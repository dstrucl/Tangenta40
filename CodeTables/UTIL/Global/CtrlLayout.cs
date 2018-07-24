using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Global
{
    public class CtrlLayout
    {
        public enum eCtrlLayoutType { MOUSE, TOUCHSCREEN };
        private Control ctrl = null;
        private int[] Top = new int[2] { 0, 0 };
        private int[] Left = new int[2] { 0, 0 };
        private int[] Width = new int[2] { 0, 0 };
        private int[] Height = new int[2] { 0, 0 };

        public CtrlLayout(Control xctrl, int xtop, int xleft, int xWidth, int xHeight, eCtrlLayoutType xeCtrlLayoutType)
        {
            int i = 0;
            switch (xeCtrlLayoutType)
            {
                case eCtrlLayoutType.MOUSE:
                    i = 0;
                    break;
                case eCtrlLayoutType.TOUCHSCREEN:
                    i = 1;
                    break;
                default:
                    MessageBox.Show("ERROR:ControlLayout:CtrlLayout:constructor:eCtrlLayoutType is not implemented:" + xeCtrlLayoutType.ToString());
                    return;
            }

            ctrl = xctrl;
            Top[i] = xtop;
            Left[i] = xleft;
            Width[i] = xWidth;
            Height[i] = xHeight;
        }

        public void Set(eCtrlLayoutType xeCtrlLayoutType)
        {
            int i = 0;
            switch (xeCtrlLayoutType)
            {
                case eCtrlLayoutType.MOUSE:
                    i = 0;
                    break;
                case eCtrlLayoutType.TOUCHSCREEN:
                    i = 1;
                    break;
                default:
                    MessageBox.Show("ERROR:ControlLayout:CtrlLayout:Set:eCtrlLayoutType is not implemented:" + xeCtrlLayoutType.ToString());
                    return;
            }
            this.ctrl.Top = Top[i];
            this.ctrl.Left = Left[i];
            this.ctrl.Width = Width[i];
            this.ctrl.Height = Height[i];
            this.ctrl.Refresh();
        }
    }
}
