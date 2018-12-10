using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnectionControl40
{
    public class ConnectionSQLITE
    {

        private conData_SQLITE m_conData_SQLITE = null;

        private bool m_bOpened = false;
        private bool m_bBatchOpen = false;

        private bool m_bSessionConnected = false;


        public SQLiteConnection Con = null;
        public SQLiteTransaction Tran = null;
        public SQLiteCommand cmd = null;

        private SQLiteConnectionDialog SQLiteConnectionDialog = null;

        public bool BatchOpen
        {
            get { return m_bBatchOpen; }
            set { m_bBatchOpen = value; }
        }

        public ConnectionSQLITE()
        {
            Con = new SQLiteConnection();
        }

        public ConnectionSQLITE(string connectionString)
        {
            Con = new SQLiteConnection(connectionString);
        }

        public ConnectionState State
        {
            get
            {
                return Con.State;
            }
        }

        public string ConnectionString
        {
            get
            {
                return Con.ConnectionString;
            }
            set
            {
                Con.ConnectionString = value;
            }
        }

        public void Open()
        {
            Con.Open();
        }

        public bool BeginTransaction()
        {
            if (Tran == null)
            {
                Tran = Con.BeginTransaction();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Commit()
        {
            if (Tran != null)
            {
                try
                {
                    Tran.Commit();
                    return true;
                }
                catch ( Exception ex)
                {
                    LogFile.Error.Show("ERROR:DBConnectionControl40:ConnectionSQLITE:Commit:Exception = " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool RollbackTransaction(ref string sError)
        {
            if (Tran != null)
            {
                try
                {
                    Tran.Rollback();
                    sError = null;
                    return true;
                }
                catch (Exception ex)
                {
                    sError = "ERROR:DBConnectionControl40:ConnectionSQLITE:RollbackTransaction:Exception = " + ex.Message;
                    return false;
                }
            }
            else
            {
                sError = "ERROR:DBConnectionControl40:ConnectionSQLITE:Tran = null";
                return false;
            }
        }

        public string SetRollbackTransactionError()
        {
             return "ERROR RollbackTransaction failed for SQLite DataBaseFile:\"" + this.SQLiteDataBaseFile + "\"\n";
        }

        public bool CreateCommand()
        {
            if (cmd == null)
            {
                cmd = Con.CreateCommand();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Close()
        {
            Con.Close();
        }

        public void Dispose()
        {
            Con.Dispose();
        }


        public bool Connect_Batch(ref string sError)
        {
            if (m_bBatchOpen)
            {
                if (m_bOpened)
                {
                    return true;
                }
            }
            return Connect(ref sError);
        }



        public bool Connect(ref string sError)
        {
            ProgramDiagnostic.Diagnostic.Meassure("Connect START", null);
            try
            {
                SetConnectionString();
                Con.Open();
                m_bOpened = true;
                ProgramDiagnostic.Diagnostic.Meassure("Connect END", null);
                return true;

            }
            catch (Exception ex)
            {
                sError = SetConnectionError() + "\n" + ex.Message;
                if (dbg.bON) dbg.Print(sError);
                Log.Write(1, sError);
                ProgramDiagnostic.Diagnostic.Meassure("Connect END with ERROR", null);
                return false;
            }
        }

        public bool Disconnect()
        {
            ProgramDiagnostic.Diagnostic.Meassure("Disconnect START", null);
            try
            {
                        Con.Close();
                        m_bOpened = false;
                        ProgramDiagnostic.Diagnostic.Meassure("Disconnect END", null);
                        return true;
            }
            catch (Exception ex)
            {
                ProgramDiagnostic.Diagnostic.Meassure("Disconnect END ERROR", null);
                MessageBox.Show("Error can not disconnect from:" + ConnectionString + "\n\n Exception = " + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }


        private string SetConnectionError()
        {
            return "ERROR Connection failed for SQLite DataBaseFile:\"" + this.SQLiteDataBaseFile + "\"\n";
        }

        public bool SessionConnect(ref string sError)
        {
            if (BatchOpen)
            {
                m_bSessionConnected = true;
                return true;
            }
            else
            {
                if (m_bBatchOpen)
                {
                    if (m_bOpened)
                    {
                        m_bSessionConnected = true;
                        return true;
                    }
                }

                if (Connect(ref sError))
                {
                    m_bBatchOpen = true;
                    m_bSessionConnected = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool SessionDisconnect()
        {
            if (BatchOpen)
            {
                if (Disconnect())
                {
                    m_bBatchOpen = false;
                    m_bSessionConnected = false;
                    return true;
                }
                else
                {
                    m_bSessionConnected = false;
                    return false;
                }
            }
            else
            {
                if (!m_bBatchOpen)
                {
                    if (!m_bOpened)
                    {
                        m_bSessionConnected = false;
                        return true;
                    }
                    else
                    {
                        if (Disconnect())
                        {
                            m_bBatchOpen = false;
                            m_bSessionConnected = false;
                            return true;
                        }
                        else
                        {
                            m_bSessionConnected = false;
                            return false;
                        }
                    }
                }
                else
                {
                    m_bSessionConnected = false;
                    return true;
                }
            }
        }



        public string SQLiteDataBaseFile
        {
            get
            {
                return m_conData_SQLITE.DataBaseFile;
            }
            set
            {
                 m_conData_SQLITE.DataBaseFile = value;
            }
        }



        public bool ExecuteQuerySQL(StringBuilder sql, List<SQL_Parameter> lSQL_Parameter, ref ID id_new, ref string csError, string SQlite_table_name)
        {

            try
            {
                SQLiteCommand command;
                string sError = "";
                if (Connect_Batch(ref sError))
                {
                    command = new SQLiteCommand(sqlTran.ToString(), m_con_SQLite.Con);
                    command.CommandTimeout = 200000;
                    if (lSQL_Parameter != null)
                    {
                        foreach (SQL_Parameter sqlPar in lSQL_Parameter)
                        {
                            if (sqlPar.size > 0)
                            {
                                SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                mySQLiteParameter.Value = sqlPar.Value;
                                command.Parameters.Add(mySQLiteParameter);
                            }
                            else
                            {
                                SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                command.Parameters.Add(mySQLiteParameter);
                            }
                        }
                    }

                    Object ReturnObject = command.ExecuteScalar();
                    Disconnect_Batch();
                    if (ReturnObject == null)
                    {
                        //SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() AS ID" , m_con_SQLite);
                        // On different Sqlite.dll runs different !
                        //                                    SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() from " + SQlite_table_name, m_con_SQLite);
                        SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid()", m_con_SQLite.Con);
                        // Bepaal de nieuwe ID en sla deze op in het juiste veld
                        if (Connect_Batch(ref sError))
                        {
                            object nieuweID = cmd.ExecuteScalar();
                            id_new = new ID(nieuweID);
                            Disconnect_Batch();
                        }
                        else
                        {
                            LogFile.Error.Show(sError);
                            ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
                            return false;
                        }
                    }
                    else
                    {
                        if (ReturnObject.GetType() == typeof(string))
                        {
                            string s;
                            s = (string)ReturnObject;
                            if (IsNumber(s))
                            {
                                id_new = new ID(ReturnObject);
                            }
                        }
                        else if (ReturnObject.GetType() == typeof(long))
                        {
                            id_new = new ID(ReturnObject);
                        }
                        else if (ReturnObject.GetType() == typeof(Int32))
                        {
                            id_new = new ID(ReturnObject);
                        }
                        else if (ReturnObject.GetType() == typeof(Int64))
                        {
                            id_new = new ID(ReturnObject);
                        }
                    }
                    ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
                    return true;
                }
                else
                {
                    LogFile.Error.Show(sError);
                    ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END ERROR", null);
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("SQL ERROR:" + ex.Message);
                csError = "Error ExecuteQuerySQL :" + ex.Message;
                ShowDBErrorMessage(ex.Message, lSQL_Parameter, "ExecuteNonQuerySQL");
                Disconnect();
                WriteLogTable(ex);
                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END ERROR", null);
                return false;
            }
        }

        public bool Startup_03_Show_ConnectionDialog(NavigationButtons.Navigation nav)
        {
            string sTitle = lng.s_Connection_to_Database.s + this.DataBase;
            switch (m_DBType)
            {
                //case eDBType.MYSQL:
                //    if ((m_conData_MYSQL.m_DataSource.Length > 0) && (m_conData_MYSQL.m_DataBase.Length > 0))
                //    {
                //        ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditLoginAndPassword, this, sTitle, nav);
                //    }
                //    else
                //    {
                //        ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditAll, this, sTitle, nav);
                //    }
                //    break;

                case eDBType.MSSQL:
                    if ((m_conData_MSSQL.m_DataSource.Length > 0) && (m_conData_MSSQL.m_DataBase.Length > 0))
                    {
                        ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditLoginAndPassword, this, sTitle, nav);
                    }
                    else
                    {
                        ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditAll, this, sTitle, nav);
                    }
                    nav.ShowForm(ConnectionDialog, ConnectionDialog.GetType().ToString());
                    return true;

                case eDBType.SQLITE:

                    SQLiteConnectionDialog = new SQLiteConnectionDialog(m_conData_SQLITE, this.RecentItemsFolder, this.BackupFolder, nav, this.ConnectionName);
                    nav.ShowForm(SQLiteConnectionDialog, SQLiteConnectionDialog.GetType().ToString());
                    return true;


                default:
                    MessageBox.Show("Error unknown eSQLType in function:  public ConnectResult_ENUM do_ConnectionDialog(string sTitle).");
                    return false;
            }
        }
    }
}
