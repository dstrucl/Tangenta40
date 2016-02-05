#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopA
{
    // Create a column class to display the Save buttons.
    public class DataGridViewImageButtonColumn : DataGridViewButtonColumn
    {
        public enum eselection {select,deselect,discount};
        public DataGridViewImageButtonColumn()
        {
            this.CellTemplate = new DataGridViewImageButtonDeselectCell();
            this.Width = 22;
            this.Resizable = DataGridViewTriState.False;
        }
    }
}
