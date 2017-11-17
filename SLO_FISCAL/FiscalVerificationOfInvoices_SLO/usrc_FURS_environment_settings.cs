#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class usrc_FURS_environment_settings : UserControl
    {
        bool Test = false;
        private usrc_FVI_SLO m_usrc_FVI_SLO;

        public usrc_FURS_environment_settings()
        {
            InitializeComponent();
        }

        public void Init(bool bTest, usrc_FVI_SLO x_usrc_FVI_SLO)
        {
            m_usrc_FVI_SLO = x_usrc_FVI_SLO;
            Test = bTest;

            if (Test)
            {
                m_usrc_FVI_SLO.SetTestCertificate();
                lng.s_Furs_Test_Environment.Text(this.lbl_Environment);
                this.lbl_Environment.ForeColor = Color.HotPink;
                this.txt_CertificateFile.Text = Properties.Settings.Default.furscertificateFileName_TEST;
                this.txt_CertificatePassword.Text = Properties.Settings.Default.fursCertPass_TEST;
                this.txt_fursWebServiceURL.Text = Properties.Settings.Default.fursWebServiceURL_TEST;
                this.txt_fursXmlNamespace.Text = Properties.Settings.Default.fursXmlNamespace_TEST;
                this.txt_fursWWW_check_invoice.Text = Properties.Settings.Default.fursWWW_check_invoice_TEST;
            }
            else
            {
                lng.s_Furs_Environment.Text(this.lbl_Environment);
                this.lbl_Environment.ForeColor = Color.DarkBlue;
                this.txt_CertificateFile.Text = Properties.Settings.Default.furscertificateFileName;
                this.txt_CertificatePassword.Text = Properties.Settings.Default.fursCertPass;
                this.txt_fursWebServiceURL.Text = Properties.Settings.Default.fursWebServiceURL;
                this.txt_fursXmlNamespace.Text = Properties.Settings.Default.fursXmlNamespace;
                this.txt_fursWWW_check_invoice.Text = Properties.Settings.Default.fursWWW_check_invoice;
            }
            this.usrc_FURS_BussinesPremiseData1.Init(Test, m_usrc_FVI_SLO);
        }

        private void btn_BrowseCertificateFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnf = new OpenFileDialog();
            opnf.Title = lng.s_SelectCertificate.s;

            if (opnf.ShowDialog() == DialogResult.OK)
            {
                this.txt_CertificateFile.Text = opnf.FileName;
            }
        }

        public void Save()
        {
            this.usrc_FURS_BussinesPremiseData1.Save();
            if (Test)
            {
                Properties.Settings.Default.furscertificateFileName_TEST = this.txt_CertificateFile.Text;
                Properties.Settings.Default.fursCertPass_TEST = this.txt_CertificatePassword.Text;
                Properties.Settings.Default.fursWebServiceURL_TEST = this.txt_fursWebServiceURL.Text;
                Properties.Settings.Default.fursXmlNamespace_TEST = this.txt_fursXmlNamespace.Text;
                Properties.Settings.Default.fursWWW_check_invoice_TEST = this.txt_fursWWW_check_invoice.Text;
            }
            else
            {
                Properties.Settings.Default.furscertificateFileName = this.txt_CertificateFile.Text;
                Properties.Settings.Default.fursCertPass = this.txt_CertificatePassword.Text;
                Properties.Settings.Default.fursWebServiceURL = this.txt_fursWebServiceURL.Text;
                Properties.Settings.Default.fursXmlNamespace = this.txt_fursXmlNamespace.Text;
                Properties.Settings.Default.fursWWW_check_invoice = this.txt_fursWWW_check_invoice.Text;
            }
            Properties.Settings.Default.Save();
        }
    }
}
