﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using SQLTableControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceDB
{
    public static class fs
    {
        public enum enum_GetDBSettings
        {
            DBSettings_OK,
            No_Data_Rows,
            No_ReadOnly,
            No_TextValue,
            Error_Load_DBSettings
        };

        public static string GetString(int i, int places)
        {
            string s = i.ToString();
            while (s.Length < places)
            {
                s = '0' + s;
            }
            return s;
        }



        public static enum_GetDBSettings GetDBSettings(string Name, ref string TextValue, ref bool bReadOnly, ref string Err)
        {
            SQLTable tbl_DBSettings = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(DBSettings));
            DataTable dt_DBSettings = new DataTable();
            string colName = "Name";
            string colTextValue = "TextValue";
            string colReadOnly = "ReadOnly";



            string sql_DBSettings = "Select "
                                              + colName + ","
                                              + colTextValue + ","
                                              + colReadOnly + " from DBSettings where Name = '" + Name + "'";

            if (DBSync.DBSync.ReadDataTable(ref dt_DBSettings, sql_DBSettings, ref Err))
            {
                if (dt_DBSettings.Rows.Count > 0)
                {
                    if (dt_DBSettings.Rows[0][colTextValue].GetType() == typeof(string))
                    {
                        TextValue = (string)dt_DBSettings.Rows[0][colTextValue];
                        if (dt_DBSettings.Rows[0][colReadOnly].GetType() == typeof(bool))
                        {
                            bReadOnly = (bool)dt_DBSettings.Rows[0][colReadOnly];
                            return enum_GetDBSettings.DBSettings_OK;
                        }
                        else
                        {
                            return enum_GetDBSettings.No_ReadOnly;
                        }
                    }
                    else
                    {
                        return enum_GetDBSettings.No_TextValue;
                    }
                }
                else
                {
                    return enum_GetDBSettings.No_Data_Rows;
                }
            }
            else
            {
                return enum_GetDBSettings.Error_Load_DBSettings;
            }

        }



        public static bool Init_Default_DB(ref string Err)
        {
            string s_DBSettings_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.DBSettings)).TableName;
            string s_col_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.DBSettings)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_DBSettings.Name.GetType()).Name;
            string s_col_TextValue = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.DBSettings)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_DBSettings.TextValue.GetType()).Name;
            string s_col_ReadOnly = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.DBSettings)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_DBSettings.ReadOnly.GetType()).Name;

            string sql_DB_Version = "insert into " + s_DBSettings_table_name + " ( " + s_col_Name + "," + s_col_TextValue + "," + s_col_ReadOnly + " ) values ('" + DBSync.DBSync.DB_for_Blagajna.Settings.Version.Name + "','" + DBSync.DBSync.DB_for_Blagajna.Settings.Version.TextValue + "'," + Convert.ToInt32(DBSync.DBSync.DB_for_Blagajna.Settings.Version.ReadOnly).ToString() + ")";
            string sql_DB_LastInvoiceType = "insert into " + s_DBSettings_table_name + " ( " + s_col_Name + "," + s_col_TextValue + "," + s_col_ReadOnly + " ) values ('LastInvoiceType','Invoice',0)";
            string sql_DB_StockCheckAtStartup = "insert into " + s_DBSettings_table_name + " ( " + s_col_Name + "," + s_col_TextValue + "," + s_col_ReadOnly + " ) values ('StockCheckAtStartup','1',0)";
            object Result = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_DB_Version, null, ref Result, ref Err))
            {
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql_DB_LastInvoiceType, null, ref Result, ref Err))
                {
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql_DB_StockCheckAtStartup, null, ref Result, ref Err))
                    {
                        if (Init_Currency_Table(ref Err))
                        {
                            if (Init_Unit_Table(ref Err))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool Init_Currency_Table(ref string Err)
        {
            string s_Currency_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).TableName;
            string s_col_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Currency.Name.GetType()).Name;
            string s_col_Abbreviation = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Currency.Abbreviation.GetType()).Name;
            string s_col_Symbol = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Currency.Symbol.GetType()).Name;
            string s_col_CurrencyCode = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Currency.CurrencyCode.GetType()).Name;
            string s_col_DecimalPlaces = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Currency.DecimalPlaces.GetType()).Name;

            xCurrencyList xCurrencyList = new xCurrencyList();

            DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.BatchOpen = true;
            string sql_Currency = "insert into " + s_Currency_table_name + " ( " + s_col_Name + "," + s_col_Abbreviation + "," + s_col_Symbol + "," + s_col_CurrencyCode + "," + s_col_DecimalPlaces + " ) values (";
            foreach (xCurrency currency in xCurrencyList.m_CurrencyList)
            {
                string sValues = "'" + currency.Name + "','" + currency.Abbreviation + "','" + currency.Symbol + "'," + currency.CurrencyCode.ToString() + "," + currency.DecimalPlaces.ToString();
                string sql = sql_Currency + sValues + ")";
                object Result = null;
                if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref Result, ref Err))
                {
                    Err = "ERROR::InvoiceDB:fs:Init_Currency_Table:Err=" + Err;
                    DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.Disconnect();
                    DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.BatchOpen = false;
                    return false;
                }
            }
            DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.Disconnect();
            DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.BatchOpen = false;
            return true;
        }

        private static bool Init_Unit_Table(ref string Err)
        {
            string s_Unit_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).TableName;
            string s_col_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Unit.Name.GetType()).Name;
            string s_col_Symbol = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Unit.Symbol.GetType()).Name;
            string s_col_DecimalPlaces = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Unit.DecimalPlaces.GetType()).Name;
            string s_col_StorageOption = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Unit.StorageOption.GetType()).Name;
            string s_col_Description = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Unit.Description.GetType()).Name;

            xUnitList xUnitList = new xUnitList();

            string sql_Unit = "insert into " + s_Unit_table_name + " ( " + s_col_Name + "," + s_col_Symbol + "," + s_col_DecimalPlaces + "," + s_col_StorageOption + "," + s_col_Description + " ) values (";
            foreach (xUnit unit in xUnitList.m_DefaltUnitList)
            {
                string sStorageOptionValue = null;
                if (unit.StorageOption)
                {
                    sStorageOptionValue = "1";
                }
                else
                {
                    sStorageOptionValue = "0";
                }
                string sValues = "'" + unit.Name + "','" + unit.Symbol + "'," + unit.DecimalPlaces.ToString() + "," + sStorageOptionValue + ",'" + unit.Description + "'";
                string sql = sql_Unit + sValues + ")";
                object Result = null;
                if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref Result, ref Err))
                {
                    Err = "ERROR::InvoiceDB:fs:Init_Unit_Table:Err=" + Err;
                    return false;
                }
            }
            return true;
        }

        public static bool Init_Sample_DB(ref string Err)
        {
            if (Init_Default_DB(ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }
        }

        public static bool Read_DBSettings_StockCheckAtStartup(bool bUpgradeDone, ref string Err)
        {
            string xTextValue = null;
            bool xReadOnly = false;
            switch (GetDBSettings(DBSync.DBSync.DB_for_Blagajna.Settings.StockCheckAtStartup.Name,
                                   ref xTextValue,
                                   ref xReadOnly,
                                   ref Err))
            {
                case enum_GetDBSettings.DBSettings_OK:
                    if (!xReadOnly)
                    {
                        DBSync.DBSync.DB_for_Blagajna.Settings.StockCheckAtStartup.TextValue = xTextValue;
                    }
                    return true;


                case enum_GetDBSettings.Error_Load_DBSettings:
                    LogFile.Error.Show(Err);
                    return false;

                case enum_GetDBSettings.No_Data_Rows:
                    string sql_DB_StockCheckAtStartup = "insert into DBSettings ( name,textvalue,readonly ) values ('StockCheckAtStartup','1',0)";
                    object Result = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql_DB_StockCheckAtStartup, null, ref Result, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:InvoiceDB:fs:Read_DBSettings_StockCheckAtStartup:sql=" + sql_DB_StockCheckAtStartup + "\r\nErr=" + Err);
                    }
                    return true;
                //break;

                case enum_GetDBSettings.No_TextValue:
                    return false;

                case enum_GetDBSettings.No_ReadOnly:
                    return false;
                default:
                    Err = "ERROR:InvoiceDB:fs:enum_GetDBSettings not handled!";
                    return false;

            }

        }


        public static decimal GetIncrement(int_v DecimalPlaces, string_v Unit_Symbol)
        {
            if (DecimalPlaces != null)
            {
                try
                {
                    if (Unit_Symbol == null)
                    {
                        double y = -DecimalPlaces.v;
                        decimal dincrement = (decimal)Math.Pow(10, y);
                        return dincrement;
                    }
                    else
                    {
                        if (Unit_Symbol.v.Equals("kom."))
                        {
                            return 1;
                        }
                        else
                        {
                            double y = -DecimalPlaces.v;
                            decimal dincrement = (decimal)Math.Pow(10, y);
                            return dincrement;
                        }
                    }

                }
                catch
                {
                    return 1M;
                }
            }
            else
            {
                return 1M;
            }
        }


        public static bool ExpiryCheckData(ref DataTable dt_ExpiryCheck)
        {
            int iLimit = 10009;
            string sql = @"select " + DBSync.DBSync.sTop(iLimit) + @"
                                    Stock_$_ppi_$_i_$$Code,
                                    Stock_$_ppi_$_i_$$UniqueName,
                                    Stock_$$ExpiryDate,
                                    Stock_$$dQuantity,
                                    Stock_$_ppi_$_i_$_exp_$$SaleBeforeExpiryDateInDays,
                                    Stock_$_ppi_$_i_$_exp_$$DiscardBeforeExpiryDateInDays,
                                    Stock_$$ImportTime,
                                    Stock_$_ppi_$_pp_$_sup_$_org_$$Name,
                                    Stock_$_ppi_$_pp_$_ref_$$ReferenceNote
                                    from stock_view where Stock_$$dQuantity > 0 and (Stock_$$ExpiryDate is not null) order by Stock_$$ExpiryDate asc " + DBSync.DBSync.sLimit(iLimit);
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_ExpiryCheck, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR::InvoiceDB:fs:ExpiryCheck:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool ExpiryCheck(ref DataTable dt_ExpiryCheck, ref bool ExpiryItemsFound,ref string sNoExpiryDate, ref string sNoSaleBeforeExpiryDateInDays, ref string sNoDiscardBeforeExpiryDateInDays)
        {
            sNoExpiryDate = null;
            sNoSaleBeforeExpiryDateInDays = null;
            sNoDiscardBeforeExpiryDateInDays = null;
            ExpiryItemsFound = false;
            if (fs.ExpiryCheckData(ref dt_ExpiryCheck))
            {
                if (dt_ExpiryCheck.Rows.Count > 0)
                {
                    int iSaleBeforeExpiryDateInDays_COUNT = 0;
                    int iDiscardBeforeExpiryDateInDays_COUNT = 0;
                    foreach (DataRow dr in dt_ExpiryCheck.Rows)
                    {
                        DateTime dt_Expiry_Date;
                        int iSaleBeforeExpiryDateInDays;
                        int iDiscardBeforeExpiryDateInDays;
                        string sUniqueName = null;
                        object oUniqueName = dr["Stock_$_ppi_$_i_$$UniqueName"];
                        if (oUniqueName is string)
                        {
                            sUniqueName = (string)oUniqueName;
                        }
                        object odt_Expiry_Date = dr["Stock_$$ExpiryDate"];

                        if (odt_Expiry_Date is DateTime)
                        {
                            dt_Expiry_Date = (DateTime)odt_Expiry_Date;
                            object oSaleBeforeExpiryDateInDays = dr["Stock_$_ppi_$_i_$_exp_$$SaleBeforeExpiryDateInDays"];
                            if (oSaleBeforeExpiryDateInDays is int)
                            {
                                iSaleBeforeExpiryDateInDays = (int)oSaleBeforeExpiryDateInDays;
                                object oiDiscardBeforeExpiryDateInDays = dr["Stock_$_ppi_$_i_$_exp_$$DiscardBeforeExpiryDateInDays"];
                                if (oiDiscardBeforeExpiryDateInDays is int)
                                {
                                    iDiscardBeforeExpiryDateInDays = (int)oiDiscardBeforeExpiryDateInDays;
                                    DateTime datet_SaleBeforeExpiryDateInDays = dt_Expiry_Date.AddDays(-iSaleBeforeExpiryDateInDays);
                                    DateTime datet_DiscardBeforeExpiryDateInDays = dt_Expiry_Date.AddDays(-iDiscardBeforeExpiryDateInDays);
                                    DateTime dtNow = DateTime.Now;
                                    if (dtNow.CompareTo(datet_DiscardBeforeExpiryDateInDays) > 0)
                                    {
                                        iDiscardBeforeExpiryDateInDays_COUNT++;
                                    }
                                    else
                                    {
                                        if (dtNow.CompareTo(datet_SaleBeforeExpiryDateInDays) > 0)
                                        {
                                            iSaleBeforeExpiryDateInDays_COUNT++;
                                        }
                                    }
                                }
                                else
                                {
                                    if (sUniqueName != null)
                                    {
                                        if (sNoDiscardBeforeExpiryDateInDays == null)
                                        {
                                            sNoDiscardBeforeExpiryDateInDays = sUniqueName;
                                        }
                                        else
                                        {
                                            sNoDiscardBeforeExpiryDateInDays += "|*|" + sUniqueName;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (sUniqueName != null)
                                {
                                    if (sNoSaleBeforeExpiryDateInDays == null)
                                    {
                                        sNoSaleBeforeExpiryDateInDays = sUniqueName;
                                    }
                                    else
                                    {
                                        sNoSaleBeforeExpiryDateInDays += "|*|" + sUniqueName;
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (sUniqueName != null)
                            {
                                if (sNoExpiryDate == null)
                                {
                                    sNoExpiryDate = sUniqueName;
                                }
                                else
                                {
                                    sNoExpiryDate += "|*|" + sUniqueName;
                                }
                            }
                        }
                    }
                    if (iSaleBeforeExpiryDateInDays_COUNT + iDiscardBeforeExpiryDateInDays_COUNT > 0)
                    {
                        ExpiryItemsFound = true;
                    }
                }
                else
                {
                    ExpiryItemsFound = false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Get_JOURNAL_TYPE(string JOURNAL_TYPE_table_name, string stype_name, ref long ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_name = "@par_type_name";
            SQL_Parameter par_name = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, stype_name);
            string sql = " select ID from " + JOURNAL_TYPE_table_name + " where Name = " + spar_name;
            lpar.Add(par_name);
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ID = (long)dt.Rows[0][0];
                    return true;
                }
                else
                {
                    sql = "  insert into " + JOURNAL_TYPE_table_name + " (Name) values (" + spar_name + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref ID, ref oret, ref Err, JOURNAL_TYPE_table_name))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR::InvoiceDB:fs:Get_JOURNAL_TYPE:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR::InvoiceDB:fs:Get_JOURNAL_TYPE:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static string GetGroupCondition(ref List<SQL_Parameter> lpar, string[] s_name)
        {
            string s_group_condition = null;
            string spar_s3_name = "@par_s3_name";
            string spar_s2_name = "@par_s2_name";
            string spar_s1_name = "@par_s1_name";
            if (lpar == null)
            {
                lpar = new List<SQL_Parameter>();
            }

            if (s_name.Count() == 3)
            {
                if (s_name[2] != null)
                {
                    SQL_Parameter par3 = new SQL_Parameter(spar_s3_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, s_name[2]);
                    SQL_Parameter par2 = new SQL_Parameter(spar_s2_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, s_name[1]);
                    SQL_Parameter par1 = new SQL_Parameter(spar_s2_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, s_name[0]);
                    lpar.Add(par3);
                    lpar.Add(par2);
                    lpar.Add(par1);
                    s_group_condition = " and s3.Name = " + spar_s3_name + " and s2.Name = " + spar_s2_name + " and s1.Name = " + spar_s1_name + " ";
                }
                else if (s_name[1] != null)
                {
                    SQL_Parameter par2 = new SQL_Parameter(spar_s2_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, s_name[1]);
                    SQL_Parameter par1 = new SQL_Parameter(spar_s1_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, s_name[0]);
                    lpar.Add(par2);
                    lpar.Add(par1);
                    s_group_condition = " and s3.Name is null and s2.Name = " + spar_s2_name + " and s1.Name = " + spar_s1_name + " ";
                }
                else if (s_name[0] != null)
                {
                    SQL_Parameter par1 = new SQL_Parameter(spar_s1_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, s_name[0]);
                    lpar.Add(par1);
                    s_group_condition = " and s3.Name is null and s2.Name is null and s1.Name = " + spar_s1_name + " ";
                }
                else
                {
                    s_group_condition = " and s3.Name is null and s2.Name is null and s1.Name is null";
                }
            }
            else if (s_name.Count() == 2)
            {
                if (s_name[1] != null)
                {
                    SQL_Parameter par2 = new SQL_Parameter(spar_s2_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, s_name[1]);
                    SQL_Parameter par1 = new SQL_Parameter(spar_s1_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, s_name[0]);
                    lpar.Add(par2);
                    lpar.Add(par1);
                    s_group_condition = " and s3.Name is null and s2.Name = " + spar_s2_name + " and s1.Name = " + spar_s1_name + " ";
                }
                else if (s_name[0] != null)
                {
                    SQL_Parameter par1 = new SQL_Parameter(spar_s1_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, s_name[0]);
                    lpar.Add(par1);
                    s_group_condition = " and s3.Name is null and s2.Name is null and s1.Name = " + spar_s1_name + " ";
                }
                else
                {
                    s_group_condition = " and s3.Name is null and s2.Name is null and s1.Name is null";
                }
            }
            else if (s_name.Count() == 1)
            {
                if (s_name[0] != null)
                {
                    SQL_Parameter par1 = new SQL_Parameter(spar_s1_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, s_name[0]);
                    lpar.Add(par1);
                    s_group_condition = " and s3.Name is null and s2.Name is null and s1.Name = " + spar_s1_name + " ";
                }
                else
                {
                    s_group_condition = " and s3.Name is null and s2.Name is null and s1.Name is null";
                }
            }
            else
            {
                s_group_condition = "";
            }
            return s_group_condition;
        }

        public static bool Get_ID(string TableName, string col_name, string_v svalue, ref ID_v iD_v, ref string Err)
        {
            DataTable dt = new DataTable();
            string spar = "@par_svalue";
            string scond = col_name + " is null";
            string sval = "null";
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            if (svalue != null)
            {
                SQL_Parameter par_svalue = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, svalue.v);
                lpar.Add(par_svalue);
                scond = " " + col_name + " = " + spar + " ";
                sval = spar;
            }

            string sql_select = "select ID from " + TableName + " where " + scond;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (iD_v == null)
                    {
                        iD_v = new ID_v();
                    }
                    iD_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    string sql_insert = " insert into " + TableName + " (" + col_name + ") values (" + spar + ")";
                    object oret = null;
                    long id = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, null, ref id, ref oret, ref Err, TableName))
                    {
                        if (iD_v == null)
                        {
                            iD_v = new ID_v();
                        }
                        iD_v.v = id;
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool GetID(string TableName, string[] columns, string[] values, List<DBConnectionControl40.SQL_Parameter> lpar, ref long ID, ref string Err)
        {

            string sql = null;
            string sColumns = null;
            string sValues = null;
            string sWhere = null;
            int iColumnsCount = columns.Count();
            int iValuesCount = values.Count();
            if (iColumnsCount == iValuesCount)
            {
                int i;
                for (i = 0; i < iColumnsCount; i++)
                {
                    string scol = columns[i];
                    string sval = values[i];
                    if (sColumns == null)
                    {
                        sColumns = scol;
                        if (!scol.ToLower().Equals("image_data"))
                        {
                            if (sWhere == null)
                            {
                                if (sval.Equals("null"))
                                {
                                    sWhere = scol + " is " + sval;
                                }
                                else
                                {
                                    sWhere = scol + " = " + sval;
                                }
                            }
                        }
                        sValues = sval;
                    }
                    else
                    {
                        sColumns += "," + scol;
                        if (!scol.ToLower().Equals("image_data"))
                        {
                            if (sWhere == null)
                            {
                                if (sval.Equals("null"))
                                {
                                    sWhere = scol + " is " + sval;
                                }
                                else
                                {
                                    sWhere = scol + " = " + sval;
                                }
                            }
                            else
                            {
                                if (sval.Equals("null"))
                                {
                                    sWhere += " and " + scol + " is " + sval;
                                }
                                else
                                {
                                    sWhere += " and " + scol + " = " + sval;
                                }
                            }
                        }
                        sValues += "," + sval;
                    }
                }
            }
            else
            {
                Err = "ERROR::InvoiceDB:fs:Columns count not equal to values count!\r\niColumnsCount = " + iColumnsCount.ToString() + ", iValuesCount = " + iValuesCount.ToString();
                return false;
            }
            sql = "select ID from " + TableName + " where " + sWhere;
            DataTable dt = new DataTable();
            object objret = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into " + TableName + " (" + sColumns + ") values (" + sValues + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref ID, ref objret, ref Err, TableName))
                    {
                        return true;
                    }
                    else
                    {
                        Err = Err + "\r\n sql = " + sql;
                        return false;
                    }
                }
            }
            else
            {
                Err = Err + "\r\n sql = " + sql;
                return false;
            }

        }

        public static bool Get_cAddres_Org_ID(string StreetName,
                                      string HouseNumber,
                                      string ZIP,
                                      string City,
                                      string Country,
                                      ref long cAddres_Org_ID, ref string Err)
        {

            long cStreetName_Org_ID = -1;
            if (!GetID("cStreetName_Org", new string[] { "StreetName" }, new string[] { "'" + StreetName + "'" }, null, ref cStreetName_Org_ID, ref Err))
            {
                return false;
            }
            long cHouseNumber_Org_ID = -1;
            if (!GetID("cHouseNumber_Org", new string[] { "HouseNumber" }, new string[] { "'" + HouseNumber + "'" }, null, ref cHouseNumber_Org_ID, ref Err))
            {
                return false;
            }
            long cZIP_Org_ID = -1;
            if (!GetID("cZIP_Org", new string[] { "ZIP" }, new string[] { "'" + ZIP + "'" }, null, ref cZIP_Org_ID, ref Err))
            {
                return false;
            }

            long cCity_Org_ID = -1;
            if (!GetID("cCity_Org", new string[] { "City" }, new string[] { "'" + City + "'" }, null, ref cCity_Org_ID, ref Err))
            {
                return false;
            }

            long cCountry_Org_ID = -1;
            if (!GetID("cCountry_Org", new string[] { "Country" }, new string[] { "'" + Country+ "'" }, null, ref cCountry_Org_ID, ref Err))
            {
                return false;
            }

            if (GetID("cAddress_Org", new string[] { "cStreetName_Org_ID", "cHouseNumber_Org_ID", "cCity_Org_ID", "cZIP_Org_ID", "cCountry_Org_ID" }, new string[] { cStreetName_Org_ID.ToString(),
                                                                                                                                                                    cHouseNumber_Org_ID.ToString(),
                                                                                                                                                                    cCity_Org_ID.ToString(),
                                                                                                                                                                    cZIP_Org_ID.ToString(),
                                                                                                                                                                    cCountry_Org_ID.ToString()},
                                                                                                                                                                    null, ref cAddres_Org_ID, ref Err))
            {
                return true;
            }
            {
                return false;
            }

        }


        public static bool Get_OrganisationData_ID(string Name,
                                                   string StreetName,
                                                   string HouseNumber,
                                                   string ZIP,
                                                   string City,
                                                   string Country,
                                                   string_v TRR,
                                                   long_v Tax_ID,
                                                   string_v Registration_ID,
                                                   string Bank_Name,
                                                   long_v Bank_Tax_ID,
                                                   string_v Bank_Registration_ID,
                                                   string_v AccountDescription,
                                                   string OrgTYPE,
                                                   string HomePage,
                                                   string Email,
                                                   string PhoneNumber,
                                                   string FaxNumber,
                                                   ref long Organisation_id,
                                                   ref long OrganisationAccount_id,
                                                   ref long OrganisationData_id,
                                                   ref string Err)
        {
            long cAddres_Org_ID = -1;
            if (Get_cAddres_Org_ID(StreetName, HouseNumber, ZIP, City, Country, ref cAddres_Org_ID, ref Err))
            {
                if (Get_Organisation_ID_and_OrganisationAccount_ID(Name, Tax_ID, Registration_ID, Bank_Name, Bank_Tax_ID, Bank_Registration_ID, TRR, AccountDescription, ref Organisation_id, ref OrganisationAccount_id, ref Err))
                {
                    long cOrgTYPE_id = -1;
                    if (!GetID("cOrgTYPE", new string[] { "OrganisationTYPE" }, new string[] { "'" + OrgTYPE + "'" }, null, ref cOrgTYPE_id, ref Err))
                    {
                        return false;
                    }


                    long cHomePage_Org_id = -1;
                    if (!GetID("cHomePage_Org", new string[] { "HomePage" }, new string[] { "'" + HomePage + "'" }, null, ref cHomePage_Org_id, ref Err))
                    {
                        return false;
                    }


                    long cEmail_Org_id = -1;
                    if (!GetID("cEmail_Org", new string[] { "Email" }, new string[] { "'" + Email + "'" }, null, ref cEmail_Org_id, ref Err))
                    {
                        return false;
                    }

                    long cPhoneNumber_Org_id = -1;
                    if (!GetID("cPhoneNumber_Org", new string[] { "PhoneNumber" }, new string[] { "'" + PhoneNumber + "'" }, null, ref cPhoneNumber_Org_id, ref Err))
                    {
                        return false;
                    }

                    long cFaxNumber_Org_id = -1;
                    if (!GetID("cFaxNumber_Org", new string[] { "FaxNumber" }, new string[] { "'" + FaxNumber + "'" }, null, ref cFaxNumber_Org_id, ref Err))
                    {
                        return false;
                    }
                    if (GetID("OrganisationData", new string[] { "Organisation_ID",
                                                                  "cOrgTYPE_ID",
                                                                  "cAddress_Org_ID",
                                                                  "cPhoneNumber_Org_ID",
                                                                  "cFaxNumber_Org_ID",
                                                                  "cEmail_Org_ID",
                                                                  "cHomePage_Org_ID"
                                                                  }, new string[] { Organisation_id.ToString(),
                                                                                    cOrgTYPE_id.ToString(),
                                                                                    cAddres_Org_ID.ToString(),
                                                                                    cPhoneNumber_Org_id.ToString(),
                                                                                    cFaxNumber_Org_id.ToString(),
                                                                                    cEmail_Org_id.ToString(),
                                                                                    cHomePage_Org_id.ToString()
                                                                                    }, null, ref OrganisationData_id, ref Err))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool Get_Organisation_ID_and_OrganisationAccount_ID(string Organisation_Name,
                                       long_v Organisation_Tax_ID,
                                       string_v Organisation_Registration_ID,
                                       string Bank_Name,
                                       long_v Bank_Tax_ID,
                                       string_v Bank_Registration_ID,
                                       string_v TRR,
                                       string_v AccountDescription,
                                       ref long Organisation_id,
                                       ref long OrganisationAccount_id,
                                       ref string Err)
        {
            string sOrganisation_Tax_ID = null;
            if (Organisation_Tax_ID != null)
            {
                sOrganisation_Tax_ID = Organisation_Tax_ID.v.ToString();
            }
            else
            {
                sOrganisation_Tax_ID = "null";
            }

            string sOrganisation_Registration_ID = null;
            if (Organisation_Tax_ID != null)
            {
                sOrganisation_Registration_ID = "'" + Organisation_Registration_ID.v + "'";
            }
            else
            {
                sOrganisation_Registration_ID = "null";
            }

            string sBank_Tax_ID = null;
            if (Bank_Tax_ID != null)
            {
                sBank_Tax_ID = Bank_Tax_ID.v.ToString();
            }
            else
            {
                sBank_Tax_ID = "null";
            }

            string sBank_Registration_ID = null;
            if (Bank_Tax_ID != null)
            {
                sBank_Registration_ID = "'" + Bank_Registration_ID.v + "'";
            }
            else
            {
                sBank_Registration_ID = "null";
            }
            string sTRR = null;
            if (TRR != null)
            {
                sTRR = "'" + TRR.v + "'";
            }
            else
            {
                sTRR = "null";
            }

            string sAccountDescription = null;
            if (AccountDescription != null)
            {
                sAccountDescription = "'" + AccountDescription.v + "'";
            }
            else
            {
                sAccountDescription = "null";
            }


            if (GetID("Organisation", new string[] { "Name", "Tax_ID", "Registration_ID" }, new string[] { "'" + Organisation_Name + "'", sOrganisation_Tax_ID, sOrganisation_Registration_ID }, null, ref Organisation_id, ref Err))
            {
                long Bank_Organisation_id = -1;
                if (Bank_Name == null)
                {
                    return true;
                }
                else
                {
                    if (GetID("Organisation", new string[] { "Name", "Tax_ID", "Registration_ID" }, new string[] { "'" + Bank_Name + "'", sBank_Tax_ID, sBank_Registration_ID }, null, ref Bank_Organisation_id, ref Err))
                    {
                        long Bank_ID = -1;
                        if (GetID("Bank", new string[] { "Organisation_ID" }, new string[]
                                                                    {
                                                                      Bank_Organisation_id.ToString()}, null, ref Bank_ID, ref Err))
                        {
                            long BankAccount_ID = -1;
                            if (GetID("BankAccount", new string[] { "Bank_ID", "TRR", "Active", "Description" }, new string[]
                                                                        {
                                                                          Bank_ID.ToString(),
                                                                          sTRR,
                                                                          "1",
                                                                          sAccountDescription
                                                                         }, null, ref BankAccount_ID, ref Err))
                            {

                                if (GetID("OrganisationAccount", new string[] { "BankAccount_ID",
                                                                             "Organisation_ID"
                                                                            }, new string[]
                                                                            {
                                                                              BankAccount_ID.ToString(),
                                                                              Organisation_id.ToString()}
                                                                              , null, ref OrganisationAccount_id, ref Err))
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
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Get_Person_ID(bool Gender, string FirstName, string LastName, DateTime DateOfBirth, long_v TaxID, string_v Registration_ID, ref long Person_ID, ref string Err)
        {
            long cFirstName_ID = -1;
            if (fs.GetID("cFirstName", new string[] { "FirstName" }, new string[] { "'" + FirstName + "'" }, null, ref cFirstName_ID, ref Err))
            {
                long cLastName_ID = -1;
                if (fs.GetID("cLastName", new string[] { "LastName" }, new string[] { "'" + LastName + "'" }, null, ref cLastName_ID, ref Err))
                {
                    List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                    string spar_DateOfBirth = "@par_DateOfBirth";
                    DBConnectionControl40.SQL_Parameter par_DateOfBirth = new SQL_Parameter(spar_DateOfBirth, SQL_Parameter.eSQL_Parameter.Datetime, false, DateOfBirth);
                    lpar.Add(par_DateOfBirth);
                    string sTax_ID = null;
                    if (TaxID != null)
                    {
                        sTax_ID = TaxID.v.ToString();
                    }
                    else
                    {
                        sTax_ID = "null";
                    }
                    string sRegistration_ID = null;
                    if (Registration_ID != null)
                    {
                        sRegistration_ID = "'" + Registration_ID.v.ToString() + "'";
                    }
                    else
                    {
                        sRegistration_ID = "null";
                    }

                    if (GetID("Person", new string[] { "Gender", "cFirstName_ID", "cLastName_ID", "DateOfBirth", "Tax_ID", "Registration_ID" }, new string[] { "0", cFirstName_ID.ToString(), cLastName_ID.ToString(), spar_DateOfBirth, sTax_ID, sRegistration_ID }, lpar, ref Person_ID, ref Err))
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
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public static bool Get_Person_ID_and_PersonAccount_ID(string FirstName,
                                                              string LastName,
                                                              DateTime DateOfBirth,
                                                              long_v TaxID,
                                                              string_v Registration_ID,
                                                              string Bank_Name,
                                                              long_v Bank_TaxID,
                                                              string_v Bank_Registration_ID,
                                                              string_v TRR,
                                                              string_v BankAccount_Description,
                                                              bool BankAccount_Active,
                                                              ref long Person_id,
                                                              ref long PersonAccount_id,
                                                              ref string Err)
        {
            if (Get_Person_ID(false, FirstName, LastName, DateOfBirth, TaxID, Registration_ID, ref Person_id, ref Err))
            {
                long Bank_Organisation_id = -1;
                string sBank_TaxID = null;
                if (Bank_TaxID != null)
                {
                    sBank_TaxID = Bank_TaxID.v.ToString();
                }
                else
                {
                    sBank_TaxID = "null";
                }
                string sBank_Registration_ID = null;
                if (Bank_Registration_ID != null)
                {
                    sBank_Registration_ID = "'" + Bank_Registration_ID.v + "'";
                }
                else
                {
                    sBank_Registration_ID = "null";
                }

                string sTRR = null;
                if (TRR != null)
                {
                    sTRR = "'" + TRR.v + "'";
                }
                else
                {
                    sTRR = "null";
                }

                string sBankAccount_Active = "0";
                if (BankAccount_Active)
                {
                    sBankAccount_Active = "1";
                }

                string sBankAccount_Description = null;
                if (BankAccount_Description != null)
                {
                    sBankAccount_Description = "'" + BankAccount_Description.v + "'";
                }
                else
                {
                    sBankAccount_Description = "null";
                }


                if (GetID("Organisation", new string[] { "Name", "Tax_ID", "Registration_ID" }, new string[] { "'" + Bank_Name + "'", sBank_TaxID, sBank_Registration_ID }, null, ref Bank_Organisation_id, ref Err))
                {
                    long Bank_ID = -1;
                    if (GetID("Bank", new string[] { "Organisation_ID" }, new string[]
                                                                {
                                                                  Bank_Organisation_id.ToString()}, null, ref Bank_ID, ref Err))
                    {
                        long BankAccount_ID = -1;
                        if (GetID("BankAccount", new string[] { "Bank_ID", "TRR", "Active", "Description" }, new string[]
                                                                    {
                                                                      Bank_ID.ToString(),
                                                                      sTRR,
                                                                      sBankAccount_Active,
                                                                      sBankAccount_Description
                                                                     }, null, ref BankAccount_ID, ref Err))
                        {
                            if (GetID("PersonAccount", new string[] { "BankAccount_ID",
                                                                             "Person_ID"
                                                                            }, new string[]
                                                                            {
                                                                              BankAccount_ID.ToString(),
                                                                              Person_id.ToString()}
                                                                          , null, ref PersonAccount_id, ref Err))
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
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string GetFursDecimalString(decimal d)
        {
            d = decimal.Round(d, 2);
            string s = d.ToString();
            int icomma = s.IndexOf(',');
            if (s.Contains(","))
            {
                s = s.Replace(',', '.');
            }

            icomma = s.IndexOf('.');
            if (icomma >= 0)
            {
                int len = s.Length;
                while (s.Length < icomma + 3)
                {
                    s = s + "0";
                }
            }
            else
            {
                s = s + ".00";
            }
            return s;
        }


        public static bool WriteRow(string TableName, DataRow dr, string Column_PrefixTable, bool Those_from_Column_PrefixTable, ref long id)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            int iColumnsCount = dr.Table.Columns.Count;
            int iCol = 0;
            string sParams = null;
            string sValues = null;
            string sql = "insert into " + TableName + "(";
            for (iCol = 0; iCol < iColumnsCount; iCol++)
            {
                Add_lpar(dr.Table.Columns[iCol], dr[iCol], Column_PrefixTable, Those_from_Column_PrefixTable, ref lpar, ref sParams, ref sValues);
            }
            sql += sParams + ")values(" + sValues + ")";
            object objret = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref objret, ref Err, TableName))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:WriteRow:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private static void Add_lpar(DataColumn dataColumn, object value, string Column_PrefixTable, bool Those_from_Column_PrefixTable, ref List<SQL_Parameter> lpar, ref string sParams, ref string sValues)
        {
            string sColName = dataColumn.ColumnName;
            if (sColName.ToLower().Equals("id"))
            {
                return;
            }
            if (Column_PrefixTable != null)
            {
                int iColumn_PrefixTable_Length = Column_PrefixTable.Length;
                if (sColName.Length > iColumn_PrefixTable_Length)
                {
                    if (sColName.Substring(0, iColumn_PrefixTable_Length).Equals(Column_PrefixTable))
                    {
                        if (Those_from_Column_PrefixTable)
                        {
                            sColName = sColName.Substring(iColumn_PrefixTable_Length);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (Those_from_Column_PrefixTable)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    if (Those_from_Column_PrefixTable)
                    {
                        return;
                    }
                }
            }
            string spar_name = "@par_" + sColName;
            string sValue = "null";
            if (value != null)
            {
                if (!(value is System.DBNull))
                {
                    SQL_Parameter par = new SQL_Parameter(spar_name, Get_SQL_Param_type(dataColumn.DataType), false, value);
                    lpar.Add(par);
                    sValue = spar_name;
                }
            }
            if (sParams == null)
            {
                sParams = sColName;
            }
            else
            {
                sParams += "," + sColName;
            }
            if (sValues == null)
            {
                sValues = sValue;
            }
            else
            {
                sValues += "," + sValue;
            }
        }

        private static SQL_Parameter.eSQL_Parameter Get_SQL_Param_type(Type type)
        {
            if (type == typeof(System.Int64))
            {
                return SQL_Parameter.eSQL_Parameter.Bigint;
            }
            else if (type == typeof(System.Boolean))
            {
                return SQL_Parameter.eSQL_Parameter.Bit;
            }
            else if (type == typeof(System.Int32))
            {
                return SQL_Parameter.eSQL_Parameter.Int;
            }
            else if (type == typeof(System.DateTime))
            {
                return SQL_Parameter.eSQL_Parameter.Datetime;
            }
            else if (type == typeof(System.Decimal))
            {
                return SQL_Parameter.eSQL_Parameter.Decimal;
            }
            else if (type == typeof(System.String))
            {
                return SQL_Parameter.eSQL_Parameter.Nvarchar;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:Get_SQL_Param_type: Type " + type.ToString() + " not implemented!");
                return SQL_Parameter.eSQL_Parameter.Nvarchar;
            }
        }


        public static string Date_DDMMYYYY(DateTime dateTime)
        {
            string sDay = dateTime.Day.ToString();
            if (sDay.Length == 1)
            {
                sDay = '0' + sDay;
            }
            string sMonth = dateTime.Month.ToString();
            if (sMonth.Length == 1)
            {
                sMonth = '0' + sMonth;
            }
            string sYear = dateTime.Year.ToString();
            return sDay + sMonth + sYear;
        }

        public static string Time_HH_MM(char delimiter, DateTime dateTime)
        {
            string sHour = dateTime.Hour.ToString();
            if (sHour.Length == 1)
            {
                sHour = '0' + sHour;
            }
            string sMinute = dateTime.Minute.ToString();
            if (sMinute.Length == 1)
            {
                sMinute = '0' + sMinute;
            }
            return sHour + delimiter + sMinute;
        }

        public static string Decimal2String(decimal value, int places)
        {
            decimal d = decimal.Round(value, places);
            string s = Convert.ToString(d);
            int icomma = s.IndexOf(',');
            if (icomma > 0)
            {
                string sDecimals = s.Substring(icomma);
                if (sDecimals.Length < 3)
                {
                    s += "0";
                }
            }
            else
            {
                s += ",00";
            }
            return s;
        }

        public static string DateTime2String(DateTime t)
        {
            string s = fmt_number2string(t.Day, 2) + "." + fmt_number2string(t.Month, 2) + "." + fmt_number2string(t.Year, 4) + " " + fmt_number2string(t.Hour, 2) + ":" + fmt_number2string(t.Minute, 2);
            return s;
        }

        private static string fmt_number2string(int inum, int length)
        {
            string s = null;
            try
            {
                s = Convert.ToString(inum);
                if (s.Length < length)
                {
                    while (s.Length < length)
                    {
                        s = '0' + s;
                    }
                }
                else if (s.Length > length)
                {
                    LogFile.Error.Show("ERROR:fs:fmt_number2string:Cannot convert inum=" + inum.ToString() + " to string of length = " + length.ToString());
                }
                return s;
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("ERROR:fs:fmt_number2string:Cannot convert Exception =" + ex.Message);
                return "";
            }
        }


        public static object String2Date_DDMMYYYY_HH_MM(string Datum_Racuna_DDMMLL, string sTime_HH_MM)
        {
            int year;
            int day;
            int month;
            int hour;
            int minute;

            if (Datum_Racuna_DDMMLL == null)
            {
                return System.DBNull.Value;
            }
            if (Datum_Racuna_DDMMLL.Length == 0)
            {
                return System.DBNull.Value;
            }

            string sDay = Datum_Racuna_DDMMLL.Substring(0, 2);
            string sMonth = Datum_Racuna_DDMMLL.Substring(2, 2);
            string sYear = Datum_Racuna_DDMMLL.Substring(4);

            string sHour;
            string sMinute;
            sHour = "0";
            sMinute = "0";
            if (sTime_HH_MM == null)
            {
                return System.DBNull.Value;
            }
            else if (sTime_HH_MM.Length == 0)
            {
                return System.DBNull.Value;
            }
            else
            {
                sHour = sTime_HH_MM.Substring(0, 2);
                sMinute = sTime_HH_MM.Substring(3);
            }

            try
            {
                day = Convert.ToInt32(sDay);
                month = Convert.ToInt32(sMonth);
                year = Convert.ToInt32(sYear);
                hour = Convert.ToInt32(sHour);
                minute = Convert.ToInt32(sMinute);

                DateTime dt = new DateTime(year, month, day, hour, minute, 0);
                return dt;
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("ERROR:String2Date_DDMMYYYY:Datum_Racuna_DDMMLL=" + Datum_Racuna_DDMMLL + "; Exception =" + ex.Message);
                DateTime dt = DateTime.MinValue;
                return dt;
            }
        }

        public static string GetFURS_Time_Formated(DateTime dtime)
        {
            return fs.GetString(dtime.Year, 4) + "-"
            + fs.GetString(dtime.Month, 2) + "-"
            + fs.GetString(dtime.Day, 2) + "T"
            + fs.GetString(dtime.Hour, 2) + ":"
            + fs.GetString(dtime.Minute, 2) + ":"
            + fs.GetString(dtime.Second, 2);
        }

        public static object String2Decimal(string sdec)
        {
            decimal d = 0;
            try
            {
                if (sdec == null)
                {
                    object o = System.DBNull.Value;
                    return o;
                }
                if (sdec.Length == 0)
                {
                    object o = System.DBNull.Value;
                    return o;
                }
                d = Convert.ToDecimal(sdec);
                return d;
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("ERROR:String2Date_DDMMYYYY:sdec=" + sdec + "; Exception =" + ex.Message);
                return 0;
            }
        }

        public static object String2Int(string snum)
        {
            int i = 0;
            try
            {
                if (snum == null)
                {
                    object o = System.DBNull.Value;
                    return o;
                }
                if (snum.Length == 0)
                {
                    object o = System.DBNull.Value;
                    return o;
                }
                i = Convert.ToInt32(snum);
                return i;
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("ERROR:String2Date_DDMMYYYY:snum=" + snum + "; Exception =" + ex.Message);
                object o = System.DBNull.Value;
                return o;
            }
        }

        public static bool Get_Atom_cAddress_Person_ID(string_v StreetName_v, string_v HouseNumber_v, string_v ZIP_v, string_v City_v, string_v Country_v, string_v State_v, ref long_v Atom_cAddress_Person_ID_v)
        {
            if ((StreetName_v == null) || (HouseNumber_v == null) || (ZIP_v == null) || (City_v == null) || (Country_v == null))
            {
                Atom_cAddress_Person_ID_v = null;
                return true;
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            long_v Atom_cStreetName_Person_ID_v = null;
            if (!Get_string_table_ID("Atom_cStreetName_Person", "StreetName", StreetName_v, ref Atom_cStreetName_Person_ID_v))
            {
                return false;
            }
            string Atom_cStreetName_Person_ID_cond = null;
            string Atom_cStreetName_Person_ID_value = null;
            if (!AddPar("Atom_cStreetName_Person_ID", ref lpar, Atom_cStreetName_Person_ID_v, ref Atom_cStreetName_Person_ID_cond, ref Atom_cStreetName_Person_ID_value))
            {
                return false;
            }
            long_v Atom_cHouseNumber_Person_ID_v = null;
            if (!Get_string_table_ID("Atom_cHouseNumber_Person", "HouseNumber", HouseNumber_v, ref Atom_cHouseNumber_Person_ID_v))
            {
                return false;
            }
            string Atom_cHouseNumber_Person_ID_cond = null;
            string Atom_cHouseNumber_Person_ID_value = null;
            if (!AddPar("Atom_cHouseNumber_Person_ID", ref lpar, Atom_cHouseNumber_Person_ID_v, ref Atom_cHouseNumber_Person_ID_cond, ref Atom_cHouseNumber_Person_ID_value))
            {
                return false;
            }
            long_v Atom_cZIP_Person_ID_v = null;
            if (!Get_string_table_ID("Atom_cZIP_Person", "ZIP", ZIP_v, ref Atom_cZIP_Person_ID_v))
            {
                return false;
            }
            string Atom_cZIP_Person_ID_cond = null;
            string Atom_cZIP_Person_ID_value = null;
            if (!AddPar("Atom_cZIP_Person_ID", ref lpar, Atom_cZIP_Person_ID_v, ref Atom_cZIP_Person_ID_cond, ref Atom_cZIP_Person_ID_value))
            {
                return false;
            }
            long_v Atom_cCity_Person_ID_v = null;
            if (!Get_string_table_ID("Atom_cCity_Person", "City", City_v, ref Atom_cCity_Person_ID_v))
            {
                return false;
            }
            string Atom_cCity_Person_ID_cond = null;
            string Atom_cCity_Person_ID_value = null;
            if (!AddPar("Atom_cCity_Person_ID", ref lpar, Atom_cCity_Person_ID_v, ref Atom_cCity_Person_ID_cond, ref Atom_cCity_Person_ID_value))
            {
                return false;
            }
            long_v Atom_cCountry_Person_ID_v = null;
            if (!Get_string_table_ID("Atom_cCountry_Person", "Country", Country_v, ref Atom_cCountry_Person_ID_v))
            {
                return false;
            }
            string Atom_cCountry_Person_ID_cond = null;
            string Atom_cCountry_Person_ID_value = null;
            if (!AddPar("Atom_cCountry_Person_ID", ref lpar, Atom_cCountry_Person_ID_v, ref Atom_cCountry_Person_ID_cond, ref Atom_cCountry_Person_ID_value))
            {
                return false;
            }
            long_v Atom_cState_Person_ID_v = null;
            if (!Get_string_table_ID("Atom_cState_Person", "State", State_v, ref Atom_cState_Person_ID_v))
            {
                return false;
            }
            string Atom_cState_Person_ID_cond = null;
            string Atom_cState_Person_ID_value = null;
            if (!AddPar("Atom_cState_Person_ID", ref lpar, Atom_cState_Person_ID_v, ref Atom_cState_Person_ID_cond, ref Atom_cState_Person_ID_value))
            {
                return false;
            }

            string sql = "select ID from Atom_cAddress_Person where " + Atom_cStreetName_Person_ID_cond
                                                                     + " and " + Atom_cHouseNumber_Person_ID_cond
                                                                     + " and " + Atom_cZIP_Person_ID_cond
                                                                     + " and " + Atom_cCity_Person_ID_cond
                                                                     + " and " + Atom_cCountry_Person_ID_cond
                                                                     + " and " + Atom_cState_Person_ID_cond + " order by ID desc";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_cAddress_Person_ID_v == null)
                    {
                        Atom_cAddress_Person_ID_v = new long_v();
                    }
                    Atom_cAddress_Person_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = " insert into Atom_cAddress_Person (Atom_cStreetName_Person_ID,Atom_cHouseNumber_Person_ID,Atom_cZIP_Person_ID,Atom_cCity_Person_ID,Atom_cCountry_Person_ID,Atom_cState_Person_ID)values(" + Atom_cStreetName_Person_ID_value + "," + Atom_cHouseNumber_Person_ID_value + "," + Atom_cZIP_Person_ID_value + "," + Atom_cCity_Person_ID_value + "," + Atom_cCountry_Person_ID_value + "," + Atom_cState_Person_ID_value + ")";
                    long id = -1;
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref ores, ref Err, "Atom_cAddress_Person"))
                    {
                        if (Atom_cAddress_Person_ID_v == null)
                        {
                            Atom_cAddress_Person_ID_v = new long_v();
                        }
                        Atom_cAddress_Person_ID_v.v = id;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get_Atom_cAddress_Person_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get_Atom_cAddress_Person_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get_string_table_ID(string TableName, string ColumnName, string_v s_v, ref long_v ID_v)
        {
            List<SQL_Parameter> lpar = null;
            if (s_v == null)
            {
                ID_v = null;
                return true;
            }
            string cond = null;
            string value = null;
            if (!AddPar(ColumnName, ref lpar, s_v, ref cond, ref value))
            {
                return false;
            }

            string sql = "select id from " + TableName + " where " + cond;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ID_v = new long_v();
                    ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into " + TableName + " (" + ColumnName + ")values(" + value + ")";
                    long id = -1;
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref oret, ref Err, "Atom_cFirstName"))
                    {
                        ID_v = new long_v();
                        ID_v.v = id;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get_Atom_cFirstName_ID:" + sql + "\r\n:Err=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get_Atom_cFirstName_ID:" + sql + "\r\n:Err=" + Err);
                return false;
            }
        }

        public static bool AddPar(string spar, ref List<SQL_Parameter> lpar, object obj_v, ref string cond, ref string value)
        {
            string spar_name = "@par_" + spar;
            SQL_Parameter par = null;
            if (obj_v == null)
            {
                cond = spar + " is null ";
                value = "null";
            }
            else
            {
                if (obj_v is bool_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Bit, false, ((bool_v)obj_v).v);
                }
                else if (obj_v is string_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ((string_v)obj_v).v);
                }
                else if (obj_v is int_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Int, false, ((int_v)obj_v).v);
                }
                else if (obj_v is long_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Bigint, false, ((long_v)obj_v).v);
                }
                else if (obj_v is DateTime_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Datetime, false, ((DateTime_v)obj_v).v);
                }
                else if (obj_v is byte_array_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Varbinary, false, ((byte_array_v)obj_v).v);
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_Customer_Person:AddPar: Type " + obj_v.GetType().ToString() + " not implemented!");
                    return false;
                }
                cond = spar + " = " + spar_name;
                value = spar_name;
                if (lpar == null)
                {
                    lpar = new List<SQL_Parameter>();
                }
                lpar.Add(par);
            }
            return true;
        }
        public static bool Get_Atom_PersonImage_ID(string_v Image_Hash_v, byte_array_v Image_Data_v, ref long_v Atom_PersonImage_ID_v)
        {
            if (Image_Hash_v == null)
            {
                Atom_PersonImage_ID_v = null;
                return true;
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Image_Hash_cond = null;
            string Image_Hash_value = null;
            if (!AddPar("Image_Hash", ref lpar, Image_Hash_v, ref Image_Hash_cond, ref Image_Hash_value))
            {
                return false;
            }
            string sql = "select ID from Atom_PersonImage where " + Image_Hash_cond;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_PersonImage_ID_v == null)
                    {
                        Atom_PersonImage_ID_v = new long_v();
                    }
                    Atom_PersonImage_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    string Image_Data_cond = null;
                    string Image_Data_value = null;
                    if (!AddPar("Image_Data", ref lpar, Image_Data_v, ref Image_Data_cond, ref Image_Data_value))
                    {
                        return false;
                    }
                    sql = "insert into Atom_PersonImage (Image_Hash, Image_Data)values(" + Image_Hash_value + "," + Image_Data_value + ")";
                    long id = -1;
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref ores, ref Err, "Atom_PersonImage"))
                    {
                        if (Atom_PersonImage_ID_v == null)
                        {
                            Atom_PersonImage_ID_v = new long_v();
                        }
                        Atom_PersonImage_ID_v.v = id;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get_Atom_PersonImage_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get_Atom_PersonImage_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }


        private static int BUFFER_SIZE = 64 * 1024; //64kB

        public static byte[] Compress(byte[] inputData)
        {
            if (inputData == null)
                throw new ArgumentNullException("inputData must be non-null");

            using (var compressIntoMs = new MemoryStream())
            {
                using (var gzs = new BufferedStream(new GZipStream(compressIntoMs,
                 CompressionMode.Compress), BUFFER_SIZE))
                {
                    gzs.Write(inputData, 0, inputData.Length);
                }
                return compressIntoMs.ToArray();
            }
        }

        public static byte[] Decompress(byte[] inputData)
        {
            if (inputData == null)
                throw new ArgumentNullException("inputData must be non-null");

            using (var compressedMs = new MemoryStream(inputData))
            {
                using (var decompressedMs = new MemoryStream())
                {
                    using (var gzs = new BufferedStream(new GZipStream(compressedMs,
                     CompressionMode.Decompress), BUFFER_SIZE))
                    {
                        gzs.CopyTo(decompressedMs);
                    }
                    return decompressedMs.ToArray();
                }
            }
        }

        public static object MyConvertToShort(object v)
        {
            if (v is int)
            {
                return Convert.ToInt16(v);
            }
            else if (v is uint)
            {
                return Convert.ToInt16(v);
            }
            else if (v is long)
            {
                return Convert.ToInt16(v);
            }
            else if (v is ulong)
            {
                return Convert.ToInt16(v);
            }
            else if (v is short)
            {
                return Convert.ToInt16(v);
            }
            else if (v is ushort)
            {
                return Convert.ToInt16(v);
            }
            else
            {
                return System.DBNull.Value;
            }
        }

    }
}