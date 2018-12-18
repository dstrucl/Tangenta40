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
using CodeTables;
using TangentaTableClass;
using LanguageControl;
using NavigationButtons;
using DBTypes;
using TangentaDB;
using UniqueControlNames;
using DBConnectionControl40;

namespace PriseLists
{
    public partial class usrc_PriceList_Edit : UserControl
    {
        UniqueControlName uctrln = new UniqueControlName();
        public enum ePriceListMode { SELECT_VALID, SELECT_UNVALID, SELECT_ALL };
        public enum eShopType { ShopB,ShopC};

        public delegate void delegate_Cancel ();
        public event delegate_Cancel Button_Cancel_Click;

        public delegate void delegate_OK();
        public event delegate_OK Button_OK_Click;

        SQLTable tbl_PriceList = null;
        SQLTable tbl_Price_SimpleItem = null;
        SQLTable tbl_Price_Item = null;
        private bool bChanged = false;

        public bool Changed
        {
            get { return bChanged; }
        }

        private eShopType m_eShopType;

        private ePriceListMode PriceListMode = ePriceListMode.SELECT_VALID;

        private Navigation nav = null;

        private bool bEditUndefined = false;
        public usrc_PriceList_Edit()
        {
            InitializeComponent();
            this.rdb_OnlyValid.Text = lng.s_OnlyValidPriceList.s;
            this.rdb_All.Text = lng.s_AllPriceList.s;
            this.rdb_OnlyUnvalid.Text = lng.s_OnlyUnvalid.s;
            rdb_OnlyValid.Checked = true;
            this.usrc_EditTable_PriceList.Title = lng.s_Manage_PriceLists.s;
        }

        public bool Init(SQLTable xtbl_PriceList, bool xbEditUndefined,  eShopType xeShopType,Navigation xnav)
        {
            nav = xnav;
            this.usrc_NavigationButtons1.Init(nav);
            m_eShopType = xeShopType;
            tbl_PriceList = xtbl_PriceList;
            bEditUndefined = xbEditUndefined;
            if (nav!=null)
            {
                if (nav.m_eButtons == Navigation.eButtons.OkCancel)
                {
                    if (m_eShopType == eShopType.ShopB)
                    {
                        usrc_EditTable_Shop_Prices.Title = lng.s_PriceList.s + " " + lng.s_Shop_B.s;
                    }
                    else
                    {
                        usrc_EditTable_Shop_Prices.Title = lng.s_PriceList.s + " " + lng.s_Shop_C.s;
                    }
                }
                else
                {
                    rdb_OnlyValid.Visible = false;
                    rdb_All.Visible = false;
                    rdb_OnlyUnvalid.Visible = false;
                    usrc_EditTable_Shop_Prices.Dispose();
                    usrc_EditTable_Shop_Prices = null;
                    splitContainer1.Panel2Collapsed = true;
                }
            }
            else
            {
                if (m_eShopType == eShopType.ShopB)
                {
                    usrc_EditTable_Shop_Prices.Title = lng.s_PriceList.s + " " + lng.s_Shop_B.s;
                }
                else
                {
                    usrc_EditTable_Shop_Prices.Title = lng.s_PriceList.s + " " + lng.s_Shop_C.s;
                }
            }

            return Init();
            
        }
        private bool Init()
        {
            string selection = @" ID,
                                        PriceList_$_pln_$$Name,
                                        PriceList_$_Cur_$$Abbreviation,
                                        PriceList_$_Cur_$$Name,
                                        PriceList_$$CreationDate,
                                        PriceList_$$Description,
                                        PriceList_$$Valid,
                                        PriceList_$$ValidFrom,
                                        PriceList_$$ValidTo
            ";
            string sWhereCondition = "";
            switch (PriceListMode)
            {
                case ePriceListMode.SELECT_VALID:
                    sWhereCondition = " where PriceList_$$Valid  = 1";
                    break;
                case ePriceListMode.SELECT_UNVALID:
                    sWhereCondition = " where PriceList_$$Valid  = 0";
                    break;
                case ePriceListMode.SELECT_ALL:
                    break;
            }
            bool bRes = usrc_EditTable_PriceList.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_PriceList, selection, "ID asc", bEditUndefined, sWhereCondition, null, false,nav);
            if (bRes)
            {
                if (usrc_EditTable_PriceList.dt_Data.Rows.Count == 0)
                {
                    if (nav.m_eButtons == Navigation.eButtons.PrevNextExit)
                    {
                        this.usrc_EditTable_PriceList.FillInitialDataAndSetInputControls(null);
                        return true;
                    }
                    else
                    {
                        if (usrc_EditTable_Shop_Prices != null)
                        {
                            usrc_EditTable_Shop_Prices.Clear();
                        }
                    }
                }
                this.rdb_OnlyValid.CheckedChanged += new System.EventHandler(this.rdb_OnlyValid_CheckedChanged);
                this.rdb_All.CheckedChanged += new System.EventHandler(this.rdb_All_CheckedChanged);
                this.rdb_OnlyUnvalid.CheckedChanged += new System.EventHandler(this.rdb_OnlyUnvalid_CheckedChanged);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RemoveHandlers()
        {
            this.rdb_OnlyValid.CheckedChanged -= new System.EventHandler(this.rdb_OnlyValid_CheckedChanged);
            this.rdb_All.CheckedChanged -= new System.EventHandler(this.rdb_All_CheckedChanged);
            this.rdb_OnlyUnvalid.CheckedChanged -= new System.EventHandler(this.rdb_OnlyUnvalid_CheckedChanged);
        }
        private void rdb_OnlyValid_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_OnlyValid.Checked)
            {
                RemoveHandlers();
                PriceListMode = usrc_PriceList_Edit.ePriceListMode.SELECT_VALID;
                Init();
            }
        }

        private void rdb_OnlyUnvalid_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_OnlyUnvalid.Checked)
            {
                RemoveHandlers();
                PriceListMode = usrc_PriceList_Edit.ePriceListMode.SELECT_UNVALID;
                Init();
            }
        }

        private void rdb_All_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_All.Checked)
            {
                RemoveHandlers();
                PriceListMode = usrc_PriceList_Edit.ePriceListMode.SELECT_ALL;
                Init();
            }
        }

        private void usrc_EditTable_PriceList_after_InsertInDataBase(SQLTable m_tbl, ID ID, bool bRes)
        {
            // Now create price lists
            if (bRes)
            {
                bChanged = true;
                if (nav.m_eButtons == Navigation.eButtons.OkCancel)
                {
                    SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Taxation)));
                    tbl_Taxation.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                    SelectID_Table_Assistant_Form SelectID_Table_dlg = new SelectID_Table_Assistant_Form(tbl_Taxation, DBSync.DBSync.DB_for_Tangenta.m_DBTables, null);
                    SelectID_Table_dlg.ShowDialog();
                    ID id_Taxation = SelectID_Table_dlg.ID;
                    if (ID.Validate(id_Taxation))
                    {
                        string sql = null;
                        string Err = null;
                        if (m_eShopType == eShopType.ShopB)
                        {

                            sql = @" insert into Price_SimpleItem (SimpleItem_ID,PriceList_ID,Taxation_ID,RetailSimpleItemPrice,Discount) 
                                    select id," + ID.ToString() + "," + id_Taxation.ToString() + ",-1,0 from SimpleItem where ToOffer = 1";
                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref Err))
                            {
                                if (tbl_Price_SimpleItem == null)
                                {
                                    tbl_Price_SimpleItem = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_SimpleItem)));
                                    tbl_Price_SimpleItem.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                                }
                                else
                                {
                                    tbl_Price_SimpleItem.DeleteInputControls();
                                }
                                string where_condition = " where Price_SimpleItem_$_pl_$$ID = " + ID.ToString() + " ";
                                string selection = @" ID,
                                                  Price_SimpleItem_$$RetailSimpleItemPrice,
                                                  Price_SimpleItem_$$Discount,
                                                  Price_SimpleItem_$_si_$$Name,
                                                  Price_SimpleItem_$_si_$_siimg_$$Image_Data,
                                                  Price_SimpleItem_$_tax_$$Name,
                                                  Price_SimpleItem_$_tax_$$Rate,
                                                  Price_SimpleItem_$_pl_$_Cur_$$Symbol,
                                                  Price_SimpleItem_$_pl_$_Cur_$$Abbreviation,
                                                  Price_SimpleItem_$_si_$$Code,
                                                  Price_SimpleItem_$_pl_$_pln_$$Name
                                                  ";
                                if (usrc_EditTable_Shop_Prices != null)
                                {
                                    if (this.usrc_EditTable_Shop_Prices.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Price_SimpleItem, selection, "Price_SimpleItem_$_si_$$Code desc", false, where_condition, null, false,nav))
                                    {
                                    }
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_PriceList_Edit:usrc_EditTable_PriceList_after_InsertInDataBase:Err=" + Err + "\r\nSql=" + sql);
                                return;
                            }
                        }
                        else
                        {
                            sql = @" insert into Price_Item (Item_ID,PriceList_ID,Taxation_ID,RetailPricePerUnit,Discount) 
                                            select id," + ID.ToString() + "," + id_Taxation.ToString() + ",-1,0 from Item where ToOffer = 1";
                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref Err))
                            {
                                if (tbl_Price_Item == null)
                                {
                                    tbl_Price_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_Item)));
                                    tbl_Price_Item.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                                }
                                else
                                {
                                    tbl_Price_Item.DeleteInputControls();
                                }
                                string selection = @" ID,
                                                  Price_Item_$$RetailPricePerUnit,
                                                  Price_Item_$$Discount,
                                                  Price_Item_$_i_$$UniqueName,
                                                  Price_Item_$_i_$_iimg_$$Image_Data,
                                                  Price_Item_$_i_$$Name,
                                                  Price_Item_$_tax_$$Rate,
                                                  Price_Item_$_i_$_exp_$$ExpectedShelfLifeInDays,
                                                  Price_Item_$_i_$_exp_$$SaleBeforeExpiryDateInDays,
                                                  Price_Item_$_pl_$_Cur_$$Symbol,
                                                  Price_Item_$_pl_$_Cur_$$Abbreviation,
                                                  Price_Item_$_i_$$Code,
                                                  Price_Item_$_pl_$_pln_$$Name
                                                  ";
                                string where_condition = " where Price_Item_$_pl_$$ID = " + ID.ToString() + " ";
                                if (usrc_EditTable_Shop_Prices != null)
                                {
                                    if (usrc_EditTable_Shop_Prices.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Price_Item, selection, " Price_Item_$_i_$$Code desc ", false, where_condition, null, false,nav))
                                    {
                                        if (!SetPriceListName(ID, ref Err))
                                        {
                                            LogFile.Error.Show("ERROR:usrc_PriceList_Edit:usrc_EditTable_PriceList_after_InsertInDataBase:Err=" + Err);
                                        }
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_PriceList_Edit:usrc_EditTable_PriceList_after_InsertInDataBase:Err=" + Err + "\r\nSql=" + sql);
                            }
                        }
                    }
                }
            }
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private bool SetPriceListName(ID ID,ref string Err)
        {
            string sql_PriceListName = @" select pln.Name,
                                                 cur.Name as CurrencyName,
                                                 pl.CreationDate 
                                          from PriceList pl
                                          inner join PriceList_Name pln on pln.ID = pl.PriceList_Name_ID
                                          inner join Currency cur on cur.ID = pl.Currency_ID
                                          where pl.ID = " + ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_PriceListName, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    string sPriceListName = "";
                    string sCurrencyName = "";

                    object oPriceListName = dt.Rows[0]["Name"];
                    if (oPriceListName.GetType() == typeof(string))
                    {
                        sPriceListName = (string)oPriceListName;

                    }

                    object oCurrencyName = dt.Rows[0]["CurrencyName"];
                    if (oCurrencyName.GetType() == typeof(string))
                    {
                        sCurrencyName = (string)oCurrencyName;

                    }

                    this.txt_PriceList_Name.Text = sPriceListName + ":" + sCurrencyName;

                    object oCreationDate = dt.Rows[0]["CreationDate"];
                    if (oCreationDate.GetType() == typeof(DateTime))
                    {
                        this.txt_PriceList_Name.Text += "," + oCreationDate.ToString();
                    }
                    return true;
                }
                else
                {
                    Err="ERROR:SetPriceListName:PriceList with ID = "+ ID.ToString()+ " not found!";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void usrc_EditTable_PriceList_SelectedIndexChanged(SQLTable m_tbl, ID ID, int index)
        {
            string Err = null;
            if (SetPriceListName(ID,ref Err))
            {
                string sOrder_by_UndefinedFirst = null;

                string where_condition = null;
                string selection = null;
                if (m_eShopType == eShopType.ShopB)
                {
                    if (usrc_EditTable_Shop_Prices != null)
                    {
                        if (tbl_Price_SimpleItem == null)
                        {
                            tbl_Price_SimpleItem = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_SimpleItem)));
                            tbl_Price_SimpleItem.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                        }
                        else
                        {
                            tbl_Price_SimpleItem.DeleteInputControls();
                        }

                        where_condition = " where Price_SimpleItem_$_pl_$$ID = " + ID.ToString() + " ";

                        selection = @"             Price_SimpleItem_$_si_$$Name,
                                                      Price_SimpleItem_$$RetailSimpleItemPrice,
                                                      Price_SimpleItem_$_si_$_sipg1_$$Name,
                                                      Price_SimpleItem_$_si_$_sipg1_$_sipg2_$$Name,
                                                      Price_SimpleItem_$_si_$_sipg1_$_sipg2_$_sipg3_$$Name,
                                                      Price_SimpleItem_$_si_$_siimg_$$Image_Data,
                                                      Price_SimpleItem_$$Discount,
                                                      Price_SimpleItem_$_tax_$$Name,
                                                      Price_SimpleItem_$_tax_$$Rate,
                                                      Price_SimpleItem_$_pl_$_Cur_$$Symbol,
                                                      Price_SimpleItem_$_pl_$_Cur_$$Abbreviation,
                                                      Price_SimpleItem_$_pl_$_pln_$$Name,
                                                      Price_SimpleItem_$_si_$$Code,
                                                      ID
                                                      ";
                        sOrder_by_UndefinedFirst = "";
                        if (bEditUndefined)
                        {
                            sOrder_by_UndefinedFirst = " Price_SimpleItem_$$RetailSimpleItemPrice asc, ";
                        }
                        else
                        {
                            sOrder_by_UndefinedFirst = " Price_SimpleItem_$_si_$_sipg1_$$Name,Price_SimpleItem_$_si_$_sipg1_$_sipg2_$$Name,Price_SimpleItem_$_si_$_sipg1_$_sipg2_$_sipg3_$$Name, Price_SimpleItem_$$RetailSimpleItemPrice asc, ";
                        }

                        if (usrc_EditTable_Shop_Prices.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Price_SimpleItem, selection, sOrder_by_UndefinedFirst + " Price_SimpleItem_$_si_$$Code desc", false, where_condition, null, false,nav))
                        {

                        }
                    }
                }
                else
                {
                    if (usrc_EditTable_Shop_Prices != null)
                    {
                        if (tbl_Price_Item == null)
                        {
                            tbl_Price_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_Item)));
                            tbl_Price_Item.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                        }
                        else
                        {
                            tbl_Price_Item.DeleteInputControls();
                        }
                        where_condition = " where Price_Item_$_pl_$$ID = " + ID.ToString() + " ";
                        selection = @"                Price_Item_$_i_$$UniqueName,
                                                      Price_Item_$$RetailPricePerUnit,
                                                      Price_Item_$_i_$_ipg1_$$Name,
                                                      Price_Item_$_i_$_ipg1_$_ipg2_$$Name,
                                                      Price_Item_$_i_$_ipg1_$_ipg2_$_ipg3_$$Name,
                                                      Price_Item_$_i_$$Name,
                                                      Price_Item_$_i_$_iimg_$$Image_Data,
                                                      Price_Item_$$Discount,
                                                      Price_Item_$_tax_$$Rate,
                                                      Price_Item_$_i_$_exp_$$ExpectedShelfLifeInDays,
                                                      Price_Item_$_i_$_exp_$$SaleBeforeExpiryDateInDays,
                                                      Price_Item_$_pl_$_Cur_$$Symbol,
                                                      Price_Item_$_pl_$_Cur_$$Abbreviation,
                                                      Price_Item_$_i_$$Code,
                                                      Price_Item_$_pl_$_pln_$$Name,
                                                      ID
                                                      ";
                        sOrder_by_UndefinedFirst = "";
                        if (bEditUndefined)
                        {
                            sOrder_by_UndefinedFirst = " Price_Item_$$RetailPricePerUnit asc, ";
                        }
                        else
                        {
                            sOrder_by_UndefinedFirst = " Price_Item_$_i_$_ipg1_$$Name, Price_Item_$_i_$_ipg1_$_ipg2_$$Name, Price_Item_$_i_$_ipg1_$_ipg2_$_ipg3_$$Name, Price_Item_$$RetailPricePerUnit asc, ";
                        }
                        if (usrc_EditTable_Shop_Prices.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Price_Item, selection, sOrder_by_UndefinedFirst + " Price_Item_$_i_$$Code desc", false, where_condition, null, false,nav))
                        {

                        }
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_PriceList_Edit:usrc_EditTable_PriceList_SelectedIndexChanged:Err=" + Err);
            }
        }

        private void usrc_EditTable_PriceList_before_InsertInDataBase(SQLTable m_tbl, ref bool bCancel)
        {
        }

        private void usrc_EditTable_Shop_Prices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (m_eShopType == eShopType.ShopB)
            {
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                {
                    if (dgv.Columns[e.ColumnIndex].Name.Equals("RetailsSimpleItemPrice"))
                    {
                        if (e.RowIndex >= 0)
                        {
                            object o_RetailsSimpleItemPrice = dgv[e.ColumnIndex, e.RowIndex].Value;
                            if (o_RetailsSimpleItemPrice.GetType() == typeof(decimal))
                            {
                                decimal RetailsSimpleItemPrice = (decimal)o_RetailsSimpleItemPrice;
                                if (RetailsSimpleItemPrice < 0)
                                {
                                    int iCount = dgv.Rows[e.RowIndex].Cells.Count;
                                    int i;
                                    for (i = 0; i < iCount; i++)
                                    {
                                        dgv.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.LightPink;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                {
                    if (dgv.Columns[e.ColumnIndex].Name.Equals("Price_Item_$$RetailPricePerUnit"))
                    {
                        if (e.RowIndex >= 0)
                        {
                            object o_RetailsSimpleItemPrice = dgv[e.ColumnIndex, e.RowIndex].Value;
                            if (o_RetailsSimpleItemPrice.GetType() == typeof(decimal))
                            {
                                decimal RetailsSimpleItemPrice = (decimal)o_RetailsSimpleItemPrice;
                                if (RetailsSimpleItemPrice < 0)
                                {
                                    int iCount = dgv.Rows[e.RowIndex].Cells.Count;
                                    int i;
                                    for (i = 0; i < iCount; i++)
                                    {
                                        dgv.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.LightPink;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private bool Usrc_EditTable_SimpleItem_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID id, ref bool bCancelDialog, ref ltext Instruction)
        {
            if (pSQL_Table.TableName.ToLower().Equals("taxation"))
            {
                if (pSQL_Table.pParentTable!=null)
                {
                    if (pSQL_Table.pParentTable.TableName.ToLower().Equals("price_simpleitem"))
                    {
                        string sql = "select Name from Taxation where id = " + id.ToString();
                        DataTable dt = new DataTable();
                        string Err = null;
                        if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
                        {
                            if (dt.Rows.Count>0)
                            {
                                string staxname = (string)dt.Rows[0]["Name"];
                                List<object> complex_text = new List<object>();
                                complex_text.Add(lng.s_Tax_with_name);
                                complex_text.Add("\""+staxname +"\"");
                                complex_text.Add(lng.s_belongs_to_many_other_trade_items_and_services);
                                complex_text.Add(lng.s_If_you_want_to_change_the_tax_only_to_the_selected_article___);

                                if (Instruction == null)
                                {
                                    Instruction = new ltext(complex_text);
                                }
                                else
                                {
                                    Instruction.complex_text_list =complex_text;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_PriceList_Edit:usrc_EditTable_SimpleItem_RowReferenceFromTable_Check_NoChangeToOther:\r\nsql=" + sql + "\r\nErr=" + Err);
                        }
                        
                    }
                }
                
            }
            bCancelDialog = false;
            return false;
        }


        private void usrc_NavigationButtons1_ButtonPressed(Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {
                case Navigation.eButtons.OkCancel:

                    switch (evt)
                    {
                        case Navigation.eEvent.OK:
                            nav.eExitResult = evt;
                            if (Button_OK_Click != null)
                            {
                                Button_OK_Click();
                            }
                            break;
                        case Navigation.eEvent.CANCEL:
                            nav.eExitResult = evt;
                            if (Button_Cancel_Click != null)
                            {
                                Button_Cancel_Click();
                            }
                            break;
                    }
                    break;
                case Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case Navigation.eEvent.EXIT:
                            nav.eExitResult = evt;
                            if (Button_Cancel_Click != null)
                            {
                                Button_Cancel_Click();
                            }
                            break;
                        case Navigation.eEvent.PREV:
                            nav.eExitResult = evt;
                            if (Button_Cancel_Click != null)
                            {
                                Button_Cancel_Click();
                            }
                            break;
                        case Navigation.eEvent.NEXT:
                            nav.eExitResult = evt;
                            if (usrc_EditTable_PriceList.Changed)
                            {
                                usrc_EditTable_PriceList.Save();
                            }
                            if (Button_OK_Click != null)
                            {
                                Button_OK_Click();
                            }
                            break;
                    }
                    break;
            }
        }

        private void usrc_EditTable_PriceList_FillTable(SQLTable m_tbl)
        {
            string Err = null;
            if (nav.m_eButtons == Navigation.eButtons.PrevNextExit)
            {
                if (m_tbl.TableName.Equals("Currency"))
                {
                    m_tbl.FillDataInputControl(DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con, uctrln, GlobalData.BaseCurrency.ID, true, ref Err);
                }
            }
        }


        private void usrc_EditTable_PriceList_SetInputControlProperties(Column col, object obj)
        {
            if (nav.m_eButtons == Navigation.eButtons.PrevNextExit)
            {
                if (col.ownerTable.TableName.Equals("PriceList_Name"))
                {
                    if (col.Name.Equals("Name"))
                    {
                        col.InputControl.SetValue(lng.PriceList_Name.s);
                    }
                }
                else if (col.ownerTable.TableName.Equals("PriceList"))
                {
                    if (col.Name.Equals("Valid"))
                    {
                        col.InputControl.SetValue(true);
                    }
                }
            }
        }

        private void usrc_EditTable_Shop_Prices_after_UpdateDataBase(SQLTable m_tbl, ID ID, bool bRes)
        {
            bChanged = true;
        }

        private void usrc_EditTable_Shop_Prices_after_InsertInDataBase(SQLTable m_tbl, ID ID, bool bRes)
        {
            bChanged = true;
        }

        private void usrc_EditTable_PriceList_after_UpdateDataBase(SQLTable m_tbl, ID ID, bool bRes)
        {
            bChanged = true;
        }
    }
}
