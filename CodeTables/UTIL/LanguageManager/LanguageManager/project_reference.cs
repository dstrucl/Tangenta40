using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageManager
{
    public class project_reference
    {
        string project_name = "";
        public string Project_name
        {
            get { return project_name; }
            set { project_name = value; }
        }
        public List<source_file_reference> source_file_reference_list = new List<source_file_reference>();

        internal source_file_reference GetSourceFile(string xsource_file)
        {
            foreach (source_file_reference sf in source_file_reference_list)
            {
                if (sf.Source_file.Equals(xsource_file))
                {
                    return sf;
                }
            }
            source_file_reference xsf = new source_file_reference();
            xsf.Source_file = xsource_file;
            source_file_reference_list.Add(xsf);
            return xsf;

        }
    }
}
