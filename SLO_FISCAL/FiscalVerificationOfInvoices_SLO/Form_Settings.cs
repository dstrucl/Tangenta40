using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class Form_Settings : Form
    {
        private usrc_FVI_SLO m_usrc_FVI_SLO = null;

        public string certificateFileName = null;
        public string CertPass = null;
        public string fursWebServiceURL = null;
        public string fursXmlNamespace = null;
        public int timeOutInSec = -1;


        public Form_Settings(usrc_FVI_SLO x_usrc_FVI_SLO)
        {
            InitializeComponent();
            m_usrc_FVI_SLO = x_usrc_FVI_SLO;

            this.txt_CertificateFile.Text = Properties.Settings.Default.certificateFileName;
            this.txt_CertificatePassword.Text = Properties.Settings.Default.CertPass;
            this.txt_fursWebServiceURL.Text = Properties.Settings.Default.fursWebServiceURL;
            this.txt_fursXmlNamespace.Text = Properties.Settings.Default.fursXmlNamespace;
            this.nm_UpDown_timeOutInSec.Value = Convert.ToDecimal(Properties.Settings.Default.timeOutInSec);
            this.nm_TimeToShoqSuccessfulFURS_Transaction.Value = Convert.ToDecimal(Properties.Settings.Default.timeToShowSuccessfulFURSResult);
            this.nm_QRSizeWidth.Value = Convert.ToDecimal(Properties.Settings.Default.QRImageWidth);
            chk_DebugAndTest.Checked = Properties.Settings.Default.DEBUG;
            chk_DebugAndTest.CheckedChanged += Chk_DebugAndTest_CheckedChanged;

        }

        private void Chk_DebugAndTest_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_DebugAndTest.Checked != Properties.Settings.Default.DEBUG)
            {
                Properties.Settings.Default.DEBUG = chk_DebugAndTest.Checked;
                Properties.Settings.Default.Save();
            }
            m_usrc_FVI_SLO.DEBUG = chk_DebugAndTest.Checked;

        }

        private void btn_BrowseCertificateFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnf = new OpenFileDialog();
            opnf.Title = "Izberite certifikat !";

            if (opnf.ShowDialog()==DialogResult.OK)
            {
                this.txt_CertificateFile.Text = opnf.FileName;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.certificateFileName = this.txt_CertificateFile.Text;
            Properties.Settings.Default.CertPass = this.txt_CertificatePassword.Text;
            Properties.Settings.Default.fursWebServiceURL = this.txt_fursWebServiceURL.Text;
            Properties.Settings.Default.fursXmlNamespace = this.txt_fursXmlNamespace.Text;
            Properties.Settings.Default.timeOutInSec = Convert.ToInt32(this.nm_UpDown_timeOutInSec.Value);
            Properties.Settings.Default.timeToShowSuccessfulFURSResult = Convert.ToInt32(this.nm_TimeToShoqSuccessfulFURS_Transaction.Value);
            Properties.Settings.Default.QRImageWidth = Convert.ToInt32(this.nm_QRSizeWidth.Value);
            Properties.Settings.Default.Save();
            certificateFileName = Properties.Settings.Default.certificateFileName;
            CertPass = Properties.Settings.Default.CertPass;
            fursWebServiceURL = Properties.Settings.Default.fursWebServiceURL;
            fursXmlNamespace = Properties.Settings.Default.fursXmlNamespace;
            timeOutInSec = Properties.Settings.Default.timeOutInSec;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
