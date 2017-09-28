using CodeTables;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Contact
    {
        public static bool Get(string_v Organisation_Name_v,
                           string_v Tax_ID_v,
                           string_v Registration_ID_v,
                           bool_v TaxPayer_v,
                           string_v Comment1_v,
                           string_v Comment2_v,
                           string_v OrganisationTYPE_v,
                           PostAddress_v Address_v,
                           string_v PhoneNumber_v,
                           string_v FaxNumber_v,
                           string_v Email_v,
                           string_v HomePage_v,
                           long_v BankAccount_ID_v,
                           string_v Organisation_BankAccount_Description_v,
                           string_v Image_Hash_v,
                           byte_array_v Image_Data_v,
                           string_v Image_Description_v,
                           bool_v Person_Gender_v,
                           string_v FirstName_v,
                           string_v LastName_v,
                           DateTime_v DateOfBirth_v,
                           string_v Person_Tax_ID_v,
                           string_v Person_Registration_ID_v,
                           ref ID_v cAdressAtom_Org_iD_v,
                           ref long_v Organisation_ID_v,
                           ref long_v OrganisationData_ID_v,
                           ref long_v OrganisationAccount_ID_v,
                           ref long_v Person_ID_v,
                           ref long_v Contact_ID_v)
        {
            if (f_Organisation.Get(Organisation_Name_v,
                                   Tax_ID_v,
                                   Registration_ID_v,
                                   TaxPayer_v,
                                   Comment1_v,
                                   Comment2_v,
                                   OrganisationTYPE_v,
                                   Address_v,
                                   PhoneNumber_v,
                                   FaxNumber_v,
                                   Email_v,
                                   HomePage_v,
                                   BankAccount_ID_v,
                                   Organisation_BankAccount_Description_v,
                                   Image_Hash_v,
                                   Image_Data_v,
                                   Image_Description_v,
                                   ref cAdressAtom_Org_iD_v,
                                   ref Organisation_ID_v,
                                   ref OrganisationData_ID_v,
                                   ref OrganisationAccount_ID_v
            ))
            {
                string sql_select = null;
                string sql_insert = null;
                if (FirstName_v != null)
                {
                    if (f_Person.Get(Person_Gender_v,
                                    FirstName_v,
                                    LastName_v,
                                    DateOfBirth_v,
                                    Person_Tax_ID_v,
                                    Person_Registration_ID_v,
                                    ref Person_ID_v))
                    {
                        sql_select = "select ID from Contact where OrganisationData_ID = " + OrganisationData_ID_v.v.ToString() + " and Person_ID =" + Person_ID_v.v.ToString() + ";";
                        sql_insert = "insert into Contact (OrganisationData_ID,Person_ID)values(" + OrganisationData_ID_v.v.ToString() + "," + Person_ID_v.v.ToString() + ");";
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    sql_select = "select ID from Contact where OrganisationData_ID = " + OrganisationData_ID_v.v.ToString() + " and Person_ID is null";
                    sql_insert = "insert into Contact (OrganisationData_ID,Person_ID)values(" + OrganisationData_ID_v.v.ToString() + ",null);";
                }

                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, null, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Contact_ID_v == null)
                        {
                            Contact_ID_v = new long_v();
                        }
                        Contact_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        long Contact_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, null, ref Contact_ID, ref oret, ref Err, "Contact"))
                        {
                            if (Contact_ID_v == null)
                            {
                                Contact_ID_v = new long_v();
                            }
                            Contact_ID_v.v = Contact_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Contact:Get: sql=" + sql_insert + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Contact:Get: sql=" + sql_select + "\r\nErr=" + Err);
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
