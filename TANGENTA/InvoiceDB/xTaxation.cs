using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using SQLTableControl;
using BlagajnaTableClass;

namespace InvoiceDB
{
    public class xTaxation
    {
        private long m_ID=-1;
        private string m_Name = null;
        private decimal m_Rate = 0;

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

        public xTaxation(long xid,string xName, decimal xRate)
        {
            m_ID = xid;
            m_Name = xName;
            m_Rate = xRate;
        }
    }

    public class xTaxationList
    {

        public int Count = 0;
        public List<xTaxation> items = new List<xTaxation>();
        public void Add(xTaxation xtax)
        {
            items.Add(xtax);
        }
        public bool Get(ref DataTable dt,ref string Err)
        {
            string sql_Taxation = "select * from Taxation";
            items.Clear();
            dt.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql_Taxation,ref Err))
            {
                Count = dt.Rows.Count;
                if (Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        xTaxation xtax = new xTaxation((long)dr["ID"], (string)dr["Name"], (decimal)dr["Rate"]);
                        Add(xtax);
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
