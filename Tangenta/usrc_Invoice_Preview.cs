using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using System.Runtime.InteropServices;
using DBConnectionControl40;

namespace Tangenta
{
    public partial class usrc_Invoice_Preview : UserControl
    {
        private usrc_InvoiceMan m_usrc_InvoiceMan = null;

        public usrc_Invoice_Preview()
        {
            InitializeComponent();

            //string html_doc = Properties.Resources.html_doc;
            string html_doc = Properties.Resources.htmlt_ENG_inv1_A4;
            this.m_webBrowser.DocumentText = html_doc;
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            m_webBrowser.ShowPrintDialog();
        }
    }
}
