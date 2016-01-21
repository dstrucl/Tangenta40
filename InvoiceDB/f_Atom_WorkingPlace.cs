using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public static class f_Atom_WorkingPlace
    {
        public static bool Get(long WorkingPlace_ID,ref long Atom_WorkingPlace_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Err = null;
            DataTable dt = new DataTable();

            string sql = @"select Name,Description from WorkingPlace
                                                where ID = " + WorkingPlace_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    string WorkingPlace_Name = null;
                    if (dt.Rows[0]["Name"] is string)
                    {
                        WorkingPlace_Name = (string) dt.Rows[0]["Name"];
                    }
                    string scond_Atom_WorkingPlace_Name = null;
                    string sval_Atom_WorkingPlace_Name = "null";
                    if (WorkingPlace_Name != null)
                    {
                        string spar_Atom_WorkingPlace_Name = "@par_Atom_WorkingPlace_Name";
                        SQL_Parameter par_Atom_WorkingPlace_Name = new SQL_Parameter(spar_Atom_WorkingPlace_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, WorkingPlace_Name);
                        lpar.Add(par_Atom_WorkingPlace_Name);
                        scond_Atom_WorkingPlace_Name = "Name = " + spar_Atom_WorkingPlace_Name;
                        sval_Atom_WorkingPlace_Name = spar_Atom_WorkingPlace_Name;
                    }
                    else
                    {
                        scond_Atom_WorkingPlace_Name = "Name is null";
                        sval_Atom_WorkingPlace_Name = "null";
                    }


                    string WorkingPlace_Description = null;
                    if (dt.Rows[0]["Description"] is string)
                    {
                        WorkingPlace_Description = (string)dt.Rows[0]["Description"];
                    }
                    string scond_Atom_WorkingPlace_Description = null;
                    string sval_Atom_WorkingPlace_Description = "null";
                    if (WorkingPlace_Description != null)
                    {
                        string spar_Atom_WorkingPlace_Description = "@par_Atom_WorkingPlace_Description";
                        SQL_Parameter par_Atom_WorkingPlace_Description = new SQL_Parameter(spar_Atom_WorkingPlace_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, WorkingPlace_Description);
                        lpar.Add(par_Atom_WorkingPlace_Description);
                        scond_Atom_WorkingPlace_Description = "Description = " + spar_Atom_WorkingPlace_Description;
                        sval_Atom_WorkingPlace_Description = spar_Atom_WorkingPlace_Description;
                    }
                    else
                    {
                        scond_Atom_WorkingPlace_Description = "Description is null";
                        sval_Atom_WorkingPlace_Description = "null";
                    }

                    sql = @"select ID from Atom_WorkingPlace
                                                where " + scond_Atom_WorkingPlace_Name + " and " + scond_Atom_WorkingPlace_Description;

                    DataTable dt_Atom_WorkingPlace = new DataTable();
                    if (DBSync.DBSync.ReadDataTable(ref dt_Atom_WorkingPlace, sql, lpar, ref Err))
                    {
                        if (dt_Atom_WorkingPlace.Rows.Count > 0)
                        {
                            Atom_WorkingPlace_ID = (long)dt_Atom_WorkingPlace.Rows[0]["ID"];
                            return true;
                        }
                        else
                        {
                            sql = @"insert into Atom_WorkingPlace (Name,Description) values (" + sval_Atom_WorkingPlace_Name + "," + sval_Atom_WorkingPlace_Description + ")";
                            object objretx = null;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_WorkingPlace_ID, ref objretx, ref Err, "Atom_WorkingPlace"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Atom_WorkingPlace:Get:" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_WorkingPlace:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_WorkingPlace: WorkingPlace with ID = " + WorkingPlace_ID.ToString() + " not found!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkingPlace:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
