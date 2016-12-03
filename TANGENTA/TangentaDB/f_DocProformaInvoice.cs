using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_DocProformaInvoice
    {
        public class fData
        {
            public bool bDraft = false;
            public long DraftNumber = -1;
            public long FinancialYear = -1;
            public long NumberInFinancialYear = -1;
            public f_DocProformaInvoice_ShopC_Item.fData ShopC_Item_Data = new f_DocProformaInvoice_ShopC_Item.fData();
        }

        public static bool Get(long docProformaInvoice_ID,long docInvoice_ShopC_Item_ID, ref fData data)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select Draft,
                                 DraftNumber,
                                 FinancialYear,
                                 NumberInFinancialYear
                                 from DocProformaInvoice where ID = " + docProformaInvoice_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    data.bDraft = DBTypes.tf._set_bool(dt.Rows[0]["Draft"]);
                    data.DraftNumber = DBTypes.tf._set_long(dt.Rows[0]["DraftNumber"]);
                    data.FinancialYear = DBTypes.tf._set_long(dt.Rows[0]["FinancialYear"]);
                    data.NumberInFinancialYear = DBTypes.tf._set_long(dt.Rows[0]["NumberInFinancialYear"]);
                    if (f_DocProformaInvoice_ShopC_Item.Get(docInvoice_ShopC_Item_ID,
                                                ref data.ShopC_Item_Data
                                                ))
                    {
                    }


                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoice:Get:sql=" + sql + "\r\nNo DocProformaInvoice data for ID = " + docProformaInvoice_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoice:Get:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }
    }
}
