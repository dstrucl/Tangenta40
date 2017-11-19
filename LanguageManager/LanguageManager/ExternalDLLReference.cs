using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageManager
{
    public class ExternalDLLReference
    {
        public string m_RelativePath = null;
        public string m_AbsolutePath = null;
        public List<string> ReferenceList = new List<string>();
        public string ReferencingAssembly
        {
            get {   string s = "";
                    foreach (string sr in ReferenceList)
                    {
                        if (s.Length == 0)
                        {
                            s = sr;
                        }
                        else
                        {
                        s += ";"+sr;
                    }
                    }
                    return s;
                }
        }

        public ExternalDLLReference(string xRelative_Path,string Absolute_Path, string xReferencingAssembly)
        {
            m_RelativePath = xRelative_Path;
            m_AbsolutePath = Absolute_Path;
            ReferenceList.Add(xReferencingAssembly);
        }

        public void Add(string xReferencingAssembly)
        {
            int index = ReferenceList.FindIndex(s => s.Contains(xReferencingAssembly));
            if (index < 0)
            {
                ReferenceList.Add(xReferencingAssembly);
            }
            
        }
    }
}
