using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class f_Taxation_Data
    {
        private string_v name_v = null;
        public string Name
        {
            get
            {
                if (name_v != null)
                {
                    return name_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private decimal_v rate_v = null;

        public decimal Rate
        {
            get
            {
                if (rate_v != null)
                {
                    return rate_v.v;
                }
                else
                {
                    return 0;
                }
            }
        }
        public void Set(DataRow dr)
        {
            name_v = tf.set_string(dr["Taxation_Name"]);
            rate_v = tf.set_decimal(dr["Taxation_Rate"]);
        }

        public f_Taxation_Data(DataRow dr)
        {
            this.Set(dr);
        }
    }
}
