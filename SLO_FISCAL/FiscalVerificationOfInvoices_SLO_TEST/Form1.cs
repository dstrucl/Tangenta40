
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LanguageControl;
using FiscalVerificationOfInvoices_SLO;

namespace FiscalVerificationOfInvoices_SLO_TEST
{
    public partial class Form1 : Form
    {
        private bool FVI_com_running = false;
        public Form1()
        {
            InitializeComponent();
            btn_Send_ECHO.Enabled = false;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            //string CertName = "C:\\Luka\\TestCert\\10329048-1.p12";
            //string CertPass = "NVIJCY55TF3L";
            //string FursserviceUrl = "https://blagajne-test.fu.gov.si:9002/v1/cash_registers";
            //string FursXMLNamespace = "http://www.fu.gov.si/";
            string ErrReason = "";


            FVI_com_running = m_FVI_SLO1.Start(ref ErrReason);
            if (FVI_com_running)
            {
                btn_Send_ECHO.Enabled = true;
            }
        }


        private void btn_End_Click(object sender, EventArgs e)
        {
            m_FVI_SLO1.End();
            btn_Send_ECHO.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_FVI_SLO1.End();
            btn_Send_ECHO.Enabled = false;
        }

        private void usrc_FVI_SLO1_Response_ECHO(long Message_ID, string xml)
        {
            txt_Response_ECHO_xml.Text = "Message_ID =" + Message_ID.ToString() + "\r\n" + xml;

        
        }

        private string GetFursXmlMesage(string FileName)
        {
            string line = "";
           using (StreamReader sr = new StreamReader(FileName))
            {
                line = sr.ReadToEnd();
                sr.Close();
            }
            return line;
        }

        private void btn_Send_ECHO_Click(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + "\\XML\\Echo.xml";

            string xml_echo = GetFursXmlMesage(FileName);
            m_FVI_SLO1.Send_Echo(xml_echo);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + "\\XML\\BusinessPremises.xml";

            string xml = GetFursXmlMesage(FileName);
            m_FVI_SLO1.Send_PP(xml);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string FileName = Application.StartupPath + "\\XML\\Invoice.xml";
            string xml = GetFursXmlMesage(FileName);
            string UniqueMsgID = null;
            string UniqueInvoiceID = null;
            string BarCodeValue = null;
            Image Image_QR = null;
            m_FVI_SLO1.Send_SingleInvoice(false, xml,this, ref UniqueMsgID,ref UniqueInvoiceID,ref BarCodeValue,ref Image_QR);
        }



        private void usrc_FVI_SLO1_Response_ManyInvoices(long Message_ID, string xml)
        {
            txt_Response_ECHO_xml.Text = "Message_ID =" + Message_ID.ToString() + "\r\n" + xml;

        }

        private void usrc_FVI_SLO1_Response_PP(long Message_ID, string xml)
        {
            txt_Response_ECHO_xml.Text = "Message_ID =" + Message_ID.ToString() + "\r\n" + xml;

        }

        private void usrc_FVI_SLO1_Response_SingleInvoice(long Message_ID, string xml)
        {
            txt_Response_ECHO_xml.Text = "Message_ID =" + Message_ID.ToString() + "\r\n" + xml;

        }

        private void usrc_FVI_SLO1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LanguageControl.DynSettings.LanguageID = Properties.Settings.Default.LanguageID;    //Settings_Tangenta.Settings.LanguageID; ;

            btn_Start_Click(null, null);
        }

        private void btn_CompareCertFileToBuiltInTestCertificate_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog opnf = new OpenFileDialog();
            opnf.InitialDirectory = "c:\\";
            opnf.Filter = "txt files (*.crt)|*.crt|(*.p*)|*.p*|All files (*.*)|*.*";
            opnf.FilterIndex = 2;
            opnf.RestoreDirectory = true;

            if (opnf.ShowDialog() == DialogResult.OK)
            {
                string CerticateFullPath = opnf.FileName;
                TestCertificate.Compare(CerticateFullPath);
            }
        }
    }
}
