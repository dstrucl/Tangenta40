using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Global
{
    public static class g
    {
        public static void DrawStringAlignCenter(Graphics graphics, string s, Font font, Color color, float ypos, float pagewidth)
        {
            SizeF sf = graphics.MeasureString(s, font);
            float fwidth = pagewidth;
            float fxpos = fwidth / 2 - sf.Width / 2;
            graphics.DrawString(s, font, new SolidBrush(color), fxpos, ypos);

        }

        public static void DrawStringAlignRight(Graphics graphics, string s, Font font, Color color, float xpos_rightalignemnt, float ypos)
        {
            SizeF sf = graphics.MeasureString(s, font);
            float fxpos = xpos_rightalignemnt - sf.Width;
            graphics.DrawString(s, font, new SolidBrush(color), fxpos, ypos);

        }

        public static void DrawWordWrap(Graphics graphics, string s, Font font, Color color, float xpos, float ypos, float pagewidth, ref float offset)
        {
            Pen pen = new Pen(Color.Black);
            StringFormat sformat = new StringFormat();
            sformat.Alignment = StringAlignment.Near;
            SizeF sfx = graphics.MeasureString(s,font, (int)(pagewidth - xpos), sformat);
            RectangleF drawRect = new RectangleF(xpos, ypos, pagewidth-xpos, sfx.Height);
            //graphics.FillRectangle(Brushes.Azure, drawRect);
            graphics.DrawString(s, font, new SolidBrush(color), drawRect);
            offset = sfx.Height;
        }

        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        public static void Cursor_Wait(Control xctrl)
        {
            Form frm = Global.f.GetParentForm(xctrl);
            if (frm != null)
            {
                frm.Cursor = Cursors.WaitCursor;
            }
        }

        public static void Cursor_Arrow(Control xctrl)
        {
            Form frm = Global.f.GetParentForm(xctrl);
            if (frm != null)
            {
                frm.Cursor = Cursors.Arrow;
            }
        }

  

        public static void DataGridCollumnVisible(DataGridView dgv, bool v)
        {
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                dgvc.Visible = v;
            }
        }
    }
}
