using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalVerificationOfInvoices_SLO
{
    public class usrc_FVI_SLO_Message
    {
        public enum eMessage { NONE, Thread_FVI_START, Thread_FVI_END, FVI_RESPONSE_SINGLE_INVOICE, FVI_RESPONSE_MANY_INVOICES, FVI_RESPONSE_PP, FVI_RESPONSE_ECHO }
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

        public usrc_FVI_SLO_Message(long xMessage_ID, eMessage xMessage, string xml_data)
        {
            Message = xMessage;
            XML_Data = xml_data;
            Message_ID = xMessage_ID;
        }

        public void Set(long xMessage_ID, eMessage xMessage, string xml_data)
        {
            Message = xMessage;
            XML_Data = xml_data;
            Message_ID = xMessage_ID;
        }
    }
}
