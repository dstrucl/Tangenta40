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
using System.Threading.Tasks;

namespace SQLTableControl
{
    public static class TableNames
    {
        public static List<NamesAndAbbreviation> list = new List<NamesAndAbbreviation>();

        internal static void Add(string TableName, string TableName_Abbreviation)
        {
           if (exist(TableName,TableName_Abbreviation))
           {
               return;
           }
           else
           {
               NamesAndAbbreviation nab = new NamesAndAbbreviation();
               nab.Name = TableName;
               nab.Abbreviation = TableName_Abbreviation;
               list.Add(nab);
           }
        }

        private static bool exist(string TableName, string TableName_Abbreviation)
        {
            foreach (NamesAndAbbreviation nab in list)
            {
                if (nab.Name.Equals(TableName))
                {
                    LogFile.Error.Show("TableName " + TableName + " allready exists!");
                    return true;
                }
                if (nab.Abbreviation.Equals(TableName_Abbreviation))
                {
                    LogFile.Error.Show("TableName abbreviation " + TableName_Abbreviation + " allready exists!");
                    return true;
                }
            }
            return false;
        }
    }

    public class NamesAndAbbreviation
    {
        public string Name = null;
        public string Abbreviation = null;
    }

}
