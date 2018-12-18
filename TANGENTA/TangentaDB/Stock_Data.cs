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
    public class Stock_Data
    {
        private ID m_Doc_ShopC_Item_ID = null;
        public ID Doc_ShopC_Item_ID
        {
            get
            {
                return m_Doc_ShopC_Item_ID;
            }
            set
            {
                m_Doc_ShopC_Item_ID = value;
            }
        }

        private ID m_Stock_ID = null;

        public ID Stock_ID
        {
            get
            {
                return m_Stock_ID;
            }
            set
            {
                m_Stock_ID = value;
            }
        }

        public DateTime_v Stock_ImportTime = null;
        public decimal_v dQuantity_v = null;
        public decimal_v dQuantity_New_in_Stock_v = null;
        public decimal_v dQuantity_Taken_v = null;
        public DateTime_v Stock_ExpiryDate = null;
        public bool_v StockTake_Draft = null;

        public decimal_v dQuantity_from_stock
        {
            get
            {
                if (ID.Validate(Stock_ID))
                {
                    return dQuantity_v;
                }
                else
                {
                    return null;
                }
            }
        }

        public decimal_v dQuantity_from_factory
        {
            get
            {
                if (!ID.Validate(Stock_ID))
                {
                    return dQuantity_v;
                }
                else
                {
                    return null;
                }
            }
        }


        //public void Set(string docType,System.Data.DataRow dria)
        //{
        //    Doc_ShopC_Item_ID = tf.set_ID(dria[docType + "_ShopC_Item_ID"]);
        //    Stock_ID = tf.set_ID(dria["Stock_ID"]);
        //    Stock_ImportTime = tf.set_DateTime(dria["Stock_ImportTime"]);
        //    Stock_ExpiryDate = tf.set_DateTime(dria["Stock_ExpiryDate"]);
        //    dQuantity_v = tf.set_decimal(dria["dQuantity"]);
        //}

        public bool Remove_from_StockShelf(ID xAtom_WorkPeriod_ID)
        {
            if (ID.Validate(Stock_ID))
            {
                if (dQuantity_New_in_Stock_v != null)
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    string spar_dQuantity_New_in_Stock = "@par_dQuantity_New_in_Stock";
                    SQL_Parameter par_dQuantity_New_in_Stock = new SQL_Parameter(spar_dQuantity_New_in_Stock, SQL_Parameter.eSQL_Parameter.Decimal, false, dQuantity_New_in_Stock_v.v);
                    lpar.Add(par_dQuantity_New_in_Stock);
                    string sql = "update stock set dQuantity = " + spar_dQuantity_New_in_Stock + " where ID = " + Stock_ID.ToString();
                    string Err = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref Err))
                    {
                        ID JOURNAL_Stock_ID = null;
                        DateTime EventTime = DateTime.Now;
                        decimal dQuantityRemovedFromStock = dQuantity_v.v;
                        return f_JOURNAL_Stock.Get(Stock_ID, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_from_stock_to_basket, xAtom_WorkPeriod_ID, EventTime, dQuantityRemovedFromStock, ref JOURNAL_Stock_ID);
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Stock_Data:Remove_from_StockShelf:sql = " + sql + "\r\nErr=" + Err);
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Stock_Data:Remove_from_StockShelf:dQuantity_New_in_Stock==null!");
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Stock_Data:Remove_from_StockShelf:dQuantity_New_in_Stock==null!");
            }
            return false;
        }

        public Stock_Data()
        {
            m_Doc_ShopC_Item_ID = null;
            Stock_ID = null;
            Stock_ImportTime = null;
            dQuantity_v = null;
            dQuantity_New_in_Stock_v = null;
            Stock_ExpiryDate = null;
            StockTake_Draft = null;
        }
    }
}
