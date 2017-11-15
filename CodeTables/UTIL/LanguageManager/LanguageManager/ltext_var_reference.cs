using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageManager
{
    public class ltext_var_reference
    {
        private string class_name = "";
        private string var_name = "";

        public string Class_name
        {
            get { return class_name; }
            set { class_name = value; }
        }
        public string Var_name
        {
            get { return var_name; }
            set { var_name = value; }
        }
        public string Class_and_Var
        {
            get { return Class_name + "." + Var_name; }
        }

        public List<project_reference> project_reference_list = new List<project_reference>();
       

        internal project_reference GetProject(string project_file)
        {
           foreach(project_reference projref in project_reference_list)
            {
                if (projref.Project_name.Equals(project_file))
                {
                    return projref;
                }
            }
            // now project_reference found
            project_reference xprojref = new project_reference();
            xprojref.Project_name = project_file;
            project_reference_list.Add(xprojref);
            return xprojref;

        }
    }
}
