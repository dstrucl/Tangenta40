using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class usrc_FVI_SLO : UserControl
    {
        internal usrc_FVI_SLO_MessageBox message_box = new usrc_FVI_SLO_MessageBox();

        private Thread_FVI thread_fvi = new Thread_FVI();

        private usrc_FVI_SLO_Message message = new usrc_FVI_SLO_Message(usrc_FVI_SLO_Message.eMessage.NONE, null);

        public usrc_FVI_SLO()
        {
            InitializeComponent();
        }

        private void usrc_FVI_SLO_Load(object sender, EventArgs e)
        {
            thread_fvi.Start(message_box);
        }

        private void timer_MessagePump_Tick(object sender, EventArgs e)
        {
            if (message_box.Get(ref message))
            {
                switch (message.Message)
                {
                    case usrc_FVI_SLO_Message.eMessage.Thread_FVI_END:
                        break;

                    case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_ECHO:
                        break;

                    case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_INVOICE:
                        break;

                    case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_PP:
                        break;
                }
            }
        }
    }
}
