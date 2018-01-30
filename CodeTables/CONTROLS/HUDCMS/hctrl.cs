using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public class hctrl
    {
        public Control ctrl = null;
        public hctrl parentctrl = null;
        public List<hctrl> subctrl = null;
        public int xScr = -1;
        public int yScr = -1;
        public int width = 0;
        public int height = 0;
        public Form pForm = null;
        public Screen pScreen = null;
        public Bitmap ctrlbmp = null;

        public hctrl(Form pForm)
        {
            this.pForm = pForm;
            xScr = pForm.Left;
            yScr = pForm.Top;
            pScreen = Screen.FromControl(pForm);
            ctrlbmp = new Bitmap(pForm.Width, pForm.Height);
            pForm.DrawToBitmap(ctrlbmp, new Rectangle(0, 0, pForm.Width, pForm.Height));
            foreach (Control c in pForm.Controls)
            {
                if (c is UserControl)
                {
                    AddSubCtrl(c);
                }
                else if (c is SplitContainer)
                {
                    AddSubCtrl(c);
                }
                else if (c is Panel)
                {
                    AddSubCtrl(c);
                }
                else if (c is GroupBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is Label)
                {
                    AddSubCtrl(c);
                }
                else if (c is Button)
                {
                    AddSubCtrl(c);
                }
                else if (c is TextBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is ComboBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is NumericUpDown)
                {
                    AddSubCtrl(c);
                }
            }
        }

        public hctrl(Control xc,hctrl xparent)
        {
            this.ctrl = xc;
            this.parentctrl = xparent;
            xScr = xparent.xScr + xc.Left;
            yScr = xparent.yScr + xc.Top;
            ctrlbmp = new Bitmap(xc.Width, xc.Height);
            xc.DrawToBitmap(ctrlbmp, new Rectangle(0, 0, xc.Width, xc.Height));
            foreach (Control c in xc.Controls)
            {
                if (c is UserControl)
                {
                    AddSubCtrl(c);
                }
                else if (c is SplitContainer)
                {
                    AddSubCtrl(c);
                }
                else if (c is Panel)
                {
                    AddSubCtrl(c);
                }
                else if (c is GroupBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is Label)
                {
                    AddSubCtrl(c);
                }
                else if (c is Button)
                {
                    AddSubCtrl(c);
                }
                else if (c is TextBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is ComboBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is NumericUpDown)
                {
                    AddSubCtrl(c);
                }
            }
        }

        private void AddSubCtrl(Control c)
        {
            if (subctrl==null)
            {
                subctrl = new List<hctrl>();
            }
            subctrl.Add(new hctrl(c,this));
        }
    }
}
