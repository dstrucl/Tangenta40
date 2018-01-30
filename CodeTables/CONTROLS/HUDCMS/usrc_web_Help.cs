using System;


using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HUDCMS
{
    public partial class usrc_web_Help : UserControl
    {

        internal usrc_Help mH = null;
        internal Form_HUDCMS frm_HUDCMS = null;


        Uri uri = null;
        public usrc_web_Help()
        {
            InitializeComponent();
            lbl_URL.Text = "";
            chk_local.Text = HUDCMS_static.slng_LocalURL;
        }

        private string m_LocalUrl = "Local URL:";
        public string LocalUrl
        {
            get { return m_LocalUrl; }
            set { m_LocalUrl = value; }
        }

        private string m_RemoteUrl = "";
        public string RemoteUrl
        {
            get { return m_RemoteUrl; }
            set { m_RemoteUrl = value; }
        }

        public void Show(string sUrl,string html)
        {
            if (uri!=null)
            {
                uri = null;
            }
            uri = new Uri(sUrl);
            webBrowser1.Url = uri;
            lbl_URL.Text = sUrl;
            webBrowser1.Refresh();

        }

        internal void Init(usrc_Help xH)
        {
            mH = xH;
           
            if (mH.RemoteURL_accessible)
            {
                chk_local.Checked = false;
                btn_HUDCMS.Visible = false;
                lbl_URL.Text = mH.RemoteURL;
                this.webBrowser1.Url = new Uri(mH.RemoteURL);
            }
            else
            {
                if (mH.LocalHtmlFile_exist)
                {
                    chk_local.Checked = true;
                    btn_HUDCMS.Visible = true;
                    lbl_URL.Text = mH.sLocalHtmlFile;
                    this.webBrowser1.Url = new Uri("file:///"+mH.sLocalHtmlFile);
                }
                else
                {
                    chk_local.Checked = false;
                    btn_HUDCMS.Visible = false;
                    lbl_URL.Text = mH.Err_Local;
                    this.webBrowser1.DocumentText = mH.Err_Remote; 
                }
            }
        }


        private void usrc_web_Help_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_HUDCMS_Click(object sender, EventArgs e)
        {
            if (frm_HUDCMS==null)
            {
                frm_HUDCMS = new Form_HUDCMS(mH);
                frm_HUDCMS.Owner = Global.f.GetParentForm(this);
            }
            frm_HUDCMS.Show();
        }

        private void chk_local_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_local.Checked)
            {
                btn_HUDCMS.Visible = true;
            }
            else
            {
                btn_HUDCMS.Visible = false;
            }
        }
    }
}

