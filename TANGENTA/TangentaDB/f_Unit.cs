using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Unit
    {
        public static bool Get(string Name, string Symbol, int DecimalPlaces, bool StorageOption, string Description, ref long Unit_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();


            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);


            string spar_Symbol = "@par_Symbol";
            SQL_Parameter par_Symbol = new SQL_Parameter(spar_Symbol, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Symbol);
            lpar.Add(par_Symbol);


            string spar_DecimalPlaces = "@par_DecimalPlaces";
            SQL_Parameter par_DecimalPlaces = new SQL_Parameter(spar_DecimalPlaces, SQL_Parameter.eSQL_Parameter.Int, false, DecimalPlaces);
            lpar.Add(par_DecimalPlaces);

            string spar_StorageOption = "@par_StorageOption";
            SQL_Parameter par_StorageOption = new SQL_Parameter(spar_StorageOption, SQL_Parameter.eSQL_Parameter.Bit, false, StorageOption);
            lpar.Add(par_StorageOption);

            string scond_Description = " Description is null ";
            string sval_Description = " null ";
            if (Description != null)
            {
                string spar_Description = "@par_Description";
                SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                lpar.Add(par_Description);
                scond_Description = " Description = " + spar_Description + " ";
                sval_Description = " " + spar_Description + " ";
            }

            string sql = "select ID from Unit where Name = " + spar_Name + " and  Symbol = " + spar_Symbol + " and DecimalPlaces = " + spar_DecimalPlaces + " and StorageOption = " + spar_StorageOption + " and " + scond_Description;

            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Unit_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into Unit (Name,Symbol,DecimalPlaces,StorageOption,Description)values(" + spar_Name + "," + spar_Symbol + "," + spar_DecimalPlaces + "," + spar_StorageOption + "," + sval_Description + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Unit_ID, ref oret, ref Err, "Unit"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Unit:InsertDefault:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Unit:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
