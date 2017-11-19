using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageManager
{
    public class Ordered_ltext_position
    {
        private string class_name = "";
        private string var_name = "";
        private string constructor_call = "";

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

        public int iPos = 0;

 
    }
}
