#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLTableControl
{
    public class MyControl
    {


        public int x;
        public int y;
        public int cx;
        public int cy;
        public Object Control;

        public MyControl(Object ctrl)
        {

            if (ctrl.GetType() == typeof(usrc_myGroupBox))
            {
                usrc_myGroupBox pMyGroupBox = (usrc_myGroupBox)ctrl;
                x = pMyGroupBox.Left;
                y = pMyGroupBox.Top;
                cx = pMyGroupBox.Width;
                cy = pMyGroupBox.Height;
                Control = ctrl;
            }
            else if (ctrl.GetType() == typeof(usrc_InputControl))
            {
                usrc_InputControl pInputControl = (usrc_InputControl)ctrl;
                x = pInputControl.Left;
                y = pInputControl.Top;
                cx = pInputControl.Width;
                cy = pInputControl.Height;
                Control = ctrl;
            }
        }
    }
}
