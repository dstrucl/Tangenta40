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

namespace CodeTables
{
    public class Col_class
    {
        public CodeTables.Column.Flags m_Flags;
        public string sColName;
        public string sValue;
        public Col_class(string sCol, string sVal, CodeTables.Column.Flags flags)
        {
            m_Flags = flags;
            sColName = sCol;
            sValue = sVal;
        }
    }
}
