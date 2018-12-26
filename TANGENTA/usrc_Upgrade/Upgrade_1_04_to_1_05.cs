using CodeTables;
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TangentaTableClass;

namespace UpgradeDB
{
    internal static class Upgrade_1_04_to_1_05
    {
        private static Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05 = null;
        private static Database_Upgrade_WindowsForm_Thread wfp_ui_thread = null;
        internal static UpgradeDB_inThread.eUpgrade m_eUpgrade = UpgradeDB_inThread.eUpgrade.none;
        private static List<TableDataItem> TableDataItem_List = new List<TableDataItem>();


        internal static object UpgradeDB_1_04_to_1_05(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_04_to_1_05 = DBSync.DBSync.NewTransaction("UpgradeDB_1_04_to_1_05");

            Check_DB_1_04(transaction_UpgradeDB_1_04_to_1_05);
            m_Old_tables_1_04_to_1_05 = new Old_tables_1_04_to_1_05();
            if (m_Old_tables_1_04_to_1_05.Read())
            {
                m_eUpgrade = UpgradeDB_inThread.eUpgrade.from_1_04_to_105;
                wfp_ui_thread = new Database_Upgrade_WindowsForm_Thread();
                wfp_ui_thread.Start();


                List<DataTable> dt_List = new List<DataTable>();
                string Message_Title = " 1.04 -> 1.05";

                SQLTable tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(PersonData));
                wfp_ui_thread.Message("$$$" + lng.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
                SQLTable xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_PersonData = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }

                TableDataItem_List.Add(dt_PersonData);


                Err = null;
                Message_Title = " 1.04 -> 1.05";
                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation));
                wfp_ui_thread.Message("$$$" + lng.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_myOrganisation = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_myOrganisation);

                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_myOrganisation));
                wfp_ui_thread.Message("$$$" + lng.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_Atom_myOrganisation = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Atom_myOrganisation);

                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_Item));
                wfp_ui_thread.Message("$$$" + lng.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_Price_Item = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Price_Item);

                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_SimpleItem));
                wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_Price_SimpleItem = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Price_SimpleItem);

                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationAccount));
                wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_OrganisationAccount = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_OrganisationAccount);


                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice_ShopB_Item));
                wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_DocInvoice_ShopB_Item = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_DocInvoice_ShopB_Item);


                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice_ShopC_Item));
                wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_DocInvoice_ShopC_Item = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_DocInvoice_ShopC_Item);


                Err = null;
                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.DBSettings));
                wfp_ui_thread.Message("$$$" + lng.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_DBSettings = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_DBSettings);

                Err = null;
                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.BaseCurrency));
                wfp_ui_thread.Message("$$$" + lng.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_BaseCurrency = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_BaseCurrency);


                wfp_ui_thread.Message(lng.s_BackupOfExistingDatabase.s + DBSync.DBSync.DataBase + " -> " + DBSync.DBSync.DataBase_BackupTemp);

                if (DBSync.DBSync.DB_for_Tangenta.DataBase_Make_BackupTemp())
                {
                    if (DBSync.DBSync.DB_for_Tangenta.DataBase_Delete())
                    {
                        if (DBSync.DBSync.DB_for_Tangenta.DataBase_Create(transaction_UpgradeDB_1_04_to_1_05))
                        {
                            wfp_ui_thread.Message(lng.s_ImportData.s);
                            if (Write_TableDataItem_List(m_eUpgrade, m_Old_tables_1_04_to_1_05))
                            {
                                // Correct Item's Units
                                string sql = "update item set Unit_ID=1";
                                if (transaction_UpgradeDB_1_04_to_1_05.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null,  ref Err))
                                {
                                    if (UpgradeDB_inThread.Set_DataBase_Version("1.05", transaction_UpgradeDB_1_04_to_1_05))
                                    {
                                        if (transaction_UpgradeDB_1_04_to_1_05.Commit())
                                        {
                                            wfp_ui_thread.End();
                                            return true;
                                        }
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                                }

                            }
                        }
                    }
                }
                wfp_ui_thread.End();
            }
            transaction_UpgradeDB_1_04_to_1_05.Rollback();
            return false;
        }

        private static bool Check_DB_1_04(Transaction transaction)
        {
            string Err = null;
            string sql = "select ID,FinancialYear,NumberInFinancialYear,NetSum,TaxSum,GrossSum from DocInvoice where Draft=0";
            DataTable dt_DocInvoice = new DataTable();
            DataTable dt_DocInvoice_ShopB_Item = new DataTable();
            DataTable dt_DocInvoice_ShopC_Item = new DataTable();
            DataTable dt_Atom_Price_Item = new DataTable();
            string sErrMsg = "";
            if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice, sql, ref Err))
            {
                sql = "select ID,RetailSimpleItemPrice,iQuantity,TaxPrice,DocInvoice_ID from DocInvoice_ShopB_Item";
                if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice_ShopB_Item, sql, ref Err))
                {
                    sql = "select ID,RetailPriceWithDiscount,dQuantity,Atom_Price_Item_ID,DocInvoice_ID from DocInvoice_ShopC_Item";
                    if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice_ShopC_Item, sql, ref Err))
                    {
                        sql = "select ID,RetailPricePerUnit from Atom_Price_Item";
                        if (DBSync.DBSync.ReadDataTable(ref dt_Atom_Price_Item, sql, ref Err))
                        {
                            long DocInvoice_ID = -1;
                            int iFinancialYear = -1;
                            int iNumberInFinancialYear = -1;
                            decimal NetSum = -1;
                            decimal TaxSum = -1;
                            decimal GrossSum = -1;
                            decimal ItemsGrossSum = -1;
                            foreach (DataRow dr in dt_DocInvoice.Rows)
                            {
                                DocInvoice_ID = (long)dr["ID"];
                                iFinancialYear = (int)dr["FinancialYear"];
                                iNumberInFinancialYear = (int)dr["NumberInFinancialYear"];
                                NetSum = (decimal)dr["NetSum"];
                                TaxSum = (decimal)dr["TaxSum"];
                                GrossSum = (decimal)dr["GrossSum"];
                                List<long> DocInvoice_ShopB_Item_ID_list = new List<long>();
                                long DocInvoice_ShopB_Item_ID = -1;
                                GetItemsSum(DocInvoice_ID, dt_DocInvoice_ShopB_Item, dt_DocInvoice_ShopC_Item, dt_Atom_Price_Item, ref ItemsGrossSum, ref DocInvoice_ShopB_Item_ID);
                                if (ItemsGrossSum == GrossSum)
                                {
                                    continue;
                                }
                                else
                                {
                                    sErrMsg += "ERROR:Proforma_Invoice_ID = " + DocInvoice_ID.ToString() + " GrossSum=" + GrossSum.ToString() + " ItemsGrossSum = " + ItemsGrossSum.ToString() + "\r\n";
                                    if (((DocInvoice_ID == 45) || (DocInvoice_ID == 47) || (DocInvoice_ID == 89)) && (DocInvoice_ShopB_Item_ID >= 0))
                                    {
                                        string sql_update = "update DocInvoice_ShopB_Item set iQuantity = 1 where DocInvoice_ID = " + DocInvoice_ID.ToString() + " and ID =" + DocInvoice_ShopB_Item_ID.ToString();
                                        if (!transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql_update, null,  ref Err))
                                        {
                                            LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                            }
                            if (sErrMsg.Length > 0)
                            {
                                LogFile.Error.Show("Check_DB_1_04:Errors:\r\n" + sErrMsg);
                            }
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                            return false;

                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                        return false;

                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                    return false;

                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                return false;

            }
        }

        internal static void GetItemsSum(long DocInvoice_ID, DataTable dt_DocInvoice_ShopB_Item, DataTable dt_DocInvoice_ShopC_Item, DataTable dt_Atom_Price_Item, ref decimal ItemsGrossSum, ref long DocInvoice_ShopB_Item_ID)
        {
            decimal dsum = 0;
            DataRow[] drs_DocInvoice_ShopB_Item = dt_DocInvoice_ShopB_Item.Select("DocInvoice_ID=" + DocInvoice_ID.ToString());
            if (drs_DocInvoice_ShopB_Item.Count() > 0)
            {
                int iQuantity = -1;

                int icol_iQuantity = dt_DocInvoice_ShopB_Item.Columns.IndexOf("iQuantity");
                int icol_RetailPriceWithDiscount = dt_DocInvoice_ShopB_Item.Columns.IndexOf("RetailSimpleItemPrice");

                decimal dRetailPriceWithDiscount = -1;
                foreach (DataRow dr_DocInvoice_ShopB_Item in drs_DocInvoice_ShopB_Item)
                {
                    iQuantity = (int)dr_DocInvoice_ShopB_Item[icol_iQuantity];
                    DocInvoice_ShopB_Item_ID = (long)dr_DocInvoice_ShopB_Item["ID"];
                    dRetailPriceWithDiscount = (decimal)dr_DocInvoice_ShopB_Item[icol_RetailPriceWithDiscount];
                    dsum += dRetailPriceWithDiscount * iQuantity;
                }
            }

            DataRow[] drs_DocInvoice_ShopC_Item = dt_DocInvoice_ShopC_Item.Select("DocInvoice_ID=" + DocInvoice_ID.ToString());
            if (drs_DocInvoice_ShopC_Item.Count() > 0)
            {
                decimal dQuantity = -1;
                int icol_iQuantity = dt_DocInvoice_ShopC_Item.Columns.IndexOf("dQuantity");
                int icol_Atom_Price_Item_ID = dt_DocInvoice_ShopC_Item.Columns.IndexOf("Atom_Price_Item_ID");

                decimal dRetailPricePerUnit = -1;

                foreach (DataRow dr_DocInvoice_ShopC_Item in drs_DocInvoice_ShopC_Item)
                {
                    dQuantity = (decimal)dr_DocInvoice_ShopC_Item[icol_iQuantity];
                    long Atom_Price_Item_ID = (long)dr_DocInvoice_ShopC_Item[icol_Atom_Price_Item_ID];
                    DataRow[] drs_Atom_Price_Item = dt_Atom_Price_Item.Select("ID=" + Atom_Price_Item_ID.ToString());
                    if (drs_Atom_Price_Item.Count() == 1)
                    {
                        dRetailPricePerUnit = (decimal)drs_Atom_Price_Item[0]["RetailPricePerUnit"];
                        dsum += decimal.Round(dQuantity * dRetailPricePerUnit, 2);
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:GetItemsSum:drs_Atom_Price_Item.Count()!=1");
                    }
                }
            }
            ItemsGrossSum = dsum;
        }

        private static bool Write_TableDataItem_List(UpgradeDB_inThread.eUpgrade eUpgr, Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {
            foreach (TableDataItem tdi in TableDataItem_List)
            {
                //if (!tdi.Write2DB(wfp_ui_thread, eUpgr, m_Old_tables_1_04_to_1_05))
                //{
                //    return false;
                //}
            }
            return true;
        }
    }
}
