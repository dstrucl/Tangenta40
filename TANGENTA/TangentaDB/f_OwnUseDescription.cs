using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;
using DBTypes;

namespace TangentaDB
{
    public static class f_OwnUseDescription
    {
        public static bool Get(string name, string description, ref ID ownUseDescription_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Err = null;
            DataTable dt = new DataTable();

            string scond_Name = null;
            string sval_Name = "null";
            if (name != null)
            {
                string spar_Name = "@par_Name";
                SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, name);
                lpar.Add(par_Name);
                scond_Name = "Name = " + spar_Name;
                sval_Name = spar_Name;
            }
            else
            {
                scond_Name = "Name is null";
                sval_Name = "null";
            }


            string scond_Description = null;
            string sval_Description = "null";
            if (name != null)
            {
                string spar_Description = "@par_Description";
                SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, description);
                lpar.Add(par_Description);
                scond_Description = "Description = " + spar_Description;
                sval_Description = spar_Description;
            }
            else
            {
                scond_Description = "Description is null";
                sval_Description = "null";
            }

            string sql = @"select ID, Description from OwnUseDescription
                                                where " + scond_Name + " and " + scond_Description;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ownUseDescription_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    string ownUseDescriptionDescription = tf._set_string(dt.Rows[0]["Description"]);
                    if ((ownUseDescriptionDescription == null) && (description == null))
                    {
                        return true;
                    }
                    else
                    {
                        if ((ownUseDescriptionDescription != null) && (description != null))
                        {
                            if (ownUseDescriptionDescription.Equals(description))
                            {
                                return true;
                            }
                            else
                            {
                                sql = @"update OwnUseDescription set Description = " + sval_Description + " where ID = " + ownUseDescription_ID.ToString();
                            }
                        }
                        else
                        {
                            sql = @"update OwnUseDescription set Description = " + sval_Description + " where ID = " + ownUseDescription_ID.ToString();
                        }
                        if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con, sql, lpar, ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_OwnUseReason:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    sql = @"insert into OwnUseDescription (Name,Description) values (" + sval_Name + "," + sval_Description + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con, sql, lpar, ref ownUseDescription_ID, ref Err, "OwnUseDescription"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_OwnUseReason:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_OwnUseReason:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        public static bool GetTable(ref DataTable dtOwnUseDescription)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Err = null;

            string sql = @"select ID,Name, Description from OwnUseReason";
            if (dtOwnUseDescription != null)
            {
                dtOwnUseDescription.Dispose();
                dtOwnUseDescription = null;
            }
            else
            {
                dtOwnUseDescription = new DataTable();
            }

            if (DBSync.DBSync.ReadDataTable(ref dtOwnUseDescription, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_OwnUseDescription:GetTable:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
