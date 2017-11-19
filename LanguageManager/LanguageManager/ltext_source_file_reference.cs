using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageManager
{
    public class ltext_source_file_reference
    {
        string source_file = "";
        public string Source_file
        {
            get { return source_file; }
            set { source_file = value; }
        }

        public List<ltext_var_reference> var_ltext_reference_List = new List<ltext_var_reference>();

        internal ltext_var_reference Get_ltext_var_reference(string class_name,string var_name, string sConstructor_Call)
        {
            ltext_var_reference xlvar = new ltext_var_reference();
            xlvar.Class_name = class_name;
            xlvar.Var_name = var_name;
            foreach (ltext_var_reference lvr in var_ltext_reference_List)
            {
                if (lvr.Class_and_Var.Equals(xlvar.Class_and_Var))
                {
                    return lvr;
                }
            }
            ltext_var_reference xlvr = new ltext_var_reference();
            xlvr.Class_name = class_name;
            xlvr.Var_name = var_name;
            xlvr.Constructor_call = sConstructor_Call;
            var_ltext_reference_List.Add(xlvr);
            return xlvr;
        }
    }

}
