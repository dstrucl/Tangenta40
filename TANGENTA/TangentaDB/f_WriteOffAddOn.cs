using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_WriteOffAddOn
    {

        public static bool Get(
                             ID WriteOff_ID,
                             ref ID WriteOffAddOn_ID)
        {

            if (WriteOff_ID == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_WriteOffAddOn:WriteOff_ID_v==null");
                return false;
            }

            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_WriteOff_ID = "@par_WriteOff_ID";
            SQL_Parameter par_WriteOff_ID = new SQL_Parameter(spar_WriteOff_ID, false, WriteOff_ID);
            lpar.Add(par_WriteOff_ID);
            string sql = "select ID from WriteOffAddOn where WriteOff_ID = " + spar_WriteOff_ID;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, lpar,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    if (WriteOffAddOn_ID==null)
                    {
                        WriteOffAddOn_ID = new ID();
                    }
                    WriteOffAddOn_ID.Set(dt.Rows[0]["ID"]);
                }
                else
                {
                    WriteOffAddOn_ID = null;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_WriteOffAddOn:Get: sql= " + sql + "\r\nErr=" + Err);
            }
            return false;
        }
    }
}