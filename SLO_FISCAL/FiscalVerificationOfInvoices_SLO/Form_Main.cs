using LanguageControl;
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
    public partial class Form_Main : Form
    {
        string Xml_ECHO = @"<?xml version=""1.0"" encoding=""UTF-8""?> <fu:EchoRequest xmlns:fu=""http://www.fu.gov.si/"">Echo</fu:EchoRequest>";
        ToolTip ToolTipEcho = new ToolTip();

        public usrc_FVI_SLO m_usrc_FVI_SLO = null;

        public Form_Main(usrc_FVI_SLO xusrc_FVI_SLO)
        {
            InitializeComponent();
            m_usrc_FVI_SLO = xusrc_FVI_SLO;
            this.Text = "FURS";
            Init();
        }

        public void Init()
        {
            //if (m_usrc_FVI_SLO.FursTESTEnvironment)
            //{
            //    this.lbl_FURS_Environment.Text = lngRPM.s_Furs_Test_Environment.s;
            //}
            //else
            //{
            //    this.lbl_FURS_Environment.Text = lngRPM.s_Furs_Environment.s;
            //}
            //usrc_FURS_BussinesPremiseData1.ReadOnly = true;
            //usrc_FURS_BussinesPremiseData1.Init(m_usrc_FVI_SLO.FursTESTEnvironment);

        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            Form_Settings fvi_settings = new Form_Settings(m_usrc_FVI_SLO);
            fvi_settings.ShowDialog(this);
            Init();
        }

        public void btn_Send_ECHO_Click(object sender, EventArgs e)
        {

            ToolTipEcho.SetToolTip(this.btn_Send_ECHO, "");
            btn_Send_ECHO.ForeColor = Color.Black ;
            Refresh();
            m_usrc_FVI_SLO.Send_Echo(Xml_ECHO);
        }

        public bool FVI_Response_ECHO(bool success, string errorMessage)
        {

            string msg = "";

            if (success)
            {
                msg = "Echo OK";
                btn_Send_ECHO.ForeColor = Color.Green;
            }
            else
            {
                msg = "Echo Err " + errorMessage;
                btn_Send_ECHO.ForeColor = Color.Red;
            }

            
            ToolTipEcho.SetToolTip(this.btn_Send_ECHO, DateTime.Now.ToString() + " " +  msg);


            return true;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {  
            ToolTipEcho.SetToolTip(this.btn_Send_ECHO, "");
        }

        private void btn_BussinesPremisseID_Click(object sender, EventArgs e)
        {

        }
    }
}
