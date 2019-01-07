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
using DBConnectionControl40;

namespace TangentaCore
{
    public partial class usrc_PurchasePrice_Edit : UserControl
    {
        public bool b_InsertInDataBase = false;
        public delegate void delegate_Cancel ();
        public event delegate_Cancel Button_Cancel_Click;

        public delegate void delegate_OK();
        public event delegate_OK Button_OK_Click;
        public NavigationButtons.Navigation nav = null;

        public usrc_PurchasePrice_Edit()
        {
            InitializeComponent();
            this.usrc_EditTable_PurchaseItem.Title = lng.s_PurchasePrice_Items.s;
            this.usrc_EditTable_PurchasePriceList.Title = "";
        }

        public bool Init(CodeTables.DBTableControl dbTables,SQLTable tbl,ref string Err, NavigationButtons.Navigation xnav)
        {
            nav = xnav;
            tbl.CreateTableTree(dbTables.DBT.items);
            string selection = @"ID,
                                 PurchasePrice_$$CreationDate,
                                 PurchasePrice_$$Description,
                                 PurchasePrice_$_Cur_$$Name,
                                 PurchasePrice_$_Cur_$$Abbreviation,
                                 PurchasePrice_$_Cur_$$Symbol,
                                 PurchasePrice_$$Valid,
                                 PurchasePrice_$$ValidFrom,
                                 PurchasePrice_$$ValidTo
            ";
            return usrc_EditTable_PurchasePriceList.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                         DBSync.DBSync.MyTransactionLog_delegates,
                                                         tbl,selection, "ID asc",false,null,null,false,nav);
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

        private void usrc_EditTable_PurchasePrice_after_InsertInDataBase(SQLTable m_tbl, ID xID, bool bRes, Transaction transaction)
        {
            // Now create price lists
            if (bRes)
            {
                SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Taxation)));
                tbl_Taxation.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.DBT.items);
                SelectID_Table_Assistant_Form  SelectID_Table_dlg = new SelectID_Table_Assistant_Form(tbl_Taxation,DBSync.DBSync.DB_for_Tangenta.m_DBTables,null);
                SelectID_Table_dlg.ShowDialog();
                ID id_Taxation = SelectID_Table_dlg.ID;
                if (ID.Validate(id_Taxation))
                {
                    string Err = null;
                    string sql = @" insert into PurchasePrice_Item (Item_ID,PurchasePrice_ID,Taxation_ID,PurchasePricePerUnit,Discount) 
                                select id," + xID.ToString() + "," + id_Taxation.ToString() + ",-1,0 from Item where ToOffer = 1";
                    //Transaction transaction_usrc_EditTable_PurchasePrice_after_InsertInDataBase = DBSync.DBSync.NewTransaction("usrc_EditTable_PurchasePrice_after_InsertInDataBase");
                    //if (transaction_usrc_EditTable_PurchasePrice_after_InsertInDataBase.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
                    //if (transaction_usrc_EditTable_PurchasePrice_after_InsertInDataBase.Commit())
                    //{
                    if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con, sql, null, ref Err))
                    { 
                        if (transaction.Commit())
                        {
                            SQLTable tbl_Price_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_Item)));
                            tbl_Price_Item.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.DBT.items);
                            string where_condition = " where PurchasePrice_$_ID = " + xID.ToString() + " ";
                            string selection = @"ID,
                                 PurchasePrice_Item_$$PurchasePricePerUnit,
                                 PurchasePrice_Item_$_pp_$_Cur_$$Symbol,
                                 PurchasePrice_Item_$_i_$$UniqueName,
                                 PurchasePrice_Item_$_tax_$$Name,
                                 PurchasePrice_Item_$_tax_$$Rate,
                                 PurchasePrice_Item_$_pp_$$Valid,
                                 PurchasePrice_Item_$_i_$$Code ";

                            if (usrc_EditTable_PurchaseItem.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                 DBSync.DBSync.MyTransactionLog_delegates,
                                                                 tbl_Price_Item, selection, "PurchasePrice_Item_$_i_$$Code desc", false, where_condition, null, false, nav))
                            {
                                Edit_PurchasePrice_Item(id_Taxation);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        transaction.Rollback();
                        LogFile.Error.Show("ERROR:usrc_PriceList_Edit:usrc_EditTable_PriceList_after_InsertInDataBase:Err=" + Err + "\r\nSql=" + sql);
                    }
                }
            }
            else
            {
                if (transaction!=null)
                {
                    transaction.Rollback();
                }
            }
            b_InsertInDataBase = false;
        }

        private void Edit_PurchasePrice_Item(ID id_Taxation)
        {
            string Err = null;
            string sql = @"select ID from PurchasePrice_Item ";
            DataTable dt_PurchasePrice_Item = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt_PurchasePrice_Item, sql, ref Err))
            {
                if (dt_PurchasePrice_Item.Rows.Count > 0)
                {
                    SQLTable tbl_PurchasePrice_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(PurchasePrice_Item)));
                    tbl_PurchasePrice_Item.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.DBT.items);
                    string selection = @"ID,
                                 PurchasePrice_Item_$$PurchasePricePerUnit,
                                 PurchasePrice_Item_$_pp_$_Cur_$$Symbol,
                                 PurchasePrice_Item_$_i_$$UniqueName,
                                 PurchasePrice_Item_$_tax_$$Name,
                                 PurchasePrice_Item_$_tax_$$Rate,
                                 PurchasePrice_Item_$_pp_$$Valid,
                                 PurchasePrice_Item_$_pp_$_myOrganisation_Person_$_myOrganisation_$$Name,
                                 PurchasePrice_Item_$_pp_$_myOrganisation_Person_$$UserName,
                                 PurchasePrice_Item_$_pp_$_myOrganisation_Person_$$FirstName,
                                 PurchasePrice_Item_$_pp_$_myOrganisation_Person_$$LastName
                                 PurchasePrice_Item_$_i_$$Code
";

                    if (this.usrc_EditTable_PurchaseItem.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                              DBSync.DBSync.MyTransactionLog_delegates,
                                                              tbl_PurchasePrice_Item, selection, "PurchasePrice_Item_$_i_$$Code desc", false, null, null, false, nav))
                    {
                        return;
                    }
                }
                else
                {
                    sql = @"select ID from PriceList order by ID asc";
                    DataTable dt_PriceList = new DataTable();
                    if (DBSync.DBSync.ReadDataTable(ref dt_PriceList, sql, ref Err))
                    {
                        if (dt_PriceList.Rows.Count > 0)
                        {
                            long PriceList_ID = (long)dt_PriceList.Rows[0]["ID"];

                            sql = @" insert into PurchasePrice_Item (Item_ID,PriceList_ID,Taxation_ID,PurchasePricePerUnit) 
                                                        select id," + PriceList_ID.ToString() + "," + id_Taxation.ToString() + ",-1 from Item where ToOffer = 1";
                            Transaction transaction_Edit_PurchasePrice_Item = DBSync.DBSync.NewTransaction("Edit_PurchasePrice_Item");
                            if (transaction_Edit_PurchasePrice_Item.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
                            {
                                if (transaction_Edit_PurchasePrice_Item.Commit())
                                {

                                    SQLTable tbl_PurchasePrice_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(PurchasePrice_Item)));
                                    tbl_PurchasePrice_Item.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.DBT.items);
                                    string selection = @"ID,
                                 PurchasePrice_Item_$$PurchasePricePerUnit,
                                 PurchasePrice_Item_$_pp_$_Cur_$$Symbol,
                                 PurchasePrice_Item_$_i_$$UniqueName,
                                 PurchasePrice_Item_$_tax_$$Name,
                                 PurchasePrice_Item_$_tax_$$Rate,
                                 PurchasePrice_Item_$_pp_$$Valid,
                                 PurchasePrice_Item_$_pp_$_myOrganisation_Person_$_myOrganisation_$$Name,
                                 PurchasePrice_Item_$_pp_$_myOrganisation_Person_$$UserName,
                                 PurchasePrice_Item_$_pp_$_myOrganisation_Person_$$FirstName,
                                 PurchasePrice_Item_$_pp_$_myOrganisation_Person_$$LastName
                                 PurchasePrice_Item_$_i_$$Code
";
                                    if (usrc_EditTable_PurchaseItem.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                         DBSync.DBSync.MyTransactionLog_delegates,
                                                                         tbl_PurchasePrice_Item, selection, "PurchasePrice_Item_$_i_$$Code desc", false, null, null, false, nav))
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                transaction_Edit_PurchasePrice_Item.Rollback();
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


        private void usrc_EditTable_PriceList_SelectedIndexChanged(SQLTable m_tbl, ID xID, int index)
        {
            string where_condition = " where PurchasePrice_Item_$_pp_$$ID = " + xID.ToString() + " ";
            SQLTable tbl_Price_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_Item)));
            tbl_Price_Item.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.DBT.items);
            string selection = @"ID,
                                 PurchasePrice_Item_$$PurchasePricePerUnit,
                                 PurchasePrice_Item_$_pp_$_Cur_$$Symbol,
                                 PurchasePrice_Item_$_i_$$UniqueName,
                                 PurchasePrice_Item_$_tax_$$Name,
                                 PurchasePrice_Item_$_tax_$$Rate,
                                 PurchasePrice_Item_$_pp_$$Valid,
                                 PurchasePrice_Item_$_i_$$Code
";

            if (usrc_EditTable_PurchaseItem.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                 DBSync.DBSync.MyTransactionLog_delegates,
                                                 tbl_Price_Item, selection, "PurchasePrice_Item_$_i_$$Code desc", false, where_condition, null, false,nav))
            {

            }
        }

        private void usrc_EditTable_PurchasePrice_before_InsertInDataBase(SQLTable m_tbl, ref bool bCancel, ref Transaction transaction)
        {
            b_InsertInDataBase = true;
        }


    }
}
