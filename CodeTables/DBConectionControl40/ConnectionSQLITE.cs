using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnectionControl40
{
    public class ConnectionSQLITE
    {
        public enum eSQLITEFileExist { OK, NOT_EXISTS, CONNECTION_FILE_NOT_DEFINED };

        public conData_SQLITE m_conData_SQLITE = null;

        private bool m_bOpened = false;
        private bool m_bBatchOpen = false;

        private bool m_bSessionConnected = false;


        public SQLiteConnection Con = null;
        public SQLiteTransaction Tran = null;
        public SQLiteCommand cmd = null;

        public SQLiteConnectionDialog SQLiteConnectionDialog = null;

        public bool BatchOpen
        {
            get { return m_bBatchOpen; }
            set { m_bBatchOpen = value; }
        }

        public bool SessionConnected
        {
            get { return m_bSessionConnected; }
        }

        
        public string DataBaseFile
        {
            get
            {
                if (m_conData_SQLITE != null)
                {
                    return m_conData_SQLITE.DataBaseFile;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_SQLITE != null)
                {
                    m_conData_SQLITE.DataBaseFile = value;
                }
            }
        }


        public string DataBaseFileName
        {
            get
            {
                if (m_conData_SQLITE != null)
                {
                    return m_conData_SQLITE.DataBaseFileName;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_SQLITE != null)
                {
                    m_conData_SQLITE.DataBaseFileName = value;
                }
            }
        }

        public string DataBaseFilePath
        {
            get
            {
                if (m_conData_SQLITE != null)
                {
                    return m_conData_SQLITE.DataBaseFilePath;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_SQLITE != null)
                {
                    m_conData_SQLITE.DataBaseFilePath = value;
                }
            }
        }


        public string SQLiteDataBaseFile
        {
            get
            {
                if (m_conData_SQLITE != null)
                {
                    return m_conData_SQLITE.DataBaseFile;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_SQLITE != null)
                {
                    m_conData_SQLITE.DataBaseFile = value;
                }
            }
        }

        public DateTime SQLiteDataBaseFileCreationTime
        {
            get
            {
                if (m_conData_SQLITE != null)
                {
                    return m_conData_SQLITE.DataBaseFileCreationTime;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        public string PasswordCrypted
        {
            get
            {
                if (m_conData_SQLITE != null)
                {
                    return m_conData_SQLITE.m_crypted_Password;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_SQLITE != null)
                {
                    m_conData_SQLITE.m_crypted_Password = value;
                }
            }
        }

        public string Password
        {
            get
            {
                if (m_conData_SQLITE != null)
                {
                    return m_conData_SQLITE.m_Crypt.DecryptString(PasswordCrypted);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_SQLITE != null)
                {
                    m_conData_SQLITE.m_crypted_Password = m_conData_SQLITE.m_Crypt.EncryptString(value); 
                }
            }
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


        public bool CheckConnectionToServerOnly()
        {
            try
            {
                Con.ConnectionString = m_conData_SQLITE.DataBaseFile;
                Con.Open();
                return true;
            }
            catch (Exception ex)
            {
                //sError = SetConnectionError() + "\n" + ex.Message;
                //if (dbg.bON) dbg.Print(sError);
                //Log.Write(1, sError);
                LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_RUN_RELEASE, "Error:CheckConnectionToServerOnly: Exception = " + ex.Message);
                return false;
            }
        }

        public bool Connect_ToServerOnly(ref string sError)
        {
            try
            {
                Con.Open();
                return true;
            }
            catch (Exception ex)
            {
                sError = SetConnectionError() + "\n" + ex.Message;
                return false;
            }
        }


        public bool Connect(ref string sError)
        {
            ProgramDiagnostic.Diagnostic.Meassure("Connect START", null);
            try
            {
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


        public bool Disconnect_Batch()
        {
            if (m_bBatchOpen)
            {
                return true;
            }
            else
            {
                return Disconnect();
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


        public bool Startup_03_Show_ConnectionDialog(NavigationButtons.Navigation nav, string recentItemsFolder, string backupFolder, string connectionName)
        {
            SQLiteConnectionDialog = new SQLiteConnectionDialog(m_conData_SQLITE, recentItemsFolder, backupFolder, nav, connectionName);
            nav.ShowForm(SQLiteConnectionDialog, SQLiteConnectionDialog.GetType().ToString());
            return true;
        }

        public void do_ConnectionDialog(string sTitle,
                                        ref bool bNewDatabase,
                                        NavigationButtons.Navigation nav,
                                        ref bool bCanceled,
                                        string myConnectionName,
                                        string recentItemsFolder,
                                        string backupFolder
                                        )
        {
            bNewDatabase = false;
            SQLiteConnectionDialog = new SQLiteConnectionDialog(m_conData_SQLITE, recentItemsFolder, backupFolder, nav, myConnectionName);
        }



        public bool ExecuteQuerySQL(StringBuilder sql, List<SQL_Parameter> lSQL_Parameter, ref ID id_new, ref string csError, string SQlite_table_name)
        {

            try
            {
                SQLiteCommand command;
                string sError = "";
                if (Connect_Batch(ref sError))
                {
                    cmd.CommandText = sql.ToString();
                    if (lSQL_Parameter != null)
                    {
                        cmd.Parameters.Clear();
                        foreach (SQL_Parameter sqlPar in lSQL_Parameter)
                        {
                            if (sqlPar.size > 0)
                            {
                                SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                mySQLiteParameter.Value = sqlPar.Value;
                                cmd.Parameters.Add(mySQLiteParameter);
                            }
                            else
                            {
                                SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                cmd.Parameters.Add(mySQLiteParameter);
                            }
                        }
                    }

                    Object ReturnObject = cmd.ExecuteScalar();
                    Disconnect_Batch();
                    if (ReturnObject == null)
                    {
                        //SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() AS ID" , m_con_SQLite);
                        // On different Sqlite.dll runs different !
                        //                                    SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() from " + SQlite_table_name, m_con_SQLite);
                        cmd.CommandText = "SELECT last_insert_rowid()";
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
                            if (DBConnection.IsNumber(s))
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
                DBConnection.ShowDBErrorMessage(ex.Message, lSQL_Parameter, "ExecuteNonQuerySQL");
                Disconnect();
                DBConnection.WriteLogTable(ex);
                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END ERROR", null);
                return false;
            }
        }


        internal eSQLITEFileExist SQLITEFileExist(ref string sqlitefile)
        {
            if (m_conData_SQLITE != null)
            {
                sqlitefile = m_conData_SQLITE.DataBaseFile;
                if (File.Exists(sqlitefile))
                {
                    return eSQLITEFileExist.OK;
                }
                else
                {
                    return eSQLITEFileExist.NOT_EXISTS;
                }
            }
            else
            {
                return eSQLITEFileExist.CONNECTION_FILE_NOT_DEFINED;
            }
        }

        public bool SQLite_AllwaysCreateNew
        {
            get
            {
                if (m_conData_SQLITE != null)
                {
                    return m_conData_SQLITE.SQLite_AllwaysCreateNew;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (m_conData_SQLITE != null)
                {
                    m_conData_SQLITE.SQLite_AllwaysCreateNew = value;
                }
            }
        }

        internal bool DataBase_Make_Backup_SQLite(string backupFullFileNamePath)
        {
            string FullFileNamePath = this.m_conData_SQLITE.DataBaseFile;
            if (backupFullFileNamePath == null)
            {
                string full_path = System.IO.Path.GetDirectoryName(FullFileNamePath);
                string file_name = System.IO.Path.GetFileName(FullFileNamePath);
                if ((full_path[full_path.Length - 1] != '\\') && (full_path[full_path.Length - 1] != '/'))
                {
                    full_path += '\\';
                }
                backupFullFileNamePath = full_path + "BACKUP_" + file_name;
            }

            try
            {
                File.Copy(FullFileNamePath, backupFullFileNamePath);
                return true;

            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:DBConnection:DataBase_Make_BackupTemp_SQLite:Exception=" + Ex.Message);
                return false;
            }

        }



        internal bool DataBase_Restore_SQLite(string BackupFullFileNamePath)
        {
            string FullFileNamePath = this.m_conData_SQLITE.DataBaseFile;
            try
            {
                File.Copy(BackupFullFileNamePath, FullFileNamePath, true);
                return true;

            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:ConnectionSQLITE:DataBase_Restore_SQLite:Backup file = \"" + BackupFullFileNamePath + "\"\r\nException = " + Ex.Message);
                return false;
            }
        }

    }
}
