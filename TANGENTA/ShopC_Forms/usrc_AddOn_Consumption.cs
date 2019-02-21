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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using DBConnectionControl40;
using DBTypes;
using TangentaDB;
using CodeTables;
using TangentaTableClass;
using HUDCMS;

namespace ShopC_Forms
{
    public partial class usrc_AddOn_Consumption : UserControl
    {

        public delegate void delegate_Cancel();
        public event delegate_Cancel Cancel;

        public delegate bool delegate_Issue(ShopC_Forms.ConsumptionAddOn ownuse_add_on, Transaction transaction);
        public event delegate_Issue Issue = null;

        private ConsumptionAddOn m_AddOnConsumption= null;
        private ConsumptionAddOn AddOnConsumption
        {
            get
            {
                return m_AddOnConsumption;
            }
            set
            {
                m_AddOnConsumption= value;
            }
        }

        private usrc_Consumption_AddOn m_usrc_Consumption_AddOn = null;

        private bool m_bPrint;

        public usrc_AddOn_Consumption()
        {
            InitializeComponent();
            lng.s_Removing_from_stock_Reason_Name.Text(lbl_Comsumption_Reason_Name);
            lng.s_Removing_from_stock_Reason_Description.Text(lbl_Consumption_Reason_Description);
            lng.s_Removing_from_stock_description1.Text(lbl_Description_Name);
            lng.s_IssueDate.Text(lbl_DateOfIssue);
                       
            lng.s_Issue.Text(btn_Comsumption_Issue);

            this.dtP_DateOfIssue.Value = DateTime.Now;
         

        }

       

        public bool Init(ConsumptionAddOn x_ConsumptionAddOn, bool bxPrint, usrc_Consumption_AddOn x_usrc_AddOn) //, int xCurrency_DecimalPlaces, decimal xGrossSum)
        {
          
            AddOnConsumption= x_ConsumptionAddOn;
            m_bPrint = bxPrint;
            m_usrc_Consumption_AddOn = x_usrc_AddOn;
            if (m_bPrint)
            {
                lng.s_Consumption_Issue.Text(this.btn_Comsumption_Issue);
            }
            else
            {
                this.btn_Comsumption_Issue.Text = lng.s_OK.s;
            }

            AddOnConsumption.GetReasonTable();
            AddOnConsumption.GetDescriptionTable();
            cmb_Reason.DataSource = AddOnConsumption.dtConsumptionReason;
            cmb_Reason.DisplayMember = "Name";
            cmb_Reason.ValueMember = "ID";

            cmb_Description.DataSource = AddOnConsumption.dtConsumptionDescription;
            cmb_Reason.DisplayMember = "Name";
            cmb_Reason.ValueMember = "ID";

            if (ID.Validate(m_usrc_Consumption_AddOn.ConsM.ConsE.CurrentCons.Doc_ID))
            {
                if (AddOnConsumption.Get(m_usrc_Consumption_AddOn.ConsM.ConsE.CurrentCons.Doc_ID))
                {
                    

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        

        private void btn_Issue_Click(object sender, EventArgs e)
        {
           
            if (m_AddOnConsumption.MyIssueDate == null)
            {
                m_AddOnConsumption.MyIssueDate = new ConsumptionAddOn.IssueDate();
            }
            m_AddOnConsumption.MyIssueDate.Date = dtP_DateOfIssue.Value;


            ltext ltMsg = null;
            //AddOnDI.m_NoticeText = this.usrc_Notice1.NoticeText;
            if (AddOnConsumption.Completed(ref ltMsg))
            {
                Transaction transaction_usrc_DocInvoice_AddOn_Set = DBSync.DBSync.NewTransaction("usrc_Consumption_AddOn.btn_Issue_Click");
                AddOnConsumption.ReasonName = this.cmb_Reason.Text;
                AddOnConsumption.ReasonDescription = this.txt_ReasonDescription.Text;
                AddOnConsumption.DescriptionName = this.cmb_Description.Text;
                AddOnConsumption.DescriptionDescription = this.txt_DescriptionDescription.Text;
                if (Issue != null)
                {
                    if (Issue(AddOnConsumption, transaction_usrc_DocInvoice_AddOn_Set))
                    {
                        transaction_usrc_DocInvoice_AddOn_Set.Commit();
                    }
                    else
                    {
                        transaction_usrc_DocInvoice_AddOn_Set.Rollback();
                    }
                }
                
            }
            else
            {
                XMessage.Box.Show(this, false, ltMsg,MessageBoxIcon.Exclamation);
            }
        }

            
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Cancel != null)
            {
                Cancel();
            }
        }
    }
}
