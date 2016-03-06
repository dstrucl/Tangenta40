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

namespace CodeTables
{
    public static class DefWindowPos
    {
        public static int MainForm_Left;
        public static int MainForm_Top;
        public static int MainForm_Width;
        public static int MainForm_Height;

        public static int TableDockingForm_Left;
        public static int TableDockingForm_Top;
        public static int TableDockingForm_Width;
        public static int TableDockingForm_Height;

        public static int EditTable_Form_Left;
        public static int EditTable_Form_Top;
        public static int EditTable_Form_Width;
        public static int EditTable_Form_Height;

        public static int DataTable_Form_Left;
        public static int DataTable_Form_Top;
        public static int DataTable_Form_Width;
        public static int DataTable_Form_Height;

        public static int CreateView_Form_Left;
        public static int CreateView_Form_Top;
        public static int CreateView_Form_Width;
        public static int CreateView_Form_Height;

        public static int TableView_Form_Left;
        public static int TableView_Form_Top;
        public static int TableView_Form_Width;
        public static int TableView_Form_Height;

        public static void Init(Form MainForm)
        {
            Screen scr = Screen.FromControl(MainForm);
            MainForm_Left = scr.Bounds.Width / 8;
            MainForm_Top = scr.Bounds.Height / 8;
            MainForm_Width = (6 * scr.Bounds.Width) / 8;
            MainForm_Height = (6 * scr.Bounds.Height) / 8;

            TableDockingForm_Left = (MainForm_Width) / 16; ;
            TableDockingForm_Top = (MainForm_Height) / 16; ;
            TableDockingForm_Width = (14 * MainForm_Width) / 16; ;
            TableDockingForm_Height = (14 * MainForm_Height) / 16; ;

            EditTable_Form_Left = 0;
            EditTable_Form_Top = (6 * TableDockingForm_Height) / 16;
            EditTable_Form_Width = TableDockingForm_Width / 2 - 20;
            EditTable_Form_Height = (10 * TableDockingForm_Height) / 16;

            DataTable_Form_Left = (TableDockingForm_Width) / 2;
            DataTable_Form_Top = (6 * TableDockingForm_Height) / 16;
            DataTable_Form_Width = TableDockingForm_Width / 2 - 20;
            DataTable_Form_Height = (10 * TableDockingForm_Height) / 16;

            CreateView_Form_Left = 0;
            CreateView_Form_Top = 0;
            CreateView_Form_Width = TableDockingForm_Width - 20;
            CreateView_Form_Height = (6 * TableDockingForm_Height) / 16;

            TableView_Form_Left = (TableDockingForm_Width) / 2;
            TableView_Form_Top = (6 * TableDockingForm_Height) / 16;
            TableView_Form_Width = TableDockingForm_Width / 2 - 20;
            TableView_Form_Height = (10 * TableDockingForm_Height) / 16;

        }
    }
}
