﻿using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_PurchasePrice
    {

        public static bool Get(decimal PricePerUnit,
                               decimal Discount,
                               bool PriceWithoutVAT,
                               bool VATCanNotBeDeducted,
                               ID ID_Taxation,ID ID_Currency, ref ID PurchasePrice_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_PricePerUnit = "@par_PricePerUnit";
            SQL_Parameter par_PricePerUnit = new SQL_Parameter(spar_PricePerUnit, SQL_Parameter.eSQL_Parameter.Decimal, false, PricePerUnit);
            lpar.Add(par_PricePerUnit);

            string spar_Discount = "@par_Discount";
            SQL_Parameter par_Discount = new SQL_Parameter(spar_Discount, SQL_Parameter.eSQL_Parameter.Decimal, false, Discount);
            lpar.Add(par_Discount);

            string spar_PriceWithoutVAT = "@par_PriceWithoutVAT";
            SQL_Parameter par_PriceWithoutVAT = new SQL_Parameter(spar_PriceWithoutVAT, SQL_Parameter.eSQL_Parameter.Bit, false, PriceWithoutVAT);
            lpar.Add(par_PriceWithoutVAT);

            string spar_VATCanNotBeDeducted = "@par_VATCanNotBeDeducted";
            SQL_Parameter par_VATCanNotBeDeducted = new SQL_Parameter(spar_VATCanNotBeDeducted, SQL_Parameter.eSQL_Parameter.Bit, false, VATCanNotBeDeducted);
            lpar.Add(par_VATCanNotBeDeducted);

            string spar_ID_Taxation = "@par_ID_Taxation";
            SQL_Parameter par_ID_Taxation = new SQL_Parameter(spar_ID_Taxation,  false, ID_Taxation);
            lpar.Add(par_ID_Taxation);

            string spar_ID_Currency = "@par_ID_Currency";
            SQL_Parameter par_ID_Currency = new SQL_Parameter(spar_ID_Currency,  false, ID_Currency);
            lpar.Add(par_ID_Currency);

            string sql = "select ID from PurchasePrice where PurchasePricePerUnit = " + spar_PricePerUnit 
                         + " and  Discount = " + spar_Discount
                         + " and  PriceWithoutVAT = " + spar_PriceWithoutVAT
                         + " and  VATCanNotBeDeducted = " + spar_VATCanNotBeDeducted
                         + " and  Currency_ID = " + spar_ID_Currency + " and Taxation_ID = " + spar_ID_Taxation;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (PurchasePrice_ID==null)
                    {
                        PurchasePrice_ID = new ID();
                    }
                    PurchasePrice_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    DateTime dtPurchasePriceDate = DateTime.Now;
                    string spar_PurchasePriceDate = "@par_PurchasePriceDate";
                    SQL_Parameter par_PurchasePriceDate = new SQL_Parameter(spar_PurchasePriceDate, SQL_Parameter.eSQL_Parameter.Datetime, false, dtPurchasePriceDate);
                    lpar.Add(par_PurchasePriceDate);
                    sql = "insert into PurchasePrice (PurchasePricePerUnit,Discount,PriceWithoutVAT,VATCanNotBeDeducted,Currency_ID,Taxation_ID,PurchasePriceDate)values(" 
                        + spar_PricePerUnit + ","
                        + spar_Discount + ","
                        + spar_PriceWithoutVAT + ","
                        + spar_VATCanNotBeDeducted + ","
                        + spar_ID_Currency + "," 
                        + spar_ID_Taxation + ","
                        + spar_PurchasePriceDate + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref PurchasePrice_ID, ref Err, "PurchasePrice"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        public static bool Get_InUpdate(string PurchasePrice_TableName, decimal PricePerUnit, ID ID_Taxation, ID ID_Currency, ref ID PurchasePrice_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_PricePerUnit = "@par_PricePerUnit";
            SQL_Parameter par_PricePerUnit = new SQL_Parameter(spar_PricePerUnit, SQL_Parameter.eSQL_Parameter.Decimal, false, PricePerUnit);
            lpar.Add(par_PricePerUnit);

            string spar_ID_Taxation = "@par_ID_Taxation";
            SQL_Parameter par_ID_Taxation = new SQL_Parameter(spar_ID_Taxation, false, ID_Taxation);
            lpar.Add(par_ID_Taxation);

            string spar_ID_Currency = "@par_ID_Currency";
            SQL_Parameter par_ID_Currency = new SQL_Parameter(spar_ID_Currency, false, ID_Currency);
            lpar.Add(par_ID_Currency);

            string sql = "select ID from "+ PurchasePrice_TableName + " where PurchasePricePerUnit = " + spar_PricePerUnit + " and  Currency_ID = " + spar_ID_Currency + " and Taxation_ID = " + spar_ID_Taxation;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (PurchasePrice_ID==null)
                    {
                        PurchasePrice_ID = new ID();
                    }
                    PurchasePrice_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    DateTime dtPurchasePriceDate = DateTime.Now;
                    string spar_PurchasePriceDate = "@par_PurchasePriceDate";
                    SQL_Parameter par_PurchasePriceDate = new SQL_Parameter(spar_PurchasePriceDate, SQL_Parameter.eSQL_Parameter.Datetime, false, dtPurchasePriceDate);
                    lpar.Add(par_PurchasePriceDate);
                    sql = "insert into "+PurchasePrice_TableName+" (PurchasePricePerUnit,Currency_ID,Taxation_ID,PurchasePriceDate)values(" + spar_PricePerUnit + "," + spar_ID_Currency + "," + spar_ID_Taxation + "," + spar_PurchasePriceDate + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref PurchasePrice_ID,  ref Err, PurchasePrice_TableName))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}
