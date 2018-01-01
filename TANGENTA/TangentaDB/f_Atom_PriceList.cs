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

namespace TangentaDB
{
    public static class f_Atom_PriceList
    {
        public static bool Get(long PriceList_ID, ref long Atom_PriceList_ID)
        {
            string Err = null;

            DataTable dt = new DataTable();
            string sql = @"select apl.ID
                            from Atom_PriceList apl
                            inner join Atom_PriceList_Name apln on apl.Atom_PriceList_Name_ID = apln.ID
                            inner join PriceList_Name pln on pln.Name = apln.Name
                            inner join PriceList pl on pl.PriceList_Name_ID = pln.ID 
                                                    and apl.Valid = pl.Valid
                                                    and ((apl.ValidFrom = pl.ValidFrom) or (apl.ValidFrom is null and pl.ValidFrom is null))
                                                    and ((apl.ValidTo = pl.ValidTo) or (apl.ValidTo is null and pl.ValidTo is null))
                                                    and ((apl.Description = pl.Description) or (apl.Description is null and pl.Description is null))
                            inner join Currency cur on pl.Currency_ID = cur.ID
                            inner join Atom_Currency acur on apl.Atom_Currency_ID = acur.ID 
                            where cur.Abbreviation = acur.Abbreviation and
                                  pl.ID = " + PriceList_ID.ToString();

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
                    sql = @"select pl.Currency_ID,
                                   pln.Name as PriceList_Name
                                   from PriceList pl
                                   inner join PriceList_Name pln on pl.PriceList_Name_ID = pln.ID
                                   where pl.ID = " + PriceList_ID.ToString();
                    dt.Clear();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            long Currency_ID = (long)dt.Rows[0]["Currency_ID"];
                            long Atom_Currency_ID = -1;
                            if (f_Atom_Currency.Get(Currency_ID, ref Atom_Currency_ID))
                            {

                                string PriceList_Name = (string)dt.Rows[0]["PriceList_Name"];
                                long Atom_PriceList_Name_ID = -1;
                                if (f_Atom_PriceList_Name.Get(PriceList_Name, ref Atom_PriceList_Name_ID))
                                {

                                    sql = "insert into Atom_PriceList (Atom_PriceList_Name_ID,Valid,ValidFrom,ValidTo,Description,Atom_Currency_ID) select "+ Atom_PriceList_Name_ID.ToString() + ",Valid,ValidFrom,ValidTo,Description," + Atom_Currency_ID.ToString() + " from PriceList where ID = " + PriceList_ID.ToString();

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

        public static bool Get(ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, ref long Atom_PriceList_ID)
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
                            inner join Atom_PriceList_Name on Atom_PriceList.Atom_PriceList_Name_ID = Atom_PriceList_Name.ID
                            inner join Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID 
                            where Atom_PriceList_Name.Name = " + spar_Atom_PriceList_Name + " and  Atom_Currency.Abbreviation = " + spar_Atom_Currency_Abbreviation;

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
                                      inner join PriceList_Name on PriceList.PriceList_Name_ID = PriceList_Name.ID 
                                      inner join Currency on PriceList.Currency_ID = Currency.ID 
                                      where PriceList_Name.Name = " + spar_Atom_PriceList_Name + " and  Currency.Abbreviation = " + spar_Atom_Currency_Abbreviation;
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
                                            long Atom_PriceList_Name_ID = -1;
                                            if (f_Atom_PriceList_Name.Get(appisd.Atom_PriceList_Name.v, ref Atom_PriceList_Name_ID))
                                            {
                                                sql = "insert into Atom_PriceList (Atom_PriceList_Name_ID,Valid,ValidFrom,ValidTo,Description,Atom_Currency_ID) select "+ Atom_PriceList_Name_ID.ToString() + ",Valid,ValidFrom,ValidTo,Description," + Atom_Currency_ID.ToString() + " from PriceList where ID = " + PriceList_ID.ToString();

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
