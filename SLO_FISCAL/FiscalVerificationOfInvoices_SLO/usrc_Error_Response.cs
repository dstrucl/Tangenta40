using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MNet.SLOTaxService.Messages;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class usrc_Error_Response : UserControl
    {
        //private string m_XML_Data;
        //private long m_Message_ID;

        //private string m_errorMessage;
        //private MessageType m_messageType;
        //private string m_protectedID;
        //private bool m_success;
        //private string m_uniqueInvoiceID;
        //private string m_barCodeValue;
        //private Image m_image_QRCode;

        public usrc_Error_Response()
        {
            InitializeComponent();
        }

        public usrc_Error_Response(MessageType xm_messageType, string ErrorMessage)
        {
            InitializeComponent();
            //m_messageType = xm_messageType;
            lbl_MessageType.Text = messageType_SetString(xm_messageType);
            txt_ErrorMessage.Text = ErrorMessage;

        }

        private string messageType_SetString(MessageType m_messageType)
        {
            switch (m_messageType)
            {
                case MessageType.Invoice:
                    return "Invoice (Račun)";
                case MessageType.BusinessPremise:
                    return "BusinessPremise (Podatki o poslovnem prostoru)";
                case MessageType.Echo:
                    return "Echo (Odziv)";
                case MessageType.Unknown:
                    return "Unknown (Neznano)";
            }
            return "???";
        }
    }
}
