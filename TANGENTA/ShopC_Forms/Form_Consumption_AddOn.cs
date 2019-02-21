#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using DBConnectionControl40;
using DBTypes;
using TangentaDB;

namespace ShopC_Forms
{
    public partial class Form_Consumption_AddOn : Form
    {
        public delegate bool delegate_Issue(ShopC_Forms.ConsumptionAddOn ownuse_add_on, Transaction transaction);
        public event delegate_Issue Issue = null;

        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;
        private ConsumptionAddOn m_AddOnConsumption = null;
        internal ConsumptionAddOn AddOnConsumption
        {
            get
            {
                return m_AddOnConsumption;
            }
            set
            {
                m_AddOnConsumption = value;
            }
        }

        private usrc_Consumption_AddOn m_usrc_AddOn = null;
        private bool m_bPrint = false;

        public Form_Consumption_AddOn(ConsumptionAddOn x_Consumption_AddOn,bool x_bPrint, usrc_Consumption_AddOn x_usrc_AddOn)
        {
            InitializeComponent();
            this.AddOnConsumption = x_Consumption_AddOn;
            m_usrc_AddOn = x_usrc_AddOn;
            m_bPrint = x_bPrint;
            this.Text = lng.s_Consumption_Data.s;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void Form_Consumption_AddOn_Load(object sender, EventArgs e)
        {
            if (this.m_usrc_Consumption_AddOn.Init(AddOnConsumption, m_bPrint, m_usrc_AddOn))
            {
                return;
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void m_usrc_Payment_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private bool m_usrc_ConsumptionAddOn_Issue(ShopC_Forms.ConsumptionAddOn consumptionAddOn, Transaction transaction)
        {
            bool bres = false;
            if (Issue!=null)
            {
                bres = Issue(consumptionAddOn, transaction);
            }
            if (bres)
            {
                this.Close();
                DialogResult = DialogResult.OK;
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
            return bres;
        }
    }
}
