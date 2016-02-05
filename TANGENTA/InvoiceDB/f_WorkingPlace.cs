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
    public static class f_WorkingPlace
    {
        public static bool Get(string WorkingPlace_Name,string Description,ref long WorkingPlace_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();


            string Err = null;
            DataTable dt = new DataTable();

            string scond_WorkingPlace_Name = null;
            string sval_WorkingPlace_Name = "null";
            if (WorkingPlace_Name != null)
            {
                string spar_WorkingPlace_Name = "@par_WorkingPlace_Name";
                SQL_Parameter par_WorkingPlace_Name = new SQL_Parameter(spar_WorkingPlace_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, WorkingPlace_Name);
                lpar.Add(par_WorkingPlace_Name);
                scond_WorkingPlace_Name = "Name = " + spar_WorkingPlace_Name;
                sval_WorkingPlace_Name = spar_WorkingPlace_Name;
            }
            else
            {
                scond_WorkingPlace_Name = "Name is null";
                sval_WorkingPlace_Name = "null";
            }

            string scond_WorkingPlace_Description = null;
            string sval_WorkingPlace_Description = "null";
            if (Description != null)
            {
                string spar_WorkingPlace_Description = "@par_WorkingPlace_Description";
                SQL_Parameter par_WorkingPlace_Description = new SQL_Parameter(spar_WorkingPlace_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                lpar.Add(par_WorkingPlace_Description);
                scond_WorkingPlace_Description = "Description = " + spar_WorkingPlace_Description;
                sval_WorkingPlace_Description = spar_WorkingPlace_Description;
            }
            else
            {
                scond_WorkingPlace_Description = "Description is null";
                sval_WorkingPlace_Description = "null";
            }

            string sql = @"select ID from WorkingPlace
                                                    where " + scond_WorkingPlace_Name;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    WorkingPlace_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into WorkingPlace (Name,Description) values (" + sval_WorkingPlace_Name + "," + sval_WorkingPlace_Description + ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref WorkingPlace_ID, ref objretx, ref Err, "WorkingPlace"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_WorkingPlace:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_WorkingPlace:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}
