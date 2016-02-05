#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

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
        public delegate void delegate_do_close();
        public event delegate_do_close do_close = null;


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

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (do_close != null)
            {
                do_close();
            }
        }
    }
}
