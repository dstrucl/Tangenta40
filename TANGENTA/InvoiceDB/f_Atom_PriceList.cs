#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public static class f_Atom_PriceList
    {
        public static bool Get(long PriceList_ID, ref long Atom_PriceList_ID)
        {
            string Err = null;

            DataTable dt = new DataTable();
            string sql = @"select Atom_PriceList.ID
                            from Atom_PriceList 
                            inner join PriceList on Atom_PriceList.Name = PriceList.Name 
                                                    and Atom_PriceList.Valid = PriceList.Valid
                                                    and ((Atom_PriceList.ValidFrom = PriceList.ValidFrom) or (Atom_PriceList.ValidFrom is null and PriceList.ValidFrom is null))
                                                    and ((Atom_PriceList.ValidTo = PriceList.ValidTo) or (Atom_PriceList.ValidTo is null and PriceList.ValidTo is null))
                                                    and ((Atom_PriceList.Description = PriceList.Description) or (Atom_PriceList.Description is null and PriceList.Description is null))
                            inner join Currency on PriceList.Currency_ID = Currency.ID
                            inner join Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID 
                            where Currency.Abbreviation = Atom_Currency.Abbreviation and
                                  PriceList.ID = " + PriceList_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_PriceList_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    xPriceList m_xPriceList = new xPriceList();
                    sql = "select Currency_ID from PriceList where PriceList.ID = " + PriceList_ID.ToString();
                    dt.Clear();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            long Currency_ID = (long)dt.Rows[0]["Currency_ID"];
                            long Atom_Currency_ID = -1;
                            if (f_Atom_Currency.Get(Currency_ID, ref Atom_Currency_ID))
                            {
                                sql = "insert into Atom_PriceList (Name,Valid,ValidFrom,ValidTo,Description,Atom_Currency_ID) select Name,Valid,ValidFrom,ValidTo,Description," + Atom_Currency_ID.ToString() + " from PriceList where ID = " + PriceList_ID.ToString();

                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_PriceList_ID, ref objretx, ref Err, "Atom_PriceList"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_PriceList:Get:" + sql + "\r\nErr=" + Err);
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
                            LogFile.Error.Show("ERROR:f_Atom_PriceList:PriceList has no Currency!\r\nsql=" + sql);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_PriceList:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_PriceList:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(ref Atom_ProformaInvoice_Price_Item_Stock_Data appisd, ref long Atom_PriceList_ID)
        {
            string Err = null;
            if (appisd.Atom_PriceList_Name != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar_Atom_PriceList_Name = "@par_Atom_PriceList_Name";
                SQL_Parameter par_Atom_PriceList_Name = new SQL_Parameter(spar_Atom_PriceList_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, appisd.Atom_PriceList_Name.v);
                lpar.Add(par_Atom_PriceList_Name);

                string spar_Atom_Currency_Abbreviation = "@par_Atom_Currency_Abbreviation";
                SQL_Parameter par_Atom_Currency_Abbreviation = new SQL_Parameter(spar_Atom_Currency_Abbreviation, SQL_Parameter.eSQL_Parameter.Nvarchar, false, appisd.Atom_Currency_Abbreviation.v);
                lpar.Add(par_Atom_Currency_Abbreviation);

                string spar_Atom_Currency_Name = "@par_Atom_Currency_Name";
                SQL_Parameter par_Atom_Currency_Name = new SQL_Parameter(spar_Atom_Currency_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, appisd.Atom_Currency_Name.v);
                lpar.Add(par_Atom_Currency_Name);

                DataTable dt = new DataTable();
                string sql = @"select Atom_PriceList.ID
                            from Atom_PriceList
                            inner join Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID 
                            where Atom_PriceList.Name = " + spar_Atom_PriceList_Name + " and  Atom_Currency.Name = " + spar_Atom_Currency_Name + " and  Atom_Currency.Abbreviation = " + spar_Atom_Currency_Abbreviation;

                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        Atom_PriceList_ID = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"select PriceList.ID
                                      from PriceList 
                                      inner join Currency on PriceList.Currency_ID = Currency.ID 
                                      where PriceList.Name = " + spar_Atom_PriceList_Name + " and  Currency.Name = " + spar_Atom_Currency_Name + " and  Currency.Abbreviation = " + spar_Atom_Currency_Abbreviation;
                        dt.Clear();
                        dt.Rows.Clear();
                        dt.Columns.Clear();
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                long PriceList_ID = (long)dt.Rows[0]["ID"];
                                xPriceList m_xPriceList = new xPriceList();
                                sql = "select Currency_ID from PriceList where PriceList.ID = " + PriceList_ID.ToString();
                                dt.Clear();
                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        long Currency_ID = (long)dt.Rows[0]["Currency_ID"];
                                        long Atom_Currency_ID = -1;
                                        if (f_Atom_Currency.Get(Currency_ID, ref Atom_Currency_ID))
                                        {
                                            sql = "insert into Atom_PriceList (Name,Valid,ValidFrom,ValidTo,Description,Atom_Currency_ID) select Name,Valid,ValidFrom,ValidTo,Description," + Atom_Currency_ID.ToString() + " from PriceList where ID = " + PriceList_ID.ToString();

                                            object objretx = null;
                                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_PriceList_ID, ref objretx, ref Err, "Atom_PriceList"))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                LogFile.Error.Show("ERROR:f_Atom_PriceList:Get:" + sql + "\r\nErr=" + Err);
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
                                        LogFile.Error.Show("ERROR:f_Atom_PriceList:PriceList has no Currency!\r\nsql=" + sql);
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_PriceList:Get:" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Atom_PriceList:PriceList has no data!\r\nsql=" + sql);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_PriceList:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_PriceList:Get:" + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_PriceList:Get:appisd.Atom_PriceList_Name==null");
                return false;
            }
        }
    }
}
