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
    }
}
