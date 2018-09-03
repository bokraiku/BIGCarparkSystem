namespace BIGCarParkSystem
{
    partial class Test
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
            this.edit_role_cb = new MetroFramework.Controls.MetroComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // edit_role_cb
            // 
            this.edit_role_cb.FormattingEnabled = true;
            this.edit_role_cb.ItemHeight = 23;
            this.edit_role_cb.Location = new System.Drawing.Point(329, 211);
            this.edit_role_cb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.edit_role_cb.Name = "edit_role_cb";
            this.edit_role_cb.Size = new System.Drawing.Size(282, 29);
            this.edit_role_cb.TabIndex = 58;
            this.edit_role_cb.UseSelectable = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(189, 222);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(97, 18);
            this.label23.TabIndex = 57;
            this.label23.Text = "สิทธิ์การใช้งาน";
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.edit_role_cb);
            this.Controls.Add(this.label23);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox edit_role_cb;
        private System.Windows.Forms.Label label23;
    }
}