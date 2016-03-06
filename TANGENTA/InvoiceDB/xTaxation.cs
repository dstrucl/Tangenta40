#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using CodeTables;
using TangentaTableClass;

namespace InvoiceDB
{
    public class xTaxation
    {
        private int m_Index = -1;
        private long m_ID=-1;
        private string m_Name = null;
        private decimal m_Rate = 0;

        public long Index
        {
            get { return m_Index; }
        }

        public long ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        public decimal Rate
        {
            get { return m_Rate; }
            set { m_Rate = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public xTaxation(long xid,string xName, decimal xRate, int idx)
        {
            m_Index = idx;
            m_ID = xid;
            m_Name = xName;
            m_Rate = xRate;
        }
    }

    public class xTaxationList
    {

        public int Count = 0;
        public xTaxation[] items = null;
        public bool Get(ref DataTable dt,ref string Err)
        {
            string sql_Taxation = "select * from Taxation";
            dt.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql_Taxation,ref Err))
            {
                Count = dt.Rows.Count;
                items = new xTaxation[Count];
                if (Count > 0)
                {
                    int i = 0;
                    for (i=0;i<Count;i++)
                    {
                        DataRow dr = dt.Rows[i];
                        items[i] = new xTaxation((long)dr["ID"], (string)dr["Name"], (decimal)dr["Rate"],i);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
