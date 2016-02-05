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

namespace DBSync
{
    public partial class Form_StartupWindow : Form
    {
        public Form_StartupWindow()
        {
            InitializeComponent();
            this.Text = lngRPM.s_Startup_title.s;
            this.lbl_CopyRight.Text = lngRPM.s_Copyright_KIG.s;
            this.lbl_CopyRight.BackColor = Color.Transparent;
        }
    }
}
