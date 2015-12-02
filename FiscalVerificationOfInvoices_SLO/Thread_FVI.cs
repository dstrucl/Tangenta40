using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalVerificationOfInvoices_SLO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class Thread_FVI
    {
        internal bool bEnd = false;
        public Thread_FVI_MessageBox message_box = new Thread_FVI_MessageBox();
            

        private System.Threading.Thread FVI_Thread;

        private void Run(object ousrc_FVI_SLO_MessageBox )
        {
            usrc_FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox = (usrc_FVI_SLO_MessageBox)ousrc_FVI_SLO_MessageBox;
            

            Thread_FVI_Message fvi_message = new Thread_FVI_Message(Thread_FVI_Message.eMessage.NONE,null);
            for (;;)
            {
                if (message_box.Get(ref fvi_message))
                { 
                    switch (fvi_message.Message)
                    {
                        case Thread_FVI_Message.eMessage.POST_ECHO:
                            return;

                        case Thread_FVI_Message.eMessage.POST_INVOICE:
                            break;

                        case Thread_FVI_Message.eMessage.POST_PP:
                            break; 

                        case Thread_FVI_Message.eMessage.END:
                            usrc_FVI_SLO_Message xusrc_FVI_SLO_Message_END = new usrc_FVI_SLO_Message(usrc_FVI_SLO_Message.eMessage.Thread_FVI_END, null);
                            xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message_END);
                            break; 
                    }
                }
            }
        }

        public void End(usrc_FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox)
        {
            usrc_FVI_SLO_Message xusrc_FVI_SLO_Message_END = new usrc_FVI_SLO_Message(usrc_FVI_SLO_Message.eMessage.NONE, null);
            Thread_FVI_Message fvi_message_END = new Thread_FVI_Message(Thread_FVI_Message.eMessage.END, null);
            message_box.Post(fvi_message_END);
            for (;;)
            {
                if (xusrc_FVI_SLO_MessageBox.Get(ref xusrc_FVI_SLO_Message_END))
                { 
                    if (xusrc_FVI_SLO_Message_END.Message == usrc_FVI_SLO_Message.eMessage.Thread_FVI_END)
                    {
                        return;
                    }
                }
            }
        }


        public void Start(usrc_FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox)
        {
            FVI_Thread = new System.Threading.Thread(Run);
            FVI_Thread.SetApartmentState(ApartmentState.STA);
            FVI_Thread.Start(xusrc_FVI_SLO_MessageBox);
        }
    }
}
