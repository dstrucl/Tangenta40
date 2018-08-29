
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticLib
{
    public class TaxSum
    {
        public List<Tax> TaxList = new List<Tax>();
        public void Add(decimal TaxValue, decimal TaxableAmount, string TaxName, decimal TaxRate)
        {
            foreach (Tax tax in TaxList)
            {
                if (tax.Name.Equals(TaxName))
                {
                    tax.TaxAmount += TaxValue;
                    tax.TaxableAmount += TaxableAmount;
                    return;
                }
            }
            Tax tx = new Tax();
            tx.Name = TaxName;
            tx.TaxAmount = TaxValue;
            tx.Rate = TaxRate;
            tx.TaxableAmount = TaxableAmount;
            TaxList.Add(tx);
        }

        public decimal Value
        {
            get
            {
                decimal v = 0;
                foreach (Tax tax in TaxList)
                {
                    v += tax.TaxAmount;
                }
                return v;
            }
        }

        public void Clear()
        {
            TaxList.Clear();
        }
    }

    public class Tax
    {
        public string Name = null;
        public decimal TaxAmount = 0;
        public decimal TaxableAmount = 0;
        public decimal Rate = 0;

    }
}
