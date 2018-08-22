using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using DarrenLee.Media;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using RDNIDWRAPPER;
using BIGCarParkSystem.Resources;


namespace BIGCarParkSystem
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        FunctionClass fn = new FunctionClass();
        Camera display_cam = new Camera();
        RDNIDWRAPPER.RDNID mRDNIDWRAPPER = new RDNIDWRAPPER.RDNID();

        string StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        int Camera1;
        int Camera2;
        string CardReader;
        public MainForm()
        {
            InitializeComponent();
            

            // trans panel
            

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            TopMost = true;
            this.GetCameraInfo();
            display_cam.OnFrameArrived += new FrameArrivedEventHandler(myCam_OnFrameArrived);


            display_cam.Start(2);

            // transparant panel
            this.transparent_bg();

            // check RDNIDLib.DLD for read id card
            string fileDLC = StartupPath + "\\RDNIDLib.DLD";
            if (System.IO.File.Exists(fileDLC) == false)
            {
                MessageBox.Show("RDNIDLib.DLD not found");
            }

            byte[] _lic = fn.String2Byte(fileDLC);

            int nres = 0;
            nres = RDNID.openNIDLibRD(_lic);
            if (nres != 0)
            {
                String m;
                m = String.Format(" error no {0} ", nres);
                MessageBox.Show(m);
            }

            // Download LIC Software
            this.init_downloadLIC();

            // List Card reader
            this.ListCardReader();



        }

        public void myCam_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            camera1_pb.Image = img;
        }

        private void GetCameraInfo()
        {
            var cameraDevice = display_cam.GetCameraSources();
            var cameraResolution = display_cam.GetSupportedResolutions();
            if(cameraDevice[0] != null)
            {
                Camera1 = 0;
            }
            




        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            display_cam.Stop();
        }

        private void transparent_bg()
        {
            c_panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            c_panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            c_panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            c_panel4.BackColor = Color.FromArgb(100, 0, 0, 0);
            left_panel.BackColor = Color.FromArgb(100, 0, 0, 0);
            right_panel.BackColor = Color.FromArgb(100, 0, 0, 0);
            form_panel.BackColor = Color.FromArgb(200, 200, 200, 200);
        }

        private void scancard_btn_Click(object sender, EventArgs e)
        {
            if (this.CardReader != null)
            {
               
                this.ReadCard();



            }
            else
            {
                MessageBox.Show("ไม่พบเครื่องอ่านบัตร กรุณาตรวจสอบ");
            }
        }

        private void init_downloadLIC()
        {
            byte[] _lic = fn.String2Byte(StartupPath + "\\RDNIDLib.DLD");
            int res = RDNID.updateLicenseFileRD(_lic);
            if (res != 0)
            {
                string s = string.Format("Error : {0}", res);
                MessageBox.Show(s);
            }
        }

        private void ListCardReader()
        {
            byte[] szReaders = new byte[1024 * 2];
            int size = szReaders.Length;
            int numreader = RDNID.getReaderListRD(szReaders, size);
            if (numreader <= 0)
                return;
            String s = fn.aByteToString(szReaders);
            String[] readlist = s.Split(';');
            if (readlist != null)
            {
                for (int i = 0; i < readlist.Length; i++)
                {

                    this.CardReader = readlist[i];
                    
                }


                //m_ListReaderCard.SelectedIndex = 0;
            }
        }
        public IntPtr selectReader(String reader)
        {
            IntPtr mCard = (IntPtr)0;
            byte[] _reader = fn.String2Byte(reader);
            IntPtr res = (IntPtr)RDNID.selectReaderRD(_reader);
            if ((Int64)res > 0)
                mCard = (IntPtr)res;
            return mCard;
        }

        protected int ReadCard()
        {

            String strTerminal = this.CardReader;

            IntPtr obj = selectReader(strTerminal);
            

            Int32 nInsertCard = 0;
            nInsertCard = RDNID.connectCardRD(obj);
            if (nInsertCard != 0)
            {
                String m;
                m = String.Format(" error no {0} ", nInsertCard);
                MessageBox.Show(m);

                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);
                return nInsertCard;
            }

            byte[] id = new byte[30];
            int res = RDNID.getNIDNumberRD(obj, id);
            if (res != DefineConstants.NID_SUCCESS)
                return res;
            String NIDNum = fn.aByteToString(id);

            byte[] data = new byte[1024];
            res = RDNID.getNIDTextRD(obj, data, data.Length);
            if (res != DefineConstants.NID_SUCCESS)
                return res;

            String NIDData = fn.aByteToString(data);

            if (NIDData == "")
            {
                MessageBox.Show("Read Text error");
            }
            else
            {
                //download_card.Visible = false;
                //Thread.Sleep(5000);

                string[] fields = NIDData.Split('#');

                idcard_tb.Text = NIDNum;

                // Name Thai
                string fullname = fields[(int)FunctionClass.NID_FIELD.TITLE_T] + " " +
                                    fields[(int)FunctionClass.NID_FIELD.NAME_T] + " " +
                                    fields[(int)FunctionClass.NID_FIELD.MIDNAME_T] + " " +
                                    fields[(int)FunctionClass.NID_FIELD.SURNAME_T];
                fullname_tb.Text = fullname.Trim();

               

                string birthday = fn._yyyymmdd_(fields[(int)FunctionClass.NID_FIELD.BIRTH_DATE]);

                string address = fields[(int)FunctionClass.NID_FIELD.HOME_NO] + "   " +
                                       fields[(int)FunctionClass.NID_FIELD.MOO] + "   " +
                                       fields[(int)FunctionClass.NID_FIELD.TROK] + "   " +
                                       fields[(int)FunctionClass.NID_FIELD.SOI] + "   " +
                                       fields[(int)FunctionClass.NID_FIELD.ROAD] + "   " +
                                       fields[(int)FunctionClass.NID_FIELD.TUMBON] + "   " +
                                       fields[(int)FunctionClass.NID_FIELD.AMPHOE] + "   " +
                                       fields[(int)FunctionClass.NID_FIELD.PROVINCE] + "   ";

                string gender;
                if (fields[(int)FunctionClass.NID_FIELD.GENDER] == "1")
                {
                    gender = "ชาย";
                }
                else
                {
                    gender = "หญิง";
                }
              

                byte[] NIDPicture = new byte[1024 * 5];
                int imgsize = NIDPicture.Length;
                res = RDNID.getNIDPhotoRD(obj, NIDPicture, out imgsize);
                if (res != DefineConstants.NID_SUCCESS)
                    return res;

                byte[] byteImage = NIDPicture;
                if (byteImage == null)
                {
                    MessageBox.Show("Read Photo error");
                }
                else
                {
                    //m_picPhoto
                    Image img = Image.FromStream(new MemoryStream(byteImage));
                    Bitmap MyImage = new Bitmap(img, idcard_pb.Width - 2, idcard_pb.Height - 2);
                    idcard_pb.Image = (Image)MyImage;
                }

                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);

            }

            return 0;
        }

        private void capture_btn_Click(object sender, EventArgs e)
        {
            string file = Application.StartupPath + @"\" + "Image" + fn.getRanFile();

            display_cam.Capture(file);
            camera1_display_pb.Image = Image.FromFile(file + ".jpg");
        }
    }




}
