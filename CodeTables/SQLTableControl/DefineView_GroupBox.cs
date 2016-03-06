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
using System.Windows.Forms;
using LanguageControl;
using System.Runtime.InteropServices;
using System.Resources;
using StaticLib;

namespace CodeTables
{
    //public class MyControl
    //{


    //    public int x;
    //    public int y;
    //    public int cx;
    //    public int cy;
    //    public Object Control;
        
    //    public MyControl(Object ctrl)
    //    {
            
    //        if (ctrl.GetType() == typeof(MyGroupBox))
    //        {
    //            MyGroupBox pMyGroupBox = (MyGroupBox)ctrl;
    //            x = pMyGroupBox.Left;
    //            y = pMyGroupBox.Top;
    //            cx = pMyGroupBox.Width;
    //            cy = pMyGroupBox.Height;
    //            Control = ctrl;
    //        }
    //        else if (ctrl.GetType() == typeof(InputControl))
    //        {
    //            InputControl pInputControl = (InputControl)ctrl;
    //            x = pInputControl.x;
    //            y = pInputControl.y;
    //            cx = pInputControl.cx;
    //            cy = pInputControl.cy;
    //            Control = ctrl;
    //        }
    //    }
    //}

    public class DefineView_GroupBox:GroupBox
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);

        public bool bExpanded;
        public string sParentKeys;
        public SQLTable pSQL_Table;
        public Object pParentWindow;
        public Button randomize;
        private Form pForm;
        private CheckBox checkview;

        public List<MyControl> controls = new List<MyControl>();
        private Button btnExpand;



        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (bExpanded)
            {
                bExpanded = false;
                btnExpand.Text = "";
                btnExpand.Image = Resource.IconPlus.ToBitmap();
            }
            else
            {
                bExpanded = true;
                btnExpand.Text = "";
                btnExpand.Image = Resource.IconMinus.ToBitmap();
            }
            System.IntPtr wparam = new IntPtr(0);
            System.IntPtr lparam = new IntPtr(0);
            PostMessage(pForm.Handle.ToInt32(), Func.WM_USER_REDRAW_FORM, wparam, lparam);
        }

        public DefineView_GroupBox(SQLTable pTbl, string sPrKeys, Object pPrevWindow,Form pFrm)
        {
            randomize = new Button();
            randomize.Visible = true;
            randomize.Text = "randomize";
             pForm = pFrm;
             pParentWindow = pPrevWindow;
             pSQL_Table = pTbl;
             sParentKeys = sPrKeys;
             base.Text = pTbl.lngTableName.s;
             if (pPrevWindow.GetType().BaseType == typeof(Form))
             {
                 base.Parent = (Form)pPrevWindow;
             }
             if (pPrevWindow.GetType() == typeof(DefineView_GroupBox))
             {
                 base.Parent = (DefineView_GroupBox)pPrevWindow;
             }
             
             bExpanded = true;
             checkview = new CheckBox();
             btnExpand = new Button();
             btnExpand.Text = "";
             btnExpand.Image = Resource.IconMinus.ToBitmap();
             btnExpand.Top = 14;
             btnExpand.Left = 3;
             btnExpand.Width = 22;
             btnExpand.Height = 22;
             btnExpand.Click +=new EventHandler(btnExpand_Click);
             btnExpand.Visible = true;
             btnExpand.Parent = this;
             checkview.Parent = this;
             checkview.Visible = true;
             checkview.Top = btnExpand.Top;
             checkview.Left = btnExpand.Left + 20;
             checkview.AutoSize = true;
             base.Visible = false;
        }
    }
}

