using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationButtons
{
    public class NavigationButtons
    {
        public enum eButtons { PrevNextExit, OkCancel };

        public enum eEvent {NOTHING, PREV, NEXT, EXIT, OK, CANCEL };

        public eButtons m_eButtons = eButtons.OkCancel;

        public Image btn1_Image = null;
        public string btn1_Text = null;
        public bool btn1_Visible = true;

        public Image btn2_Image = null;
        public string btn2_Text = null;
        public bool btn2_Visible = true;

        public Image btn3_Image = null;
        public string btn3_Text = null;
        public bool btn3_Visible = true;

    }
}
