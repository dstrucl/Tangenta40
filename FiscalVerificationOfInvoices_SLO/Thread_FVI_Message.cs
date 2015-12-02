using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FiscalVerificationOfInvoices_SLO
{
    public class Thread_FVI_Message
    {

        public enum eMessage {NONE,END,POST_INVOICE,POST_PP,POST_ECHO}
        public eMessage Message;
        public string XML_Data;
        public Thread_FVI_Message(eMessage xMessage, string xml_data)
        {
            Message = xMessage;
            XML_Data = xml_data;
        }

    }
}
