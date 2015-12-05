using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public static class f_State
    {
        public static List<string> State_List_SLO = new List<string>();
        public static int Count(DBConnection xcon,string TableName, DataTable dt)
        {
            string Err = null;
            DataTable xdt = null;
            if (dt!=null)
            {
                xdt = dt;
            }
            else
            {
                xdt = new DataTable();
            }
            string sql = "select ID,State from " + TableName;
            if (xcon.ReadDataTable(ref xdt, sql, ref Err))
            {
                return xdt.Rows.Count;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_State:Count:sql=\r\n" + sql + "\r\nErr=" + Err);
                return -1;
            }

        }
        private static void Init_State_List_SLO()
        {




            f_State.State_List_SLO.Clear();
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
            f_State.State_List_SLO.Add(
        }

        public static bool WriteDefaultTable((DBConnection xcon, string TableName, DataTable dt)
        {

            foreach(string s in f_State.State_List_SLO)
            {

            }

            return false;
        }
    }
}
