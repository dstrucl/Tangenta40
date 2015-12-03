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
        public Thread_FVI_MessageBox message_box = null;
            

        private System.Threading.Thread FVI_Thread;

        private void Run(object ousrc_FVI_SLO_MessageBox )
        {
            usrc_FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox = (usrc_FVI_SLO_MessageBox)ousrc_FVI_SLO_MessageBox;
            Thread_FVI_Message fvi_message = new Thread_FVI_Message(Thread_FVI_Message.eMessage.NONE,null);
            usrc_FVI_SLO_Message xusrc_FVI_SLO_Message = new usrc_FVI_SLO_Message(usrc_FVI_SLO_Message.eMessage.Thread_FVI_START, null);
            xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
            for (;;)
            {
                switch (message_box.Get(ref fvi_message))
                {
                    case Result_MessageBox_Get.OK:
                        switch (fvi_message.Message)
                        {
                            case Thread_FVI_Message.eMessage.POST_ECHO:
                                return;

                            case Thread_FVI_Message.eMessage.POST_INVOICE:
                                break;

                            case Thread_FVI_Message.eMessage.POST_PP:
                                break; 

                            case Thread_FVI_Message.eMessage.END:
                                xusrc_FVI_SLO_Message.Set(usrc_FVI_SLO_Message.eMessage.Thread_FVI_END, null);
                                xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
                                return;
                        }
                        break;
                    case Result_MessageBox_Get.TIMEOUT:
                        break;
                }
            }
        }

        public bool End(usrc_FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox)
        {
            usrc_FVI_SLO_Message xusrc_FVI_SLO_Message_END = new usrc_FVI_SLO_Message(usrc_FVI_SLO_Message.eMessage.NONE, null);
            Thread_FVI_Message fvi_message_END = new Thread_FVI_Message(Thread_FVI_Message.eMessage.END, null);
            message_box.Post(fvi_message_END);
            long StartTicks = DateTime.Now.Ticks;
            for (;;)
            {
                if (xusrc_FVI_SLO_MessageBox.Get(ref xusrc_FVI_SLO_Message_END)== Result_MessageBox_Get.OK)
                { 
                    if (xusrc_FVI_SLO_Message_END.Message == usrc_FVI_SLO_Message.eMessage.Thread_FVI_END)
                    {
                        return true;
                    }
                }
                if ((DateTime.Now.Ticks- StartTicks)>100000000)
                {
                    return false;
                }
            }
        }


        public void Start(usrc_FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox,int message_box_length)
        {
            message_box = new Thread_FVI_MessageBox(message_box_length);
            FVI_Thread = new System.Threading.Thread(Run);
            FVI_Thread.SetApartmentState(ApartmentState.STA);
            FVI_Thread.Start(xusrc_FVI_SLO_MessageBox);
        }
    }
}
