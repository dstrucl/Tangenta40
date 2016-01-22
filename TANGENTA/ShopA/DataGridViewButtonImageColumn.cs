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
