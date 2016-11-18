using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionExplorer
{
    public class ExternalDllReferenceList
    {
        public List<ExternalDLLReference> Items = new List<ExternalDLLReference>();

        public int Find(string abs_path)
        {
            int iCount = Items.Count;
            int i = 0;
            for (i = 0; i < iCount; i++)
            {
                if (Items[i].m_AbsolutePath.Equals(abs_path))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(string rel_path,string abs_path, string referencing_assembly)
        {
            int iIndex = Find(abs_path);
            if (iIndex < 0)
            {
                ExternalDLLReference pref = new ExternalDLLReference(rel_path, abs_path, referencing_assembly);
                Items.Add(pref);
            }
        }
    }
}
