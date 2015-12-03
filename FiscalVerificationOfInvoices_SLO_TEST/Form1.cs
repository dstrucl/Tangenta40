using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            FVI_com_running = usrc_FVI_SLO1.Start();
            if (FVI_com_running)
            {
                btn_Send_ECHO.Enabled = true;
            }
        }


        private void btn_End_Click(object sender, EventArgs e)
        {
            usrc_FVI_SLO1.End();
            btn_Send_ECHO.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            usrc_FVI_SLO1.End();
            btn_Send_ECHO.Enabled = false;
        }

        private void usrc_FVI_SLO1_Response_ECHO(long Message_ID, string xml)
        {
            txt_Response_ECHO_xml.Text = "Message_ID =" + Message_ID.ToString() + "\r\n" + xml;
        }

        private void btn_Send_ECHO_Click(object sender, EventArgs e)
        {
            string xml_echo = Properties.Resources.FVI_ECHO;
            usrc_FVI_SLO1.Send_Echo(1, xml_echo);
        }
    }
}
