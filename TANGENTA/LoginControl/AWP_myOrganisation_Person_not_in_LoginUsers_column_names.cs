using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginControl
{
    internal class AWPColName
    {

        internal Control lbl_ctrl = null;
        internal Control edit_ctrl = null;
        internal string ColumnName = "";
        internal ltext NameInLanguage = null;
        internal int DisplayIndex = 0;
        internal AWPColName(string colname,ltext ltext_colname, int display_index)
        {
            ColumnName = colname;
            NameInLanguage = ltext_colname;
            DisplayIndex = display_index;
            lbl_ctrl = null;
            edit_ctrl = null;
        }

        internal void Bind(Control xctrl, Control xedit_ctrl)
        {
            lbl_ctrl = xctrl;
            edit_ctrl = xedit_ctrl;
        }

    }
}
