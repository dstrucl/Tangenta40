using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransactionLogDataBaseDef;

namespace TransactionLog
{
    public partial class Form_TransactionLog : Form
    {
        private MyDataBase_TransactionsLog myDataBase_TransactionsLog = null;
        private DataTable dt_TransactionsLog = null;
        private DataTable dt_SQLCommand = null;

        public Form_TransactionLog()
        {
            InitializeComponent();
        }

        public Form_TransactionLog(MyDataBase_TransactionsLog xmyDataBase_TransactionsLog)
        {
            InitializeComponent();
            myDataBase_TransactionsLog = xmyDataBase_TransactionsLog;
        }


        private void Form_TransactionLog_Load(object sender, EventArgs e)
        {
            if (!init())
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }

        }

        private bool init()
        {
            string err = null;
            string sql = @"select Number,trn.Name as TransactionName,CreationTime,ActivationTime,CommitTime,RollBackTime, trl.ID from TransactionLog trl inner join TransactionName trn on trl.TransactionName_ID = trn.ID";
            this.dgvx_TransactionLog.DataSource = null;
            if (dt_TransactionsLog!=null)
            {
                dt_TransactionsLog.Dispose();
                dt_TransactionsLog = null;
            }
            dt_TransactionsLog = new DataTable();
            if (myDataBase_TransactionsLog.m_DBTables.Con.ReadDataTable(ref dt_TransactionsLog,sql,ref err))
            {
                this.dgvx_TransactionLog.DataSource = dt_TransactionsLog;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TransactionLog:Form_TransactionLog:init: err=" + err + "\r\nsql=" + sql);
                return false;
            }
        }

        private void dgvx_TransactionLog_SelectionChanged(object sender, EventArgs e)
        {
            if (sender is DataGridView)
            {
                DataGridView dataGridView_Table = (DataGridView)sender;
                DataGridViewSelectedCellCollection dgvCellCollection = dataGridView_Table.SelectedCells;
                if (dgvCellCollection.Count >= 1)
                {
                    //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;

                    if (dgvCellCollection[0].OwningRow.Cells["TransactionName"].Value  is string)
                    {
                        this.txt_TransactionName.Text = (string)dgvCellCollection[0].OwningRow.Cells["TransactionName"].Value;
                        if (dgvCellCollection[0].OwningRow.Cells["ID"].Value is long)
                        {
                            ID transaction_ID = tf.set_ID(dgvCellCollection[0].OwningRow.Cells["ID"].Value);
                            ShowSQLCommands(transaction_ID);
                        }
                    }
                }
                else
                {
                    //lbl_test_sender_type.Text = "Num Selected cels = 0";
                }
            }
        }

        private bool ShowSQLCommands(ID transaction_ID)
        {
            string err = null;
            string sql = @"select cmdt.SQLText as CommandText, ExecutionStart, ExecutionEnd,Error, sqlcmd.ID from SQLCommand sqlcmd inner join CommandText cmdt on sqlcmd.CommandText_ID = cmdt.ID 
                           where TransactionLog_ID = " + transaction_ID.ToString(); 
            this.dgvx_SQLCommand.DataSource = null;
            if (dt_SQLCommand != null)
            {
                dt_SQLCommand.Dispose();
                dt_SQLCommand = null;
            }
            dt_SQLCommand = new DataTable();
            if (myDataBase_TransactionsLog.m_DBTables.Con.ReadDataTable(ref dt_SQLCommand, sql, ref err))
            {
                this.dgvx_SQLCommand.DataSource = dt_SQLCommand;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TransactionLog:Form_TransactionLog:ShowSQLCommands: err=" + err + "\r\nsql=" + sql);
                return false;
            }
        }

        private void dataGridView2xls1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvx_SQLCommand_SelectionChanged(object sender, EventArgs e)
        {

            if (sender is DataGridView)
            {
                DataGridView dataGridView_Table = (DataGridView)sender;
                DataGridViewSelectedCellCollection dgvCellCollection = dataGridView_Table.SelectedCells;
                if (dgvCellCollection.Count >= 1)
                {
                    //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;

                    if (dgvCellCollection[0].OwningRow.Cells["CommandText"].Value is string)
                    {
                        this.tstxt_SQLCommand.Text = (string)dgvCellCollection[0].OwningRow.Cells["CommandText"].Value;
                    }
                }
                else
                {
                    //lbl_test_sender_type.Text = "Num Selected cels = 0";
                }
            }
        }
    }
}
