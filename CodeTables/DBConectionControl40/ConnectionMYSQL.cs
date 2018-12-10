using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnectionControl40
{
    public class ConnectionMYSQL
    {
        private conData_MYSQL m_conData_MYSQL = null;

        private bool m_bOpened = false;
        private bool m_bBatchOpen = false;

        public MySqlConnection Con = null;
        public MySqlTransaction Tran = null;
        public MySqlCommand cmd = null;

        public bool BatchOpen
        {
            get { return m_bBatchOpen; }
            set { m_bBatchOpen = value; }
        }

        public ConnectionMYSQL()
        {
            Con = new MySqlConnection();
        }

        public ConnectionMYSQL(string connectionString)
        {
            Con = new MySqlConnection(connectionString);
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
                    LogFile.Error.Show("ERROR:DBConnectionControl40:ConnectionMYSQL:Commit:Exception = " + ex.Message);
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
                    sError = "ERROR:DBConnectionControl40:ConnectionMYSQL:RollbackTransaction:Exception = " + ex.Message;
                    return false;
                }
            }
            else
            {
                sError = "ERROR:DBConnectionControl40:ConnectionMYSQL:Tran = null";
                return false;
            }
        }

        public string SetRollbackTransactionError()
        {
            return "ERROR RollbackTransaction failed for MySQL Server Authetnication:\"" + m_conData_MYSQL.m_DataSource + "\" DataBase:\"" + m_conData_MYSQL.m_DataBase + "\" UserName:\"" + m_conData_MYSQL.m_UserName + "\" and Password:*******\n";
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
