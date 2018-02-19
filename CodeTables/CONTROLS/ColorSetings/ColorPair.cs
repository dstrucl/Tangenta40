using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSettings
{
    public class ColorPair
    {
        private Color m_ForeColor = Color.Black;
        public Color ForeColor
        {
            get { return m_ForeColor; }
            set { m_ForeColor = value;  }
        }

        private Color m_BackColor = Color.White;
        public Color BackColor
        {
            get { return m_BackColor; }
            set { m_BackColor = value; }
        }

        public ColorPair(Color forecolor, Color backcolor)
        {
            m_ForeColor = forecolor;
            m_BackColor = backcolor;
        }
    }
}
