using System;
using System.Drawing;
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
        public bool DEBUG = false;
        public string certificateFileName = null;
        public string CertPass = null;
        public string fursWebServiceURL = null;
        public string fursXmlNamespace = null;
        public int timeOutInSec = 0;


        private FormFURSCommunication FormFURSCommunicationForm = null;

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

        internal Thread_FVI thread_fvi = new Thread_FVI();

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

        public bool Start(string xcertificateFileName, string xCertPass, string xfursWebServiceURL, string xfursXmlNamespace, int xtimeOutInSec, Control ParentForm, ref string ErrReason)
        {
            if (!bRun)
            {
                message_box = new usrc_FVI_SLO_MessageBox(MessageBox_Length);
                thread_fvi.Start(message_box, MessageBox_Length, xcertificateFileName, xCertPass, xfursWebServiceURL, xfursXmlNamespace, xtimeOutInSec, ref ErrReason);
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

        public bool Start(ref string ErrReason)
        {
            

            //Properties.Settings.Default.Save();  //shranis setings


            if (!bRun)
            {
                message_box = new usrc_FVI_SLO_MessageBox(MessageBox_Length);

                DialogResult dlgResult = DialogResult.None;
                while (dlgResult != DialogResult.Cancel)
                {
                    DEBUG = Properties.Settings.Default.DEBUG;
                    certificateFileName = Properties.Settings.Default.certificateFileName;
                    CertPass = Properties.Settings.Default.CertPass;
                    fursWebServiceURL = Properties.Settings.Default.fursWebServiceURL;
                    fursXmlNamespace = Properties.Settings.Default.fursXmlNamespace;
                    timeOutInSec = Properties.Settings.Default.timeOutInSec;
                    if (thread_fvi.Start(message_box, MessageBox_Length, certificateFileName, CertPass, fursWebServiceURL, fursXmlNamespace, timeOutInSec, ref ErrReason))
                    {
                        timer_MessagePump.Enabled = true;
                        bRun = true;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(ErrReason);
                        Form_Settings fvi_settings = new Form_Settings(this);
                        dlgResult = fvi_settings.ShowDialog();
                    }
                }
                return false;
            }
            else
            {
                ErrReason = "0 Not run";
                return false;
            }
        }

        public Result_MessageBox_Post Send_SingleInvoice(string xml, Control ParentForm, ref string UniqeMsgID, ref string UniqueInvID, ref Image Image_QR)
        {
            LastMessageID++;

            Thread_FVI_Message msg = new Thread_FVI_Message(LastMessageID, Thread_FVI_Message.eMessage.POST_SINGLE_INVOICE, xml);
            WaitForm = new FormWait(this, msg);
            WaitForm.ShowDialog();
            return WaitForm.RetFromWaitForm;

        }

        public Result_MessageBox_Post Send_ManyInvoices(long Message_ID, string xml)
        {
            LastMessageID++;

            Thread_FVI_Message msg = new Thread_FVI_Message(LastMessageID, Thread_FVI_Message.eMessage.POST_MANY_INVOICES, xml);
            FormFURSCommunicationForm = new FormFURSCommunication(this, msg);
            FormFURSCommunicationForm.ShowDialog();
            return FormFURSCommunicationForm.RetFromWaitForm;

        }

        public Result_MessageBox_Post Send_PP(long Message_ID, string xml)
        {
            LastMessageID++;

            Thread_FVI_Message msg = new Thread_FVI_Message(LastMessageID, Thread_FVI_Message.eMessage.POST_BUSINESSPREMISE, xml);
            FormFURSCommunicationForm = new FormFURSCommunication(this, msg);
            FormFURSCommunicationForm.ShowDialog();
            return FormFURSCommunicationForm.RetFromWaitForm;

        }

        public Result_MessageBox_Post Send_Echo(long Message_ID, string xml)
        {
            LastMessageID++;
            Thread_FVI_Message msg = new Thread_FVI_Message(LastMessageID, Thread_FVI_Message.eMessage.POST_ECHO, xml);
            FormFURSCommunicationForm = new FormFURSCommunication(this, msg);
            FormFURSCommunicationForm.ShowDialog();
            return FormFURSCommunicationForm.RetFromWaitForm;

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
                            if (FormFURSCommunicationForm != null)
                            {
                                if (FormFURSCommunicationForm.FVI_Response_ECHO(message.Message_ID,
                                                                         message.XML_Data,
                                                                         message.Success,
                                                                         message.MessageType,
                                                                         message.ErrorMessage
                                                                         ))
                                {
                                }
                            }
                            if (Response_ECHO!=null)
                            {
                                Response_ECHO(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_SINGLE_INVOICE:
                            if (FormFURSCommunicationForm != null)
                            {
                                if (FormFURSCommunicationForm.FVI_Response_Single_Invoice(message.Message_ID,
                                                                         message.XML_Data,
                                                                         message.Success,
                                                                         message.MessageType,
                                                                         message.ErrorMessage,
                                                                         message.ProtectedID,
                                                                         message.UniqueInvoiceID,
                                                                         message.Image_QRCode
                                                                         ))
                                {
                                }
                            }
                            if (Response_SingleInvoice!=null)
                            {
                                Response_SingleInvoice(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_MANY_INVOICES:
                            if (FormFURSCommunicationForm != null)
                            {
                                if (FormFURSCommunicationForm.FVI_Response_Many_Invoice(message.Message_ID,
                                                                         message.XML_Data,
                                                                         message.Success,
                                                                         message.MessageType,
                                                                         message.ErrorMessage,
                                                                         message.ProtectedID,
                                                                         message.UniqueInvoiceID,
                                                                         message.Image_QRCode
                                                                         ))
                                {
                                }
                            }

                            if (Response_ManyInvoices!=null)
                            {
                                Response_ManyInvoices(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_PP:

                            if (FormFURSCommunicationForm.FVI_Response_PP(message.Message_ID,
                                                                     message.XML_Data,
                                                                     message.Success,
                                                                     message.MessageType,
                                                                     message.ErrorMessage
                                                                     ))
                            {
                            }
    

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

        private void btn_FVI_Click(object sender, EventArgs e)
        {
            Form_Settings fvi_man = new Form_Settings(this);
            fvi_man.ShowDialog();
        }
    }
}
