#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion


using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TangentaTableClass;
using CodeTables;
using LanguageControl;
using DBTypes;
using TangentaDB;
using System.Drawing;
using System.Linq;
using DBConnectionControl40;
using LoginControl;
using TangentaProperties;
using PriseLists;

namespace ShopC_Forms
{
    public partial class usrc_ConsumptionEditor : UserControl
    {
        public delegate bool delegate_Issue(ShopC_Forms.ConsumptionAddOn ownuse_add_on, Transaction transaction);
        public event delegate_Issue Issue = null;

        internal class Defpos
        {
            internal int lbl_Number_Left;
            internal int lbl_Number_Top;
            internal int txt_Number_Left;
            internal int txt_Number_Top;
            internal int usrc_Customer_Left;
            internal int usrc_Customer_Top;
        }
        private Defpos defpos = null;
        private ConsumptionEditor.DoCurrent_delegates doCurrent_delegates;

        public ConsumptionEditor ConsE = null;
        private ConsumptionMan ConsM = null;

        private NavigationButtons.Navigation nav = null;


        public delegate void delegate_LayoutChanged();
        public event delegate_LayoutChanged LayoutChanged = null;

        public delegate void delegate_New_Click(object sender, EventArgs e);
        public event delegate_New_Click New_Click = null;


        public delegate void delegate_SetTotalColor(Color color);
        public event delegate_SetTotalColor SetTotalColor = null;

        public delegate void delegate_SetTotal(string stotal);
        public event delegate_SetTotal SetTotal = null;

        public delegate void delegate_SetBtnIssueLabel(string slabel);
        public event delegate_SetBtnIssueLabel SetBtnIssueLabel = null;

        public delegate void delegate_SetBtnIssueVisible(bool bvisible);
        public event delegate_SetBtnIssueVisible SetBtnIssueVisible = null;
     

        public int ShopA_default_X = -1;
        public int ShopA_default_Y = -1;
        public int ShopB_default_X = -1;
        public int ShopB_default_Y = -1;
        public int ShopC_default_X = -1;
        public int ShopC_default_Y = -1;

        public int ShopA_default_W = -1;
        public int ShopA_default_H = -1;
        public int ShopB_default_W = -1;
        public int ShopB_default_H = -1;
        public int ShopC_default_W = -1;
        public int ShopC_default_H = -1;


        public bool IsWriteOff
        {
            get
            { return ConsE.ConsumptionType_Name.Equals(f_ConsumptionType.ltconst_ConsumptionWriteOff.s); }
        }

        public bool IsOwnUsw
        {
            get
            { return ConsE.ConsumptionType_Name.Equals(f_ConsumptionType.ltconst_ConsumptionOwnUse.s); }
        }


        public delegate void delegate_Storno(bool bStorno);
        public event delegate_Storno Storno = null;

        public delegate void delegate_DocInvoiceSaved(ID DocInvoice_id);
        public event delegate_DocInvoiceSaved aa_DocInvoiceSaved;

        public delegate void delegate_DocProformaInvoiceSaved(ID DocProformaInvoice_id);
        public event delegate_DocProformaInvoiceSaved aa_DocProformaInvoiceSaved;

        public delegate void delegate_Customer_Person_Changed(ID Customer_Person_ID);
        public event delegate_Customer_Person_Changed aa_Customer_Person_Changed = null;

        public delegate void delegate_Customer_Org_Changed(ID Customer_Org_ID);
        public event delegate_Customer_Org_Changed aa_Customer_Org_Changed = null;




       

        public int NumberOfShopCGroupLevels
        {
            get
            {
                if (this.m_usrc_ConsumptionShopC != null)
                {
                    //return m_usrc_ShopC.NumberOfGroupLevels;
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
        }


       

        private void M_usrc_ShopA_aa_ItemRemoved(ID ID, DataTable dt)
        {
            get_price_sum();
        }

        private void M_usrc_ShopA_aa_ItemAdded(ID ID, DataTable dt)
        {
            get_price_sum();
        }


        private void Init_ShopC()
        {
            
            m_usrc_ConsumptionShopC.Init(ConsE.m_LMOUser,
                                      ConsE,
                                      ConsE.DBtcn,
                                      this.usrc_Item_selected1);

            m_usrc_ConsumptionShopC.Dock = DockStyle.None;
            m_usrc_ConsumptionShopC.ItemAdded += usrc_ShopC_ItemAdded;
            m_usrc_ConsumptionShopC.After_Atom_Item_Remove += usrc_ShopC_After_Atom_Item_Remove;
        }

        private bool M_usrc_ShopC_CheckIfAdministrator()
        {
            return ConsE.m_LMOUser.IsAdministrator;
        }

        private bool M_usrc_ShopC_CheckAccessStock()
        {
            return true;
        }

        private bool M_usrcCheckPriceListAccess()
        {
            return true;
        }






        internal void Set_ConsumptionMan_eMode_Shops(int usrc_ConsumptionEditor_Left,int usrc_TransactionLog_plus_usrc_LoginCtrl_width)
        {
            int idist = usrc_ConsumptionEditor_Left + usrc_TransactionLog_plus_usrc_LoginCtrl_width;
            this.lbl_Number.Left = defpos.lbl_Number_Left + idist;
            this.txt_Number.Left = defpos.txt_Number_Left + idist;
            this.m_usrc_ConsumptionShopC.Width = this.Width;
            //this.m_usrc_ShopC.Set_ConsumptionMan_eMode_Shops();
        }

    

        internal void Set_ConsumptionMan_eMode_Shops_and_InvoiceTable()
        {
            lbl_Number.Left = defpos.lbl_Number_Left;
            lbl_Number.Top = defpos.lbl_Number_Top;
            txt_Number.Left = defpos.txt_Number_Left;
            txt_Number.Top = defpos.txt_Number_Top;
        }


        internal void WizzardShow_ShopsVisible(string xshops_inuse)
        {
            if (LayoutChanged!=null)
            {
                LayoutChanged();
            }
            this.Refresh();
        }

        internal void WizzardShow_usrc_Invoice_Head_Visible(bool bvisible)
        {
            //chk_Head.Checked = bvisible;
            this.Refresh();
            this.Refresh();
        }

        private bool bInitShops = true;


       

        public enum enum_GetOrganisation_Person_Data { MyOrganisation_Data_OK,
            No_MyOrganisation_Tax_ID,
            No_MyOrganisation_name,
            No_MyOrganisation_StreetName,
            No_MyOrganisation_HouseNumber,
            No_MyOrganisation_ZIP,
            No_MyOrganisation_City,
            No_MyOrganisation_Country,
            No_MyOrganisation_State,
            No_MyOrganisationData,
            No_MyOrganisation_Person_FirstName,
            No_MyOrganisation_Person,
            Error_Load_MyOrganisation_data

        };

        private bool EventsActive;



        public ID PriceList_ShopC_ID
        {
            get
            {
                if (m_usrc_ConsumptionShopC != null)
                {
                    return m_usrc_ConsumptionShopC.m_usrc_PriceList1.ID;
                }
                else
                {
                    if (this.DesignMode)
                    {
                        return null;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:public long PriceList_ID:this.usrc_PriceList==null");
                        return null;
                    }
                }
            }
        }


        //public bool HeadVisible
        //{
        //    get {
        //         return this.chk_Head.Checked;
        //        }
        //}

        public usrc_ConsumptionEditor()
        {
            InitializeComponent();
            defpos = new Defpos();
            defpos.lbl_Number_Left = lbl_Number.Left;
            defpos.lbl_Number_Top = lbl_Number.Top;
            defpos.txt_Number_Left= txt_Number.Left;
            defpos.txt_Number_Top = txt_Number.Top;
            usrc_PriceList xusrc_PriceListC = null;
            if (this.m_usrc_ConsumptionShopC != null)
            {
                xusrc_PriceListC = this.m_usrc_ConsumptionShopC.m_usrc_PriceList1;
            }
            doCurrent_delegates = new ConsumptionEditor.DoCurrent_delegates(
                                   xusrc_PriceListC,
                                   this.usrc_Consumption_AddOn1.Show,
                                   this.AddHandler,
                                   this.RemoveHandler,
                                   this.set_InvoiceNumberText,
                                   this.SetMode,
                                   this.m_usrc_ConsumptionShopC.SetCurrentInvoice_SelectedItems,
                                   this.chk_Storno_Show,
                                   this.chk_Storno_Check,
                                   this.m_usrc_ConsumptionShopC.Reset,
                                   this.m_usrc_ConsumptionShopC.Clear,
                                   this.btn_Issue_Show,
                                   this.lbl_Sum_ForeColor,
                                   this.lbl_Sum_Text,
                                   this.m_usrc_ConsumptionShopC.m_usrc_ItemList.Get_Price_Item_Stock_Data);

            ShopC_default_X = this.m_usrc_ConsumptionShopC.Left;
            ShopC_default_Y = this.m_usrc_ConsumptionShopC.Top;

            ShopC_default_W = this.m_usrc_ConsumptionShopC.Width;
            ShopC_default_H = this.m_usrc_ConsumptionShopC.Height;

            //lng.s_Number.Text(lbl_Number);
            //btn_BuyerSelect.Text = lng.s_BuyerSelect.s;
            //this.usrc_DocIssue1.BtnIssueLabel = lng.s_Issue.s;

            //lng.s_chk_Storno.Text(chk_Storno);

            

            //this.usrc_DocIssue1.Total = lng.s_Total.s;
            //lng.s_btn_New.Text(btn_New);


        }

        internal void SetMode(ConsumptionEditor.emode mode)
        {
            ConsE.m_mode = mode;
            if (mode == ConsumptionEditor.emode.edit_eDocumentType)
            {
                this.m_usrc_ConsumptionShopC.SetMode(usrc_ConsumptionShopC.eMode.EDIT);
            }
            else
            {
                this.m_usrc_ConsumptionShopC.SetMode(usrc_ConsumptionShopC.eMode.VIEW);
            }

            if (mode == ConsumptionEditor.emode.view_eDocumentType)
            {
                chk_Storno.Visible = true;
                usrc_DocIssue1.BtnIssueLabel = lng.s_Print.s;
                if (SetBtnIssueLabel!=null)
                {
                    SetBtnIssueLabel(lng.s_Print.s);
                }
            
            }
            else
            {
                usrc_DocIssue1.BtnIssueLabel = lng.s_Issue.s;
                if (SetBtnIssueLabel != null)
                {
                    SetBtnIssueLabel(lng.s_Issue.s);
                }
                chk_Storno.Visible = false;
            }

        }

        public void EnableControls(bool b)
        {
            //this.splitContainer1.Enabled = b;
        }

      
       
       


        public bool Initialise(ConsumptionMan xDocM, LoginControl.LMOUser xLMOUser)
        {
            ConsM = xDocM;
            ConsE = ConsM.ConsE;
            ConsE.m_mode = ConsumptionEditor.emode.view_eDocumentType;
            ConsM = xDocM;
            ConsE.m_LMOUser = xLMOUser;
           
            usrc_Consumption_AddOn1.Init(this, this.ConsM);

            SetOperationMode();
            return true;
        }

        private void SetOperationMode()
        {
         

        }

        

        public bool Init(ID Document_ID)
        {
            Form pform = Global.f.GetParentForm(this);

            m_usrc_ConsumptionShopC.Init(this.ConsE.m_LMOUser, this.ConsE, this.ConsE.DBtcn, this.usrc_Item_selected1);

            Transaction transaction_ConsE_Init = DBSync.DBSync.NewTransaction("ConsE.Init");
            if (ConsE.Init(pform,
                            Document_ID,
                            doCurrent_delegates,
                            transaction_ConsE_Init
                            ))
            {
                if (transaction_ConsE_Init.Commit())
                {
                    
                   
                    m_usrc_ConsumptionShopC.CheckAccessPriceList += M_usrcCheckPriceListAccess;
                    m_usrc_ConsumptionShopC.CheckAccessStock += M_usrc_ShopC_CheckAccessStock;
                    m_usrc_ConsumptionShopC.CheckIfAdministrator += M_usrc_ShopC_CheckIfAdministrator;

                    m_usrc_ConsumptionShopC.ItemAdded += usrc_ShopC_ItemAdded;
                    m_usrc_ConsumptionShopC.After_Atom_Item_Remove += usrc_ShopC_After_Atom_Item_Remove;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                transaction_ConsE_Init.Rollback();
                return false;
            }
        }

        internal void SetColor()
        {
            this.BackColor = Colors.m_usrc_ConsumptionEditor.BackColor;
            this.ForeColor = Colors.m_usrc_ConsumptionEditor.ForeColor;
            
        }

      

        private void set_InvoiceNumberText(string s)
        {
            this.txt_Number.Text = s;
        }

        private void chk_Storno_Show(bool bvisible)
        {
            this.chk_Storno.Visible = bvisible;
        }

        private void chk_Storno_Check(bool bcheck)
        {
            this.chk_Storno.Checked = bcheck;
        }

        private void btn_Issue_Show(bool bvisible)
        {
            usrc_DocIssue1.Visible = bvisible;
            if (SetBtnIssueVisible!=null)
            {
                SetBtnIssueVisible(bvisible);
            }
        }

        private void lbl_Sum_ForeColor(Color color)
        {
            usrc_DocIssue1.TotalColor = color;
           if (SetTotalColor!=null)
            {
                SetTotalColor(color);
            }
            
        }

        private void lbl_Sum_Text(string s)
        {
            usrc_DocIssue1.Total = s;
            if (SetTotal != null)
            {
                SetTotal(s);
            }
        }

        public bool DoCurrent(ID xID, Transaction transaction)
        {
            return ConsE.DoCurrent(xID,
                        doCurrent_delegates,
                        transaction
                        );
        }

      
        private void AddHandler()
        {
            if (!EventsActive)
            {
                EventsActive = true;
             
            }
        }

        private void RemoveHandler()
        {
            if (EventsActive)
            {
                EventsActive = false;
                
            }
        }







        


        public void SetNewDraft(LMOUser xLMOUser,
                                string consumptionTyp,
                                string consumption_name,
                                string consumption_description,
                                int xFinancialYear,
                                xCurrency xcurrency,
                                ID Atom_Currency_ID)
        {
            Form pform = Global.f.GetParentForm(this);
            ConsE.SetNewDraft(pform,
                            xLMOUser,
                            consumptionTyp,
                            consumption_name,
                            consumption_description,
                            xFinancialYear,
                            xcurrency,
                            Atom_Currency_ID,
                            this.SetMode,
                            this.set_InvoiceNumberText
                            );
        }

        private bool SetNewConsumptionDraft(LMOUser xLMOUser,
                                            string consumption_name,
                                            string consumption_description,
                                            int FinancialYear,
                                            xCurrency xcurrency,
                                            ID xAtom_Currency_ID)
        {
            Form pform = Global.f.GetParentForm(this);
            return ConsE.SetNewConsumptionDraft(
                            pform,
                            xLMOUser,
                            consumption_name,
                            consumption_description,
                            FinancialYear,
                            xcurrency,
                            xAtom_Currency_ID,
                            //workArea,
                            this.SetMode,
                            this.set_InvoiceNumberText
                            );
        }

        private void get_price_sum()
        {
            //ConsE.GetPriceSum(this.m_usrc_ShopA.dt_Item_Price,
            //                        this.m_usrc_ShopB.dt_SelectedShopBItem,
            //                        this.btn_Issue_Show,
            //                        this.lbl_Sum_ForeColor,
            //                        this.lbl_Sum_Text);
        }

        private void usrc_ShopC_ItemAdded()
        {
            get_price_sum();
        }

        private void usrc_ShopC_After_Atom_Item_Remove()
        {
            get_price_sum();
        }

        private void usrc_ShopB_ItemUpdated(ID ID, DataTable dt_SelectedSimpleItem)
        {
            get_price_sum();
        }

        internal bool GetConsumptionData(usrc_ConsumptionMan usrc_ConsumptionMan)
        {
            Form_Consumption_AddOn frm_Consumption_AddOn = new Form_Consumption_AddOn(ConsE.MyConsumptionData.AddOnConsumption, false, this.usrc_Consumption_AddOn1);
            frm_Consumption_AddOn.Issue += Frm_Consumption_AddOn_Issue;
            if (frm_Consumption_AddOn.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Frm_Consumption_AddOn_Issue(ConsumptionAddOn ownuse_add_on, Transaction transaction)
        {
            if (Issue!=null)
            {
                return Issue(ownuse_add_on, transaction);
            }
            else
            {
                return false;
            }
        }

        private void usrc_ShopB_ExtraDiscount(ID ID, DataTable dt_SelectedSimpleItem)
        {
            get_price_sum();
        }

        private void usrc_ShopB_ItemRemoved(ID ID, DataTable dt_SelectedSimpleItem)
        {
            get_price_sum();
        }

        private void usrc_ShopB_ItemAdded(ID ID, DataTable dt_SelectedSimpleItem)
        {
            get_price_sum();
        }




        private void docInvoice_saved(ID doc_ID)
        {
            if (aa_DocInvoiceSaved != null)
            {
                aa_DocInvoiceSaved(doc_ID);
            }
        }
        private void docProformaInvoice_saved(ID doc_ID)
        {
            if (aa_DocProformaInvoiceSaved != null)
            {
                aa_DocProformaInvoiceSaved(ConsE.CurrentCons.Doc_ID);
            }
        }


        internal void btn_Issue_Click(object sender, EventArgs e)
        {
            Form pform = Global.f.GetParentForm(this);
            //ConsE.btn_Issue_Click(pform,
            //                    usrc_AddOn1.Check_Consumption_AddOn,
            //                    usrc_AddOn1.Get_Doc_AddOn,
            //                    usrc_AddOn1.Check_DocProformaInvoice_AddOn,
            //                    usrc_AddOn1.Get_Doc_AddOn,
            //                    this.DoCurrent,
            //                    this.docInvoice_saved,
            //                    this.docProformaInvoice_saved
            //                    );
        }

   
      

        private void customer_Person_Changed(ID customer_Person_ID)
        {
            if (aa_Customer_Person_Changed != null)
            {
                aa_Customer_Person_Changed(customer_Person_ID);
            }

        }

        private void customer_Organisation_Changed(ID Customer_Org_ID)
        {
            if (aa_Customer_Org_Changed != null)
            {
                aa_Customer_Org_Changed(Customer_Org_ID);
            }

        }



        private void storno_event(bool b)
        {
            if (Storno != null)
            {
                Storno(b);
            }
        }
        private void chk_Storno_CheckedChanged(object sender, EventArgs e)
        {
            Form pform = Global.f.GetParentForm(this);
            Transaction transaction_usrc_ConsumptionEditor_chk_Storno_CheckedChanged = DBSync.DBSync.NewTransaction("transaction_usrc_ConsumptionEditor_chk_Storno_CheckedChanged");
            if (ConsE.Storno_CheckedChanged(pform,
                                       chk_Storno.Checked,
                                       txt_Number.Text,
                                       storno_event,
                                       chk_Storno_Check,
                                       transaction_usrc_ConsumptionEditor_chk_Storno_CheckedChanged
                                       ))
            {
                transaction_usrc_ConsumptionEditor_chk_Storno_CheckedChanged.Commit();
            }
            else
            {
                transaction_usrc_ConsumptionEditor_chk_Storno_CheckedChanged.Rollback();
            }
        }




     

        private void usrc_Currency1_CurrencyChanged(xCurrency currency, ID xAtom_Currency_ID)
        {
            GlobalData.BaseCurrency = currency;
            ConsE.Atom_Currency_ID = xAtom_Currency_ID;
        }

        private void chk_Head_CheckedChanged_1(object sender, EventArgs e)
        {
            if (LayoutChanged != null)
            {
                LayoutChanged();
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            if (New_Click!=null)
            {
                New_Click(sender, e);
            }
        }
        public void DoRefresh()
        {
            this.m_usrc_ConsumptionShopC.DoRefresh();
        }
    }
}
