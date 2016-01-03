using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public static class f_Atom_Office_Data
    {
        internal static bool Get(
                                 long Office_Data_ID,
                                 ref long Atom_Office_Data_ID)
        {

            long cAddress_Org_ID = -1;
            long myCompany_Person_ID = -1;
            long Office_ID = -1;
            string Description = null;
            string sql = @"select 
                            od.Office_ID,
                            od.cAddress_Org_ID,
                            od.myCompany_Person_ID,
                            od.Description
                            from Office_Data od
                            where od.ID = " + Office_Data_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    object o_Office_ID = dt.Rows[0]["Office_ID"];
                    if (o_Office_ID is long)
                    {
                        Office_ID = (long)o_Office_ID;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:Office_ID is null!");
                        return false;
                    }

                    object o_cAddress_Org_ID = dt.Rows[0]["cAddress_Org_ID"];
                    if (o_cAddress_Org_ID is long)
                    {
                        cAddress_Org_ID = (long)o_cAddress_Org_ID;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:cAddress_Org_ID is null!");
                        return false;
                    }

                    object o_myCompany_Person_ID = dt.Rows[0]["myCompany_Person_ID"];
                    if (o_myCompany_Person_ID is long)
                    {
                        myCompany_Person_ID = (long)o_cAddress_Org_ID;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:myCompany_Person_ID is null!");
                        return false;
                    }

                    object o_Description = dt.Rows[0]["Description"];
                    if (o_Description is string)
                    {
                        Description = (string)o_Description;
                    }

                    long Atom_myCompany_Person_ID = -1;
                    long Atom_cAddress_Org_ID = -1;
                    long Atom_Office_ID = -1;

                    if (f_Atom_Office.Get(Office_ID, ref Atom_Office_ID))
                    {
                        if (f_Atom_cAddress_Org.Get(cAddress_Org_ID, ref Atom_cAddress_Org_ID))
                        {
                            DBTypes.string_v Office_Name = new DBTypes.string_v();
                            myOrg.enum_GetCompany_Person_Data res = f_Atom_myCompany_Person.Get(myCompany_Person_ID, ref Atom_myCompany_Person_ID, ref Office_Name);
                            if (res == myOrg.enum_GetCompany_Person_Data.MyCompany_Data_OK)
                            {
                                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                                string scond_Description = null;
                                string sval_Description = "null";
                                if (Description != null)
                                {
                                    string spar_Description = "@par_Description";
                                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                                    lpar.Add(par_Description);
                                    scond_Description = "Description = " + spar_Description;
                                    sval_Description = spar_Description;
                                }
                                else
                                {
                                    scond_Description = "Description is null";
                                    sval_Description = "null";
                                }


                                sql = @"select
                                        ID
                                        from Atom_Office_Data
                                        where  Atom_Office_ID = " + Atom_Office_ID.ToString() + @" and 
                                               Atom_cAddress_Org_ID = " + Atom_cAddress_Org_ID.ToString() + @" and
                                               Atom_myCompany_Person_ID = " + Atom_myCompany_Person_ID.ToString() + @" and 
                                               " + scond_Description;
                                dt.Clear();
                                dt.Columns.Clear();
                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                                {
                                    if (dt.Rows.Count>0)
                                    {
                                        Atom_Office_Data_ID = (long)dt.Rows[0]["ID"];
                                        return true;
                                    }
                                    else
                                    {
                                        sql = @"insert into Atom_Office_Data (Atom_Office_ID,Atom_cAddress_Org_ID,Atom_myCompany_Person_ID,Description) values (" + Atom_Office_ID.ToString() + "," + Atom_cAddress_Org_ID.ToString() + "," + Atom_myCompany_Person_ID.ToString() + "," + sval_Description + ")";
                                        object objretx = null;
                                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Office_Data_ID, ref objretx, ref Err, "Atom_Office_Data"))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:" + sql + "\r\nErr=" + Err);
                                        }
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:sql=" + sql + "\r\nErr=" + Err);
                                }
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:No Office_Data data link for Office_Data_ID =" + Office_Data_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
