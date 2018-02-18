using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSettings
{
    public class ColorSheme
    {
        private bool m_ReadOnly = true;

        public bool ReadOnly
        {
            get
            {
                return m_ReadOnly;
            }
            set
            {
                m_ReadOnly = value;
            }
        }


        private string m_Name;
        public string Name
        {
            get {
                return m_Name;
                }
            set
                {
                    m_Name = value;
                }
        }

        public System.Drawing.Color[] color = null;

        public ColorSheme(bool read_only,string name, System.Drawing.Color[] xcolor)
        {
            m_ReadOnly = read_only;
            m_Name = name;
            if (xcolor!=null)
            {
                int icollength = xcolor.Length;
                if (icollength > 0)
                {
                    color = new System.Drawing.Color[icollength];
                    for (int i=0;i< icollength;i++)
                    {
                        color[i] = xcolor[i];
                    }
                }
            }
        }

        public ColorSheme()
        {
        }


    }
}
