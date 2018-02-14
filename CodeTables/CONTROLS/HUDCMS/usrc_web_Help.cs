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

        internal usrc_Help mH = null;
        internal Form_HUDCMS frm_HUDCMS = null;
        private System.Windows.Forms.WebBrowser webBrowser1 = null;

        Uri uri = null;
        public usrc_web_Help()
        {
            InitializeComponent();
            AddWebBrowser();

            txt_URL.Text = "";
            chk_local.Text = HUDCMS_static.slng_LocalURL;
            var appName = Process.GetCurrentProcess().ProcessName + ".exe";
            SetIE8KeyforWebBrowserControl(appName);
        }

        private void SetIE8KeyforWebBrowserControl(string appName)
        {
            RegistryKey Regkey = null;
            try
            {
                // For 64 bit machine
                if (Environment.Is64BitOperatingSystem)
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                else  //For 32 bit machine
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);

                // If the path is not correct or
                // if the user haven't priviledges to access the registry
                if (Regkey == null)
                {
                    MessageBox.Show("Application Settings Failed - Address Not found");
                    return;
                }

                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                // Check if key is already present
                if (FindAppkey == "11001")
                {
                    MessageBox.Show("Required Application Settings Present");
                    Regkey.Close();
                    return;
                }

                    // If a key is not present add the key, Key value 11000 (decimal)
                if (string.IsNullOrEmpty(FindAppkey))
                    Regkey.SetValue(appName, unchecked((int)11001), RegistryValueKind.DWord);

                if (FindAppkey == "8000")
                {
                    Regkey.SetValue(appName, unchecked((int)11001), RegistryValueKind.DWord);
                }

                    // Check for the key after adding
                  FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                if (FindAppkey == "11001")
                    MessageBox.Show("Application Settings Applied Successfully");
                else
                    MessageBox.Show("Application Settings Failed, Ref: " + FindAppkey);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application Settings Failed");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the Registry
                if (Regkey != null)
                    Regkey.Close();
            }
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
            txt_URL.Text = sUrl;
            txt_URL.BackColor = this.BackColor;
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
                    txt_URL.Text = mH.Err_Local;
                    this.webBrowser1.DocumentText = mH.Err_Remote; 
                }
            }
            txt_URL.BackColor = this.BackColor;
            txt_URL.ForeColor = Color.LightGray;
        }

        private void ShowRemoteURL()
        {
            txt_URL.Text = mH.RemoteURL;
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
            txt_URL.Text = mH.LocalHtmlFile;
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

