using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecimalConvertToString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            decimal x1 = 14;
            decimal x2 = 3;
            string s = GetFursDecimalString(1.1m);
            s = GetFursDecimalString(1.0m);
            s = GetFursDecimalString(1.02m);
            s = GetFursDecimalString(2m);
            s = GetFursDecimalString(-1);
        }

        internal static string GetFursDecimalString(decimal d)
        {
            d = decimal.Round(d, 2);
            string s = d.ToString();
            int icomma = s.IndexOf(',');
            if (s.Contains(","))
            {
                s = s.Replace(',', '.');
            }

            icomma = s.IndexOf('.');
            if (icomma>=0)
            {
                int len = s.Length;
                while (s.Length < icomma+3)
                {
                    s = s + "0";
                }
            }
            else
            {
                s = s +".00";
            }
            return s;
        }
    }
}
