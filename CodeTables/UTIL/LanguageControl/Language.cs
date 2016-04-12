using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanguageControl
{
    public class Language
    {
        private string m_Name = null;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private int m_Index = -1;
        public int Index
        {
            get { return m_Index; }
            set { m_Index = value; }
        }
        public Language(string name,int index)
        {
            m_Name = name;
            m_Index = index;
        }
    }
}
