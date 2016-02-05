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

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class usrc_DEBUG_MessagePreview : UserControl
    {
        public delegate void delegate_Send();
        public event delegate_Send PostMessage = null;

        public delegate void delegate_End();
        public event delegate_End End = null;

        private Thread_FVI_Message msg = null;
        public usrc_DEBUG_MessagePreview()
        {
            InitializeComponent();
        }

        public usrc_DEBUG_MessagePreview(Thread_FVI_Message xmsg)
        {
            InitializeComponent();
            msg = xmsg;
            lbl_MessageType.Text = msg.MessageType;
            txt_MessageID.Text = msg.Message_ID.ToString();
            txt_MessageXml.Text = msg.XML_Data;
        }

        private void btn_PostMessage_Click(object sender, EventArgs e)
        {
            msg.Message_ID = Convert.ToInt32(txt_MessageID.Text);
            msg.XML_Data = txt_MessageXml.Text;
            if (PostMessage!=null)
            {
                PostMessage();
            }
        }

        private void btn_End_Click(object sender, EventArgs e)
        {
            if (End != null)
            {
                End();
            }
        }

        internal void SetResponse(long message_ID, string xML_Data)
        {
            this.txt_Response_MessageID.Text = message_ID.ToString();
            this.txt_Response_XML.Text = xML_Data;
        }
    }
}
