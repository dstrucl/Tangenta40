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
using System.Windows.Controls;
using System.Data;
using SQLTableControl;

namespace uwpf_GUI
{
    public static class DataGridView_Headers
    {
        public static void SetVIEW_DataGridViewImageColumns_Headers(DataGrid dgvx, SQLTableControl.DBTableControl xdbTables,SQLTableControl.SQLTable tbl)
        {
            foreach (DataGridColumn col in dgvx.Columns)
            {
                Column c = FindColumn(tbl,(string)col.Header);
                if (c != null)
                {
                    col.Header = c.Name_in_language.s;
                }
                else
                {
                    string sSeparator = SQLTable.VIEW_TableName2ColumnName_SEPARATOR;
                    int iSeparator_Length = sSeparator.Length;
                    string colName = (string)col.Header;
                    int iTableNameEnd = colName.IndexOf(sSeparator);
                    if (iTableNameEnd > 0)
                    {
                        string sTableName_Abbreviation = colName.Substring(0, iTableNameEnd);
                        string sColName = colName.Substring(iTableNameEnd + iSeparator_Length, colName.Length - iTableNameEnd - iSeparator_Length);
                        iSeparator_Length = SQLTable.VIEW_TableName_SEPARATOR.Length;
                        iTableNameEnd = sTableName_Abbreviation.LastIndexOf(SQLTable.VIEW_TableName_SEPARATOR);
                        if (iTableNameEnd > 0)
                        {
                            sTableName_Abbreviation = sTableName_Abbreviation.Substring(iTableNameEnd + iSeparator_Length, sTableName_Abbreviation.Length - iTableNameEnd - iSeparator_Length);
                        }
                        SQLTable xtbl = xdbTables.GetTable_from_TableName_Abbreviation(sTableName_Abbreviation);
                        if (xtbl != null)
                        {
                            Column cc = FindColumn(xtbl,sColName);
                            if (cc != null)
                            {
                                col.Header = cc.Name_in_language.s;
                            }
                        }
                    }
                }
            }
        }

        private static Column FindColumn(SQLTableControl.SQLTable tbl,string column_name)
        {
            foreach (Column col in tbl.Column)
            {
                if (col.Name.Equals(column_name))
                {
                    return col;
                }
            }
            return null;

        }
    }
}
