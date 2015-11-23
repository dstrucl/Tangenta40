using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLTableControl
{
    public class Col_class
    {
        public SQLTableControl.Column.Flags m_Flags;
        public string sColName;
        public string sValue;
        public Col_class(string sCol, string sVal, SQLTableControl.Column.Flags flags)
        {
            m_Flags = flags;
            sColName = sCol;
            sValue = sVal;
        }
    }
}
