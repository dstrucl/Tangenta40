using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class f_Currency_Data
    {
        private string_v abbreviation_v = null;
        private string_v name_v = null;
        private string_v symbol_v = null;
        private int_v currencyCode_v = null;
        private int_v decimalPlaces_v = null;

        public void Set(DataRow dr)
        {
            abbreviation_v = tf.set_string(dr["Currency_Abbreviation"]);
            name_v = tf.set_string(dr["Currency_Name"]);
            symbol_v = tf.set_string(dr["Currency_Symbol"]);
            currencyCode_v = tf.set_int(dr["Currency_CurrencyCode"]);
            decimalPlaces_v = tf.set_int(dr["Currency_DecimalPlaces"]);
        }

        public f_Currency_Data(DataRow dr)
        {
            this.Set(dr);
        }
    }

}
