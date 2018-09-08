namespace BIGCarParkSystem
{
    partial class ViewVisitHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBG = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.blacklist_logo_pb = new System.Windows.Forms.PictureBox();
            this.black_list = new System.Windows.Forms.Button();
            this.visitor_amount_tb = new MetroFramework.Controls.MetroTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.delete_history_bt = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.out_dateout_tb = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.out_visitid_tb = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.out_image1_pb = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.out_idcardpic_pb = new System.Windows.Forms.PictureBox();
            this.out_indate_tb = new MetroFramework.Controls.MetroTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.out_comment_tb = new MetroFramework.Controls.MetroTextBox();
            this.out_carid_tb = new MetroFramework.Controls.MetroTextBox();
            this.out_cartype_tb = new MetroFramework.Controls.MetroTextBox();
            this.out_company_tb = new MetroFramework.Controls.MetroTextBox();
            this.out_contact_tb = new MetroFramework.Controls.MetroTextBox();
            this.out_objective_tb = new MetroFramework.Controls.MetroTextBox();
            this.out_idcard_tb = new MetroFramework.Controls.MetroTextBox();
            this.out_fullname_tb = new MetroFramework.Controls.MetroTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panelBG.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blacklist_logo_pb)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.out_image1_pb)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.out_idcardpic_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBG
            // 
            this.panelBG.BackgroundImage = global::BIGCarParkSystem.Properties.Resources.bg_01;
            this.panelBG.Controls.Add(this.panelMain);
            this.panelBG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBG.Location = new System.Drawing.Point(20, 60);
            this.panelBG.Name = "panelBG";
            this.panelBG.Size = new System.Drawing.Size(1160, 720);
            this.panelBG.TabIndex = 69;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.blacklist_logo_pb);
            this.panelMain.Controls.Add(this.black_list);
            this.panelMain.Controls.Add(this.visitor_amount_tb);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.delete_history_bt);
            this.panelMain.Controls.Add(this.save_btn);
            this.panelMain.Controls.Add(this.out_dateout_tb);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.out_visitid_tb);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.groupBox2);
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Controls.Add(this.out_indate_tb);
            this.panelMain.Controls.Add(this.label19);
            this.panelMain.Controls.Add(this.out_comment_tb);
            this.panelMain.Controls.Add(this.out_carid_tb);
            this.panelMain.Controls.Add(this.out_cartype_tb);
            this.panelMain.Controls.Add(this.out_company_tb);
            this.panelMain.Controls.Add(this.out_contact_tb);
            this.panelMain.Controls.Add(this.out_objective_tb);
            this.panelMain.Controls.Add(this.out_idcard_tb);
            this.panelMain.Controls.Add(this.out_fullname_tb);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.label11);
            this.panelMain.Controls.Add(this.label13);
            this.panelMain.Controls.Add(this.label14);
            this.panelMain.Controls.Add(this.label15);
            this.panelMain.Controls.Add(this.label16);
            this.panelMain.Controls.Add(this.label17);
            this.panelMain.Controls.Add(this.label18);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1160, 720);
            this.panelMain.TabIndex = 1;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // blacklist_logo_pb
            // 
            this.blacklist_logo_pb.Image = global::BIGCarParkSystem.Properties.Resources.blacklist_logo;
            this.blacklist_logo_pb.Location = new System.Drawing.Point(638, 434);
            this.blacklist_logo_pb.Name = "blacklist_logo_pb";
            this.blacklist_logo_pb.Size = new System.Drawing.Size(200, 200);
            this.blacklist_logo_pb.TabIndex = 73;
            this.blacklist_logo_pb.TabStop = false;
            // 
            // black_list
            // 
            this.black_list.BackColor = System.Drawing.Color.Black;
            this.black_list.Cursor = System.Windows.Forms.Cursors.Hand;
            this.black_list.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.black_list.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.black_list.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.black_list.Image = global::BIGCarParkSystem.Properties.Resources.blacklist_45;
            this.black_list.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.black_list.Location = new System.Drawing.Point(395, 624);
            this.black_list.Name = "black_list";
            this.black_list.Size = new System.Drawing.Size(121, 47);
            this.black_list.TabIndex = 72;
            this.black_list.Text = "แบล็คลิส";
            this.black_list.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.black_list.UseVisualStyleBackColor = false;
            this.black_list.Click += new System.EventHandler(this.black_list_Click);
            // 
            // visitor_amount_tb
            // 
            // 
            // 
            // 
            this.visitor_amount_tb.CustomButton.Image = null;
            this.visitor_amount_tb.CustomButton.Location = new System.Drawing.Point(251, 2);
            this.visitor_amount_tb.CustomButton.Name = "";
            this.visitor_amount_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.visitor_amount_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.visitor_amount_tb.CustomButton.TabIndex = 1;
            this.visitor_amount_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.visitor_amount_tb.CustomButton.UseSelectable = true;
            this.visitor_amount_tb.CustomButton.Visible = false;
            this.visitor_amount_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.visitor_amount_tb.Lines = new string[0];
            this.visitor_amount_tb.Location = new System.Drawing.Point(156, 572);
            this.visitor_amount_tb.MaxLength = 32767;
            this.visitor_amount_tb.Multiline = true;
            this.visitor_amount_tb.Name = "visitor_amount_tb";
            this.visitor_amount_tb.PasswordChar = '\0';
            this.visitor_amount_tb.ReadOnly = true;
            this.visitor_amount_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.visitor_amount_tb.SelectedText = "";
            this.visitor_amount_tb.SelectionLength = 0;
            this.visitor_amount_tb.SelectionStart = 0;
            this.visitor_amount_tb.ShortcutsEnabled = true;
            this.visitor_amount_tb.Size = new System.Drawing.Size(281, 32);
            this.visitor_amount_tb.TabIndex = 71;
            this.visitor_amount_tb.UseSelectable = true;
            this.visitor_amount_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.visitor_amount_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 575);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 18);
            this.label3.TabIndex = 70;
            this.label3.Text = "จำนวนผู้มาติดต่อ";
            // 
            // delete_history_bt
            // 
            this.delete_history_bt.BackColor = System.Drawing.Color.Red;
            this.delete_history_bt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete_history_bt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.delete_history_bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_history_bt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.delete_history_bt.Image = global::BIGCarParkSystem.Properties.Resources.icons8_trash_35;
            this.delete_history_bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delete_history_bt.Location = new System.Drawing.Point(292, 624);
            this.delete_history_bt.Name = "delete_history_bt";
            this.delete_history_bt.Size = new System.Drawing.Size(79, 47);
            this.delete_history_bt.TabIndex = 69;
            this.delete_history_bt.Text = "ลบ";
            this.delete_history_bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delete_history_bt.UseVisualStyleBackColor = false;
            this.delete_history_bt.Click += new System.EventHandler(this.delete_history_bt_Click);
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.save_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save_btn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_btn.Image = global::BIGCarParkSystem.Properties.Resources.icons8_save_50;
            this.save_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save_btn.Location = new System.Drawing.Point(156, 624);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(105, 47);
            this.save_btn.TabIndex = 68;
            this.save_btn.Text = "พิมพ์";
            this.save_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // out_dateout_tb
            // 
            // 
            // 
            // 
            this.out_dateout_tb.CustomButton.Image = null;
            this.out_dateout_tb.CustomButton.Location = new System.Drawing.Point(251, 2);
            this.out_dateout_tb.CustomButton.Name = "";
            this.out_dateout_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.out_dateout_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_dateout_tb.CustomButton.TabIndex = 1;
            this.out_dateout_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_dateout_tb.CustomButton.UseSelectable = true;
            this.out_dateout_tb.CustomButton.Visible = false;
            this.out_dateout_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_dateout_tb.Lines = new string[0];
            this.out_dateout_tb.Location = new System.Drawing.Point(156, 127);
            this.out_dateout_tb.MaxLength = 32767;
            this.out_dateout_tb.Multiline = true;
            this.out_dateout_tb.Name = "out_dateout_tb";
            this.out_dateout_tb.PasswordChar = '\0';
            this.out_dateout_tb.ReadOnly = true;
            this.out_dateout_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_dateout_tb.SelectedText = "";
            this.out_dateout_tb.SelectionLength = 0;
            this.out_dateout_tb.SelectionStart = 0;
            this.out_dateout_tb.ShortcutsEnabled = true;
            this.out_dateout_tb.Size = new System.Drawing.Size(281, 32);
            this.out_dateout_tb.TabIndex = 67;
            this.out_dateout_tb.UseSelectable = true;
            this.out_dateout_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_dateout_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 66;
            this.label2.Text = "เวลาออก";
            // 
            // out_visitid_tb
            // 
            // 
            // 
            // 
            this.out_visitid_tb.CustomButton.Image = null;
            this.out_visitid_tb.CustomButton.Location = new System.Drawing.Point(251, 2);
            this.out_visitid_tb.CustomButton.Name = "";
            this.out_visitid_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.out_visitid_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_visitid_tb.CustomButton.TabIndex = 1;
            this.out_visitid_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_visitid_tb.CustomButton.UseSelectable = true;
            this.out_visitid_tb.CustomButton.Visible = false;
            this.out_visitid_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_visitid_tb.Lines = new string[0];
            this.out_visitid_tb.Location = new System.Drawing.Point(156, 34);
            this.out_visitid_tb.MaxLength = 32767;
            this.out_visitid_tb.Multiline = true;
            this.out_visitid_tb.Name = "out_visitid_tb";
            this.out_visitid_tb.PasswordChar = '\0';
            this.out_visitid_tb.ReadOnly = true;
            this.out_visitid_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_visitid_tb.SelectedText = "";
            this.out_visitid_tb.SelectionLength = 0;
            this.out_visitid_tb.SelectionStart = 0;
            this.out_visitid_tb.ShortcutsEnabled = true;
            this.out_visitid_tb.Size = new System.Drawing.Size(281, 32);
            this.out_visitid_tb.TabIndex = 65;
            this.out_visitid_tb.UseSelectable = true;
            this.out_visitid_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_visitid_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 64;
            this.label1.Text = "เลขที่";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(455, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 410);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "กล้องตัวที่ 1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.out_image1_pb);
            this.panel4.Location = new System.Drawing.Point(15, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(458, 363);
            this.panel4.TabIndex = 35;
            // 
            // out_image1_pb
            // 
            this.out_image1_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.out_image1_pb.Location = new System.Drawing.Point(3, 6);
            this.out_image1_pb.Name = "out_image1_pb";
            this.out_image1_pb.Size = new System.Drawing.Size(450, 350);
            this.out_image1_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.out_image1_pb.TabIndex = 2;
            this.out_image1_pb.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.out_idcardpic_pb);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(957, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 223);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รูปบัตรประชาชน";
            // 
            // out_idcardpic_pb
            // 
            this.out_idcardpic_pb.Location = new System.Drawing.Point(26, 27);
            this.out_idcardpic_pb.Name = "out_idcardpic_pb";
            this.out_idcardpic_pb.Size = new System.Drawing.Size(143, 172);
            this.out_idcardpic_pb.TabIndex = 37;
            this.out_idcardpic_pb.TabStop = false;
            // 
            // out_indate_tb
            // 
            // 
            // 
            // 
            this.out_indate_tb.CustomButton.Image = null;
            this.out_indate_tb.CustomButton.Location = new System.Drawing.Point(251, 2);
            this.out_indate_tb.CustomButton.Name = "";
            this.out_indate_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.out_indate_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_indate_tb.CustomButton.TabIndex = 1;
            this.out_indate_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_indate_tb.CustomButton.UseSelectable = true;
            this.out_indate_tb.CustomButton.Visible = false;
            this.out_indate_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_indate_tb.Lines = new string[0];
            this.out_indate_tb.Location = new System.Drawing.Point(156, 82);
            this.out_indate_tb.MaxLength = 32767;
            this.out_indate_tb.Multiline = true;
            this.out_indate_tb.Name = "out_indate_tb";
            this.out_indate_tb.PasswordChar = '\0';
            this.out_indate_tb.ReadOnly = true;
            this.out_indate_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_indate_tb.SelectedText = "";
            this.out_indate_tb.SelectionLength = 0;
            this.out_indate_tb.SelectionStart = 0;
            this.out_indate_tb.ShortcutsEnabled = true;
            this.out_indate_tb.Size = new System.Drawing.Size(281, 32);
            this.out_indate_tb.TabIndex = 60;
            this.out_indate_tb.UseSelectable = true;
            this.out_indate_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_indate_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(53, 85);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 18);
            this.label19.TabIndex = 59;
            this.label19.Text = "เวลาเข้า";
            // 
            // out_comment_tb
            // 
            // 
            // 
            // 
            this.out_comment_tb.CustomButton.Image = null;
            this.out_comment_tb.CustomButton.Location = new System.Drawing.Point(251, 2);
            this.out_comment_tb.CustomButton.Name = "";
            this.out_comment_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.out_comment_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_comment_tb.CustomButton.TabIndex = 1;
            this.out_comment_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_comment_tb.CustomButton.UseSelectable = true;
            this.out_comment_tb.CustomButton.Visible = false;
            this.out_comment_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_comment_tb.Lines = new string[0];
            this.out_comment_tb.Location = new System.Drawing.Point(156, 520);
            this.out_comment_tb.MaxLength = 32767;
            this.out_comment_tb.Multiline = true;
            this.out_comment_tb.Name = "out_comment_tb";
            this.out_comment_tb.PasswordChar = '\0';
            this.out_comment_tb.ReadOnly = true;
            this.out_comment_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_comment_tb.SelectedText = "";
            this.out_comment_tb.SelectionLength = 0;
            this.out_comment_tb.SelectionStart = 0;
            this.out_comment_tb.ShortcutsEnabled = true;
            this.out_comment_tb.Size = new System.Drawing.Size(281, 32);
            this.out_comment_tb.TabIndex = 58;
            this.out_comment_tb.UseSelectable = true;
            this.out_comment_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_comment_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // out_carid_tb
            // 
            // 
            // 
            // 
            this.out_carid_tb.CustomButton.Image = null;
            this.out_carid_tb.CustomButton.Location = new System.Drawing.Point(251, 2);
            this.out_carid_tb.CustomButton.Name = "";
            this.out_carid_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.out_carid_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_carid_tb.CustomButton.TabIndex = 1;
            this.out_carid_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_carid_tb.CustomButton.UseSelectable = true;
            this.out_carid_tb.CustomButton.Visible = false;
            this.out_carid_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_carid_tb.Lines = new string[0];
            this.out_carid_tb.Location = new System.Drawing.Point(156, 272);
            this.out_carid_tb.MaxLength = 100;
            this.out_carid_tb.Multiline = true;
            this.out_carid_tb.Name = "out_carid_tb";
            this.out_carid_tb.PasswordChar = '\0';
            this.out_carid_tb.ReadOnly = true;
            this.out_carid_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_carid_tb.SelectedText = "";
            this.out_carid_tb.SelectionLength = 0;
            this.out_carid_tb.SelectionStart = 0;
            this.out_carid_tb.ShortcutsEnabled = true;
            this.out_carid_tb.Size = new System.Drawing.Size(281, 32);
            this.out_carid_tb.TabIndex = 57;
            this.out_carid_tb.UseSelectable = true;
            this.out_carid_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_carid_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // out_cartype_tb
            // 
            // 
            // 
            // 
            this.out_cartype_tb.CustomButton.Image = null;
            this.out_cartype_tb.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.out_cartype_tb.CustomButton.Name = "";
            this.out_cartype_tb.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.out_cartype_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_cartype_tb.CustomButton.TabIndex = 1;
            this.out_cartype_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_cartype_tb.CustomButton.UseSelectable = true;
            this.out_cartype_tb.CustomButton.Visible = false;
            this.out_cartype_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_cartype_tb.Lines = new string[0];
            this.out_cartype_tb.Location = new System.Drawing.Point(156, 370);
            this.out_cartype_tb.MaxLength = 32767;
            this.out_cartype_tb.Name = "out_cartype_tb";
            this.out_cartype_tb.PasswordChar = '\0';
            this.out_cartype_tb.ReadOnly = true;
            this.out_cartype_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_cartype_tb.SelectedText = "";
            this.out_cartype_tb.SelectionLength = 0;
            this.out_cartype_tb.SelectionStart = 0;
            this.out_cartype_tb.ShortcutsEnabled = true;
            this.out_cartype_tb.Size = new System.Drawing.Size(281, 30);
            this.out_cartype_tb.TabIndex = 55;
            this.out_cartype_tb.UseSelectable = true;
            this.out_cartype_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_cartype_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // out_company_tb
            // 
            // 
            // 
            // 
            this.out_company_tb.CustomButton.Image = null;
            this.out_company_tb.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.out_company_tb.CustomButton.Name = "";
            this.out_company_tb.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.out_company_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_company_tb.CustomButton.TabIndex = 1;
            this.out_company_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_company_tb.CustomButton.UseSelectable = true;
            this.out_company_tb.CustomButton.Visible = false;
            this.out_company_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_company_tb.Lines = new string[0];
            this.out_company_tb.Location = new System.Drawing.Point(156, 320);
            this.out_company_tb.MaxLength = 32767;
            this.out_company_tb.Name = "out_company_tb";
            this.out_company_tb.PasswordChar = '\0';
            this.out_company_tb.ReadOnly = true;
            this.out_company_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_company_tb.SelectedText = "";
            this.out_company_tb.SelectionLength = 0;
            this.out_company_tb.SelectionStart = 0;
            this.out_company_tb.ShortcutsEnabled = true;
            this.out_company_tb.Size = new System.Drawing.Size(281, 30);
            this.out_company_tb.TabIndex = 54;
            this.out_company_tb.UseSelectable = true;
            this.out_company_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_company_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // out_contact_tb
            // 
            // 
            // 
            // 
            this.out_contact_tb.CustomButton.Image = null;
            this.out_contact_tb.CustomButton.Location = new System.Drawing.Point(251, 2);
            this.out_contact_tb.CustomButton.Name = "";
            this.out_contact_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.out_contact_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_contact_tb.CustomButton.TabIndex = 1;
            this.out_contact_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_contact_tb.CustomButton.UseSelectable = true;
            this.out_contact_tb.CustomButton.Visible = false;
            this.out_contact_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_contact_tb.Lines = new string[0];
            this.out_contact_tb.Location = new System.Drawing.Point(156, 466);
            this.out_contact_tb.MaxLength = 32767;
            this.out_contact_tb.Name = "out_contact_tb";
            this.out_contact_tb.PasswordChar = '\0';
            this.out_contact_tb.ReadOnly = true;
            this.out_contact_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_contact_tb.SelectedText = "";
            this.out_contact_tb.SelectionLength = 0;
            this.out_contact_tb.SelectionStart = 0;
            this.out_contact_tb.ShortcutsEnabled = true;
            this.out_contact_tb.Size = new System.Drawing.Size(281, 32);
            this.out_contact_tb.TabIndex = 53;
            this.out_contact_tb.UseSelectable = true;
            this.out_contact_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_contact_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // out_objective_tb
            // 
            // 
            // 
            // 
            this.out_objective_tb.CustomButton.Image = null;
            this.out_objective_tb.CustomButton.Location = new System.Drawing.Point(251, 2);
            this.out_objective_tb.CustomButton.Name = "";
            this.out_objective_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.out_objective_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_objective_tb.CustomButton.TabIndex = 1;
            this.out_objective_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_objective_tb.CustomButton.UseSelectable = true;
            this.out_objective_tb.CustomButton.Visible = false;
            this.out_objective_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_objective_tb.Lines = new string[0];
            this.out_objective_tb.Location = new System.Drawing.Point(156, 418);
            this.out_objective_tb.MaxLength = 32767;
            this.out_objective_tb.Multiline = true;
            this.out_objective_tb.Name = "out_objective_tb";
            this.out_objective_tb.PasswordChar = '\0';
            this.out_objective_tb.ReadOnly = true;
            this.out_objective_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_objective_tb.SelectedText = "";
            this.out_objective_tb.SelectionLength = 0;
            this.out_objective_tb.SelectionStart = 0;
            this.out_objective_tb.ShortcutsEnabled = true;
            this.out_objective_tb.Size = new System.Drawing.Size(281, 32);
            this.out_objective_tb.TabIndex = 52;
            this.out_objective_tb.UseSelectable = true;
            this.out_objective_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_objective_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // out_idcard_tb
            // 
            // 
            // 
            // 
            this.out_idcard_tb.CustomButton.Image = null;
            this.out_idcard_tb.CustomButton.Location = new System.Drawing.Point(251, 2);
            this.out_idcard_tb.CustomButton.Name = "";
            this.out_idcard_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.out_idcard_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_idcard_tb.CustomButton.TabIndex = 1;
            this.out_idcard_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_idcard_tb.CustomButton.UseSelectable = true;
            this.out_idcard_tb.CustomButton.Visible = false;
            this.out_idcard_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_idcard_tb.Lines = new string[0];
            this.out_idcard_tb.Location = new System.Drawing.Point(156, 222);
            this.out_idcard_tb.MaxLength = 13;
            this.out_idcard_tb.Multiline = true;
            this.out_idcard_tb.Name = "out_idcard_tb";
            this.out_idcard_tb.PasswordChar = '\0';
            this.out_idcard_tb.ReadOnly = true;
            this.out_idcard_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_idcard_tb.SelectedText = "";
            this.out_idcard_tb.SelectionLength = 0;
            this.out_idcard_tb.SelectionStart = 0;
            this.out_idcard_tb.ShortcutsEnabled = true;
            this.out_idcard_tb.Size = new System.Drawing.Size(281, 32);
            this.out_idcard_tb.TabIndex = 51;
            this.out_idcard_tb.UseSelectable = true;
            this.out_idcard_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_idcard_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // out_fullname_tb
            // 
            // 
            // 
            // 
            this.out_fullname_tb.CustomButton.Image = null;
            this.out_fullname_tb.CustomButton.Location = new System.Drawing.Point(251, 2);
            this.out_fullname_tb.CustomButton.Name = "";
            this.out_fullname_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.out_fullname_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.out_fullname_tb.CustomButton.TabIndex = 1;
            this.out_fullname_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.out_fullname_tb.CustomButton.UseSelectable = true;
            this.out_fullname_tb.CustomButton.Visible = false;
            this.out_fullname_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.out_fullname_tb.Lines = new string[0];
            this.out_fullname_tb.Location = new System.Drawing.Point(156, 174);
            this.out_fullname_tb.MaxLength = 32767;
            this.out_fullname_tb.Multiline = true;
            this.out_fullname_tb.Name = "out_fullname_tb";
            this.out_fullname_tb.PasswordChar = '\0';
            this.out_fullname_tb.ReadOnly = true;
            this.out_fullname_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.out_fullname_tb.SelectedText = "";
            this.out_fullname_tb.SelectionLength = 0;
            this.out_fullname_tb.SelectionStart = 0;
            this.out_fullname_tb.ShortcutsEnabled = true;
            this.out_fullname_tb.Size = new System.Drawing.Size(281, 32);
            this.out_fullname_tb.TabIndex = 50;
            this.out_fullname_tb.UseSelectable = true;
            this.out_fullname_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.out_fullname_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 523);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 18);
            this.label6.TabIndex = 49;
            this.label6.Text = "หมายเหตุ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(49, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 18);
            this.label11.TabIndex = 48;
            this.label11.Text = "ทะเบียนรถ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 471);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 18);
            this.label13.TabIndex = 46;
            this.label13.Text = "ผู้ได้รับการติดต่อ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(35, 424);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 18);
            this.label14.TabIndex = 45;
            this.label14.Text = "วัตถุประสงค์";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(45, 370);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 18);
            this.label15.TabIndex = 44;
            this.label15.Text = "ประเภทรถ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(70, 325);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 18);
            this.label16.TabIndex = 43;
            this.label16.Text = "บริษัท";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(16, 229);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 18);
            this.label17.TabIndex = 42;
            this.label17.Text = "เลขบัตรประชาชน";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(53, 174);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 18);
            this.label18.TabIndex = 41;
            this.label18.Text = "ชื่อ - สกุล";
            // 
            // ViewVisitHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelBG);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "ViewVisitHistoryForm";
            this.Resizable = false;
            this.Text = "ประวัติการใช้งาน";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewVisitHistoryForm_FormClosing);
            this.Load += new System.EventHandler(this.ViewVisitHistoryForm_Load);
            this.panelBG.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blacklist_logo_pb)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.out_image1_pb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.out_idcardpic_pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox out_image1_pb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox out_idcardpic_pb;
        private MetroFramework.Controls.MetroTextBox out_indate_tb;
        private System.Windows.Forms.Label label19;
        private MetroFramework.Controls.MetroTextBox out_comment_tb;
        private MetroFramework.Controls.MetroTextBox out_carid_tb;
        private MetroFramework.Controls.MetroTextBox out_cartype_tb;
        private MetroFramework.Controls.MetroTextBox out_company_tb;
        private MetroFramework.Controls.MetroTextBox out_contact_tb;
        private MetroFramework.Controls.MetroTextBox out_objective_tb;
        private MetroFramework.Controls.MetroTextBox out_idcard_tb;
        private MetroFramework.Controls.MetroTextBox out_fullname_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private MetroFramework.Controls.MetroTextBox out_visitid_tb;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox out_dateout_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Panel panelBG;
        private System.Windows.Forms.Button delete_history_bt;
        private MetroFramework.Controls.MetroTextBox visitor_amount_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button black_list;
        private System.Windows.Forms.PictureBox blacklist_logo_pb;
    }
}