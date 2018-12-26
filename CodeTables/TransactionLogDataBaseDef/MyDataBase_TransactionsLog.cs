using CodeTables;
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionLogDataBaseDef
{
    public partial class MyDataBase_TransactionsLog
    {
        //        public DBTypes.SQL_Database_Tables_Definition mt_DB;
        public const string DataBaseFilePrefix = "TangentaDB";

        public TransactionLogTableClass.SQL_Database_Tables_Definition mt;

        public DBTableControl m_DBTables = null;

        public DBTableControl m_DBLogTables = null;

        public TransactionLog_delegates MyTransactionLog_delegates = null;

        public MyDataBase_TransactionsLog(Form pForm, string XmlRootName, string xmlIniFileFolder)
        {
            // TODO: Complete member initialization
            mt = new TransactionLogTableClass.SQL_Database_Tables_Definition();

            m_DBTables = new DBTableControl(pForm, XmlRootName, xmlIniFileFolder);

            //            Define_Image_SQL_Database_Tables();

            //            Define_Document_SQL_Database_Tables();

            Define_SQL_Database_Tables();

            MyTransactionLog_delegates = new TransactionLog_delegates(WriteTransactionLog_BeginTransaction,
                                                                      WriteTransactionLogExecute,
                                                                      WriteTransactionLog_Commit,
                                                                      WriteTransactionLog_Rollback);
        }



        public DBConnection.eDBType DBType
        {

            get { return m_DBTables.Con.DBType; }
            set { m_DBTables.Con.DBType = value; }

        }


        public DBTableControl.enumDataBaseCheckResult CheckDatabase(Form pParentForm, ref string csError)
        {
            Transaction transaction_CheckDatabase = new Transaction(null,"CheckDatabase");
            DBTableControl.enumDataBaseCheckResult eres = m_DBTables.DataBaseCheck(ref csError, transaction_CheckDatabase);
            switch (eres)
            {
                case DBTableControl.enumDataBaseCheckResult.OK:
                    transaction_CheckDatabase.Commit();
                    break;
                default:
                    transaction_CheckDatabase.Rollback();
                    break;
            }
            return eres;
        }

        public bool CheckConnection(Form pParentForm, Object DB_Param)
        {
            return m_DBTables.Con.CheckConnection(DB_Param);
        }

        public bool Restore(string full_backup_filename)
        {
            return m_DBTables.Con.DataBase_Restore(full_backup_filename);
        }


        public void Init(DBConnection.eDBType eDBType)
        {
            this.m_DBTables.Init(eDBType,"Log", VERSION);
        }

        public bool DropViews(ref string Err, Transaction transaction)
        {
            return this.m_DBTables.DropVIEWs(ref Err, transaction);
        }

        public bool Create_VIEWs(Transaction transaction)
        {
            return this.m_DBTables.Create_VIEWs(transaction);
        }

        public bool BeginTransaction(string transaction_name, ref string transaction_id)
        {
            return m_DBTables.Con.BeginTransaction(transaction_name, ref transaction_id);
        }

        public bool CommitTransaction(string transaction_id)
        {
            return m_DBTables.Con.CommitTransaction(transaction_id);
        }

        public bool RollbackTransaction(string transaction_id)
        {
            return m_DBTables.Con.RollbackTransaction(transaction_id);
        }


        public bool DataBase_Backup(string full_backup_filename)
        {
            return this.m_DBTables.DataBase_Backup(full_backup_filename);
        }

        public bool DataBase_Restore(string full_backup_filename)
        {
            return this.m_DBTables.DataBase_Restore(full_backup_filename);
        }

        public bool DataBase_Make_BackupTemp()
        {
            return this.m_DBTables.DataBase_Make_BackupTemp();
        }

        public bool DataBase_Delete_BackupTemp()
        {
            return this.m_DBTables.DataBase_Delete_BackupTemp();
        }

        public bool DataBase_Delete()
        {
            return this.m_DBTables.DataBase_Delete();
        }

        public bool DataBase_Create(Transaction transaction)
        {
            if (this.m_DBTables.DataBase_Create(transaction))
            {
                bool bxCancel = false;
                return this.m_DBTables.CreateDatabaseTables(false,"", ref bxCancel, MyDataBase_TransactionsLog.VERSION, transaction);
            }
            else
            {
                return false;
            }
        }
    }
}
