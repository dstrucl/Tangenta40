using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_Atom_ComputerUsername
    {
        public static string Get()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }
        public static bool Get(ref ID Atom_ComputerUsername_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string UserName = f_Atom_ComputerUsername.Get();
            return f_Atom_ComputerUsername.Get(UserName, ref Atom_ComputerUsername_ID, transaction);
        }

        public static bool Get(string xUserName,ref ID Atom_ComputerUsername_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Err = null;
            DataTable dt = new DataTable();

            string scond_ComputerUsername = null;
            string sval_ComputerUsername = "null";
            if (xUserName != null)
            {
                string spar_ComputerUsername = "@par_ComputerUsername";
                SQL_Parameter par_ComputerUsername = new SQL_Parameter(spar_ComputerUsername, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xUserName);
                lpar.Add(par_ComputerUsername);
                scond_ComputerUsername = "UserName = " + spar_ComputerUsername;
                sval_ComputerUsername = spar_ComputerUsername;
            }
            else
            {
                scond_ComputerUsername = "UserName is null";
                sval_ComputerUsername = "null";
            }

            string sql = @"select ID from Atom_ComputerUsername
                                                where " + scond_ComputerUsername;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_ComputerUsername_ID==null)
                    {
                        Atom_ComputerUsername_ID = new ID();
                    }
                    Atom_ComputerUsername_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_ComputerUsername (UserName) values (" + sval_ComputerUsername + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Atom_ComputerUsername_ID,  ref Err, "Atom_ComputerUsername"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_ComputerUsername:GetName:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_ComputerUsername:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
