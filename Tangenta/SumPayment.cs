using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public class SumPayment
    {
        public decimal Sum; 
        public string PaymentType;
    }

    public class SumPaymentList
    {
        public List<SumPayment> SumPayment_List = new List<SumPayment>();

        public void Add()
        {

        }

        internal void Add(decimal Value, string type)
        {
            int iIndex=0;
            if (Find(type, ref iIndex))
            {
                SumPayment_List[iIndex].Sum += Value;
            }
            else
            {
                SumPayment sumpay = new SumPayment();
                sumpay.Sum = Value;
                sumpay.PaymentType = type;
                SumPayment_List.Add(sumpay);
            }
        }

        private bool Find(string type, ref int iIndex)
        {
            int iCount = SumPayment_List.Count;
            int i;
            for (i=0;i<iCount;i++)
            {
                if (SumPayment_List[i].PaymentType.Equals(type))
                {
                    iIndex = i;
                    return true;

                }
            }
            return false;
        }
    }
}
