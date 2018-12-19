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
    public static class f_Atom_WorkArea
    {
        public static bool Get(string Atom_WorkArea_Name,string Description,ref ID Atom_WorkArea_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();


            string Err = null;
            DataTable dt = new DataTable();

            string scond_Atom_WorkArea_Name = null;
            string sval_Atom_WorkArea_Name = "null";
            if (Atom_WorkArea_Name != null)
            {
                string spar_Atom_WorkArea_Name = "@par_Atom_WorkArea_Name";
                SQL_Parameter par_Atom_WorkArea_Name = new SQL_Parameter(spar_Atom_WorkArea_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Atom_WorkArea_Name);
                lpar.Add(par_Atom_WorkArea_Name);
                scond_Atom_WorkArea_Name = "Name = " + spar_Atom_WorkArea_Name;
                sval_Atom_WorkArea_Name = spar_Atom_WorkArea_Name;
            }
            else
            {
                scond_Atom_WorkArea_Name = "Name is null";
                sval_Atom_WorkArea_Name = "null";
            }

            string scond_Atom_WorkArea_Description = null;
            string sval_Atom_WorkArea_Description = "null";
            if (Description != null)
            {
                string spar_Atom_WorkArea_Description = "@par_Atom_WorkArea_Description";
                SQL_Parameter par_Atom_WorkArea_Description = new SQL_Parameter(spar_Atom_WorkArea_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                lpar.Add(par_Atom_WorkArea_Description);
                scond_Atom_WorkArea_Description = "Description = " + spar_Atom_WorkArea_Description;
                sval_Atom_WorkArea_Description = spar_Atom_WorkArea_Description;
            }
            else
            {
                scond_Atom_WorkArea_Description = "Description is null";
                sval_Atom_WorkArea_Description = "null";
            }

            string sql = @"select ID from Atom_WorkArea
                                                    where " + scond_Atom_WorkArea_Name;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_WorkArea_ID==null)
                    {
                        Atom_WorkArea_ID = new ID();
                    }
                    Atom_WorkArea_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    if (!transaction.Get(DBSync.DBSync.Con))
                    {
                        return false;
                    }
                    sql = @"insert into Atom_WorkArea (Name,Description) values (" + sval_Atom_WorkArea_Name + "," + sval_Atom_WorkArea_Description + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_WorkArea_ID, ref Err, "Atom_WorkArea"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_WorkArea:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkArea:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
