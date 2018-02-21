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
using UniqueControlNames;

namespace CodeTables
{
    public partial class usrc_InputControl_DataBox : UserControl
    {
        public Byte[] Data;

        public usrc_InputControl_DataBox(UniqueControlName xuctrln)
        {
            InitializeComponent();
            this.Name = "uInputDataBox_" + xuctrln.Get_usrc_InputControl_DataBox_UniqueIndex();
        }
    }
}
