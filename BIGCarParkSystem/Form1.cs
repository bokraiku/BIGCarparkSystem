using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using RDNIDWRAPPER;

namespace BIGCarParkSystem
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        string CardReader;
        RDNIDWRAPPER.RDNID mRDNIDWRAPPER = new RDNIDWRAPPER.RDNID();
        string StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        public Form1()
        {
            InitializeComponent();
            string fileName = StartupPath + "\\RDNIDLib.DLD";
            Console.WriteLine(fileName);
            if (System.IO.File.Exists(fileName) == false)
            {
                MessageBox.Show("RDNIDLib.DLD not found");
            }

            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "BIG CarPark System " + String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);


            byte[] _lic = String2Byte(fileName);

            int nres = 0;
            nres = RDNID.openNIDLibRD(_lic);
            if (nres != 0)
            {
                String m;
                m = String.Format(" error no {0} ", nres);
                MessageBox.Show(m);
            }

            byte[] Licinfo = new byte[1024];

            RDNID.getLicenseInfoRD(Licinfo);

            dld_info.Text = aByteToString(Licinfo);

            byte[] Softinfo = new byte[1024];
            RDNID.getSoftwareInfoRD(Softinfo);
            software_info.Text = aByteToString(Softinfo);

            // Download LIC Software
            this.init_downloadLIC();

 
            // List Card reader
            this.ListCardReader();
        }

        static byte[] String2Byte(string s)
        {
            // Create two different encodings.
            Encoding ascii = Encoding.GetEncoding(874);
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(s);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            return asciiBytes;
        }
        static string aByteToString(byte[] b)
        {
            Encoding ut = Encoding.GetEncoding(874); // 874 for Thai langauge
            int i;
            for (i = 0; b[i] != 0; i++) ;

            string s = ut.GetString(b);
            s = s.Substring(0, i);
            return s;
        }
        public IntPtr selectReader(String reader)
        {
            IntPtr mCard = (IntPtr)0;
            byte[] _reader = String2Byte(reader);
            IntPtr res = (IntPtr)RDNID.selectReaderRD(_reader);
            if ((Int64)res > 0)
                mCard = (IntPtr)res;
            return mCard;
        }
        String _yyyymmdd_(String d)
        {
            string s = "";
            string _yyyy = d.Substring(0, 4);
            string _mm = d.Substring(4, 2);
            string _dd = d.Substring(6, 2);


            string[] mm = { "", "ม.ค.", "ก.พ.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธ.ค." };
            string _tm = "-";
            if (_mm == "00")
            {
                _tm = "-";
            }
            else
            {
                _tm = mm[int.Parse(_mm)];
            }
            if (_yyyy == "0000")
                _yyyy = "-";

            if (_dd == "00")
                _dd = "-";

            s = _dd + " " + _tm + " " + _yyyy;
            return s;
        }

        private void ListCardReader()
        {
            byte[] szReaders = new byte[1024 * 2];
            int size = szReaders.Length;
            int numreader = RDNID.getReaderListRD(szReaders, size);
            MessageBox.Show(numreader.ToString());
            if (numreader <= 0)
                return;
            String s = aByteToString(szReaders);
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

        private void init_downloadLIC()
        {
            byte[] _lic = String2Byte(StartupPath + "\\RDNIDLib.DLD");
            int res = RDNID.updateLicenseFileRD(_lic);
            MessageBox.Show(res.ToString());
            if (res != 0)
            {
                string s = string.Format("Error : {0}", res);
                MessageBox.Show(s);
            }
        }

        private void readcard_btn_Click(object sender, EventArgs e)
        {
            if (this.CardReader != null)
            {
                readcard_btn.Text = "Loading ..";
                readcard_btn.Enabled = false;
                this.ReadCard();

                readcard_btn.Text = "Read Card";
                readcard_btn.Enabled = true;


            }
            else
            {
                MessageBox.Show("ไม่พบเครื่องอ่านบัตร กรุณาตรวจสอบ");
            }
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
            String NIDNum = aByteToString(id);

            byte[] data = new byte[1024];
            res = RDNID.getNIDTextRD(obj, data, data.Length);
            if (res != DefineConstants.NID_SUCCESS)
                return res;

            String NIDData = aByteToString(data);
            
            if (NIDData == "")
            {
                MessageBox.Show("Read Text error");
            }
            else
            {
                //download_card.Visible = false;
                //Thread.Sleep(5000);
                
                string[] fields = NIDData.Split('#');

                id_number_tb.Text = NIDNum;

                // Name Thai
                String fullname = fields[(int)NID_FIELD.TITLE_T] + " " +
                                    fields[(int)NID_FIELD.NAME_T] + " " +
                                    fields[(int)NID_FIELD.MIDNAME_T] + " " +
                                    fields[(int)NID_FIELD.SURNAME_T];
                fullname_T.Text = fullname.Trim();

                fullname = fields[(int)NID_FIELD.TITLE_E] + " " +
                                    fields[(int)NID_FIELD.NAME_E] + " " +
                                    fields[(int)NID_FIELD.MIDNAME_E] + " " +
                                    fields[(int)NID_FIELD.SURNAME_E];
                fullname_E.Text = fullname.Trim();

                m_txtBrithDate.Text = _yyyymmdd_(fields[(int)NID_FIELD.BIRTH_DATE]);

                string address = fields[(int)NID_FIELD.HOME_NO] + "   " +
                                       fields[(int)NID_FIELD.MOO] + "   " +
                                       fields[(int)NID_FIELD.TROK] + "   " +
                                       fields[(int)NID_FIELD.SOI] + "   " +
                                       fields[(int)NID_FIELD.ROAD] + "   " +
                                       fields[(int)NID_FIELD.TUMBON] + "   " +
                                       fields[(int)NID_FIELD.AMPHOE] + "   " +
                                       fields[(int)NID_FIELD.PROVINCE] + "   ";
                address_tb.Text = address.Trim();
                if (fields[(int)NID_FIELD.GENDER] == "1")
                {
                    m_txtGender.Text = "ชาย";
                }
                else
                {
                    m_txtGender.Text = "หญิง";
                }
                m_txtIssueDate.Text = _yyyymmdd_(fields[(int)NID_FIELD.ISSUE_DATE]);
                m_txtExpiryDate.Text = _yyyymmdd_(fields[(int)NID_FIELD.EXPIRY_DATE]);
                if ("99999999" == m_txtExpiryDate.Text)
                    m_txtExpiryDate.Text = "99999999 ตลอดชีพ";
                m_txtIssueNum.Text = fields[(int)NID_FIELD.ISSUE_NUM];

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
                    Bitmap MyImage = new Bitmap(img, m_picPhoto.Width - 2, m_picPhoto.Height - 2);
                    m_picPhoto.Image = (Image)MyImage;
                }

                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);

            }
           
            return 0;
        }


        enum NID_FIELD
        {
            NID_Number,   //1234567890123#

            TITLE_T,    //Thai title#
            NAME_T,     //Thai name#
            MIDNAME_T,  //Thai mid name#
            SURNAME_T,  //Thai surname#

            TITLE_E,    //Eng title#
            NAME_E,     //Eng name#
            MIDNAME_E,  //Eng mid name#
            SURNAME_E,  //Eng surname#

            HOME_NO,    //12/34#
            MOO,        //10#
            TROK,       //ตรอกxxx#
            SOI,        //ซอยxxx#
            ROAD,       //ถนนxxx#
            TUMBON,     //ตำบลxxx#
            AMPHOE,     //อำเภอxxx#
            PROVINCE,   //จังหวัดxxx#

            GENDER,     //1#			//1=male,2=female

            BIRTH_DATE, //25200131#	    //YYYYMMDD 
            ISSUE_PLACE,//xxxxxxx#      //
            ISSUE_DATE, //25580131#     //YYYYMMDD 
            EXPIRY_DATE,//25680130      //YYYYMMDD 
            ISSUE_NUM,  //12345678901234 //14-Char
            END
        };


    }
}
