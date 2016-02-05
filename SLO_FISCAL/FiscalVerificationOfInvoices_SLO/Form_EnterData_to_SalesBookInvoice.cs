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
    public partial class Form_EnterData_to_SalesBookInvoice : Form
    {
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

        public Form_EnterData_to_SalesBookInvoice(long Invoice_ID,int FiscalYear, int InvoiceNumber, string xSerialNaumber, string xSetNumber,string xInvoiceNumber, eMode xEmode)
        {
            InitializeComponent();
            lngRPM.s_SalesBookInvoice.Text(this);
            m_SerialNumber = xSerialNaumber;
            m_eMode = xEmode;
            switch (m_eMode)
            {
                case eMode.WRITE:
                    this.lbl_Msg.Text = "Vpišete podatke iz vezane knjige računov za račun:" + FiscalYear.ToString() + "/" + InvoiceNumber.ToString();
                    txt_SerialNumber.Text = "";
                    txt_SetNumber.Text = "";
                    txt_InvoiceNumber.Text = "";
                    this.btn_Write.Text = "Zapiši";
                    break;
                case eMode.UPDATE:
                    txt_SerialNumber.Text = m_SerialNumber;
                    txt_SetNumber.Text = xSetNumber;
                    txt_InvoiceNumber.Text = xInvoiceNumber;
                    this.btn_Write.Text = "Popravi";
                    this.lbl_Msg.Text = "Popravite podatke iz vezane knjige računov za račun:" + FiscalYear.ToString() + "/" + InvoiceNumber.ToString();
                    break;
            }

        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            if (Check())
            {
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
                    if (Check_InvoiceNumber())
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Številka računa iz vezane knjige računov ni ustrezna !");
                    }
                }
                else
                {
                    MessageBox.Show("Številka posameznega obrazca iz vezane knjige računov ni ustrezna !");
                }
            }
            else
            {
                MessageBox.Show("Serijska številka vezane knjige računov ne ustreza!");
            }
            return false;
        }

        private bool Check_InvoiceNumber()
        {
            if (txt_InvoiceNumber.Text.Length > 0)
            {
                m_InvoiceNumber = txt_InvoiceNumber.Text;
                return true;
            }
            else
            {
                m_InvoiceNumber = "";
            }
            return false;
        }

        private bool Check_SetNumber()
        {
            if (txt_SetNumber.Text.Length > 0)
            {
                m_SetNumber = txt_SetNumber.Text;
                return true;
            }
            else
            {
                m_SetNumber = "";
            }
            return false;
        }

        private bool Check_SerialNumber()
        {
            if (txt_SerialNumber.Text.Length > 0)
            {
                m_SerialNumber = txt_SerialNumber.Text;
                return true;
            }
            else
            {
                m_SerialNumber = "";
            }
            return false;
        }
    }
}
