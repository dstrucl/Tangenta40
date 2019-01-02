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
              

        public Form_TransactionLog()
        {
            InitializeComponent();
        }
       
        public Form_TransactionLog(MyDataBase_TransactionsLog xmyDataBase_TransactionsLog)
        {
            InitializeComponent();
            this.usrc_TransactionLog1.myDataBase_TransactionsLog = xmyDataBase_TransactionsLog;
        }


        private void Form_TransactionLog_Load(object sender, EventArgs e)
        {
            if (!usrc_TransactionLog1.init())
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }
    }
}
