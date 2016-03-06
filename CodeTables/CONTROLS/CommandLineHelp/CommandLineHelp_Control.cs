﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace CommandLineHelp
{
    public partial class CommandLineHelp_Control : UserControl
    {
        private List<CommandLineHelp> m_CommandLineHelpList = null;
        public CommandLineHelp_Control()
        {
            InitializeComponent();
            btn_CommandLineHelp.Text = lngRPM.s_CommandLineHelp.s;
        }

        public void Attach(List<CommandLineHelp> xCommandLineHelpList)
        {
            m_CommandLineHelpList = xCommandLineHelpList;
        }

        private void btn_CommandLineHelp_Click(object sender, EventArgs e)
        {
            CommandLineHelp_Form hlpfrm = new CommandLineHelp_Form(m_CommandLineHelpList);
            hlpfrm.ShowDialog();
        }
    }
}