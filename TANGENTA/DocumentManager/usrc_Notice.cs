using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocumentManager
{
    public partial class usrc_Notice : UserControl
    {
        public string NoticeText
        {
            get
            {
                if (chk_Notice.Checked)
                {
                    if (IsNotEmpty(txt_Notice.Text))
                    {
                        return txt_Notice.Text;
                    }
                }
                return null;
            }
        }

        private bool IsNotEmpty(string text)
        {
            int ilen = text.Length;
            for (int i=0;i<ilen;i++)
            {
                if ((text[i]==' ')|| (text[i] == '\r') || (text[i] == '\n')|| (text[i] == '\t'))
                {
                    continue;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public usrc_Notice()
        {
            InitializeComponent();
        }

        private void btn_SelectNotice_Click(object sender, EventArgs e)
        {
            Form_Select_Notice frm_sel_notice = new Form_Select_Notice();
            if (frm_sel_notice.ShowDialog(this) == DialogResult.OK)
            {
                if (frm_sel_notice.NoticeText_v!=null)
                {
                    this.txt_Notice.Text = frm_sel_notice.NoticeText_v.v;
                    this.chk_Notice.Checked = true;
                }
            }
        }

        private void chk_Notice_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_Notice.Checked)
            {
                this.txt_Notice.Enabled = true;
            }
            else
            {
                this.txt_Notice.Enabled = false;
            }
        }
    }
}
