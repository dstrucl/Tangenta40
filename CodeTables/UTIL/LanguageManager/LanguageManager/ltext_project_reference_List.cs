using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageManager
{
    public class ltext_project_reference_List
    {
      
        public List<ltext_project_reference> project_reference_list = new List<ltext_project_reference>();
       

        internal ltext_project_reference GetProject(string project_file)
        {
           foreach(ltext_project_reference projref in project_reference_list)
            {
                if (projref.Project_name.Equals(project_file))
                {
                    return projref;
                }
            }
            // now project_reference found
            ltext_project_reference xprojref = new ltext_project_reference();
            xprojref.Project_name = project_file;
            project_reference_list.Add(xprojref);
            return xprojref;

        }
    }
}
