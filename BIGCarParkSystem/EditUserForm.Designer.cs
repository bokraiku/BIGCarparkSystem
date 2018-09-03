namespace BIGCarParkSystem
{
    partial class EditUserForm
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
            this.label23 = new System.Windows.Forms.Label();
            this.admin_save_bt = new System.Windows.Forms.Button();
            this.admin_conpass_tb = new MetroFramework.Controls.MetroTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.admin_username_tb = new MetroFramework.Controls.MetroTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.admin_password_tb = new MetroFramework.Controls.MetroTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.edit_pass_checkbox = new System.Windows.Forms.CheckBox();
            this.edit_role_cb = new MetroFramework.Controls.MetroComboBox();
            this.active_user_rb = new System.Windows.Forms.RadioButton();
            this.disable_user_rb = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(34, 274);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(97, 18);
            this.label23.TabIndex = 51;
            this.label23.Text = "สิทธิ์การใช้งาน";
            // 
            // admin_save_bt
            // 
            this.admin_save_bt.BackColor = System.Drawing.SystemColors.Highlight;
            this.admin_save_bt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.admin_save_bt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.admin_save_bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_save_bt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.admin_save_bt.Image = global::BIGCarParkSystem.Properties.Resources.icons8_save_35;
            this.admin_save_bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.admin_save_bt.Location = new System.Drawing.Point(174, 380);
            this.admin_save_bt.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.admin_save_bt.Name = "admin_save_bt";
            this.admin_save_bt.Size = new System.Drawing.Size(94, 43);
            this.admin_save_bt.TabIndex = 50;
            this.admin_save_bt.Text = "บันทึก";
            this.admin_save_bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.admin_save_bt.UseVisualStyleBackColor = false;
            this.admin_save_bt.Click += new System.EventHandler(this.admin_save_bt_Click);
            // 
            // admin_conpass_tb
            // 
            // 
            // 
            // 
            this.admin_conpass_tb.CustomButton.Image = null;
            this.admin_conpass_tb.CustomButton.Location = new System.Drawing.Point(250, 2);
            this.admin_conpass_tb.CustomButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.admin_conpass_tb.CustomButton.Name = "";
            this.admin_conpass_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.admin_conpass_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.admin_conpass_tb.CustomButton.TabIndex = 1;
            this.admin_conpass_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.admin_conpass_tb.CustomButton.UseSelectable = true;
            this.admin_conpass_tb.CustomButton.Visible = false;
            this.admin_conpass_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.admin_conpass_tb.Lines = new string[0];
            this.admin_conpass_tb.Location = new System.Drawing.Point(174, 206);
            this.admin_conpass_tb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.admin_conpass_tb.MaxLength = 32767;
            this.admin_conpass_tb.Multiline = true;
            this.admin_conpass_tb.Name = "admin_conpass_tb";
            this.admin_conpass_tb.PasswordChar = '*';
            this.admin_conpass_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.admin_conpass_tb.SelectedText = "";
            this.admin_conpass_tb.SelectionLength = 0;
            this.admin_conpass_tb.SelectionStart = 0;
            this.admin_conpass_tb.ShortcutsEnabled = true;
            this.admin_conpass_tb.Size = new System.Drawing.Size(280, 32);
            this.admin_conpass_tb.TabIndex = 49;
            this.admin_conpass_tb.UseSelectable = true;
            this.admin_conpass_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.admin_conpass_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(34, 212);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(124, 18);
            this.label22.TabIndex = 48;
            this.label22.Text = "Confirm Password";
            // 
            // admin_username_tb
            // 
            // 
            // 
            // 
            this.admin_username_tb.CustomButton.Image = null;
            this.admin_username_tb.CustomButton.Location = new System.Drawing.Point(250, 2);
            this.admin_username_tb.CustomButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.admin_username_tb.CustomButton.Name = "";
            this.admin_username_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.admin_username_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.admin_username_tb.CustomButton.TabIndex = 1;
            this.admin_username_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.admin_username_tb.CustomButton.UseSelectable = true;
            this.admin_username_tb.CustomButton.Visible = false;
            this.admin_username_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.admin_username_tb.Lines = new string[0];
            this.admin_username_tb.Location = new System.Drawing.Point(174, 83);
            this.admin_username_tb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.admin_username_tb.MaxLength = 32767;
            this.admin_username_tb.Multiline = true;
            this.admin_username_tb.Name = "admin_username_tb";
            this.admin_username_tb.PasswordChar = '\0';
            this.admin_username_tb.ReadOnly = true;
            this.admin_username_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.admin_username_tb.SelectedText = "";
            this.admin_username_tb.SelectionLength = 0;
            this.admin_username_tb.SelectionStart = 0;
            this.admin_username_tb.ShortcutsEnabled = true;
            this.admin_username_tb.Size = new System.Drawing.Size(280, 32);
            this.admin_username_tb.TabIndex = 47;
            this.admin_username_tb.UseSelectable = true;
            this.admin_username_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.admin_username_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(34, 83);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 18);
            this.label20.TabIndex = 46;
            this.label20.Text = "Username";
            // 
            // admin_password_tb
            // 
            // 
            // 
            // 
            this.admin_password_tb.CustomButton.Image = null;
            this.admin_password_tb.CustomButton.Location = new System.Drawing.Point(250, 2);
            this.admin_password_tb.CustomButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.admin_password_tb.CustomButton.Name = "";
            this.admin_password_tb.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.admin_password_tb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.admin_password_tb.CustomButton.TabIndex = 1;
            this.admin_password_tb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.admin_password_tb.CustomButton.UseSelectable = true;
            this.admin_password_tb.CustomButton.Visible = false;
            this.admin_password_tb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.admin_password_tb.Lines = new string[0];
            this.admin_password_tb.Location = new System.Drawing.Point(174, 162);
            this.admin_password_tb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.admin_password_tb.MaxLength = 32767;
            this.admin_password_tb.Multiline = true;
            this.admin_password_tb.Name = "admin_password_tb";
            this.admin_password_tb.PasswordChar = '*';
            this.admin_password_tb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.admin_password_tb.SelectedText = "";
            this.admin_password_tb.SelectionLength = 0;
            this.admin_password_tb.SelectionStart = 0;
            this.admin_password_tb.ShortcutsEnabled = true;
            this.admin_password_tb.Size = new System.Drawing.Size(280, 32);
            this.admin_password_tb.TabIndex = 45;
            this.admin_password_tb.UseSelectable = true;
            this.admin_password_tb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.admin_password_tb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(34, 162);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 18);
            this.label21.TabIndex = 44;
            this.label21.Text = "Password";
            // 
            // edit_pass_checkbox
            // 
            this.edit_pass_checkbox.AutoSize = true;
            this.edit_pass_checkbox.Font = new System.Drawing.Font("Angsana New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_pass_checkbox.Location = new System.Drawing.Point(174, 122);
            this.edit_pass_checkbox.Name = "edit_pass_checkbox";
            this.edit_pass_checkbox.Size = new System.Drawing.Size(113, 33);
            this.edit_pass_checkbox.TabIndex = 53;
            this.edit_pass_checkbox.Text = "แก้ไขรหัสผ่าน";
            this.edit_pass_checkbox.UseVisualStyleBackColor = true;
            // 
            // edit_role_cb
            // 
            this.edit_role_cb.FormattingEnabled = true;
            this.edit_role_cb.ItemHeight = 23;
            this.edit_role_cb.Location = new System.Drawing.Point(174, 263);
            this.edit_role_cb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.edit_role_cb.Name = "edit_role_cb";
            this.edit_role_cb.Size = new System.Drawing.Size(282, 29);
            this.edit_role_cb.TabIndex = 56;
            this.edit_role_cb.UseSelectable = true;
            // 
            // active_user_rb
            // 
            this.active_user_rb.AutoSize = true;
            this.active_user_rb.Font = new System.Drawing.Font("Angsana New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.active_user_rb.Location = new System.Drawing.Point(174, 333);
            this.active_user_rb.Name = "active_user_rb";
            this.active_user_rb.Size = new System.Drawing.Size(91, 33);
            this.active_user_rb.TabIndex = 54;
            this.active_user_rb.TabStop = true;
            this.active_user_rb.Text = "เปิดใช้งาน";
            this.active_user_rb.UseVisualStyleBackColor = true;
            // 
            // disable_user_rb
            // 
            this.disable_user_rb.AutoSize = true;
            this.disable_user_rb.Font = new System.Drawing.Font("Angsana New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disable_user_rb.Location = new System.Drawing.Point(271, 333);
            this.disable_user_rb.Name = "disable_user_rb";
            this.disable_user_rb.Size = new System.Drawing.Size(87, 33);
            this.disable_user_rb.TabIndex = 55;
            this.disable_user_rb.TabStop = true;
            this.disable_user_rb.Text = "ปิดใช้งาน";
            this.disable_user_rb.UseVisualStyleBackColor = true;
            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.edit_role_cb);
            this.Controls.Add(this.disable_user_rb);
            this.Controls.Add(this.active_user_rb);
            this.Controls.Add(this.edit_pass_checkbox);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.admin_save_bt);
            this.Controls.Add(this.admin_conpass_tb);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.admin_username_tb);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.admin_password_tb);
            this.Controls.Add(this.label21);
            this.Name = "EditUserForm";
            this.Text = "แก้ไขข้อมูลผู้ใช้งาน";
            this.Load += new System.EventHandler(this.EditUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button admin_save_bt;
        private MetroFramework.Controls.MetroTextBox admin_conpass_tb;
        private System.Windows.Forms.Label label22;
        private MetroFramework.Controls.MetroTextBox admin_username_tb;
        private System.Windows.Forms.Label label20;
        private MetroFramework.Controls.MetroTextBox admin_password_tb;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox edit_pass_checkbox;
        private MetroFramework.Controls.MetroComboBox edit_role_cb;
        private System.Windows.Forms.RadioButton active_user_rb;
        private System.Windows.Forms.RadioButton disable_user_rb;
    }
}