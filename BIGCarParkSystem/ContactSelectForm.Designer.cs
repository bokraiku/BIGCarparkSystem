namespace BIGCarParkSystem
{
    partial class ContactSelectForm
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
            this.contact_cb = new MetroFramework.Controls.MetroComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.select_company_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contact_cb
            // 
            this.contact_cb.FormattingEnabled = true;
            this.contact_cb.ItemHeight = 23;
            this.contact_cb.Location = new System.Drawing.Point(25, 19);
            this.contact_cb.Name = "contact_cb";
            this.contact_cb.Size = new System.Drawing.Size(362, 29);
            this.contact_cb.TabIndex = 3;
            this.contact_cb.UseSelectable = true;
            this.contact_cb.SelectedIndexChanged += new System.EventHandler(this.contact_cb_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.select_company_btn);
            this.panel1.Controls.Add(this.contact_cb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 67);
            this.panel1.TabIndex = 5;
            // 
            // select_company_btn
            // 
            this.select_company_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.select_company_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.select_company_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_company_btn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_company_btn.ForeColor = System.Drawing.Color.White;
            this.select_company_btn.Location = new System.Drawing.Point(393, 16);
            this.select_company_btn.Name = "select_company_btn";
            this.select_company_btn.Size = new System.Drawing.Size(75, 32);
            this.select_company_btn.TabIndex = 10;
            this.select_company_btn.Text = "ตกลง";
            this.select_company_btn.UseVisualStyleBackColor = false;
            this.select_company_btn.Click += new System.EventHandler(this.select_company_btn_Click);
            // 
            // ContactSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 147);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "ContactSelectForm";
            this.Resizable = false;
            this.Text = "ติดต่อคุณ";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.ContactSelectForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox contact_cb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button select_company_btn;
    }
}