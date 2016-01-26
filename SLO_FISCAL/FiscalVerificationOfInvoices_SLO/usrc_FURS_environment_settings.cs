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
                lngRPM.s_Furs_Test_Environment.Text(this.lbl_Environment);
                this.lbl_Environment.ForeColor = Color.HotPink;
                this.txt_CertificateFile.Text = Properties.Settings.Default.furscertificateFileName_TEST;
                this.txt_CertificatePassword.Text = Properties.Settings.Default.fursCertPass_TEST;
                this.txt_fursWebServiceURL.Text = Properties.Settings.Default.fursWebServiceURL_TEST;
                this.txt_fursXmlNamespace.Text = Properties.Settings.Default.fursXmlNamespace_TEST;
            }
            else
            {
                lngRPM.s_Furs_Environment.Text(this.lbl_Environment);
                this.lbl_Environment.ForeColor = Color.DarkBlue;
                this.txt_CertificateFile.Text = Properties.Settings.Default.furscertificateFileName;
                this.txt_CertificatePassword.Text = Properties.Settings.Default.fursCertPass;
                this.txt_fursWebServiceURL.Text = Properties.Settings.Default.fursWebServiceURL;
                this.txt_fursXmlNamespace.Text = Properties.Settings.Default.fursXmlNamespace;
            }
            this.usrc_FURS_BussinesPremiseData1.Init(Test, m_usrc_FVI_SLO);
        }

        private void btn_BrowseCertificateFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnf = new OpenFileDialog();
            opnf.Title = lngRPM.s_SelectCertificate.s;

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
            }
            else
            {
                Properties.Settings.Default.furscertificateFileName = this.txt_CertificateFile.Text;
                Properties.Settings.Default.fursCertPass = this.txt_CertificatePassword.Text;
                Properties.Settings.Default.fursWebServiceURL = this.txt_fursWebServiceURL.Text;
                Properties.Settings.Default.fursXmlNamespace = this.txt_fursXmlNamespace.Text;
            }

        }
    }
}
