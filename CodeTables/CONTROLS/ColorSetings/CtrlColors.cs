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
        private int m_BackColorIndex = 0;

        private System.Drawing.Color foreColor = System.Drawing.Color.Black;
        private System.Drawing.Color backColor = System.Drawing.Color.White;

        public int BackColorIndex
        {
            get { return m_BackColorIndex; }
            set { m_BackColorIndex = value; }
        }
        private int m_ForeColorIndex = 0;
        public int ForeColorIndex
        {
            get { return m_ForeColorIndex; }
            set { m_ForeColorIndex = value; }
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
                    if (csheme.color.Length> m_BackColorIndex)
                    {
                        return csheme.color[m_BackColorIndex];
                    }
                }
                return backColor;
            }
        }

        public System.Drawing.Color ForeColor
        {
            get
            {
                ColorSheme csheme = Sheme.Current();
                if (csheme != null)
                {
                    if (csheme.color.Length > m_ForeColorIndex)
                    {
                        return csheme.color[m_ForeColorIndex];
                    }
                }
                return foreColor;
            }
        }

        public CtrlColors(string name,int backcolorindex, int forecolorindex, System.Drawing.Color backcolor, System.Drawing.Color forecolor)
        {
            m_Name = name;
            m_BackColorIndex = backcolorindex;
            m_ForeColorIndex = forecolorindex;
            backColor = backcolor;
            foreColor = forecolor;
        }


    }
}
