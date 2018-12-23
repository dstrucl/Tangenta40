using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLogDataBaseDef;

namespace TransactionLog
{
    public partial class TransactionLog : Component
    {
        MyDataBase_TransactionsLog DB_TransactionsLog = null;

        public TransactionLog()
        {
            InitializeComponent();
        }

        public TransactionLog(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
