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
using CodeTables;
using System.Windows.Forms;
using LanguageControl;
using TangentaTableClass;
using DBTypes;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_PriceList
    {
        public static bool Get(string sPriceListName, bool valid, long Currency_ID, DateTime_v ValidFrom_v, DateTime_v ValidTo_v, DateTime_v CreationDate_v, string Description, ref long PriceList_ID)
        {
            string Err = null;
            object oret = null;
            string sql = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_PriceListName = "@par_PriceListName";
            SQL_Parameter par_PriceListName = new SQL_Parameter(spar_PriceListName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, sPriceListName);
            lpar.Add(par_PriceListName);

            string scond_ValidFrom = " ValidFrom is null ";
            string sval_ValidFrom = " null ";
            if (ValidFrom_v != null)
            {
                string spar_ValidFrom = "@par_ValidFrom";
                SQL_Parameter par_ValidFrom = new SQL_Parameter(spar_ValidFrom, SQL_Parameter.eSQL_Parameter.Datetime, false, ValidFrom_v.v);
                lpar.Add(par_ValidFrom);
                scond_ValidFrom = " ValidFrom = " + spar_ValidFrom + " ";
                sval_ValidFrom = " " + spar_ValidFrom + " ";
            }


            string scond_ValidTo = " ValidTo is null ";
            string sval_ValidTo = " null ";
            if (ValidTo_v != null)
            {
                string spar_ValidTo = "@par_ValidTo";
                SQL_Parameter par_ValidTo = new SQL_Parameter(spar_ValidTo, SQL_Parameter.eSQL_Parameter.Datetime, false, ValidTo_v.v);
                lpar.Add(par_ValidTo);
                scond_ValidTo = " ValidTo = " + spar_ValidTo + " ";
                sval_ValidTo = " " + spar_ValidTo + " ";
            }

            string scond_CreationDate = " CreationDate is null ";
            string sval_CreationDate = " null ";
            if (CreationDate_v != null)
            {
                string spar_CreationDate = "@par_CreationDate";
                SQL_Parameter par_CreationDate = new SQL_Parameter(spar_CreationDate, SQL_Parameter.eSQL_Parameter.Datetime, false, CreationDate_v.v);
                lpar.Add(par_CreationDate);
                scond_CreationDate = " CreationDate = " + spar_CreationDate + " ";
                sval_CreationDate = " " + spar_CreationDate + " ";
            }

            string scond_Description = " Description is null ";
            string sval_Description = " null ";
            if (Description != null)
            {
                string spar_Description = "@par_Description";
                SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                lpar.Add(par_Description);
                scond_Description = " Description = " + spar_Description + " ";
                sval_Description = " " + spar_Description + " ";
            }

            string scond_valid = " valid = 0 ";
            string sval_valid = " 0 ";
            if (valid)
            {
                scond_valid = " valid = 1 ";
                sval_valid = " 1 ";
            }


            sql = "select ID from PriceList where Name = " + spar_PriceListName;


            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    PriceList_ID = (long)dt.Rows[0]["ID"];


                    sql = "select ID from PriceList where Name = " + spar_PriceListName +
                                                        " and Currency_ID = " + Currency_ID.ToString() +
                                                        " and " + scond_valid +
                                                        " and " + scond_ValidFrom +
                                                        " and " + scond_ValidTo +
                                                        " and " + scond_CreationDate +
                                                        " and " + scond_Description;

                    dt.Clear();
                    dt.Rows.Clear();
                    dt.Columns.Clear();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            sql = "update PriceList set Currency_ID = " + Currency_ID.ToString() +
                                                                " , valid = " + sval_valid +
                                                                " , ValidFrom = " + sval_ValidFrom +
                                                                " , ValidTo = " + sval_ValidTo +
                                                                " , CreationDate = " + sval_CreationDate +
                                                                " , Description = " + sval_Description +
                                                                " where ID = " + PriceList_ID.ToString();
                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref oret, ref Err))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_PriceList:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_PriceList:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    sql = @"insert into PriceList (Name,
                                                   valid,
                                                   Currency_ID,
                                                   ValidFrom,
                                                   ValidTo,
                                                   CreationDate,
                                                   Description) values
                                                   (" + spar_PriceListName +
                                                    "," + sval_valid +
                                                    "," + Currency_ID.ToString() +
                                                    "," + sval_ValidFrom +
                                                    "," + sval_ValidTo +
                                                    "," + sval_CreationDate +
                                                    "," + sval_Description +
                                                        ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref PriceList_ID, ref oret, ref Err, "PriceList"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_PriceList:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PriceList:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        public static bool Insert_ShopB_Items_in_PriceList(DataTable dt_SimpleItem, Control parent_ctrl)
        {
            string Err = null;

            for (;;)
            {
                SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Taxation)));
                tbl_Taxation.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                SelectID_Table_Assistant_Form SelectID_Table_dlg = new SelectID_Table_Assistant_Form(tbl_Taxation, DBSync.DBSync.DB_for_Tangenta.m_DBTables, null);
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
                    if (MessageBox.Show(parent_ctrl, lng.s_PriceListIsNotUpdatedBecauseYouDidnotSelect.s, "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
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
                SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Taxation)));
                tbl_Taxation.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                SelectID_Table_Assistant_Form SelectID_Table_dlg = new SelectID_Table_Assistant_Form(tbl_Taxation, DBSync.DBSync.DB_for_Tangenta.m_DBTables, null);
                if (parent_ctrl is Form)
                {
                    if (((Form)parent_ctrl).TopMost)
                    {
                        SelectID_Table_dlg.TopMost = true;
                    }
                }
                SelectID_Table_dlg.ShowDialog(parent_ctrl);
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
                    if (MessageBox.Show(parent_ctrl, lng.s_PriceListIsNotUpdatedBecauseYouDidnotSelect.s, "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
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



        public static bool CheckAndComplete_PriceList_if_needed(char chShop, Control parent_ctrl)
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
                    //uwpf_GUI.Price_Undefined_Window piu_w = new uwpf_GUI.Price_Undefined_Window(lng.s_ItemPriceUndefined.s, dt_Price_Item_VIEW, xdbTables);
                    //bEdit = (bool) piu_w.ShowDialog();
                    bEdit = true;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PriceList:CheckPriceUndefined_ShopB:sql=" + sql + "\r\nErr=" + Err);
            }
        }


        internal static bool Get(string PriceList_Name,
                                 ref long_v priceList_ID_v,
                                 ref bool_v valid_v,
                                 ref DateTime_v validFrom_v,
                                 ref DateTime_v validTo_v,
                                 ref DateTime_v creationDate_v,
                                 ref string_v description_v,
                                 ref long_v Currency_ID_v,
                                 ref string_v CurrencyAbbreviation_v,
                                 ref string_v CurrencyName_v,
                                 ref string_v CurrencySymbol_v,
                                 ref int_v CurrencyCode_v,
                                 ref int_v CurrencyDecimalPlaces_v)
        {
            string Err = null;
            priceList_ID_v = null;
            valid_v = null;
            validFrom_v = null;
            validTo_v = null;
            creationDate_v = null;
            description_v = null;
            Currency_ID_v = null;
            CurrencyAbbreviation_v = null;
            CurrencyName_v = null;
            CurrencySymbol_v = null;
            CurrencyCode_v = null;
            CurrencyDecimalPlaces_v = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, PriceList_Name);
            lpar.Add(par_Name);
            DataTable dt_PriceList = new DataTable();
            string sql = @"select ID,Valid,Currency_ID,ValidFrom,ValidTo,CreationDate,Description from PriceList where Name = " + spar_Name;
            if (DBSync.DBSync.ReadDataTable(ref dt_PriceList, sql, lpar, ref Err))
            {
                if (dt_PriceList.Rows.Count > 0)
                {
                    priceList_ID_v = tf.set_long(dt_PriceList.Rows[0]["ID"]);
                    valid_v = tf.set_bool(dt_PriceList.Rows[0]["Valid"]);
                    validFrom_v = tf.set_DateTime(dt_PriceList.Rows[0]["ValidFrom"]);
                    validTo_v = tf.set_DateTime(dt_PriceList.Rows[0]["ValidTo"]);
                    creationDate_v = tf.set_DateTime(dt_PriceList.Rows[0]["CreationDate"]);
                    description_v = tf.set_string(dt_PriceList.Rows[0]["Description"]);
                    Currency_ID_v = tf.set_long(dt_PriceList.Rows[0]["Currency_ID"]);
                    if (Currency_ID_v != null)
                    {
                        return f_Currency.Get(Currency_ID_v.v,
                                              ref CurrencyAbbreviation_v,
                                              ref CurrencyName_v,
                                              ref CurrencySymbol_v,
                                              ref CurrencyCode_v,
                                              ref CurrencyDecimalPlaces_v
                                             );
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PriceList:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
        internal static bool Get(
                             long priceList_ID,
                             ref string_v PriceList_Name_v,
                             ref bool_v valid_v,
                             ref DateTime_v validFrom_v,
                             ref DateTime_v validTo_v,
                             ref DateTime_v creationDate_v,
                             ref string_v description_v,
                             ref long_v Currency_ID_v,
                             ref string_v CurrencyAbbreviation_v,
                             ref string_v CurrencyName_v,
                             ref string_v CurrencySymbol_v,
                             ref int_v CurrencyCode_v,
                             ref int_v CurrencyDecimalPlaces_v)
        {
            string Err = null;
            PriceList_Name_v = null;
            valid_v = null;
            validFrom_v = null;
            validTo_v = null;
            creationDate_v = null;
            description_v = null;
            Currency_ID_v = null;
            CurrencyAbbreviation_v = null;
            CurrencyName_v = null;
            CurrencySymbol_v = null;
            CurrencyCode_v = null;
            CurrencyDecimalPlaces_v = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_ID = "@par_ID";
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, priceList_ID);
            lpar.Add(par_ID);
            DataTable dt_PriceList = new DataTable();
            string sql = @"select Name,Valid,Currency_ID,ValidFrom,ValidTo,CreationDate,Description from PriceList where ID = " + spar_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt_PriceList, sql, lpar, ref Err))
            {
                if (dt_PriceList.Rows.Count > 0)
                {
                    PriceList_Name_v = tf.set_string(dt_PriceList.Rows[0]["Name"]);
                    valid_v = tf.set_bool(dt_PriceList.Rows[0]["Valid"]);
                    validFrom_v = tf.set_DateTime(dt_PriceList.Rows[0]["ValidFrom"]);
                    validTo_v = tf.set_DateTime(dt_PriceList.Rows[0]["ValidTo"]);
                    creationDate_v = tf.set_DateTime(dt_PriceList.Rows[0]["CreationDate"]);
                    description_v = tf.set_string(dt_PriceList.Rows[0]["Description"]);
                    Currency_ID_v = tf.set_long(dt_PriceList.Rows[0]["Currency_ID"]);
                    if (Currency_ID_v != null)
                    {
                        return f_Currency.Get(Currency_ID_v.v,
                                              ref CurrencyAbbreviation_v,
                                              ref CurrencyName_v,
                                              ref CurrencySymbol_v,
                                              ref CurrencyCode_v,
                                              ref CurrencyDecimalPlaces_v
                                             );
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PriceList:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}

