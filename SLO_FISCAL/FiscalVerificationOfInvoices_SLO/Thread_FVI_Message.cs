//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MNet.SLOTaxService.Services;
using System.IO;

using MNet.SLOTaxService;
using MNet.SLOTaxService.Messages;


namespace FiscalVerificationOfInvoices_SLO
{
    public class Thread_FVI_Message
    {

        public enum eMessage {NONE,END,POST_SINGLE_INVOICE,POST_MANY_INVOICES,POST_ECHO, POST_BUSINESSPREMISE}
        private eMessage m_Message;
        private string m_XML_Data;
        private long m_Message_ID;


        public eMessage Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }
        public string XML_Data
        {
            get { return m_XML_Data; }
            set { m_XML_Data = value; }
        }

        public long Message_ID
        {
            get { return m_Message_ID; }
            set { m_Message_ID = value; }
        }

        public string MessageType
        {
            get {
                    switch (m_Message)
                    {
                        case eMessage.NONE:
                            return "eMessage = NONE";
                        case eMessage.END:
                            return "eMessage = END";
                        case eMessage.POST_BUSINESSPREMISE:
                            return "eMessage = POST_BUSINESSPREMISE";
                        case eMessage.POST_ECHO:
                            return "eMessage = POST_ECHO";
                        case eMessage.POST_MANY_INVOICES:
                            return "eMessage = POST_MANY_INVOICES";
                        case eMessage.POST_SINGLE_INVOICE:
                            return "eMessage = POST_SINGLE_INVOICE";
                    }
                return "eMessage = ERROR wrong eMessage in Thread_FVI_Message";
                }

        }

        public Thread_FVI_Message(long xMessage_ID,eMessage xMessage, string xml_data)
        {
            Message = xMessage;
            XML_Data = xml_data;
            Message_ID = xMessage_ID;
        }
        public void Set(long xMessage_ID,eMessage xMessage, string xml_data)
        {
            Message_ID = xMessage_ID;
            Message = xMessage;
            XML_Data = xml_data;
        }
    }
}
