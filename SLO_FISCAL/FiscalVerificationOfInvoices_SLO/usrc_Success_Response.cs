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
    public partial class usrc_Success_Response : UserControl
    {
        public delegate void delegate_do_close();
        public event delegate_do_close do_close = null;

        int iSeconds = 4;

        public usrc_Success_Response()
        {
            InitializeComponent();
        }

        public usrc_Success_Response(MessageType xm_messageType, string ProtectedID, string UniqueInvoiceID,Image img_QR)
        {
            InitializeComponent();
            //m_messageType = xm_messageType;
            lbl_MessageType.Text = messageType_SetString(xm_messageType);
            txt_ProtectID.Text = ProtectedID;
            txt_UniqueInvoiceID.Text = UniqueInvoiceID;
            pic_QR.Image = img_QR;
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

        private void usrc_Success_Response_Load(object sender, EventArgs e)
        {
            iSeconds = Convert.ToInt32(Properties.Settings.Default.timeToShowSuccessfulFURSResult);
            this.lbl_CountDown.Text = iSeconds.ToString();
            timer_Close.Enabled = true;
            timer_Close.Tick += Timer_Close_Tick;

        }

        private void Timer_Close_Tick(object sender, EventArgs e)
        {
            if (iSeconds > 0)
            {
                this.lbl_CountDown.Text = iSeconds.ToString();
                iSeconds--;
            }
            else
            {
                this.lbl_CountDown.Text = iSeconds.ToString();
                if (do_close!=null)
                {
                    do_close();
                }
            }
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
