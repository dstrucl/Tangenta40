using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class usrc_IdleSettings : UserControl
    {
        private IdleControl idlectrl = null;
        public usrc_IdleSettings()
        {
            InitializeComponent();
            lng.s_chk_ShowIdleControl.Text(chk_ShowIdleControl);
            lng.s_lbl_TimeInSecondsToActivateIdleControl.Text(lbl_TimeInSecondsToActivateIdleControl);
            lng.s_chk_ExitWithButton.Text(chk_ExitWithButton);
            lng.s_lbl_URL1.Text(lbl_URL1);
            lng.s_chk_ShowURL2.Text(chk_ShowURL2);
            lng.s_lbl_URL2.Text(lbl_URL2);
        }


        public void Init(IdleControl xidlectrl)
        {
            idlectrl = xidlectrl;

            chk_ShowIdleControl.Checked = idlectrl.Active;
            nmUpDn_TimeInSecondsToActivateIdleControl.Value = Convert.ToDecimal(idlectrl.TimeInSecondsToActivate);
            chk_ExitWithButton.Checked = idlectrl.UseExitButton;
            chk_ShowURL2.Checked = idlectrl.ShowURL2;
            txt_URL1.Text = idlectrl.URL1;
            txt_URL2.Text = idlectrl.URL2;
            EnableControls(chk_ShowIdleControl.Checked);
            chk_ShowIdleControl.CheckedChanged += Chk_ShowIdleControl_CheckedChanged;
        }

        private void Chk_ShowIdleControl_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(chk_ShowIdleControl.Checked);
        }

        private void EnableControls(bool xchecked)
        {
            nmUpDn_TimeInSecondsToActivateIdleControl.Enabled = xchecked;
            chk_ExitWithButton.Enabled = xchecked; 
            chk_ShowURL2.Enabled = xchecked; 
            txt_URL1.Enabled = xchecked; 
            txt_URL2.Enabled = xchecked; 
        }

        public void Set()
        {
            idlectrl.Active = chk_ShowIdleControl.Checked;
            idlectrl.TimeInSecondsToActivate = Convert.ToInt32(nmUpDn_TimeInSecondsToActivateIdleControl.Value);
            idlectrl.UseExitButton = chk_ExitWithButton.Checked;
            idlectrl.ShowURL2 = chk_ShowURL2.Checked;
            idlectrl.URL1 = txt_URL1.Text;
            idlectrl.URL2 = txt_URL2.Text;
        }

    }
}
