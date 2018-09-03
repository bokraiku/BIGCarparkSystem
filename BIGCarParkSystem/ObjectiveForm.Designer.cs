namespace BIGCarParkSystem
{
    partial class ObjectiveForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flow_group_1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flow_group_2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flow_group_4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flow_group_3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flow_group_3);
            this.panel1.Controls.Add(this.flow_group_4);
            this.panel1.Controls.Add(this.flow_group_2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 420);
            this.panel1.TabIndex = 0;
            // 
            // flow_group_1
            // 
            this.flow_group_1.AutoScroll = true;
            this.flow_group_1.Location = new System.Drawing.Point(20, 60);
            this.flow_group_1.Name = "flow_group_1";
            this.flow_group_1.Size = new System.Drawing.Size(250, 420);
            this.flow_group_1.TabIndex = 0;
            // 
            // flow_group_2
            // 
            this.flow_group_2.AutoScroll = true;
            this.flow_group_2.Location = new System.Drawing.Point(271, 0);
            this.flow_group_2.Name = "flow_group_2";
            this.flow_group_2.Size = new System.Drawing.Size(250, 420);
            this.flow_group_2.TabIndex = 1;
            // 
            // flow_group_4
            // 
            this.flow_group_4.AutoScroll = true;
            this.flow_group_4.Location = new System.Drawing.Point(810, 0);
            this.flow_group_4.Name = "flow_group_4";
            this.flow_group_4.Size = new System.Drawing.Size(250, 420);
            this.flow_group_4.TabIndex = 2;
            // 
            // flow_group_3
            // 
            this.flow_group_3.AutoScroll = true;
            this.flow_group_3.Location = new System.Drawing.Point(540, 0);
            this.flow_group_3.Name = "flow_group_3";
            this.flow_group_3.Size = new System.Drawing.Size(250, 420);
            this.flow_group_3.TabIndex = 3;
            // 
            // ObjectiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 500);
            this.Controls.Add(this.flow_group_1);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "ObjectiveForm";
            this.Resizable = false;
            this.Text = "วัตถุประสงค์";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.ObjectiveForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flow_group_1;
        private System.Windows.Forms.FlowLayoutPanel flow_group_2;
        private System.Windows.Forms.FlowLayoutPanel flow_group_4;
        private System.Windows.Forms.FlowLayoutPanel flow_group_3;
    }
}