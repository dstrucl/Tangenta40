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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class Form_Help : Form
    {

        private usrc_Help mH = null;

        public Form_Help(usrc_Help xusrc_Help)
        {
            InitializeComponent();

            mH = xusrc_Help;
        }

        private void Form_Help_Load(object sender, EventArgs e)
        {
            usrc_web_Help1.Init(mH);
            usrc_web_Help1.Refresh();
        }
    }
}
