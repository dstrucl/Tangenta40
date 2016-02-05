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
    public static class f_Atom_WorkPeriod_Type
    {
        public static bool Get(string Atom_WorkPeriod_Type_Name,
                                 string Atom_WorkPeriod_Type_Description,
                                 ref long Atom_WorkPeriod_Type_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string scond_Atom_WorkPeriod_Type_Name = null;
            string sval_Atom_WorkPeriod_Type_Name = "null";
            if (Atom_WorkPeriod_Type_Name != null)
            {
                string spar_Atom_WorkPeriod_Type_Name = "@par_Atom_WorkPeriod_Type_Name";
                SQL_Parameter par_Atom_WorkPeriod_Type_Name = new SQL_Parameter(spar_Atom_WorkPeriod_Type_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Atom_WorkPeriod_Type_Name);
                lpar.Add(par_Atom_WorkPeriod_Type_Name);
                scond_Atom_WorkPeriod_Type_Name = "Name = " + spar_Atom_WorkPeriod_Type_Name;
                sval_Atom_WorkPeriod_Type_Name = spar_Atom_WorkPeriod_Type_Name;
            }
            else
            {
                scond_Atom_WorkPeriod_Type_Name = "Name is null";
                sval_Atom_WorkPeriod_Type_Name = "null";
            }


            string sql = @"select ID from Atom_WorkPeriod_Type
                                            where " + scond_Atom_WorkPeriod_Type_Name;


            string Err = null;
            DataTable dt = new DataTable();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_WorkPeriod_Type_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    string scond_Atom_WorkPeriod_Type_Description = null;
                    string sval_Atom_WorkPeriod_Type_Description = "null";
                    if (Atom_WorkPeriod_Type_Description != null)
                    {
                        string spar_Atom_WorkPeriod_Type_Description = "@par_Atom_WorkPeriod_Type_Description";
                        SQL_Parameter par_Atom_WorkPeriod_Type_Description = new SQL_Parameter(spar_Atom_WorkPeriod_Type_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Atom_WorkPeriod_Type_Description);
                        lpar.Add(par_Atom_WorkPeriod_Type_Description);
                        scond_Atom_WorkPeriod_Type_Description = "Description = " + spar_Atom_WorkPeriod_Type_Description;
                        sval_Atom_WorkPeriod_Type_Description = spar_Atom_WorkPeriod_Type_Description;
                    }
                    else
                    {
                        scond_Atom_WorkPeriod_Type_Description = "Description is null";
                        sval_Atom_WorkPeriod_Type_Description = "null";
                    }
                    sql = @"insert into Atom_WorkPeriod_Type (Name,Description) values (" + sval_Atom_WorkPeriod_Type_Name + ","+sval_Atom_WorkPeriod_Type_Description+")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_WorkPeriod_Type_ID, ref objretx, ref Err, "Atom_WorkPeriod_Type"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_WorkPeriod_Type:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkPeriod_Type:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
