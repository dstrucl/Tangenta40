using DBConnectionControl40;
using LanguageControl;
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
            public string Addressee = "";

            public f_DocProformaInvoice_ShopC_Item.fData ShopC_Item_Data = new f_DocProformaInvoice_ShopC_Item.fData();
        }

        public static bool Get(ID docProformaInvoice_ID,ID docInvoice_ShopC_Item_ID, ref fData data)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select dpi.Draft,
                                  dpi.DraftNumber,
                                  dpi.FinancialYear,
                                  dpi.NumberInFinancialYear,
                                  ap.Gender,
                                  acfn.FirstName,
                                  acfl.LastName,
                                  ao.Name as Organisation_Name,
                                  ao.Tax_ID as Organisation_Tax_ID,
                                  acp.Atom_Person_ID,
                                  aco.Atom_Organisation_ID
                                  from DocProformaInvoice dpi
                                  left join Atom_Customer_Person acp on dpi.Atom_Customer_Person_ID = acp.ID
                                  left join Atom_Person ap on acp.Atom_Person_ID = ap.ID
                                  left join Atom_cFirstName acfn on ap.Atom_cFirstName_ID = acfn.ID
                                  left join Atom_cLastName acfl on ap.Atom_cLastName_ID = acfl.ID
                                  left join Atom_Customer_Org aco on dpi.Atom_Customer_Org_ID = aco.ID
                                  left join Atom_Organisation ao on aco.Atom_Organisation_ID = ao.ID

                        
                                  where dpi.ID = " + docProformaInvoice_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    data.bDraft = DBTypes.tf._set_bool(dt.Rows[0]["Draft"]);
                    data.DraftNumber = DBTypes.tf._set_long(dt.Rows[0]["DraftNumber"]);
                    data.FinancialYear = DBTypes.tf._set_long(dt.Rows[0]["FinancialYear"]);
                    data.NumberInFinancialYear = DBTypes.tf._set_long(dt.Rows[0]["NumberInFinancialYear"]);
                    data.Addressee = "";
                    if (!(dt.Rows[0]["Atom_Person_ID"] is System.DBNull))
                    {
                        data.Addressee = lng.s_PhisycalPerson.s + ":";
                        bool Gender = DBTypes.tf._set_bool(dt.Rows[0]["Gender"]);
                        string sFirstName = DBTypes.tf._set_string(dt.Rows[0]["FirstName"]);
                        string sLastName = DBTypes.tf._set_string(dt.Rows[0]["LastName"]);
                        if (Gender)
                        {
                            data.Addressee += lng.s_Man.s;
                        }
                        else
                        {
                            data.Addressee +=  lng.s_Woman.s;
                        }

                        data.Addressee += ":" + sFirstName + " " + sLastName;
                    }
                    else if (!(dt.Rows[0]["Atom_Organisation_ID"] is System.DBNull))
                    {
                        string s_organisation_name =
                        data.Addressee = lng.s_Organisation.s + ":" + DBTypes.tf._set_string(dt.Rows[0]["Organisation_Name"])+" "+
                                   lng.s_Tax_ID.s + ":" + DBTypes.tf._set_string(dt.Rows[0]["Organisation_Tax_ID"]);
                    }
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
        public static bool GetExistingFinancialYears(ref DataTable dt_FinancialYears)
        {
            string sql = "select distinct FinancialYear from DocProformaInvoice";
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
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:GetExistingFinancialYears:sql:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetItems(ID currentDoc_ID, ref DataTable dtShopCItems)
        {
            string sql = @"select
                                   dpisci.ID as DocProformaInvoice_ShopC_Item_ID,
                                   dpisci.dQuantity,
                                   dpisci.ExtraDiscount,
                                   dpisci.RetailPriceWithDiscount,
                                   dpisci.TaxPrice,
                                   dpisci.DocProformaInvoice_ID,
                                   dpisci.Atom_Price_Item_ID,
                                   dpisci.ExpiryDate,
                                   dpisci.Stock_ID,
                                   api.RetailPricePerUnit as api_RetailPricePerUnit,
                                   api.Discount as api_Discount,
                                   api.Atom_Taxation_ID as api_Atom_Taxation_ID,
                                   api.Atom_Item_ID as api_Atom_Item_ID, 
                                   api.Atom_PriceList_ID as api_Atom_PriceList_ID,
								   s.ImportTime as Stock_ImportTime,
								   s.dQuantity as Stock_dQuantity,
								   s.ExpiryDate as Stock_ExpiryDate,
								   s.PurchasePrice_Item_ID as PurchasePrice_Item_ID,
								   s.Stock_AddressLevel1_ID as Stock_AddressLevel1_ID,
								   s.Description as Stock_Description,
                                   s.ExpiryDate as Stock_ExpiriyDate,
								   ppi.Item_ID as ppi_Item_ID,
								   ppi.PurchasePrice_ID as ppi_PurchasePrice_ID,
								   ppi.StockTake_ID as ppi_StockTake_ID,
                                  st.Name as StockTakeName,
                                  st.StockTake_Date
                                  from DocproformaInvoice_ShopC_Item dpisci
                                  left join Stock s on dpisci.Stock_ID = s.ID

                                  left join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID

                                  left join PurchasePrice pp on pp.ID = ppi_PurchasePrice_ID
                                  left join StockTake st on ppi.StockTake_ID = st.ID

                                  left join Item i on i.ID = ppi.Item_ID
                                  left join Atom_Price_Item api on dpisci.Atom_Price_Item_ID = api.ID
                                  left join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
                                  left join Atom_Item ai on api.Atom_Item_ID = ai.ID
                                  left join Atom_PriceList apl on api.Atom_PriceList_ID = apl.ID
                                  where dpisci.DocProformaInvoice_ID = " + currentDoc_ID.ToString();
            if (dtShopCItems == null)
            {
                dtShopCItems = new DataTable();
            }
            else
            {
                dtShopCItems.Clear();
                dtShopCItems.Columns.Clear();
            }
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dtShopCItems, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoice_ShopC_Item:GetItems:sql=" + sql + "\r\nErr" + Err);
                return false;
            }

        }

        public static bool Get_ShopC_ProformaInvoices(ref DataTable dtDoc)
        {
            string Err = null;
            if (dtDoc == null)
            {
                dtDoc = new DataTable();
            }
            else
            {
                dtDoc.Clear();
                dtDoc.Columns.Clear();
            }

            string sql = @"select
							     dpi.ID as DocProformaInvoice_ID,
								 dpi.Draft,
                                 dpi.DraftNumber,
                                 dpi.FinancialYear,
                                 dpi.NumberInFinancialYear,
								 dpi.GrossSum,
								 pt.Identification as Payment_Identification,
								 pt.Name as Payment_Name,
								 aba.TRR as BankAccount_TRR,
								 aba.Active as BankAccount_Avtive,
								 abao.Name as Bank_Name,
								 an.NoticeText,
                                    ap.Gender,
                                    acfn.FirstName,
                                    acfl.LastName,
                                    ao.Name as Organisation_Name,
                                    ao.Tax_ID as Organisation_Tax_ID,
                                    acp.Atom_Person_ID,
                                    aco.Atom_Organisation_ID
                                 from DocProformaInvoice dpi
                                  left join Atom_Customer_Person acp on dpi.Atom_Customer_Person_ID = acp.ID
                                  left join Atom_Person ap on acp.Atom_Person_ID = ap.ID
                                  left join Atom_cFirstName acfn on ap.Atom_cFirstName_ID = acfn.ID
                                  left join Atom_cLastName acfl on ap.Atom_cLastName_ID = acfl.ID
                                  left join Atom_Customer_Org aco on dpi.Atom_Customer_Org_ID = aco.ID
                                  left join Atom_Organisation ao on aco.Atom_Organisation_ID = ao.ID
								  left join DocProformaInvoiceAddOn dpiaon on  dpiaon.DocProformaInvoice_ID = dpi.ID
								  left join TermsOfPayment top on dpiaon .TermsOfPayment_ID = top.ID 
								  left join MethodOfPayment_DPI omopdpi on omopdpi.ID = dpiaon .MethodOfPayment_DPI_ID
								  left join PaymentType pt on pt.ID = omopdpi.PaymentType_ID
								  left join Atom_BankAccount aba on aba.ID = omopdpi.Atom_BankAccount_ID
								  left join Atom_Bank ab on ab.ID = aba.Atom_Bank_ID 
								  left join Atom_Organisation abao on  abao.ID = ab.Atom_Organisation_ID
								  left join Atom_Warranty aw on aw.ID = dpiaon.Atom_Warranty_ID 
								  left join Atom_Notice an on an.ID = dpiaon.Atom_Notice_ID
								  left join Doc_ImageLib docIL on docIL.ID = dpiaon.Doc_ImageLib_ID
								  where dpi.ID in (select DocProformaInvoice_ID from DocProformaInvoice_ShopC_Item Group by DocProformaInvoice_ID)";
            if (DBSync.DBSync.ReadDataTable(ref dtDoc, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoice:Get_ShopC_ProformaInvoices:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }
        public static bool Get_ShopC_ProformaInvoices_FromStock(ref DataTable dtDoc)
        {
            string Err = null;
            if (dtDoc == null)
            {
                dtDoc = new DataTable();
            }
            else
            {
                dtDoc.Clear();
                dtDoc.Columns.Clear();
            }

            string sql = @"select
							     dpi.ID as DocProformaInvoice_ID,
								 dpi.Draft,
                                 dpi.DraftNumber,
                                 dpi.FinancialYear,
                                 dpi.NumberInFinancialYear,
								 dpi.GrossSum,
								 pt.Identification as Payment_Identification,
								 pt.Name as Payment_Name,
								 aba.TRR as BankAccount_TRR,
								 aba.Active as BankAccount_Avtive,
								 abao.Name as Bank_Name,
								 an.NoticeText,
                                    ap.Gender,
                                    acfn.FirstName,
                                    acfl.LastName,
                                    ao.Name as Organisation_Name,
                                    ao.Tax_ID as Organisation_Tax_ID,
                                    acp.Atom_Person_ID,
                                    aco.Atom_Organisation_ID
                                 from DocProformaInvoice dpi
                                  left join Atom_Customer_Person acp on dpi.Atom_Customer_Person_ID = acp.ID
                                  left join Atom_Person ap on acp.Atom_Person_ID = ap.ID
                                  left join Atom_cFirstName acfn on ap.Atom_cFirstName_ID = acfn.ID
                                  left join Atom_cLastName acfl on ap.Atom_cLastName_ID = acfl.ID
                                  left join Atom_Customer_Org aco on dpi.Atom_Customer_Org_ID = aco.ID
                                  left join Atom_Organisation ao on aco.Atom_Organisation_ID = ao.ID
								  left join DocProformaInvoiceAddOn dpiaon on  dpiaon.DocProformaInvoice_ID = dpi.ID
								  left join TermsOfPayment top on dpiaon .TermsOfPayment_ID = top.ID 
								  left join MethodOfPayment_DPI omopdpi on omopdpi.ID = dpiaon .MethodOfPayment_DPI_ID
								  left join PaymentType pt on pt.ID = omopdpi.PaymentType_ID
								  left join Atom_BankAccount aba on aba.ID = omopdpi.Atom_BankAccount_ID
								  left join Atom_Bank ab on ab.ID = aba.Atom_Bank_ID 
								  left join Atom_Organisation abao on  abao.ID = ab.Atom_Organisation_ID
								  left join Atom_Warranty aw on aw.ID = dpiaon.Atom_Warranty_ID 
								  left join Atom_Notice an on an.ID = dpiaon.Atom_Notice_ID
								  left join Doc_ImageLib docIL on docIL.ID = dpiaon.Doc_ImageLib_ID
								  where dpi.ID in (select DocProformaInvoice_ID from DocProformaInvoice_ShopC_Item where Stock_ID is not null Group by DocProformaInvoice_ID)";
            if (DBSync.DBSync.ReadDataTable(ref dtDoc, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoice:Get_ShopC_ProformaInvoices_FromStock:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }
    }
}
