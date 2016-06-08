// Copyright (c) 2011 rubicon IT GmbH
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class myOrg_Office_List
    {
        public static bool Get(long myOrganisation_id, ref List<myOrg_Office> myOrg_Office_list)
        {

            DataTable dt = new DataTable();
            myOrg_Office_list.Clear();
            string sql = null;
            sql = @"select
                        ID
                        FROM Office where myOrganisation_ID = " + myOrganisation_id.ToString();

            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    int iCount = dt.Rows.Count;
                    for (i = 0; i < iCount; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        long Office_ID = (long)dr["ID"];
                        myOrg_Office moffice = new myOrg_Office();
                        long_v Office_ID_v = new long_v(Office_ID);

                        if (moffice.Get(Office_ID_v))
                        {
                            myOrg_Office_list.Add(moffice);
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:myOrg_Office_List:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}

