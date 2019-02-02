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
        public Control Ctrl = null;

        public ControlLayout Parent = null;

        private AnchorStyles anchor = 0;
        public AnchorStyles Anchor
        {
            get
            {
                return anchor;
            }
            set
            {
                anchor = value;
            }
        }

        private int xdef = 0;
        public int Xdef
        {
            get
            {
                return xdef;
            }
            set
            {
                xdef = value;
            }
        }

        private int cxdef = 0;
        public int CXdef
        {
            get
            {
                return cxdef;
            }
            set
            {
                cxdef = value;
            }
        }

        private int xofsdef = 0;
        public int Xofsdef
        {
            get
            {
                return xofsdef;
            }
            set
            {
                xofsdef = value;
            }
        }

        private int xofs = 0;
        public int Xofs
        {
            get
            {
                return xofs;
            }
            set
            {
                xofs = value;
            }
        }


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


      

        private int scx = 0;
        public int SCX
        {
            get
            {
                return scx;
            }
            set
            {
                scx = value;
            }
        }

        private int scxdef = 0;
        public int SCXdef
        {
            get
            {
                return scxdef;
            }
            set
            {
                scxdef = value;
            }
        }

        private int ydef = 0;
        public int Ydef
        {
            get
            {
                return ydef;
            }
            set
            {
                ydef = value;
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

        private int yofs = 0;
        public int Yofs
        {
            get
            {
                return yofs;
            }
            set
            {
                yofs = value;
            }
        }

        private int yofsdef = 0;
        public int Yofsdef
        {
            get
            {
                return yofsdef;
            }
            set
            {
                yofsdef = value;
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


        private int scydef = 0;
        public int SCYdef
        {
            get
            {
                return scydef;
            }
            set
            {
                scydef = value;
            }
        }

        private int scy = 0;
        public int SCY
        {
            get
            {
                return scy;
            }
            set
            {
                scy = value;
            }
        }


        private int cydef = 0;
        public int CYdef
        {
            get
            {
                return cydef;
            }
            set
            {
                cydef = value;
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

        public ControlLayout(int scx_def, int scy_def, int xofs_def,int yofs_def, ControlLayout parent,Control ctrl)
        {
            Parent = parent;
            scxdef = scxdef;
            scydef = scydef;
            Ctrl = ctrl;
            xdef = ctrl.Left;
            ydef = ctrl.Top;
            cxdef = ctrl.Width;
            cydef = ctrl.Height;
            xofsdef = xofs_def + ctrl.Left;
            yofsdef = yofs_def + ctrl.Top;
            controlname = ctrl.Name;
            anchor = ctrl.Anchor;
            foreach ( Control ctrlx in ctrl.Controls)
            {
                if (LayoutChildren==null)
                {
                    LayoutChildren = new List<ControlLayout>();
                }
                ControlLayout ly = new ControlLayout(scxdef,scydef,xofsdef, yofsdef,this, ctrlx);
                LayoutChildren.Add(ly);
            }
        }

        public void SetNewLayout(int scx_, int scy_, int xofs, int yofs)
        {
            scx = scx_;
            scy = scy_;
            if (((short)anchor) == ((short) (AnchorStyles.Top | AnchorStyles.Left)))
            {

            }
        }
    }
}
