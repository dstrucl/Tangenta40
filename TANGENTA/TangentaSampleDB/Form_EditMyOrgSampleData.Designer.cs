using DynEditControls;

namespace TangentaSampleDB
{
    partial class Form_EditMyOrgSampleData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_EditMyOrgSampleData));
            this.m_usrc_SampleDataEdit = new DynEditControls.usrc_DataEdit();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.SuspendLayout();
            // 
            // m_usrc_SampleDataEdit
            // 
            this.m_usrc_SampleDataEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_SampleDataEdit.AutoScroll = true;
            this.m_usrc_SampleDataEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.m_usrc_SampleDataEdit.ColorChanged = System.Drawing.Color.DarkRed;
            this.m_usrc_SampleDataEdit.ColorNotChanged = System.Drawing.Color.DarkBlue;
            this.m_usrc_SampleDataEdit.HorisontalDistance = 5;
            this.m_usrc_SampleDataEdit.HorisontallOffsetToLabel = 4;
            this.m_usrc_SampleDataEdit.lblVerticalOffset = 4;
            this.m_usrc_SampleDataEdit.LeftMargin = 10;
            this.m_usrc_SampleDataEdit.Location = new System.Drawing.Point(1, 1);
            this.m_usrc_SampleDataEdit.MinEditBoxWidth = 36;
            this.m_usrc_SampleDataEdit.Name = "m_usrc_SampleDataEdit";
            this.m_usrc_SampleDataEdit.RightMargin = 10;
            this.m_usrc_SampleDataEdit.Size = new System.Drawing.Size(574, 432);
            this.m_usrc_SampleDataEdit.TabIndex = 0;
            this.m_usrc_SampleDataEdit.TopMargin = 30;
            this.m_usrc_SampleDataEdit.VerticalDistance = 5;
            this.m_usrc_SampleDataEdit.VerticalOffsetToLabel = 4;
            this.m_usrc_SampleDataEdit.Load += new System.EventHandler(this.m_usrc_SampleDataEdit_Load);
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_NavigationButtons1.btn1_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn2_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn3_ToolTip_Text = "";
            this.usrc_NavigationButtons1.Buttons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_NEXT")));
            this.usrc_NavigationButtons1.Image_OK = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_OK")));
            this.usrc_NavigationButtons1.Image_PREV = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_PREV")));
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(1, 439);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(574, 65);
            this.usrc_NavigationButtons1.TabIndex = 1;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "";
            this.usrc_NavigationButtons1.Text_OK = "";
            this.usrc_NavigationButtons1.Text_PREV = "";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            this.usrc_NavigationButtons1.Load += new System.EventHandler(this.usrc_NavigationButtons1_Load);
            // 
            // Form_EditSampleData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 504);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.m_usrc_SampleDataEdit);
            this.Name = "Form_EditSampleData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_EditSampleData";
            this.Load += new System.EventHandler(this.Form_EditSampleData_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_DataEdit m_usrc_SampleDataEdit;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}