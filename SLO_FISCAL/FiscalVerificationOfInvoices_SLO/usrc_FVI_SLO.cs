using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;




namespace FiscalVerificationOfInvoices_SLO
{
    public partial class usrc_FVI_SLO : UserControl
    {

        public delegate void delegate_Response_SingleInvoice(long Message_ID, string xml);
        public delegate void delegate_Response_ManyInvoices(long Message_ID, string xml);
        public delegate void delegate_Response_PP(long Message_ID, string xml);
        public delegate void delegate_Response_ECHO(long Message_ID, string xml);

        public event delegate_Response_SingleInvoice Response_SingleInvoice = null;
        public event delegate_Response_ManyInvoices Response_ManyInvoices = null;
        public event delegate_Response_PP Response_PP = null;
        public event delegate_Response_ECHO Response_ECHO = null;

        private bool bRun = false;
        internal usrc_FVI_SLO_MessageBox message_box = null;

        private Thread_FVI thread_fvi = new Thread_FVI();

        private usrc_FVI_SLO_Message message = new usrc_FVI_SLO_Message(0,usrc_FVI_SLO_Message.eMessage.NONE, null);

        private int m_message_box_length = 100;
        private long LastMessageID = 0;

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

        public bool Start(string certificateFileName, string CertPass, string fursWebServiceURL, string fursXmlNamespace, int timeOutInSec, ref string ErrReason)
        {
            if (!bRun)
            {
                message_box = new usrc_FVI_SLO_MessageBox(MessageBox_Length);
                thread_fvi.Start(message_box, MessageBox_Length,  certificateFileName,  CertPass,  fursWebServiceURL,  fursXmlNamespace,  timeOutInSec, ref  ErrReason);
                timer_MessagePump.Enabled = true;
                bRun = true;
                return true;
            }
            else
            {
                ErrReason = "0 Not run";
                return false;
            }
        }

        public Result_MessageBox_Post Send_SingleInvoice(string xml, Control ParentForm, ref string UniqeMsgID, ref string UniqueInvID)
        {
            LastMessageID ++;

            Thread_FVI_Message msg = new Thread_FVI_Message(LastMessageID, Thread_FVI_Message.eMessage.POST_SINGLE_INVOICE, xml);
            return thread_fvi.message_box.Post(msg);

        }

        public Result_MessageBox_Post Send_ManyInvoices(long Message_ID, string xml)
        {
            Thread_FVI_Message msg = new Thread_FVI_Message(Message_ID, Thread_FVI_Message.eMessage.POST_MANY_INVOICES, xml);
            return thread_fvi.message_box.Post(msg);

        }

        public Result_MessageBox_Post Send_PP(long Message_ID, string xml)
        {
            Thread_FVI_Message msg = new Thread_FVI_Message(Message_ID, Thread_FVI_Message.eMessage.POST_BUSINESSPREMISE, xml);
            return thread_fvi.message_box.Post(msg);

        }

        public Result_MessageBox_Post Send_Echo(long Message_ID, string xml)
        {
            Thread_FVI_Message msg = new Thread_FVI_Message(Message_ID, Thread_FVI_Message.eMessage.POST_ECHO, xml);
            return thread_fvi.message_box.Post(msg);
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
                            if (Response_ECHO!=null)
                            {
                                Response_ECHO(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_SINGLE_INVOICE:
                            if (Response_SingleInvoice!=null)
                            {
                                Response_SingleInvoice(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_MANY_INVOICES:
                            if (Response_ManyInvoices!=null)
                            {
                                Response_ManyInvoices(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_PP:
                            if (Response_PP != null)
                            {
                                Response_PP(message.Message_ID, message.XML_Data);
                            }
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
