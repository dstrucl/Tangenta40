using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using SQLTableControl;
using BlagajnaTableClass;

namespace Tangenta
{
    public class xTaxation
    {
        public long ID=-1;
        public string Name = null;
        public decimal Rate = 0;
        public xTaxation(long xid,string xName, decimal xRate)
        {
            ID = xid;
            Name = xName;
            Rate = xRate;
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
        public bool Get(ref string Err)
        {
            string sql_Taxation = "select * from Taxation";
            items.Clear();
            DataTable dt = new DataTable();
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
                    return true;
                }
                else
                {
                    if (Edit())
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            xTaxation xtax = new xTaxation((long)dr["ID"], (string)dr["Name"], (decimal)dr["Rate"]);
                            Add(xtax);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private bool Edit()
        {
            SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Taxation)));
            Form_Taxation_Edit tax_dlg = new Form_Taxation_Edit(DBSync.DBSync.DB_for_Blagajna.m_DBTables, tbl_Taxation,"ID asc");
            if (tax_dlg.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
