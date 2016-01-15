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
            lbl_MessageID.Text = msg.Message_ID.ToString();
            txt_MessageXml.Text = msg.XML_Data;
        }

        private void btn_PostMessage_Click(object sender, EventArgs e)
        {
            if (PostMessage!=null)
            {
                PostMessage();
            }
        }
    }
}
