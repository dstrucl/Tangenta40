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
        private bool bRun = false;
        internal usrc_FVI_SLO_MessageBox message_box = null;

        private Thread_FVI thread_fvi = new Thread_FVI();

        private usrc_FVI_SLO_Message message = new usrc_FVI_SLO_Message(usrc_FVI_SLO_Message.eMessage.NONE, null);

        private int m_message_box_length = 100;

        public int MessageBox_Length
        {
            get { return m_message_box_length; }
            set { m_message_box_length = value; }
        }

        public usrc_FVI_SLO()
        {
            InitializeComponent();
            btn_FVI.Enabled = false;
        }

        private void usrc_FVI_SLO_Load(object sender, EventArgs e)
        {
        }

        public bool Start()
        {
            if (!bRun)
            {
                message_box = new usrc_FVI_SLO_MessageBox(MessageBox_Length);
                thread_fvi.Start(message_box, MessageBox_Length);
                timer_MessagePump.Enabled = true;
                bRun = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool End()
        {
            if (bRun)
            {
                bRun = false;
                timer_MessagePump.Enabled = false;
                thread_fvi.End(message_box);
                return true;
            }
            else
            {
                return false;
            }

        }


        private void timer_MessagePump_Tick(object sender, EventArgs e)
        {
            switch (message_box.Get(ref message))
            {
                case Result_MessageBox_Get.OK:
                    switch (message.Message)
                    {
                        case usrc_FVI_SLO_Message.eMessage.Thread_FVI_START:
                            btn_FVI.Enabled = true;
                            break;
                        case usrc_FVI_SLO_Message.eMessage.Thread_FVI_END:
                            btn_FVI.Enabled = false;
                            bRun = false;
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_ECHO:
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_INVOICE:
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_PP:
                            break;
                    }
                    break;
                case Result_MessageBox_Get.EMPTY:
                    break;
                case Result_MessageBox_Get.TIMEOUT:
                    break;

            }
        }
    }
}
