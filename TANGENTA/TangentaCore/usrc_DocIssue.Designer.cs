namespace TangentaCore
{
    partial class usrc_DocIssue
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Issue = new System.Windows.Forms.Button();
            this.lbl_Sum = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_Issue
            // 
            this.btn_Issue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Issue.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Issue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Issue.Location = new System.Drawing.Point(1, 37);
            this.btn_Issue.Name = "btn_Issue";
            this.btn_Issue.Size = new System.Drawing.Size(147, 41);
            this.btn_Issue.TabIndex = 34;
            this.btn_Issue.Text = "Issue";
            this.btn_Issue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Issue.UseVisualStyleBackColor = false;
            this.btn_Issue.Click += new System.EventHandler(this.btn_Issue_Click);
            // 
            // lbl_Sum
            // 
            this.lbl_Sum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sum.Location = new System.Drawing.Point(4, 7);
            this.lbl_Sum.Name = "lbl_Sum";
            this.lbl_Sum.Size = new System.Drawing.Size(143, 29);
            this.lbl_Sum.TabIndex = 33;
            this.lbl_Sum.Text = "SKUPAJ";
            this.lbl_Sum.Click += new System.EventHandler(this.lbl_Sum_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // usrc_DocIssue
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::TangentaCore.Properties.Resources.IssueUnpressed;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btn_Issue);
            this.Controls.Add(this.lbl_Sum);
            this.DoubleBuffered = true;
            this.Name = "usrc_DocIssue";
            this.Size = new System.Drawing.Size(150, 80);
            this.Load += new System.EventHandler(this.usrc_DocIssue_Load);
            this.Click += new System.EventHandler(this.usrc_DocIssue_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Issue;
        public System.Windows.Forms.Label lbl_Sum;
        private System.Windows.Forms.Timer timer1;
    }
}
