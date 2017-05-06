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
        public static bool GetData(long Supplier_ID, ref bool bOrganisation,
                                               ref string OrganisationName,
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
                        bOrganisation = true;
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
                                return true;
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
                    else
                    {
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
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:f_Supplier:GetData:No Person data for Person ID = " + ((long)oPerson_ID).ToString());
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
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