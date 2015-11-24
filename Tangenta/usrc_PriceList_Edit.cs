using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLTableControl;
using BlagajnaTableClass;
using LanguageControl;

namespace Tangenta
{
    public partial class usrc_PriceList_Edit : UserControl
    {
        public enum ePriceListMode { SELECT_VALID, SELECT_UNVALID, SELECT_ALL };

        public delegate void delegate_Cancel ();
        public event delegate_Cancel Button_Cancel_Click;

        public delegate void delegate_OK();
        public event delegate_OK Button_OK_Click;

        SQLTable tbl_PriceList = null;
        SQLTable tbl_Price_SimpleItem = null;
        SQLTable tbl_Price_Item = null;

        private ePriceListMode PriceListMode = ePriceListMode.SELECT_VALID;


        private bool bEditUndefined = false;
        public usrc_PriceList_Edit()
        {
            InitializeComponent();
            this.rdb_OnlyValid.Text = lngRPM.s_OnlyValidPriceList.s;
            this.rdb_All.Text = lngRPM.s_AllPriceList.s;
            this.rdb_OnlyUnvalid.Text = lngRPM.s_OnlyUnvalid.s;
            rdb_OnlyValid.Checked = true;
            this.usrc_EditTable_PriceList.Title = lngRPM.s_Manage_PriceLists.s;
            this.usrc_EditTable_SimpleItem.Title = lngRPM.s_PriceList_SimpleItems.s;
            this.usrc_EditTable_Item.Title = lngRPM.s_PriceList_Items.s;
        }

        public bool Init(SQLTable xtbl_PriceList, bool xbEditUndefined)
        {
            tbl_PriceList = xtbl_PriceList;
            bEditUndefined = xbEditUndefined;
            return Init();
            
        }
        private bool Init()
        {
            string selection = @" ID,
                                  PriceList_$$Name,
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
            bool bRes = usrc_EditTable_PriceList.Init(DBSync.DBSync.DB_for_Blagajna.m_DBTables, tbl_PriceList, selection, "ID asc", bEditUndefined, sWhereCondition, null, false);
            if (bRes)
            {
                if (usrc_EditTable_PriceList.dt_Data.Rows.Count == 0)
                {
                    usrc_EditTable_SimpleItem.Clear();
                    usrc_EditTable_Item.Clear();
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
        private void rdb_OnlyValid_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_OnlyValid.Checked)
            {
                PriceListMode = usrc_PriceList_Edit.ePriceListMode.SELECT_VALID;
                Init();
            }
        }

        private void rdb_OnlyUnvalid_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_OnlyUnvalid.Checked)
            {
                PriceListMode = usrc_PriceList_Edit.ePriceListMode.SELECT_UNVALID;
                Init();
            }
        }

        private void rdb_All_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_All.Checked)
            {
                PriceListMode = usrc_PriceList_Edit.ePriceListMode.SELECT_ALL;
                Init();
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Button_Cancel_Click != null)
            {
                Button_Cancel_Click();
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (Button_OK_Click != null)
            {
                Button_OK_Click();
            }
        }

        private void usrc_EditTable_PriceList_after_InsertInDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            // Now create price lists
            if (bRes)
            {
                SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Taxation)));
                tbl_Taxation.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                SelectID_Table_Assistant_Form  SelectID_Table_dlg = new SelectID_Table_Assistant_Form(tbl_Taxation,DBSync.DBSync.DB_for_Blagajna.m_DBTables,null);
                SelectID_Table_dlg.ShowDialog();
                long id_Taxation = SelectID_Table_dlg.ID;
                if (id_Taxation>=0)
                {
                    string sql = @" insert into Price_SimpleItem (SimpleItem_ID,PriceList_ID,Taxation_ID,RetailSimpleItemPrice,Discount) 
                                    select id," + ID.ToString() + "," + id_Taxation.ToString() + ",-1,0 from SimpleItem where ToOffer = 1";
                    object ores = null;
                    string Err = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                    {
                        if (tbl_Price_SimpleItem==null)
                        {
                            tbl_Price_SimpleItem = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Price_SimpleItem)));
                            tbl_Price_SimpleItem.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
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
                                              Price_SimpleItem_$_pl_$$Name
                                              ";
                        if (usrc_EditTable_SimpleItem.Init(DBSync.DBSync.DB_for_Blagajna.m_DBTables, tbl_Price_SimpleItem, selection, "Price_SimpleItem_$_si_$$Code desc", false, where_condition, null, false))
                        {
                            sql = @" insert into Price_Item (Item_ID,PriceList_ID,Taxation_ID,RetailPricePerUnit,Discount) 
                                        select id," + ID.ToString() + "," + id_Taxation.ToString() + ",-1,0 from Item where ToOffer = 1";
                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                            {
                                if (tbl_Price_Item==null)
                                { 
                                    tbl_Price_Item = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Price_Item)));
                                    tbl_Price_Item.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                                }
                                else
                                {
                                    tbl_Price_Item.DeleteInputControls();
                                }
                                selection = @" ID,
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
                                              Price_Item_$_pl_$$Name
                                              ";
                                where_condition = " where Price_Item_$_pl_$$ID = " + ID.ToString() + " ";
                                if (usrc_EditTable_Item.Init(DBSync.DBSync.DB_for_Blagajna.m_DBTables, tbl_Price_Item, selection, " Price_Item_$_i_$$Code desc ", false, where_condition, null, false))
                                {
                                    if (!SetPriceListName(ID, ref Err))
                                    {
                                        LogFile.Error.Show("ERROR:usrc_PriceList_Edit:usrc_EditTable_PriceList_after_InsertInDataBase:Err=" + Err);
                                    }
                                    return; 
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_PriceList_Edit:usrc_EditTable_PriceList_after_InsertInDataBase:Err=" + Err + "\r\nSql=" + sql);
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_PriceList_Edit:usrc_EditTable_PriceList_after_InsertInDataBase:Err=" + Err + "\r\nSql=" + sql);
                        return;
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

        private void chk_View_SimpleItems_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_View_SimpleItems.Checked)
            {
                splitContainer2.Panel1Collapsed = false;
            }
            else
            {
                splitContainer2.Panel1Collapsed = true;
            }
        }

        private void chk_Items_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Items.Checked)
            {
                this.splitContainer2.Panel2Collapsed = false;
            }
            else
            {
                this.splitContainer2.Panel2Collapsed = true;
            }
        }

        private bool SetPriceListName(long ID,ref string Err)
        {
            string sql_PriceListName = " select Name,CreationDate from PriceList where ID = " + ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_PriceListName, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    object oName = dt.Rows[0]["Name"];
                    if (oName.GetType() == typeof(string))
                    {
                        this.txt_PriceList_Name.Text = (string)oName;
                    }
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

        private void usrc_EditTable_PriceList_SelectedIndexChanged(SQLTable m_tbl, long ID, int index)
        {
            string Err = null;
            if (SetPriceListName(ID,ref Err))
            {
                string sOrder_by_UndefinedFirst = null;
                if (tbl_Price_SimpleItem == null)
                {
                    tbl_Price_SimpleItem = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Price_SimpleItem)));
                    tbl_Price_SimpleItem.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                }
                else
                {
                    tbl_Price_SimpleItem.DeleteInputControls();
                }
                string where_condition = " where Price_SimpleItem_$_pl_$$ID = " + ID.ToString() + " ";
                /*
                CREATE VIEW Price_SimpleItem_VIEW AS
SELECT
  Price_SimpleItem.ID,
  Price_SimpleItem.RetailSimpleItemPrice AS Price_SimpleItem_$$RetailSimpleItemPrice,
  Price_SimpleItem.Discount AS Price_SimpleItem_$$Discount,
Price_SimpleItem_$_tax.ID AS Price_SimpleItem_$_tax_$$ID,
Price_SimpleItem_$_tax.Name AS Price_SimpleItem_$_tax_$$Name,
Price_SimpleItem_$_tax.Rate AS Price_SimpleItem_$_tax_$$Rate,
Price_SimpleItem_$_si.ID AS Price_SimpleItem_$_si_$$ID,
Price_SimpleItem_$_si.Name AS Price_SimpleItem_$_si_$$Name,
Price_SimpleItem_$_si.Abbreviation AS Price_SimpleItem_$_si_$$Abbreviation,
Price_SimpleItem_$_si.ToOffer AS Price_SimpleItem_$_si_$$ToOffer,
Price_SimpleItem_$_si_$_siimg.ID AS Price_SimpleItem_$_si_$_siimg_$$ID,
Price_SimpleItem_$_si_$_siimg.Image_Hash AS Price_SimpleItem_$_si_$_siimg_$$Image_Hash,
Price_SimpleItem_$_si_$_siimg.Image_Data AS Price_SimpleItem_$_si_$_siimg_$$Image_Data,
Price_SimpleItem_$_si.Code AS Price_SimpleItem_$_si_$$Code,
Price_SimpleItem_$_si_$_sipg1.ID AS Price_SimpleItem_$_si_$_sipg1_$$ID,
Price_SimpleItem_$_si_$_sipg1.Name AS Price_SimpleItem_$_si_$_sipg1_$$Name,
Price_SimpleItem_$_si_$_sipg1_$_sipg2.ID AS Price_SimpleItem_$_si_$_sipg1_$_sipg2_$$ID,
Price_SimpleItem_$_si_$_sipg1_$_sipg2.Name AS Price_SimpleItem_$_si_$_sipg1_$_sipg2_$$Name,
Price_SimpleItem_$_si_$_sipg1_$_sipg2_$_sipg3.ID AS Price_SimpleItem_$_si_$_sipg1_$_sipg2_$_sipg3_$$ID,
Price_SimpleItem_$_si_$_sipg1_$_sipg2_$_sipg3.Name AS Price_SimpleItem_$_si_$_sipg1_$_sipg2_$_sipg3_$$Name,
Price_SimpleItem_$_pl.ID AS Price_SimpleItem_$_pl_$$ID,
Price_SimpleItem_$_pl.Name AS Price_SimpleItem_$_pl_$$Name,
Price_SimpleItem_$_pl.Valid AS Price_SimpleItem_$_pl_$$Valid,
Price_SimpleItem_$_pl_$_Cur.ID AS Price_SimpleItem_$_pl_$_Cur_$$ID,
Price_SimpleItem_$_pl_$_Cur.Abbreviation AS Price_SimpleItem_$_pl_$_Cur_$$Abbreviation,
Price_SimpleItem_$_pl_$_Cur.Name AS Price_SimpleItem_$_pl_$_Cur_$$Name,
Price_SimpleItem_$_pl_$_Cur.Symbol AS Price_SimpleItem_$_pl_$_Cur_$$Symbol,
Price_SimpleItem_$_pl_$_Cur.CurrencyCode AS Price_SimpleItem_$_pl_$_Cur_$$CurrencyCode,
Price_SimpleItem_$_pl_$_Cur.DecimalPlaces AS Price_SimpleItem_$_pl_$_Cur_$$DecimalPlaces,
Price_SimpleItem_$_pl.ValidFrom AS Price_SimpleItem_$_pl_$$ValidFrom,
Price_SimpleItem_$_pl.ValidTo AS Price_SimpleItem_$_pl_$$ValidTo,
Price_SimpleItem_$_pl.CreationDate AS Price_SimpleItem_$_pl_$$CreationDate,
Price_SimpleItem_$_pl.Description AS Price_SimpleItem_$_pl_$$Description
FROM Price_SimpleItem
INNER JOIN Taxation Price_SimpleItem_$_tax ON Price_SimpleItem.Taxation_ID = Price_SimpleItem_$_tax.ID
INNER JOIN SimpleItem Price_SimpleItem_$_si ON Price_SimpleItem.SimpleItem_ID = Price_SimpleItem_$_si.ID
LEFT JOIN SimpleItem_Image Price_SimpleItem_$_si_$_siimg ON Price_SimpleItem_$_si.SimpleItem_Image_ID = Price_SimpleItem_$_si_$_siimg.ID
LEFT JOIN SimpleItem_ParentGroup1 Price_SimpleItem_$_si_$_sipg1 ON Price_SimpleItem_$_si.SimpleItem_ParentGroup1_ID = Price_SimpleItem_$_si_$_sipg1.ID
LEFT JOIN SimpleItem_ParentGroup2 Price_SimpleItem_$_si_$_sipg1_$_sipg2 ON Price_SimpleItem_$_si_$_sipg1.SimpleItem_ParentGroup2_ID = Price_SimpleItem_$_si_$_sipg1_$_sipg2.ID
LEFT JOIN SimpleItem_ParentGroup3 Price_SimpleItem_$_si_$_sipg1_$_sipg2_$_sipg3 ON Price_SimpleItem_$_si_$_sipg1_$_sipg2.SimpleItem_ParentGroup3_ID = Price_SimpleItem_$_si_$_sipg1_$_sipg2_$_sipg3.ID
INNER JOIN PriceList Price_SimpleItem_$_pl ON Price_SimpleItem.PriceList_ID = Price_SimpleItem_$_pl.ID
INNER JOIN Currency Price_SimpleItem_$_pl_$_Cur ON Price_SimpleItem_$_pl.Currency_ID = Price_SimpleItem_$_pl_$_Cur.ID
*/
                string selection = @"             Price_SimpleItem_$_si_$$Name,
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
                                                  Price_SimpleItem_$_pl_$$Name,
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
            

                if (usrc_EditTable_SimpleItem.Init(DBSync.DBSync.DB_for_Blagajna.m_DBTables, tbl_Price_SimpleItem, selection, sOrder_by_UndefinedFirst + " Price_SimpleItem_$_si_$$Code desc", false, where_condition, null, false))
                {
                    if (tbl_Price_Item==null)
                    { 
                        tbl_Price_Item = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Price_Item)));
                        tbl_Price_Item.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                    }
                    else
                    {
                        tbl_Price_Item.DeleteInputControls();
                    }
                    where_condition = " where Price_Item_$_pl_$$ID = " + ID.ToString() + " ";
                    /*
CREATE VIEW Price_Item_VIEW AS 
SELECT 
  Price_Item.ID,
  Price_Item.RetailPricePerUnit AS Price_Item_$$RetailPricePerUnit,
  Price_Item.Discount AS Price_Item_$$Discount,
Price_Item_$_tax.ID AS Price_Item_$_tax_$$ID,
Price_Item_$_tax.Name AS Price_Item_$_tax_$$Name,
Price_Item_$_tax.Rate AS Price_Item_$_tax_$$Rate,
Price_Item_$_i.ID AS Price_Item_$_i_$$ID,
Price_Item_$_i.Code AS Price_Item_$_i_$$Code,
Price_Item_$_i.UniqueName AS Price_Item_$_i_$$UniqueName,
Price_Item_$_i.Name AS Price_Item_$_i_$$Name,
Price_Item_$_i_$_ipg1.ID AS Price_Item_$_i_$_ipg1_$$ID,
Price_Item_$_i_$_ipg1.Name AS Price_Item_$_i_$_ipg1_$$Name,
Price_Item_$_i_$_ipg1_$_ipg2.ID AS Price_Item_$_i_$_ipg1_$_ipg2_$$ID,
Price_Item_$_i_$_ipg1_$_ipg2.Name AS Price_Item_$_i_$_ipg1_$_ipg2_$$Name,
Price_Item_$_i_$_ipg1_$_ipg2_$_ipg3.ID AS Price_Item_$_i_$_ipg1_$_ipg2_$_ipg3_$$ID,
Price_Item_$_i_$_ipg1_$_ipg2_$_ipg3.Name AS Price_Item_$_i_$_ipg1_$_ipg2_$_ipg3_$$Name,
Price_Item_$_i_$_u.ID AS Price_Item_$_i_$_u_$$ID,
Price_Item_$_i_$_u.Name AS Price_Item_$_i_$_u_$$Name,
Price_Item_$_i_$_u.Symbol AS Price_Item_$_i_$_u_$$Symbol,
Price_Item_$_i_$_u.DecimalPlaces AS Price_Item_$_i_$_u_$$DecimalPlaces,
Price_Item_$_i_$_u.StorageOption AS Price_Item_$_i_$_u_$$StorageOption,
Price_Item_$_i_$_u.Description AS Price_Item_$_i_$_u_$$Description,
Price_Item_$_i.barcode AS Price_Item_$_i_$$barcode,
Price_Item_$_i.Description AS Price_Item_$_i_$$Description,
Price_Item_$_i_$_iimg.ID AS Price_Item_$_i_$_iimg_$$ID,
Price_Item_$_i_$_iimg.Image_Hash AS Price_Item_$_i_$_iimg_$$Image_Hash,
Price_Item_$_i_$_iimg.Image_Data AS Price_Item_$_i_$_iimg_$$Image_Data,
Price_Item_$_i_$_exp.ID AS Price_Item_$_i_$_exp_$$ID,
Price_Item_$_i_$_exp.ExpectedShelfLifeInDays AS Price_Item_$_i_$_exp_$$ExpectedShelfLifeInDays,
Price_Item_$_i_$_exp.SaleBeforeExpiryDateInDays AS Price_Item_$_i_$_exp_$$SaleBeforeExpiryDateInDays,
Price_Item_$_i_$_exp.DiscardBeforeExpiryDateInDays AS Price_Item_$_i_$_exp_$$DiscardBeforeExpiryDateInDays,
Price_Item_$_i_$_exp.ExpiryDescription AS Price_Item_$_i_$_exp_$$ExpiryDescription,
Price_Item_$_i_$_wrty.ID AS Price_Item_$_i_$_wrty_$$ID,
Price_Item_$_i_$_wrty.WarrantyDuration AS Price_Item_$_i_$_wrty_$$WarrantyDuration,
Price_Item_$_i_$_wrty.WarrantyDurationType AS Price_Item_$_i_$_wrty_$$WarrantyDurationType,
Price_Item_$_i_$_wrty.WarrantyConditions AS Price_Item_$_i_$_wrty_$$WarrantyConditions,
Price_Item_$_i.ToOffer AS Price_Item_$_i_$$ToOffer,
Price_Item_$_pl.ID AS Price_Item_$_pl_$$ID,
Price_Item_$_pl.Name AS Price_Item_$_pl_$$Name,
Price_Item_$_pl.Valid AS Price_Item_$_pl_$$Valid,
Price_Item_$_pl_$_Cur.ID AS Price_Item_$_pl_$_Cur_$$ID,
Price_Item_$_pl_$_Cur.Abbreviation AS Price_Item_$_pl_$_Cur_$$Abbreviation,
Price_Item_$_pl_$_Cur.Name AS Price_Item_$_pl_$_Cur_$$Name,
Price_Item_$_pl_$_Cur.Symbol AS Price_Item_$_pl_$_Cur_$$Symbol,
Price_Item_$_pl_$_Cur.CurrencyCode AS Price_Item_$_pl_$_Cur_$$CurrencyCode,
Price_Item_$_pl_$_Cur.DecimalPlaces AS Price_Item_$_pl_$_Cur_$$DecimalPlaces,
Price_Item_$_pl.ValidFrom AS Price_Item_$_pl_$$ValidFrom,
Price_Item_$_pl.ValidTo AS Price_Item_$_pl_$$ValidTo,
Price_Item_$_pl.CreationDate AS Price_Item_$_pl_$$CreationDate,
Price_Item_$_pl.Description AS Price_Item_$_pl_$$Description
FROM Price_Item
INNER JOIN Taxation Price_Item_$_tax ON Price_Item.Taxation_ID = Price_Item_$_tax.ID
INNER JOIN Item Price_Item_$_i ON Price_Item.Item_ID = Price_Item_$_i.ID
LEFT JOIN Item_ParentGroup1 Price_Item_$_i_$_ipg1 ON Price_Item_$_i.Item_ParentGroup1_ID = Price_Item_$_i_$_ipg1.ID
LEFT JOIN Item_ParentGroup2 Price_Item_$_i_$_ipg1_$_ipg2 ON Price_Item_$_i_$_ipg1.Item_ParentGroup2_ID = Price_Item_$_i_$_ipg1_$_ipg2.ID
LEFT JOIN Item_ParentGroup3 Price_Item_$_i_$_ipg1_$_ipg2_$_ipg3 ON Price_Item_$_i_$_ipg1_$_ipg2.Item_ParentGroup3_ID = Price_Item_$_i_$_ipg1_$_ipg2_$_ipg3.ID
LEFT JOIN Unit Price_Item_$_i_$_u ON Price_Item_$_i.Unit_ID = Price_Item_$_i_$_u.ID
LEFT JOIN Item_Image Price_Item_$_i_$_iimg ON Price_Item_$_i.Item_Image_ID = Price_Item_$_i_$_iimg.ID
LEFT JOIN Expiry Price_Item_$_i_$_exp ON Price_Item_$_i.Expiry_ID = Price_Item_$_i_$_exp.ID
LEFT JOIN Warranty Price_Item_$_i_$_wrty ON Price_Item_$_i.Warranty_ID = Price_Item_$_i_$_wrty.ID
INNER JOIN PriceList Price_Item_$_pl ON Price_Item.PriceList_ID = Price_Item_$_pl.ID
INNER JOIN Currency Price_Item_$_pl_$_Cur ON Price_Item_$_pl.Currency_ID = Price_Item_$_pl_$_Cur.ID
                    */
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
                                                  Price_Item_$_pl_$$Name,
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
                    if (usrc_EditTable_Item.Init(DBSync.DBSync.DB_for_Blagajna.m_DBTables, tbl_Price_Item, selection, sOrder_by_UndefinedFirst + " Price_Item_$_i_$$Code desc", false, where_condition, null, false))
                    {

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

        private void usrc_EditTable_SimpleItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex>=0)
            {
                if (dgv.Columns[e.ColumnIndex].Name.Equals("RetailsSimpleItemPrice"))
                {
                    if (e.RowIndex>=0)
                    {
                        object o_RetailsSimpleItemPrice = dgv[e.ColumnIndex,e.RowIndex].Value;
                        if (o_RetailsSimpleItemPrice.GetType() == typeof(decimal))
                        {
                            decimal RetailsSimpleItemPrice = (decimal)o_RetailsSimpleItemPrice;
                            if (RetailsSimpleItemPrice<0)
                            {
                                int iCount = dgv.Rows[e.RowIndex].Cells.Count;
                                int i;
                                for (i=0;i<iCount;i++)
                                {
                                    dgv.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.LightPink;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void usrc_EditTable_Item_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private bool usrc_EditTable_SimpleItem_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, SQLTableControl.ID_v id_v, ref bool bCancelDialog, ref ltext Instruction)
        {
            if (pSQL_Table.TableName.ToLower().Equals("taxation"))
            {
                if (pSQL_Table.pParentTable!=null)
                {
                    if (pSQL_Table.pParentTable.TableName.ToLower().Equals("price_simpleitem"))
                    {
                        string sql = "select Name from Taxation where id = " + id_v.v.ToString();
                        DataTable dt = new DataTable();
                        string Err = null;
                        if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
                        {
                            if (dt.Rows.Count>0)
                            {
                                string staxname = (string)dt.Rows[0]["Name"];
                                List<object> complex_text = new List<object>();
                                complex_text.Add(lngRPM.s_Tax_with_name);
                                complex_text.Add("\""+staxname +"\"");
                                complex_text.Add(lngRPM.s_belongs_to_many_other_trade_items_and_services);
                                complex_text.Add(lngRPM.s_If_you_want_to_change_the_tax_only_to_the_selected_article___);

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

    }
}
