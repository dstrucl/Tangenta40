#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangentaPrint
{
    public partial class Form_DeviceSettings : Form
    {
        usrc_Device m_usrc_Device = null;
        public Form_DeviceSettings(usrc_Device xusrc_Printer)
        {
            InitializeComponent();
            m_usrc_Device = xusrc_Printer;
            this.m_usrc_DeviceSettings.Init(m_usrc_Device.m_Printer);
            lngRPM.s_PrinterDeviceSettings.Text(this," "+ (m_usrc_Device.m_Printer.Index+1).ToString());
        }

        private void Form_PrinterSettings_Load(object sender, EventArgs e)
        {
         
        }
    }
}
