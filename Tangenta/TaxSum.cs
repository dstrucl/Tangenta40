using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public class TaxSum
    {
        public List<Tax> TaxList = new List<Tax>();
        public void Add(decimal TaxValue,string TaxName,decimal TaxRate)
        {
           foreach (Tax tax in TaxList) 
           {
               if (tax.Name.Equals(TaxName))
               {
                   tax.Sum += TaxValue;
                   return;
               }
           }
           Tax tx = new Tax();
           tx.Name = TaxName;
           tx.Sum = TaxValue;
           tx.Rate = TaxRate;
           TaxList.Add(tx);
        }

        public decimal Value 
        {
            get
            {
                decimal v = 0;
                foreach (Tax tax in TaxList)
                {
                    v += tax.Sum;
                }
                return v;} 
        }

        internal bool Create(long ProformaInvoice_ID)
        {
            string Err = null;
            string sql = @" select apsi.TaxPrice,
                                   atax.Name,
                                   atax.Rate
                                   from atom_price_simpleitem  apsi
                                   inner join Atom_Taxation atax on apsi.Atom_Taxation_ID = atax.ID
                                   where ProformaInvoice_ID = " + ProformaInvoice_ID.ToString();
            DataTable dt_simple_item_tax = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt_simple_item_tax, sql, ref Err))
            {
                foreach (DataRow dr in dt_simple_item_tax.Rows)
                {
                    Add((decimal)dr["TaxPrice"], (string)dr["Name"], (decimal)dr["Rate"]);
                }

                sql = @" select appis.TaxPrice,
                                   atax.Name,
                                   atax.Rate
                                   from atom_proformainvoice_price_item_stock  appis
                                   inner join atom_price_item api on appis.atom_price_item_ID = api.ID
                                   inner join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
                                   where ProformaInvoice_ID = " + ProformaInvoice_ID.ToString();
                DataTable dt_item_tax = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt_item_tax, sql, ref Err))
                {
                    foreach (DataRow dr in dt_item_tax.Rows)
                    {
                        Add((decimal)dr["TaxPrice"], (string)dr["Name"], (decimal)dr["Rate"]);
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TaxSum:Create:sql= "+sql+"\r\nErr=" + Err);
                    return false;

                }

            }
            else
            {
                LogFile.Error.Show("ERROR:TaxSum:Create:sql= " + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }

    public class Tax
    {
        public string Name = null;
        public decimal Sum = 0;
        public decimal Rate = 0;

    }


}
