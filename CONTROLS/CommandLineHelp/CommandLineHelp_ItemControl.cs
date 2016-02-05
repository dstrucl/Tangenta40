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

namespace CommandLineHelp
{
    internal partial class CommandLineHelp_ItemControl : UserControl
    {
        public CommandLineHelp_ItemControl(CommandLineHelp chlp)
        {
            InitializeComponent();
            this.txt_Help.Text = chlp.Command + " = " + chlp.description;
        }
    }
}
