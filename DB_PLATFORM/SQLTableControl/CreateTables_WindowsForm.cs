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

namespace SQLTableControl
{
    public partial class CreateTables_WindowsForm : Form
    {
        public CreateTables_WindowsForm(int Tables_Count)
        {
            InitializeComponent();
            this.Text = lngRPM.s_WaitToCreate_Tables.s;
            this.lbl_CopyRight.Text = lngRPM.s_Copyright_Tangenta.s;
            this.lbl_CopyRight.BackColor = Color.Transparent;
            this.lbl_Info.Text = lngRPM.s_NumberOfTabelsToCreate.s + Tables_Count.ToString();
        }
    }
}
