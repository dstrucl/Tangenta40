#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LanguageControl;
using DBConnectionControl40;
using System.Windows.Forms;
using System.Data;
using LogFile;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using DBTypes;

namespace CodeTables
{
    [ToolboxBitmap("E:\\ManualReader\\ctlogina\\CodeTables\\Resources\\CodeTables.ico")]
    public partial class DBTableControl : Component
    {
        public xml m_xml;

        public DBConnection m_con;

        public SQLTable.delegate_GetInputControlRandomData m_dControlRandomData;
        public SQLTable.delegate_CheckRandomParamSettings m_dCheckRandomParamSettings;

        DataTable SQLite_tables = null;
        DataTable SQLite_columns_table = null;

        public List<SQLTable> items = new List<SQLTable>();

        public List<DataBaseView> SQL_DataBase_VIEW_List = new List<DataBaseView>();

        public enum enumDataBaseCheckResult { OK, NO_DATABASE_CONNECTION, TABLE_MISSING, COLUMN_MISSING, FOREIGN_KEY_MISSING, PRIMARY_KEY_MISSING, CONNECTION_FAILED };
        public StringBuilder m_strSQLUseDatabase = null;
        StringBuilder m_strSQLCheckTables = new StringBuilder();
        public Form m_ParentForm;

        public void Init(DBConnection.eDBType eDBType)
        {
            m_con.DBType = eDBType;
            m_strSQLUseDatabase = new StringBuilder("\nUSE " + this.m_con.DataBase + "\n SET DATEFORMAT dmy\n\n");

            StringBuilder sbAll = SQLcmd_CreateAllTables(this.m_con); // this fuction creates all fkey links !
            string sAll = sbAll.ToString();


            SQLcmd_DropAllTables(this.m_con);
        }


        public void SetVIEW_DataGridViewImageColumns_Headers(DataGridView dgvx_Item, SQLTable m_tbl,string[] table_names)
        {
            if (m_tbl!=null)
            {
                m_tbl.SetVIEW_DataGridViewImageColumns_Headers(dgvx_Item, this);
            }
            foreach (string stbl in table_names)
            {
                foreach (SQLTable tbl in items)
                {
                    if (stbl.ToLower().Equals(tbl.TableName.ToLower()))
                    {
                        foreach (DataGridViewColumn cl in dgvx_Item.Columns)
                        {
                            foreach (CodeTables.Column col in tbl.Column)
                            {
                                if (col.Name.ToLower().Equals(cl.Name.ToLower()))
                                {
                                    cl.HeaderText = col.Name_in_language.s;
                                }
                            }
                        }
                    }
                }
            }
        }

        public SQLTable GetTable(Type typeOrefTable)
        {
            int iTable;
            int iTableCount;
            iTableCount = items.Count;

            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                if (items[iTable].objTable.GetType() == typeOrefTable)
                {
                    return items[iTable];
                }
            }
            return null;
        }

        //public SQLTable Add(Object oTable, Column.Flags xFlags, ltext lngtblname)
        //{
        //    SQLTable myTable = new SQLTable(oTable, xFlags, lngtblname);
        //    items.Add(myTable);
        //    return myTable;
        //}

        public StringBuilder SQLcmd_CreateAllTables(DBConnection xcon)
        {
            StringBuilder strSqlAll = new StringBuilder("");
            StringBuilder strSqlTables = new StringBuilder("");
            //strSql.Append(Create_Database_Table(SQL_Table tbl_eva_User, m_eva_UserSQL_Table(());) new eva_User           ());

            //strSql.Append(Create_Database_Table(col_evl_CmdTYPE, m_evl_CmdTYPE)),
            //strSql.Append(Create_Database_Table(col_evl_History, m_evl_History));
            int iTable;
            int iTableCount;
            iTableCount = items.Count;

            List<string> UniqueConstraintNameList = new List<string>();
            string sql_DBm = "";

            for (iTable = 0; iTable < iTableCount; iTable++)
            {
                SQLTable tbl = items[iTable];
                if (DBtypesFunc.Is_DBm_Type(tbl.objTable)) 
                {
                    continue; // ignore DBm_*  Tables
                }
                else
                {
                    tbl.sql_CreateTable = tbl.SQLcmd_CreateTable(this, UniqueConstraintNameList, ref sql_DBm, null);
                    strSqlTables.Append(tbl.sql_CreateTable);
                }
            }
            strSqlAll.Append(sql_DBm);
            strSqlAll.Append(strSqlTables);

            StringBuilder strTableAlterTable = new StringBuilder("");

            //iTableCount = items.Count;

            //iTable = 0;  
            //while (iTable <iTableCount)
            //{
            //    SQLTable tbl = items[iTable];
            //    if (DBtypesFunc.Is_DBm_Type(tbl.objTable)) 
            //    {
            //        items.RemoveAt(iTable);
            //    }
            //    else
            //    {
            //        iTable++;
            //    }
            //    iTableCount = items.Count;
            //}


            for (iTable = 0; iTable < iTableCount; iTable++)
            {
                switch (m_con.DBType)
                {
                    case DBConnection.eDBType.MYSQL:
                        strTableAlterTable.Append(items[iTable].SQLcmdMySQL_AlterTableAddConstraintForeign()).ToString();
                    break;

                    case DBConnection.eDBType.MSSQL:
                        strTableAlterTable.Append(items[iTable].SQLcmdMSSQL_AlterTableAddConstraintForeign());
                    break;

                    case DBConnection.eDBType.SQLITE:
                    //strTable = new StringBuilder(items[iTable].SQLcmd_AlterTableAddConstraintForeign());
                    break;

                    default:
                    break;

                }
            }
            strSqlAll.Append(strTableAlterTable);

            // Also create views! in one step
            SQL_DataBase_VIEW_List.Clear();
            for (iTable = 0; iTable < iTableCount; iTable++)
            {
                StringBuilder SQLCreateView_InDataBase = items[iTable].SQLCreateView_InDataBase(items);
                if (SQLCreateView_InDataBase.Length > 0)
                {
                    items[iTable].sql_CreateView = SQLCreateView_InDataBase.ToString();
                    DataBaseView xDataBaseView = new DataBaseView(items[iTable].ViewName, SQLCreateView_InDataBase.ToString());
                    SQL_DataBase_VIEW_List.Add(xDataBaseView);
                }
            }


            return strSqlAll;
        }

        public StringBuilder SQLcmd_DropAll_Views(DBConnection xcon)
        {
            StringBuilder strSqlAll = new StringBuilder("USE [" + xcon.DataBase + @"]
                SET ANSI_NULLS ON;

                SET QUOTED_IDENTIFIER ON;

                SET ANSI_PADDING ON;
                ");
          //  int iTable;
            int iTableCount;
            iTableCount = items.Count;

            foreach (DataBaseView dbv in SQL_DataBase_VIEW_List)
            {

                StringBuilder strTable = null;
                switch (xcon.DBType)
                {
                    case DBConnection.eDBType.MSSQL:
                        strTable = new StringBuilder(dbv.SQLcmd_DropView());
                        break;
                    case DBConnection.eDBType.MYSQL:
                        strTable = new StringBuilder(dbv.MySQLcmd_DropView());
                        break;
                    case DBConnection.eDBType.SQLITE:
                        strTable = new StringBuilder(dbv.SQLitecmd_DropView());
                        break;
                }
                if (strTable != null)
                {
                    strSqlAll.Append(strTable);
                }
                else
                {
                    LogFile.Error.Show("ERROR:CodeTables:DBTableControl:SQLcmd_DropAllTables:Not valid xcon.DBType : " + xcon.DBType.ToString());
                }
                strSqlAll.Append(strTable);
            }
            return strSqlAll;
        }


        public StringBuilder SQLcmd_DropAllTables(DBConnection xcon)
        {
            StringBuilder strSqlAll = new StringBuilder("USE [" + xcon.DataBase + @"]
                SET ANSI_NULLS ON;

                SET QUOTED_IDENTIFIER ON;

                SET ANSI_PADDING ON;
                ");
            int iTable;
            int iTableCount;
            iTableCount = items.Count;

            foreach (DataBaseView dbv in SQL_DataBase_VIEW_List)
            {
                StringBuilder strTable = null;
                switch (xcon.DBType)
                {
                    case DBConnection.eDBType.MSSQL:
                        strTable = new StringBuilder(dbv.SQLcmd_DropView());
                        break;
                    case DBConnection.eDBType.MYSQL:
                        strTable = new StringBuilder(dbv.MySQLcmd_DropView());
                        break;
                    case DBConnection.eDBType.SQLITE:
                        strTable = new StringBuilder(dbv.SQLitecmd_DropView());
                        break;
                }
                if (strTable != null)
                {
                    strSqlAll.Append(strTable);
                }
                else
                {
                    LogFile.Error.Show("ERROR:CodeTables:DBTableControl:SQLcmd_DropAllTables:Not valid xcon.DBType : " + xcon.DBType.ToString());
                }
            }
            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                if (DBtypesFunc.Is_DBm_Type(items[iTable]))
                {
                    continue;
                }
                else
                {
                    StringBuilder strTable = new StringBuilder(items[iTable].SQLcmd_AlterTableDropConstraintForeign());
                    strSqlAll.Append(strTable);
                }
            }

            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                if (DBtypesFunc.Is_DBm_Type(items[iTable]))
                {
                    continue;
                }
                else
                {
                    StringBuilder strTable = new StringBuilder(items[iTable].SQLcmd_DropTable());
                    strSqlAll.Append(strTable);
                }
            }
            return strSqlAll;
        }

        public StringBuilder MySQLcmd_DropAllTables(DBConnection xcon)
        {
            StringBuilder strSqlAll = new StringBuilder("USE [" + xcon.DataBase + @"]
                SET ANSI_NULLS ON;

                SET QUOTED_IDENTIFIER ON;

                SET ANSI_PADDING ON;
                ");
            int iTable;
            int iTableCount;
            iTableCount = items.Count;

            foreach (DataBaseView dbv in SQL_DataBase_VIEW_List)
            {
                StringBuilder strTable = new StringBuilder(dbv.MySQLcmd_DropView());
                strSqlAll.Append(strTable);
            }
            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                StringBuilder strTable = new StringBuilder(items[iTable].MySQLcmd_AlterTableDropConstraintForeign());
                strSqlAll.Append(strTable);
            }

            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                StringBuilder strTable = new StringBuilder(items[iTable].MySQLcmd_DropTable());
                strSqlAll.Append(strTable);
            }
            return strSqlAll;
        }

        public StringBuilder SQLitecmd_DropAllTables(DBConnection xcon)
        {
            StringBuilder strSqlAll = new StringBuilder("");
            int iTable;
            int iTableCount;
            iTableCount = items.Count;

            foreach (DataBaseView dbv in SQL_DataBase_VIEW_List)
            {
                StringBuilder strTable = new StringBuilder(dbv.SQLitecmd_DropView());
                strSqlAll.Append(strTable);
            }
            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                StringBuilder strTable = new StringBuilder(items[iTable].SQLitecmd_AlterTableDropConstraintForeign());
                strSqlAll.Append(strTable);
            }

            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                StringBuilder strTable = new StringBuilder(items[iTable].SQLitecmd_DropTable());
                strSqlAll.Append(strTable);
            }
            return strSqlAll;
        }

        public bool IsMyTable(out SQLTable OutTbl,Type type)
        {
            foreach (SQLTable tbl in items)
            {
                if (type == tbl.objTable.GetType())
                {
                    OutTbl = tbl;
                    return true;
                }
            }
            OutTbl = null;
            return false;
        }

        public int GetTableIndex(Type typeOrefTable)
        {
            int iTable;
            int iTableCount;
            iTableCount = items.Count;

            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                if (items[iTable].objTable.GetType() == typeOrefTable)
                {
                    return iTable;
                }
            }
            return -1;
        }

        public bool DbTableExists(SQLTable tbl, ref string  csError)
        {
            //string strTableNameAndSchema = " SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '"+tbl.TableName+"'";
            //string strCheckTable =   m_strSQLUseDatabase + String.Format(
            //      "IF OBJECT_ID('{0}', 'U') IS NOT NULL SELECT 'true' ELSE SELECT 'false' ",strTableNameAndSchema
            //      );
            string strCheckTable = null;
            switch (m_con.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    strCheckTable = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '" + this.m_con.DataBase+"' AND table_name = '" + tbl.TableName + "';";
                    break;
                case DBConnection.eDBType.MSSQL:
                    strCheckTable = "\nUSE " + this.m_con.DataBase + "\n IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='" + tbl.TableName + "') SELECT 1 AS res ELSE SELECT 0 AS res";
                    break;
                case DBConnection.eDBType.SQLITE:
                    strCheckTable = "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = '" + tbl.TableName + "'";
                    break;
            }
            StringBuilder strB_CheckTable = new StringBuilder(strCheckTable);
            int i = 0;
            Object ObjRet = new Object();
            if (this.m_con.ExecuteQuerySQL(strB_CheckTable, null, ref i, ref ObjRet, ref csError, tbl.TableName))
            {
                if (ObjRet.GetType() == typeof(int))
                {
                    i =(int)ObjRet;
                    if (i == 1)
                    {
                        return true;
                    }
                    else
                    {
                        csError = lngConn.s_Error.s + ": " + lngConn.sTableIsMissing.s + ":" + tbl.TableName;
                        return false;
                    }
                }
                else if (ObjRet.GetType() == typeof(long))
                {
                    long l;
                    l = (long)ObjRet;
                    if (l == 1)
                    {
                        return true;
                    }
                    else
                    {
                        if (tbl.TableName.Equals("RemoteUpdate"))
                        {
                            List<string> UniqueConstraintNameList = new List<string>();
                            string sql_DBm = "";
                            string sql_create = tbl.SQLcmd_CreateTable(this, UniqueConstraintNameList, ref sql_DBm,null);
                            string sql_create_All = sql_DBm + sql_create;
                            object oResult=null;
                            if (m_con.ExecuteNonQuerySQL(sql_create_All, null, ref oResult, ref csError))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }
                        else
                        {
                            csError = lngConn.s_Error.s + ": " + lngConn.sTableIsMissing.s + ":" + tbl.TableName;
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        public enumDataBaseCheckResult DataBaseCheck(ref string csError)
        {
                    
            enumDataBaseCheckResult eRes;
            eRes = enumDataBaseCheckResult.OK;
            if (DataBaseExists(ref csError))
            {
                foreach (SQLTable tbl in items)
                {
                    if (DBtypesFunc.Is_DBm_Type(tbl.objTable))
                    {
                        string tbl_type = tbl.objTable.GetType().ToString();
                        if (tbl_type.Contains("." + tbl.TableName))
                        {
                            continue;
                        }
                    }
                    if (DbTableExists(tbl, ref csError))
                    {
                        if (ColumnExists(tbl, ref csError))
                        {

                        }
                        else
                        {
                            eRes = enumDataBaseCheckResult.COLUMN_MISSING;
                            return eRes;
                        }
                    }
                    else
                    {
                        eRes = enumDataBaseCheckResult.TABLE_MISSING;
                        return eRes;
                    }
                }
                return eRes;
            }
            else
            {
                return enumDataBaseCheckResult.NO_DATABASE_CONNECTION;
            }
        }

        private bool DataBaseExists(ref string csError)
        {
            if (m_con.Connect_ToServerOnly(ref csError))
            {
                m_con.Disconnect();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool FindColumnInTable(SQLTable tbl, DataTable columns_table, string column_name)
        {
            foreach (DataRow drow in columns_table.Rows)
            {
                string tbl_name = drow["TABLE_NAME"].ToString();
                if (tbl_name.Equals(tbl.TableName))
                {
                    // this column is of this table:
                    if (column_name.Equals(drow["COLUMN_NAME"].ToString()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ColumnExists(SQLTable tbl, ref string csError)
        {
            bool bRes = true;
            string csNewLine = "";
            string sqlColumnExist = null;
            switch (m_con.DBType)
            {
                case DBConnection.eDBType.MSSQL:
                    sqlColumnExist = @"USE " + m_con.DataBase + @"
                                     SELECT *
                                     FROM INFORMATION_SCHEMA.COLUMNS
                                     WHERE TABLE_NAME = '" + tbl.TableName + @"'
                                     ORDER BY ORDINAL_POSITION;";
                    break;
                case DBConnection.eDBType.MYSQL:
                    sqlColumnExist = @"SELECT * FROM information_schema.COLUMNS
		                            WHERE table_name='" + tbl.TableName + @"'
		                            and table_schema='" + m_con.DataBase + "';";
                    break;

                case DBConnection.eDBType.SQLITE:
                    {
                        if (m_con.SQLiteTableInfo(ref SQLite_tables, ref SQLite_columns_table, ref csError))
                        {

                            int i;
                            int iCount = tbl.Column.Count();
                            for (i = 0; i < iCount; i++)
                            {
                                string column_name = tbl.Column[i].Name;
                                if (!FindColumnInTable(tbl, SQLite_columns_table, column_name))
                                {
                                    csError += csNewLine + "Column with name:\"" + column_name + "\" does not exist in table:\"" + tbl.TableName + "\"";
                                    csNewLine = "\r\n";
                                    bRes = false;
                                }
                            }
                            return bRes;
                        }
                        else
                        {
                            LogFile.Error.Show("Error executing m_con.SQLiteTableInfo(ref tables,ref columns, ref csError)=" + csError);
                            return false;
                        }
                    }
            }

            DataTable dtColumnTable = new DataTable();

            if (m_con.ReadDataTable(ref dtColumnTable,sqlColumnExist,ref csError))
            {
                int i;
                int iCount = tbl.Column.Count();
                for (i = 0; i < iCount; i++)
                {
                    string column_name = tbl.Column[i].Name;
                    if (!FindColumnInTable(tbl, dtColumnTable, column_name))
                    {
                        csError += csNewLine + "Column with name:\"" + column_name + "\" does not exist in table:\"" + tbl.TableName + "\"";
                        csNewLine = "\r\n";
                        bRes = false;
                    }
                }
                return bRes;
            }
            else
            {
                return false;
            }
        }


        private void GetValue_FromSourceText(SourceText sTxt, string s2, ref string Value)
        {
            string[] token = s2.Split('=');
            char[] SkipSpaces = { ' ', '\t' };
            if (token.Length >= 2)
            {
                string sCommand = token[0];
                sCommand.TrimStart(SkipSpaces);
                sCommand.TrimEnd(SkipSpaces);
                if (sCommand.Equals(ASet.KEYWORD_LINES))
                {
                    string sNumOfLines = token[1];
                    sNumOfLines.TrimStart(SkipSpaces);
                    sNumOfLines.TrimEnd(SkipSpaces);
                    int NumOfLines = Convert.ToInt32(sNumOfLines);
                    int i;
                    for (i = 0; i < NumOfLines; i++)
                    {
                        sTxt.ReadLine();
                        Value += sTxt.sLine;
                    }
                }
                else
                {
                    Value = s2;
                }
            }
            else
            {
                Value = s2;
            }
        }

        public bool SQLcmd_ImportFile(Form mMainForm, string FileName, ref List<SQLTable> lTable)
        {

            List<SQL_Parameter> lsqlPar = new List<SQL_Parameter>();

            SQLTable sqlTbl = null;
            SQLTable refsqlTbl = null;
            int iTableNameStart;
            int iTableNameEnd;
            Globals.MainWindow = mMainForm;
            StringBuilder sbSQLInsert = new StringBuilder(m_strSQLUseDatabase.ToString());
            string sPrevVar = "";
            SourceText Source_Txt = new SourceText(FileName);

            char[] trimChars = new char[] { ' ', '\t' };
            if (Source_Txt.OpenText())
            {
                while (Source_Txt.ReadLine())
                {
                    if (sqlTbl != null)
                    {
                        iTableNameStart = Source_Txt.sLine.IndexOf('<');
                        if (iTableNameStart != -1)
                        {
                            iTableNameStart++;
                            if (Source_Txt.sLine[iTableNameStart].Equals('/'))
                            {
                                iTableNameStart++;
                                iTableNameEnd = Source_Txt.sLine.IndexOf('>');
                                string sTblName = Source_Txt.sLine.Substring(iTableNameStart, iTableNameEnd - iTableNameStart);
                                if (sqlTbl.TableName.Equals(sTblName))
                                {
                                    string sVarID = Globals.sVar + "_" + sqlTbl.TableName;
                                    sPrevVar = Globals.sVar;
                                    string ErrorMsg = "";
                                    Int64 newID = -1;
                                    if (sqlTbl.SQLcmd_InsertInto(m_con,lTable, ref ErrorMsg, m_strSQLUseDatabase, ref newID))
                                    {
                                        sqlTbl = null;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    Source_Txt.ShowParseError(lngRPM.s_Illegal_end_table_XML_command_expected.s + ": </" + sqlTbl.TableName + ">\n", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Source_Txt.CloseText();
                                }
                            }
                            else
                            {
                                Source_Txt.ShowParseError(lngRPM.s_Illegal_end_table_XML_command_expected.s + ": </" + sqlTbl.TableName + ">\n", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Source_Txt.CloseText();
                            }
                        }
                        else
                        {
                            string[] column = Source_Txt.sLine.Split(',');
                            int iCount = column.Length;
                            string s1;
                            string s2 = "";
                            if (iCount >= 2)
                            {
                                s1 = column[0];
                                int i;
                                for (i = 1; i < iCount; i++)
                                {
                                    s2 += column[i];
                                }
                                string Value = "";
                                GetValue_FromSourceText(Source_Txt, s2, ref Value);
                                if (sqlTbl.SetColumnValue(s1, Value))
                                {
                                    continue;
                                }
                                else
                                {
                                    Source_Txt.CloseText();
                                    return false;
                                }
                            }
                            else
                            {
                                Source_Txt.ShowParseError(lngRPM.s_File.s + ":" + FileName + "\n" + lngRPM.s_Comma_is_missing_to_separate_cells_column_name_from_cell_value_in_line.s + ":" + Source_Txt.iLine.ToString(), lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Source_Txt.CloseText();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        iTableNameStart = Source_Txt.sLine.IndexOf('<');
                        iTableNameEnd = Source_Txt.sLine.IndexOf('>');
                        if ((iTableNameStart != -1) && (iTableNameEnd != -1) && (iTableNameEnd > iTableNameStart))
                        {
                            string sTableName = Source_Txt.sLine.Substring(iTableNameStart + 1, iTableNameEnd - iTableNameStart - 1);
                            sTableName = sTableName.TrimStart(trimChars);
                            sTableName = sTableName.TrimEnd(trimChars);
                            if (Globals.FindTable(out refsqlTbl, sTableName, items))
                            {
                                sqlTbl = new SQLTable(refsqlTbl);
                                sqlTbl.CreateTableTree(lTable);
                                continue;
                            }
                            else
                            {
                                Source_Txt.ShowParseError(lngRPM.s_TableNameIsExpectedToBeBeforeDataLines.s, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }

                        }
                        else
                        {
                            Source_Txt.ShowParseError(lngRPM.s_TableNameIsExpectedToBeBeforeDataLines.s, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                }
                Source_Txt.CloseText();

                //  Structures are filled now create SQL statements

                return true;


            }
            else
            {
                return false;
            }
        }

        public bool CreateDatabaseTables(bool bAsk)
        {
            if (bAsk)
            { 
                DialogResult dRes = MessageBox.Show(m_ParentForm, lngRPM.s_CreateTablesInDataBaseQuestion.s + this.m_con.DataSource + " ?", lngRPM.s_Warning.s, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((dRes == DialogResult.No) || (dRes == DialogResult.Cancel))
                {
                    return false;
                }
            }
            CreateTables_WindowsForm_Thread xCreateTables_WindowsForm_Thread = new CreateTables_WindowsForm_Thread();
            int Tables_Count = items.Count();
            xCreateTables_WindowsForm_Thread.Start(Tables_Count);

            String csErrorMsg = "";

            bool bRes;

            StringBuilder m_strSQLCreate = SQLcmd_CreateAllTables(m_con);

            switch (m_con.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    {
                        string sql = "USE `" + m_con.DataBase + "`;" + m_strSQLCreate.ToString();
                        bRes = this.m_con.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref csErrorMsg);
                    }
                    break;
                case DBConnection.eDBType.MSSQL:
                    {
                    string sql =@"USE [" + m_con.DataBase + @"]
                                  SET ANSI_NULLS ON;

                                  SET QUOTED_IDENTIFIER ON;

                                  SET ANSI_PADDING ON;
                                  " + m_strSQLCreate.ToString();
                      Object oResult = null;
                      bRes= this.m_con.ExecuteNonQuerySQL(sql, null,ref oResult, ref csErrorMsg);
                    }
                    break;

                case DBConnection.eDBType.SQLITE:
                    bRes = this.m_con.ExecuteNonQuerySQL_NoMultiTrans(m_strSQLCreate.ToString(), null, ref csErrorMsg);
                    break;
                default:
                    LogFile.Error.Show("Error m_con.DBType in function:public bool CreateDatabaseTables()");
                    bRes = false;
                    break;

            }
            if (bRes)
            {
                foreach (DataBaseView dbv in SQL_DataBase_VIEW_List)
                {
                    if (this.m_con.ExecuteNonQuerySQL_NoMultiTrans(dbv.SQLCommand, null, ref csErrorMsg))
                    {
                    }
                    else
                    {
                        xCreateTables_WindowsForm_Thread.End();
                        Error.Show(m_ParentForm, lngRPM.s_ErrorView.s + " " + dbv.ViewName + "\n\nException = " + csErrorMsg, lngRPM.s_Error.s);
                        return false;
                    }
                }

                xCreateTables_WindowsForm_Thread.End();
                //MessageBox.Show(m_ParentForm, lngRPM.s_AllTablesCreatedOK.s, lngRPM.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                xCreateTables_WindowsForm_Thread.End();
                Error.Show(m_ParentForm, lngRPM.s_err_AllTablesCreated.s + "\n\nException = " + csErrorMsg, lngRPM.s_Error.s);
                return false;
            }
        }




        private bool DropAllViewsInSQLiteDataBase(Form pParentForm, ref bool bCancel, ref string serror)
        {
            try
            {

                string sqlAllTables = "SELECT name FROM SQLITE_MASTER WHERE type = 'view' and name <>'sqlite_sequence';";
                DataTable tables = new DataTable();
                List<string> sTableList = new List<string>();
                if (m_con.ReadDataTable(ref tables, sqlAllTables, ref serror))
                {
                    foreach (DataRow row in tables.Rows)
                    {
                        Object obj = row.ItemArray.GetValue(0);
                        if (obj != null)
                        {
                            if (obj.GetType() == typeof(string))
                            {
                                string sTableName = (string)obj;
                                sTableList.Add(sTableName);
                            }
                        }
                    }

                    if (sTableList.Count > 0)
                    {
                        foreach (string sTblName in sTableList)
                        {
                            string s_SQLite_Drop_table = @"DROP View '" + sTblName + "';";
                            object oResult = null;
                            if (!this.m_con.ExecuteNonQuerySQL(s_SQLite_Drop_table, null,ref oResult, ref serror))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        // Empty data base
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("Error executing ReadDataTable=" + serror);
                    return false;
                }
            }
            catch (Exception Ex)
            {
                serror = Ex.Message;
                return false;
            }
        }

         public bool DropAllTablesInSQLiteDataBase(Form pParentForm,ref bool bCancel, ref string serror)
         {
             if (DropAllViewsInSQLiteDataBase(pParentForm, ref bCancel, ref serror))
             {
                 try
                 {

                     string sqlAllTables = "SELECT name FROM SQLITE_MASTER WHERE type = 'table' and name <>'sqlite_sequence';";
                     DataTable tables = new DataTable();
                     List<string> sTableList = new List<string>();
                     if (m_con.ReadDataTable(ref tables, sqlAllTables, ref serror))
                     {
                         foreach (DataRow row in tables.Rows)
                         {
                             Object obj = row.ItemArray.GetValue(0);
                             if (obj != null)
                             {
                                 if (obj.GetType() == typeof(string))
                                 {
                                     string sTableName = (string)obj;
                                     sTableList.Add(sTableName);
                                 }
                             }
                         }

                         if (sTableList.Count > 0)
                         {
                             foreach (string sTblName in sTableList)
                             {
                                 string s_SQLite_Drop_table = @"delete from '" + sTblName + @"';    
                                                               delete from sqlite_sequence where name='" + sTblName + @"';
                                                               DROP TABLE '" + sTblName + "';";
                                 object oResult = null;
                                 if (!this.m_con.ExecuteNonQuerySQL(s_SQLite_Drop_table, null,ref oResult, ref serror))
                                 {
                                     return false;
                                 }
                             }
                             MessageBox.Show(m_ParentForm, lngRPM.s_AllTablesDropedOK.s, lngConn.s_DataBase.s + " SQLite " + lngRPM.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                             return true;
                         }
                         else
                         {
                             // Empty data base
                             MessageBox.Show(m_ParentForm, lngRPM.s_DataBaseHasNoTablesItIsEmpty.s, lngRPM.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                             return true;
                         }
                     }
                     else
                     {
                         LogFile.Error.Show("Error executing ReadDataTable=" + serror);
                         return false;
                     }

                 }
                 catch (Exception Ex)
                 {
                     serror = Ex.Message;
                     return false;
                 }
             }
             else
             {
                 LogFile.Error.Show("Error Views in SQLite are not delited :" + serror);
                 return false;
             }
         }


        public bool DropAllTablesInDataBase(Form pParentForm,ref bool bCancel)
        {

            bCancel = false;
            DialogResult dres = MessageBox.Show(pParentForm, lngConn.s_AreYouShureToDeleteAllTablesAndCreateNewOnes.s, "?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (dres)
            {
                case DialogResult.Cancel:
                    bCancel = true;
                    return false;
                case DialogResult.No:
                    return false;
                case DialogResult.Yes:
                    break;
            }

            string sql_DropAllTables = null;
            switch (m_con.DBType)
            {
                case DBConnection.eDBType.MSSQL:
                sql_DropAllTables = @"
				DECLARE @table_schema varchar(400)
               ,@table_name varchar(400)
               ,@table_type varchar(200)
               ,@constraint_schema varchar(400)
               ,@constraint_name varchar(400)
               ,@cmd nvarchar(400)


                --
                -- drop all the constraints
                --
                DECLARE constraint_cursor CURSOR FOR
                  select CONSTRAINT_SCHEMA, CONSTRAINT_NAME, TABLE_SCHEMA, TABLE_NAME
                    from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                   where TABLE_NAME != 'sysdiagrams'
                    order by CONSTRAINT_TYPE asc -- FOREIGN KEY, then PRIMARY KEY
     

                OPEN constraint_cursor
                FETCH NEXT FROM constraint_cursor INTO @constraint_schema, @constraint_name, @table_schema, @table_name

                WHILE @@FETCH_STATUS = 0 
                BEGIN 
                     SELECT @cmd = 'ALTER TABLE ' + @table_schema + '.' + @table_name + ' DROP CONSTRAINT ' + @constraint_name
                     EXEC sp_executesql @cmd
                     --select @cmd

                     FETCH NEXT FROM constraint_cursor INTO @constraint_schema, @constraint_name, @table_schema, @table_name
                END

                CLOSE constraint_cursor
                DEALLOCATE constraint_cursor

                --
                -- drop all the tables
                --
                DECLARE table_cursor CURSOR FOR
	               select TABLE_SCHEMA, TABLE_NAME,TABLE_TYPE
                                from INFORMATION_SCHEMA.TABLES
                               where TABLE_NAME != 'sysdiagrams'


                OPEN table_cursor
                FETCH NEXT FROM table_cursor INTO @table_schema, @table_name,@table_type

                WHILE @@FETCH_STATUS = 0 
                BEGIN 
				    
					 if (@table_type = 'VIEW')
					 begin
						 SELECT @cmd = 'DROP VIEW ' + @table_schema + '.' + @table_name
						 EXEC sp_executesql @cmd
						 --select @cmd
					 end
					 else
					 begin
						if (@table_type ='BASE TABLE')
						begin
						 SELECT @cmd = 'DROP TABLE ' + @table_schema + '.' + @table_name
						 EXEC sp_executesql @cmd
						 --select @cmd
						end
					end
                    FETCH NEXT FROM table_cursor INTO @table_schema, @table_name,@table_type
                END

                CLOSE table_cursor 
                DEALLOCATE table_cursor;
            ";
                break;

                case DBConnection.eDBType.MYSQL:
                sql_DropAllTables = @"DROP DATABASE " + m_con.DataBase + @";
                                          CREATE DATABASE " + m_con.DataBase + ";";
                    break;


                case DBConnection.eDBType.SQLITE:
                {
                    try
                    {
                        m_con.Disconnect();
                        string serr = null;
                        if (DropAllTablesInSQLiteDataBase(pParentForm,ref bCancel,ref serr))
                        {
                            if (m_con.Connect(ref serr))
                            {
                                m_con.Disconnect();
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show(lngConn.s_CanNotMakeAConnection.s + "\n\nException = " + serr);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show(lngRPM.s_err_AllTablesDroped.s + "\n\nException = " + serr);
                            return false;
                        }
                    }
                    catch (Exception EX)
                    {
                        LogFile.Error.Show(lngRPM.s_err_AllTablesDroped.s + "\n\nException = " + EX.Message);
                        return false;
                    }
                }
            }


            if (sql_DropAllTables!=null)
            {
                string csErrorMsg=null;
                object oResult = null;
                if (this.m_con.ExecuteNonQuerySQL(sql_DropAllTables, null,ref oResult, ref csErrorMsg))
                {
                    MessageBox.Show(m_ParentForm, lngRPM.s_AllTablesDropedOK.s, lngRPM.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    LogFile.Error.Show(lngRPM.s_err_AllTablesDroped.s + "\n\nException = " + csErrorMsg);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show(lngRPM.s_DropAllTablesNotSupported_for_data_base_type.s + m_con.ServerType);
                return false;
            }

        }

        public bool Create_VIEWs()
        {
            string sql = "";
            foreach (DataBaseView xDataBaseView in SQL_DataBase_VIEW_List)
            {
                sql = xDataBaseView.SQLCommand + "\r\n";
                String csErrorMsg = "";
               // object oResult = null;
                if (this.m_con.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref csErrorMsg))
                {
                    continue;
                }
                else
                {
                    LogFile.Error.Show(lngRPM.s_err_CreateViews.s + "\n\nException = " + csErrorMsg);
                    return false;
                }
            }
            return true;
        }
        public bool DropVIEWs(ref string Err)
        {
            Err = null;
            StringBuilder m_strSQLDrop =  this.SQLcmd_DropAll_Views(m_con);

            string sql = m_strSQLDrop.ToString();

            if (this.m_con.DBType== DBConnection.eDBType.SQLITE)
            {
                // filter USE clause !
                int idrop = sql.IndexOf("DROP");
                if (idrop>0)
                {
                    sql = sql.Substring(idrop);
                    sql = sql.Replace("[dbo].", "");
                }
            }

            String csErrorMsg = "";
            object oResult = null;
            if (this.m_con.ExecuteNonQuerySQL(sql, null, ref oResult, ref csErrorMsg))
            {
                return true;
            }
            else
            {
                Err = lngRPM.s_err_AllTablesDroped.s + "\n\nException = " + csErrorMsg;
                LogFile.Error.Show(Err);
                return false;
            }
        }

        public bool DropTables()
        {
            DialogResult dRes = MessageBox.Show(m_ParentForm, lngRPM.s_DropTablesInDataBaseQuestion.s + this.m_con.DataBase + " ?", lngRPM.s_Warning.s, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if ((dRes == DialogResult.No) || (dRes == DialogResult.Cancel))
            {
                return false;
            }
            StringBuilder m_strSQLDrop = SQLcmd_DropAllTables(m_con);

            String csErrorMsg = "";
            object oResult = null;
            if (this.m_con.ExecuteNonQuerySQL(m_strSQLDrop.ToString(), null,ref oResult, ref csErrorMsg))
            {
                MessageBox.Show(m_ParentForm, lngRPM.s_AllTablesDropedOK.s, lngRPM.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show(m_ParentForm, lngRPM.s_err_AllTablesDroped.s + "\n\nException = " + csErrorMsg, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public string GetDatabaseConnectionInfo()
        {
            switch (m_con.DBType)
            {
                case DBConnection.eDBType.MSSQL:
                    return "MSSQL Server=\""+ m_con.DataSource + "\",DataBase=\"" +m_con.DataBase+"\"";
                case DBConnection.eDBType.MYSQL:
                    return "MSSQL Server=\""+ m_con.DataSource + "\",DataBase=\"" +m_con.DataBase+"\"";
                case DBConnection.eDBType.SQLITE:
                    return "SQLite DataBaseFile=\"" + m_con.SQLiteDataBaseFile +"\"";
                default:
                    return "Error wrong m_con.DBType=";
            }
        }
     /*********************************************************/
        public DBTableControl(Form pForm, string XmlRootName,string xmlFolder)
        {
            InitializeComponent();
            m_con = new DBConnection();
            if (XmlRootName != null)
            {
                m_xml = new xml(xmlFolder, XmlRootName, pForm);
                string csError = null;
                if (!m_xml.Load(ref csError))
                {
                    LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_RUN_RELEASE, csError);
                }
            }
        }

        public DBTableControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
     /*********************************************************/

        public bool CheckConnection(Object DB_Param)
        {
            return m_con.CheckConnection(DB_Param);
        }

        public bool CreateNewDataBaseConnection(Form pParentForm, Object DB_Param, bool bNoDataBaseCheck)
        {
            while (true)
            {
                if (m_con.CreateNewDataBaseConnection(pParentForm, DB_Param))
                {
                    if (m_con.DBType == DBConnection.eDBType.SQLITE)
                    {
                        LocalDB_data local_DB_Data = (LocalDB_data)DB_Param;
                        if (local_DB_Data.bNewDatabase)
                        {
                            if (CreateDatabaseTables(true))
                            {
                                return true;
                            }
                            else
                            {
                                if (MessageBox.Show(pParentForm, lngConn.s_Error_Creating_Tables_in_SQLITE.s, lngConn.s_Error.s, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        RemoteDB_data remote_DB_Data = (RemoteDB_data)DB_Param;
                        if (remote_DB_Data.bNewDatabase)
                        {
                            if (CreateDatabaseTables(true))
                            {
                                return true;
                            }
                            else
                            {
                                if (MessageBox.Show(pParentForm, lngConn.s_Error_Creating_Tables_in_SQLITE.s, lngConn.s_Error.s, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    if (bNoDataBaseCheck)
                    {
                        return true;
                    }
                    string csError = null;
                    enumDataBaseCheckResult eRes = DataBaseCheck(ref csError);
                    switch (eRes)
                    {
                        case enumDataBaseCheckResult.OK:
                            return true;

                        case enumDataBaseCheckResult.TABLE_MISSING:
                        case enumDataBaseCheckResult.COLUMN_MISSING:
                        case enumDataBaseCheckResult.CONNECTION_FAILED:
                        case enumDataBaseCheckResult.NO_DATABASE_CONNECTION:
                        case enumDataBaseCheckResult.PRIMARY_KEY_MISSING:
                            LogFile.Error.Show(csError);
                            DialogResult dres = MessageBox.Show(pParentForm,
                                                                   lngConn.s_DeleteAllTablesAndCreateNewOnes.s,
                                                                   "?",
                                                                   MessageBoxButtons.YesNoCancel,
                                                                   MessageBoxIcon.Question);
                            switch (dres)
                            {
                                case DialogResult.Cancel:
                                    return false;
                                case DialogResult.No:
                                    break;
                                case DialogResult.Yes:
                                    bool bCancel = false;
                                    if (DropAllTablesInDataBase(pParentForm, ref bCancel))
                                    {
                                        return CreateDatabaseTables(true);
                                    }
                                    else
                                    {
                                        return false;
                                    }

                            }
                            break;
                    }
                    Application.DoEvents();
                }
                else
                {
                    return false;
                }
            }
        }
        
        public bool MakeDataBaseConnection(Form pParentForm, Object DB_Param)
        {
            while (true)
            {
                if (m_con.MakeDataBaseConnection(pParentForm, DB_Param))
                {
                    if (m_con.DBType == DBConnection.eDBType.SQLITE)
                    {
                        LocalDB_data local_DB_Data = (LocalDB_data)DB_Param;
                        if (local_DB_Data.bNewDatabase)
                        {
                            if (CreateDatabaseTables(false))
                            {
                                return true;
                            }
                            else
                            {
                                if (MessageBox.Show(pParentForm, lngConn.s_Error_Creating_Tables_in_SQLITE.s, lngConn.s_Error.s, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        RemoteDB_data remote_DB_Data = (RemoteDB_data)DB_Param;
                        if (remote_DB_Data.bNewDatabase)
                        {
                            if (CreateDatabaseTables(true))
                            {
                                return true;
                            }
                            else
                            {
                                if (MessageBox.Show(pParentForm, lngConn.s_Error_Creating_Tables_in_SQLITE.s, lngConn.s_Error.s, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    if (m_con.DBType == DBConnection.eDBType.SQLITE)
                    {
                        return true;
                    }
                    string csError = null;
                    enumDataBaseCheckResult eRes = DataBaseCheck(ref csError);
                    switch (eRes)
                    {
                        case enumDataBaseCheckResult.OK:
                            return true;

                        case enumDataBaseCheckResult.TABLE_MISSING:
                        case enumDataBaseCheckResult.COLUMN_MISSING:
                        case enumDataBaseCheckResult.CONNECTION_FAILED:
                        case enumDataBaseCheckResult.NO_DATABASE_CONNECTION:
                        case enumDataBaseCheckResult.PRIMARY_KEY_MISSING:
                            LogFile.Error.Show(csError);
                            DialogResult dres =MessageBox.Show(pParentForm, 
                                                                   lngConn.s_DeleteAllTablesAndCreateNewOnes.s, 
                                                                   "?", 
                                                                   MessageBoxButtons.YesNoCancel, 
                                                                   MessageBoxIcon.Question);
                            switch (dres)
                            {
                                case DialogResult.Cancel:
                                    return false;
                                case DialogResult.No:
                                    break;
                                case DialogResult.Yes:
                                    bool bCancel = false;
                                    if (DropAllTablesInDataBase(pParentForm, ref bCancel))
                                    {
                                        return CreateDatabaseTables(true);
                                    }
                                    else
                                    {
                                        return false;
                                    }

                            }
                            break;
                    }
                    Application.DoEvents();
                }
                else
                {
                    return false;
                }
            }
        }

        public Object UndefineAllValues(SQLTable myTable)
        {
            Object objTable = myTable.objTable;
            Type this_class = objTable.GetType();
            FieldInfo[] this_class_fields = this_class.GetFields();
            int i;
            int iCount = this_class_fields.Count();
            for (i = 0; i < iCount; i++)
            {
                object obj = this_class_fields[i].GetValue(objTable);
                if (DBTypes.DBtypesFunc.IsBasicType(obj))
                {
                    try
                    {
                        DBTypes.ValSet valset = (DBTypes.ValSet)obj;
                        valset.defined = false;
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("Error in UndefineAllValues:" + ex.Message);
                    }
                }
                else
                {
                    object objChildTable = this_class_fields[i].GetValue(objTable);
                    SQLTable OutTbl;
                    if (myTable.IsMyChildTable(out OutTbl, objChildTable.GetType()))
                    {
                        foreach (Column col in myTable.Column)
                        {
                            if (col.fKey != null)
                            {
                                if (col.fKey.fTable.objTable.GetType() == objChildTable.GetType())
                                {
                                    col.fKey.fTable.objTable = objChildTable;
                                    col.fKey.fTable.pParentTable = myTable;
                                }
                            }
                        }
                        UndefineAllValues(OutTbl);
                    }
                }
            }
            return myTable.objTable;
        }


        public SQLTable GetTable(string sTableName)
        {
            foreach (SQLTable tbl in items)
            {
                if (tbl.TableName.Equals(sTableName))
                {
                    return tbl;
                }
            }
            return null;
        }

        public SQLTable GetTable_from_TableName_Abbreviation(string sTableName_Abbreviation)
        {
            foreach (SQLTable tbl in items)
            {
                if (tbl.TableName_Abbreviation.Equals(sTableName_Abbreviation))
                {
                    return tbl;
                }
            }
            return null;
        }

        public bool DataBase_Backup(string full_back_up_file_name)
        {
            return this.m_con.DataBase_Backup(full_back_up_file_name);
        }

        public bool DataBase_Restore(string full_back_up_file_name)
        {
            return this.m_con.DataBase_Restore(full_back_up_file_name);
        }

        public bool DataBase_Make_BackupTemp()
        {
            return this.m_con.DataBase_Make_BackupTemp();
        }

        public bool DataBase_Delete_BackupTemp()
        {
            return this.m_con.DataBase_Delete_BackupTemp();
        }

        public bool DataBase_Delete()
        {
            return this.m_con.DataBase_Delete();
        }

        public bool DataBase_Create()
        {
            return this.m_con.DataBase_Create();
        }
    }
}
