﻿using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
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
    }
}