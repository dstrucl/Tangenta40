#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using DBConnectionControl40;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class Form_EnterData_to_SalesBookInvoice : Form
    {
        private usrc_FVI_SLO m_usrc_FVI_SLO;
        public enum eMode { WRITE, UPDATE };
        private eMode m_eMode = eMode.WRITE;

        private string m_SerialNumber = "";
        private string m_SetNumber = "";
        private string m_InvoiceNumber = "";
        public string SerialNumber
        {
            get { return m_SerialNumber; }
        }
        public string SetNumber
        {
            get { return m_SetNumber; }
        }

        public string InvoiceNumber
        {
            get { return m_InvoiceNumber; }
        }

        public Form_EnterData_to_SalesBookInvoice(usrc_FVI_SLO xusrc_FVI_SLO, ID Invoice_ID,int FiscalYear, int InvoiceNumber, string xSerialNaumber, string xSetNumber,string xInvoiceNumber, eMode xEmode)
        {
            InitializeComponent();
            m_usrc_FVI_SLO = xusrc_FVI_SLO;
            lng.s_SalesBookInvoice.Text(this);
            m_SerialNumber = xSerialNaumber;
            m_eMode = xEmode;
            switch (m_eMode)
            {
                case eMode.WRITE:
                    this.lbl_Msg.Text = "Vpišete podatke iz vezane knjige računov za račun:" + FiscalYear.ToString() + "/" + InvoiceNumber.ToString();
                    txt_SerialNumber.Text = Properties.Settings.Default.Last_SalesBookInvoice_SerialNumber;
                    nm_UpDown_SetNumber.Value = Convert.ToDecimal(Properties.Settings.Default.Last_SalesBookInvoice_SetNumber);
                    txt_InvoiceNumber.Text = m_usrc_FVI_SLO.FURS_InvoiceNumber(InvoiceNumber);
                    this.btn_Write.Text = "Zapiši";
                    break;
                case eMode.UPDATE:
                    txt_SerialNumber.Text = m_SerialNumber;
                    try
                    {
                        nm_UpDown_SetNumber.Value = Convert.ToDecimal(xSetNumber);
                    }
                    catch
                    {
                        nm_UpDown_SetNumber.Value = 0;
                    }
                    txt_InvoiceNumber.Text = xInvoiceNumber;
                    this.btn_Write.Text = "Popravi";
                    this.lbl_Msg.Text = "Popravite podatke iz vezane knjige računov za račun:" + FiscalYear.ToString() + "/" + InvoiceNumber.ToString();
                    break;
            }

        }

        private int SetNext(int last_SalesBookInvoice_SetNumber)
        {
            try
            {
                int set_number = last_SalesBookInvoice_SetNumber;
                set_number++;
                if (set_number > Properties.Settings.Default.MAX_SalesBookInvoice_SetNumber)
                {
                    MessageBox.Show(lng.s_LastSetNumberIsMoreThan_MAX_SalesBookInvoice_SetNumber.s+"\r\n" + lng.s_TakeNewSalesBookInvoiceAndWriteItsSerialNumberFirst.s);
                    txt_SerialNumber.Text = "";
                    txt_SerialNumber.Focus();
                    return 1;
                }
                else
                {
                    return set_number;
                }
            }
            catch
            {
                return last_SalesBookInvoice_SetNumber;
            }
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                Properties.Settings.Default.Last_SalesBookInvoice_SerialNumber = this.txt_SerialNumber.Text;
                Properties.Settings.Default.Last_SalesBookInvoice_SetNumber = Convert.ToInt32(this.nm_UpDown_SetNumber.Value);
                Properties.Settings.Default.Save();
                Close();
                DialogResult = DialogResult.OK;
            }
        }

        private bool Check()
        {
            if (Check_SerialNumber())
            {
                if (Check_SetNumber())
                {
                    m_InvoiceNumber = txt_InvoiceNumber.Text;
                    return true;
                }
            }
            return false;
        }


        private bool Check_SetNumber()
        {
            if (nm_UpDown_SetNumber.Value > 0)
            {
                if (nm_UpDown_SetNumber.Value <= Convert.ToDecimal(Properties.Settings.Default.MAX_SalesBookInvoice_SetNumber))
                {
                    m_SetNumber = nm_UpDown_SetNumber.Value.ToString();
                    return true;
                }
                else
                {
                    MessageBox.Show(this, lng.s_SalesBookInvoice_SetNumber_GraterThanAllSetsDefinedInSettings.s);
                    return false;
                }
                
            }
            else
            {
                m_SetNumber = "";
                MessageBox.Show(this, lng.s_SalesBookInvoice_SetNumber_Not_OK.s);
            }
            return false;
        }

        private bool Check_SerialNumber()
        {
            if (txt_SerialNumber.Text.Length > 0)
            {
                Regex regexpr = new Regex(Properties.Settings.Default.SalesBookInvoice_SerialNumber_RegularExpression_pattern);
                if (regexpr.IsMatch(txt_SerialNumber.Text))
                {
                    m_SerialNumber = txt_SerialNumber.Text;
                    return true;
                }
                else
                {
                    if (MessageBox.Show(this,lng.sSalesBookInvoice_SerialNumber_does_not_match_patern.s,"?",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
                    {
                        m_SerialNumber = txt_SerialNumber.Text;
                        return true;
                    }
                    return false;
                }
                
            }
            m_SerialNumber = "";
            return false;
        }

        private void Form_EnterData_to_SalesBookInvoice_Load(object sender, EventArgs e)
        {
            this.timer_SetNext.Enabled = true;
        }

        private void timer_SetNext_Tick(object sender, EventArgs e)
        {
            this.timer_SetNext.Enabled = false;
            nm_UpDown_SetNumber.Value = Convert.ToDecimal(SetNext(Convert.ToInt32(nm_UpDown_SetNumber.Value)));
        }
    }
}
