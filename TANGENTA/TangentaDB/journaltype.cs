using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class journaltype
    {
        public ID ID = null;
        public string Name = null;
        public string Description = null;
        public journaltype(string xName, string xDescription)
        {
            Name = xName;
            Description = xDescription;
        }
    }
}
