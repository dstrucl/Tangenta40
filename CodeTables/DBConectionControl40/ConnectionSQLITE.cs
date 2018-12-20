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
    public partial class ConnectionSQLITE
    {
        public enum eSQLITEFileExist { OK, NOT_EXISTS, CONNECTION_FILE_NOT_DEFINED };

        public conData_SQLITE m_conData_SQLITE = null;

        private bool m_bBatchOpen = false;

        private bool m_bSessionConnected = false;


        public SQLiteConnection Con = null;
        public SQLiteCommand cmd = null;

        private SQLiteTransaction m_Tran = null;
        public SQLiteTransaction Tran
        {
            get
            {
                return m_Tran;
            }
            set
            {
                m_Tran = value;
            }
        }

        private bool m_TransactionsOnly = true;
        public bool TransactionsOnly
        {
            get
            {
                return m_TransactionsOnly;
            }
            set
            {
                m_TransactionsOnly = value;
            }
        }

        private string m_TransactionName = null;
        public string TransactionName
        {
            get
            {
                return "T"+ m_TransactionNumber.ToString()+"_"+m_TransactionName;
            }
        }

        public bool TransactionIsActive
        {
            get
            {
                if (m_TransactionName != null)
                {
                    return m_TransactionName.Length > 0;
                }
                else
                {
                    return false;
                }
            }

        }


        public long m_TransactionNumber = 0;
        public long TransactionNumber
        {
            get
            {
                return m_TransactionNumber;
            }
        }


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

        public bool Connected
        {
            get
            {
                return (Con != null);
            }
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
            Con = null;
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

        private string m_ConnectionString = null;
        public string ConnectionString
        {
            get
            {
                return m_ConnectionString;
            }
            set
            {
                m_ConnectionString = value;
            }
        }

        public void Open()
        {
            Con.Open();
        }

        public bool BeginTransaction(string transaction_name, ref string transaction_id)
        {
            transaction_id = null;
            if (Connected)
            {
                if (Tran == null)
                {
                    m_TransactionName = transaction_name;
                    m_TransactionNumber++;
                    transaction_id = TransactionName;
                    Tran = Con.BeginTransaction();
                    if (cmd!=null)
                    {
                        cmd.Dispose();
                        cmd = null;
                    }
                    cmd = Con.CreateCommand();
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR::DBConnectionControl40:ConncetionSQLITE:BeginTransaction:Can not begin new Transaction "+transaction_name+"! Transaction:" + TransactionName + " is still active!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:DBConnectionControl40:ConncetionSQLITE::BeginTransaction:Can not begin new Transaction (" + transaction_name + ") if connection is not opened!");
                return false;
            }
        }

        public bool Commit(string transaction_id)
        {
            if (Connected)
            {
                if (Tran != null)
                {
                    if (transaction_id.Equals(TransactionName))
                    {
                        try
                        {
                            Tran.Commit();
                            m_TransactionName = "";
                            if (cmd != null)
                            {
                                cmd.Dispose();
                                cmd = null;
                            }
                            Tran.Dispose();
                            Tran = null;
                            return true;
                        }
                        catch (Exception ex)
                        {
                            LogFile.Error.Show("ERROR:DBConnectionControl40:ConnectionSQLITE:Commit:Transaction:'" + TransactionName + "' commit failed!\r\nException = " + ex.Message);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:ConnectionSQLITE:CommitTransaction " + transaction_id_not_equal(transaction_id));
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:DBConnectionControl40:ConnectionSQLITE:Commit: Commit Transaction without BeginTransatction!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:DBConnectionControl40:ConncetionSQLITE:BeginTransaction:Can not begin new Transaction (" + TransactionName + ") if connection is not opened!");
                return false;
            }
        }

        private string transaction_id_not_equal(string transaction_id)
        {
            return " '"+transaction_id + "' not equal BeginTransaction = '" + TransactionName + "'!";
        }
        public bool RollbackTransaction(string transaction_id)
        {
            if (Connected)
            {
                if (Tran != null)
                {
                    if (transaction_id.Equals(TransactionName))
                    {
                        try
                        {
                            Tran.Rollback();
                            if (cmd != null)
                            {
                                cmd.Dispose();
                                cmd = null;
                            }
                            Tran.Dispose();
                            Tran = null;
                            return true;
                        }
                        catch (Exception ex)
                        {
                            LogFile.Error.Show("ERROR:DBConnectionControl40:ConnectionSQLITE:RollbackTransaction ('" + TransactionName + "') failed!\r\nException = " + ex.Message);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:ConnectionSQLITE:RollbackTransaction '" + transaction_id_not_equal(transaction_id));
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:DBConnectionControl40:ConnectionSQLITE:RollbackTransaction:Tran = null");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:DBConnectionControl40:ConncetionSQLITE:RollbackTransaction:Can not RollbackTransaction (" + TransactionName + ") if connection is not opened!");
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
                if (Con!=null)
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
                if (Con == null)
                {
                    Con = new SQLiteConnection(ConnectionString);
                    Con.Open();
                    ProgramDiagnostic.Diagnostic.Meassure("Connect END", null);
                    return true;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                if (Con!=null)
                {
                    Con.Dispose();
                    Con = null;
                }
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
                if (Con != null)
                {
                    Con.Close();
                    Con.Dispose();
                    Con = null;
                    ProgramDiagnostic.Diagnostic.Meassure("Disconnect END", null);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ProgramDiagnostic.Diagnostic.Meassure("Disconnect END ERROR", null);
                LogFile.Error.Show("Error can not disconnect from:" + ConnectionString + "\n\n Exception = " + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                    if (Connected)
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
                    if (!Connected)
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







        private string SetError(string errheader, StringBuilder sql, SQLiteParameterCollection parameters)
        {
            return SetError(errheader, sql.ToString(), parameters);
        }

        private string SetError(string errheader, string sql, SQLiteParameterCollection parameters)
        {
            return errheader + "\r\nSQL=" + sql + "\r\n\r\nParameters:" + ParametersToString(parameters);
        }

        private string ParametersToString(SQLiteParameterCollection parameters)
        {
            string slines = "";
            foreach(SQLiteParameter par in parameters)
            {
                slines += "\r\n"+DbValueToString(par);
            }
            return slines;
        }

        private string DbValueToString(SQLiteParameter par)
        {
            string s = null;
            switch (par.DbType)
            {
                case DbType.AnsiString:
                    s = "AnsiString:=" +SetValueString(par);
                    break;
                case DbType.AnsiStringFixedLength:
                    s = "AnsiStringFixedLength:=" + SetValueString(par);
                    break;
                case DbType.Binary:
                    s = "Binary:="+ SetValueString(par);
                    break;
                case DbType.Boolean:
                    s = "Boolean:=" +SetValueString(par); 
                    break;
                case DbType.Byte:
                    s = "Byte:=" +SetValueString(par); 
                    break;
                case DbType.Currency:
                    s = "Currency:=" +SetValueString(par); 
                    break;
                case DbType.Date:
                    s = "Date:=" +SetValueString(par); 
                    break;
                case DbType.DateTime:
                    s = "DateTime:=" +SetValueString(par); 
                    break;
                case DbType.DateTime2:
                    s = "DateTime2:=" +SetValueString(par); 
                    break;
                case DbType.DateTimeOffset:
                    s = "DateTimeOffset:=" +SetValueString(par); 
                    break;
                case DbType.Decimal:
                    s = "Decimal:=" +SetValueString(par); 
                    break;
                case DbType.Double:
                    s = "Double:=" +SetValueString(par); 
                    break;
                case DbType.Guid:
                    s = "Guid:=" +SetValueString(par); 
                    break;
                case DbType.Int16:
                    s = "Int16:=" +SetValueString(par); 
                    break;
                case DbType.Int32:
                    s = "Int32:=" +SetValueString(par); 
                    break;
                case DbType.Int64:
                    s = "Int64:=" +SetValueString(par); 
                    break;
                case DbType.Object:
                    s = "Object:=" +SetValueString(par); 
                    break;
                case DbType.SByte:
                    s = "SByte:=" +SetValueString(par); 
                    break;
                case DbType.Single:
                    s = "Single:=" +SetValueString(par); 
                    break;
                case DbType.String:
                    s = "String:=" +SetValueString(par); 
                    break;
                case DbType.StringFixedLength:
                    s = "StringFixedLength:=" +SetValueString(par); 
                    break;
                case DbType.Time:
                    s = "Time:=" +SetValueString(par); 
                    break;
                case DbType.UInt16:
                    s = "UInt16:=" +SetValueString(par); 
                    break;
                case DbType.UInt32:
                    s = "UInt32:=" +SetValueString(par); 
                    break;
                case DbType.UInt64:
                    s = "UInt64:=" +SetValueString(par); 
                    break;
                case DbType.VarNumeric:
                    s = "VarNumeric:=" +SetValueString(par); 
                    break;
                case DbType.Xml:
                    s = "Xml:=" +SetValueString(par); 
                    break;
                default:
                    s = "par.DbType not defined!:=" + SetValueString(par);
                    break;
            }
            return s;
        }

        private string SetValueString(SQLiteParameter par)
        {
            string s = null;
            try
            {
                switch (par.DbType)
                {
                    case DbType.AnsiString:
                        s = "AnsiString:='" + Convert.ToString(par.Value)+"'";
                        break;
                    case DbType.AnsiStringFixedLength:
                        s = "AnsiStringFixedLength:='" + Convert.ToString(par.Value)+"'";
                        break;
                    case DbType.Binary:
                        s = "Binary:=" + ConvertBinaryToString(par.Value);
                        break;
                    case DbType.Boolean:
                        s = "Boolean:=" + SetValueString(par);
                        break;
                    case DbType.Byte:
                        s = "Byte:=" + SetValueString(par);
                        break;
                    case DbType.Currency:
                        s = "Currency:=" + SetValueString(par);
                        break;
                    case DbType.Date:
                        s = "Date:=" + SetValueString(par);
                        break;
                    case DbType.DateTime:
                        s = "DateTime:=" + SetValueString(par);
                        break;
                    case DbType.DateTime2:
                        s = "DateTime2:=" + SetValueString(par);
                        break;
                    case DbType.DateTimeOffset:
                        s = "DateTimeOffset:=" + SetValueString(par);
                        break;
                    case DbType.Decimal:
                        s = "Decimal:=" + SetValueString(par);
                        break;
                    case DbType.Double:
                        s = "Double:=" + SetValueString(par);
                        break;
                    case DbType.Guid:
                        s = "Guid:=" + SetValueString(par);
                        break;
                    case DbType.Int16:
                        s = "Int16:=" + SetValueString(par);
                        break;
                    case DbType.Int32:
                        s = "Int32:=" + SetValueString(par);
                        break;
                    case DbType.Int64:
                        s = "Int64:=" + SetValueString(par);
                        break;
                    case DbType.Object:
                        s = "Object:=" + SetValueString(par);
                        break;
                    case DbType.SByte:
                        s = "SByte:=" + SetValueString(par);
                        break;
                    case DbType.Single:
                        s = "Single:=" + SetValueString(par);
                        break;
                    case DbType.String:
                        s = "String:=" + SetValueString(par);
                        break;
                    case DbType.StringFixedLength:
                        s = "StringFixedLength:=" + SetValueString(par);
                        break;
                    case DbType.Time:
                        s = "Time:=" + SetValueString(par);
                        break;
                    case DbType.UInt16:
                        s = "UInt16:=" + SetValueString(par);
                        break;
                    case DbType.UInt32:
                        s = "UInt32:=" + SetValueString(par);
                        break;
                    case DbType.UInt64:
                        s = "UInt64:=" + SetValueString(par);
                        break;
                    case DbType.VarNumeric:
                        s = "VarNumeric:=" + SetValueString(par);
                        break;
                    case DbType.Xml:
                        s = "Xml:=" + SetValueString(par);
                        break;
                    default:
                        s = "par.DbType not defined!:=";
                        break;
                }
            }
            catch (Exception ex)
            {
                s = "ERROR:Can not convert value to string! Exception = "+ex.Message;
            }
            return s;
        }

        private string ConvertBinaryToString(object value)
        {
            try
            { 
                string s = "null";
                if (value != null)
                {
                    if (value is byte[])
                    {
                        long len = ((byte[])value).Length;
                        s = "ByteArray:Length=" + len.ToString() + ":";
                        for (long l = 0; l < 10; l++)
                        {
                            if (l < len)
                            {
                                if (l == 0)
                                {
                                    s = Convert.ToInt32(((byte[])value)[l]).ToString();
                                }
                                else
                                {
                                    s += "," + Convert.ToInt32(((byte[])value)[l]).ToString();
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (len > 10)
                        {
                            s += ",...";
                        }
                        return s;
                    }
                    else
                    {
                        return Convert.ToString(value);
                    }
                }
                else
                {
                    return s;
                }
            }
            catch (Exception ex)
            {
                return "ConvertBinaryToString failed! Exception ex=" + ex.Message;
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
