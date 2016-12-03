using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_DocInvoice
    {
        public class fData
        {
            public bool bDraft = false;
            public long DraftNumber = -1;
            public long FinancialYear = -1;
            public long NumberInFinancialYear = -1;
            public f_DocInvoice_ShopC_Item.fData ShopC_Item_Data = new f_DocInvoice_ShopC_Item.fData();
        }


        public static bool Get(long docInvoice_ID,long docInvoice_ShopC_Item_ID, ref fData ret_data)
        {
            string Err = null;
            DataTable dt = new DataTable();
            if (ret_data == null)
            {
                ret_data = new fData();
            }
            string sql = @"select Draft,
                                 DraftNumber,
                                 FinancialYear,
                                 NumberInFinancialYear
                                 from DocInvoice where ID = " + docInvoice_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err ))
            {
                if (dt.Rows.Count > 0)
                {
                    ret_data.bDraft = DBTypes.tf._set_bool(dt.Rows[0]["Draft"]);
                    ret_data.DraftNumber = DBTypes.tf._set_long(dt.Rows[0]["DraftNumber"]);
                    ret_data.FinancialYear = DBTypes.tf._set_long(dt.Rows[0]["FinancialYear"]);
                    ret_data.NumberInFinancialYear = DBTypes.tf._set_long(dt.Rows[0]["NumberInFinancialYear"]);
                    if (f_DocInvoice_ShopC_Item.Get(docInvoice_ShopC_Item_ID,
                                                ref ret_data.ShopC_Item_Data
                                                ))
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
                    LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:Get:sql=" + sql + "\r\nNo DocInvoice data for ID = " + docInvoice_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:Get:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }
    }
}
