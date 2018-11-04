using LanguageControl;
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
    public partial class Form_BussinesPremisse : Form
    {
        private FVI_SLO m_FVI_SLO = null;
        public bool FURS_BussinesPremiseData_SignedUp = false;
        public Form_BussinesPremisse(FVI_SLO xFVI_SLO, 
                                    bool bTest,
                                    bool bstartup,
                                    string msg)
        {
            InitializeComponent();
            m_FVI_SLO = xFVI_SLO;
            this.usrc_FURS_BussinesPremiseData1.Init(bTest, bstartup, m_FVI_SLO);
            lng.s_SignUpBussinesPremisse.Text(this);
            if (bTest)
            {
                lbl_msg.Text = lng.s_Warning.s+":"+ lng.s_Furs_Test_Environment.s+"\r\n"+msg;
            }
            else
            {
                lbl_msg.Text = msg;
            }
            btn_Exit.Text = lng.ss_Exit.s;
        }

        private void usrc_FURS_BussinesPremiseData1_FURS_BussinesPremiseData_SignedUp(bool bResult)
        {
            FURS_BussinesPremiseData_SignedUp = bResult;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
