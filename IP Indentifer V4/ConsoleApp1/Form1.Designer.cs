namespace IP_Identifier_WindowsForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.RichTextBox rtbResults;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.LinkLabel linkLabelMaps;
        private System.Windows.Forms.Button btnMyIP;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnLookup = new System.Windows.Forms.Button();
            this.rtbResults = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.linkLabelMaps = new System.Windows.Forms.LinkLabel();
            this.btnMyIP = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(15, 12);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(260, 22);
            this.txtIP.TabIndex = 0;
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(285, 10);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(80, 26);
            this.btnLookup.TabIndex = 1;
            this.btnLookup.Text = "Lookup";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // rtbResults
            // 
            this.rtbResults.Location = new System.Drawing.Point(15, 45);
            this.rtbResults.Name = "rtbResults";
            this.rtbResults.ReadOnly = true;
            this.rtbResults.Size = new System.Drawing.Size(350, 180);
            this.rtbResults.TabIndex = 2;
            this.rtbResults.Text = "";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(285, 260);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // linkLabelMaps
            // 
            this.linkLabelMaps.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabelMaps.AutoSize = true;
            this.linkLabelMaps.Location = new System.Drawing.Point(15, 230);
            this.linkLabelMaps.Name = "linkLabelMaps";
            this.linkLabelMaps.Size = new System.Drawing.Size(0, 16);
            this.linkLabelMaps.TabIndex = 6;
            this.linkLabelMaps.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMaps_LinkClicked);
            // 
            // btnMyIP
            // 
            this.btnMyIP.Location = new System.Drawing.Point(15, 260);
            this.btnMyIP.Name = "btnMyIP";
            this.btnMyIP.Size = new System.Drawing.Size(80, 28);
            this.btnMyIP.TabIndex = 4;
            this.btnMyIP.Text = "My IP";
            this.btnMyIP.UseVisualStyleBackColor = true;
            this.btnMyIP.Click += new System.EventHandler(this.btnMyIP_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 42);
            this.label2.TabIndex = 7;
            this.label2.Text = "Public IP Addresses ONLY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // Removed label2.Click event hookup
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 300);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMyIP);
            this.Controls.Add(this.linkLabelMaps);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rtbResults);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.txtIP);
            this.Name = "Form1";
            this.Text = "IP Identifier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
