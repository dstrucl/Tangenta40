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
using SQLTableControl;
using StaticLib;

namespace SQLTableControl
{
    public partial class VirtualSecretary_Form : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);

        SQLTable m_tbl;
        //Form m_pParentForm;
        int iParentFormHandle;
        bool bStart = false;
        int iEntryCount = 0;


        public VirtualSecretary_Form(SQLTable tbl, int iHandle)
        {
            m_tbl = tbl;
            InitializeComponent();
            iParentFormHandle = iHandle;
        }

        private void btnStartPause_Click(object sender, EventArgs e)
        {
            if (!bStart)
            {
                bStart = true;
                btnStartPause.Text = lngRPM.s_Pause.s;
                this.pictureBox_Secretary.Image = Properties.Resources.jim_carrey_typing_grande;
                timer_EnterData.Enabled = true;
                iEntryCount = Convert.ToInt32(nmUpDown_Entries.Value);
            }
            else
            {
                bStart = false;
                btnStartPause.Text = lngRPM.s_Start.s;
                this.pictureBox_Secretary.Image = Properties.Resources.JimCarreyWaits2;
                timer_EnterData.Enabled = false;
            }
        }

        private void timer_EnterData_Tick(object sender, EventArgs e)
        {
            timer_EnterData.Enabled = false;
            if (iEntryCount > 0)
            {
                System.IntPtr wparam = new IntPtr(this.Handle.ToInt32());
                System.IntPtr lparam = new IntPtr(iEntryCount);
                PostMessage(iParentFormHandle, Func.WM_USER_GENERATE_RANDOM_INPUT, wparam, lparam);
            }
            else
            {
                bStart = false;
                btnStartPause.Text = lngRPM.s_Start.s;
                this.pictureBox_Secretary.Image = Properties.Resources.JimCarreySleeps;
                System.IntPtr wparam = new IntPtr(this.Handle.ToInt32());
                System.IntPtr lparam = new IntPtr(iEntryCount);
                PostMessage(iParentFormHandle, Func.WM_USER_GENERATE_RANDOM_INPUT_DONE, wparam, lparam);
            }
        }

        private void VirtualSecretary_Form_Load(object sender, EventArgs e)
        {
            lbl_NumberOfEntries.Text = lngRPM.s_NumberOfEntries.s;
            this.pictureBox_Secretary.Image = Properties.Resources.JimCarreyWaits2;
            btnStartPause.Text = lngRPM.s_Start.s;
            this.btnSettings.Text = lngRPM.sRandomDataSettings.s;
            this.btnCancel.Text = lngRPM.s_Cancel.s;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            WaitRandomDataParamSettingsDialogClosed_Form WaitRandomDataParamSettingsDialogClosed = new WaitRandomDataParamSettingsDialogClosed_Form(iParentFormHandle,this);
            WaitRandomDataParamSettingsDialogClosed.ShowDialog();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            if (m.Msg == (int)Func.WM_USER_GENERATE_RANDOM_INPUT_OK)
            {
                iEntryCount = m.LParam.ToInt32();
                iEntryCount--;
                nmUpDown_Entries.Value = Convert.ToDecimal(iEntryCount);
                timer_EnterData.Enabled = true;
            }
            base.WndProc(ref m);
        }
    }

}
