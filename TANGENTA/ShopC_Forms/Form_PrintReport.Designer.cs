using TangentaPrint;

namespace ShopC_Forms
{
    partial class Form_PrintReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PrintReport));
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_From_To = new System.Windows.Forms.Label();
            this.btn_XML_export = new System.Windows.Forms.Button();
            this.btn_VOD_xml_OPAL_export = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.chk_Details = new System.Windows.Forms.CheckBox();
            this.btn_SaveAsText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Print
            // 
            this.btn_Print.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Print.Image = TangentaResources.Properties.Resources.Print;
            this.btn_Print.Location = new System.Drawing.Point(288, 102);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(166, 39);
            this.btn_Print.TabIndex = 1;
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = TangentaResources.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(449, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(39, 39);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_From_To
            // 
            this.lbl_From_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_From_To.Location = new System.Drawing.Point(3, 9);
            this.lbl_From_To.Name = "lbl_From_To";
            this.lbl_From_To.Size = new System.Drawing.Size(440, 18);
            this.lbl_From_To.TabIndex = 3;
            this.lbl_From_To.Text = "Prikaži vse";
            // 
            // btn_XML_export
            // 
            this.btn_XML_export.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_XML_export.Location = new System.Drawing.Point(6, 57);
            this.btn_XML_export.Name = "btn_XML_export";
            this.btn_XML_export.Size = new System.Drawing.Size(114, 37);
            this.btn_XML_export.TabIndex = 5;
            this.btn_XML_export.Text = "Izpis v XML";
            this.btn_XML_export.UseVisualStyleBackColor = false;
            this.btn_XML_export.Visible = false;
            this.btn_XML_export.Click += new System.EventHandler(this.btn_XML_export_Click);
            // 
            // btn_VOD_xml_OPAL_export
            // 
            this.btn_VOD_xml_OPAL_export.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_VOD_xml_OPAL_export.Location = new System.Drawing.Point(137, 57);
            this.btn_VOD_xml_OPAL_export.Name = "btn_VOD_xml_OPAL_export";
            this.btn_VOD_xml_OPAL_export.Size = new System.Drawing.Size(188, 37);
            this.btn_VOD_xml_OPAL_export.TabIndex = 6;
            this.btn_VOD_xml_OPAL_export.UseVisualStyleBackColor = false;
            this.btn_VOD_xml_OPAL_export.Click += new System.EventHandler(this.btn_VOD_xml_OPAL_export_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(494, 2);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(34, 39);
            this.usrc_Help1.TabIndex = 7;
            // 
            // chk_Details
            // 
            this.chk_Details.AutoSize = true;
            this.chk_Details.Location = new System.Drawing.Point(470, 112);
            this.chk_Details.Name = "chk_Details";
            this.chk_Details.Size = new System.Drawing.Size(58, 17);
            this.chk_Details.TabIndex = 8;
            this.chk_Details.Text = "Details";
            this.chk_Details.UseVisualStyleBackColor = true;
            // 
            // btn_SaveAsText
            // 
            this.btn_SaveAsText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_SaveAsText.Image = TangentaResources.Properties.Resources.Edit;
            this.btn_SaveAsText.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_SaveAsText.Location = new System.Drawing.Point(137, 101);
            this.btn_SaveAsText.Name = "btn_SaveAsText";
            this.btn_SaveAsText.Size = new System.Drawing.Size(145, 39);
            this.btn_SaveAsText.TabIndex = 9;
            this.btn_SaveAsText.Text = "Save In Text File";
            this.btn_SaveAsText.UseVisualStyleBackColor = false;
            this.btn_SaveAsText.Click += new System.EventHandler(this.btn_SaveAsText_Click);
            // 
            // Form_PrintReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(580, 151);
            this.Controls.Add(this.btn_SaveAsText);
            this.Controls.Add(this.chk_Details);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_VOD_xml_OPAL_export);
            this.Controls.Add(this.btn_XML_export);
            this.Controls.Add(this.lbl_From_To);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Print);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_PrintReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_PrintReport";
            this.Load += new System.EventHandler(this.Form_PrintReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Cancel;
        internal System.Windows.Forms.Label lbl_From_To;
        private System.Windows.Forms.Button btn_XML_export;
        private System.Windows.Forms.Button btn_VOD_xml_OPAL_export;
        private HUDCMS.usrc_Help usrc_Help1;
        private System.Windows.Forms.CheckBox chk_Details;
        private System.Windows.Forms.Button btn_SaveAsText;
    }
}