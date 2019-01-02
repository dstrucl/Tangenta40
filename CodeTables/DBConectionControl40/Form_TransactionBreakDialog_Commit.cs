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
    public partial class Form_TransactionBreakDialog_Commit : Form
    {
        UserControl usrccontrol = null;
        public Form_TransactionBreakDialog_Commit(Transaction transaction)
        {
            InitializeComponent();
            this.txt_TransactionName.Text = transaction.Name;
            if (Transaction.Delegate_AddTransactionLogUserControl!=null)
            {
                usrccontrol = Transaction.Delegate_AddTransactionLogUserControl(this.panel1);
                
            }
        }

        private void btn_NEXT_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void Form_TransactionBreakDialog_Commit_Load(object sender, EventArgs e)
        {
            if (usrccontrol!=null)
            {
                if (Transaction.Delegate_InitTransactionLogUserControl(usrccontrol))
                {
                    return;
                }
            }
            this.Close();
            DialogResult = DialogResult.Abort;
        }
    }
}
