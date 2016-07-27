namespace TangentaSampleDB
{
    partial class Form_EditSampleData
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
            this.m_usrc_SampleDataEdit = new usrc_SampleDataEdit();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_usrc_SampleDataEdit
            // 
            this.m_usrc_SampleDataEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_SampleDataEdit.AutoScroll = true;
            this.m_usrc_SampleDataEdit.BackColor = System.Drawing.Color.Cornsilk;
            this.m_usrc_SampleDataEdit.HorisontalDistance = 5;
            this.m_usrc_SampleDataEdit.HorisontallOffsetToLabel = 4;
            this.m_usrc_SampleDataEdit.lblVerticalOffset = 4;
            this.m_usrc_SampleDataEdit.LeftMargin = 10;
            this.m_usrc_SampleDataEdit.Location = new System.Drawing.Point(1, 1);
            this.m_usrc_SampleDataEdit.MinEditBoxWidth = 36;
            this.m_usrc_SampleDataEdit.Name = "m_usrc_SampleDataEdit";
            this.m_usrc_SampleDataEdit.RightMargin = 10;
            this.m_usrc_SampleDataEdit.Size = new System.Drawing.Size(574, 439);
            this.m_usrc_SampleDataEdit.TabIndex = 0;
            this.m_usrc_SampleDataEdit.TopMargin = 0;
            this.m_usrc_SampleDataEdit.VerticalDistance = 5;
            this.m_usrc_SampleDataEdit.VerticalOffsetToLabel = 4;
            this.m_usrc_SampleDataEdit.Load += new System.EventHandler(this.m_usrc_SampleDataEdit_Load);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(1, 446);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(76, 27);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(147, 446);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(74, 27);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // Form_EditSampleData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 474);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.m_usrc_SampleDataEdit);
            this.Name = "Form_EditSampleData";
            this.Text = "Form_EditSampleData";
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_SampleDataEdit m_usrc_SampleDataEdit;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}