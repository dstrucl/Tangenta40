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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommandLineHelp
{
    internal partial class CommandLineHelp_ItemControl : UserControl
    {
        private string m_command = null;

        public string Command
        {
            get  { return m_command; }
            set { m_command = value; }
        }

        public bool Selected
        {
            get { return this.chk_select.Checked; }
        }
        public CommandLineHelp_ItemControl(CommandLineHelp chlp)
        {
            InitializeComponent();
            m_command = chlp.Command;
            if (m_command!=null)
            {
                chk_select.Visible = true;
            }
            else
            {
                chk_select.Visible = false;
            }
            this.txt_Help.Text = chlp.Command + " = " + chlp.description;
        }
    }
}
