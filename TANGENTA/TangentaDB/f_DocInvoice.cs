using DBConnectionControl40;
using DBTypes;
using LanguageControl;
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
            public string Addressee = "";
            public f_DocInvoice_ShopC_Item.fData ShopC_Item_Data = new f_DocInvoice_ShopC_Item.fData();
        }


        public static bool Get(ID docInvoice_ID,ID docInvoice_ShopC_Item_ID, ref fData ret_data)
        {
            string Err = null;
            DataTable dt = new DataTable();
            if (ret_data == null)
            {
                ret_data = new fData();
            }
            string sql = @"select di.Draft,
                                 di.DraftNumber,
                                 di.FinancialYear,
                                 di.NumberInFinancialYear,
                                    ap.Gender,
                                    acfn.FirstName,
                                    acfl.LastName,
                                    ao.Name as Organisation_Name,
                                    ao.Tax_ID as Organisation_Tax_ID,
                                    acp.Atom_Person_ID,
                                    aco.Atom_Organisation_ID
                                 from DocInvoice di
                                  left join Atom_Customer_Person acp on di.Atom_Customer_Person_ID = acp.ID
                                  left join Atom_Person ap on acp.Atom_Person_ID = ap.ID
                                  left join Atom_cFirstName acfn on ap.Atom_cFirstName_ID = acfn.ID
                                  left join Atom_cLastName acfl on ap.Atom_cLastName_ID = acfl.ID
                                  left join Atom_Customer_Org aco on di.Atom_Customer_Org_ID = aco.ID
                                  left join Atom_Organisation ao on aco.Atom_Organisation_ID = ao.ID
                                  where di.ID = " + docInvoice_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err ))
            {
                if (dt.Rows.Count > 0)
                {
                    ret_data.bDraft = DBTypes.tf._set_bool(dt.Rows[0]["Draft"]);
                    ret_data.DraftNumber = DBTypes.tf._set_int(dt.Rows[0]["DraftNumber"]);
                    ret_data.FinancialYear = DBTypes.tf._set_int(dt.Rows[0]["FinancialYear"]);
                    ret_data.NumberInFinancialYear = DBTypes.tf._set_int(dt.Rows[0]["NumberInFinancialYear"]);
                    ret_data.Addressee = "";
                    if (!(dt.Rows[0]["Atom_Person_ID"] is System.DBNull))
                    {
                        ret_data.Addressee = lng.s_PhisycalPerson.s + ":";
                        bool Gender = DBTypes.tf._set_bool(dt.Rows[0]["Gender"]);
                        string sFirstName = DBTypes.tf._set_string(dt.Rows[0]["FirstName"]);
                        string sLastName = DBTypes.tf._set_string(dt.Rows[0]["LastName"]);
                        if (Gender)
                        {
                            ret_data.Addressee += lng.s_Man.s;
                        }
                        else
                        {
                            ret_data.Addressee  += lng.s_Woman.s;
                        }

                        ret_data.Addressee += ":" + sFirstName + " " + sLastName;
                    }
                    else if (!(dt.Rows[0]["Atom_Organisation_ID"] is System.DBNull))
                    {
                        string s_organisation_name =
                        ret_data.Addressee = lng.s_Organisation.s + ":" + DBTypes.tf._set_string(dt.Rows[0]["Organisation_Name"]) + " " +
                                   lng.s_Tax_ID.s + ":" + DBTypes.tf._set_string(dt.Rows[0]["Organisation_Tax_ID"]);
                    }

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

        public static bool GetExistingFinancialYears(ref DataTable dt_FinancialYears)
        {
            string sql = "select distinct FinancialYear from DocInvoice";
            string Err = null;
            if (dt_FinancialYears==null)
            {
                dt_FinancialYears = new DataTable();
            }
            dt_FinancialYears.Clear();
            dt_FinancialYears.Columns.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_FinancialYears, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:GetExistingFinancialYears:sql:"+sql+"\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetTaxSum(ID DocInvoice_ID, StaticLib.TaxSum taxSum)
        {
            string Err = null;
            //ShopA
            //string sqlA = @"
            //    select disai.DocInvoice_ID,
            //           disai.Atom_ItemShopA_ID,
            //           disai.Discount,
            //           disai.dQuantity,
            //           disai.PricePerUnit,
            //           disai.EndPriceWithDiscountAndTax,
            //           disai.TAX,
            //           aisa.Name as ItemName,
            //           aisa.Description as ItemDescription,
            //           aisa.Taxation_ID,
            //           aisa.Unit_ID,
            //           aisa.Supplier_ID,
            //           aisa.VisibleForSelection,
            //           tax.Name as TaxName,
            //           tax.Rate  as Taxrate
            //           from DocInvoice_ShopA_Item disai
            //           inner join Atom_ItemShopA aisa on disai.Atom_ItemShopA_ID = aisa.ID
            //           inner join Taxation tax on aisa.Taxation_ID = tax.ID
            //           where DocInvoice_ID = " + DocInvoice_ID.ToString();
            string sqlA = @"
                            select 
                                   'ShopA' as ShopName,
                                   disai.TAX as TaxPrice,
                                   disai.Discount,
                                   disai.dQuantity,
                                   disai.PricePerUnit,
                                   tax.Name as TaxName,
                                   tax.Rate  as Taxrate
                                   from DocInvoice_ShopA_Item disai
                                   inner join Atom_ItemShopA aisa on disai.Atom_ItemShopA_ID = aisa.ID
                                   inner join Taxation tax on aisa.Taxation_ID = tax.ID
                                   where DocInvoice_ID = " + DocInvoice_ID.ToString();

            DataTable dtitemtaxA = new DataTable();

            if (!DBSync.DBSync.ReadDataTable(ref dtitemtaxA, sqlA, ref Err))
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:GetTaxSum:sqlA=" + sqlA + "\r\nErr=" + Err);
                return false;
            }
            //ShopB
            DataTable dtitemtax = new DataTable();



            string sqlB = @"
                        select
                        'ShopB' as ShopName,
                        disbi.TaxPrice as TaxPrice,
                        disbi.RetailSimpleItemPriceWithDiscount as Total,
                        atax.Name as TaxName,
                        atax.Rate as TaxRate
                        from DocInvoice_ShopB_Item disbi
                        inner join Atom_Taxation  atax on disbi.Atom_Taxation_ID = atax.ID
                        where DocInvoice_ID = " + DocInvoice_ID.ToString();
            if (!DBSync.DBSync.ReadDataTable(ref dtitemtax, sqlB, ref Err))
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:GetTaxSum:sqlB=" + sqlB + "\r\nErr=" + Err);
                return false;
            }

            //Import rows from ShopA
            if (dtitemtaxA.Rows.Count>0)
            {
                foreach (DataRow drA in dtitemtaxA.Rows)
                {
                    decimal_v Discount_v = tf.set_decimal(drA["Discount"]);
                    if (Discount_v==null)
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:GetTaxSum:Discount_v == null");
                        return false;
                    }
                    decimal_v dQuantity_v = tf.set_decimal(drA["dQuantity"]);
                    if (dQuantity_v == null)
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:GetTaxSum:dQuantity_v == null");
                        return false;
                    }

                    decimal_v PricePerUnit_v =tf.set_decimal(drA["PricePerUnit"]);
                    if (PricePerUnit_v == null)
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:GetTaxSum:PricePerUnit_v == null");
                        return false;
                    }

                    decimal_v xTaxRate_v = tf.set_decimal(drA["TaxRate"]);
                    if (xTaxRate_v == null)
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:GetTaxSum:xTaxRate_v == null");
                        return false;
                    }

                    decimal dxbase = PricePerUnit_v.v * Discount_v.v;
                    dxbase = decimal.Round(dxbase, GlobalData.BaseCurrency.DecimalPlaces);
                    decimal dxbaseTotal =dxbase * dQuantity_v.v;

                    decimal dtaxbase = decimal.Round(dxbaseTotal, GlobalData.BaseCurrency.DecimalPlaces);
                    decimal dxtotal = dtaxbase * (1 + xTaxRate_v.v);
                    decimal dtotal =  decimal.Round(dxtotal, GlobalData.BaseCurrency.DecimalPlaces);

                    DataRow drnew = dtitemtax.NewRow();
                    drnew["ShopName"] = "ShopA";
                    drnew["TaxPrice"] = drA["TaxPrice"];
                    drnew["Total"] = dtotal;
                    drnew["TaxName"] = drA["TaxName"];
                    drnew["TaxRate"] = drA["TaxRate"];
                    dtitemtax.Rows.Add(drnew);
                }
            }

            //ShopC
            string sqlC = @"
                         select 
                       'ShopC' as ShopName,
                        disci.TaxPrice as TaxPrice,
                        disci.RetailPriceWithDiscount as Total,
                        atax.Name as TaxName,
                        atax.Rate as TaxRate
                        from  DocInvoice_ShopC_Item disci
                        inner join Atom_Price_Item api on api.ID = disci.Atom_Price_Item_ID
                        inner join Atom_Taxation  atax on api.Atom_Taxation_ID = atax.ID
                        where DocInvoice_ID = " + DocInvoice_ID.ToString();
            if (!DBSync.DBSync.ReadDataTable(ref dtitemtax, sqlC, ref Err))
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:GetTaxSum:sqlC=" + sqlC + "\r\nErr=" + Err);
                return false;
            }
            int idtitemtax_count = dtitemtax.Rows.Count;

            for (int j = 0; j < idtitemtax_count; j++)
            {
                DataRow drj = dtitemtax.Rows[j];

                decimal_v tax_v = tf.set_decimal(drj["TaxPrice"]);
                if (tax_v != null)
                {
                    decimal_v total_v = tf.set_decimal(drj["Total"]);
                    if (total_v != null)
                    {
                        string_v tax_name_v = tf.set_string(drj["TaxName"]);
                        if (tax_name_v != null)
                        {
                            decimal_v tax_rate_v = tf.set_decimal(drj["TaxRate"]);
                            if (tax_rate_v != null)
                            {
                                decimal taxbase = total_v.v - tax_v.v;
                                taxSum.Add(tax_v.v, taxbase, tax_name_v.v, tax_rate_v.v);
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
