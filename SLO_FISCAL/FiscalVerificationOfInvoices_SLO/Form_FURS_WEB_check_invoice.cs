using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class Form_FURS_WEB_check_invoice : Form
    {
        public string m_sUrl = null;
        public Uri m_Uri = null;
        public Form_FURS_WEB_check_invoice(string surl)
        {
            InitializeComponent();
            m_sUrl = surl;
            m_Uri = new Uri(m_sUrl);
            webBrowser1.Url = m_Uri;
            this.Text = surl;
            this.Icon = System.Drawing.SystemIcons.Question;
        }
    }
}
