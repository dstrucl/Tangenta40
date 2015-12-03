using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalVerificationOfInvoices_SLO
{
    public class usrc_FVI_SLO_Message
    {
        public enum eMessage { NONE, Thread_FVI_START, Thread_FVI_END, FVI_RESPONSE_INVOICE, FVI_RESPONSE_PP, FVI_RESPONSE_ECHO }
        public eMessage Message;
        public string XML_Data;
        public usrc_FVI_SLO_Message(eMessage xMessage, string xml_data)
        {
            Message = xMessage;
            XML_Data = xml_data;
        }

        public void Set(eMessage xMessage, string xml_data)
        {
            Message = xMessage;
            XML_Data = xml_data;
        }
    }
}
