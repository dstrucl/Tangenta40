using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionExplorer
{
    public class ConfigurationList
    {
        public List<Configuration> Items = new List<Configuration>();

        private int m_iSelectedIndex = -1;

        public int SelectedIndex
        {
            get { return m_iSelectedIndex; }
            set { int i = value;
                    if ((i>=0)&&(i< Items.Count))
                    {
                    m_iSelectedIndex = i;
                    }
                }
        }

        public void Add(string configurationName)
        {
            if (Find(configurationName) < 0)
            {
                Configuration cfg = new Configuration(configurationName);
                Items.Add(cfg);
            }
        }

        public int Find(string configurationName)
        {
            int iCount = Items.Count;
            int i = 0;
            for (i = 0; i < iCount; i++)
            {
                string sitm = (string)Items[i].Name;
                if (sitm.Equals(configurationName))
                {
                    return i;
                }
            }
            return -1;
        }

        internal string SetSelected(int xiSelectedIndex)
        {
            if ((xiSelectedIndex>=0)&& (xiSelectedIndex < Items.Count))
            {
                m_iSelectedIndex = xiSelectedIndex;
                return Selected();
            }
            else
            {
                return "";
            }
        }

        public string Selected()
        {
            if (m_iSelectedIndex>=0)
            {
                return Items[m_iSelectedIndex].Name;
            }
            else
            {
                return "";
            }
        }

        internal void Clear()
        {
            Items.Clear();
            m_iSelectedIndex = -1;
        }
    }
}
