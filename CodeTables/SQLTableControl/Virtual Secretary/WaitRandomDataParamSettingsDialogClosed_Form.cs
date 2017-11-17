#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using System.Runtime.InteropServices;
using StaticLib;

namespace CodeTables
{
    public partial class WaitRandomDataParamSettingsDialogClosed_Form : Form
    {
        int m_iParentFormHandle;
        VirtualSecretary_Form m_Form;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);

        public WaitRandomDataParamSettingsDialogClosed_Form(int iParentFormHandle, VirtualSecretary_Form pForm)
        {
            m_Form = pForm;
            m_iParentFormHandle = iParentFormHandle;
            InitializeComponent();

        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            if (m.Msg == (int)Func.WM_RANDOM_PARAM_SETTINGS_DIALOG_CLOSED)
            {
                Close();
                DialogResult = DialogResult.OK;
                return;
            }
            base.WndProc(ref m);
        }

        private void WaitRandomDataParamSettingsDialogClosed_Form_Load(object sender, EventArgs e)
        {
            //this.Top = 0;
            //this.Left = 0;
            //this.Width = 0;
            //this.Height = 0;
            //this.Visible = false;
            //this.Parent = m_Form;
            //this.Owner = m_Form;
            this.CenterToScreen();
            this.Visible = true;
            this.lbl_WaitRandomDataParamSettingsDialogIsClosed.Text = lng.s_WaitUntilRandomParamSettingDialogIsClosed.s;
            System.IntPtr wparam = new IntPtr(this.Handle.ToInt32());
            System.IntPtr lparam = new IntPtr(0);
            PostMessage(m_iParentFormHandle, Func.WM_DO_RANDOM_PARAM_SETTINGS_DIALOG, wparam, lparam);
        }
    }
}
