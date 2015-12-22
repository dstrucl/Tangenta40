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
        private byte[] m_Doc = null;

        public string html_doc_text
        {
            get
            {
                if (m_Doc != null)
                {
                    try
                    {
                        char[] chars = Encoding.UTF8.GetChars(m_Doc);
                        string s = new string(chars);
                        return s;
                    }
                    catch
                    {
                        return "Error can not decode template!";
                    }
                }
                else
                {
                    return "Document Template not set";
                }
            }

            set
            {
                try
                {
                    m_Doc = System.Text.Encoding.UTF8.GetBytes(value);
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice_Preview:propertiy:html_doc_text:Exception=" + ex.Message);
                }
            }
        }

        private usrc_InvoiceMan m_usrc_InvoiceMan = null;


        public usrc_Invoice_Preview()
        {
            InitializeComponent();

            //string html_doc = Properties.Resources.html_doc;

        }
        public bool Init(byte[] xdoc)
        {
            m_Doc = xdoc;
            string s = html_doc_text;
            this.m_webBrowser.DocumentText = s;
            this.m_webBrowser.Refresh();
            return true;
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            m_webBrowser.ShowPrintDialog();
        }
    }
}
