using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayoutManager
{
    public class ControlLayout
    {
        private int x = 0;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        private int cx = 0;
        public int CX
        {
            get
            {
                return cx;
            }
            set
            {
                cx = value;
            }
        }
        private int y = 0;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        private int cy = 0;
        public int CY
        {
            get
            {
                return cy;
            }
            set
            {
                cy = value;
            }
        }

        private string controlname = null;
        public string ControlName
        {
            get
            {
                return controlname;
            }
            set
            {
                controlname = value;
            }
        }

        public List<ControlLayout> LayoutChildren = null;

        public ControlLayout(Control ctrl)
        {
            x = ctrl.Left;
            y = ctrl.Top;
            cx = ctrl.Width;
            cy = ctrl.Height;
            controlname = ctrl.Name;
            foreach (Control ctrlx in ctrl.Controls)
            {
                if (LayoutChildren==null)
                {
                    LayoutChildren = new List<ControlLayout>();
                }
                ControlLayout ly = new ControlLayout(ctrlx);
                LayoutChildren.Add(ly);
            }
        }
    }
}
