using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_StockTake_AdditionalCost
    {
        public static bool Add(ID StockTake_ID, string Name, decimal Cost, string Description, ref ID StockTake_AdditionalCost_ID)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            ID StocTakeCostName_ID = null;
            if (f_StockTakeCostName.Get(Name, ref StocTakeCostName_ID))
            {
                string spar_StocTakeCostDescription_ID = "null";
                if (Description != null)
                {
                    if (Description.Length > 0)
                    {
                        ID StocTakeCostDescription_ID = null;
                        if (f_StockTakeCostDescription.Get(Description, ref StocTakeCostDescription_ID))
                        {
                            spar_StocTakeCostDescription_ID = "@par_StocTakeCostDescription_ID";
                            SQL_Parameter par_StocTakeCostDescription_ID = new SQL_Parameter(spar_StocTakeCostDescription_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, StocTakeCostName_ID);
                            lpar.Add(par_StocTakeCostDescription_ID);
                        }
                    }
                }

                string spar_StocTakeCostName_ID = "@par_StocTakeCostName_ID";
                SQL_Parameter par_StocTakeCostName_ID = new SQL_Parameter(spar_StocTakeCostName_ID, false, StocTakeCostName_ID);
                lpar.Add(par_StocTakeCostName_ID);

                string spar_Cost = "@par_Cost";
                SQL_Parameter par_Cost = new SQL_Parameter(spar_Cost, SQL_Parameter.eSQL_Parameter.Decimal, false, Cost);
                lpar.Add(par_Cost);

                string spar_StocTake_ID = "@par_StocTake_ID";
                SQL_Parameter par_StocTake_ID = new SQL_Parameter(spar_StocTake_ID, false, StockTake_ID);
                lpar.Add(par_StocTake_ID);


                string sql = "insert into StockTake_AdditionalCost (StockTakeCostName_ID,Cost,StockTakeCostDescription_ID,StockTake_ID)values("
                              + spar_StocTakeCostName_ID + ","
                              + spar_Cost + ","
                              + spar_StocTakeCostDescription_ID + ","
                              + spar_StocTake_ID 
                              + ")";
                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref StockTake_AdditionalCost_ID, ref Err, "StockTake_AdditionalCost"))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_StockTake_AdditionalCost.cs:Add:sql=" + sql + "\r\nErr=" + Err);
                }
            }
            return false;
        }

        public static bool Update(ID StockTake_AdditionalCost_ID,ID StockTake_ID, string Name, decimal Cost, string Description)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            ID StocTakeCostName_ID = null;
            if (f_StockTakeCostName.Get(Name, ref StocTakeCostName_ID))
            {
                string spar_StocTakeCostDescription_ID = "null";
                if (Description != null)
                {
                    if (Description.Length > 0)
                    {
                        ID StocTakeCostDescription_ID = null;
                        if (f_StockTakeCostDescription.Get(Description, ref StocTakeCostDescription_ID))
                        {
                            spar_StocTakeCostDescription_ID = "@par_StocTakeCostDescription_ID";
                            SQL_Parameter par_StocTakeCostDescription_ID = new SQL_Parameter(spar_StocTakeCostDescription_ID, false, StocTakeCostName_ID);
                            lpar.Add(par_StocTakeCostDescription_ID);
                        }
                    }
                }

                string spar_StocTakeCostName_ID = "@par_StocTakeCostName_ID";
                SQL_Parameter par_StocTakeCostName_ID = new SQL_Parameter(spar_StocTakeCostName_ID, false, StocTakeCostName_ID);
                lpar.Add(par_StocTakeCostName_ID);

                string spar_Cost = "@par_Cost";
                SQL_Parameter par_Cost = new SQL_Parameter(spar_Cost, SQL_Parameter.eSQL_Parameter.Decimal, false, Cost);
                lpar.Add(par_Cost);

                string spar_StocTake_ID = "@par_StocTake_ID";
                SQL_Parameter par_StocTake_ID = new SQL_Parameter(spar_StocTake_ID, false, StockTake_ID);
                lpar.Add(par_StocTake_ID);

                string spar_StocTake_AdditionalCost_ID = "@par_StocTake_AdditionalCost_ID";
                SQL_Parameter par_StocTake_AdditionalCost_ID = new SQL_Parameter(spar_StocTake_AdditionalCost_ID, false, StockTake_AdditionalCost_ID);
                lpar.Add(par_StocTake_AdditionalCost_ID);


                string sql = "Update StockTake_AdditionalCost set StockTakeCostName_ID = " + spar_StocTakeCostName_ID
                                                               + ",Cost=" + spar_Cost 
                                                               + ", StockTakeCostDescription_ID = " + spar_StocTakeCostDescription_ID
                                                               + " where StockTake_ID = " + spar_StocTake_ID + " and ID =" + StockTake_AdditionalCost_ID.ToString();
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_StockTake_AdditionalCost.cs:Update:sql=" + sql + "\r\nErr=" + Err);
                }
            }
            return false;
        }

        public static bool Remove(ID StockTake_AdditionalCost_ID, ID StockTake_ID)
        {
            string Err = null;
            string sql = "delete from StockTake_AdditionalCost where StockTake_ID = " + StockTake_ID.ToString() + " and ID =" + StockTake_AdditionalCost_ID.ToString();
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql,null, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_StockTake_AdditionalCost.cs:Remove:sql=" + sql + "\r\nErr=" + Err);
            }
            return false;
        }

        public static bool ReadDataTable(ref DataTable dt, ID StockTake_ID)
        {
            string Err = null;
            if (dt != null)
            {
                dt = new DataTable();
            }
            dt.Rows.Clear();
            string sql = @"select 
                               stcn.Name,
                               stac.Cost,
                               stcd.Description,
                               stac.ID,
                               stcn.ID as StockTakeCostName_ID,
                               st.Name as StockTake_Name
                        from StockTake_AdditionalCost stac 
                        inner join StockTake st on stac.StockTake_ID = st.ID 
                        inner join StockTakeCostName stcn on stac.StockTakeCostName_ID = stcn.ID
                        left join StockTakeCostDescription stcd on stac.StockTakeCostDescription_ID = stcd.ID
                        where st.ID = " + StockTake_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_StockTake_AdditionalCost.cs:ReadDataTable:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
