namespace TangentaSampleDB
{
    partial class usrc_SampleDataEdit
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
            this.eds_MyOrg_Organisation_Name = new TangentaSampleDB.usrc_edit_string();
            this.eds_MyOrg_Tax_ID = new TangentaSampleDB.usrc_edit_string();
            this.SuspendLayout();
            // 
            // eds_MyOrg_Organisation_Name
            // 
            this.eds_MyOrg_Organisation_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eds_MyOrg_Organisation_Name.label = "label1";
            this.eds_MyOrg_Organisation_Name.Location = new System.Drawing.Point(3, 3);
            this.eds_MyOrg_Organisation_Name.Name = "eds_MyOrg_Organisation_Name";
            this.eds_MyOrg_Organisation_Name.Size = new System.Drawing.Size(218, 40);
            this.eds_MyOrg_Organisation_Name.TabIndex = 0;
            this.eds_MyOrg_Organisation_Name.text = "";
            // 
            // eds_MyOrg_Tax_ID
            // 
            this.eds_MyOrg_Tax_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eds_MyOrg_Tax_ID.label = "label1";
            this.eds_MyOrg_Tax_ID.Location = new System.Drawing.Point(3, 49);
            this.eds_MyOrg_Tax_ID.Name = "eds_MyOrg_Tax_ID";
            this.eds_MyOrg_Tax_ID.Size = new System.Drawing.Size(218, 40);
            this.eds_MyOrg_Tax_ID.TabIndex = 1;
            this.eds_MyOrg_Tax_ID.text = "";
            // 
            // usrc_SampleDataEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eds_MyOrg_Tax_ID);
            this.Controls.Add(this.eds_MyOrg_Organisation_Name);
            this.Name = "usrc_SampleDataEdit";
            this.Size = new System.Drawing.Size(1024, 768);
            this.ResumeLayout(false);

        }

        #endregion

        internal TangentaSampleDB.usrc_edit_string eds_MyOrg_Organisation_Name;
        internal TangentaSampleDB.usrc_edit_string eds_MyOrg_Tax_ID;
    }
}
