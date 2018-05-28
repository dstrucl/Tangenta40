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

namespace TangentaDB
{
        public static class f_Office
        {
            public static bool Get(
                                    string Name,
                                    string ShortName,
                                    long myOrganisation_ID,
                                    ref long Office_ID)
            {

                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                string scond_Office_Name = null;
                string sval_Office_Name = "null";
                if (Name != null)
                {
                    string spar_Office_Name = "@par_Office_Name";
                    SQL_Parameter par_Office_Name = new SQL_Parameter(spar_Office_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
                    lpar.Add(par_Office_Name);
                    scond_Office_Name = "Name = " + spar_Office_Name;
                    sval_Office_Name = spar_Office_Name;
                }
                else
                {
                    scond_Office_Name = "Name is null";
                    sval_Office_Name = "null";
                }

            string scond_Office_ShortName = null;
            string sval_Office_ShortName = "null";
            if (ShortName != null)
            {
                string spar_Office_ShortName = "@par_Office_ShortName";
                SQL_Parameter par_Office_ShortName = new SQL_Parameter(spar_Office_ShortName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ShortName);
                lpar.Add(par_Office_ShortName);
                scond_Office_ShortName = "ShortName = " + spar_Office_ShortName;
                sval_Office_ShortName = spar_Office_ShortName;
            }
            else
            {
                scond_Office_ShortName = "ShortName is null";
                sval_Office_ShortName = "null";
            }
            string scond_myOrganisation_ID = null;
                string sval_myOrganisation_ID = "null";
                if (myOrganisation_ID >= 0)
                {
                    string spar_myOrganisation_ID = "@par_myOrganisation_ID";
                    SQL_Parameter par_myOrganisation_ID = new SQL_Parameter(spar_myOrganisation_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, myOrganisation_ID);
                    lpar.Add(par_myOrganisation_ID);
                    scond_myOrganisation_ID = "myOrganisation_ID = " + spar_myOrganisation_ID;
                    sval_myOrganisation_ID = spar_myOrganisation_ID;
                }
                else
                {
                    scond_myOrganisation_ID = "myOrganisation_ID is null";
                    sval_myOrganisation_ID = "null";
                }

                string sql = @"select ID from Office
                                        where (" + scond_Office_Name + ") and (" + scond_myOrganisation_ID + ")";
                string Err = null;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        Office_ID = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Office (myOrganisation_ID,
                                                            Name,
                                                            ShortName) values ("
                                                                + sval_myOrganisation_ID + ","
                                                                + sval_Office_Name + ","
                                                                + sval_Office_ShortName+
                                                                ")";
                        object objretx = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Office_ID, ref objretx, ref Err, "Office"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Office:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Office:Get:" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }

        public static bool Get(long office_ID, ref string sOfficeName, ref string sOfficeShortName)
        {
            string sql = @"select Name,ShortName from Office
                                        where ID=" + office_ID.ToString();
            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    object oname = dt.Rows[0]["Name"];
                    if (oname is string)
                    {
                        sOfficeName = (string)oname;
                    }
                    object oshortname = dt.Rows[0]["ShortName"];
                    if (oshortname is string)
                    {
                        sOfficeShortName = (string)oshortname;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Office:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


            public static bool DeleteAll()
        {
            return fs.DeleteAll("Office");
        }
    }
}
