using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBTypes;

namespace TangentaDB
{
    public static class f_PersonData
    {
        public static bool Find(long Person_ID,ref long PersonData_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Person_ID = "@spar_Person_ID";
            SQL_Parameter par_Person_ID = new SQL_Parameter(spar_Person_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Person_ID);
            lpar.Add(par_Person_ID);
            string sql = "select ID from PersonData where Person_ID = " + spar_Person_ID;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,lpar, ref Err))
            {
                if (dt.Rows.Count==1)
                {
                    PersonData_ID = (long)dt.Rows[0]["ID"];
                }
                else if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_PersonData:Find:sql=" + sql + "\r\nErr= PersonData found more than once for Person_ID ="+Person_ID.ToString());
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PersonData:Find:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        public static bool InsertEmptyRow(long_v person_ID_v, ref long personData_ID)
        {
            if (person_ID_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar_Person_ID = "@spar_Person_ID";
                SQL_Parameter par_Person_ID = new SQL_Parameter(spar_Person_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, person_ID_v.v);
                lpar.Add(par_Person_ID);
                string sql = "insert into PersonData (Person_ID)values(" + spar_Person_ID + ")";
                string Err = null;
                object oret = null;
                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql,lpar, ref personData_ID,ref oret, ref Err, "PersonData"))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:InsertEmptyRow:f_PersonData:Find:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PersonData:InsertEmptyRow:\r\nErr= person_ID_v != null" );
                return false;
            }
        }
    }
}
