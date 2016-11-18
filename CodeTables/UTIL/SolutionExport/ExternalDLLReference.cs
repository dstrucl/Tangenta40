using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionExport
{
    public class ExternalDLLReference
    {
        public string m_ReferencingAssembly = null;
        public string m_RelativePath = null;
        public string m_AbsolutePath = null;
        public ExternalDLLReference(string xRelative_Path,string Absolute_Path, string xReferencingAssembly)
        {
            m_RelativePath = xRelative_Path;
            m_AbsolutePath = Absolute_Path;
            m_ReferencingAssembly = xReferencingAssembly;
        }
    }
}
