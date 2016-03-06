using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public static class f_JOURNAL_Invoice_Type
    {
        internal static bool Get(string Name, string Description, ref long JOURNAL_Invoice_type_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = null;

            sql = @"select ID from JOURNAL_Invoice_Type where Name = '" + Name + "'";
            if (Program.LocalDB_for_Tangenta.m_DBTables.m_con.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    JOURNAL_Invoice_type_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {

                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    string sPar_Description = "@Description";
                    if (Description != null)
                    {
                        SQL_Parameter par_Description = new SQL_Parameter(sPar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, sPar_Description);
                        lpar.Add(par_Description);
                    }
                    else
                    {
                        sPar_Description = "null";
                    }
                    string sPar_Name = "@Name";
                    SQL_Parameter par_Name = new SQL_Parameter(sPar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, sPar_Name);
                    lpar.Add(par_Name);

                    sql = @"insert into JOURNAL_Invoice_Type (Name,Description)values(" + sPar_Name + "," + sPar_Description + ")";
                    object objretx = null;
                    if (Program.LocalDB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQLReturnID(sql, null, ref JOURNAL_Invoice_type_ID, ref objretx, ref Err, "JOURNAL_Invoice_Type"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_JOURNAL_Invoice_Type:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_JOURNAL_Invoice_Type:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
