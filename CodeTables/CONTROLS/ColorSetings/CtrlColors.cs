using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorSettings
{
    public class CtrlColors
    {
        private int m_ColorpairIndex = 0;

        private ColorPair colorpair = null;
        //private System.Drawing.Color foreColor = System.Drawing.Color.Black;
        //private System.Drawing.Color backColor = System.Drawing.Color.White;

        public int ColorpairIndex
        {
            get { return m_ColorpairIndex; }
            set { m_ColorpairIndex = value; }
        }

        private string m_Name = "";
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public System.Drawing.Color BackColor
        {
            get
            {
                ColorSheme csheme = Sheme.Current();
                if (csheme!=null)
                {
                    if (csheme.Colorpair.Length > m_ColorpairIndex)
                    {
                        return csheme.Colorpair[m_ColorpairIndex].BackColor;
                    }
                }
                return colorpair.BackColor;
            }
        }

        public System.Drawing.Color ForeColor
        {
            get
            {
                ColorSheme csheme = Sheme.Current();
                if (csheme != null)
                {
                    if (csheme.Colorpair.Length > m_ColorpairIndex)
                    {
                        return csheme.Colorpair[m_ColorpairIndex].ForeColor;
                    }
                }
                return colorpair.ForeColor;
            }
        }

        public ColorPair Colorpair
        {
            get
            {
                ColorSheme csheme = Sheme.Current();
                if (csheme != null)
                {
                    if (csheme.Colorpair.Length > m_ColorpairIndex)
                    {
                        return csheme.Colorpair[m_ColorpairIndex];
                    }
                }
                return colorpair;
            }
        }

        public CtrlColors(string name, int colorpairindex, System.Drawing.Color backcolor, System.Drawing.Color forecolor)
        {
            m_Name = name;
            m_ColorpairIndex = colorpairindex;
            ControlColorDic.Add(colorpairindex, m_Name);
            colorpair = new ColorPair(forecolor, backcolor);
        }
    }
}
