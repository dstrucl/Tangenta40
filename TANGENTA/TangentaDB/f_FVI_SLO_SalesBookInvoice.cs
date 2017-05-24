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
    public static class f_FVI_SLO_SalesBookInvoice
    {
        public static bool Get(long Invoice_ID, string xSerialNumber,string xSetNumber,string xInvoiceNumber, ref long FVI_SLO_SalesBookInvoice_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Invoice_ID = "@par_Invoice_ID";
            SQL_Parameter par_Invoice_ID = new SQL_Parameter(spar_Invoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Invoice_ID);
                lpar.Add(par_Invoice_ID);
            string spar_SerialNumber = "@par_SerialNumber";
            SQL_Parameter par_SerialNumber = new SQL_Parameter(spar_SerialNumber, SQL_Parameter.eSQL_Parameter.Varchar, false, xSerialNumber);
            lpar.Add(par_SerialNumber);
            string spar_SetNumber = "@par_SetNumber";
            SQL_Parameter par_SetNumber = new SQL_Parameter(spar_SetNumber, SQL_Parameter.eSQL_Parameter.Varchar, false, xSetNumber);
            lpar.Add(par_SetNumber);
            string spar_InvoiceNumber = "@par_InvoiceNumber";
            SQL_Parameter par_InvoiceNumber = new SQL_Parameter(spar_InvoiceNumber, SQL_Parameter.eSQL_Parameter.Varchar, false, xInvoiceNumber);
            lpar.Add(par_InvoiceNumber);

        string sql = @"select ID from FVI_SLO_SalesBookInvoice
                                where Invoice_ID = " + spar_Invoice_ID + " and SerialNumber = " + spar_SerialNumber + " and SetNumber = " + spar_SetNumber + " and InvoiceNumber = " + spar_InvoiceNumber;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    FVI_SLO_SalesBookInvoice_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                sql = @"insert into FVI_SLO_SalesBookInvoice (Invoice_ID,SerialNumber,SetNumber,InvoiceNumber) values(" + spar_Invoice_ID + "," + spar_SerialNumber + "," + spar_SetNumber + "," + spar_InvoiceNumber + ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref FVI_SLO_SalesBookInvoice_ID, ref objretx, ref Err, "FVI_SLO_SalesBookInvoice"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_FVI_SLO_SalesBookInvoice:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_FVI_SLO_SalesBookInvoice:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Select_SalesBookInvoice_NotSent(ShopABC xInvoiceDB, ref List<InvoiceData> list, string xCasshierName)
        {
            string sql = @"select pi.ID from DocInvoice pi
                                inner join FVI_SLO_SalesBookInvoice fvisbi on fvisbi.DocInvoice_ID = pi.ID
                                left join FVI_SLO_Response fvires on fvires.DocInvoice_ID = pi.ID
                                where pi.Draft = 0 and fvires.BarCodeValue is null and fvisbi.SetNumber is not null";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (list == null)
                    {
                        list = new List<InvoiceData>();
                    }
                    list.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        long invoice_id = (long)dr["ID"];
                        InvoiceData xInvoiceData = new InvoiceData(xInvoiceDB, invoice_id, true, xCasshierName);
                        if (xInvoiceData.Read_DocInvoice())
                        {
                            list.Add(xInvoiceData);
                        }
                    }
                }
                else
                {
                    list = null;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:SelectNotSent:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
