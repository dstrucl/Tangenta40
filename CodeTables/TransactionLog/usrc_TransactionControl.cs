using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DBConnectionControl40.Transaction;
using DBConnectionControl40;
using TransactionLogDataBaseDef;

namespace TransactionLog
{
    public partial class usrc_TransactionControl : UserControl
    {
        private Form_TransactionLog frm_transactionLog = null;
        private MyDataBase_TransactionsLog dataBase_TransactionsLog = null;
        public MyDataBase_TransactionsLog DataBase_TransactionsLog
        {
            get
            {
                return dataBase_TransactionsLog;
            }
            set
            {
                dataBase_TransactionsLog = value;
            }
        }

        public usrc_TransactionControl()
        {
            InitializeComponent();
            this.pictureBox1.Image = Properties.Resources.DBDisconnected;
            DBConnection.Delegate_SetState = SetConnectionState;
        }

        ~usrc_TransactionControl()
        {
            if (frm_transactionLog!=null)
            {
                if (!frm_transactionLog.IsDisposed)
                {
                    frm_transactionLog.Close();
                    frm_transactionLog.Dispose();
                }
            }
        }

        private eConnectionState m_State = eConnectionState.DICSONNECTED;
        public eConnectionState State
        {
            get
            {
                return m_State;
            }
            set
            {
                m_State = value;
                switch (m_State)
                {
                    case eConnectionState.DICSONNECTED:
                        this.pictureBox1.Image = Properties.Resources.DBDisconnected;
                        break;
                    case eConnectionState.CONNECTED:
                        this.pictureBox1.Image = Properties.Resources.DBConnection;
                        break;
                    case eConnectionState.CONNECTED_TRANSACTION_COMMITED:
                        this.pictureBox1.Image = Properties.Resources.DBConnectedTransactionCommited;
                        break;
                    case eConnectionState.CONNECTED_TRANSACTION_ROLLBACKED:
                        this.pictureBox1.Image = Properties.Resources.DBConnectedTransactionFailed;
                        break;
                }
                this.pictureBox1.Refresh();
                Application.DoEvents();
            }
        }

        public void SetConnectionState(eConnectionState eConnectionState)
        {
            State = eConnectionState;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (DataBase_TransactionsLog!=null)
            {
                if (frm_transactionLog!=null)
                {
                    if (!frm_transactionLog.IsDisposed)
                    {
                        frm_transactionLog.Close();
                        frm_transactionLog.Dispose();
                    }
                }
                frm_transactionLog = new Form_TransactionLog(DataBase_TransactionsLog);
                frm_transactionLog.Show(this);
            }
        }
    }
}
