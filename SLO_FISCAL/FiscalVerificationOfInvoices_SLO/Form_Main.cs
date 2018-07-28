#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

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
    public partial class Form_MainFiscal : Form
    {
        public usrc_FVI_SLO.deleagteRequestPasswordCheck PasswordCheck = null;

        string Xml_ECHO = @"<?xml version=""1.0"" encoding=""UTF-8""?> <fu:EchoRequest xmlns:fu=""http://www.fu.gov.si/"">Echo</fu:EchoRequest>";
        ToolTip ToolTipEcho = new ToolTip();

        public FVI_SLO m_FVI_SLO = null;

        public Form_MainFiscal(FVI_SLO xFVI_SLO)
        {
            InitializeComponent();
            m_FVI_SLO = xFVI_SLO;
            lng.s_FURS_WWW_btn_Check_invoice.Text(btn_CheckInvoice);
            lng.s_FVI_for_cash_payment.Text(chk_FVI_CASH_PAYMENT);
            lng.s_FVI_for_card_payment.Text(chk_FVI_CARD_PAYMENT);
            lng.s_FVI_for_payment_on_bankaccount.Text(chk_FVI_PAYMENT_ON_BANK_ACCOUNT);
            lng.s_FVI_Edit_DocType_Settings.Text(chk_Edit_DocType_Settings);
            chk_Edit_DocType_Settings.Enabled = true;
            chk_Edit_DocType_Settings.Checked = false;
            chk_Edit_DocType_Settings.CheckedChanged += Chk_Edit_DocType_Settings_CheckedChanged;
            grp_DocTypeSettings.Enabled = false;
            chk_FVI_CASH_PAYMENT.Enabled = false;
            if (m_FVI_SLO.m_usrc_FVI_SLO != null)
            {
                if (m_FVI_SLO.m_usrc_FVI_SLO.Image_ButtonExit != null)
                {
                    this.btn_Exit.Image = m_FVI_SLO.m_usrc_FVI_SLO.Image_ButtonExit;
                    this.btn_Exit.Text = "";
                }
                else
                {
                    this.btn_Exit.Image = null;
                    this.btn_Exit.Text = lng.ss_Exit.s;
                }
            }
            Init();
        }

        private void Chk_Edit_DocType_Settings_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Edit_DocType_Settings.Checked)
            {
                if (PasswordCheck != null)
                {
                    bool bPasswordOK = false;
                    PasswordCheck(ref bPasswordOK);
                    if (bPasswordOK)
                    {
                        grp_DocTypeSettings.Enabled = true;
                    }
                    else
                    {
                        grp_DocTypeSettings.Enabled = false; 
                    }
                }
                else
                {
                    grp_DocTypeSettings.Enabled = true;
                }
            }
            else
            {
                grp_DocTypeSettings.Enabled = false;
            }
        }

        public void Init()
        {
            if (m_FVI_SLO.FursTESTEnvironment)
            {
                this.Text = lng.s_FVI_Check.s + " " + lng.s_Furs_Test_Environment.s;
            }
            else
            {
                this.Text = lng.s_FVI_Check.s;
            }
            chk_FVI_CASH_PAYMENT.Checked = Properties.Settings.Default.FVI_for_cash_payment;
            chk_FVI_CARD_PAYMENT.Checked = Properties.Settings.Default.FVI_for_card_payment;
            chk_FVI_PAYMENT_ON_BANK_ACCOUNT.Checked = Properties.Settings.Default.FVI_for_payment_on_bank_account;
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            bool bPasswordCheckOK = true;
            if (PasswordCheck!=null)
            {
                bPasswordCheckOK = false;
                PasswordCheck(ref bPasswordCheckOK);
            }
            if (bPasswordCheckOK)
            {
                NavigationButtons.Navigation nav_Form_Settings = new NavigationButtons.Navigation(null);
                nav_Form_Settings.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
                nav_Form_Settings.bDoModal = true;
                bool Reset2FactorySettings_FiscalVerification_DLL = false;
                Form_Settings fvi_settings = new Form_Settings(m_FVI_SLO, nav_Form_Settings, ref Reset2FactorySettings_FiscalVerification_DLL);
                fvi_settings.ShowDialog(this);
                Init();
            }
        }

        public void btn_Send_ECHO_Click(object sender, EventArgs e)
        {

            ToolTipEcho.SetToolTip(this.btn_Send_ECHO, "");
            btn_Send_ECHO.ForeColor = Color.Black ;
            Refresh();
            m_FVI_SLO.Send_Echo(Xml_ECHO);
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

        private void LoadVKRinvoice()
        {




        }

        private void btn_CheckInvoice_Click(object sender, EventArgs e)
        {
            string surl = m_FVI_SLO.FursD_WWW_check_invoice;

            if (m_FVI_SLO.m_Form_FURS_WEB_check_invoice==null)
            {
                m_FVI_SLO.m_Form_FURS_WEB_check_invoice = new Form_FURS_WEB_check_invoice(surl);
            }
            else
            {
                if (m_FVI_SLO.m_Form_FURS_WEB_check_invoice.IsDisposed)
                {
                    m_FVI_SLO.m_Form_FURS_WEB_check_invoice = new Form_FURS_WEB_check_invoice(surl);
                }
            }
            m_FVI_SLO.m_Form_FURS_WEB_check_invoice.Show();
        }

        private void chk_FVI_CASH_PAYMENT_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FVI_for_cash_payment = chk_FVI_CASH_PAYMENT.Checked;
            Properties.Settings.Default.Save();
        }

        private void chk_FVI_CARD_PAYMENT_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FVI_for_card_payment = chk_FVI_CARD_PAYMENT.Checked;
            Properties.Settings.Default.Save();
        }

        private void chk_FVI_PAYMENT_ON_BANK_ACCOUNT_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FVI_for_payment_on_bank_account = chk_FVI_PAYMENT_ON_BANK_ACCOUNT.Checked;
            Properties.Settings.Default.Save();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
