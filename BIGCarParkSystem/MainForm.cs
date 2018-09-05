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
using Newtonsoft.Json;



namespace BIGCarParkSystem
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        // Init Class
        FunctionClass fn = new FunctionClass();
        VisitorClass vc = new VisitorClass();
        CompanyClass com = new CompanyClass();
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
        public string objectiveID = "0";

        FileStream fs;

        BinaryReader br;
        public MainForm()
        {
            InitializeComponent();


            // trans panel
            metroStyleManager1.Style = MetroColorStyle.Blue;

            // check every 30 minutes
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = (1000*60)*30;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();


        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
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


            display_cam.Start(0);
           

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

            this.checkPrivileges();


            history_gridview.DefaultCellStyle.Font = new Font("Ansana New", 18, GraphicsUnit.Pixel);


            

        }
       

        public void Callback(object state)
        {
            Console.WriteLine("The current time is {0}", DateTime.Now);
        }

        private void checkPrivileges()
        {
            //Check Privileges
            if (UserInfo.UserRole != "1")
            {
                admin_bg_panel.Visible = false;
                objective_panel_bg.Visible = false;
              
                
                for(int i = 0;i < 2; i++)
                {
                    Label ll = new Label();
                    Label ll2 = new Label();
                    ll.Width = 500;
                    ll.Height = 50;
                    ll.TextAlign = ContentAlignment.MiddleCenter;
                    ll.BackColor = Color.FromArgb(100, 255, 255, 255);
                    ll.ForeColor = Color.FromArgb(0, 255, 0, 0);
                    ll.Text = "คุณไม่มีสิทธิ์ใช้งานระบบนี้";
                    ll.Font = new Font("Tahoma", 14, FontStyle.Bold);
                    ll.Left = (userTab.Width / 2) - (ll.Width / 2);
                    ll.Top = 50;

                    if(i == 0)
                    {
                        userTab.Controls.Add(ll);
                    }
                    if(i == 1)
                    {
                        objective_tab.Controls.Add(ll);
                    }
                   
                }
               
                //objective_tab.Controls.Add(ll2);


            }

           
        }

        public void myCam_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            img = resizeImage(img, new Size(450, 350));
            camera1_pb.Image = img;


        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }


        private void GetCameraInfo()
        {
            var cameraDevice = display_cam.GetCameraSources();
            var cameraResolution = display_cam.GetSupportedResolutions();
            if (cameraDevice[0] != null)
            {
                Camera1 = 0;
            }
            if(cameraResolution.Count < 1)
            {
                MessageBox.Show("ตรวจสอบไม่พบกล้อง กรุณาเช็คอุปกรณ์อีกครั้ง");
                Application.Restart();
                return;
            }
            foreach (var r in cameraResolution)
            {
               
               
                //object obj = JObjec
                String json = r.ToString();
                String NewJson = json.Replace('=', ':');
                Console.WriteLine(NewJson);
                Dictionary<string, string> resolution = JsonConvert.DeserializeObject<Dictionary<string, string>>(NewJson);
                string showText = resolution["Width"] + " X " + resolution["Height"];
                change_resolution_cb.Items.Add(showText);
            }
            change_resolution_cb.SelectedIndex = 0;



        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            display_cam.Stop();
        }

        private void transparent_bg()
        {
            c_panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
          
            c_panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
          
            left_panel.BackColor = Color.FromArgb(100, 0, 0, 0);
            right_panel.BackColor = Color.FromArgb(100, 0, 0, 0);
            admin_manage_panel.BackColor = Color.FromArgb(100, 0, 0, 0);
            objective_manage_panel.BackColor = Color.FromArgb(100, 0, 0, 0);
            his_backdrop_panel.BackColor = Color.FromArgb(100, 0, 0, 0);
            backdrop_panel.BackColor = Color.FromArgb(100, 0, 0, 0);
            form_panel.BackColor = Color.FromArgb(100, 255, 255, 255);
            out_head_panel.BackColor = Color.FromArgb(100, 255, 255, 255);
            show_outform_panel.BackColor = Color.FromArgb(100, 255, 255, 255);
            his_head_panel.BackColor = Color.FromArgb(100, 255, 255, 255);
            his_data_panel.BackColor = Color.FromArgb(100, 255, 255, 255);

            admin_head_panel.BackColor = Color.FromArgb(100, 255, 255, 255);
            objective_group.BackColor = Color.FromArgb(100, 255, 255, 255);
        }

        private void scancard_btn_Click(object sender, EventArgs e)
        {
            if (this.CardReader != null)
            {

                this.ReadCard();
                this.carid_tb.Focus();


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

                    string name = NIDNum + ".jpg";
                    string file = Application.StartupPath + @"\imagesidcard" + @"\" + name;
                    if (!Directory.Exists(Application.StartupPath + @"\imagesidcard"))
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
        {
            string name = "Image" + fn.getRanFile();
            string file = Application.StartupPath + @"\" + name;

            display_cam.Capture(file);
            this.displayImage1 = name + ".jpg";
            camera1_display_pb.Image = Image.FromFile(file + ".jpg");

            Image img = resizeImage(Image.FromFile(file + ".jpg"), new Size(450, 350));
            //camera1_pb.Image = img;
            camera1_display_pb.Image = img;
        }

        private void AutoCompleteCompanyTB()
        {
            // Company
            company_tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            company_tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            DataTable compamyDT = com.getAllCompany();

            foreach (DataRow c in compamyDT.Rows)
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
            //cartype_select_btn.PerformClick();
            objective_select_btn.PerformClick();

            //cf.FormClosed += new FormClosedEventHandler(Cf_FormClosed);

        }

        private void Cf_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.CompanySelectedID != 0)
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
            if (e.KeyCode == Keys.F5)
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
            //objective_select_btn.PerformClick();
            select_company_btn.PerformClick();
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
                //String tel = tel_tb.Text.Trim();
                String carId = carid_tb.Text.Trim();
                String Company = company_tb.Text.Trim();
                String CarType = cartype_tb.Text.Trim();
                String Objective = objective_tb.Text.Trim();
                String Comment = comment_tb.Text.Trim();
                String ContactName = contact_tb.Text.Trim();
                string visitor_amount = visitor_amount_tb.Text.Trim();

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


                //if (tel.Equals(String.Empty))
                //{
                //    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                //    MessageBox.Show(this, "กรุณาระบุเบอร์โทร", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    tel_tb.Focus();
                //    return;
                //}

                //if (fn.checkTel(tel) == false)
                //{
                //    //MetroMessageBox.Show(this, "กรุณาระบุชื่อ-สกุล");
                //    MessageBox.Show(this, "กรุณากรอกเบอร์โทรให้ถูกต้อง", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    tel_tb.Focus();
                //    return;
                //}

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
                // Get Barcode

                String NewBar = fn.getRanFile();
                String BarcodeFull = NewBar + Barcode.CheckSumBarcode(NewBar).ToString();
                Barcode.GenBarcodeImg(BarcodeFull);

                VisitorClass vc = new VisitorClass();
                String visit_id = vc.InsertVisitData(UserInfo.UserId, CartypeId, CompanyId, ObjectiveId, fullname, carId, idcard, null, Comment, ContactId, this.displayImage1, this.idcard_image, BarcodeFull,visitor_amount);

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

                    // print bill
                    VisitorReportForm cf = new VisitorReportForm();
                    DataSet dst = new DataSet();
                    DataTable vcdt = vc.getVisitorInfoById(visit_id);
                    dst.Tables.Add(vcdt);
                    cf.DsReport = dst;

                    cf.ShowDialog();


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

            if (index == 1)
            {
                out_input_tb.Focus();
                show_outform_panel.Visible = false;
                if (this.isVisitOutFound == true)
                {
                    show_outform_panel.Visible = true;
                }

            }
            if (index == 2)
            {
                this.ConfigHeaderHistoryGridView();
                this.getHistoryData();


            }

            if(index == 3 && UserInfo.UserRole == "1")
            {
                MemberClass member = new MemberClass();
                DataTable dt = member.getAllRole();
                DataRow drRole = dt.NewRow();
                drRole["role_name"] = "กรุณาเลือกสิทธิ์การใช้งาน";
                drRole["role_id"] = "0";

                dt.Rows.Add(drRole);
                admin_role_cb.DisplayMember = "role_name";
                admin_role_cb.ValueMember = "role_id";
                admin_role_cb.DataSource = dt;
                admin_role_cb.SelectedValue = "0";

                //DataTable dtacc = member.getAllUser();
                this.ConfigHeaderAccountGridView();
                this.getAccountData();

            }
            if (index == 4 && UserInfo.UserRole == "1")
            {
                this.ConfigHeaderObjectiveGridView();
                this.getobjectiveData();
                // Objective manage
                ObjectiveClass objC = new ObjectiveClass();
                DataTable objDT = objC.getAllObjective();

                
            }


        }

        private void scan_barcode_btn_Click(object sender, EventArgs e)
        {
            string inputSearch = out_input_tb.Text.Trim();

            if (inputSearch.Equals(String.Empty))
            {
                MessageBox.Show(this, "กรุณากรอกข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                out_input_tb.Focus();
                return;
            }

            DataTable visitorDT = vc.getVisitorInfo(inputSearch);
            if (visitorDT.Rows.Count < 1)
            {
                MessageBox.Show(this, "ไม่พบข้อมูลที่ค้นหา กรุณาตรวจสอบอีกครั้ง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                this.isVisitOutFound = true;
                show_outform_panel.Visible = true;
                this.OutVisitID = visitorDT.Rows[0]["visit_id"].ToString();
                out_indate_tb.Text = fn.ConvertDate(visitorDT.Rows[0]["visit_datetime_in"].ToString());
                out_fullname_tb.Text = visitorDT.Rows[0]["visit_name"].ToString();
                out_idcard_tb.Text = visitorDT.Rows[0]["id_card"].ToString();
                
                out_carid_tb.Text = visitorDT.Rows[0]["car_id"].ToString();
                out_company_tb.Text = visitorDT.Rows[0]["com_name"].ToString();
                out_cartype_tb.Text = visitorDT.Rows[0]["cartype_name"].ToString();
                out_objective_tb.Text = visitorDT.Rows[0]["obt_name"].ToString();
                out_contact_tb.Text = visitorDT.Rows[0]["contact_name"].ToString();
                out_comment_tb.Text = visitorDT.Rows[0]["comment"].ToString();

                if (visitorDT.Rows[0]["image_1"].ToString() != "")
                {
                    out_image1_pb.Image = Image.FromFile(VariableDB.PathImage + visitorDT.Rows[0]["image_1"].ToString());
                }
                //if (visitorDT.Rows[0]["image_2"].ToString() != "")
                //{
                //    out_image2_pb.Image = Image.FromFile(VariableDB.PathImage + visitorDT.Rows[0]["image_2"].ToString());
                //}
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
            if (e.KeyCode == Keys.Enter)
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
                    //out_image2_pb.Image = null;
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
        
        public void ConfigHeaderObjectiveGridView()
        {
            this.objective_datagrid.AllowUserToAddRows = false;
            this.objective_datagrid.Refresh();
            this.objective_datagrid.ColumnCount = 3;
            this.objective_datagrid.Columns[0].Name = "เลขที่";
            this.objective_datagrid.Columns[0].ReadOnly = true;
            this.objective_datagrid.Columns[1].Name = "ชื่อวัตถุประสงค์";
            this.objective_datagrid.Columns[1].ReadOnly = true;
            this.objective_datagrid.Columns[2].Name = "กลุ่ม";
            this.objective_datagrid.Columns[2].ReadOnly = true;



        }

        public void ConfigHeaderAccountGridView()
        {
            this.manage_user_gridview.AllowUserToAddRows = false;
            this.manage_user_gridview.Refresh();
            this.manage_user_gridview.ColumnCount = 4;
            this.manage_user_gridview.Columns[0].Name = "รหัสผู้ใช้งาน";
            this.manage_user_gridview.Columns[0].ReadOnly = true;
            this.manage_user_gridview.Columns[1].Name = "Username";
            this.manage_user_gridview.Columns[1].ReadOnly = true;
            this.manage_user_gridview.Columns[2].Name = "สิทธิ์การใช้งาน";
            this.manage_user_gridview.Columns[2].ReadOnly = true;
            this.manage_user_gridview.Columns[3].Name = "วันที่เพิ่ม";
            this.manage_user_gridview.Columns[3].ReadOnly = true;


        }

        public void ConfigHeaderHistoryGridView()
        {
            this.history_gridview.AllowUserToAddRows = false;
            this.history_gridview.Refresh();
            this.history_gridview.ColumnCount = 6;
            this.history_gridview.Columns[0].Name = "เลขที่";
            this.history_gridview.Columns[0].ReadOnly = true;
            this.history_gridview.Columns[1].Name = "ทะเบียน";
            this.history_gridview.Columns[1].ReadOnly = true;
            this.history_gridview.Columns[2].Name = "บริษัท";
            this.history_gridview.Columns[2].ReadOnly = true;
            this.history_gridview.Columns[3].Name = "เวลาเข้า";
            this.history_gridview.Columns[3].ReadOnly = true;
            this.history_gridview.Columns[4].Name = "เวลาออก";
            this.history_gridview.Columns[4].ReadOnly = true;
            this.history_gridview.Columns[5].Name = "ชื่อ";
            this.history_gridview.Columns[5].ReadOnly = true;

        }

        

        public void getobjectiveData()
        {
            this.objective_datagrid.Rows.Clear();
            this.objective_datagrid.AllowUserToAddRows = false;
            this.objective_datagrid.Refresh();
            ObjectiveClass objClass = new ObjectiveClass();
            DataTable ObjectiveDT = objClass.getAllObjective();


            if (ObjectiveDT.Rows.Count > 0)
            {
                foreach (DataRow dr in ObjectiveDT.Rows)
                {
                    String obt_id   = dr["obt_id"].ToString();
                    String obt_name = dr["obt_name"].ToString();

                    String group_id = dr["group"].ToString();
                    //String create_date = fn.ConvertDate(dr["create_date"].ToString());



                    String[] rows = { obt_id, obt_name, group_id };
                    this.objective_datagrid.Rows.Add(rows);


                }

            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลผู้ใช้งาน");
            }


        }

        public void getAccountData()
        {
            this.manage_user_gridview.Rows.Clear();
            this.manage_user_gridview.AllowUserToAddRows = false;
            this.manage_user_gridview.Refresh();
            MemberClass mem = new MemberClass();
            DataTable AccountDT = mem.getAllUser();
            

            if(AccountDT.Rows.Count > 0)
            {
                foreach (DataRow dr in AccountDT.Rows)
                {
                    String acc_id = dr["acc_id"].ToString();
                    String ac_name = dr["username"].ToString();

                    String role_name = dr["role_name"].ToString();
                    String create_date = fn.ConvertDate(dr["create_date"].ToString());



                    String[] rows = { acc_id, ac_name, role_name, create_date };
                    this.manage_user_gridview.Rows.Add(rows);


                }

            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลผู้ใช้งาน");
            }


        }

        public void getHistoryData(DataTable _hisDT = null)
        {
            this.history_gridview.Rows.Clear();
            this.history_gridview.AllowUserToAddRows = false;
            this.history_gridview.Refresh();
            DataTable hisDT;
            DataTable ReportDT;
           
            if (_hisDT == null)
            {
                hisDT = vc.getAllVisitorInfo();
                ReportDT = vc.getAllVisitorInfo();
              
                VisitorClass.VisitDS.Clear();
                VisitorClass.VisitDS.Reset();
                VisitorClass.VisitDS.Tables.Add(ReportDT.Copy());
                //HisDSS.Tables.Add(vc.getAllVisitorInfo());
            }
            else
            {
                hisDT = _hisDT;
                VisitorClass.VisitDS.Clear();
                VisitorClass.VisitDS.Reset();
                VisitorClass.VisitDS.Tables.Add(hisDT.Copy());
            }
            
            

            foreach (DataRow dr in hisDT.Rows)
            {
                String visit_id = dr["visit_id"].ToString();
                String car_id = dr["car_id"].ToString();

                String com_name = dr["com_name"].ToString();
                String visit_datetime_in = fn.ConvertDate(dr["visit_datetime_in"].ToString());
                String visit_datetime_out = "";
                if (dr["visit_datetime_out"].ToString() == "")
                {
                    visit_datetime_out = "-";
                }
                else
                {
                    visit_datetime_out = fn.ConvertDate(dr["visit_datetime_out"].ToString());
                }
                
                String visit_name = dr["visit_name"].ToString();



                String[] rows = { visit_id,car_id, com_name,visit_datetime_in,visit_datetime_out, visit_name };
                this.history_gridview.Rows.Add(rows);





            }
        }

        private void history_gridview_DoubleClick(object sender, EventArgs e)
        {

        }

        private void history_gridview_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            String visit_id = this.history_gridview.Rows[RowIndex].Cells[0].Value.ToString();
            if (visit_id == "" || visit_id == null)
            {
                MessageBox.Show("ขออภัยข้อมูลไม่ถูกต้อง");
                return;
            }
            
            ViewVisitHistoryForm cf = new ViewVisitHistoryForm();
            ViewVisitHistoryForm.VisitID = visit_id;
            cf.FormClosing += Cf_FormClosing1;
           
            cf.ShowDialog();
        }

        private void Cf_FormClosing1(object sender, FormClosingEventArgs e)
        {
            button2.PerformClick();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClearDataInControl(panel2);
            idcard_pb.Image = null;
            camera1_display_pb.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string searchHistory = his_search_box.Text.Trim();
            string start_date = fn.ConvertDateV2(from_datetime.Text.Trim()) + " 00:00:01";
            string end_date = fn.ConvertDateV2(to_datetime.Text.Trim()) + " 23:59:59";
            bool isOut = his_noout_rb.Checked;

            //MessageBox.Show(isOut.ToString());
            if (searchHistory.Equals(string.Empty) && isOut == false )
            {
                getHistoryData();
            }
            else
            {
                DataTable historyDT = vc.getAllVisitorInfoHistory(searchHistory,start_date,end_date,isOut);

               

                if (historyDT.Rows.Count > 0)
                {
                    getHistoryData(historyDT);
                    //DataSet _HisDS = new DataSet();
                    //_HisDS.Tables.Add(historyDT);
                    //VisitorClass.VisitDS = _HisDS;
                }
                else
                {
                    MessageBox.Show(this, "ไม่พบข้อมูลที่ค้นหา", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void his_search_box_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        private void admin_save_bt_Click(object sender, EventArgs e)
        {
            string username = admin_username_tb.Text.Trim();
            string password = admin_password_tb.Text;
            string conPassword = admin_conpass_tb.Text;
            string roleId = admin_role_cb.SelectedValue.ToString();
            if (username.Equals(string.Empty) || password.Equals(string.Empty) || conPassword.Equals(string.Empty))
            {
                MessageBox.Show(this, "กรุณากรอกข้อมูลให้ครบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(password != conPassword)
            {
                MessageBox.Show(this, "กรุณากรอกรหัสผ่านให้ตรงกัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(roleId == null || roleId == "0")
            {
                MessageBox.Show(this, "กรุณาเลือกสิทธิ์การใช้งาน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string md5Pass = fn.MD5Hash(password);
            MemberClass member = new MemberClass();
            DataTable adminDT = member.checkUsername(username);
            if(adminDT.Rows.Count > 0)
            {
                MessageBox.Show(this, "Username นี้มีในระบบแล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string index = member.InsertAccount(username, md5Pass, roleId);
            if(index == "")
            {
                MessageBox.Show(this, "ไม่สามารถบันททึกข้อมูลได้", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show(this, "บันทึกข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.getAccountData();
                return;
            }

        }

        private void left_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            HistoryReportForm hsr = new HistoryReportForm();
            hsr.DsReport = VisitorClass.VisitDS;
            hsr.ShowDialog();
        }

        private void change_resolution_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            display_cam.Start(change_resolution_cb.SelectedIndex);
            
        }

        private void manage_user_gridview_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            String Userid = this.manage_user_gridview.Rows[RowIndex].Cells[0].Value.ToString();
            if (Userid == "" || Userid == null)
            {
                MessageBox.Show("ขออภัยข้อมูลไม่ถูกต้อง");
                return;
            }

           
            EditUserForm ef = new EditUserForm();
            EditUserForm.UserID = Userid;
            ef.FormClosing += Ef_FormClosing;

            ef.ShowDialog();
        }

        private void Ef_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.getAccountData();
        }

        private void delete_objective_Click(object sender, EventArgs e)
        {
            int selectedRow = objective_datagrid.CurrentCell.RowIndex;
            string obt_id = objective_datagrid.Rows[selectedRow].Cells[0].Value.ToString();

            ObjectiveClass obtClass = new ObjectiveClass();
            DialogResult dialogResult = MessageBox.Show("คุณต้องการลบข้อมูลหรือไม่", "ยืนยันการลบ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int rowCount = obtClass.DeleteObjective(obt_id);
                if (rowCount > 0)
                {
                    MessageBox.Show(this, "ลบข้อมูลำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.getobjectiveData();
                    return;
                }
                else
                {
                    MessageBox.Show(this, "ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void save_objective_btn_Click(object sender, EventArgs e)
        {
            string obt_name = objective_name_tb.Text.Trim();
            string group = objective_group_tb.Text.Trim();
            if(obt_name.Equals(string.Empty) || group.Equals(string.Empty))
            {
                MessageBox.Show(this, "กรุณากรอกข้อมูลให้ครบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.objectiveID == "")
            {
                DataTable obtDT = objClass.getObjectiveByName(obt_name);
                if(obtDT.Rows.Count > 0)
                {
                    MessageBox.Show(this, "วัตถุประสงค์นี้มีในระบบแล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string lastId = objClass.InsertObjective(obt_name, group);
                if (lastId != "")
                {
                    MessageBox.Show(this, "บันทึกข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.getobjectiveData();
                    this.objectiveID = "";
                    objective_name_tb.Text = "";
                    objective_group_tb.Text = "";
                    return;
                }
                else
                {
                    MessageBox.Show(this, "ไม่สามารถบันทึกข้อมูลได้ กรุณาตรวจสอบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {

                DataTable obtDT = objClass.getObjectiveById(Int32.Parse(this.objectiveID));


                if (obtDT.Rows.Count > 0)
                {
                    int rowCount = objClass.UpdateObjectiveByName(obt_name, group, this.objectiveID);
                    if (rowCount > 0)
                    {
                        MessageBox.Show(this, "บันทึกข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.getobjectiveData();
                        this.objectiveID = "";
                        objective_name_tb.Text = "";
                        objective_group_tb.Text = "";
                        return;
                    }
                    else
                    {
                        MessageBox.Show(this, "ไม่สามารถบันทึกข้อมูลได้ กรุณาตรวจสอบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    string lastId = objClass.InsertObjective(obt_name, group);
                    if (lastId != "")
                    {
                        MessageBox.Show(this, "บันทึกข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.getobjectiveData();
                        this.objectiveID = "";
                        objective_name_tb.Text = "";
                        objective_group_tb.Text = "";
                        return;
                    }
                    else
                    {
                        MessageBox.Show(this, "ไม่สามารถบันทึกข้อมูลได้ กรุณาตรวจสอบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }



        }

        private void objective_datagrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedRow = objective_datagrid.CurrentCell.RowIndex;
            string obt_id = objective_datagrid.Rows[selectedRow].Cells[0].Value.ToString();
            ObjectiveClass objClass = new ObjectiveClass();
            DataTable obtDT = objClass.getObjectiveById(Int32.Parse(obt_id));
            if(obtDT.Rows.Count > 0)
            {
                objective_name_tb.Text = obtDT.Rows[0]["obt_name"].ToString();
                objective_group_tb.Text = obtDT.Rows[0]["group"].ToString();
                this.objectiveID = obtDT.Rows[0]["obt_id"].ToString();
            }
        }

        private void clear_objective_btn_Click(object sender, EventArgs e)
        {
            this.objectiveID = "";
            objective_name_tb.Text = "";
            objective_group_tb.Text =  "";
        }
    }




}
