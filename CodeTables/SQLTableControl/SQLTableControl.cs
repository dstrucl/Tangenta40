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
using NavigationButtons;

namespace CodeTables
{
    [ToolboxBitmap("E:\\ManualReader\\ctlogina\\CodeTables\\Resources\\CodeTables.ico")]
    public partial class DBTableControl : Component
    {
        private static bool bStrartupCheckColumns = false;
        public static bool StrartupCheckColumns
        {
            get
            {
                return bStrartupCheckColumns;
            }
            set
            {
                bStrartupCheckColumns = value;
            }
        }

        
        public DataTable DataBaseTablesInfo = null;

        private static Form_dtSQLdb form_dtSQLdb = null;

        public static DataTable dtSQLdb = new DataTable();
        private const string TRANSACTION_CreateDatabaseTables = "CreateDatabaseTables";

        public const string col_TABLE_NAME = "TABLE_NAME";
        public const string col_VIEW_NAME = "VIEW_NAME";
        public const string col_SQL_CreateTABLE = "SQL_CreateTABLE";
        public const string col_SQL_AddFkey = "SQL_AddFkey";
        public const string col_SQL_CreateVIEW = "SQL_CreateVIEW";

        public static void Show_Form_dtSQLdb(Form pform, DBConnection xcon, string sdbversion)
        {
            if (form_dtSQLdb != null)
            {
                if (form_dtSQLdb.IsDisposed)
                {
                    form_dtSQLdb = null;
                }
            }
            if (form_dtSQLdb == null)
            {

                form_dtSQLdb = new Form_dtSQLdb(xcon, sdbversion);
                form_dtSQLdb.Owner = pform;
                form_dtSQLdb.Show(pform);
            }
            else
            {
                form_dtSQLdb.Show();
            }
        }

        private static string m_SQLdbFile = null;
        public static string SQLdbFile
        {
            get
            {
                return m_SQLdbFile;
            }
            private set
            {
                m_SQLdbFile = value;
            }
        }

        public xml m_xml;

        private DBConnection m_con;
        public DBConnection Con
        {
            get {
                return m_con;
            }
            set
            {
                m_con = value;
            }
        }

        public SQLTable.delegate_GetInputControlRandomData m_dControlRandomData;
        public SQLTable.delegate_CheckRandomParamSettings m_dCheckRandomParamSettings;

        DataTable SQLite_tables = null;
        DataTable SQLite_columns_table = null;

        private DataBaseTables m_DBT = null;
        public DataBaseTables DBT
        {
            get
            {
                return m_DBT;
            }
            set
            {
                m_DBT = value;
            }
        }

        public List<DataBaseView> SQL_DataBase_VIEW_List = new List<DataBaseView>();

        public enum enumDataBaseCheckResult { OK, NO_DATABASE_CONNECTION,NO_TABLES, TABLE_MISSING, COLUMN_MISSING, FOREIGN_KEY_MISSING, PRIMARY_KEY_MISSING, CONNECTION_FAILED, WRONG_DBVERSION, ERROR };
        public StringBuilder m_strSQLUseDatabase = null;
        StringBuilder m_strSQLCheckTables = new StringBuilder();
        public Form m_ParentForm;

        public void Init(DBConnection.eDBType eDBType,string slog,string dbVersion)
        {
            Con.DBType = eDBType;           
            StringBuilder sbAll = SQLcmd_CreateAllTables(this.Con, slog, dbVersion); // this fuction creates all fkey links !
            string sAll = sbAll.ToString();
            SQLcmd_DropAllTables(this.Con);

        }


        public void SetVIEW_DataGridViewImageColumns_Headers(DataGridView dgvx_Item, SQLTable m_tbl,string[] table_names)
        {
            if (m_tbl!=null)
            {
                m_tbl.SetVIEW_DataGridViewImageColumns_Headers(dgvx_Item, this);
            }
            foreach (string stbl in table_names)
            {
                foreach (SQLTable tbl in DBT.items)
                {
                    if (stbl.ToLower().Equals(tbl.TableName.ToLower()))
                    {
                        foreach (DataGridViewColumn cl in dgvx_Item.Columns)
                        {
                            if (cl.Name.Equals("ID"))
                            {
                                cl.Visible = Globals.ShowID;
                            }
                            if (cl.Visible)
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
        }

        public SQLTable GetTable(Type typeOrefTable)
        {
            int iTable;
            int iTableCount;
            iTableCount = DBT.items.Count;

            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                if (DBT.items[iTable].objTable.GetType() == typeOrefTable)
                {
                    return DBT.items[iTable];
                }
            }
            return null;
        }
        
        public StringBuilder SQLcmd_CreateAllTables(DBConnection xcon,string slog, string dbVersion)
        {

            string sversion = dbVersion.Replace('.', '-');
            string sDBtype = "??";
            switch (xcon.DBType)
            {
                case DBConnection.eDBType.MSSQL:
                    sDBtype = "MSSQL";
                    break;
                case DBConnection.eDBType.SQLITE:
                    sDBtype = "SQLite";
                    break;
                default:
                    LogFile.Error.Show("ERROR:CodeTables:DBTableControl:SQLcmd_CreateAllTables:xcon.DBType not implemented: \"" + xcon.DBType.ToString() + "\"");
                    break;
            }
            string filename = "\\"+ sDBtype+ slog+"db-" + sversion+".xml";
            string sfolder = Global.f.GetApplicationDataFolder();

            SQLdbFile = sfolder + filename;


            dtSQLdb.Clear();
            dtSQLdb.Columns.Clear();

            StringBuilder strSqlAll = new StringBuilder(30000);
            StringBuilder strSqlTables = new StringBuilder(30000);

            if ((!File.Exists(SQLdbFile))||SQLTable.ResetSettings)
            {
                DataColumn dcol_TableName = new DataColumn(col_TABLE_NAME, typeof(string));
                DataColumn dcol_ViewName = new DataColumn(col_VIEW_NAME, typeof(string));
                DataColumn dcol_SQL_CreateTable = new DataColumn(col_SQL_CreateTABLE, typeof(string));
                DataColumn dcol_SQL_AddFkey = new DataColumn(col_SQL_AddFkey, typeof(string));
                DataColumn dcol_SQL_CreateView = new DataColumn(col_SQL_CreateVIEW, typeof(string));
                dtSQLdb.Columns.Add(dcol_TableName);
                dtSQLdb.Columns.Add(dcol_ViewName);
                dtSQLdb.Columns.Add(dcol_SQL_CreateTable);
                dtSQLdb.Columns.Add(dcol_SQL_AddFkey);
                dtSQLdb.Columns.Add(dcol_SQL_CreateView);

                //strSql.Append(Create_Database_Table(SQL_Table tbl_eva_User, m_eva_UserSQL_Table(());) new eva_User           ());

                //strSql.Append(Create_Database_Table(col_evl_CmdTYPE, m_evl_CmdTYPE)),
                //strSql.Append(Create_Database_Table(col_evl_History, m_evl_History));
                int iTable;
                int iTableCount;
                iTableCount = DBT.items.Count;

                List<string> UniqueConstraintNameList = new List<string>();
                string sql_DBm = "";

                dtSQLdb.TableName = SQLdbFile;

                for (iTable = 0; iTable < iTableCount; iTable++)
                {
                    DataRow dr = dtSQLdb.NewRow();
                    dr[dcol_TableName] = DBT.items[iTable].TableName;
                    SQLTable tbl = DBT.items[iTable];
                    if (DBtypesFunc.Is_DBm_Type(tbl.objTable))
                    {
                        continue; // ignore DBm_*  Tables
                    }
                    else
                    {
                        tbl.sql_CreateTable = tbl.SQLcmd_CreateTable(this, UniqueConstraintNameList, ref sql_DBm, null);
                        dr[dcol_SQL_CreateTable] = tbl.sql_CreateTable;
                        strSqlTables.Append(tbl.sql_CreateTable);
                    }
                    dtSQLdb.Rows.Add(dr);
                }
                strSqlAll.Append(sql_DBm);
                strSqlAll.Append(strSqlTables);

                StringBuilder strTableAlterTable = new StringBuilder("");

                for (iTable = 0; iTable < iTableCount; iTable++)
                {
                    DataRow dr = dtSQLdb.Rows[iTable];
                    switch (Con.DBType)
                    {
                        case DBConnection.eDBType.MYSQL:
                            dr[dcol_SQL_AddFkey] = DBT.items[iTable].SQLcmdMySQL_AlterTableAddConstraintForeign();
                            strTableAlterTable.Append((string)dr[dcol_SQL_AddFkey]);
                            break;

                        case DBConnection.eDBType.MSSQL:
                            dr[dcol_SQL_AddFkey] = DBT.items[iTable].SQLcmdMSSQL_AlterTableAddConstraintForeign();
                            strTableAlterTable.Append((string)dr[dcol_SQL_AddFkey]);
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
                string ErrMSSQLNameToLong = null;
                for (iTable = 0; iTable < iTableCount; iTable++)
                {
                    DataRow dr = dtSQLdb.Rows[iTable];
                    Application.DoEvents();
                    string table_view = null;
                    StringBuilder SQLCreateView_InDataBase = DBT.items[iTable].SQLCreateView_InDataBase(DBT.items);
                    if (SQLCreateView_InDataBase.Length > 0)
                    {
                        switch (Con.DBType)
                        {
                            case DBConnection.eDBType.MYSQL:
                                break;

                            case DBConnection.eDBType.MSSQL:
                                foreach (SQLTable.Table_View.ColumnNames cnames in DBT.items[iTable].m_Table_View.View_ColumnNames_List)
                                {
                                    if (cnames.Name.Length >= 128)
                                    {
                                        if (ErrMSSQLNameToLong == null)
                                        {
                                            ErrMSSQLNameToLong = "ERROR:SQLTableControl.cs:SQLcmd_CreateAllTables:View column name to long (>128) fo MSSQL database:\r\n  " + table_view;
                                        }
                                        else
                                        {
                                            if (table_view == null)
                                            {
                                                table_view = DBT.items[iTable].ViewName;
                                                ErrMSSQLNameToLong += "\r\n  " + table_view;
                                            }
                                        }
                                        ErrMSSQLNameToLong += "\r\n      " + cnames.Name;
                                    }
                                }
                                if (ErrMSSQLNameToLong != null)
                                {
                                    LogFile.Error.Show(ErrMSSQLNameToLong);
                                }
                                break;

                            case DBConnection.eDBType.SQLITE:
                                break;

                            default:
                                break;
                        }

                        DBT.items[iTable].sql_CreateView = SQLCreateView_InDataBase.ToString();
                        dr[dcol_ViewName] = DBT.items[iTable].ViewName;
                        dr[dcol_SQL_CreateView] = DBT.items[iTable].sql_CreateView;

                        DataBaseView xDataBaseView = new DataBaseView(DBT.items[iTable].ViewName, SQLCreateView_InDataBase.ToString());
                        SQL_DataBase_VIEW_List.Add(xDataBaseView);
                    }
                }
                try
                {
                    dtSQLdb.WriteXml(SQLdbFile,XmlWriteMode.WriteSchema);
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:CodeTables:DBTableControl:SQLcmd_CreateAllTables:Can not write \"" + SQLdbFile + "\"\r\nException=" + ex.Message);
                }
            }
            else
            {
                try
                {
                    dtSQLdb.TableName = SQLdbFile;
                    dtSQLdb.ReadXml(SQLdbFile);

                    //strSql.Append(Create_Database_Table(SQL_Table tbl_eva_User, m_eva_UserSQL_Table(());) new eva_User           ());

                    //strSql.Append(Create_Database_Table(col_evl_CmdTYPE, m_evl_CmdTYPE)),
                    //strSql.Append(Create_Database_Table(col_evl_History, m_evl_History));
                    int iTable;
                    int iTableCount;
                    iTableCount = DBT.items.Count;

                    List<string> UniqueConstraintNameList = new List<string>();
                    string sql_DBm = "";

                    

                    for (iTable = 0; iTable < iTableCount; iTable++)
                    {
                        DataRow dr = dtSQLdb.Rows[iTable];
                        DBT.items[iTable].TableName = (string)dr[col_TABLE_NAME];
                        SQLTable tbl = DBT.items[iTable];
                        if (DBtypesFunc.Is_DBm_Type(tbl.objTable))
                        {
                            continue; // ignore DBm_*  Tables
                        }
                        else
                        {
                            tbl.sql_CreateTable = (string)dr[col_SQL_CreateTABLE];
                            strSqlTables.Append(tbl.sql_CreateTable);
                        }
                    }
                    strSqlAll.Append(sql_DBm);
                    strSqlAll.Append(strSqlTables);

                    StringBuilder strTableAlterTable = new StringBuilder("");

                    for (iTable = 0; iTable < iTableCount; iTable++)
                    {
                        string_v s_v = null;
                        DataRow dr = dtSQLdb.Rows[iTable];
                        switch (Con.DBType)
                        {
                            case DBConnection.eDBType.MYSQL:
                                s_v = tf.set_string(dr[col_SQL_AddFkey]);
                                if (s_v != null)
                                {
                                    strTableAlterTable.Append(s_v.v);
                                }
                                break;

                            case DBConnection.eDBType.MSSQL:
                                s_v = tf.set_string(dr[col_SQL_AddFkey]);
                                if (s_v != null)
                                {
                                    strTableAlterTable.Append((string)dr[s_v.v]);
                                }
                                break;

                            case DBConnection.eDBType.SQLITE:
                                //strTable = new StringBuilder(DBT.items[iTable].SQLcmd_AlterTableAddConstraintForeign());
                                break;

                            default:
                                break;
                        }
                    }
                    strSqlAll.Append(strTableAlterTable);

                    // Also create views! in one step
                    SQL_DataBase_VIEW_List.Clear();
                    string ErrMSSQLNameToLong = null;
                    for (iTable = 0; iTable < iTableCount; iTable++)
                    {
                        DataRow dr = dtSQLdb.Rows[iTable];
                        Application.DoEvents();
                        string table_view = null;
                        string_v s_v = tf.set_string(dr[col_SQL_CreateVIEW]);
                        if (s_v!=null)
                        {
                            string_v viewName_v = tf.set_string(dr[col_VIEW_NAME]);
                            if (viewName_v != null)
                            {
                                if (DBT.items[iTable].m_Table_View==null)
                                {
                                    DBT.items[iTable].m_Table_View = new SQLTable.Table_View();
                                }
                                DBT.items[iTable].ViewName = viewName_v.v;
                            }
                            StringBuilder SQLCreateView_InDataBase = new StringBuilder(s_v.v);
                            if (SQLCreateView_InDataBase.Length > 0)
                            {
                                switch (Con.DBType)
                                {
                                    case DBConnection.eDBType.MYSQL:
                                        break;

                                    case DBConnection.eDBType.MSSQL:
                                        foreach (SQLTable.Table_View.ColumnNames cnames in DBT.items[iTable].m_Table_View.View_ColumnNames_List)
                                        {
                                            if (cnames.Name.Length >= 128)
                                            {
                                                if (ErrMSSQLNameToLong == null)
                                                {
                                                    ErrMSSQLNameToLong = "ERROR:SQLTableControl.cs:SQLcmd_CreateAllTables:View column name to long (>128) fo MSSQL database:\r\n  " + table_view;
                                                }
                                                else
                                                {
                                                    if (table_view == null)
                                                    {
                                                        table_view = DBT.items[iTable].ViewName;
                                                        ErrMSSQLNameToLong += "\r\n  " + table_view;
                                                    }
                                                }
                                                ErrMSSQLNameToLong += "\r\n      " + cnames.Name;
                                            }
                                        }
                                        if (ErrMSSQLNameToLong != null)
                                        {
                                            LogFile.Error.Show(ErrMSSQLNameToLong);
                                        }
                                        break;

                                    case DBConnection.eDBType.SQLITE:
                                        break;

                                    default:
                                        break;
                                }

                                DBT.items[iTable].sql_CreateView = SQLCreateView_InDataBase.ToString();
                                DBT.items[iTable].SQLitecmd_CreateFkeys(this, null);
                                //DBT.items[iTable].CreateTableTree(DBT.items);
                                DataBaseView xDataBaseView = new DataBaseView(DBT.items[iTable].ViewName, SQLCreateView_InDataBase.ToString());
                                SQL_DataBase_VIEW_List.Add(xDataBaseView);
                            }
                        }
                    }

                    //    int jTable = 0;
                    //for (jTable = 0; jTable < iTableCount; jTable++)
                    //{
                    //    for (iTable = 0; iTable < iTableCount; iTable++)
                    //    {
                    //        if (jTable != iTable)
                    //        {
                    //            foreach (Column col in DBT.items[iTable].Column)
                    //            {
                    //                if (!col.IsIdentity)
                    //                {
                    //                    if (col.fKey != null)
                    //                    {
                    //                        if (col.fKey.refInListOfTables != null)
                    //                        {
                    //                            if (col.fKey.refInListOfTables.TableName.Equals(DBT.items[jTable].TableName))
                    //                            {
                    //                                col.fKey.refInListOfTables.ReferencesToThisTable.Add(DBT.items[iTable], col.Name);
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}


                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:CodeTables:DBTableControl:SQLcmd_CreateAllTables:Can not read \"" + SQLdbFile + "\"\r\nException=" + ex.Message);
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
            iTableCount = DBT.items.Count;

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
            iTableCount = DBT.items.Count;

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
                if (DBtypesFunc.Is_DBm_Type(DBT.items[iTable]))
                {
                    continue;
                }
                else
                {
                    StringBuilder strTable = new StringBuilder(DBT.items[iTable].SQLcmd_AlterTableDropConstraintForeign());
                    strSqlAll.Append(strTable);
                }
            }

            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                if (DBtypesFunc.Is_DBm_Type(DBT.items[iTable]))
                {
                    continue;
                }
                else
                {
                    StringBuilder strTable = new StringBuilder(DBT.items[iTable].SQLcmd_DropTable());
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
            iTableCount = DBT.items.Count;

            foreach (DataBaseView dbv in SQL_DataBase_VIEW_List)
            {
                StringBuilder strTable = new StringBuilder(dbv.MySQLcmd_DropView());
                strSqlAll.Append(strTable);
            }
            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                StringBuilder strTable = new StringBuilder(DBT.items[iTable].MySQLcmd_AlterTableDropConstraintForeign());
                strSqlAll.Append(strTable);
            }

            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                StringBuilder strTable = new StringBuilder(DBT.items[iTable].MySQLcmd_DropTable());
                strSqlAll.Append(strTable);
            }
            return strSqlAll;
        }

        public StringBuilder SQLitecmd_DropAllTables(DBConnection xcon)
        {
            StringBuilder strSqlAll = new StringBuilder("");
            int iTable;
            int iTableCount;
            iTableCount = DBT.items.Count;

            foreach (DataBaseView dbv in SQL_DataBase_VIEW_List)
            {
                StringBuilder strTable = new StringBuilder(dbv.SQLitecmd_DropView());
                strSqlAll.Append(strTable);
            }
            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                StringBuilder strTable = new StringBuilder(DBT.items[iTable].SQLitecmd_AlterTableDropConstraintForeign());
                strSqlAll.Append(strTable);
            }

            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                StringBuilder strTable = new StringBuilder(DBT.items[iTable].SQLitecmd_DropTable());
                strSqlAll.Append(strTable);
            }
            return strSqlAll;
        }

        public bool IsMyTable(out SQLTable OutTbl,Type type)
        {
            foreach (SQLTable tbl in DBT.items)
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
            iTableCount = DBT.items.Count;

            for (iTable = iTableCount - 1; iTable >= 0; iTable--)
            {
                if (DBT.items[iTable].objTable.GetType() == typeOrefTable)
                {
                    return iTable;
                }
            }
            return -1;
        }

        public bool TablesCountInDatabase(ref int tablesCount)
        {
            if (DataBaseTablesInfo!=null)
            {
                tablesCount = Convert.ToInt32(DataBaseTablesInfo.Rows.Count);
                return true;
            }
            string strCheckTable = null;
            string csError = null;
            tablesCount = -1;
            switch (Con.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    strCheckTable = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '" + this.Con.DataBase + "';";
                    break;
                case DBConnection.eDBType.MSSQL:
                    strCheckTable = "\nUSE " + this.Con.DataBase + " SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE';";
                    break;
                case DBConnection.eDBType.SQLITE:
                    strCheckTable = "SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name != 'android_metadata' AND name != 'sqlite_sequence'";
                    break;
            }
            StringBuilder strB_CheckTable = new StringBuilder(strCheckTable);

            DataTable dt = new DataTable();
            if (this.Con.ReadDataTable(ref dt, strCheckTable, ref csError))
            {
                if (dt.Rows.Count > 0)
                {
                    tablesCount = Convert.ToInt32(dt.Rows[0][0]);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:SQLTableControl:No rows from selection:sql = " + strCheckTable);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:SQLTableControl:" + csError);
                return false;
            }
        }

        public bool DbTableExists(SQLTable tbl, ref string csError, Transaction transaction)
        {
            //string strTableNameAndSchema = " SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '"+tbl.TableName+"'";
            //string strCheckTable =   m_strSQLUseDatabase + String.Format(
            //      "IF OBJECT_ID('{0}', 'U') IS NOT NULL SELECT 'true' ELSE SELECT 'false' ",strTableNameAndSchema
            //      );
            if (DataBaseTablesInfo!=null)
            {
                DataRow[] drs = DataBaseTablesInfo.Select("tbl_name = '" + tbl.TableName + "'");
                if (drs.Count()>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            string strCheckTable = null;
            switch (Con.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    strCheckTable = "SELECT COUNT(*) as res FROM information_schema.tables WHERE table_schema = '" + this.Con.DataBase + "' AND table_name = '" + tbl.TableName + "';";
                    break;
                case DBConnection.eDBType.MSSQL:
                    strCheckTable = "\nUSE " + this.Con.DataBase + "\n IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='" + tbl.TableName + "') SELECT 1 AS res ELSE SELECT 0 AS res";
                    break;
                case DBConnection.eDBType.SQLITE:
                    strCheckTable = "SELECT COUNT(*) as res FROM sqlite_master WHERE type = 'table' AND name = '" + tbl.TableName + "'";
                    break;
            }
            DataTable dt = new DataTable();
            if (this.Con.ReadDataTable(ref dt, strCheckTable, ref csError))
            {
                if (dt.Rows.Count > 0)
                {
                    object ores = dt.Rows[0]["res"];
                    if (ores is int)
                    {
                        int i = (int)ores;
                        if (i == 1)
                        {
                            return true;
                        }
                        else
                        {
                            csError = lng.s_Error.s + ": " + lng.sTableIsMissing.s + ":" + tbl.TableName;
                            return false;
                        }
                    }
                    else if (ores is long)
                    {
                        long l;
                        l = (long)ores;
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
                                string sql_create = tbl.SQLcmd_CreateTable(this, UniqueConstraintNameList, ref sql_DBm, null);
                                string sql_create_All = sql_DBm + sql_create;
                                if (transaction.ExecuteNonQuerySQL(Con,sql_create_All, null, ref csError))
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
                                csError = lng.s_Error.s + ": " + lng.sTableIsMissing.s + ":" + tbl.TableName;
                                return false;
                            }
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public enumDataBaseCheckResult DataBaseCheck(ref string csError, Transaction transaction)
        {
                    
            enumDataBaseCheckResult eRes;
            eRes = enumDataBaseCheckResult.OK;
            if (DataBaseExists(ref csError))
            {
                int iCountOfTables = 0;
                if (!GetDataBalseTablesInfo(ref DataBaseTablesInfo))
                {
                    return enumDataBaseCheckResult.ERROR;
                }
                if (!TablesCountInDatabase(ref iCountOfTables))
                {
                    return enumDataBaseCheckResult.ERROR;
                }
                
                if (iCountOfTables==0)
                {
                    return enumDataBaseCheckResult.NO_TABLES;
                }

                if (DataBaseTablesInfo != null)
                {
                    DataRow[] drs = DataBaseTablesInfo.Select("tbl_name = 'DBSettings'");
                    if (drs.Count() > 0)
                    {
                        string version = null;
                        if (!DBTableControl.GetDataBaseVersion(Con, DBT.DBVersion, ref version))
                        {
                            return enumDataBaseCheckResult.ERROR;
                        }
                        if (!version.Equals(DBT.DBVersion))
                        {
                            return enumDataBaseCheckResult.WRONG_DBVERSION;
                        }
                    }
                }

                foreach (SQLTable tbl in DBT.items)
                {
                    if (DBtypesFunc.Is_DBm_Type(tbl.objTable))
                    {
                        string tbl_type = tbl.objTable.GetType().ToString();
                        if (tbl_type.Contains("." + tbl.TableName))
                        {
                            continue;
                        }
                    }
                    if (DbTableExists(tbl, ref csError, transaction))
                    {
                        if (DBTableControl.StrartupCheckColumns)
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

        public static bool GetDataBaseVersion(DBConnection con,string dBVersion, ref string version)
        {
            string err = null;
            version = "??";
            string sql = "Select TextValue from DBSettings where Name = 'Version'";
            DataTable dt = new DataTable();
            if (con.ReadDataTable(ref dt,sql,ref err))
            {
                if (dt.Rows.Count>0)
                {
                    version = tf._set_string(dt.Rows[0]["TextValue"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:CodeTables:SQLTableControl:GetDataBaseVersion:Error="+err +"\r\nsql="+sql);
                return false;
            }
        }

        public bool GetDataBalseTablesInfo(ref DataTable dt)
        {
            string err = null;
            switch (Con.DBType)
            {

                case DBConnection.eDBType.SQLITE:
                    string sql = "SELECT tbl_name,sql as sql_create_table FROM sqlite_master where type ='table' AND name != 'android_metadata' AND name != 'sqlite_sequence'";
                    if (dt!=null)
                    {
                        dt.Dispose();
                        dt = new DataTable();
                    }
                    else
                    {
                        dt = new DataTable();
                    }
                    if (Con.ReadDataTable(ref dt, sql, ref err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:CodeTables:SQLTableControl:GetDataBalseTablesInfo:Err=" + err);
                        return false;
                    }
                default:
                    LogFile.Error.Show("ERROR:CodeTables:SQLTableControl:GetDataBalseTablesInfo:Function not implemented for Con.DBType=" + Con.DBType.ToString());
                    return false;
            }
        }

        private bool DataBaseExists(ref string csError)
        {
            if (Con.Connect_ToServerOnly(ref csError))
            {
                Con.Disconnect();
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
            switch (Con.DBType)
            {
                case DBConnection.eDBType.MSSQL:
                    sqlColumnExist = @"USE " + Con.DataBase + @"
                                     SELECT *
                                     FROM INFORMATION_SCHEMA.COLUMNS
                                     WHERE TABLE_NAME = '" + tbl.TableName + @"'
                                     ORDER BY ORDINAL_POSITION;";
                    break;
                case DBConnection.eDBType.MYSQL:
                    sqlColumnExist = @"SELECT * FROM information_schema.COLUMNS
		                            WHERE table_name='" + tbl.TableName + @"'
		                            and table_schema='" + Con.DataBase + "';";
                    break;

                case DBConnection.eDBType.SQLITE:
                    {
                        if (Con.SQLiteTableInfo(ref SQLite_tables, ref SQLite_columns_table, ref csError))
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

            if (Con.ReadDataTable(ref dtColumnTable,sqlColumnExist,ref csError))
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

        public bool SQLcmd_ImportFile(Form mMainForm, string FileName, ref List<SQLTable> lTable, Transaction transaction)
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
                                    ID newID = null;
                                    if (sqlTbl.SQLcmd_InsertInto(Con,lTable, ref ErrorMsg, m_strSQLUseDatabase, ref newID, transaction))
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
                                    Source_Txt.ShowParseError(lng.s_Illegal_end_table_XML_command_expected.s + ": </" + sqlTbl.TableName + ">\n", lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Source_Txt.CloseText();
                                }
                            }
                            else
                            {
                                Source_Txt.ShowParseError(lng.s_Illegal_end_table_XML_command_expected.s + ": </" + sqlTbl.TableName + ">\n", lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                Source_Txt.ShowParseError(lng.s_File.s + ":" + FileName + "\n" + lng.s_Comma_is_missing_to_separate_cells_column_name_from_cell_value_in_line.s + ":" + Source_Txt.iLine.ToString(), lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            if (Globals.FindTable(out refsqlTbl, sTableName, DBT.items))
                            {
                                sqlTbl = new SQLTable(refsqlTbl);
                                sqlTbl.CreateTableTree(lTable);
                                continue;
                            }
                            else
                            {
                                Source_Txt.ShowParseError(lng.s_TableNameIsExpectedToBeBeforeDataLines.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }

                        }
                        else
                        {
                            Source_Txt.ShowParseError(lng.s_TableNameIsExpectedToBeBeforeDataLines.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        public bool CreateDatabaseTables(bool bAsk, string slog,ref bool bCancel, string dbVersion, Transaction transaction)
        {
            bCancel = false;
            if (bAsk)
            { 
                DialogResult dRes = MessageBox.Show(m_ParentForm, lng.s_CreateTablesInDataBaseQuestion.s + this.Con.DataSource + " ?", lng.s_Warning.s, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((dRes == DialogResult.No) || (dRes == DialogResult.Cancel))
                {
                    bCancel = true;
                    return false;
                }
            }
            CreateTables_WindowsForm_Thread xCreateTables_WindowsForm_Thread = new CreateTables_WindowsForm_Thread();
            int Tables_Count = DBT.items.Count();
            xCreateTables_WindowsForm_Thread.Start(Tables_Count);

            String csErrorMsg = "";

            bool bRes;

            StringBuilder m_strSQLCreate = SQLcmd_CreateAllTables(Con, slog, dbVersion);

                switch (Con.DBType)
                {
                    case DBConnection.eDBType.MYSQL:
                        {
                            string sql = "USE `" + Con.DataBase + "`;" + m_strSQLCreate.ToString();
                            bRes = transaction.ExecuteNonQuerySQL(Con,sql, null, ref csErrorMsg);
                        }
                        break;
                    case DBConnection.eDBType.MSSQL:
                        {
                            string sql = @"USE [" + Con.DataBase + @"]
                                      SET ANSI_NULLS ON;

                                      SET QUOTED_IDENTIFIER ON;

                                      SET ANSI_PADDING ON;
                                      " + m_strSQLCreate.ToString();
                            bRes = transaction.ExecuteNonQuerySQL(Con,sql, null, ref csErrorMsg);
                        }
                        break;

                    case DBConnection.eDBType.SQLITE:
                        bRes = transaction.ExecuteNonQuerySQL(Con,m_strSQLCreate.ToString(), null, ref csErrorMsg);
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
                        if (dbv.ViewName.Equals("JOURNAL_myOrganisation_Person_AccessR_VIEW"))
                        {
                            File.WriteAllText("C:\\TangentaDB\\JOURNAL_myOrganisation_Person_AccessR_VIEW.txt", dbv.SQLCommand, Encoding.UTF8);
                        }
                        if (transaction.ExecuteNonQuerySQL(Con,dbv.SQLCommand, null, ref csErrorMsg))
                        {
                        }
                        else
                        {
                            xCreateTables_WindowsForm_Thread.End();
                            Error.Show(m_ParentForm, lng.s_ErrorView.s + " " + dbv.ViewName + "\n\nException = " + csErrorMsg, lng.s_Error.s);
                            return false;
                        }
                    }

                    xCreateTables_WindowsForm_Thread.End();
                    //MessageBox.Show(m_ParentForm, lng.s_AllTablesCreatedOK.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string err = null;
                    return true;
                }
                else
                {
                    xCreateTables_WindowsForm_Thread.End();
                    string err = null;
                    Error.Show(m_ParentForm, lng.s_err_AllTablesCreated.s + "\n\nException = " + csErrorMsg, lng.s_Error.s);
                    return false;
                }
        }

        private bool DropAllViewsInSQLiteDataBase(Form pParentForm, ref bool bCancel, ref string serror, Transaction transaction)
        {
            try
            {

                string sqlAllTables = "SELECT name FROM SQLITE_MASTER WHERE type = 'view' and name <>'sqlite_sequence';";
                DataTable tables = new DataTable();
                List<string> sTableList = new List<string>();
                if (Con.ReadDataTable(ref tables, sqlAllTables, ref serror))
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
                            if (!transaction.ExecuteNonQuerySQL(Con,s_SQLite_Drop_table, null, ref serror))
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

        public bool DropAllTablesInSQLiteDataBase(Form pParentForm,ref bool bCancel, ref string serror, Transaction transaction)
         {
             if (DropAllViewsInSQLiteDataBase(pParentForm, ref bCancel, ref serror, transaction))
             {
                 try
                 {

                     string sqlAllTables = "SELECT name FROM SQLITE_MASTER WHERE type = 'table' and name <>'sqlite_sequence';";
                     DataTable tables = new DataTable();
                     List<string> sTableList = new List<string>();
                     if (Con.ReadDataTable(ref tables, sqlAllTables, ref serror))
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
                                 if (!transaction.ExecuteNonQuerySQL(Con,s_SQLite_Drop_table, null, ref serror))
                                 {
                                     return false;
                                 }
                             }
                             MessageBox.Show(m_ParentForm, lng.s_AllTablesDropedOK.s, lng.s_DataBase.s + " SQLite " + lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                             return true;
                         }
                         else
                         {
                             // Empty data base
                             MessageBox.Show(m_ParentForm, lng.s_DataBaseHasNoTablesItIsEmpty.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool DropAllTablesInDataBase(Form pParentForm,ref bool bCancel, Transaction transaction)
        {

            bCancel = false;
            DialogResult dres = MessageBox.Show(pParentForm, lng.s_AreYouShureToDeleteAllTablesAndCreateNewOnes.s, "?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
            switch (Con.DBType)
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
                sql_DropAllTables = @"DROP DATABASE " + Con.DataBase + @";
                                          CREATE DATABASE " + Con.DataBase + ";";
                    break;


                case DBConnection.eDBType.SQLITE:
                {
                    try
                    {
                        //m_con.Disconnect();
                        string serr = null;
                        if (DropAllTablesInSQLiteDataBase(pParentForm,ref bCancel,ref serr, transaction))
                        {
                                return true;
                            //if (m_con.Connect(ref serr))
                            //{
                            //    m_con.Disconnect();
                            //    return true;
                            //}
                            //else
                            //{
                            //    LogFile.Error.Show(lng.s_CanNotMakeAConnection.s + "\n\nException = " + serr);
                            //    return false;
                            //}
                        }
                        else
                        {
                            LogFile.Error.Show(lng.s_err_AllTablesDroped.s + "\n\nException = " + serr);
                            return false;
                        }
                    }
                    catch (Exception EX)
                    {
                        LogFile.Error.Show(lng.s_err_AllTablesDroped.s + "\n\nException = " + EX.Message);
                        return false;
                    }
                }
            }


            if (sql_DropAllTables!=null)
            {
                string csErrorMsg=null;
                if (transaction.ExecuteNonQuerySQL(Con,sql_DropAllTables, null, ref csErrorMsg))
                {
                    MessageBox.Show(m_ParentForm, lng.s_AllTablesDropedOK.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    LogFile.Error.Show(lng.s_err_AllTablesDroped.s + "\n\nException = " + csErrorMsg);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show(lng.s_DropAllTablesNotSupported_for_data_base_type.s + Con.ServerType);
                return false;
            }

        }

        public bool Create_VIEWs(Transaction transaction)
        {
            string sql = "";
            foreach (DataBaseView xDataBaseView in SQL_DataBase_VIEW_List)
            {
                sql = xDataBaseView.SQLCommand + "\r\n";
                String csErrorMsg = "";
               // object oResult = null;
                if (transaction.ExecuteNonQuerySQL(Con,sql, null, ref csErrorMsg))
                {
                    continue;
                }
                else
                {
                    LogFile.Error.Show(lng.s_err_CreateViews.s +"\r\nsql="+sql+ "\r\nException = " + csErrorMsg);
                    return false;
                }
            }
            return true;
        }

        public bool DropVIEWs(ref string Err, Transaction transaction)
        {
            Err = null;
            StringBuilder m_strSQLDrop =  this.SQLcmd_DropAll_Views(Con);

            string sql = m_strSQLDrop.ToString();

            if (this.Con.DBType== DBConnection.eDBType.SQLITE)
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
            if (transaction.ExecuteNonQuerySQL(Con,sql, null, ref csErrorMsg))
            {
                return true;
            }
            else
            {
                Err = lng.s_err_AllTablesDroped.s + "\n\nException = " + csErrorMsg;
                LogFile.Error.Show(Err);
                return false;
            }
        }

        public bool DropTables(Transaction transaction)
        {
            DialogResult dRes = MessageBox.Show(m_ParentForm, lng.s_DropTablesInDataBaseQuestion.s + this.Con.DataBase + " ?", lng.s_Warning.s, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if ((dRes == DialogResult.No) || (dRes == DialogResult.Cancel))
            {
                return false;
            }
            StringBuilder m_strSQLDrop = SQLcmd_DropAllTables(Con);

            String csErrorMsg = "";
            if (transaction.ExecuteNonQuerySQL(Con,m_strSQLDrop.ToString(), null, ref csErrorMsg))
            {
                MessageBox.Show(m_ParentForm, lng.s_AllTablesDropedOK.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show(m_ParentForm, lng.s_err_AllTablesDroped.s + "\n\nException = " + csErrorMsg, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public string GetDatabaseConnectionInfo()
        {
            switch (Con.DBType)
            {
                case DBConnection.eDBType.MSSQL:
                    return "MSSQL Server=\""+ Con.DataSource + "\",DataBase=\"" +Con.DataBase+"\"";
                case DBConnection.eDBType.MYSQL:
                    return "MSSQL Server=\""+ Con.DataSource + "\",DataBase=\"" +Con.DataBase+"\"";
                case DBConnection.eDBType.SQLITE:
                    return "SQLite DataBaseFile=\"" + Con.SQLiteDataBaseFile +"\"";
                default:
                    return "Error wrong m_con.DBType=";
            }
        }

     /*********************************************************/
        public DBTableControl(Form pForm, string XmlRootName,string xmlFolder, bool bTransactionsLog)
        {
            InitializeComponent();
            Con = new DBConnection(bTransactionsLog);
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
            return Con.CheckConnection(DB_Param);
        }

        public bool CreateNewDataBaseConnection( Object DB_Param, bool bNoDataBaseCheck, NavigationButtons.Navigation xnav, ref bool bCanceled, string dbVersion, Transaction transaction, TransactionLog_delegates transactionLog_Delegates)
        {
            while (true)
            {
                if (Con.CreateNewDataBaseConnection(DB_Param, xnav, transactionLog_Delegates, ref bCanceled))
                {
                    if (Con.DBType == DBConnection.eDBType.SQLITE)
                    {
                        LocalDB_data local_DB_Data = (LocalDB_data)DB_Param;
                        if (local_DB_Data.bNewDatabase)
                        {
                            bool bxCancel = false;
                            if (CreateDatabaseTables(true,"",ref bxCancel, dbVersion, transaction))
                            {
                                return true;
                            }
                            else
                            {
                                if (MessageBox.Show(xnav.parentForm, lng.s_Error_Creating_Tables_in_SQLITE.s, lng.s_Error.s, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
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
                            bool bxCancel = false;
                            if (CreateDatabaseTables(true,"", ref bxCancel, dbVersion, transaction))
                            {
                                return true;
                            }
                            else
                            {
                                if (MessageBox.Show(xnav.parentForm, lng.s_Error_Creating_Tables_in_SQLITE.s, lng.s_Error.s, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
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
                    enumDataBaseCheckResult eRes = DataBaseCheck(ref csError, transaction);
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
                            DialogResult dres = MessageBox.Show(xnav.parentForm,
                                                                   lng.s_DeleteAllTablesAndCreateNewOnes.s,
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
                                    if (DropAllTablesInDataBase(xnav.parentForm, ref bCancel, transaction))
                                    {
                                        bool bxCancel = false;
                                        return CreateDatabaseTables(true,"", ref bxCancel, dbVersion, transaction);
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

        internal ReferencesToTable GetReferencesToTable(SQLTable sQLTable)
        {
            SQLTable pfound = DBT.items.Find(delegate (SQLTable p) { return p.TableName == sQLTable.TableName; });
            if (pfound!=null)
            {
                return pfound.ReferencesToThisTable;
            }
            else
            {
                return null;
            }
        }

        public bool MakeDataBaseConnection(Form pParentForm,
                                           Object DB_Param,
                                           ref bool bNewDataBaseCreated,NavigationButtons.Navigation nav,
                                           ref bool bCanceled,
                                           string dbVersion,
                                           Transaction transaction,
                                           TransactionLog_delegates transactionLog_Delegates)
        {
            while (true)
            {
                if (Con.MakeDataBaseConnection(pParentForm, DB_Param, nav, transactionLog_Delegates, ref bCanceled))
                {
                    if (Con.DBType == DBConnection.eDBType.SQLITE)
                    {
                        LocalDB_data local_DB_Data = (LocalDB_data)DB_Param;
                        if (local_DB_Data.bNewDatabase)
                        {
                            bool bxCancel = false;
                            bNewDataBaseCreated = CreateDatabaseTables(false,"", ref bxCancel, dbVersion, transaction);
                            if (bNewDataBaseCreated)
                            {
                                return true;
                            }
                            else
                            {
                                if (MessageBox.Show(pParentForm, lng.s_Error_Creating_Tables_in_SQLITE.s, lng.s_Error.s, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
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
                            bool bxCancel = false;
                            bNewDataBaseCreated = CreateDatabaseTables(true,"", ref bxCancel, dbVersion, transaction);
                            if (bNewDataBaseCreated)
                            {
                                return bNewDataBaseCreated;
                            }
                            else
                            {
                                if (MessageBox.Show(pParentForm, lng.s_Error_Creating_Tables_in_SQLITE.s, lng.s_Error.s, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    if (Con.DBType == DBConnection.eDBType.SQLITE)
                    {
                        return true;
                    }
                    string csError = null;
                    enumDataBaseCheckResult eRes = DataBaseCheck(ref csError, transaction);
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
                                                                   lng.s_DeleteAllTablesAndCreateNewOnes.s, 
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
                                    if (DropAllTablesInDataBase(pParentForm, ref bCancel, transaction))
                                    {
                                        bool bxCancel = false;
                                        bNewDataBaseCreated = CreateDatabaseTables(true,"", ref bxCancel, dbVersion, transaction);
                                        return bNewDataBaseCreated;
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

        public bool Evaluate_DataBaseConnection(Form parentForm,
                                                object DB_Param,
                                                ref bool bNewDataBaseCreated,
                                                Navigation xnav,
                                                ref bool bCanceled,
                                                string dbVersion,
                                                Transaction transaction)
        {
            if (Con.Evaluate_MakeDataBaseConnection(xnav.parentForm, DB_Param, xnav, ref bCanceled))
            {
                if (Con.DBType == DBConnection.eDBType.SQLITE)
                {
                    LocalDB_data local_DB_Data = (LocalDB_data)DB_Param;
                    if (local_DB_Data.bNewDatabase)
                    {
                        bool bxCancel = false;
                        bNewDataBaseCreated = CreateDatabaseTables(false,"", ref bxCancel, dbVersion, transaction);
                        if (bNewDataBaseCreated)
                        {
                            return true;
                        }
                        else
                        {
                            if (MessageBox.Show(xnav.parentForm, lng.s_Error_Creating_Tables_in_SQLITE.s, lng.s_Error.s, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
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
                        bool bxCancel = false;
                        bNewDataBaseCreated = CreateDatabaseTables(true,"", ref bxCancel, dbVersion, transaction);
                        if (bNewDataBaseCreated)
                        {
                            return bNewDataBaseCreated;
                        }
                        else
                        {
                            if (MessageBox.Show(xnav.parentForm, lng.s_Error_Creating_Tables_in_SQLITE.s, lng.s_Error.s, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                            {
                                return false;
                            }
                        }
                    }
                }
                if (Con.DBType == DBConnection.eDBType.SQLITE)
                {
                    return true;
                }
                string csError = null;
                enumDataBaseCheckResult eRes = DataBaseCheck(ref csError, transaction);
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
                        DialogResult dres = MessageBox.Show(xnav.parentForm,
                                                                lng.s_DeleteAllTablesAndCreateNewOnes.s,
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
                                if (DropAllTablesInDataBase(xnav.parentForm, ref bCancel, transaction))
                                {
                                    bool bxCancel = false;
                                    bNewDataBaseCreated = CreateDatabaseTables(true,"", ref bxCancel, dbVersion, transaction);
                                    return bNewDataBaseCreated;
                                }
                                else
                                {
                                    return false;
                                }

                        }
                        break;
                }
                return false;
            }
            else
            {
                return false;
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
            foreach (SQLTable tbl in DBT.items)
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
            foreach (SQLTable tbl in DBT.items)
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
            return this.Con.DataBase_Backup(full_back_up_file_name);
        }

        public bool DataBase_Restore(string full_back_up_file_name)
        {
            return this.Con.DataBase_Restore(full_back_up_file_name);
        }

        public bool DataBase_Make_BackupTemp()
        {
            return this.Con.DataBase_Make_BackupTemp();
        }

        public bool DataBase_Delete_BackupTemp()
        {
            return this.Con.DataBase_Delete_BackupTemp();
        }

        public bool DataBase_Delete()
        {
            return this.Con.DataBase_Delete();
        }

        public bool DataBase_Create(Transaction transaction)
        {
            return this.Con.DataBase_Create(transaction);
        }
    }
}
