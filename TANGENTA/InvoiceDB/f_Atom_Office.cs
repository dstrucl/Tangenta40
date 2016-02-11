#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public static class f_Atom_Office
    {
        public static bool Get(
                                 long Office_ID,
                                 ref long Atom_Office_ID)
        {

            string Office_Name = null;
            string Office_ShortName = null;
            long myCompany_ID = -1;

            string sql = @"select 
                            o.Name as Office_Name,
                            o.ShortName as Office_ShortName,
                            o.myCompany_ID
                            from Office o
                            where o.ID = " + Office_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    object o_Office_Name = dt.Rows[0]["Office_Name"];
                    if (o_Office_Name is string)
                    {
                        Office_Name = (string)o_Office_Name;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Office:Get:No Office_Name is null!");
                        return false;
                    }

                    object o_Office_ShortName = dt.Rows[0]["Office_ShortName"];
                    if (o_Office_ShortName is string)
                    {
                        Office_ShortName = (string)o_Office_ShortName;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Office:Get:No Office_ShortName is null!");
                        return false;
                    }

                    object o_myCompany_ID = dt.Rows[0]["myCompany_ID"];
                    if (o_myCompany_ID is long)
                    {
                        myCompany_ID = (long)o_myCompany_ID;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Office:Get:Organisation_Name is null!");
                        return false;
                    }

                    long Atom_myCompany_ID = -1;
                    if (f_Atom_myCompany.Get(myCompany_ID, ref Atom_myCompany_ID))
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                        string scond_Atom_Office_Name = null;
                        string sval_Atom_Office_Name = "null";
                        if (Office_Name != null)
                        {
                            string spar_Office_Name = "@par_Office_Name";
                            SQL_Parameter par_Office_Name = new SQL_Parameter(spar_Office_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Office_Name);
                            lpar.Add(par_Office_Name);
                            scond_Atom_Office_Name = "Name = " + spar_Office_Name;
                            sval_Atom_Office_Name = spar_Office_Name;
                        }
                        else
                        {
                            scond_Atom_Office_Name = "Name is null";
                            sval_Atom_Office_Name = "null";
                        }

                        string scond_Atom_Office_ShortName = null;
                        string sval_Atom_Office_ShortName = "null";
                        if (Office_ShortName != null)
                        {
                            string spar_Office_ShortName = "@par_Office_ShortName";
                            SQL_Parameter par_Office_ShortName = new SQL_Parameter(spar_Office_ShortName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Office_ShortName);
                            lpar.Add(par_Office_ShortName);
                            scond_Atom_Office_ShortName = "ShortName = " + spar_Office_ShortName;
                            sval_Atom_Office_ShortName = spar_Office_ShortName;
                        }
                        else
                        {
                            scond_Atom_Office_ShortName = "ShortName is null";
                            sval_Atom_Office_ShortName = "null";
                        }

                        string scond_Atom_myCompany_ID = null;
                        string sval_Atom_myCompany_ID = "null";
                        if (Atom_myCompany_ID >= 0)
                        {
                            string spar_Atom_myCompany_ID = "@par_Atom_myCompany_ID";
                            SQL_Parameter par_Atom_myCompany_ID = new SQL_Parameter(spar_Atom_myCompany_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_myCompany_ID);
                            lpar.Add(par_Atom_myCompany_ID);
                            scond_Atom_myCompany_ID = "Atom_myCompany_ID = " + spar_Atom_myCompany_ID;
                            sval_Atom_myCompany_ID = spar_Atom_myCompany_ID;
                        }
                        else
                        {
                            scond_Atom_myCompany_ID = "Atom_myCompany_ID is null";
                            sval_Atom_myCompany_ID = "null";
                        }

                        sql = @"select ID from Atom_Office where (" + scond_Atom_Office_Name + ")and("+ scond_Atom_Office_ShortName + ")and(" + scond_Atom_myCompany_ID + ")";
                        dt.Clear();
                        dt.Columns.Clear();
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_Office_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_Office (Atom_myCompany_ID,
                                                                    Name,
                                                                    ShortName) values 
                                                                    ("
                                                                        + sval_Atom_myCompany_ID + ","
                                                                        + sval_Atom_Office_Name + ","
                                                                        + sval_Atom_Office_ShortName +
                                                                        ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Office_ID, ref objretx, ref Err, "Atom_Office"))
                                {

                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_Office:Get:" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }

                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_Office:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_Office:Get:No Company data link for Office_ID=" + Office_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Office:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
