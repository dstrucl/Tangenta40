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
        private conData_MSSQL m_conData_MSSQL = null;

        private bool m_bOpened = false;
        private bool m_bBatchOpen = false;

        public SqlConnection Con = null;
        public SqlTransaction Tran = null;
        public SqlCommand cmd = null;

        public bool BatchOpen
        {
            get { return m_bBatchOpen; }
            set { m_bBatchOpen = value; }
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
