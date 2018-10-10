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
using PriseLists;

namespace Tangenta
{
    public partial class usrc_DocumentEditor : UserControl
    {
        public DocumentEditor DocE = null;
        private DocumentMan DocM = null;

        public usrc_ShopA m_usrc_ShopA = null;
        public usrc_ShopB m_usrc_ShopB = null;
        public usrc_ShopC m_usrc_ShopC = null;


//        private usrc_DocumentMan m_usrc_DocumentMan = null;

        private NavigationButtons.Navigation nav = null;


        public delegate void delegate_LayoutChanged();
        public event delegate_LayoutChanged LayoutChanged = null;

        public int SplitContainer1_spd
        {
            get
            {
                return splitContainer1.SplitterDistance;
            }
            set
            {
                string Err = null;
                if (!StaticLib.Func.SetSplitContainerValue(splitContainer1, value, ref Err))
                {
                    LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentEditor:SetSplitContainer2 SplitterDistance:Err=" + Err);
                }
            }
        }

        public int SplitContainer2_spd
        {
            get
            {
                return splitContainer2.SplitterDistance;
            }
            set
            {
                string Err = null;
                if (!StaticLib.Func.SetSplitContainerValue(splitContainer2, value, ref Err))
                {
                    LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentEditor:SetSplitContainer2 SplitterDistance:Err=" + Err);
                }
            }
        }

        public int SplitContainer3_spd
        {
            get
            {
                return splitContainer3.SplitterDistance;
            }
            set
            {
                string Err = null;
                if (!StaticLib.Func.SetSplitContainerValue(splitContainer3, value, ref Err))
                {
                    LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentEditor:SetSplitContainer3 SplitterDistance:Err=" + Err);
                }

            }
        }

      

        public bool IsDocInvoice
        {
            get
            { return DocM.DocTyp.Equals(GlobalData.const_DocInvoice); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocM.DocTyp.Equals(GlobalData.const_DocProformaInvoice); }
        }

        public string DocTyp {
            get
            {
                return DocM.DocTyp;
            }
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



        public ID myOrganisation_Person_id
        {
            get
            {
                if (myOrg.m_myOrg_Office!=null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Person != null)
                    {
                        return myOrg.m_myOrg_Office.m_myOrg_Person.ID;
                    }
                }
                return null;
            }
        }


        private bool chk_Storno_CanBe_ManualyChanged = true;

        public int NumberOfShopBGroupLevels
        {
            get
            {
                if (this.m_usrc_ShopB != null)
                {
                    return m_usrc_ShopB.NumberOfGroupLevels;
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
                if (this.m_usrc_ShopC != null)
                {
                    return m_usrc_ShopC.NumberOfGroupLevels;
                }
                else
                {
                    return 0;
                }
            }
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

        private void storno_event(bool b)
        {
            if (Storno != null)
            {
                Storno(b);
            }
        }

        private void storno_check(bool check)
        {
            chk_Storno.Checked = check;
        }

        //    public List<Employee> Employees = new List<Employee>();

        private void New_ShopA()
        {
            if (m_usrc_ShopA==null)
            {
                m_usrc_ShopA = new usrc_ShopA();
            }
            m_usrc_ShopA.Init(DocE.m_ShopABC, DocE.DBtcn);
            m_usrc_ShopA.Dock = DockStyle.Fill;
            m_usrc_ShopA.aa_ItemAdded += M_usrc_ShopA_aa_ItemAdded;
            m_usrc_ShopA.aa_ItemRemoved += M_usrc_ShopA_aa_ItemRemoved;
            m_usrc_ShopA.EditUnits += M_usrc_ShopA_EditUnits;

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

        internal void HideGroupHandlerForm()
        {
            if (m_usrc_ShopC!=null)
            {
                m_usrc_ShopC.HideGroupHandlerForm();
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


        private void New_ShopC()
        {
            if (m_usrc_ShopC == null)
            {
                m_usrc_ShopC = new usrc_ShopC();
                m_usrc_ShopC.DocTyp = DocE.DocTyp;
                m_usrc_ShopC.CheckAccessPriceList += M_usrcCheckPriceListAccess;
                m_usrc_ShopC.CheckAccessStock += M_usrc_ShopC_CheckAccessStock;
                m_usrc_ShopC.CheckIfAdministrator += M_usrc_ShopC_CheckIfAdministrator;
            }
            m_usrc_ShopC.Init(DocE.m_LMOUser.Atom_WorkPeriod_ID, DocE.m_ShopABC, DocE.DBtcn,PropertiesUser.ShopsInUse_Get(DocE.mSettingsUserValues),Properties.Settings.Default.AutomaticSelectionOfItemFromStock,Program.OperationMode.ShopC_ExclusivelySellFromStock);
            m_usrc_ShopC.Dock = DockStyle.Fill;
            m_usrc_ShopC.ItemAdded += usrc_ShopC_ItemAdded;
            m_usrc_ShopC.After_Atom_Item_Remove += usrc_ShopC_After_Atom_Item_Remove;
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
            PropertiesUser.ShowShops_Set(DocE.mSettingsUserValues,"A");
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopA);
        }

        private void Set_ShowShops_B()
        {
            PropertiesUser.ShowShops_Set(DocE.mSettingsUserValues, "B");
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopB);
        }

        private void Set_ShowShops_C()
        {
            PropertiesUser.ShowShops_Set(DocE.mSettingsUserValues, "C");
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopC);
        }


        private void Set_ShowShops_AB()
        {
            PropertiesUser.ShowShops_Set(DocE.mSettingsUserValues, "AB");
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();

            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer3.Panel2Collapsed = true;

            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopA);

            this.splitContainer3.Panel1.Controls.Add(m_usrc_ShopB);
        }


        private void Set_ShowShops_BC()
        {
            PropertiesUser.ShowShops_Set(DocE.mSettingsUserValues, "BC");
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();

            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer3.Panel2Collapsed = true;

            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopB);

            this.splitContainer3.Panel1.Controls.Add(m_usrc_ShopC);
        }

        private void Set_eShopsMode_AC()
        {
            PropertiesUser.ShowShops_Set(DocE.mSettingsUserValues, "AC");
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();

            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer3.Panel2Collapsed = true;

            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopA);

            this.splitContainer3.Panel1.Controls.Add(m_usrc_ShopC);
        }

        private void Set_ShowShops_ABC()
        {
            PropertiesUser.ShowShops_Set(DocE.mSettingsUserValues, "ABC");
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();

            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer3.Panel1Collapsed = false;
            this.splitContainer3.Panel2Collapsed = false;

            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopA);

            this.splitContainer3.Panel1.Controls.Add(m_usrc_ShopB);

            this.splitContainer3.Panel2.Controls.Add(m_usrc_ShopC);
        }

        internal void WizzardShow_ShopsVisible(string xshops_inuse)
        {
            DocE.mSettingsUserValues.eShopsInUse = xshops_inuse;
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

        private void New_ShopB()

        {

            if (m_usrc_ShopB == null)

            {

                m_usrc_ShopB = new usrc_ShopB();

                m_usrc_ShopB.DocTyp = DocE.DocTyp;

                m_usrc_ShopB.CheckAccessPriceList += M_usrcCheckPriceListAccess;

            }

            m_usrc_ShopB.Init(DocE.m_ShopABC, DocE.DBtcn, PropertiesUser.ShopsInUse_Get(DocE.mSettingsUserValues));

            m_usrc_ShopB.Dock = DockStyle.Fill;

            m_usrc_ShopB.aa_ExtraDiscount += usrc_ShopB_ExtraDiscount;

            m_usrc_ShopB.aa_ItemAdded += usrc_ShopB_ItemAdded;

            m_usrc_ShopB.aa_ItemRemoved += usrc_ShopB_ItemRemoved;

            m_usrc_ShopB.aa_ItemUpdated += usrc_ShopB_ItemUpdated;

        }


        internal void Set_ShowShops(string eShopsShow)
        {
            if (DocE.mSettingsUserValues.eShopsInUse.Length == 1)
            {
                eShopsShow = DocE.mSettingsUserValues.eShopsInUse;
 //               this.btn_Show_Shops.Visible = false;
            }
            else
            {
                this.btn_Show_Shops.Visible = true;
            }

            if (DocE.mSettingsUserValues.eShopsInUse.Length == 2)
            {
                if (!DocE.mSettingsUserValues.eShopsInUse.Contains(eShopsShow))
                {
                    eShopsShow = DocE.mSettingsUserValues.eShopsInUse;
                }
            }


            if (m_usrc_ShopA==null)
            {
                New_ShopA();
            }

            if (m_usrc_ShopB == null)
            {
                New_ShopB();
            }
            
            if (m_usrc_ShopC == null)
            {
                New_ShopC();
            }

            if (eShopsShow.Equals("A"))
            {
                Set_ShowShops_A();
            }
            else if (eShopsShow.Equals("B"))
            {
                Set_ShowShops_B();
                //this.btn_Show_Shops.Visible = false;
            }
            else if (eShopsShow.Equals("C"))
            {
                Set_ShowShops_C();
                //this.btn_Show_Shops.Visible = false;
            }
            else if (eShopsShow.Equals("AB"))
            {
                Set_ShowShops_AB();
            }
            else if (eShopsShow.Equals("BC"))
            {
                Set_ShowShops_BC();
            }
            else if (eShopsShow.Equals("AC"))
            {
                Set_eShopsMode_AC();
            }
            else if (eShopsShow.Equals("ABC"))
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
                if (m_usrc_ShopB != null)
                {
                    return m_usrc_ShopB.usrc_PriceList1.ID;
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
                if (m_usrc_ShopC != null)
                {
                    return m_usrc_ShopC.usrc_PriceList1.ID;
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
            get { return DocE.mSettingsUserValues.eShowShops.Contains("A"); }
        }
        public bool ShopB_DefaultVisible
        {
            get { return DocE.mSettingsUserValues.eShowShops.Contains("B"); }
        }

        internal void SetSplitControlsSpliterDistance(SettingsUserValues xSettingsUserValues)
        {
            if (xSettingsUserValues.DocumentEditor_SplitControl2_spliterdistance>0)
            {
                this.SplitContainer2_spd = xSettingsUserValues.DocumentEditor_SplitControl2_spliterdistance;
            }
            if (xSettingsUserValues.DocumentEditor_SplitControl1_spliterdistance > 0)
            {
                this.SplitContainer1_spd = xSettingsUserValues.DocumentEditor_SplitControl1_spliterdistance;
            }
            if (xSettingsUserValues.DocumentEditor_SplitControl3_spliterdistance > 0)
            {
                this.SplitContainer3_spd = xSettingsUserValues.DocumentEditor_SplitControl3_spliterdistance;
            }
            if (m_usrc_ShopA != null)
            {
                if (xSettingsUserValues.ShopA_SplitControl1_spliterdistance > 0)
                {
                    m_usrc_ShopA.SplitContainer1_spd = xSettingsUserValues.ShopA_SplitControl1_spliterdistance;
                }

                if (xSettingsUserValues.ShopA_Editor_SplitControl1_spliterdistance > 0)
                {
                    m_usrc_ShopA.Editor_SplitContainer1_spd = xSettingsUserValues.ShopA_Editor_SplitControl1_spliterdistance;
                }

                if (xSettingsUserValues.ShopA_Editor_SplitControl2_spliterdistance > 0)
                {
                    m_usrc_ShopA.Editor_SplitContainer2_spd = xSettingsUserValues.ShopA_Editor_SplitControl2_spliterdistance;
                }
            }

            if (m_usrc_ShopB!=null)
            {
                if (xSettingsUserValues.ShopB_SplitControl2_spliterdistance > 0)
                {
                    m_usrc_ShopB.SplitContainer2_spd = xSettingsUserValues.ShopB_SplitControl2_spliterdistance;
                }
                if (xSettingsUserValues.ShopB_SplitControl1_spliterdistance > 0)
                {
                    m_usrc_ShopB.SplitContainer1_spd = xSettingsUserValues.ShopB_SplitControl1_spliterdistance;
                }
            }

            if (m_usrc_ShopC != null)
            {
                if (xSettingsUserValues.ShopC_SplitControl1_spliterdistance > 0)
                {
                    m_usrc_ShopC.SplitContainer1_spd = xSettingsUserValues.ShopC_SplitControl1_spliterdistance;
                }
                if (xSettingsUserValues.ShopC_SplitControl2_spliterdistance > 0)
                {
                    m_usrc_ShopC.SplitContainer2_spd = xSettingsUserValues.ShopC_SplitControl2_spliterdistance;
                }
            }
        }


        internal void SaveSplitControlsSpliterDistance(SettingsUserValues xSettingsUserValues)
        {
            if (this.SplitContainer2_spd > 0)
            {
                 xSettingsUserValues.DocumentEditor_SplitControl2_spliterdistance = this.SplitContainer2_spd;
            }
            if (this.SplitContainer1_spd > 0)
            {
                 xSettingsUserValues.DocumentEditor_SplitControl1_spliterdistance = this.SplitContainer1_spd;
            }
            if (this.SplitContainer3_spd > 0)
            {
                 xSettingsUserValues.DocumentEditor_SplitControl3_spliterdistance = this.SplitContainer3_spd;
            }

            if (m_usrc_ShopA != null)
            {
                if (m_usrc_ShopA.SplitContainer1_spd > 0)
                {
                    xSettingsUserValues.ShopA_SplitControl1_spliterdistance = m_usrc_ShopA.SplitContainer1_spd;
                }
                if (m_usrc_ShopA.Editor_SplitContainer1_spd > 0)
                {
                    xSettingsUserValues.ShopA_Editor_SplitControl1_spliterdistance = m_usrc_ShopA.Editor_SplitContainer1_spd;
                }
                if (m_usrc_ShopA.Editor_SplitContainer2_spd > 0)
                {
                    xSettingsUserValues.ShopA_Editor_SplitControl2_spliterdistance = m_usrc_ShopA.Editor_SplitContainer2_spd;
                }
            }

            if (m_usrc_ShopB != null)
            {
                if (m_usrc_ShopB.SplitContainer1_spd > 0)
                {
                    xSettingsUserValues.ShopB_SplitControl1_spliterdistance = m_usrc_ShopB.SplitContainer1_spd;
                }
                if (m_usrc_ShopB.SplitContainer2_spd > 0)
                {
                     xSettingsUserValues.ShopB_SplitControl2_spliterdistance = m_usrc_ShopB.SplitContainer2_spd;
                }
            }

            if (m_usrc_ShopC != null)
            {
                if (m_usrc_ShopC.SplitContainer2_spd > 0)
                {
                    xSettingsUserValues.ShopC_SplitControl2_spliterdistance = m_usrc_ShopC.SplitContainer2_spd;
                }
                if (m_usrc_ShopC.SplitContainer1_spd > 0)
                {
                    xSettingsUserValues.ShopC_SplitControl1_spliterdistance = m_usrc_ShopC.SplitContainer1_spd;
                }
            }
        }


        public bool ShopC_DefaultVisible
        {
            get { return DocE.mSettingsUserValues.eShowShops.Contains("Ç"); }
        }

        public bool HeadVisible
        {
            get {
                 return this.chk_Head.Checked;
                }
        }

        public usrc_DocumentEditor()
        {
            InitializeComponent();
            usrc_AddOn1.Init(this);
            lng.s_Show_Shops.Text(btn_Show_Shops);
            lng.s_Issuer.Text(lbl_MyOrganisation);
            lng.s_Number.Text(lbl_Number);
            //btn_BuyerSelect.Text = lng.s_BuyerSelect.s;
            lng.s_Issue.Text(btn_Issue);
            lng.s_chk_Storno.Text(chk_Storno);

            lng.s_Shop_AB = new ltext(lng.s_Shop_A.sText(0) + " && " + lng.s_Shop_B.sText(0), lng.s_Shop_A.sText(1) + " && " + lng.s_Shop_B.sText(1));
            lng.s_Shop_BC = new ltext(lng.s_Shop_B.sText(0) + " && " + lng.s_Shop_C.sText(0), lng.s_Shop_B.sText(1) + " && " + lng.s_Shop_C.sText(1));
            lng.s_Shop_AC = new ltext(lng.s_Shop_A.sText(0) + " && " + lng.s_Shop_C.sText(0), lng.s_Shop_A.sText(1) + " && " + lng.s_Shop_C.sText(1));
            lng.s_Shop_ABC = new ltext(lng.s_Shop_A.sText(0) + " && " + lng.s_Shop_B.sText(0) + " && " + lng.s_Shop_C.sText(0), lng.s_Shop_A.sText(1) + " && " + lng.s_Shop_B.sText(1) + " && " + lng.s_Shop_C.sText(1));

            lng.s_MyOrganisation.Text(lbl_MyOrganisation);
            lng.s_Total.Text(this.lbl_Sum);

        }

        internal void SetMode(DocumentEditor.emode mode)
        {
            DocE.m_mode = mode;
            if (mode == DocumentEditor.emode.edit_eDocumentType)
            {
                this.m_usrc_ShopA.SetMode(usrc_ShopA.eMode.EDIT);
                this.m_usrc_ShopB.SetMode(usrc_ShopB.eMode.EDIT);
                this.m_usrc_ShopC.SetMode(usrc_ShopC.eMode.EDIT);
            }
            else
            {
                this.m_usrc_ShopA.SetMode(usrc_ShopA.eMode.VIEW);
                this.m_usrc_ShopB.SetMode(usrc_ShopB.eMode.VIEW);
                this.m_usrc_ShopC.SetMode(usrc_ShopC.eMode.VIEW);
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
            this.splitContainer1.Enabled = b;
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


        public bool Initialise(DocumentMan xDocumentMan, LoginControl.LMOUser xLMOUser)
        {
            DocM = xDocumentMan;
            DocE = DocM.DocE;
            DocE.m_mode = DocumentEditor.emode.view_eDocumentType;
            DocE.mSettingsUserValues = ((SettingsUser)xLMOUser.oSettings).mSettingsUserValues;
            DocE.m_LMOUser = xLMOUser;
            DocE.door = new Door(DocE.m_LMOUser);
            lng.s_Head.Text(chk_Head);
            chk_Head.Checked = DocE.mSettingsUserValues.InvoiceHeaderChecked;
            chk_Head.CheckedChanged += chk_Head_CheckedChanged;
            splitContainer2.Panel1Collapsed = !chk_Head.Checked;
            SetOperationMode();
            return true;
        }

        private void SetOperationMode()
        {
            if (Program.OperationMode.MultiUser)
            {
                txt_Issuer.Visible = false;
                lbl_Issuer.Visible = false;
            }
            else 
            {
                txt_Issuer.Visible = true;
                lbl_Issuer.Visible = true;
            }

        }

        private bool m_usrc_ShopB_usrc_PriceList1_Init(ID Currency_ID, usrc_PriceList_Edit.eShopType xeShopType, string ShopsInUse, ref ID price_list_ID, ref string Err)
        {
            return m_usrc_ShopB.usrc_PriceList1.Init(Currency_ID, xeShopType, ShopsInUse, ref price_list_ID, ref Err);
        }

        private bool m_usrc_ShopC_usrc_PriceList1_Init(ID Currency_ID, usrc_PriceList_Edit.eShopType xeShopType, string ShopsInUse, ref ID price_list_ID, ref string Err)
        {
            return m_usrc_ShopC.usrc_PriceList1.Init(Currency_ID, xeShopType, ShopsInUse, ref price_list_ID, ref Err);
        }

        public bool m_usrc_ShopB_Get_Price_ShopBItem_Data(ref int iCount_Price_ShopBItem_Data, ID PriceList_id)
        {
            return m_usrc_ShopB.Get_Price_ShopBItem_Data(ref iCount_Price_ShopBItem_Data, PriceList_id);
        }

        public void m_usrc_ShopB_Set_dgv_SelectedShopB_Items()
        {
            m_usrc_ShopB.Set_dgv_SelectedShopB_Items();
        }

        public bool m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data(ID xPriceList_ID)
        {
            return m_usrc_ShopC.usrc_ItemList.Get_Price_Item_Stock_Data(xPriceList_ID);
        }
        
        public bool Init(ID Document_ID)
        {
            Form pform = Global.f.GetParentForm(this);
            ID m_usrc_ShopB_usrc_PriceList1_ID = null;
            ID m_usrc_ShopC_usrc_PriceList1_ID = null;
            if (DocE.Init(pform,
                            Document_ID,
                            ref m_usrc_ShopB_usrc_PriceList1_ID,
                            ref m_usrc_ShopC_usrc_PriceList1_ID,
                            this.Set_ShowShops,
                            m_usrc_ShopB_usrc_PriceList1_Init,
                            m_usrc_ShopC_usrc_PriceList1_Init,
                            this.usrc_PriceList_Ask_To_Update,
                            m_usrc_ShopB_Get_Price_ShopBItem_Data,
                            this.DoCurrent,
                            m_usrc_ShopB_Set_dgv_SelectedShopB_Items,
                            m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data
                            ))
            {
                this.usrc_Customer.aa_Customer_Person_Changed += new Tangenta.usrc_Customer.delegate_Customer_Person_Changed(this.usrc_Customer_Customer_Person_Changed);
                this.usrc_Customer.aa_Customer_Org_Changed += new Tangenta.usrc_Customer.delegate_Customer_Org_Changed(this.usrc_Customer_Customer_Org_Changed);
                this.usrc_Customer.aa_Customer_Removed += new Tangenta.usrc_Customer.delegate_Customer_Removed(this.usrc_Customer_aa_Customer_Removed);
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void SetColor()
        {
            this.BackColor = Colors.m_usrc_DocumentEditor.BackColor;
            this.ForeColor = Colors.m_usrc_DocumentEditor.ForeColor;
            this.splitContainer2.Panel1.BackColor = Colors.HeadColor.BackColor;
            this.splitContainer2.Panel1.ForeColor = Colors.HeadColor.ForeColor;

            if (m_usrc_ShopA!=null)
            {
                m_usrc_ShopA.SetColor();
            }
            if (m_usrc_ShopB != null)
            {
                m_usrc_ShopB.SetColor();
            }
            if (m_usrc_ShopC != null)
            {
                m_usrc_ShopC.SetColor();
            }
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

        private void set_CustomerText(string s)
        {
            usrc_Customer.Text = s;
        }

        private void set_InvoiceNumberText(string s)
        {
            this.txt_Number.Text = s;
        }


        public bool DoCurrent(ID xID)
        {
            return DocE.DoCurrent(xID,
                                    this.m_usrc_ShopB.SetDraftButtons,
                                    this.m_usrc_ShopB.SetViewButtons,
                                    this.usrc_Customer.Show_Customer,
                                    this.set_CustomerText,
                                    this.usrc_AddOn1.Show,
                                    this.AddHandler,
                                    this.RemoveHandler,
                                    this.set_InvoiceNumberText,
                                    this.SetMode,
                                    this.m_usrc_ShopB,
                                    this.m_usrc_ShopB.SetCurrentInvoice_SelectedShopB_Items,
                                    this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems,
                                    this.chk_Storno_Show,
                                    this.chk_Storno_Check,
                                    this.m_usrc_ShopC.Reset,
                                    this.m_usrc_ShopC.Clear,
                                    this.m_usrc_ShopA.dt_Item_Price,
                                    this.m_usrc_ShopB.dt_SelectedShopBItem,
                                    this.btn_Issue_Show,
                                    this.lbl_Sum_ForeColor,
                                    this.lbl_Sum_Text
                                    );
        }

        private void chk_Head_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Head.Checked)
            {
                splitContainer2.Panel1Collapsed = false;
            }
            else
            {
                splitContainer2.Panel1Collapsed = true;
            }

            ((SettingsUser)DocE.m_LMOUser.oSettings).mSettingsUserValues.InvoiceHeaderChecked = chk_Head.Checked;
            Properties.Settings.Default.Save();
        }


        private void AddHandler()
        {
            if (!EventsActive)
            {
                EventsActive = true;
                if (this.m_usrc_ShopB!=null)
                {
                    this.m_usrc_ShopB.aa_ItemAdded += new usrc_ShopB.delegate_ItemAdded(usrc_ShopB_ItemAdded);
                    this.m_usrc_ShopB.aa_ItemRemoved += new usrc_ShopB.delegate_ItemRemoved(usrc_ShopB_ItemRemoved);
                    this.m_usrc_ShopB.aa_ItemUpdated += new usrc_ShopB.delegate_ItemUpdated(usrc_ShopB_ItemUpdated);
                    this.m_usrc_ShopB.aa_ExtraDiscount += new usrc_ShopB.delegate_ExtraDiscount(usrc_ShopB_ExtraDiscount);
                }
            }
        }

        private void RemoveHandler()
        {
            if (EventsActive)
            {
                EventsActive = false;
                if (m_usrc_ShopB != null)
                {
                    this.m_usrc_ShopB.aa_ItemAdded -= new usrc_ShopB.delegate_ItemAdded(usrc_ShopB_ItemAdded);
                    this.m_usrc_ShopB.aa_ItemRemoved -= new usrc_ShopB.delegate_ItemRemoved(usrc_ShopB_ItemRemoved);
                    this.m_usrc_ShopB.aa_ItemUpdated -= new usrc_ShopB.delegate_ItemUpdated(usrc_ShopB_ItemUpdated);
                    this.m_usrc_ShopB.aa_ExtraDiscount -= new usrc_ShopB.delegate_ExtraDiscount(usrc_ShopB_ExtraDiscount);
                }
            }
        }


        private void usrc_PriceList_Ask_To_Update(char chShop, DataTable dt_ShopB_Item_NotIn_PriceList)
        {
            if (PriseLists.usrc_PriceList.Ask_To_Update(chShop, dt_ShopB_Item_NotIn_PriceList, this))
            {
                if (f_PriceList.Insert_ShopB_Items_in_PriceList(dt_ShopB_Item_NotIn_PriceList, this))
                {
                    bool bPriceListChanged = false;
                    this.m_usrc_ShopB.usrc_PriceList1.PriceList_Edit(true, ref bPriceListChanged);
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

        private void Set_InvoiceNumber_Text(string s)
        {
            this.txt_Number.Text = s;
        }


        private void get_price_sum()
        {
            DocE.GetPriceSum(this.m_usrc_ShopA.dt_Item_Price,
                                    this.m_usrc_ShopB.dt_SelectedShopBItem,
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

        private void usrc_Customer_Customer_Person_Changed(ID Customer_Person_ID)
        {
            this.Cursor = Cursors.WaitCursor;
            DocE.Customer_Person_Changed(Customer_Person_ID,
                                         usrc_Customer.Show_Customer_Person,
                                         customer_Person_Changed);
            this.Cursor = Cursors.Arrow;
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
            Form_ShowShops frm_sel_shops = new Form_ShowShops(this, DocE.mSettingsUserValues);
            if (frm_sel_shops.ShowDialog(this)==DialogResult.OK)
            {
                Set_ShowShops(DocE.mSettingsUserValues.eShowShops);
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
    }
}
