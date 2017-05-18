using CodeTables;
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Supplier
    {
        public static bool Get(long_v Contact_ID_v,ref long_v Supplier_ID_v)
        {
            return Get("Supplier", Contact_ID_v, ref Supplier_ID_v);
        }

        public static bool Get(string Supplier_TableName,long_v Contact_ID_v, ref long_v Supplier_ID_v)
        {
            string sql = "select ID from "+ Supplier_TableName + " where Contact_ID = " + Contact_ID_v.v.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Supplier_ID_v == null)
                    {
                        Supplier_ID_v = new long_v();
                    }
                    Supplier_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into "+ Supplier_TableName + " (Contact_ID)values(" + Contact_ID_v.v.ToString() + ")";
                    long supplier_ID = -1;
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref supplier_ID, ref oret, ref Err, Supplier_TableName))
                    {
                        if (Supplier_ID_v == null)
                        {
                            Supplier_ID_v = new long_v();
                        }
                        Supplier_ID_v.v = supplier_ID;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_Supplier:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Supplier:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }

        public static bool Get(string_v Organisation_Name_v,
                   string_v Tax_ID_v,
                   string_v Registration_ID_v,
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
                   ref long_v Contact_ID_v,
                   ref long_v Supplier_ID_v)
        {
            if (f_Contact.Get(Organisation_Name_v,
                              Tax_ID_v,
                              Registration_ID_v,
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
                              Person_Gender_v,
                              FirstName_v,
                              LastName_v,
                              DateOfBirth_v,
                              Person_Tax_ID_v,
                              Person_Registration_ID_v,
                   ref cAdressAtom_Org_iD_v,
                   ref Organisation_ID_v,
                   ref OrganisationData_ID_v,
                   ref OrganisationAccount_ID_v,
                   ref Person_ID_v,
                   ref Contact_ID_v))
            {
                return f_Supplier.Get(Contact_ID_v, ref Supplier_ID_v);
            }
            else
            {
                    return false;
            }
        }

        public static bool GetData(long Supplier_ID, ref string OrganisationName,
                                               ref string Person_FirstName,
                                               ref string Person_LastName,
                                               ref long OrganisationData_ID,
                                               ref long Person_ID)
        {
            string sql = null;
            string Err = null;
            sql = "select c.OrganisationData_ID,c.Person_ID from Contact c inner join Supplier s on s.Contact_ID = c.ID where s.ID = " + Supplier_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    object oOrganisationData_ID = dt.Rows[0]["OrganisationData_ID"];
                    if (oOrganisationData_ID is long)
                    {
                        sql = "select Name from Organisation o inner join OrganisationData od on od.Organisation_ID = o.ID where od.ID = " + ((long)oOrganisationData_ID).ToString();
                        dt.Clear();
                        dt.Columns.Clear();
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                        {
                            OrganisationName = null;
                            if (dt.Rows.Count > 0)
                            {
                                object oName = dt.Rows[0]["Name"];
                                if (oName is string)
                                {
                                    OrganisationName = (string)oName;
                                }
                                else
                                {
                                    OrganisationName = null;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:f_Supplier:GetData:No Organisation data for OrganisationData_ID = " + ((long)oOrganisationData_ID).ToString());
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Supplier:GetData:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    
                    object oPerson_ID = dt.Rows[0]["Person_ID"];
                    if (oPerson_ID is long)
                    {
                        string_v FirstName_v = null;
                        string_v LastName_v = null;
                        DateTime_v DateOfBirth_v = null;
                        string_v Tax_ID_v = null;
                        string_v Registration_ID_v = null;
                        if (f_Person.GetData((long)oPerson_ID,
                                ref FirstName_v,
                                ref LastName_v,
                                ref DateOfBirth_v,
                                ref Tax_ID_v,
                                ref Registration_ID_v
                                ))
                        {
                            if (FirstName_v != null)
                            {
                                Person_FirstName = FirstName_v.v;
                            }
                            else
                            {
                                Person_FirstName = null;
                            }
                            if (LastName_v != null)
                            {
                                Person_LastName = LastName_v.v;
                            }
                            else
                            {
                                Person_LastName = null;
                            }

                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Supplier:GetData:No Person data for Person ID = " + ((long)oPerson_ID).ToString());
                            return false;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Supplier:GetData:No Contact data for Supplier ID = " + Supplier_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Supplier:GetData:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}