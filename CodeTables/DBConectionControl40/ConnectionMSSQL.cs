using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnectionControl40
{
    public class ConnectionMSSQL
    {
        public conData_MSSQL m_conData_MSSQL = null;

        private bool m_bOpened = false;
        private bool m_bBatchOpen = false;
        private bool m_bSessionConnected = false;

        public SqlConnection Con = null;
        public SqlTransaction Tran = null;
        public SqlCommand cmd = null;

        public ConnectionDialog ConnectionDialog = null;

        public bool BatchOpen
        {
            get { return m_bBatchOpen; }
            set { m_bBatchOpen = value; }
        }

        public bool SessionConnected
        {
            get { return m_bSessionConnected; }
        }

        public ConnectionMSSQL()
        {
            Con = new SqlConnection();
        }

        public ConnectionMSSQL(string connectionString)
        {
            Con = new SqlConnection(connectionString);
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

        public bool WindowsAuthentication
        {
            get
            {
                if (m_conData_MSSQL != null)
                {
                    return m_conData_MSSQL.m_bWindowsAuthentication;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (m_conData_MSSQL != null)
                {
                    m_conData_MSSQL.m_bWindowsAuthentication = value;
                }
            }
        }

        public string DataBase
        {
            get
            {
                if (m_conData_MSSQL != null)
                {
                    return m_conData_MSSQL.m_DataBase;
                }
                return null;
            }
            set
            {
                if (m_conData_MSSQL != null)
                {
                    m_conData_MSSQL.m_DataBase = value;
                }
            }
        }

        public string DataSource
        {
            get
            {
                if (m_conData_MSSQL != null)
                {
                    return m_conData_MSSQL.m_DataSource;
                }
                return null;
            }
            set
            {
                if (m_conData_MSSQL != null)
                {
                    m_conData_MSSQL.m_DataSource = value;
                }
            }
        }

        public string DataBaseFilePath
        {
            get
            {
                if (m_conData_MSSQL != null)
                {
                    return m_conData_MSSQL.m_strDataBaseFilePath;
                }
                return null;
            }
            set
            {
                if (m_conData_MSSQL != null)
                {
                    m_conData_MSSQL.m_strDataBaseFilePath = value;
                }
            }
        }

        public string DataBaseLogFilePath
        {
            get
            {
                if (m_conData_MSSQL != null)
                {
                    return m_conData_MSSQL.m_strDataBaseLogFilePath;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_MSSQL != null)
                {
                    m_conData_MSSQL.m_strDataBaseLogFilePath = value;
                }
            }
        }

        public string UserName
        {
            get
            {
                if (m_conData_MSSQL != null)
                {
                    return m_conData_MSSQL.m_UserName;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_MSSQL != null)
                {
                    m_conData_MSSQL.m_UserName = value;
                }
            }
        }


        public string WindowsAuthentication_UserName
        {
            get
            {
                if (m_conData_MSSQL != null)
                {
                    return m_conData_MSSQL.m_WindowsAuthentication_UserName;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_MSSQL != null)
                {
                    m_conData_MSSQL.m_WindowsAuthentication_UserName = value;
                }
            }
        }

        public string PasswordCrypted
        {
            get
            {
                if (m_conData_MSSQL != null)
                {
                    return m_conData_MSSQL.m_crypted_Password;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_MSSQL != null)
                {
                    m_conData_MSSQL.m_crypted_Password = value;
                }
            }
        }

        public string Password
        {
            get
            {
                if (m_conData_MSSQL != null)
                {
                    return m_conData_MSSQL.m_Crypt.DecryptString(m_conData_MSSQL.m_crypted_Password);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_conData_MSSQL != null)
                {
                    m_conData_MSSQL.m_crypted_Password = m_conData_MSSQL.m_Crypt.EncryptString(value); ;
                }
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
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:DBConnectionControl40:cccc:Commit:Exception = " + ex.Message);
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
                    return true;
                }
                catch (Exception ex)
                {
                    sError = "ERROR:DBConnectionControl40:ConnectionMSSQL:RollbackTransaction:Exception = " + ex.Message;
                    return false;
                }
            }
            else
            {
                sError = "ERROR:DBConnectionControl40:ConnectionMSSQL:Tran = null";
                return false;
            }
        }

        public string SetRollbackTransactionError()
        {
            if (m_conData_MSSQL.m_bWindowsAuthentication)
            {
                return "ERROR RollbackTransaction failed for SQL WINDOWS Authetnication:\"" + m_conData_MSSQL.m_DataSource + "\" DataBase:\"" + m_conData_MSSQL.m_DataBase + "\" UserName:\"" + m_conData_MSSQL.m_WindowsAuthentication_UserName + "\"\n";
            }
            else
            {
                return "ERROR RollbackTransaction failed for SQL Server Authetnication:\"" + m_conData_MSSQL.m_DataSource + "\" DataBase:\"" + m_conData_MSSQL.m_DataBase + "\" UserName:\"" + m_conData_MSSQL.m_UserName + "\" and Password:*******\n";
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
                Con.ConnectionString = m_conData_MSSQL.GetServerConnectionString();
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
                //if (dbg.bON) dbg.Print(sError);
                //Log.Write(1, sError);
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

        public bool Startup_03_Show_ConnectionDialog(DBConnection dbconnection, NavigationButtons.Navigation nav)
        {
            string sTitle = lng.s_Connection_to_Database.s + this.DataBase;
            if ((m_conData_MSSQL.m_DataSource.Length > 0) && (m_conData_MSSQL.m_DataBase.Length > 0))
            {
                ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditLoginAndPassword, dbconnection, sTitle, nav);
            }
            else
            {
                ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditAll, dbconnection, sTitle, nav);
            }
            nav.ShowForm(ConnectionDialog, ConnectionDialog.GetType().ToString());
            return true;

        }

        public void do_ConnectionDialog(DBConnection dbconnection,
                                        string sTitle,
                                        ref bool bNewDatabase,
                                        NavigationButtons.Navigation nav,
                                        ref bool bCanceled,
                                        string myConnectionName)
        {
            bNewDatabase = false;
            if ((m_conData_MSSQL.m_DataSource.Length > 0) && (m_conData_MSSQL.m_DataBase.Length > 0))
            {
                ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditLoginAndPassword, dbconnection, sTitle, nav);
            }
            else
            {
                ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditAll, dbconnection, sTitle, nav);
            }
        }

        private string SetConnectionError()
        {
            return "ERROR Connection failed for MSSQL DataBase:\"" + this.DataBase + "\"\n";
        }

    }
}
