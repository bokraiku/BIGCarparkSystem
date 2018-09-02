namespace BIGCarParkSystem
{
    partial class LoginForm
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
            this.login_panel_bg = new System.Windows.Forms.Panel();
            this.login_panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.username_tbx = new MetroFramework.Controls.MetroTextBox();
            this.password_tbx = new MetroFramework.Controls.MetroTextBox();
            this.login_panel_bg.SuspendLayout();
            this.login_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // login_panel_bg
            // 
            this.login_panel_bg.BackColor = System.Drawing.SystemColors.Control;
            this.login_panel_bg.BackgroundImage = global::BIGCarParkSystem.Properties.Resources.blue_background;
            this.login_panel_bg.Controls.Add(this.login_panel);
            this.login_panel_bg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login_panel_bg.Location = new System.Drawing.Point(20, 30);
            this.login_panel_bg.Name = "login_panel_bg";
            this.login_panel_bg.Size = new System.Drawing.Size(620, 359);
            this.login_panel_bg.TabIndex = 5;
            this.login_panel_bg.Paint += new System.Windows.Forms.PaintEventHandler(this.login_panel_bg_Paint);
            // 
            // login_panel
            // 
            this.login_panel.Controls.Add(this.button1);
            this.login_panel.Controls.Add(this.label2);
            this.login_panel.Controls.Add(this.label1);
            this.login_panel.Controls.Add(this.pictureBox1);
            this.login_panel.Controls.Add(this.username_tbx);
            this.login_panel.Controls.Add(this.password_tbx);
            this.login_panel.Location = new System.Drawing.Point(12, 34);
            this.login_panel.Name = "login_panel";
            this.login_panel.Size = new System.Drawing.Size(589, 265);
            this.login_panel.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(236, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "เข้าสู่ระบบ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Angsana New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 44);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Angsana New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 44);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BIGCarParkSystem.Properties.Resources.logo_big;
            this.pictureBox1.Location = new System.Drawing.Point(31, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // username_tbx
            // 
            // 
            // 
            // 
            this.username_tbx.CustomButton.Image = null;
            this.username_tbx.CustomButton.Location = new System.Drawing.Point(161, 2);
            this.username_tbx.CustomButton.Name = "";
            this.username_tbx.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.username_tbx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.username_tbx.CustomButton.TabIndex = 1;
            this.username_tbx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.username_tbx.CustomButton.UseSelectable = true;
            this.username_tbx.CustomButton.Visible = false;
            this.username_tbx.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.username_tbx.IconRight = true;
            this.username_tbx.Lines = new string[0];
            this.username_tbx.Location = new System.Drawing.Point(349, 35);
            this.username_tbx.MaxLength = 20;
            this.username_tbx.Name = "username_tbx";
            this.username_tbx.PasswordChar = '\0';
            this.username_tbx.PromptText = "Username ..";
            this.username_tbx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.username_tbx.SelectedText = "";
            this.username_tbx.SelectionLength = 0;
            this.username_tbx.SelectionStart = 0;
            this.username_tbx.ShortcutsEnabled = true;
            this.username_tbx.Size = new System.Drawing.Size(189, 30);
            this.username_tbx.TabIndex = 1;
            this.username_tbx.UseSelectable = true;
            this.username_tbx.WaterMark = "Username ..";
            this.username_tbx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.username_tbx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // password_tbx
            // 
            // 
            // 
            // 
            this.password_tbx.CustomButton.Image = null;
            this.password_tbx.CustomButton.Location = new System.Drawing.Point(161, 2);
            this.password_tbx.CustomButton.Name = "";
            this.password_tbx.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.password_tbx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.password_tbx.CustomButton.TabIndex = 1;
            this.password_tbx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.password_tbx.CustomButton.UseSelectable = true;
            this.password_tbx.CustomButton.Visible = false;
            this.password_tbx.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.password_tbx.Lines = new string[0];
            this.password_tbx.Location = new System.Drawing.Point(350, 80);
            this.password_tbx.MaxLength = 20;
            this.password_tbx.Name = "password_tbx";
            this.password_tbx.PasswordChar = '*';
            this.password_tbx.PromptText = "Password ..";
            this.password_tbx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password_tbx.SelectedText = "";
            this.password_tbx.SelectionLength = 0;
            this.password_tbx.SelectionStart = 0;
            this.password_tbx.ShortcutsEnabled = true;
            this.password_tbx.Size = new System.Drawing.Size(189, 30);
            this.password_tbx.Style = MetroFramework.MetroColorStyle.Black;
            this.password_tbx.TabIndex = 3;
            this.password_tbx.UseSelectable = true;
            this.password_tbx.WaterMark = "Password ..";
            this.password_tbx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.password_tbx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.password_tbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_tbx_KeyDown);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 409);
            this.Controls.Add(this.login_panel_bg);
            this.DisplayHeader = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Text = "LoginForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            this.login_panel_bg.ResumeLayout(false);
            this.login_panel.ResumeLayout(false);
            this.login_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox username_tbx;
        private MetroFramework.Controls.MetroTextBox password_tbx;
        private System.Windows.Forms.Panel login_panel_bg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel login_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}