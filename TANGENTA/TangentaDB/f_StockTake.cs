using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_StockTake
    {
        public static bool Get(string StockTake_Name,
                               DateTime_v StockTake_Date_v,
                               decimal_v StockTake_PriceTotal_v,
                               ID StockTake_Reference_ID,
                               string StockTake_Description,
                               ID StockTake_Supplier_ID,
                               ID StockTake_Trucking_ID,
                               bool_v StockTake_Draft_v,
                               ref ID StockTake_ID
                               )
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string scond_StockTake_Name = null;
            string sval_StockTake_Name = "null";
            if (StockTake_Name != null)
            {
                string spar_StockTake_Name = "@par_StockTake_Name";
                SQL_Parameter par_StockTake_Name = new SQL_Parameter(spar_StockTake_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, StockTake_Name);
                lpar.Add(par_StockTake_Name);
                scond_StockTake_Name = "Name = " + spar_StockTake_Name;
                sval_StockTake_Name = spar_StockTake_Name;
            }
            else
            {
                scond_StockTake_Name = "Name is null";
                sval_StockTake_Name = "null";
            }

            string scond_StockTake_Date = null;
            string sval_StockTake_Date = "null";
            if (StockTake_Date_v != null)
            {
                string spar_StockTake_Date = "@par_StockTake_Date";
                SQL_Parameter par_StockTake_Date = new SQL_Parameter(spar_StockTake_Date, SQL_Parameter.eSQL_Parameter.Datetime, false, StockTake_Date_v.v);
                lpar.Add(par_StockTake_Date);
                scond_StockTake_Date = "StockTake_Date = " + spar_StockTake_Date;
                sval_StockTake_Date = spar_StockTake_Date;
            }
            else
            {
                scond_StockTake_Date = "StockTake_Date is null";
                sval_StockTake_Date = "null";
            }

            string scond_StockTake_PriceTotal = null;
            string sval_StockTake_PriceTotal = "null";
            if (StockTake_PriceTotal_v != null)
            {
                string spar_StockTake_PriceTotal = "@par_StockTake_PriceTotal";
                SQL_Parameter par_StockTake_PriceTotal = new SQL_Parameter(spar_StockTake_PriceTotal, SQL_Parameter.eSQL_Parameter.Decimal, false, StockTake_PriceTotal_v.v);
                lpar.Add(par_StockTake_PriceTotal);
                scond_StockTake_PriceTotal = "StockTakePriceTotal = " + spar_StockTake_PriceTotal;
                sval_StockTake_PriceTotal = spar_StockTake_PriceTotal;
            }
            else
            {
                scond_StockTake_PriceTotal = "StockTakePriceTotal is null";
                sval_StockTake_PriceTotal = "null";
            }

            string scond_Reference_ID = null;
            string sval_Reference_ID = "null";
            if (ID.Validate(StockTake_Reference_ID))
            {
                string spar_Reference_ID = "@par_Reference_ID";
                SQL_Parameter par_Reference_ID = new SQL_Parameter(spar_Reference_ID, false, StockTake_Reference_ID);
                lpar.Add(par_Reference_ID);
                scond_Reference_ID = "Reference_ID = " + spar_Reference_ID;
                sval_Reference_ID = spar_Reference_ID;
            }
            else
            {
                scond_Reference_ID = "Reference_ID is null";
                sval_Reference_ID = "null";
            }

            string scond_Supplier_ID = null;
            string sval_Supplier_ID = "null";
            if (ID.Validate(StockTake_Supplier_ID))
            {
                string spar_Supplier_ID = "@par_Supplier_ID";
                SQL_Parameter par_Supplier_ID = new SQL_Parameter(spar_Supplier_ID, false, StockTake_Supplier_ID);
                lpar.Add(par_Supplier_ID);
                scond_Supplier_ID = "Supplier_ID = " + spar_Supplier_ID;
                sval_Supplier_ID = spar_Supplier_ID;
            }
            else
            {
                scond_Supplier_ID = "Supplier_ID is null";
                sval_Supplier_ID = "null";
            }


            string scond_Trucking_ID = null;
            string sval_Trucking_ID = "null";
            if (ID.Validate(StockTake_Trucking_ID))
            {
                string spar_Trucking_ID = "@par_Trucking_ID";
                SQL_Parameter par_Trucking_ID = new SQL_Parameter(spar_Trucking_ID,  false, StockTake_Trucking_ID);
                lpar.Add(par_Trucking_ID);
                scond_Trucking_ID = "Trucking_ID = " + spar_Trucking_ID;
                sval_Trucking_ID = spar_Trucking_ID;
            }
            else
            {
                scond_Trucking_ID = "Trucking_ID is null";
                sval_Trucking_ID = "null";
            }

            string scond_Draft = null;
            string sval_Draft = "null";
            if (StockTake_Draft_v != null)
            {
                string spar_Draft = "@par_Draft";
                SQL_Parameter par_Draft = new SQL_Parameter(spar_Draft, SQL_Parameter.eSQL_Parameter.Bit, false, StockTake_Draft_v.v);
                lpar.Add(par_Draft);
                scond_Draft = "Draft = " + spar_Draft;
                sval_Draft = spar_Draft;
            }
            else
            {
                scond_Draft = "Draft is null";
                sval_Draft = "null";
            }



            string sql = @"select ID from StockTake
                                        where (" + scond_StockTake_Name + ") and (" 
                                        + scond_StockTake_Date + ") and ("
                                        + scond_StockTake_PriceTotal + ") and ("
                                        + scond_Reference_ID + ") and ("
                                        + scond_Supplier_ID + ") and ("
                                        + scond_Trucking_ID + ") and ("
                                        + scond_Draft + ")";
            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (StockTake_ID==null)
                    {
                        StockTake_ID = new ID();
                    }
                    StockTake_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into StockTake (  Name,
                                                     StockTake_Date,
                                                     StockTakePriceTotal,
                                                     Reference_ID,
                                                     Supplier_ID,
                                                     Trucking_ID,
                                                     Draft
                                                     ) values 
                                                     ("
                                                     + sval_StockTake_Name + ","
                                                     + sval_StockTake_Date + ","
                                                     + sval_StockTake_PriceTotal + ","
                                                     + sval_Reference_ID + ","
                                                     + sval_Supplier_ID + ","
                                                     + sval_Trucking_ID + ","
                                                     + sval_Draft
                                                     + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref StockTake_ID, ref Err, "StockTake"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_StockTake:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_StockTake:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Exist(string StockTake_Name,
                        ref ID StockTake_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string scond_StockTake_Name = null;
            string sval_StockTake_Name = "null";
            if (StockTake_Name != null)
            {
                string spar_StockTake_Name = "@par_StockTake_Name";
                SQL_Parameter par_StockTake_Name = new SQL_Parameter(spar_StockTake_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, StockTake_Name);
                lpar.Add(par_StockTake_Name);
                scond_StockTake_Name = "Name = " + spar_StockTake_Name;
                sval_StockTake_Name = spar_StockTake_Name;
            }
            else
            {
                scond_StockTake_Name = "Name is null";
                sval_StockTake_Name = "null";
            }


            string sql = @"select ID from StockTake
                                        where (" + scond_StockTake_Name + ")";
            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (StockTake_ID==null)
                    {
                        StockTake_ID = new ID();
                    }
                    StockTake_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    StockTake_ID = null;
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_StockTake:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Update(
                       ID StockTake_ID,
                       string StockTake_Name,
                       DateTime_v StockTake_Date_v,
                       decimal_v StockTake_PriceTotal_v,
                       ID StockTake_Reference_ID,
                       string StockTake_Description,
                       ID StockTake_Supplier_ID,
                       ID StockTake_Trucking_ID,
                       bool_v StockTake_Draft_v
                       )
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string sval_StockTake_Name = "null";
            if (StockTake_Name != null)
            {
                string spar_StockTake_Name = "@par_StockTake_Name";
                SQL_Parameter par_StockTake_Name = new SQL_Parameter(spar_StockTake_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, StockTake_Name);
                lpar.Add(par_StockTake_Name);
                sval_StockTake_Name = spar_StockTake_Name;
            }
            else
            {
                sval_StockTake_Name = "null";
            }

            string sval_StockTake_Date = "null";
            if (StockTake_Date_v != null)
            {
                string spar_StockTake_Date = "@par_StockTake_Date";
                SQL_Parameter par_StockTake_Date = new SQL_Parameter(spar_StockTake_Date, SQL_Parameter.eSQL_Parameter.Datetime, false, StockTake_Date_v.v);
                lpar.Add(par_StockTake_Date);
                sval_StockTake_Date = spar_StockTake_Date;
            }
            else
            {
                sval_StockTake_Date = "null";
            }

            string sval_StockTake_PriceTotal = "null";
            if (StockTake_PriceTotal_v != null)
            {
                string spar_StockTake_PriceTotal = "@par_StockTake_PriceTotal";
                SQL_Parameter par_StockTake_PriceTotal = new SQL_Parameter(spar_StockTake_PriceTotal, SQL_Parameter.eSQL_Parameter.Decimal, false, StockTake_PriceTotal_v.v);
                lpar.Add(par_StockTake_PriceTotal);
                sval_StockTake_PriceTotal = spar_StockTake_PriceTotal;
            }
            else
            {
                sval_StockTake_PriceTotal = "null";
            }

            string sval_Reference_ID = "null";
            if (ID.Validate(StockTake_Reference_ID))
            {
                string spar_Reference_ID = "@par_Reference_ID";
                SQL_Parameter par_Reference_ID = new SQL_Parameter(spar_Reference_ID, false, StockTake_Reference_ID);
                lpar.Add(par_Reference_ID);
                sval_Reference_ID = spar_Reference_ID;
            }
            else
            {
                sval_Reference_ID = "null";
            }

            string sval_Supplier_ID = "null";
            if (ID.Validate(StockTake_Supplier_ID))
            {
                string spar_Supplier_ID = "@par_Supplier_ID";
                SQL_Parameter par_Supplier_ID = new SQL_Parameter(spar_Supplier_ID,  false, StockTake_Supplier_ID);
                lpar.Add(par_Supplier_ID);
                sval_Supplier_ID = spar_Supplier_ID;
            }
            else
            {
                sval_Supplier_ID = "null";
            }


            string sval_Trucking_ID = null;
            if (ID.Validate(StockTake_Trucking_ID))
            {
                string spar_Trucking_ID = "@par_Trucking_ID";
                SQL_Parameter par_Trucking_ID = new SQL_Parameter(spar_Trucking_ID, false, StockTake_Trucking_ID);
                lpar.Add(par_Trucking_ID);
                sval_Trucking_ID = spar_Trucking_ID;
            }
            else
            {
                sval_Trucking_ID = "null";
            }

            string sval_Draft = "null";
            if (StockTake_Draft_v != null)
            {
                string spar_Draft_ID = "@par_Draft_ID";
                SQL_Parameter par_Draft_ID = new SQL_Parameter(spar_Draft_ID, SQL_Parameter.eSQL_Parameter.Bit, false, StockTake_Draft_v.v);
                lpar.Add(par_Draft_ID);
                sval_Draft = spar_Draft_ID;
            }
            else
            {
                sval_Draft = "null";
            }



            string sql = @"update StockTake set
                                        Name = " + sval_StockTake_Name 
                                        + ",StockTake_Date = " + sval_StockTake_Date
                                        + ",StockTakePriceTotal = "+ sval_StockTake_PriceTotal
                                        + ",Reference_ID = " +sval_Reference_ID
                                        + ",Supplier_ID = "+ sval_Supplier_ID
                                        + ",Trucking_ID = " +sval_Trucking_ID 
                                        + ",Draft="+sval_Draft + " where ID = "+ StockTake_ID.ToString()+";";
            string Err = null;
            object oret = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar,ref oret, ref Err))
            {
                        return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_StockTake:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        public static bool Lock(ID StockTake_ID)
        {
            if (ID.Validate(StockTake_ID))
            {
                string sql = "update StockTake set Draft = 0 where ID = " + StockTake_ID.ToString();
                object ores = null;
                string Err = null;
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                {
                    ID JOURNAL_StockTake_ID = null;
                    TangentaDB.f_JOURNAL_StockTake.Get(StockTake_ID, f_JOURNAL_StockTake.JOURNAL_StockTake_Type_ID_Opened_StockTake_closed, DateTime.Now, ref JOURNAL_StockTake_ID);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB.fs.cs:Lock:sql=" + sql + "\r\nErr=" + Err);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.fs.cs:Lock:stockTake_ID is not valid!");
            }
            return false;
        }

        public static bool UnLock(ID StockTake_ID)
        {
            if (ID.Validate(StockTake_ID))
            {
                string sql = "update StockTake set Draft = 1 where ID = " + StockTake_ID.ToString();
                object ores = null;
                string Err = null;
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                {
                    ID JOURNAL_StockTake_ID = null;
                    TangentaDB.f_JOURNAL_StockTake.Get(StockTake_ID, f_JOURNAL_StockTake.JOURNAL_StockTake_Type_ID_Closed_StockTake_reopened, DateTime.Now, ref JOURNAL_StockTake_ID);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB.fs.cs:UnLock:sql=" + sql + "\r\nErr=" + Err);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.fs.cs:UnLock:stockTake_ID is not valid!");
            }
            return false;
        }
    }
}
