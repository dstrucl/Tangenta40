using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageManager
{
    public class ltext_project_reference
    {
        string project_name = "";
        public string Project_name
        {
            get { return project_name; }
            set { project_name = value; }
        }

        public int LanguageTextCount {
            get
            {
                int iCount = 0;
                if (source_file_reference_list.Count>0);
                {
                    foreach (ltext_source_file_reference lsf in source_file_reference_list)
                    {
                       foreach(ltext_var_reference lvr in lsf.var_ltext_reference_List)
                        {
                            iCount += lvr.Positions.Count;
                        }
                    }

                }
                return iCount;
            }

        }

        public List<ltext_source_file_reference> source_file_reference_list = new List<ltext_source_file_reference>();

        internal ltext_source_file_reference GetSourceFile(string xsource_file)
        {
            foreach (ltext_source_file_reference sf in source_file_reference_list)
            {
                if (sf.Source_file.Equals(xsource_file))
                {
                    return sf;
                }
            }
            ltext_source_file_reference xsf = new ltext_source_file_reference();
            xsf.Source_file = xsource_file;
            source_file_reference_list.Add(xsf);
            return xsf;

        }
    }
}
