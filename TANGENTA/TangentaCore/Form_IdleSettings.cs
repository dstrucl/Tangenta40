﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangentaCore
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
            TangentaProperties.Properties.Settings.Default.IdleControl_FileImageUrl1 = idlectrl.FileImageUrl1;
            TangentaProperties.Properties.Settings.Default.IdleControl_FileImageUrl2 = idlectrl.FileImageUrl2;
            TangentaProperties.Properties.Settings.Default.IdleControl_Active = idlectrl.Active;
            TangentaProperties.Properties.Settings.Default.IdleControl_UseExitButton = idlectrl.UseExitButton;
            TangentaProperties.Properties.Settings.Default.IdleControl_ShowURL2 = idlectrl.ShowURL2;
            TangentaProperties.Properties.Settings.Default.IdleControl_TimeInSecondsToActivate = idlectrl.TimeInSecondsToActivate;
            TangentaProperties.Properties.Settings.Default.IdleControl_URL1 = idlectrl.URL1;
            TangentaProperties.Properties.Settings.Default.IdleControl_URL2 = idlectrl.URL2;
            TangentaProperties.Properties.Settings.Default.Save();
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