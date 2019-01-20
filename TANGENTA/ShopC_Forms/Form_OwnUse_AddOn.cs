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
    public partial class Form_OwnUse_AddOn : Form
    {
        public delegate bool delegate_Issue(ShopC_Forms.OwnUseAddOn ownuse_add_on, Transaction transaction);
        public event delegate_Issue Issue = null;

        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;
        private OwnUseAddOn m_AddOnOwnUse = null;
        internal OwnUseAddOn AddOnOwnUse
        {
            get
            {
                return m_AddOnOwnUse;
            }
            set
            {
                m_AddOnOwnUse = value;
            }
        }

        private usrc_Consumption_AddOn m_usrc_AddOn = null;
        private bool m_bPrint = false;

        public Form_OwnUse_AddOn(OwnUseAddOn x_OwnUse_AddOn,bool x_bPrint, usrc_Consumption_AddOn x_usrc_AddOn)
        {
            InitializeComponent();
            this.AddOnOwnUse = x_OwnUse_AddOn;
            m_usrc_AddOn = x_usrc_AddOn;
            m_bPrint = x_bPrint;
            this.Text = lng.s_OwnUse_Data.s;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void Form_OwnUse_AddOn_Load(object sender, EventArgs e)
        {
            if (this.m_usrc_OwnUse_AddOn.Init(AddOnOwnUse, m_bPrint, m_usrc_AddOn))
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

        private bool m_usrc_OwnUseAddOn_Issue(ShopC_Forms.OwnUseAddOn ownUseAddOn, Transaction transaction)
        {
            bool bres = false;
            if (Issue!=null)
            {
                bres = Issue(ownUseAddOn, transaction);
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
