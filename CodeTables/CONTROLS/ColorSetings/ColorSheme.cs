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

        public ColorPair[] Colorpair = null;

        public ColorSheme(bool read_only,string name, ColorPair[] xcolorpairs)
        {
            m_ReadOnly = read_only;
            m_Name = name;
            if (xcolorpairs != null)
            {
                int icolpairslength = xcolorpairs.Length;
                if (icolpairslength > 0)
                {
                    Colorpair = new ColorPair[icolpairslength];
                    for (int i=0;i< icolpairslength; i++)
                    {
                        Colorpair[i] = new ColorPair(xcolorpairs[i].ForeColor, xcolorpairs[i].BackColor);
                    }
                }
            }
        }

        public ColorSheme()
        {
        }
    }
}
