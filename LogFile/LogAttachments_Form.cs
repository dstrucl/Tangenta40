using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogFile
{
    public partial class LogAttachments_Form : Form
    {
        public Image clipboard_image = null;
        public bool bImage = true;
        public string Description = null;

        int iAttachmentNumber = -1;
        public LogAttachments_Form(int xiAttachmentNumber)
        {
            InitializeComponent();
            iAttachmentNumber = xiAttachmentNumber;
            this.rdb_Picture.Checked = true;
            this.txt_AttachmentDescription.Text = LanguageControl.lngRPM.s_Attachment.s + "_" + iAttachmentNumber.ToString() + "_" + LanguageControl.lngRPM.s_Picture.s;
            rdb_Picture.Text = LanguageControl.lngRPM.s_Picture.s;
            rdb_File.Text = LanguageControl.lngRPM.s_File.s;
            this.Text = LanguageControl.lngRPM.s_AddAttachment.s;
            lbl_Attachment_Description.Text = LanguageControl.lngRPM.s_Description.s + ":";
            this.btn_Add.Text = LanguageControl.lngRPM.s_Add.s;
            this.btn_Cancel.Text = LanguageControl.lngRPM.s_Cancel.s;
        }

        private void rdb_Picture_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Picture.Checked)
            {
                this.btn_PasteOrSelect.Text = LanguageControl.lngRPM.s_Paste.s;
                lbl_Attachment_Description.Text = LanguageControl.lngRPM.s_Description.s + ":";
                bImage = true;
            }
            else
            {
                this.btn_PasteOrSelect.Text = LanguageControl.lngRPM.s_Select.s;
                lbl_Attachment_Description.Text = LanguageControl.lngRPM.s_File.s + ":";
                bImage = false;
            }
        }

        private void btn_PasteOrSelect_Click(object sender, EventArgs e)
        {
            if (rdb_Picture.Checked)
            {
                if (Clipboard.ContainsImage())
                {
                    clipboard_image = (Image)Clipboard.GetImage().Clone();
                    this.picture_Box.Image = clipboard_image;
                    this.picture_Box.Refresh();
                }
            }
            else
            {
            }

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Description = txt_AttachmentDescription.Text;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
