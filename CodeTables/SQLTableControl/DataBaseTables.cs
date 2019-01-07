using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTables
{
    public class DataBaseTables
    {
        private string m_DBVersion = null;
        public string DBVersion
        {
            get
            {
                return m_DBVersion;
            }
            private set
            {
                m_DBVersion = value;
            }
        }

        public List<SQLTable> items = new List<SQLTable>();
        public DataBaseTables(string dbversion)
        {
            DBVersion = dbversion;
        }
    }
}
