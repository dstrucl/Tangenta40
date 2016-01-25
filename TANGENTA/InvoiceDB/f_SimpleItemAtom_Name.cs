using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LogFile;

namespace InvoiceDB
{
    public static class f_Atom_ShopBItem_Name
    {
        public static bool Get(string Name,string Abbreviation, ref long Atom_SimpleItem_Name_ID)
        {
            string Err = null;
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            string sparam_Name = "@par_Name";
            DBConnectionControl40.SQL_Parameter par_Name = new DBConnectionControl40.SQL_Parameter(sparam_Name, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);
            string sparam_Abbreviation = "@par_Abbreviation";
            DBConnectionControl40.SQL_Parameter par_Abbreviation = new DBConnectionControl40.SQL_Parameter(sparam_Abbreviation, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, Abbreviation);
            lpar.Add(par_Abbreviation);
            DataTable dt = new DataTable();
            string sql = @"select ID from Atom_SimpleItem_Name
                                                where Name = " + sparam_Name + " and Abbreviation = " + sparam_Abbreviation;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_SimpleItem_Name_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_SimpleItem_Name (Name,Abbreviation) values (" + sparam_Name + "," + sparam_Abbreviation + ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_SimpleItem_Name_ID, ref objretx, ref Err, "Atom_SimpleItem_Name"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_SimpleItem_Name:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_SimpleItem_Name:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
