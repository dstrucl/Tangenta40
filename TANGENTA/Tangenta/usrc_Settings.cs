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
using SQLTableControl;
using BlagajnaTableClass;
using InvoiceDB;
using UpgradeDB;

namespace Tangenta
{
    public partial class usrc_Settings : UserControl
    {
        public delegate void delegate_Backup();
        public event delegate_Backup Backup;

        public delegate void delegate_Settings_Click();
        public event delegate_Settings_Click Settings_Click;



        public usrc_Settings()
        {
            InitializeComponent();
        }



        private void m_usrc_Upgrade_Backup()
        {
            if (Backup!=null)
            {
                Backup();
            }
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            if (Settings_Click!=null)
            {
                Settings_Click();
            }
        }

        private void m_usrc_Upgrade_Load(object sender, EventArgs e)
        {

        }

    }
}
