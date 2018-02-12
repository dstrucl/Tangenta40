using System;


using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace HUDCMS
{
    public partial class usrc_web_Help : UserControl
    {

        internal usrc_Help mH = null;
        internal Form_HUDCMS frm_HUDCMS = null;
        private System.Windows.Forms.WebBrowser webBrowser1 = null;

        Uri uri = null;
        public usrc_web_Help()
        {
            InitializeComponent();
            AddWebBrowser();

            lbl_URL.Text = "";
            chk_local.Text = HUDCMS_static.slng_LocalURL;
        }

        private void AddWebBrowser()
        {
            this.SuspendLayout();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 27);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            int cx = this.Width;
            int cy = this.Height - 27;
            this.webBrowser1.Size = new System.Drawing.Size(cx, cy);
            this.webBrowser1.TabIndex = 0;
            this.Controls.Add(this.webBrowser1);
            this.ResumeLayout(false);
            this.PerformLayout();
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
                ShowRemoteURL();
            }
            else
            {
                if (mH.LocalHtmlFile_exist)
                {
                    chk_local.Checked = true;
                    btn_HUDCMS.Visible = true;
                    ShowLocalHtmlFile();
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

        private void ShowRemoteURL()
        {
            lbl_URL.Text = mH.RemoteURL;
            if (this.webBrowser1!=null)
            {
                this.Controls.Remove(this.webBrowser1);
                this.webBrowser1.Dispose();
                this.webBrowser1 = null;
                AddWebBrowser();
            }
            this.webBrowser1.Url = new Uri(mH.RemoteURL);
            //this.webBrowser1.Navigate(mH.RemoteURL);
            this.webBrowser1.Refresh(WebBrowserRefreshOption.Completely);
            this.Refresh();
        }

        private void ShowLocalHtmlFile()
        {
            lbl_URL.Text = mH.LocalHtmlFile;
            if (this.webBrowser1 != null)
            {
                this.Controls.Remove(this.webBrowser1);
                this.webBrowser1.Dispose();
                this.webBrowser1 = null;
                AddWebBrowser();
            }
            this.webBrowser1.Url = new Uri("file:///" + mH.LocalHtmlFile);
//            this.webBrowser1.Navigate("file:///" + mH.LocalHtmlFile);
            this.webBrowser1.Refresh(WebBrowserRefreshOption.Completely);
            this.Refresh();
        }


        private void btn_HUDCMS_Click(object sender, EventArgs e)
        {
            if (frm_HUDCMS != null)
            {
                if (frm_HUDCMS.IsDisposed)
                {
                    frm_HUDCMS = null;
                }
            }
            
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
                ShowLocalHtmlFile();
            }
            else
            {
                btn_HUDCMS.Visible = false;
                ShowRemoteURL();
            }
        }

        internal void ReloadHtml()
        {
            this.webBrowser1.Refresh();
        }
    }
}

