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
        string Xml_ECHO = @"<? xml version = ""1.0"" encoding=""UTF-8""?>
                            <fu:EchoRequest xmlns:fu=""http://www.fu.gov.si/"">Echo</fu:EchoRequest>""";

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
            if (m_usrc_FVI_SLO.FursTESTEnvironment)
            {
                this.lbl_FURS_Environment.Text = lngRPM.s_Furs_Test_Environment.s;
            }
            else
            {
                this.lbl_FURS_Environment.Text = lngRPM.s_Furs_Environment.s;
            }
            usrc_FURS_BussinesPremiseData1.ReadOnly = true;
            usrc_FURS_BussinesPremiseData1.Init(m_usrc_FVI_SLO.FursTESTEnvironment);

        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            Form_Settings fvi_settings = new Form_Settings(m_usrc_FVI_SLO);
            fvi_settings.ShowDialog(this);
            Init();
        }

        private void btn_Send_ECHO_Click(object sender, EventArgs e)
        {
            m_usrc_FVI_SLO.Send_Echo(Xml_ECHO);
        }

    }
}
