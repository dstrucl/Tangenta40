using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLTableControl
{
    public class usrc_RadioButton:System.Windows.Forms.RadioButton
    {
        private bool readOnly;

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
