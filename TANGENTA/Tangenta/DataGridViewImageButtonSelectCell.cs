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
using System.IO;
using System.Drawing;

namespace Tangenta
{
    // Create a cell class to display the Save button cells. It is derived from the 
    // abstract class DataGridViewImageButtonCell. The only method that has to be 
    // implemented is LoadImages to load the Normal, Hot and Disabled Save images.
    public class DataGridViewImageButtonSelectCell : DataGridViewImageButtonCell
    {
        public override void LoadImages()
        {
            _buttonImageNormal = Properties.Resources.SelectSimpleItem;
            _buttonImageDisabled = Properties.Resources.SelectSimpleItemDisabled;
            _buttonImageHot = Properties.Resources.SelectSimpleItemHot;
        }
    }
    public class DataGridViewImageButtonDeselectCell : DataGridViewImageButtonCell
    {
        public override void LoadImages()
        {
            _buttonImageNormal = Properties.Resources.DeSelectSimpleItem;
            _buttonImageDisabled = Properties.Resources.DeSelectSimpleItemDisabled;
            _buttonImageHot = Properties.Resources.DeSelectSimpleItemHot;
        }
    }
    public class DataGridViewImageButtonDiscountCell : DataGridViewImageButtonCell
    {
        public override void LoadImages()
        {
            _buttonImageNormal = Properties.Resources.Discount;
            _buttonImageDisabled = Properties.Resources.DiscountDisabled;
            _buttonImageHot = Properties.Resources.DiscountHot;
        }
    }
}
