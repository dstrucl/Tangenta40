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
using System.Diagnostics;
using System.Security.Permissions;
using Microsoft.Win32;


namespace HUDCMS
{
    public partial class usrc_web_Help : UserControl
    {

        Font font_allreadysaved = null;
        Font font_saved = null;
        public delegate void delagete_DocumentCompleted(string url);
        public event delagete_DocumentCompleted DocumentCompleted = null;

        internal usrc_Help mH = null;
        internal Form_HUDCMS frm_HUDCMS = null;
        private System.Windows.Forms.WebBrowser webBrowser1 = null;
        private bool bHideEditButton = false;

        Uri uri = null;
        public usrc_web_Help()
        {
            InitializeComponent();
            AddWebBrowser();
            txt_Saved.Text = "";
            txt_URL.Text = "";
            chk_local.Text = HUDCMS_static.slng_LocalURL;
            FontFamily ffamily = txt_Saved.Font.FontFamily;
            float fsize = txt_Saved.Font.Size;

            font_allreadysaved = new Font(ffamily, fsize, FontStyle.Bold);
            font_saved = new Font(ffamily, fsize, FontStyle.Regular);
            cmb_Language.DataSource = HUDCMS_static.LanguagePrefixList;
            cmb_Language.SelectedIndex = HUDCMS_static.LanguageID;
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
            this.webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            this.Controls.Add(this.webBrowser1);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.txt_URL.Text = webBrowser1.Url.ToString();
            if (DocumentCompleted!=null)
            {
                DocumentCompleted(this.txt_URL.Text);
            }
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

        public void Show(Form xpForm,string sNameSpaceAndTypePath)
        {
            bHideEditButton = false;
            if (mH == null)
            {
                mH = new usrc_Help();
            }
            mH.Visible = false;
            mH.pForm = xpForm;
            mH.Prefix = "st_";
            mH.LocalHtmlFile_exist = mH.GetLocalURL(xpForm,mH.Prefix, sNameSpaceAndTypePath);
            mH.RemoteURL_accessible = mH.GetRemoteURL(xpForm,mH.Prefix, sNameSpaceAndTypePath);
            Init(mH);
        }

        public void ShowLicenceAgreement()
        {
            bHideEditButton = true;
            if (mH == null)
            {
                mH = new usrc_Help();
            }
            mH.Visible = false;
            mH.pForm = null;
            mH.Prefix = "";
            string sLicenseAgreement = "Startup.LicenseAgreement";
            mH.LocalHtmlFile_exist = mH.GetLocalURL(null,mH.Prefix, sLicenseAgreement);
            mH.RemoteURL_accessible = mH.GetRemoteURL(null,mH.Prefix, sLicenseAgreement);
            btn_HUDCMS.Visible = false;            
            Init(mH);
        }

        public void ShowNews()
        {
            if (mH == null)
            {
                mH = new usrc_Help();
            }
            mH.Visible = false;
            mH.pForm = null;
            mH.Prefix = "";
            string sNews = "News";
            mH.LocalHtmlFile_exist = mH.GetLocalURL(null,mH.Prefix, sNews);
            mH.RemoteURL_accessible = mH.GetRemoteURL(null,mH.Prefix, sNews);
            bHideEditButton = false;
            btn_HUDCMS.Visible = false;
            Init(mH);
        }

        public void ShowInstallationFinished()
        {
            bHideEditButton = false;
            if (mH == null)
            {
                mH = new usrc_Help();
            }
            mH.Visible = false;
            mH.pForm = null;
            mH.Prefix = "";
            string sNews = "InstallationFinished";
            mH.LocalHtmlFile_exist = mH.GetLocalURL(null,mH.Prefix, sNews);
            mH.RemoteURL_accessible = mH.GetRemoteURL(null, mH.Prefix, sNews);
            btn_HUDCMS.Visible = false;
            Init(mH);
        }

        internal void Init(usrc_Help xH)
        {
            mH = xH;

            if (chk_local.Checked)
            {
                ShowLocalHtmlFile();

            }
            else
            {
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
                        if (!bHideEditButton)
                        {
                            btn_HUDCMS.Visible = true;
                        }
                        ShowLocalHtmlFile();
                    }
                    else
                    {
                        chk_local.Checked = false;
                        btn_HUDCMS.Visible = false;
                        txt_URL.Text = mH.Err_Local;
                        this.webBrowser1.DocumentText = mH.Err_Remote;
                    }
                }
            }
            txt_URL.BackColor = this.BackColor;
            txt_URL.ForeColor = Color.LightGray;
            this.cmb_Language.SelectedIndexChanged += new System.EventHandler(this.cmb_Language_SelectedIndexChanged);
        }

        private void ShowRemoteURL()
        {
            bHideEditButton = false;
            txt_URL.Text = mH.RemoteURL;
            if (this.webBrowser1!=null)
            {
                this.webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted;
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
            bHideEditButton = false;
            txt_URL.Text = mH.LocalHtmlFile;
            if (this.webBrowser1 != null)
            {
                this.webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted;
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
            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
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
            mH.uwebHelp = this;
            frm_HUDCMS.Show();

            this.Cursor = cursor;
        }

        internal void ReloadHtml()
        {
            if (chk_local.Checked)
            {
                if (!bHideEditButton)
                {
                    btn_HUDCMS.Visible = true;
                }
                ShowLocalHtmlFile();
            }
            else
            {
                btn_HUDCMS.Visible = false;
                ShowRemoteURL();
            }
        }

        private void chk_local_CheckedChanged(object sender, EventArgs e)
        {
            ReloadHtml();
        }


        private void txt_URL_DoubleClick(object sender, EventArgs e)
        {
            Form_helpSettings frm_helpSettings = new Form_helpSettings(mH,this);
            frm_helpSettings.ShowDialog();
        }

        private void usrc_web_Help_Load(object sender, EventArgs e)
        {
        }

        private void btn_WebBrowserGoBack_Click(object sender, EventArgs e)
        {
            if (this.webBrowser1!=null)
            {
                this.webBrowser1.GoBack();
            }
        }

        private void btn_WebBrowserGoHome_Click(object sender, EventArgs e)
        {
            if (this.webBrowser1 != null)
            {
                if (chk_local.Checked)
                {
                    this.webBrowser1.Navigate("file:///"+HUDCMS_static.LocalHelpPath);
                }
                else
                {
                    this.webBrowser1.Navigate(HUDCMS_static.RemoteHelpURL);
                }
            }
        }

        private void btn_WebBrowserGoForward_Click(object sender, EventArgs e)
        {
            if (this.webBrowser1 != null)
            {
                this.webBrowser1.GoForward();
            }
        }

        public void ShowSaved(string err)
        {
            if (err == null)
            {
                DateTime dt = DateTime.Now;
                txt_Saved.Font = font_allreadysaved;
                txt_Saved.ForeColor = Color.Green;
                txt_Saved.Text = "Saved:" + dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString();
            }
            else
            {
                txt_Saved.ForeColor = Color.Red;
                txt_Saved.Text = "ERROR save:" + err;
            }
            timer_LastSave.Interval = 10000;
            timer_LastSave.Enabled = true;

        }

        private void timer_LastSave_Tick(object sender, EventArgs e)
        {
            txt_Saved.Font = font_saved;
            txt_Saved.ForeColor = Color.Gray;
            timer_LastSave.Enabled = false;
        }

        private void cmb_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmb_Language.SelectedIndexChanged -= new System.EventHandler(this.cmb_Language_SelectedIndexChanged);
            HUDCMS_static.LanguageID = cmb_Language.SelectedIndex;
            mH.LocalHtmlFile_exist = mH.GetLocalURL(mH.Prefix);
            mH.RemoteURL_accessible = mH.GetRemoteURL(mH.Prefix);
            Init(mH);
            ReloadHtml();
        }
    }
}

