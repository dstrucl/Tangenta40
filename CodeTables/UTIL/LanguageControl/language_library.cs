using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LanguageControl
{
    public class language_library
    {
        private string module_name = null;
        public string ModuleName
        {
            get { return module_name; }
            set { module_name = value; }
        }

        private FieldInfo[] fields = null;
        public FieldInfo[] Fields
        {
            get { return fields; }
            set { fields = value; }
        }
      
        public language_library(string xModuleName, FieldInfo[] xFields)
        {
            ModuleName = xModuleName;
            Fields = xFields;
        }
    }
}
