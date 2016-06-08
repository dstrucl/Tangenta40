#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_JOURNAL_Stock
    {
        public const string New_Stock_Data = "New Stock Data";
        public const string Stock_Data_Changed = "Stock Data Changed";
        public const string From_Stock_To_Basket = "From stock to basket";
        public const string From_Basket_To_Stock = "From basket to stock";
        private static long m_JOURNAL_Stock_Type_ID_new_stock_data = -1;
        private static long m_JOURNAL_Stock_Type_ID_stock_data_changed = -1;
        private static long m_JOURNAL_Stock_Type_ID_from_stock_to_basket = -1;
        private static long m_JOURNAL_Stock_Type_ID_from_basket_to_stock = -1;

        public static long JOURNAL_Stock_Type_ID_new_stock_data
        { get { return m_JOURNAL_Stock_Type_ID_new_stock_data; } }

        public static long JOURNAL_Stock_Type_ID_stock_data_changed
        { get { return m_JOURNAL_Stock_Type_ID_stock_data_changed; } }

        public static long JOURNAL_Stock_Type_ID_from_stock_to_basket
        { get { return m_JOURNAL_Stock_Type_ID_from_stock_to_basket; } }

        public static long JOURNAL_Stock_Type_ID_from_basket_to_stock
        { get { return m_JOURNAL_Stock_Type_ID_from_basket_to_stock; } }


        public static bool Get_JOURNAL_Stock_Type_ID()
        {
            if (fs.Get_JOURNAL_TYPE("JOURNAL_Stock_Type", New_Stock_Data, ref m_JOURNAL_Stock_Type_ID_new_stock_data))
            {
                if (fs.Get_JOURNAL_TYPE("JOURNAL_Stock_Type", Stock_Data_Changed, ref m_JOURNAL_Stock_Type_ID_stock_data_changed))
                {
                    if (fs.Get_JOURNAL_TYPE("JOURNAL_Stock_Type", From_Stock_To_Basket, ref m_JOURNAL_Stock_Type_ID_from_stock_to_basket))
                    {
                        if (fs.Get_JOURNAL_TYPE("JOURNAL_Stock_Type", From_Basket_To_Stock, ref m_JOURNAL_Stock_Type_ID_from_basket_to_stock))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool Get(long Stock_id, long stock_type_id, DateTime dEventTime, decimal dQuantity, ref long_v JOURNAL_Stock_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_JOURNAL_Stock_Type_ID = "@par_JOURNAL_Stock_Type_ID";
            SQL_Parameter par_JOURNAL_Stock_Type_ID = new SQL_Parameter(spar_JOURNAL_Stock_Type_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, stock_type_id);
            lpar.Add(par_JOURNAL_Stock_Type_ID);

            string spar_Stock_ID = "@par_Stock_ID";
            SQL_Parameter par_Stock_ID = new SQL_Parameter(spar_Stock_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Stock_id);
            lpar.Add(par_Stock_ID);

            string spar_EventTime = "@par_EventTime";
            SQL_Parameter par_EventTime = new SQL_Parameter(spar_EventTime, SQL_Parameter.eSQL_Parameter.Datetime, false, dEventTime);
            lpar.Add(par_EventTime);

            long Atom_WorkPeriod_id = GlobalData.Atom_WorkPeriod_ID;
            string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
            SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_WorkPeriod_id);
            lpar.Add(par_Atom_WorkPeriod_ID);

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dQuantity);
            lpar.Add(par_dQuantity);

            string table_name = "JOURNAL_Stock";
            string sql = "insert into " + table_name + " (JOURNAL_Stock_Type_ID,Stock_ID,EventTime,Atom_WorkPeriod_ID,dQuantity)values(" + spar_JOURNAL_Stock_Type_ID + "," + spar_Stock_ID + "," + spar_EventTime + "," + spar_Atom_WorkPeriod_ID + "," + spar_dQuantity + ")";
            long id = -1;
            object oret = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref oret, ref Err, table_name))
            {
                if (JOURNAL_Stock_ID == null)
                {
                    JOURNAL_Stock_ID = new long_v();
                }
                JOURNAL_Stock_ID.v = id;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_JOURNAL_Stock:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
