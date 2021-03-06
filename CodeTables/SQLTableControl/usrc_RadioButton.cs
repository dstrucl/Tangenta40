﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniqueControlNames;

namespace CodeTables
{
    public class usrc_RadioButton:System.Windows.Forms.RadioButton
    {
        private bool readOnly;

        public usrc_RadioButton(UniqueControlName xuctrln)
        {
            this.Name = "urdb_" + xuctrln.Get_usrc_RadioButton_UniqueIndex();
        }
        
        protected override void OnForeColorChanged(EventArgs e)
        {
            if (!ReadOnly)
            {
                base.OnForeColorChanged(e);
            }
            else
            {
                ForeColor = Color.Gray;
            }

        }
        protected override void OnClick(EventArgs e)
        {
            // pass the event up only if its not readlonly
            if (!ReadOnly) base.OnClick(e);
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; 
                  if (readOnly)
                  {
                      this.Cursor = Cursors.No;
                  }
                  else
                  {
                      this.Cursor = Cursors.Arrow;
                  }
                }
        }

    }
}
