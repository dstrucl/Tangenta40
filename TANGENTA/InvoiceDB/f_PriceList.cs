#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLTableControl;
using System.Windows.Forms;
using LanguageControl;
using BlagajnaTableClass;

namespace InvoiceDB
{
    public static class f_PriceList
    {
        public static bool Insert_ShopB_Items_in_PriceList(DataTable dt_SimpleItem, Control parent_ctrl)
        {
            string Err = null;

            for (;;)
            {
                SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Taxation)));
                tbl_Taxation.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                SelectID_Table_Assistant_Form SelectID_Table_dlg = new SelectID_Table_Assistant_Form(tbl_Taxation, DBSync.DBSync.DB_for_Blagajna.m_DBTables, null);
                SelectID_Table_dlg.ShowDialog();
                long id_Taxation = SelectID_Table_dlg.ID;
                if (id_Taxation >= 0)
                {
                    foreach (DataRow dr in dt_SimpleItem.Rows)
                    {
                        long PriceList_ID = (long)dr["PriceList_ID"];
                        long SimpleItem_ID = (long)dr["SimpleItem_ID"];
                        object objresult = new object();
                        string sql = "insert into Price_SimpleItem (RetailSimpleItemPrice,Discount,Taxation_ID,SimpleItem_ID,PriceList_ID) values (-1,0," + id_Taxation.ToString() + "," + SimpleItem_ID.ToString() + "," + PriceList_ID.ToString() + ")";
                        if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref objresult, ref Err))
                        {
                            LogFile.Error.Show("ERROR:f_PriceList:Update:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    if (MessageBox.Show(parent_ctrl, lngRPM.s_PriceListIsNotUpdatedBecauseYouDidnotSelect.s, "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
            }
        }

        public static bool Insert_ShopC_Items_in_PriceList(DataTable dt_Item_NotIn_PriceList, Control parent_ctrl)
        {
            string Err = null;
            for (;;)
            {
                SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Taxation)));
                tbl_Taxation.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                SelectID_Table_Assistant_Form SelectID_Table_dlg = new SelectID_Table_Assistant_Form(tbl_Taxation, DBSync.DBSync.DB_for_Blagajna.m_DBTables, null);
                SelectID_Table_dlg.ShowDialog();
                long id_Taxation = SelectID_Table_dlg.ID;
                if (id_Taxation >= 0)
                {
                    foreach (DataRow dr in dt_Item_NotIn_PriceList.Rows)
                    {
                        long PriceList_ID = (long)dr["PriceList_ID"];
                        long Item_ID = (long)dr["Item_ID"];
                        string sql = "insert into Price_Item (RetailPricePerUnit,Discount,Taxation_ID,Item_ID,PriceList_ID) values (-1,0," + id_Taxation.ToString() + "," + Item_ID.ToString() + "," + PriceList_ID.ToString() + ")";
                        object objresult = new object();
                        if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref objresult, ref Err))
                        {
                            LogFile.Error.Show("ERROR:f_PriceList:Update:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    if (MessageBox.Show(parent_ctrl, lngRPM.s_PriceListIsNotUpdatedBecauseYouDidnotSelect.s, "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
            }
        }


        private static bool check_price_ShopC_Item(ref DataTable dt_ShopC_Items_NotIn_PriceList)
        {
            string Err = null;
            if (dt_ShopC_Items_NotIn_PriceList.Columns.Count == 0)
            {
                dt_ShopC_Items_NotIn_PriceList.Columns.Add("PriceList_ID", typeof(long));
                dt_ShopC_Items_NotIn_PriceList.Columns.Add("PriceList", typeof(string));
                dt_ShopC_Items_NotIn_PriceList.Columns.Add("Item_ID", typeof(long));
                dt_ShopC_Items_NotIn_PriceList.Columns.Add("UniqueName", typeof(string));
                dt_ShopC_Items_NotIn_PriceList.Columns.Add("Name", typeof(string));
            }

            DataTable dt_PriceList = new DataTable();

            string sql = "select ID,Name from PriceList";
            if (DBSync.DBSync.ReadDataTable(ref dt_PriceList, sql, ref Err))
            {
                foreach (DataRow dr in dt_PriceList.Rows)
                {
                    long PriceList_ID = (long)dr["ID"];
                    string PriceList_Name = (string)dr["Name"];

                    DataTable dt_Item = new DataTable();
                    sql = "select ID,UniqueName,Name from Item where (ToOffer=1) and (ID not in (Select Item_ID from Price_Item where PriceList_ID = " + PriceList_ID.ToString() + "))";
                    if (DBSync.DBSync.ReadDataTable(ref dt_Item, sql, ref Err))
                    {
                        if (dt_Item.Rows.Count > 0)
                        {
                            foreach (DataRow dr_of_dt_Item in dt_Item.Rows)
                            {
                                DataRow dr_of_dt = dt_ShopC_Items_NotIn_PriceList.NewRow();
                                dr_of_dt["PriceList_ID"] = PriceList_ID;
                                dr_of_dt["PriceList"] = PriceList_Name;
                                dr_of_dt["Item_ID"] = dr_of_dt_Item["ID"];
                                dr_of_dt["UniqueName"] = dr_of_dt_Item["UniqueName"];
                                dr_of_dt["Name"] = dr_of_dt_Item["Name"];
                                dt_ShopC_Items_NotIn_PriceList.Rows.Add(dr_of_dt);
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_PriceList:check_price_item:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PriceList:check_price_item:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }


        }

        private static bool check_price_ShopB_Item(ref DataTable dt)
        {
            string Err = null;
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("PriceList_ID", typeof(long));
                dt.Columns.Add("PriceList", typeof(string));
                dt.Columns.Add("SimpleItem_ID", typeof(long));
                dt.Columns.Add("Name", typeof(string));
            }

            DataTable dt_PriceList = new DataTable();

            string sql = "select ID,Name from PriceList";
            if (DBSync.DBSync.ReadDataTable(ref dt_PriceList, sql, ref Err))
            {
                foreach (DataRow dr in dt_PriceList.Rows)
                {
                    long PriceList_ID = (long)dr["ID"];
                    string PriceList_Name = (string)dr["Name"];
                    DataTable dt_SimpleItem = new DataTable();
                    sql = "select ID,Name from SimpleItem where (ToOffer = 1) and (ID not in (Select SimpleItem_ID from Price_SimpleItem where PriceList_ID = " + PriceList_ID.ToString() + " ))"; ;
                    if (DBSync.DBSync.ReadDataTable(ref dt_SimpleItem, sql, ref Err))
                    {
                        if (dt_SimpleItem.Rows.Count > 0)
                        {
                            foreach (DataRow dr_of_dt_SimpleItem in dt_SimpleItem.Rows)
                            {
                                DataRow dr_of_dt = dt.NewRow();
                                dr_of_dt["PriceList_ID"] = PriceList_ID;
                                dr_of_dt["PriceList"] = PriceList_Name;
                                dr_of_dt["SimpleItem_ID"] = dr_of_dt_SimpleItem["ID"];
                                dr_of_dt["Name"] = dr_of_dt_SimpleItem["Name"];
                                dt.Rows.Add(dr_of_dt);
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_PriceList:check_price_item:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PriceList:check_price_item:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }



        public static bool CheckAndComplete_PriceList_if_needed(char chShop,Control parent_ctrl)
        {
            DataTable dt_Item_NotIn_PriceList = new DataTable();
            if (chShop == 'B')
            {
                if (check_price_ShopB_Item(ref dt_Item_NotIn_PriceList))
                {
                    if (dt_Item_NotIn_PriceList.Rows.Count > 0)
                    {
                        return Insert_ShopB_Items_in_PriceList(dt_Item_NotIn_PriceList, parent_ctrl);
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;

                }
            }
            else if (chShop == 'C')
            {
                if (check_price_ShopC_Item(ref dt_Item_NotIn_PriceList))
                {
                    if (dt_Item_NotIn_PriceList.Rows.Count > 0)
                    {
                        if (Insert_ShopC_Items_in_PriceList(dt_Item_NotIn_PriceList, parent_ctrl))
                        {
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PriceList:Update:chShop can be 'B' or 'C'!");
                return false;
            }
        }

        public static bool Check_All_ShopB_Items_In_PriceList(ref DataTable dt_ShopB_Item_NotIn_PriceList)
        {
            if (check_price_ShopB_Item(ref dt_ShopB_Item_NotIn_PriceList))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Check_All_ShopC_Items_In_PriceList(ref DataTable dt_ShopC_Item_NotIn_PriceList)
        {
            if (check_price_ShopC_Item(ref dt_ShopC_Item_NotIn_PriceList))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static void CheckPriceUndefined_ShopB(ref bool bEdit)
        {
            string Err = null;
            bEdit = false;
            DataTable dt_Price_SimpleItem_VIEW = new DataTable();
            string sql = @"select Price_SimpleItem_$_pl_$$Name,Price_SimpleItem_$_si_$$Name
                            from Price_SimpleItem_VIEW where Price_SimpleItem_$_si_$$ToOffer = 1 and  Price_SimpleItem_$$RetailSimpleItemPrice < 0";
            if (DBSync.DBSync.ReadDataTable(ref dt_Price_SimpleItem_VIEW, sql, ref Err))
            {
                if (dt_Price_SimpleItem_VIEW.Rows.Count > 0)
                {
                    bEdit = true;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PriceList:CheckPriceUndefined_ShopB:sql=" + sql + "\r\nErr=" + Err);
            }
        }


        public static void CheckPriceUndefined_ShopC(ref bool bEdit)
        {
            string Err = null;
            bEdit = false;
            DataTable dt_Price_Item_VIEW = new DataTable();
            string sql = @"select Price_Item_$_pl_$$Name,Price_Item_$_i_$$UniqueName,Price_Item_$_i_$$Name
                            from Price_Item_VIEW where Price_Item_$_i_$$ToOffer = 1 and Price_Item_$$RetailPricePerUnit < 0";
            if (DBSync.DBSync.ReadDataTable(ref dt_Price_Item_VIEW, sql, ref Err))
            {
                if (dt_Price_Item_VIEW.Rows.Count > 0)
                {
                    //uwpf_GUI.Price_Undefined_Window piu_w = new uwpf_GUI.Price_Undefined_Window(lngRPM.s_ItemPriceUndefined.s, dt_Price_Item_VIEW, xdbTables);
                    //bEdit = (bool) piu_w.ShowDialog();
                    bEdit = true;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PriceList:CheckPriceUndefined_ShopB:sql=" + sql + "\r\nErr=" + Err);
            }
        }
    }
}
