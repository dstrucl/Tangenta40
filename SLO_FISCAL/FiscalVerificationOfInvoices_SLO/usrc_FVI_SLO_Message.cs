using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNet.SLOTaxService.Messages;

namespace FiscalVerificationOfInvoices_SLO
{
    public class usrc_FVI_SLO_Message
    {
        public enum eMessage { NONE, Thread_FVI_START, Thread_FVI_END, FVI_RESPONSE_SINGLE_INVOICE, FVI_RESPONSE_MANY_INVOICES, FVI_RESPONSE_PP, FVI_RESPONSE_ECHO, ERROR }
        private eMessage m_Message;
        private string m_XML_Data;
        private long m_Message_ID;

        private string m_errorMessage;
        private MessageType m_messageType;
        private string m_protectedID;
        private bool m_success;
        private string m_uniqueInvoiceID;
        private string m_barCodeValue;
        private Image m_image_QRCode;


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


        public string ErrorMessage
        {
            get { return m_errorMessage; }
            set { m_errorMessage = value; }
        }

        public MessageType MessageType
        {
            get { return m_messageType; }
        }

        public string ProtectedID
        {
            get { return m_protectedID; }
        }

        public bool Success
        {
            get { return m_success; }
            set { m_success = value; }
        }

        public string UniqueInvoiceID
        {
            get { return m_uniqueInvoiceID; }
        }

        public string BarCodeValue
        {
            get { return m_barCodeValue; }
        }

        public Image Image_QRCode
        {
            get { return m_image_QRCode; }
        }

        public usrc_FVI_SLO_Message(long xMessage_ID, eMessage xMessage, string xml_data)
        {
            Message = xMessage;
            XML_Data = xml_data;
            Message_ID = xMessage_ID;
            m_errorMessage = null;
            m_messageType = MessageType.Unknown;
            m_protectedID = null;
            m_success = false;
            m_uniqueInvoiceID = null;
            m_barCodeValue = null;
            m_image_QRCode = null;
        }

        public void Set(long xMessage_ID, eMessage xMessage, string xml_data)
        {
            Message = xMessage;
            XML_Data = xml_data;
            Message_ID = xMessage_ID;
            m_errorMessage = null;
            m_messageType = MessageType.Unknown;
            m_protectedID = null;
            m_success = false;
            m_uniqueInvoiceID = null;
            m_barCodeValue = null;
            m_image_QRCode = null;
        }

        internal void Do_Dispose()
        {
            Message = usrc_FVI_SLO_Message.eMessage.NONE;
            XML_Data = null;
            m_errorMessage = null;
            m_messageType = MessageType.Unknown;
            m_protectedID = null;
            m_success = false;
            m_uniqueInvoiceID = null;
            m_barCodeValue = null;
            if (m_image_QRCode != null)
            {
                m_image_QRCode.Dispose();
                m_image_QRCode = null;
            }
        }

        internal void Image_QRCode_Dispose()
        {
            if (m_image_QRCode!=null)
            {
                m_image_QRCode.Dispose();
                m_image_QRCode = null;
            }
        }

        internal void Set(long message_ID, eMessage xeMessage, string xml_returned, string errorMessage, MessageType messageType, string protectedID, bool success, string uniqueInvoiceID, string barCodeValue, Image img_QRCode)
        {
            Message = xeMessage;
            XML_Data = xml_returned;
            Message_ID = message_ID;

            m_errorMessage = errorMessage;
            m_messageType = messageType;
            m_protectedID = protectedID;
            m_success = success;
            m_uniqueInvoiceID = uniqueInvoiceID;
            m_barCodeValue = barCodeValue;
            if (img_QRCode !=null)
            {
                m_image_QRCode = (Image)img_QRCode.Clone();
            }
            else
            {
                m_image_QRCode = null;
            }
    }
    }
}
