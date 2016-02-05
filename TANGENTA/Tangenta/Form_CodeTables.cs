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

namespace Tangenta
{
    public partial class Form_CodeTables : Form
    {
        public Form_CodeTables()
        {
            InitializeComponent();
            lngRPM.s_CodeTables.Text(this);
        }

        private void usrc_CodeTables1_OK_Click()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void usrc_CodeTables1_EndDialog()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void usrc_CodeTables1_Load(object sender, EventArgs e)
        {

        }
    }
}
