using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnectionControl40
{
    public partial class Form_TransactionBreakDialog_Activate : Form
    {
        public Form_TransactionBreakDialog_Activate(Transaction transaction)
        {
            InitializeComponent();
            this.txt_TransactionName.Text = transaction.Name;
            if (transaction.TransactionSQLCommandList!=null)
            {
                if (transaction.TransactionSQLCommandList.Count>0)
                {
                    this.fsttxt_SQLCommand.Text = transaction.TransactionSQLCommandList[0].SQLtext;
                }
            }
        }

        private void btn_NEXT_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
