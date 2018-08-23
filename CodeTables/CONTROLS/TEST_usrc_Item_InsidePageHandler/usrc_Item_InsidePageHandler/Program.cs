using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usrc_Item_InsidePageHandler
{
    public static class Program
    {
        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        public static decimal GetRandomPrice(decimal dmin, decimal dmax, int DecimalPlaces)
        {
            lock (syncLock)
            { // synchronize
                int min = Convert.ToInt32(dmin);
                int iMultiply = 10 ^ DecimalPlaces;
                int max = Convert.ToInt32(dmax) * iMultiply;
                int irand = getrandom.Next(min, max);
                decimal drand = Convert.ToDecimal(irand) / iMultiply;
                drand = Decimal.Round(drand, DecimalPlaces);
                return drand;
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
