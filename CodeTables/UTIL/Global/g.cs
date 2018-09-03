using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
    public static class g
    {
        public static void DrawStringAlignCenter(Graphics graphics, string s, Font font, Color color, int ypos, float pagewidth)
        {
            SizeF sf = graphics.MeasureString(s, font);
            float fwidth = pagewidth;
            float fxpos = fwidth / 2 - sf.Width / 2;
            graphics.DrawString(s, font, new SolidBrush(color), fxpos, ypos);

        }

        public static void DrawStringAlignRight(Graphics graphics, string s, Font font, Color color, int xpos_rightalignemnt, int ypos)
        {
            SizeF sf = graphics.MeasureString(s, font);
            float fxpos = xpos_rightalignemnt - sf.Width;
            graphics.DrawString(s, font, new SolidBrush(color), fxpos, ypos);

        }

    }
}
