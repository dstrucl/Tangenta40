using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Office_Data
    {
        public static bool Get(
                                   long cAddress_Org_ID,
                                   long Office_ID,
                                   string Description,
                                   ref long Office_Data_ID)
        {

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string scond_Description = null;
            string sval_Description = null;
            if (Description != null)
            {
                string spar_Description = "@par_Description";
                SQL_Parameter par_Office_ShortName = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                lpar.Add(par_Office_ShortName);
                scond_Description = "Description = " + spar_Description;
                sval_Description = spar_Description;
            }
            else
            {
                scond_Description = "Description is null";
                sval_Description = "null";
            }

            string sql = @"select ID from Office_Data
                                        where ( cAddress_Org_ID = " + cAddress_Org_ID.ToString() + ") and ( Office_ID = " + Office_ID.ToString() + ") and ("+ scond_Description + ")";
            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Office_Data_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into Office_Data (cAddress_Org_ID,
                                                            Office_ID,
                                                            Description) values ("
                                                            + cAddress_Org_ID.ToString() + ","
                                                            + Office_ID.ToString() + ","
                                                            + sval_Description +
                                                            ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Office_Data_ID, ref objretx, ref Err, "Office_Data"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Office_Data:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Office_Data:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(long Office_ID, ref DataTable dtOfficeData_of_Office_ID)
        {
            string sql = @"select 
                            ID
                            from Office_Data od
                            where od.Office_ID = " + Office_ID.ToString();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dtOfficeData_of_Office_ID, sql, null, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool DeleteAll()
        {
            return fs.DeleteAll("Office_Data");
        }
    }
}
