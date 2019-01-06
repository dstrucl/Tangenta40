using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentManager
{
    public partial class Form_IdleSettings : Form
    {
        LoginControl.IdleControl idlectrl = null;

        public Form_IdleSettings()
        {
            InitializeComponent();
        }

        public Form_IdleSettings(LoginControl.IdleControl xidlectrl)
        {
            InitializeComponent();
            idlectrl = xidlectrl;
            this.usrc_IdleSettings1.Init(idlectrl);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.usrc_IdleSettings1.Set();
            Properties.Settings.Default.IdleControl_FileImageUrl1 = idlectrl.FileImageUrl1;
            Properties.Settings.Default.IdleControl_FileImageUrl2 = idlectrl.FileImageUrl2;
            Properties.Settings.Default.IdleControl_Active = idlectrl.Active;
            Properties.Settings.Default.IdleControl_UseExitButton = idlectrl.UseExitButton;
            Properties.Settings.Default.IdleControl_ShowURL2 = idlectrl.ShowURL2;
            Properties.Settings.Default.IdleControl_TimeInSecondsToActivate = idlectrl.TimeInSecondsToActivate;
            Properties.Settings.Default.IdleControl_URL1 = idlectrl.URL1;
            Properties.Settings.Default.IdleControl_URL2 = idlectrl.URL2;
            Properties.Settings.Default.Save();
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
