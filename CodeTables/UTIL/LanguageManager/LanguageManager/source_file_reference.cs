using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageManager
{
    public class source_file_reference
    {
        string source_file = "";
        public string Source_file
        {
            get { return source_file; }
            set { source_file = value; }
        }

        public List<int> Positions = new List<int>();
    }

}
