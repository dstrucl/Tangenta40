using TangentaPrint;

namespace Tangenta
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
            this.btn_DURS_output = new System.Windows.Forms.Button();
            this.btn_XML_export = new System.Windows.Forms.Button();
            this.btn_VOD_xml_OPAL_export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Print
            // 
            this.btn_Print.Image = global::Tangenta.Properties.Resources.Print;
            this.btn_Print.Location = new System.Drawing.Point(143, 73);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(188, 39);
            this.btn_Print.TabIndex = 1;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(440, 73);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(82, 39);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_From_To
            // 
            this.lbl_From_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_From_To.Location = new System.Drawing.Point(50, 9);
            this.lbl_From_To.Name = "lbl_From_To";
            this.lbl_From_To.Size = new System.Drawing.Size(427, 18);
            this.lbl_From_To.TabIndex = 3;
            this.lbl_From_To.Text = "Prikaži vse";
            // 
            // btn_DURS_output
            // 
            this.btn_DURS_output.Location = new System.Drawing.Point(6, 73);
            this.btn_DURS_output.Name = "btn_DURS_output";
            this.btn_DURS_output.Size = new System.Drawing.Size(114, 37);
            this.btn_DURS_output.TabIndex = 4;
            this.btn_DURS_output.Text = "Izpis za DURS ";
            this.btn_DURS_output.UseVisualStyleBackColor = true;
            this.btn_DURS_output.Visible = false;
            this.btn_DURS_output.Click += new System.EventHandler(this.btn_DURS_output_Click);
            // 
            // btn_XML_export
            // 
            this.btn_XML_export.Location = new System.Drawing.Point(6, 30);
            this.btn_XML_export.Name = "btn_XML_export";
            this.btn_XML_export.Size = new System.Drawing.Size(114, 37);
            this.btn_XML_export.TabIndex = 5;
            this.btn_XML_export.Text = "Izpis v XML";
            this.btn_XML_export.UseVisualStyleBackColor = true;
            this.btn_XML_export.Visible = false;
            this.btn_XML_export.Click += new System.EventHandler(this.btn_XML_export_Click);
            // 
            // btn_VOD_xml_OPAL_export
            // 
            this.btn_VOD_xml_OPAL_export.Location = new System.Drawing.Point(143, 30);
            this.btn_VOD_xml_OPAL_export.Name = "btn_VOD_xml_OPAL_export";
            this.btn_VOD_xml_OPAL_export.Size = new System.Drawing.Size(188, 37);
            this.btn_VOD_xml_OPAL_export.TabIndex = 6;
            this.btn_VOD_xml_OPAL_export.UseVisualStyleBackColor = true;
            this.btn_VOD_xml_OPAL_export.Click += new System.EventHandler(this.btn_VOD_xml_OPAL_export_Click);
            // 
            // Form_PrintReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(528, 119);
            this.Controls.Add(this.btn_VOD_xml_OPAL_export);
            this.Controls.Add(this.btn_XML_export);
            this.Controls.Add(this.btn_DURS_output);
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

        }

        #endregion

        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Cancel;
        internal System.Windows.Forms.Label lbl_From_To;
        private System.Windows.Forms.Button btn_DURS_output;
        private System.Windows.Forms.Button btn_XML_export;
        private System.Windows.Forms.Button btn_VOD_xml_OPAL_export;
    }
}