namespace Tangenta
{
    partial class Form_PriceList_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PriceList_Edit));
            this.usrc_PriceList_Edit = new Tangenta.usrc_PriceList_Edit();
            this.SuspendLayout();
            // 
            // usrc_PriceList_Edit
            // 
            this.usrc_PriceList_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_PriceList_Edit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.usrc_PriceList_Edit.Location = new System.Drawing.Point(5, 12);
            this.usrc_PriceList_Edit.Name = "usrc_PriceList_Edit";
            this.usrc_PriceList_Edit.Size = new System.Drawing.Size(940, 793);
            this.usrc_PriceList_Edit.TabIndex = 0;
            this.usrc_PriceList_Edit.Button_Cancel_Click += new Tangenta.usrc_PriceList_Edit.delegate_Cancel(this.usrc_PriceListType_Edit_Button_Cancel_Click);
            this.usrc_PriceList_Edit.Button_OK_Click += new Tangenta.usrc_PriceList_Edit.delegate_OK(this.usrc_PriceListType_Edit_Button_OK_Click);
            // 
            // Form_PriceList_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(957, 808);
            this.Controls.Add(this.usrc_PriceList_Edit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_PriceList_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PriceList_Edit_Form";
            this.Load += new System.EventHandler(this.PriceListType_Edit_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_PriceList_Edit usrc_PriceList_Edit;



    }
}