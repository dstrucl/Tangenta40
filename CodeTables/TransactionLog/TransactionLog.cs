using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransactionLogDataBaseDef;

namespace TransactionLog
{
    public partial class TransactionLog : Component
    {


        public TransactionLog()
        {
            InitializeComponent();
        }

        public TransactionLog(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public static UserControl AddTransactionLogUserControl(Panel pnlform)
        {
            usrc_TransactionLog xusrc_TransactionLog = new usrc_TransactionLog();
            xusrc_TransactionLog.Visible = true;
            xusrc_TransactionLog.Dock = DockStyle.Fill;
            xusrc_TransactionLog.myDataBase_TransactionsLog = (MyDataBase_TransactionsLog)Transaction.MyDataBase_TransactionsLog;
            pnlform.Controls.Add(xusrc_TransactionLog);
            
            return xusrc_TransactionLog;

        }

        public static bool InitTransactionLogUserControl(object ousrc_TransactionLog)
        {
            usrc_TransactionLog xusrc_TransactionLog = (usrc_TransactionLog)ousrc_TransactionLog;
            return xusrc_TransactionLog.init();
        }
    }
}
