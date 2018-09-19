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
using ShopA;
using ShopB;
using ShopC;
using System.Drawing;
using System.Linq;
using Startup;
using DBConnectionControl40;
using LoginControl;

namespace Tangenta
{
    public partial class usrc_DocumentEditor1366x768 : UserControl
    {
        public DocumentEditor DocE = null;
        private DocumentMan DocM = null;

        private NavigationButtons.Navigation nav = null;


        public delegate void delegate_LayoutChanged();
        public event delegate_LayoutChanged LayoutChanged = null;

        public delegate void delegate_New_Click(object sender, EventArgs e);
        public event delegate_New_Click New_Click = null;

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


        public bool IsDocInvoice
        {
            get
            { return DocE.DocTyp.Equals(GlobalData.const_DocInvoice); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocE.DocTyp.Equals(GlobalData.const_DocProformaInvoice); }
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




        public int NumberOfShopBGroupLevels
        {
            get
            {
                if (this.m_usrc_ShopB1366x768 != null)
                {
                    return m_usrc_ShopB1366x768.NumberOfGroupLevels;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int NumberOfShopCGroupLevels
        {
            get
            {
                if (this.m_usrc_ShopC1366x768 != null)
                {
                    //return m_usrc_ShopC1366x768.NumberOfGroupLevels;
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
        }


        public List<Employee> Employees = new List<Employee>();

        private void Init_ShopA()
        {
            m_usrc_ShopA1366x768.Init(DocE.m_ShopABC, DocE.DBtcn);
            m_usrc_ShopA1366x768.Dock = DockStyle.None;
            m_usrc_ShopA1366x768.aa_ItemAdded += M_usrc_ShopA_aa_ItemAdded;
            m_usrc_ShopA1366x768.aa_ItemRemoved += M_usrc_ShopA_aa_ItemRemoved;
            m_usrc_ShopA1366x768.EditUnits += M_usrc_ShopA_EditUnits;

        }

        private bool M_usrc_ShopA_EditUnits()
        {
            SQLTable tbl_Unit = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Unit)));
            Form_Unit_Edit unit_dlg = new Form_Unit_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Unit, "ID asc",nav);
            if (unit_dlg.ShowDialog() == DialogResult.OK)
            {
                DocE.GetUnits();
                return true;

            }
            return false;
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
            //if (m_usrc_ShopC1366x768 == null)
            //{
            //    m_usrc_ShopC1366x768 = new usrc_ShopC1366x768();
            //    m_usrc_ShopC1366x768.DocTyp = this.DocTyp;
            //    m_usrc_ShopC1366x768.CheckAccessPriceList += M_usrcCheckPriceListAccess;
            //    m_usrc_ShopC1366x768.CheckAccessStock += M_usrc_ShopC_CheckAccessStock;
            //    m_usrc_ShopC1366x768.CheckIfAdministrator += M_usrc_ShopC_CheckIfAdministrator;
            //}
            m_usrc_ShopC1366x768.Init(DocE.m_LMOUser.Atom_WorkPeriod_ID, DocE.m_ShopABC, DocE.DBtcn,ShopsUse.ShopsInUse_Get(DocE.mSettingsUserValues),Properties.Settings.Default.AutomaticSelectionOfItemFromStock,Program.OperationMode.ShopC_ExclusivelySellFromStock);
            m_usrc_ShopC1366x768.Dock = DockStyle.None;
            m_usrc_ShopC1366x768.ItemAdded += usrc_ShopC_ItemAdded;
            m_usrc_ShopC1366x768.After_Atom_Item_Remove += usrc_ShopC_After_Atom_Item_Remove;
        }

        private bool M_usrc_ShopC_CheckIfAdministrator()
        {
            return DocE.m_LMOUser.IsAdministrator;
        }

        private bool M_usrc_ShopC_CheckAccessStock()
        {
            return DocE.door.OpenStockEdit(Global.f.GetParentForm(this));
        }

        private bool M_usrcCheckPriceListAccess()
        {
            return DocE.door.OpenPriceList(Global.f.GetParentForm(this));
        }

        private void Set_ShowShops_A()
        {
            ShopsUse.ShowShops_Set(DocE.mSettingsUserValues, "A");
            m_usrc_ShopA1366x768.Visible = true;
            m_usrc_ShopA1366x768.Top = ShopA_default_Y;
            m_usrc_ShopA1366x768.Height = (ShopC_default_Y+ShopC_default_H)- ShopA_default_Y;

            m_usrc_ShopB1366x768.Visible = false;
            m_usrc_ShopC1366x768.Visible = false;
        }

        private void Set_ShowShops_B()
        {
            ShopsUse.ShowShops_Set(DocE.mSettingsUserValues,"B");
            m_usrc_ShopB1366x768.Visible = true;
            m_usrc_ShopB1366x768.Top = ShopA_default_Y; 
            m_usrc_ShopB1366x768.Height = (ShopC_default_Y + ShopC_default_H)- ShopA_default_Y;

            m_usrc_ShopA1366x768.Visible = false;
            m_usrc_ShopC1366x768.Visible = false;
        }

        private void Set_ShowShops_C()
        {
            ShopsUse.ShowShops_Set(DocE.mSettingsUserValues, "C");
            m_usrc_ShopC1366x768.Visible = true;
            m_usrc_ShopC1366x768.Top = ShopA_default_Y; 
            m_usrc_ShopC1366x768.Height = (ShopC_default_Y + ShopC_default_H)- ShopA_default_Y;

            m_usrc_ShopB1366x768.Visible = false;
            m_usrc_ShopA1366x768.Visible = false;
        }


        private void Set_ShowShops_AB()
        {
            ShopsUse.ShowShops_Set(DocE.mSettingsUserValues, "AB");

            m_usrc_ShopA1366x768.Visible = true;
            m_usrc_ShopA1366x768.Top = ShopA_default_Y;
            m_usrc_ShopA1366x768.Height = (ShopB_default_Y + ShopB_default_H/2)- ShopA_default_Y;

            m_usrc_ShopB1366x768.Visible = true;
            m_usrc_ShopB1366x768.Top = ShopA_default_Y+m_usrc_ShopA1366x768.Height;
            m_usrc_ShopB1366x768.Height = (ShopC_default_Y + ShopC_default_H)- (ShopA_default_Y + m_usrc_ShopA1366x768.Height);

            m_usrc_ShopC1366x768.Visible = false;
        }


        private void Set_ShowShops_BC()
        {
            ShopsUse.ShowShops_Set(DocE.mSettingsUserValues, "BC");
            m_usrc_ShopB1366x768.Visible = true;
            m_usrc_ShopB1366x768.Top = ShopA_default_Y; 
            m_usrc_ShopB1366x768.Height = (ShopB_default_Y + ShopB_default_H / 2)- ShopA_default_Y;

            m_usrc_ShopC1366x768.Visible = true;
            m_usrc_ShopC1366x768.Top = ShopA_default_Y+m_usrc_ShopB1366x768.Height;
            m_usrc_ShopC1366x768.Height = (ShopC_default_Y + ShopC_default_H) - (ShopA_default_Y + m_usrc_ShopB1366x768.Height);

            m_usrc_ShopA1366x768.Visible = false;
        }

        private void Set_ShowShops_AC()
        {
            ShopsUse.ShowShops_Set(DocE.mSettingsUserValues, "AC");
            m_usrc_ShopA1366x768.Visible = true;
            m_usrc_ShopA1366x768.Top = ShopA_default_Y; 
            m_usrc_ShopA1366x768.Height = (ShopB_default_Y + ShopB_default_H / 2)- ShopA_default_Y; 

            m_usrc_ShopC1366x768.Visible = true;
            m_usrc_ShopC1366x768.Top = ShopA_default_Y + m_usrc_ShopA1366x768.Height;
            m_usrc_ShopC1366x768.Height = (ShopC_default_Y + ShopC_default_H) - (ShopA_default_Y + m_usrc_ShopA1366x768.Height);

            m_usrc_ShopB1366x768.Visible = false;
        }

        private void Set_ShowShops_ABC()
        {
            ShopsUse.ShowShops_Set(DocE.mSettingsUserValues,"ABC");
            m_usrc_ShopA1366x768.Visible = true;
            m_usrc_ShopA1366x768.Top = ShopA_default_Y;
            m_usrc_ShopA1366x768.Height = ShopA_default_H;

            m_usrc_ShopB1366x768.Visible = true;
            m_usrc_ShopB1366x768.Top = ShopB_default_Y; 
            m_usrc_ShopB1366x768.Height = ShopB_default_H;

            m_usrc_ShopC1366x768.Visible = true;
            m_usrc_ShopC1366x768.Top = ShopC_default_Y; ;
            m_usrc_ShopC1366x768.Height = ShopC_default_H;
        }

        internal void WizzardShow_ShopsVisible(string xshops_inuse)
        {
            this.Set_ShowShops(xshops_inuse);
            if (LayoutChanged!=null)
            {
                LayoutChanged();
            }
            this.Refresh();
        }

        internal void WizzardShow_usrc_Invoice_Head_Visible(bool bvisible)
        {
            chk_Head.Checked = bvisible;
            this.Refresh();
            this.Refresh();
        }

        private void Init_ShopB()

        {
            m_usrc_ShopB1366x768.Init(DocE.m_ShopABC, DocE.DBtcn, ShopsUse.ShopsInUse_Get(DocE.mSettingsUserValues));

            m_usrc_ShopB1366x768.Dock = DockStyle.None;

            m_usrc_ShopB1366x768.aa_ExtraDiscount += usrc_ShopB_ExtraDiscount;

            m_usrc_ShopB1366x768.aa_ItemAdded += usrc_ShopB_ItemAdded;

            m_usrc_ShopB1366x768.aa_ItemRemoved += usrc_ShopB_ItemRemoved;

            m_usrc_ShopB1366x768.aa_ItemUpdated += usrc_ShopB_ItemUpdated;

        }


        internal void Set_ShowShops(string showShops)
        {
            showShops = ShopsUse.setCompatibleWithShopsInUse(DocE.mSettingsUserValues, showShops);

            if (showShops.Equals("A"))
            {
                Set_ShowShops_A();
            }
            else if (showShops.Equals("B"))
            {
                Set_ShowShops_B();
            }
            else if (showShops.Equals("C"))
            {
                Set_ShowShops_C();
            }
            else if (showShops.Equals("AB"))
            {
                Set_ShowShops_AB();
            }
            else if (showShops.Equals("BC"))
            {
                Set_ShowShops_BC();
            }
            else if (showShops.Equals("AC"))
            {
                Set_ShowShops_AC();
            }
            else if (showShops.Equals("ABC"))
            {
                Set_ShowShops_ABC();
            }
        }

       

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

        public ID PriceList_ShopB_ID
        {
            get
            {
                if (m_usrc_ShopB1366x768 != null)
                {
                    return m_usrc_ShopB1366x768.usrc_PriceList1.ID;
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


        public ID PriceList_ShopC_ID
        {
            get
            {
                if (m_usrc_ShopC1366x768 != null)
                {
                    return m_usrc_ShopC1366x768.m_usrc_PriceList1.ID;
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

        public bool ShopA_DefaultVisible
        {
            get { return ShopsUse.ShowShops_Get(DocE.mSettingsUserValues).Contains("A"); }
        }
        public bool ShopB_DefaultVisible
        {
            get { return ShopsUse.ShowShops_Get(DocE.mSettingsUserValues).Contains("B"); }
        }

        public bool ShopC_DefaultVisible
        {
            get { return ShopsUse.ShowShops_Get(DocE.mSettingsUserValues).Contains("Ç"); }
        }

        public bool HeadVisible
        {
            get {
                 return this.chk_Head.Checked;
                }
        }

        public usrc_DocumentEditor1366x768()
        {
            InitializeComponent();
            ShopA_default_X = this.m_usrc_ShopA1366x768.Left;
            ShopA_default_Y = this.m_usrc_ShopA1366x768.Top;
            ShopB_default_X = this.m_usrc_ShopB1366x768.Left;
            ShopB_default_Y = this.m_usrc_ShopB1366x768.Top;
            ShopC_default_X = this.m_usrc_ShopC1366x768.Left;
            ShopC_default_Y = this.m_usrc_ShopC1366x768.Top;

            ShopA_default_W = this.m_usrc_ShopA1366x768.Width;
            ShopA_default_H = this.m_usrc_ShopA1366x768.Height;
            ShopB_default_W = this.m_usrc_ShopB1366x768.Width;
            ShopB_default_H = this.m_usrc_ShopB1366x768.Height;
            ShopC_default_W = this.m_usrc_ShopC1366x768.Width;
            ShopC_default_H = this.m_usrc_ShopC1366x768.Height;

            usrc_AddOn1.Init(this);
            DocE.m_mode = DocumentEditor.emode.view_eDocumentType;
            lng.s_Show_Shops.Text(btn_Show_Shops);
            lng.s_Number.Text(lbl_Number);
            //btn_BuyerSelect.Text = lng.s_BuyerSelect.s;
            lng.s_Issue.Text(btn_Issue);
            lng.s_chk_Storno.Text(chk_Storno);

            lng.s_Shop_AB = new ltext(lng.s_Shop_A.sText(0) + " && " + lng.s_Shop_B.sText(0), lng.s_Shop_A.sText(1) + " && " + lng.s_Shop_B.sText(1));
            lng.s_Shop_BC = new ltext(lng.s_Shop_B.sText(0) + " && " + lng.s_Shop_C.sText(0), lng.s_Shop_B.sText(1) + " && " + lng.s_Shop_C.sText(1));
            lng.s_Shop_AC = new ltext(lng.s_Shop_A.sText(0) + " && " + lng.s_Shop_C.sText(0), lng.s_Shop_A.sText(1) + " && " + lng.s_Shop_C.sText(1));
            lng.s_Shop_ABC = new ltext(lng.s_Shop_A.sText(0) + " && " + lng.s_Shop_B.sText(0) + " && " + lng.s_Shop_C.sText(0), lng.s_Shop_A.sText(1) + " && " + lng.s_Shop_B.sText(1) + " && " + lng.s_Shop_C.sText(1));

            lng.s_Total.Text(this.lbl_Sum);
            lng.s_btn_New.Text(btn_New);


        }

        internal void SetMode(DocumentEditor.emode mode)
        {
            DocE.m_mode = mode;
            if (mode == DocumentEditor.emode.edit_eDocumentType)
            {
                this.m_usrc_ShopA1366x768.SetMode(usrc_ShopA1366x768.eMode.EDIT);
                this.m_usrc_ShopB1366x768.SetMode(usrc_ShopB1366x768.eMode.EDIT);
                this.m_usrc_ShopC1366x768.SetMode(usrc_ShopC1366x768.eMode.EDIT);
            }
            else
            {
                this.m_usrc_ShopA1366x768.SetMode(usrc_ShopA1366x768.eMode.VIEW);
                this.m_usrc_ShopB1366x768.SetMode(usrc_ShopB1366x768.eMode.VIEW);
                this.m_usrc_ShopC1366x768.SetMode(usrc_ShopC1366x768.eMode.VIEW);
            }

            if (mode == DocumentEditor.emode.view_eDocumentType)
            {
                chk_Storno.Visible = true;
                lng.s_Print.Text(btn_Issue);
            }
            else
            {
                lng.s_Issue.Text(btn_Issue);
                chk_Storno.Visible = false;
            }

        }

        public void EnableControls(bool b)
        {
            //this.splitContainer1.Enabled = b;
        }

      
        private bool EditMyOrganisation_Data(bool bAllowNew,NavigationButtons.Navigation xnav)
        {
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Edit edt_my_company_dlg = new Form_myOrg_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation))), bAllowNew,xnav,null);
            this.Cursor = Cursors.Arrow;
            xnav.ChildDialog = edt_my_company_dlg;
            xnav.ShowDialog();
            if ((xnav.eExitResult == NavigationButtons.Navigation.eEvent.OK)|| (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV) || (xnav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Initialise(DocumentMan xDocM, LoginControl.LMOUser xLMOUser)
        {
            DocM = xDocM;
            DocE = DocM.DocE;
            DocE.mSettingsUserValues = ((SettingsUser)xLMOUser.oSettings).mSettingsUserValues;
            DocM = xDocM;
            DocE.m_LMOUser = xLMOUser;
            DocE.door = new Door(DocE.m_LMOUser);
            lng.s_Head.Text(chk_Head);
            chk_Head.Checked = DocE.mSettingsUserValues.InvoiceHeaderChecked;
            chk_Head.CheckedChanged += chk_Head_CheckedChanged;
            //splitContainer2.Panel1Collapsed = !chk_Head.Checked;

         

            SetOperationMode();
            return true;
        }

        private void SetOperationMode()
        {
            //if (Program.OperationMode.MultiUser)
            //{
            //    txt_Issuer.Visible = false;
            //    lbl_Issuer.Visible = false;
            //}
            //else 
            //{
            //    txt_Issuer.Visible = true;
            //    lbl_Issuer.Visible = true;
            //}

        }

        private void usrc_PriceList_Ask_To_Update(char chShop, DataTable dt_ShopB_Item_NotIn_PriceList)
        {
            if (PriseLists.usrc_PriceList.Ask_To_Update(chShop, dt_ShopB_Item_NotIn_PriceList, this))
            {
                if (f_PriceList.Insert_ShopB_Items_in_PriceList(dt_ShopB_Item_NotIn_PriceList, this))
                {
                    bool bPriceListChanged = false;
                    this.m_usrc_ShopB1366x768.usrc_PriceList1.PriceList_Edit(true, ref bPriceListChanged);
                }
            }
        }

        public bool Init(ID Document_ID)
        {
            Form pform = Global.f.GetParentForm(this);
            return DocE.Init(pform,
                            Document_ID,
                            m_usrc_ShopB1366x768.usrc_PriceList1.ID,
                            m_usrc_ShopC1366x768.m_usrc_PriceList1.ID,
                            this.Set_ShowShops,
                            m_usrc_ShopB1366x768.usrc_PriceList1.Init,
                            m_usrc_ShopC1366x768.m_usrc_PriceList1.Init,
                            this.usrc_PriceList_Ask_To_Update,
                            m_usrc_ShopB1366x768.Get_Price_ShopBItem_Data,
                            this.DoCurrent,
                            m_usrc_ShopB1366x768.Set_dgv_SelectedShopB_Items,
                            m_usrc_ShopC1366x768.m_usrc_ItemList1366x768.Get_Price_Item_Stock_Data
                            );
        }

        internal void SetColor()
        {
            this.BackColor = Colors.m_usrc_DocumentEditor.BackColor;
            this.ForeColor = Colors.m_usrc_DocumentEditor.ForeColor;
            //this.splitContainer2.Panel1.BackColor = Colors.HeadColor.BackColor;
            //this.splitContainer2.Panel1.ForeColor = Colors.HeadColor.ForeColor;

            if (m_usrc_ShopA1366x768 != null)
            {
                m_usrc_ShopA1366x768.SetColor();
            }
            if (m_usrc_ShopB1366x768 != null)
            {
                m_usrc_ShopB1366x768.SetColor();
            }
            if (m_usrc_ShopC1366x768 != null)
            {
                m_usrc_ShopC1366x768.SetColor();
            }
        }

        private void set_CustomerText(string s)
        {
            usrc_Customer.Text = s;
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
            btn_Issue.Visible = bvisible;
        }

        private void lbl_Sum_ForeColor(Color color)
        {
            this.lbl_Sum.ForeColor = color;
        }

        private void lbl_Sum_Text(string s)
        {
            this.lbl_Sum.Text = s;
        }

        public bool DoCurrent(ID xID)
        {
            return DocE.DoCurrent(xID,
                        this.m_usrc_ShopB1366x768.SetDraftButtons,
                        this.m_usrc_ShopB1366x768.SetViewButtons,
                        this.usrc_Customer.Show_Customer,
                        this.set_CustomerText,
                        this.usrc_AddOn1.Show,
                        this.AddHandler,
                        this.RemoveHandler,
                        this.set_InvoiceNumberText,
                        this.SetMode,
                        this.m_usrc_ShopB1366x768.SetCurrentInvoice_SelectedShopB_Items,
                        this.m_usrc_ShopC1366x768.SetCurrentInvoice_SelectedItems,
                        this.chk_Storno_Show,
                        this.chk_Storno_Check,
                        this.m_usrc_ShopC1366x768.Reset,
                        this.m_usrc_ShopC1366x768.Clear,
                        this.m_usrc_ShopA1366x768.dt_Item_Price,
                        this.m_usrc_ShopB1366x768.dt_SelectedShopBItem,
                        this.btn_Issue_Show,
                        this.lbl_Sum_ForeColor,
                        this.lbl_Sum_Text
                        );
        }

        private void chk_Head_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Head.Checked)
            {
                //splitContainer2.Panel1Collapsed = false;
            }
            else
            {
                //splitContainer2.Panel1Collapsed = true;
            }

            ((SettingsUser)DocE.m_LMOUser.oSettings).mSettingsUserValues.InvoiceHeaderChecked = chk_Head.Checked;
            Properties.Settings.Default.Save();
        }

        private void AddHandler()
        {
            if (!EventsActive)
            {
                EventsActive = true;
                if (this.m_usrc_ShopB1366x768 != null)
                {
                    this.m_usrc_ShopB1366x768.aa_ItemAdded += new usrc_ShopB1366x768.delegate_ItemAdded(usrc_ShopB_ItemAdded);
                    this.m_usrc_ShopB1366x768.aa_ItemRemoved += new usrc_ShopB1366x768.delegate_ItemRemoved(usrc_ShopB_ItemRemoved);
                    this.m_usrc_ShopB1366x768.aa_ItemUpdated += new usrc_ShopB1366x768.delegate_ItemUpdated(usrc_ShopB_ItemUpdated);
                    this.m_usrc_ShopB1366x768.aa_ExtraDiscount += new usrc_ShopB1366x768.delegate_ExtraDiscount(usrc_ShopB_ExtraDiscount);
                }
            }
        }

        private void RemoveHandler()
        {
            if (EventsActive)
            {
                EventsActive = false;
                if (m_usrc_ShopB1366x768 != null)
                {
                    this.m_usrc_ShopB1366x768.aa_ItemAdded -= new usrc_ShopB1366x768.delegate_ItemAdded(usrc_ShopB_ItemAdded);
                    this.m_usrc_ShopB1366x768.aa_ItemRemoved -= new usrc_ShopB1366x768.delegate_ItemRemoved(usrc_ShopB_ItemRemoved);
                    this.m_usrc_ShopB1366x768.aa_ItemUpdated -= new usrc_ShopB1366x768.delegate_ItemUpdated(usrc_ShopB_ItemUpdated);
                    this.m_usrc_ShopB1366x768.aa_ExtraDiscount -= new usrc_ShopB1366x768.delegate_ExtraDiscount(usrc_ShopB_ExtraDiscount);
                }
            }
        }







        


        public void SetNewDraft(LMOUser xLMOUser, string DocTyp, int xFinancialYear,xCurrency xcurrency, ID Atom_Currency_ID, WArea workArea)
        {
            Form pform = Global.f.GetParentForm(this);
            DocE.SetNewDraft(pform,
                            xLMOUser,
                            DocTyp,
                            xFinancialYear,
                            xcurrency,
                            Atom_Currency_ID,
                            workArea,
                            this.SetMode,
                            this.set_InvoiceNumberText
                            );
        }

        private bool SetNewInvoiceDraft(LMOUser xLMOUser,  int FinancialYear, xCurrency xcurrency, ID xAtom_Currency_ID, WArea workArea)
        {
            Form pform = Global.f.GetParentForm(this);
            return DocE.SetNewInvoiceDraft(
                            pform,
                            xLMOUser,
                            FinancialYear,
                            xcurrency,
                            xAtom_Currency_ID,
                            workArea,
                            this.SetMode,
                            this.set_InvoiceNumberText
                            );
        }

        private void get_price_sum()
        {
            DocE.GetPriceSum(this.m_usrc_ShopA1366x768.dt_Item_Price,
                                    this.m_usrc_ShopB1366x768.dt_SelectedShopBItem,
                                    this.btn_Issue_Show,
                                    this.lbl_Sum_ForeColor,
                                    this.lbl_Sum_Text);
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



        private bool IssueDocument()
        {
            //ProgramDiagnostic.Diagnostic.Enabled = true;
            //ProgramDiagnostic.Diagnostic.Init();
            //ProgramDiagnostic.Diagnostic.Clear();
            //ProgramDiagnostic.Diagnostic.Meassure("Before fs.UpdatePriceInDraft", "?");

            if (fs.UpdatePriceInDraft(DocE.DocTyp, DocE.m_ShopABC.m_CurrentDoc.Doc_ID, DocE.GrossSum, DocE.TaxSum.Value, DocE.NetSum))
            {
                if (IsDocInvoice)
                {
                    DocE.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                  
                    ID DocInvoice_ID = null;
                    // save doc Invoice 
                    if (DocE.m_InvoiceData.SaveDocInvoice(ref DocInvoice_ID,Program.CashierActivity,GlobalData.ElectronicDevice_Name, DocE.m_LMOUser.Atom_WorkPeriod_ID))
                    {

                        DocE.m_ShopABC.m_CurrentDoc.Doc_ID = DocInvoice_ID;

                        if (Program.b_FVI_SLO)
                        {

                            if ((DocE.m_InvoiceData.AddOnDI.IsCashPayment && Program.FVI_SLO1.FVI_for_cash_payment)
                                || (DocE.m_InvoiceData.AddOnDI.IsCardPayment && Program.FVI_SLO1.FVI_for_card_payment)
                                || (DocE.m_InvoiceData.AddOnDI.IsPaymentOnBankAccount && Program.FVI_SLO1.FVI_for_payment_on_bank_account)
                                )
                            {
                                UniversalInvoice.Person xInvoiceAuthor = fs.GetInvoiceAuthor(DocE.m_LMOUser.Atom_myOrganisation_Person_ID);
                                this.SendInvoice(DocE.GrossSum, DocE.TaxSum, xInvoiceAuthor);
                            }
                        }

                        // read saved doc Invoice again !
                        if (DocE.m_InvoiceData.Read_DocInvoice())
                        {

                            if (aa_DocInvoiceSaved != null)
                            {
                                aa_DocInvoiceSaved(DocE.m_ShopABC.m_CurrentDoc.Doc_ID);
                            }
                            Printing_DocInvoice();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (IsDocProformaInvoice)
                {
                    ID DocInvoice_ID = null;
                    // save doc Invoice 
                    if (DocE.m_InvoiceData.SaveDocProformaInvoice(ref DocInvoice_ID,GlobalData.ElectronicDevice_Name, DocE.m_LMOUser.Atom_WorkPeriod_ID))
                    {
                        DocE.m_ShopABC.m_CurrentDoc.Doc_ID = DocInvoice_ID;
                        // read saved doc Invoice again !
                        if (DocE.m_InvoiceData.Read_DocInvoice())
                        {

                            if (aa_DocProformaInvoiceSaved != null)
                            {
                                aa_DocProformaInvoiceSaved(DocE.m_ShopABC.m_CurrentDoc.Doc_ID);
                            }

                            Printing_DocInvoice();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }                 
                }
                else
                {
                    LogFile.Error.Show("ERROR:Tangenta:usrc_Invoice:IssueDocument:Unknown doc type!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void SendInvoice(decimal dGrossSum,StaticLib.TaxSum xTaxSum,UniversalInvoice.Person xInvoiceAuthor)
        {
            //if (m_InvoiceData.AddOnDI.m_FURS.FURS_QR_v != null)
            //{
            //m_InvoiceData.AddOnDI.m_FURS.FURS_Image_QRcode = Program.usrc_FVI_SLO1.GetQRImage(m_InvoiceData.AddOnDI.m_FURS.FURS_QR_v.v);
            //    m_InvoiceData.AddOnDI.m_FURS.Set_Invoice_Furs_Token();
            //}
            //else
            //{
                string furs_XML = DocInvoice_AddOn.FURS.Create_furs_InvoiceXML(false,
                                       Properties.Resources.FVI_SLO_Invoice,
                                       Program.FVI_SLO1.FursD_MyOrgTaxID,
                                       Program.FVI_SLO1.FursD_BussinesPremiseID,
                                       GlobalData.ElectronicDevice_Name,
                                       Program.FVI_SLO1.FursD_InvoiceAuthorTaxID,
                                       "", "",
                                       DocE.m_InvoiceData.IssueDate_v,
                                       DocE.m_InvoiceData.NumberInFinancialYear,
                                       dGrossSum,
                                       xTaxSum,
                                       xInvoiceAuthor //ToDo : Get real Invoice Autor here!
                                       );
                Image img_QR = null;
                string furs_UniqeMsgID = null;
                string furs_UniqeInvID = null;
                string furs_BarCodeValue = null;

                FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post eres = Program.FVI_SLO1.Send_SingleInvoice(false, furs_XML, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR);
                switch (eres)
                { 

                case FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK:
                case FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.TIMEOUT:
                    DocE.m_InvoiceData.AddOnDI.m_FURS.FURS_ZOI_v = new string_v(furs_UniqeMsgID);
                    DocE.m_InvoiceData.AddOnDI.m_FURS.FURS_EOR_v = new string_v(furs_UniqeInvID);
                    DocE.m_InvoiceData.AddOnDI.m_FURS.FURS_QR_v = new string_v(furs_BarCodeValue);
                    DocE.m_InvoiceData.AddOnDI.m_FURS.FURS_Image_QRcode = img_QR;
                    DocE.m_InvoiceData.AddOnDI.m_FURS.Write_FURS_Response_Data(DocE.m_InvoiceData.DocInvoice_ID,Program.FVI_SLO1.FursTESTEnvironment);
                    break;

                case FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.ERROR:

                    string xSerialNumber = null;
                    string xSetNumber = null;
                    string xInvoiceNumber = null;
                    Program.FVI_SLO1.Write_SalesBookInvoice(DocE.m_InvoiceData.DocInvoice_ID, DocE.m_InvoiceData.FinancialYear, DocE.m_InvoiceData.NumberInFinancialYear, ref xSerialNumber, ref xSetNumber, ref xInvoiceNumber);
                    ID FVI_SLO_SalesBookInvoice_ID = null;
                    if (TangentaDB.f_FVI_SLO_SalesBookInvoice.Get(DocE.m_InvoiceData.DocInvoice_ID, xSerialNumber, xSetNumber, xInvoiceNumber, ref FVI_SLO_SalesBookInvoice_ID))
                    {
                        MessageBox.Show("Račun je zabeležen v tabeli za pošiljanje računov iz vezane knjige računov! ");

                        //LK SalesBookInvoice  prestavi na gumb
                        //string furs_XML_SB = m_InvoiceData.Create_furs_SalesBookInvoiceXML(Program.usrc_FVI_SLO1.XML_Template_FVI_SLO_SalesBook, Program.usrc_FVI_SLO1.FursD_MyOrgTaxID, Program.usrc_FVI_SLO1.FursD_BussinesPremiseID, xSetNumber, xSerialNumber);
                        //if (Program.usrc_FVI_SLO1.Send_SingleInvoice(furs_XML_SB, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR) == FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK)
                        //{
                        //    m_InvoiceData.FURS_Response_Data = new FURS_Response_data(furs_UniqeMsgID, furs_UniqeInvID, furs_BarCodeValue, img_QR);
                        //    m_InvoiceData.FURS_Response_Data.Image_QRcode = img_QR;
                        //    m_InvoiceData.Write_FURS_Response_Data();
                        //}
                    }
                    break;


            }
            DocE.m_InvoiceData.AddOnDI.m_FURS.Set_Invoice_Furs_Token();
            //}
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
                aa_DocProformaInvoiceSaved(DocE.m_ShopABC.m_CurrentDoc.Doc_ID);
            }
        }


        private void btn_Issue_Click(object sender, EventArgs e)
        {
            Form pform = Global.f.GetParentForm(this);
            DocE.btn_Issue_Click(pform,
                                usrc_AddOn1.Check_DocInvoice_AddOn,
                                usrc_AddOn1.Get_Doc_AddOn,
                                usrc_AddOn1.Check_DocProformaInvoice_AddOn,
                                usrc_AddOn1.Get_Doc_AddOn,
                                this.DoCurrent,
                                Printing_DocInvoice,
                                this.docInvoice_saved,
                                this.docProformaInvoice_saved
                                );
        }

   
        //private InvoiceData Set_AddOn(InvoiceData invoiceData)
        //{
        //    if (IsDocInvoice)
        //    {
        //        invoiceData.AddOnDI = DocE.m_InvoiceData.AddOnDI;
        //        invoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
        //        invoiceData.AddOnDPI = null;
        //        invoiceData.AddOnDI.Get(invoiceData.DocInvoice_ID);
        //    }
        //    else if (IsDocProformaInvoice)
        //    {
        //        invoiceData.AddOnDPI = DocE.m_InvoiceData.AddOnDPI;
        //        invoiceData.AddOnDI = null;
        //        invoiceData.AddOnDPI.Get(invoiceData.DocInvoice_ID);
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:Tangenta:usrc_Invoice:SetAddOn:Unknown doc type!");
        //        invoiceData.AddOnDI = null;
        //        invoiceData.AddOnDPI = null;
        //    }
        //    return invoiceData;
        //}

        private bool Printing_DocInvoice()
        {
            TangentaPrint.Form_PrintDocument template_dlg = new TangentaPrint.Form_PrintDocument(DocE.m_LMOUser.Atom_WorkPeriod_ID, DocE.m_InvoiceData,Properties.Resources.Exit, DocE.door.OpenIfUserIsAdministrator);
            template_dlg.Owner = Global.f.GetParentForm(this);
            if (template_dlg.ShowDialog(this)==DialogResult.OK)
            {
                return true;
            }
            return false;
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

        private void usrc_Customer_Customer_Person_Changed(ID Customer_Person_ID)
        {
            this.Cursor = Cursors.WaitCursor;
            DocE.Customer_Person_Changed(Customer_Person_ID,
                                         usrc_Customer.Show_Customer_Person,
                                         customer_Person_Changed);
            this.Cursor = Cursors.Arrow;
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
            DocE.Storno_CheckedChanged(pform,
                                       chk_Storno.Checked,
                                       txt_Number.Text,
                                       storno_event,
                                       chk_Storno_Check
                                       );
        }




        private void usrc_Customer_Customer_Org_Changed(ID Customer_Org_ID)
        {
            this.Cursor = Cursors.WaitCursor;
            DocE.Customer_Org_Changed(Customer_Org_ID,
                                      usrc_Customer.Show_Customer_Org,
                                      this.customer_Organisation_Changed
                                      );
            this.Cursor = Cursors.Arrow;
        }

        private bool usrc_Customer_aa_Customer_Removed(string xDoxTyp)
        {
            this.Cursor = Cursors.WaitCursor;
            if (DocE.m_ShopABC.m_CurrentDoc.Update_Customer_Remove(xDoxTyp))
            {
                this.Cursor = Cursors.Arrow;
                return true;
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                return false;
            }
        }

        private void btn_Select_Shops_Click(object sender, EventArgs e)
        {
            Form_ShowShops1366x768 frm_sel_shops = new Form_ShowShops1366x768(this, DocE.mSettingsUserValues);
            if (frm_sel_shops.ShowDialog(this)==DialogResult.OK)
            {
                Set_ShowShops(ShopsUse.ShowShops_Get(DocE.mSettingsUserValues));
                if (LayoutChanged!=null)
                {
                    LayoutChanged();
                }
            }
            
        }

        private void btn_MyOrganisation_Click(object sender, EventArgs e)
        {
            NavigationButtons.Navigation nav_EditMyOrganisation_Data = new NavigationButtons.Navigation(null);
            nav_EditMyOrganisation_Data.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            nav_EditMyOrganisation_Data.bDoModal = true;
            EditMyOrganisation_Data(false, nav_EditMyOrganisation_Data);
        }

        private void usrc_Currency1_CurrencyChanged(xCurrency currency, ID xAtom_Currency_ID)
        {
            GlobalData.BaseCurrency = currency;
            DocE.Atom_Currency_ID = xAtom_Currency_ID;
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
    }
}
