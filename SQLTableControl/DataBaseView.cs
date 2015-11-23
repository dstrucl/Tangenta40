using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLTableControl
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
