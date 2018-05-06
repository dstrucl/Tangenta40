using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTables
{
    public class ReferencesToTable
    {
        private List<ReferenceFromTable> tablelist = null;

        private string m_columnName = null;

        public int Count
        {
            get
            {
                if (tablelist != null)
                {
                    return tablelist.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public List<ReferenceFromTable> Items
        {
            get
            {
               return tablelist;
            }
        }

        private bool Exist(SQLTable tbl)
        {
            if (tablelist != null)
            {
                foreach (ReferenceFromTable tbr in tablelist)
                {
                    if (tbr.TableName.Equals(tbl.TableName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Add(SQLTable tbl, string xColumnName)
        {
            if (!Exist(tbl))
            {
                if (tablelist == null)
                {
                    tablelist = new List<ReferenceFromTable>();
                }
                ReferenceFromTable rft = new ReferenceFromTable(tbl, xColumnName);
                tablelist.Add(rft);
            }
        }
    }
}
