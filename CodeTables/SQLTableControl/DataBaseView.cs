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
    public class DataBaseView
    {
       public string ViewName;
       public string SQLCommand;
       public DataBaseView(string xViewName, string xSQLCommand)
       {
           ViewName = xViewName;
           SQLCommand = xSQLCommand;
       }

       internal string SQLcmd_DropView()
       {
            return @"
                DROP VIEW [dbo].[" + ViewName + "];\n";
       }

       internal string MySQLcmd_DropView()
       {
           return @"
                DROP VIEW [dbo].[" + ViewName + "];\n";
       }

       internal string SQLitecmd_DropView()
       {
           return @" DROP VIEW IF EXISTS " + ViewName + ";\n";
       }
    }
}
