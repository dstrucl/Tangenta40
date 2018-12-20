using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_ProgramModule
    {
        public static bool Get(string xProgramModule, ref ID ProgramModule_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Err = null;
            DataTable dt = new DataTable();

            string scond_ProgramModule = null;
            string sval_ProgramModule = "null";
            if (xProgramModule != null)
            {
                string spar_ProgramModule = "@par_ProgramModule";
                SQL_Parameter par_ProgramModule = new SQL_Parameter(spar_ProgramModule, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xProgramModule);
                lpar.Add(par_ProgramModule);
                scond_ProgramModule = "Name = " + spar_ProgramModule;
                sval_ProgramModule = spar_ProgramModule;
            }
            else
            {
                scond_ProgramModule = "Name is null";
                sval_ProgramModule = "null";
            }

            string sql = @"select ID from ProgramModule
                                                where " + scond_ProgramModule;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (ProgramModule_ID == null)
                    {
                        ProgramModule_ID = new ID();
                    }
                    ProgramModule_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into ProgramModule (Name) values (" + sval_ProgramModule + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref ProgramModule_ID, ref Err, "ProgramModule"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_ProgramModule:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_ProgramModule:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
