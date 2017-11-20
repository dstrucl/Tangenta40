using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;

namespace UpgradeDB
{
    internal static class Upgrade_1_03_to_1_04
    {
        internal static object UpgradeDB_1_03_to_1_04(object obj, ref string Err)
        {
            // correct taxation
            string sql = @"select apsi.ID,RetailSimpleItemPrice,Discount,iQuantity,RetailSimpleItemPriceWithDiscount,ExtraDiscount,Rate from atom_price_simpleitem apsi 
                            inner join atom_taxation at on apsi.atom_taxation_ID = at.ID";
            DataTable dt_atom_price_simpleitem1 = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt_atom_price_simpleitem1, sql, ref Err))
            {
                if (dt_atom_price_simpleitem1.Rows.Count > 0)
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    foreach (DataRow dr in dt_atom_price_simpleitem1.Rows)
                    {
                        lpar.Clear();
                        long ID = (long)dr["ID"];
                        decimal RetailSimpleItemPrice = (decimal)dr["RetailSimpleItemPrice"];
                        decimal Discount = (decimal)dr["Discount"];
                        int iQuantity = (int)dr["iQuantity"];
                        decimal RetailSimpleItemPriceWithDiscount = (decimal)dr["RetailSimpleItemPriceWithDiscount"];
                        decimal ExtraDiscount = (decimal)dr["ExtraDiscount"];
                        decimal Taxation_Rate = (decimal)dr["Rate"];
                        decimal RetailSimpleItemPriceAll = RetailSimpleItemPrice * iQuantity;
                        decimal RetailSimpleItemPriceWithDiscount_Calculated = RetailSimpleItemPrice * iQuantity;
                        decimal TaxPrice = 0;
                        decimal RetailSimpleItemPriceWithDiscount_Calculated_WithoutTax = 0;

                        int decimal_places = 2;
                        if (GlobalData.BaseCurrency != null)
                        {
                            decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
                        }
                        decimal dQuantity = Convert.ToDecimal(iQuantity);
                        StaticLib.Func.CalculatePrice(RetailSimpleItemPriceAll, dQuantity, Discount, ExtraDiscount, Taxation_Rate, ref RetailSimpleItemPriceWithDiscount_Calculated, ref TaxPrice, ref RetailSimpleItemPriceWithDiscount_Calculated_WithoutTax, decimal_places);
                        string spar_TaxPrice = "@par_TaxPrice";
                        SQL_Parameter par_TaxPrice = new SQL_Parameter(spar_TaxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                        lpar.Add(par_TaxPrice);
                        sql = " update atom_price_simpleitem set TaxPrice=" + spar_TaxPrice + " where ID = " + ID.ToString();
                        object ores = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                        {
                            continue;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }

                string Column_PrefixTable = "invoicetable_";
                sql = @" select 
                            pi.ID,
                            Atom_myOrganisation_Person_ID,
                            Draft,
                            DraftNumber,
                            FinancialYear,
                            NumberInFinancialYear,
                            DocInvoiceTime,
                            FirstPrintTime,
                            NetSum,
                            Discount,
                            EndSum,
                            TaxSum,
                            GrossSum,
                            Atom_Customer_Person_ID,
                            Atom_Customer_Org_ID,
                            WarrantyExist,
                            WarrantyConditions,
                            WarrantyDurationType,
                            WarrantyDuration,
                            DocDuration,
                            DocDurationType,
                            TermsOfPayment_ID,
                            Invoice_ID,
                            i.PaymentDeadline as " + Column_PrefixTable + @"PaymentDeadline,
                            i.MethodOfPayment_ID as " + Column_PrefixTable + @"MethodOfPayment_ID,
                            i.Paid as " + Column_PrefixTable + @"Paid,
                            i.Storno as " + Column_PrefixTable + @"Storno
                            from DocInvoice  pi
                            inner join Invoice i on i.ID = pi.Invoice_ID";
                DataTable dt_DocInvoice = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice, sql, ref Err))
                {
                    if (dt_DocInvoice.Rows.Count > 0)
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                        List<DocInvoice_Connection_Class> DocInvoice_con_List = new List<DocInvoice_Connection_Class>();
                        string sErrors = "";
                        foreach (DataRow dr in dt_DocInvoice.Rows)
                        {
                            lpar.Clear();
                            long docinvoice_ID = (long)dr["ID"];
                            string sql_atom_price_simpleitem = "select * from atom_price_simpleitem where DocInvoice_ID = " + docinvoice_ID.ToString();
                            DocInvoice_Connection_Class picc = new DocInvoice_Connection_Class();
                            picc.ID = docinvoice_ID;
                            DataTable dt_atom_price_simpleitem2 = new DataTable();
                            if (DBSync.DBSync.ReadDataTable(ref dt_atom_price_simpleitem2, sql_atom_price_simpleitem, ref Err))
                            {
                                if (dt_atom_price_simpleitem2.Rows.Count > 0)
                                {
                                    decimal TaxSum = 0;
                                    decimal NetSum = 0;
                                    decimal GrossSum = 0;
                                    foreach (DataRow dr_atom_price_simpleitem in dt_atom_price_simpleitem2.Rows)
                                    {
                                        GrossSum += (decimal)dr_atom_price_simpleitem["RetailSimpleItemPriceWithDiscount"];
                                        TaxSum += (decimal)dr_atom_price_simpleitem["TaxPrice"];
                                    }
                                    NetSum = GrossSum - TaxSum;
                                    string sNumber = ((int)dr["FinancialYear"]).ToString() + "/" + ((int)dr["NumberInFinancialYear"]).ToString();
                                    if ((decimal)dr["NetSum"] != NetSum)
                                    {
                                        sErrors += lng.s_WrongNetSum.s + ((decimal)dr["NetSum"]).ToString() + lng.s_ForDocInvoiceNumber.s + sNumber + lng.s_RealNetSumIs.s + NetSum.ToString() + "\r\n";
                                        dr["NetSum"] = NetSum;
                                    }
                                    if ((decimal)dr["TaxSum"] != TaxSum)
                                    {
                                        sErrors += lng.s_WrongTaxSum.s + ((decimal)dr["TaxSum"]).ToString() + lng.s_ForDocInvoiceNumber.s + sNumber + lng.s_RealTaxSumIs.s + TaxSum.ToString() + "\r\n";
                                        dr["TaxSum"] = TaxSum;
                                    }
                                    if ((decimal)dr["GrossSum"] != GrossSum)
                                    {
                                        sErrors += lng.s_WrongGrossSum.s + ((decimal)dr["TaxSum"]).ToString() + lng.s_ForDocInvoiceNumber.s + sNumber + lng.s_RealGrossSumIs.s + GrossSum.ToString() + "\r\n";
                                        dr["GrossSum"] = GrossSum;
                                    }
                                }
                                picc.dt_atom_price_simpleitem = dt_atom_price_simpleitem2;
                                string sql_journal_docinvoice = "select * from journal_docinvoice where DocInvoice_ID = " + docinvoice_ID.ToString();
                                DataTable dt_journal_docinvoice = new DataTable();
                                if (DBSync.DBSync.ReadDataTable(ref dt_journal_docinvoice, sql_journal_docinvoice, ref Err))
                                {
                                    picc.dt_journal_docinvoice = dt_journal_docinvoice;
                                    DocInvoice_con_List.Add(picc);
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        if (sErrors.Length > 0)
                        {
                            MessageBox.Show(UpgradeDB_inThread.m_parent_ctrl, sErrors, "Errors:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }


                        if (UpgradeDB_inThread.DeleteTable_And_ResetAutoincrement("journal_docinvoice"))
                        {
                            if (UpgradeDB_inThread.DeleteTable_And_ResetAutoincrement("atom_price_simpleitem"))
                            {
                                if (UpgradeDB_inThread.DeleteTable_And_ResetAutoincrement("DocInvoice"))
                                {
                                    if (UpgradeDB_inThread.DeleteTable_And_ResetAutoincrement("Invoice"))
                                    {

                                        foreach (DataRow dr in dt_DocInvoice.Rows)
                                        {
                                            long new_Invoice_id = -1;
                                            if (fs.WriteRow("Invoice", dr, Column_PrefixTable, true, ref new_Invoice_id))
                                            {
                                                dr["Invoice_ID"] = new_Invoice_id;
                                                long new_DocInvoice_id = -1;
                                                if (fs.WriteRow("DocInvoice", dr, Column_PrefixTable, false, ref new_DocInvoice_id))
                                                {
                                                    DocInvoice_Connection_Class xpicc = Get_DocInvoice_Connection_Class(DocInvoice_con_List, (long)dr["ID"]);
                                                    if (xpicc != null)
                                                    {
                                                        if (!xpicc.WriteNew(new_DocInvoice_id))
                                                        {
                                                            return false;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (UpgradeDB_inThread.Set_DataBase_Version("1.04"))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private static DocInvoice_Connection_Class Get_DocInvoice_Connection_Class(List<DocInvoice_Connection_Class> DocInvoice_con_List, long DocInvoice_ID)
        {
            foreach (DocInvoice_Connection_Class picc in DocInvoice_con_List)
            {
                if (picc.ID == DocInvoice_ID)
                {
                    return picc;
                }
            }
            return null;
        }


    }
}
