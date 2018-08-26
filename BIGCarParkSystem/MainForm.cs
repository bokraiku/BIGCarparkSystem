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
using BIGCarParkSystem.Class;


namespace BIGCarParkSystem
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        // Init Class
        FunctionClass   fn = new FunctionClass();
        VisitorClass    vc = new VisitorClass();
        CompanyClass    com = new CompanyClass();
        ObjectiveClass objClass = new ObjectiveClass();
        Camera display_cam = new Camera();
        RDNIDWRAPPER.RDNID mRDNIDWRAPPER = new RDNIDWRAPPER.RDNID();

        string StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        int Camera1;
        int Camera2;
        string CardReader;

        public static int CompanySelectedID = 0;
        public static int CarTypeSelectedID = 0;
        public static int ObjectiveSelectedID = 0;
        public static int ContactId = 0;

        public string displayImage1 = "";
        public string displayImgae2 = "";

        public string idcard_image = "";

        public bool isVisitOutFound = false;

        public string OutVisitID = "";

        FileStream fs;

        BinaryReader br;
        public MainForm()
        {
            InitializeComponent();


            // trans panel
            metroStyleManager1.Style = MetroColorStyle.Blue;


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            // init defalut tab control
            main_tabcontrol.SelectedIndex = 0;
            FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            //TopMost = true;
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


            // get autocomplete
            this.AutoCompleteCompanyTB();


            fullname_tb.Focus();



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
            his_backdrop_panel.BackColor = Color.FromArgb(100, 0, 0, 0);
            backdrop_panel.BackColor = Color.FromArgb(100, 0, 0, 0);
            form_panel.BackColor = Color.FromArgb(100, 255, 255, 255);
            out_head_panel.BackColor = Color.FromArgb(100, 255, 255, 255);
            show_outform_panel.BackColor = Color.FromArgb(100, 255, 255, 255);
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

                    string name = NIDNum+ ".jpg";
                    string file = Application.StartupPath+ @"\imagesidcard" + @"\" + name;
                    if(!Directory.Exists(Application.StartupPath + @"\imagesidcard"))
                    {
                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\imagesidcard");
                    }
                    
                    MyImage.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
                    idcard_image = name;
                }

                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);

            }

            return 0;
        }

        private void capture_btn_Click(object sender, EventArgs e)
        {   string name = "Image" + fn.getRanFile();
            string file = Application.StartupPath + @"\" + name;

            display_cam.Capture(file);
            this.displayImage1 = name + ".jpg";
            camera1_display_pb.Image = Image.FromFile(file + ".jpg");
        }

        private void AutoCompleteCompanyTB()
        {
            // Company
            company_tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            company_tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            DataTable compamyDT = com.getAllCompany();

            foreach(DataRow c in compamyDT.Rows)
            {
                coll.Add(c["com_name"].ToString());
                //MessageBox.Show(c["com_name"].ToString());
            }
            compamyDT.Clear();
            company_tb.AutoCompleteCustomSource = coll;


            // Contact
            contact_tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            contact_tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection con_coll = new AutoCompleteStringCollection();
            DataTable ContactDT = objClass.getAllContact();
            foreach (DataRow c in ContactDT.Rows)
            {
                con_coll.Add(c["contact_name"].ToString());
               
            }
            contact_tb.AutoCompleteCustomSource = con_coll;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompanySelectForm cf = new CompanySelectForm();
            cf.FormClosing += new FormClosingEventHandler(Cf_FormClosing);
            cf.ShowDialog();
            cartype_select_btn.PerformClick();

            //cf.FormClosed += new FormClosedEventHandler(Cf_FormClosed);

        }

        private void Cf_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MainForm.CompanySelectedID != 0)
            {
                CompanyClass cp = new CompanyClass();
                DataTable dt = cp.GetCompanyByID(MainForm.CompanySelectedID);
                if (dt.Rows.Count > 0)
                {
                    string CompanyName = dt.Rows[0]["com_name"].ToString();
                    company_tb.Text = CompanyName;
                    //cartype_select_btn.PerformClick();
                }
                else
                {
                    MetroMessageBox.Show(this, "ไม่พบบริษัทที่เลือก กรุณาลองใหม่อีกครั้ง");
                }
            }
           
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                select_company_btn.PerformClick();
            }
            if (e.KeyCode == Keys.F6)
            {
                cartype_select_btn.PerformClick();
            }
            if (e.KeyCode == Keys.F7)
            {
                objective_select_btn.PerformClick();
            }
            if (e.KeyCode == Keys.F8)
            {
                contact_select_bt.PerformClick();
            }
            if (e.KeyCode == Keys.F9)
            {
                out_save_btn.PerformClick();
            }
        }

        private void cartype_select_btn_Click(object sender, EventArgs e)
        {
            CarSelectForm cf = new CarSelectForm();
            cf.FormClosing += new FormClosingEventHandler(CT_FormClosing);
            cf.ShowDialog();
            objective_select_btn.PerformClick();
        }

        private void CT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.CarTypeSelectedID != 0)
            {
                CartypeClass cp = new CartypeClass();
                DataTable dt = cp.getCartypeById(MainForm.CarTypeSelectedID);
                if (dt.Rows.Count > 0)
                {
                    string CartypeName = dt.Rows[0]["cartype_name"].ToString();
                    cartype_tb.Text = CartypeName;
                    
                }
                else
                {
                    MetroMessageBox.Show(this, "ไม่พบประเภทรถที่คุณเลือก");
                }
            }

        }

        private void objective_select_btn_Click(object sender, EventArgs e)
        {
            ObjectiveForm cf = new ObjectiveForm();
            cf.FormClosing += new FormClosingEventHandler(Of_FormClosing);
            cf.ShowDialog();
            contact_tb.Focus();

           
        }
        private void Of_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.ObjectiveSelectedID != 0)
            {
                ObjectiveClass cp = new ObjectiveClass();
                DataTable dt = cp.getObjectiveById(MainForm.ObjectiveSelectedID);
                if (dt.Rows.Count > 0)
                {
                    string ObjectiveName = dt.Rows[0]["obt_name"].ToString();
                    objective_tb.Text = ObjectiveName;
                }
                else
                {
                    MetroMessageBox.Show(this, "ไม่พบวัตถุประสงค์ กรุณาลองใหม่อีกครั้ง");
                }
            }

        }

        private void contact_select_bt_Click(object sender, EventArgs e)
        {
            ContactSelectForm cf = new ContactSelectForm();
            cf.FormClosing += new FormClosingEventHandler(CF_FormClosing);
            cf.ShowDialog();
            comment_tb.Focus();
        }
        private void CF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.ContactId != 0)
            {
                ObjectiveClass cp = new ObjectiveClass();
                DataTable dt = cp.getContactByID(MainForm.ContactId);
                if (dt.Rows.Count > 0)
                {
                    string contactName = dt.Rows[0]["contact_name"].ToString();
                    contact_tb.Text = contactName;
                }
                else
                {
                    MetroMessageBox.Show(this, "ไม่พบวัตถุประสงค์ กรุณาลองใหม่อีกครั้ง");
                }
            }

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("คุณต้องการบันทึกข้อมูลหรือไม่", "ยืนยันการบันทึก", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                String fullname = fullname_tb.Text.Trim();
                String idcard = idcard_tb.Text.Trim();
                String tel = tel_tb.Text.Trim();
                String carId = carid_tb.Text.Trim();
                String Company = company_tb.Text.Trim();
                String CarType = cartype_tb.Text.Trim();
                String Objective = objective_tb.Text.Trim();
                String Comment = comment_tb.Text.Trim();
                String ContactName = contact_tb.Text.Trim();

                String CompanyId = "";
                String CartypeId = "";
                String ObjectiveId = "";
                String ContactId = "";
                if (fullname.Equals(String.Empty))
                {
                    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                    MessageBox.Show(this, "กรุณาระบุชื่อ-สกุล", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fullname_tb.Focus();
                    return;
                }
                if (idcard.Equals(String.Empty))
                {
                    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                    MessageBox.Show(this, "กรุณาระบุรหัสบัตรประชาชน", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    idcard_tb.Focus();
                    return;
                }
                if (fn.checkIdCard(idcard) == false)
                {
                    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                    MessageBox.Show(this, "กรุณากรอกรหัสบัตรประชาชนให้ถูกต้อง", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    idcard_tb.Focus();
                    return;
                }


                if (tel.Equals(String.Empty))
                {
                    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                    MessageBox.Show(this, "กรุณาระบุเบอร์โทร", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tel_tb.Focus();
                    return;
                }

                if (fn.checkTel(tel) == false)
                {
                    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                    MessageBox.Show(this, "กรุณากรอกเบอร์โทรให้ถูกต้อง", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tel_tb.Focus();
                    return;
                }

                if (carId.Equals(String.Empty))
                {
                    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                    MessageBox.Show(this, "กรุณากรอกทะเบียนรถ", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    carid_tb.Focus();
                    return;
                }

                if (Company.Equals(String.Empty))
                {
                    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                    MessageBox.Show(this, "กรุณากรอกบริษัท", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    company_tb.Focus();
                    return;
                }

                if (CarType.Equals(String.Empty))
                {
                    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                    MessageBox.Show(this, "กรุณากรอกประเภทรถ", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cartype_tb.Focus();
                    return;
                }

                if (Objective.Equals(String.Empty))
                {
                    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                    MessageBox.Show(this, "กรุณากรอกวัตถุประสงค์", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objective_tb.Focus();
                    return;
                }
                CompanyClass com = new CompanyClass();
                DataTable dt = com.GetCompanyByName(Company);
                if (dt.Rows.Count < 1)
                {
                    CompanyId = com.InsertCompany(Company);
                    if (CompanyId.Equals(String.Empty))
                    {
                        MessageBox.Show(this, "ไม่สามารถบันทึกข้อมูลบริษัทได้ กรุณาจรวจสอบอีกครั้ง", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        company_tb.Focus();
                        return;
                    }
                }
                else
                {
                    CompanyId = dt.Rows[0]["com_id"].ToString();
                }
                dt.Clear();
                CartypeClass cc = new CartypeClass();
                dt = cc.getCarTypeByName(CarType);

                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show(this, "ประเภทรถไม่มีในระบบกรุณาตรวจสอบอีกครั้ง", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    CartypeId = dt.Rows[0]["cartype_id"].ToString();
                }
                dt.Clear();
                ObjectiveClass oc = new ObjectiveClass();
                dt = oc.getObjectiveByName(Objective);
                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show(this, "วัตถุประสงค์ที่เลือกไม่มีในระบบ", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    ObjectiveId = dt.Rows[0]["obt_id"].ToString();
                }



                if (!ContactName.Equals(String.Empty))
                {
                    dt.Clear();
                    dt = objClass.getContactByName(ContactName);
                    if (dt.Rows.Count < 1)
                    {
                        ContactId = objClass.InsertContact(ContactName);
                        if (ContactId.Equals(String.Empty))
                        {
                            MessageBox.Show(this, "ไม่สามารถบันทึกข้อมูลผู้มาติดต่อได้ กรุณาจรวจสอบอีกครั้ง", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            contact_tb.Focus();
                            return;
                        }
                    }
                    else
                    {
                        ContactId = dt.Rows[0]["contact_id"].ToString();
                    }
                }
                else
                {
                    ContactId = MainForm.ContactId.ToString();
                }
                if (this.displayImage1 == "")
                {
                    MessageBox.Show(this, "กรุณาถ่ายรูปผู้มาติดต่อ", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                VisitorClass vc = new VisitorClass();
                String visit_id = vc.InsertVisitData(UserInfo.UserId, CartypeId, CompanyId, ObjectiveId, fullname, carId, idcard, tel, Comment, ContactId, this.displayImage1, this.idcard_image);

                if (visit_id == "")
                {
                    MessageBox.Show(this, "ไม่สามารถบันทึกข้อมูลได้ กรุณาตรวจสอบความถูกต้อง", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(this, "บันทึกข้อมูลสำเร็จ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearDataInControl(panel2);
                    idcard_pb.Image = null;
                    camera1_display_pb.Image = null;
                }
            }



        }

        private void cartype_tb_Click(object sender, EventArgs e)
        {
            cartype_select_btn.PerformClick();
        }

        private void objective_tb_Click(object sender, EventArgs e)
        {
            objective_select_btn.PerformClick();
        }

        private void main_tabcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = main_tabcontrol.SelectedIndex;
            
            if(index == 1)
            {
                out_input_tb.Focus();
                show_outform_panel.Visible = false;
                if (this.isVisitOutFound == true)
                {
                    show_outform_panel.Visible = true;
                }

            }
        }

        private void scan_barcode_btn_Click(object sender, EventArgs e)
        {
            string inputSearch = out_input_tb.Text.Trim();
           
            if (inputSearch.Equals(String.Empty))
            {
                MessageBox.Show(this, "กรุณากรอกข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                out_input_tb.Focus();
            }

            DataTable visitorDT = vc.getVisitorInfo(inputSearch);
            if(visitorDT.Rows.Count < 1)
            {
                MessageBox.Show(this, "ไม่พบข้อมูลที่ค้นหา กรุณาตรวจสอบอีกครั้ง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                this.isVisitOutFound = true;
                show_outform_panel.Visible = true;
                this.OutVisitID = visitorDT.Rows[0]["visit_id"].ToString();
                out_indate_tb.Text = fn.ConvertDate(visitorDT.Rows[0]["visit_datetime_in"].ToString());
                out_fullname_tb.Text = visitorDT.Rows[0]["visit_name"].ToString();
                out_idcard_tb.Text   = visitorDT.Rows[0]["id_card"].ToString();
                out_tel_tb.Text = visitorDT.Rows[0]["tel"].ToString();
                out_carid_tb.Text = visitorDT.Rows[0]["car_id"].ToString();
                out_company_tb.Text = visitorDT.Rows[0]["com_name"].ToString();
                out_cartype_tb.Text = visitorDT.Rows[0]["cartype_name"].ToString();
                out_objective_tb.Text = visitorDT.Rows[0]["obt_name"].ToString();
                out_contact_tb.Text = visitorDT.Rows[0]["contact_name"].ToString();
                out_comment_tb.Text = visitorDT.Rows[0]["comment"].ToString();

                if(visitorDT.Rows[0]["image_1"].ToString() != "")
                {
                    out_image1_pb.Image = Image.FromFile(VariableDB.PathImage + visitorDT.Rows[0]["image_1"].ToString());
                }
                if (visitorDT.Rows[0]["image_2"].ToString() != "")
                {
                    out_image2_pb.Image = Image.FromFile(VariableDB.PathImage + visitorDT.Rows[0]["image_2"].ToString());
                }
                if (visitorDT.Rows[0]["idcard_image"].ToString() != "")
                {
                    out_idcardpic_pb.Image = Image.FromFile(VariableDB.PathIdCardImage + visitorDT.Rows[0]["idcard_image"].ToString());
                }
            }
        }

        private void idcard_pb_Click(object sender, EventArgs e)
        {

        }

        private void out_input_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                scan_barcode_btn.PerformClick();
            }
        }

        private void out_save_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("คุณต้องการบันทึกข้อมูลหรือไม่", "ยืนยันการบันทึก", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes && this.OutVisitID != "")
            {
                //do something


                DataTable vDT = vc.getVisitByID(this.OutVisitID);
                if (vDT.Rows.Count < 1)
                {
                    MessageBox.Show(this, "ไม่พบข้อมูลที่ต้องการบันทึก กรุณาตรวจสอบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rowCount = vc.UpdateVisitInfo(this.OutVisitID);

                if (rowCount == 0)
                {
                    MessageBox.Show(this, "ไม่สามารถบันทึกข้อมูลได้ กรุณาตรวจสอบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                   
                    this.isVisitOutFound = false;
                    //show_outform_panel.Visible = false;
                    MessageBox.Show(this, "บันทึกข้อมูลสำเร็จ", "ข้อความ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearDataInControl(show_outform_panel);
                    out_image1_pb.Image = null;
                    out_image2_pb.Image = null;
                    out_idcardpic_pb.Image = null;
                    out_input_tb.Text = string.Empty;
                    out_input_tb.Focus();

                }
            }

        }
        private void ClearDataInControl(Panel panel)
        {
            foreach (Control c in panel.Controls)
            {
                var box = c as MetroFramework.Controls.MetroTextBox;
                //MessageBox.Show(box.Name);
                if (box != null)
                {
                   
                    box.Text = string.Empty;
                }
                var boxSystem = c as TextBox;
                if (boxSystem != null)
                {

                    boxSystem.Text = string.Empty;
                }

            }
        }
    }




}
