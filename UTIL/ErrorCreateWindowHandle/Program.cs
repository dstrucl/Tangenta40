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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorCreateWindowHandle
{
    public static class Program
    {
        public static int iGDIcUser100;
        public static int iGDIcUser101;
        public static int iGDIcUser102;
        public static int iGDIcUser103;
        public static int iGDIcUser104;

        public static int iGDIcUser_After_Insert_usrc_Item2;
        public static int iGDIcUser_Insert_usrc_Item1;
        public static int iGDIcUser_Insert_usrc_Item2;
        public static int iGDIcUser_Insert_usrc_Item4;
        public static int iGDIcUser_Insert_usrc_Item5;
        public static int iGDIcUser_Insert_usrc_Item6;
        public static int iGDIcUser10;
        public static int iGDIcUser11;
        public static int iGDIcUser12;

        [DllImport("User32")]
        extern public static int GetGuiResources(IntPtr hProcess, int uiFlags);

        public static int getGuiResourcesUserCount()
        {
            return GetGuiResources(System.Diagnostics.Process.GetCurrentProcess().Handle, 1);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
