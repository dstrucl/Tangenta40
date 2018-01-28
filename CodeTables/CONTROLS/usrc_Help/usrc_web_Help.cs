using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class usrc_web_Help : UserControl
    {
        Uri uri = null;
        public usrc_web_Help()
        {
            InitializeComponent();
            lbl_URL.Text = "";
        }

        private string m_LocalUrl = "Local URL:";
        public string LocalUrl
        {
            get { return m_LocalUrl; }
            set { m_LocalUrl = value; }
        }

        private string m_RemoteUrl = "Remote URL:";
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
    }
}
