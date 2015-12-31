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
            this.lbl_Help.Text = chlp.Command + " = " + chlp.description;
        }
    }
}
