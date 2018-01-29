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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class usrc_Help: UserControl
    {
        internal Form pForm = null;
        public Form_Help hlp_dlg = null;
        public usrc_Help()
        {
            InitializeComponent();
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            pForm = Global.f.GetParentForm(this);
            if (hlp_dlg==null)
            {
                hlp_dlg = new Form_Help(pForm);
            }
            hlp_dlg.Show();
        }
    }
}
