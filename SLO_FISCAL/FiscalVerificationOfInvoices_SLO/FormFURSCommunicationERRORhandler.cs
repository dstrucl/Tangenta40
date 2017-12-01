using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class FormFURSCommunicationERRORhandler : Form
    {
        private string errorMessage;

        public FormFURSCommunicationERRORhandler()
        {
        }

        public FormFURSCommunicationERRORhandler(string errorMessage)
        {
            InitializeComponent();
            this.errorMessage = errorMessage;
            lng.s_CheckInternetConnection.Text(btn_CheckInternetConnection);
            lng.s_Error.Text(this.lbl_ErrorMessage,":"+errorMessage);
            lng.s_InvoiceNotSentOK.Text(this);
            lng.s_TryToSendFURSDataAgain.Text(this.btn_TryAagin);
            lng.s_GoToSalesBookInvoice.Text(this.btn_WriteInSalesBook);
            lng.s_InstructionToTryToSendFURSDataAgain.Text(this.lbl_Message);
        }

        private void btn_TryAagin_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Retry;
        }

        private void btn_WriteInSalesBook_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_CheckInternetConnection_Click(object sender, EventArgs e)
        {
            if (LogFile.LogFile.CheckForInternetConnection())
            {
                MessageBox.Show(lng.s_InternetConnectionISOK_maybe_FURS_server_is_not_online.s);
            }
            else
            {
                MessageBox.Show(lng.s_NoInternetConnection.s);
            }
        }


    }
}
