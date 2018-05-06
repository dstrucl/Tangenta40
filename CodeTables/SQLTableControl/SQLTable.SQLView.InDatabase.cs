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
using DBConnectionControl40;
using System.Data;
using System.Windows.Forms;

namespace CodeTables

{
    partial class SQLTable
    {
        internal JoinList_for_SQLView_InDataBase jList = new JoinList_for_SQLView_InDataBase();
        //private string alias_table_name = null;

        internal StringBuilder SQLCreateView_InDataBase(List<SQLTable> lTable)
        {
            StringBuilder SQL_View = new StringBuilder("");
            try
            {
                if (this.m_Fkey.Count > 0)
                {
                    jListClear();

                    if (this.m_Table_View == null)
                    {
                        m_Table_View = new Table_View();
                    }
                    m_Table_View.View_Name = TableName + const_DataBaseViewSuffix;

                    SQL_View.Append("\n\nCREATE VIEW " + ViewName + " AS ");

                    SQL_View.Append("\nSELECT ");

                    SQL_View.Append("\n  " + TableName + ".ID");

                    SQLTable xtbl = new SQLTable(this);
                    xtbl.CreateTableTree(lTable);

                    string alias_table_name = this.TableName;

                    foreach (Column col in xtbl.Column)
                    {
                        if (!col.IsIdentity)
                        {
                            if (col.fKey != null)
                            {
                                if (col.fKey.fTable != null)
                                {

                                    if (col.fKey.refInListOfTables != null)
                                    {
                                        col.fKey.refInListOfTables.ReferencesToThisTable.Add(this, col.Name);
                                    }

                                    col.fKey.fTable.BasicColumns(ref SQL_View, ref m_Table_View, alias_table_name);
                                    if (!m_Table_View.defined)
                                    {
                                        string Column_Name_In_View = col.ownerTable.TableName + VIEW_TableName2ColumnName_SEPARATOR + col.Name;
                                        Table_View.ColumnNames x_Table_View_ColumnNames = new Table_View.ColumnNames();
                                        x_Table_View_ColumnNames.Name = Column_Name_In_View;
                                        x_Table_View_ColumnNames.Name_in_language = col.Name_in_language;
                                        this.m_Table_View.View_ColumnNames_List.Add(x_Table_View_ColumnNames);
                                    }
                                }
                            }
                            else
                            {
                                string Column_Name_In_View = col.ownerTable.TableName + VIEW_TableName2ColumnName_SEPARATOR + col.Name;
                                SQL_View.Append(",\n  " + col.ownerTable.TableName + "." + col.Name + " AS " + Column_Name_In_View);
                                if (!m_Table_View.defined)
                                {
                                    Table_View.ColumnNames x_Table_View_ColumnNames = new Table_View.ColumnNames();
                                    x_Table_View_ColumnNames.Name = Column_Name_In_View;
                                    x_Table_View_ColumnNames.Name_in_language = col.Name_in_language;
                                    this.m_Table_View.View_ColumnNames_List.Add(x_Table_View_ColumnNames);
                                }
                            }
                        }
                    }
                    m_Table_View.defined = true;

                    SQL_View.Append("\nFROM " + TableName);

                    foreach (Column col in xtbl.Column)
                    {
                        if (!col.IsIdentity)
                        {
                            if (col.fKey != null)
                            {
                                if (col.fKey.fTable != null)
                                {
                                    col.fKey.fTable.GetJoins(col.nulltype, this, alias_table_name, alias_table_name);
                                }
                            }
                        }
                    }
                    CreateJoins(ref SQL_View, false);
                }
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:SQLTable:SQLCreateView_InDataBase:Exception=" + Ex.Message);
            }
            return SQL_View;
        }


        private void jListClear()
        {
            foreach (Column col in Column)
            {
                if (!col.IsIdentity)
                {
                    if (col.fKey != null)
                    {
                        if (col.fKey.refInListOfTables != null)
                        {
                            col.fKey.refInListOfTables.jListClear();
                        }
                    }
                }
            }
            this.jList.items.Clear();
        }

        private void CreateJoins(ref StringBuilder SQL_View, bool xbForceLeftJoin )
        {
                foreach (Join_for_SQLView_InDataBase join in jList.items)
                {
                    string s_join = null;

                    if (xbForceLeftJoin)
                    {
                        s_join = "\r\nLEFT JOIN ";
                    }
                    else
                    {
                        if (join.nulltype == CodeTables.Column.nullTYPE.NOT_NULL)
                        {
                            s_join = "\r\nINNER JOIN ";
                        }
                        else
                        {
                            s_join = "\r\nLEFT JOIN ";
                            xbForceLeftJoin = true;
                        }
                    }

                    SQL_View.Append(s_join + join.TableName + " " + join.AliasTableName + " ON " + join.Param_ID1 + " = " + join.Param_ID2);
                    SubJoin_for_SQLView_InDataBase pSubJ = join.pSubJoin;
                    while (pSubJ != null)
                    {
                        SQL_View.Append("\n   AND "  + join.Param_ID1 + " = " + join.Param_ID2);
                        pSubJ = pSubJ.pSubJoin;
                    }
                    if (join.tbl != null)
                    {
                        join.tbl.CreateJoins(ref SQL_View, xbForceLeftJoin);
                    }
                }

        }
        private void GetJoins(Column.nullTYPE nulltype, SQLTable pParentTable, string PreAliasTableName, string pParentTable_alias_table_name)
        {
            string alias_table_name = PreAliasTableName + SQLTable.VIEW_TableName_SEPARATOR + this.TableName_Abbreviation;
            Join_for_SQLView_InDataBase join = new Join_for_SQLView_InDataBase(null, TableName,TableName_Abbreviation, alias_table_name, PreAliasTableName + "." + this.TableName + "_ID", alias_table_name + ".ID", nulltype);

            join.tbl = this;
            pParentTable.jList.items.Add(join);
            
            foreach (Column col in Column)
            {
                if (!col.IsIdentity)
                {
                    if (col.fKey != null)
                    {
                        if (col.fKey.fTable != null)
                        {
                            col.fKey.fTable.GetJoins(col.nulltype, this, alias_table_name, PreAliasTableName);
                        }
                    }
                }
            }
        }


        private void BasicColumns(ref StringBuilder SQL_View, ref Table_View parent_Table_View,string AliasTableName)
        {
            if (this.m_Table_View == null)
            {
                this.m_Table_View = new Table_View();
            }
            string alias_table_name = AliasTableName + SQLTable.VIEW_TableName_SEPARATOR + this.TableName_Abbreviation;
            foreach (Column col in Column)
            {
                if (col.IsIdentity)
                {
                    string Column_Name_In_View = alias_table_name + SQLTable.VIEW_TableName2ColumnName_SEPARATOR + col.Name;
                    SQL_View.Append(",\n" + alias_table_name + "." + col.Name + " AS " + Column_Name_In_View);
                    if (!this.m_Table_View.defined)
                    {
                        Table_View.ColumnNames x_Table_View_ColumnNames = new Table_View.ColumnNames();
                        x_Table_View_ColumnNames.Name = Column_Name_In_View;
                        x_Table_View_ColumnNames.Name_in_language = col.Name_in_language;
                        this.m_Table_View.View_ColumnNames_List.Add(x_Table_View_ColumnNames);
                    }
                }
                else
                {
                    if (col.fKey != null)
                    {
                        if (col.fKey.fTable != null)
                        {
                            col.fKey.fTable.BasicColumns(ref SQL_View, ref m_Table_View, alias_table_name);
                            if (!m_Table_View.defined)
                            {
                                string Column_Name_In_View = alias_table_name + SQLTable.VIEW_TableName2ColumnName_SEPARATOR + col.Name;
                                Table_View.ColumnNames x_Table_View_ColumnNames = new Table_View.ColumnNames();
                                x_Table_View_ColumnNames.Name = Column_Name_In_View;
                                x_Table_View_ColumnNames.Name_in_language = col.Name_in_language;
                                this.m_Table_View.View_ColumnNames_List.Add(x_Table_View_ColumnNames);
                            }
                        }
                    }
                    else
                    {
                        string Column_Name_In_View = alias_table_name + SQLTable.VIEW_TableName2ColumnName_SEPARATOR + col.Name;
                        SQL_View.Append(",\n" + alias_table_name + "." + col.Name + " AS " + Column_Name_In_View);
                        if (!this.m_Table_View.defined)
                        {
                            Table_View.ColumnNames x_Table_View_ColumnNames = new Table_View.ColumnNames();
                            x_Table_View_ColumnNames.Name = Column_Name_In_View;
                            x_Table_View_ColumnNames.Name_in_language = col.Name_in_language;
                            this.m_Table_View.View_ColumnNames_List.Add(x_Table_View_ColumnNames);
                        }
                    }
                }
            }
            this.m_Table_View.defined = true;
            parent_Table_View.View_List.Add(this.m_Table_View);
        }
    }
}