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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.username_tbx = new MetroFramework.Controls.MetroTextBox();
            this.password_tbx = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.login_btn = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 88);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(89, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Username";
            // 
            // username_tbx
            // 
            // 
            // 
            // 
            this.username_tbx.CustomButton.Image = null;
            this.username_tbx.CustomButton.Location = new System.Drawing.Point(167, 1);
            this.username_tbx.CustomButton.Name = "";
            this.username_tbx.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.username_tbx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.username_tbx.CustomButton.TabIndex = 1;
            this.username_tbx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.username_tbx.CustomButton.UseSelectable = true;
            this.username_tbx.CustomButton.Visible = false;
            this.username_tbx.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.username_tbx.IconRight = true;
            this.username_tbx.Lines = new string[0];
            this.username_tbx.Location = new System.Drawing.Point(130, 88);
            this.username_tbx.MaxLength = 20;
            this.username_tbx.Name = "username_tbx";
            this.username_tbx.PasswordChar = '\0';
            this.username_tbx.PromptText = "Username ..";
            this.username_tbx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.username_tbx.SelectedText = "";
            this.username_tbx.SelectionLength = 0;
            this.username_tbx.SelectionStart = 0;
            this.username_tbx.ShortcutsEnabled = true;
            this.username_tbx.Size = new System.Drawing.Size(189, 23);
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
            this.password_tbx.CustomButton.Location = new System.Drawing.Point(167, 1);
            this.password_tbx.CustomButton.Name = "";
            this.password_tbx.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.password_tbx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.password_tbx.CustomButton.TabIndex = 1;
            this.password_tbx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.password_tbx.CustomButton.UseSelectable = true;
            this.password_tbx.CustomButton.Visible = false;
            this.password_tbx.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.password_tbx.Lines = new string[0];
            this.password_tbx.Location = new System.Drawing.Point(130, 136);
            this.password_tbx.MaxLength = 20;
            this.password_tbx.Name = "password_tbx";
            this.password_tbx.PasswordChar = '*';
            this.password_tbx.PromptText = "Password ..";
            this.password_tbx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password_tbx.SelectedText = "";
            this.password_tbx.SelectionLength = 0;
            this.password_tbx.SelectionStart = 0;
            this.password_tbx.ShortcutsEnabled = true;
            this.password_tbx.Size = new System.Drawing.Size(189, 23);
            this.password_tbx.Style = MetroFramework.MetroColorStyle.Black;
            this.password_tbx.TabIndex = 3;
            this.password_tbx.UseSelectable = true;
            this.password_tbx.WaterMark = "Password ..";
            this.password_tbx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.password_tbx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(23, 134);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(82, 25);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Password";
            // 
            // login_btn
            // 
            this.login_btn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.login_btn.ForeColor = System.Drawing.Color.White;
            this.login_btn.Highlight = true;
            this.login_btn.Location = new System.Drawing.Point(23, 210);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(89, 40);
            this.login_btn.Style = MetroFramework.MetroColorStyle.Blue;
            this.login_btn.TabIndex = 4;
            this.login_btn.Text = "Login";
            this.login_btn.Theme = MetroFramework.MetroThemeStyle.Light;
            this.login_btn.UseSelectable = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 348);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.password_tbx);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.username_tbx);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "LoginForm";
            this.Resizable = false;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox username_tbx;
        private MetroFramework.Controls.MetroTextBox password_tbx;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton login_btn;
    }
}