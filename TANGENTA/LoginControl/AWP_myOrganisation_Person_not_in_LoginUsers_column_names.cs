using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginControl
{
    class AWPColName
    {

        public Control lbl_ctrl = null;
        public Control edit_ctrl = null;
        public string ColumnName = "";
        public ltext NameInLanguage = null;
        public int DisplayIndex = 0;
        public AWPColName(string colname,ltext ltext_colname, int display_index,Control xctrl, Control xedit_ctrl)
        {
            lbl_ctrl = xctrl;
            edit_ctrl = xedit_ctrl;
            ColumnName = colname;
            NameInLanguage = ltext_colname;
            DisplayIndex = display_index;

        }
    }
}
