namespace BIGCarParkSystem
{
    partial class AlertMessage
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
            this.showuser_panel = new System.Windows.Forms.Panel();
            this.showList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.showuser_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // showuser_panel
            // 
            this.showuser_panel.Controls.Add(this.label1);
            this.showuser_panel.Controls.Add(this.showList);
            this.showuser_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showuser_panel.Location = new System.Drawing.Point(20, 30);
            this.showuser_panel.Name = "showuser_panel";
            this.showuser_panel.Size = new System.Drawing.Size(760, 395);
            this.showuser_panel.TabIndex = 0;
            // 
            // showList
            // 
            this.showList.Font = new System.Drawing.Font("Angsana New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showList.FormattingEnabled = true;
            this.showList.ItemHeight = 29;
            this.showList.Location = new System.Drawing.Point(3, 61);
            this.showList.Name = "showList";
            this.showList.Size = new System.Drawing.Size(754, 323);
            this.showList.Sorted = true;
            this.showList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "ตรวจสอบรายชื่อยังไม่สแกนออก";
            // 
            // AlertMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.Controls.Add(this.showuser_panel);
            this.DisplayHeader = false;
            this.Name = "AlertMessage";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "ตรวจสอบรายชื่อยังไม่สแกนออก";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AlertMessage_Load);
            this.showuser_panel.ResumeLayout(false);
            this.showuser_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel showuser_panel;
        private System.Windows.Forms.ListBox showList;
        private System.Windows.Forms.Label label1;
    }
}