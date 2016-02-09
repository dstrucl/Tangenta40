using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadProcessor
{
    public class ThreadP
    {
        internal bool bEnd = false;
        public ThreadP_MessageBox message_box = null;
        public ThreadP2Ctrl_MessageBox m_ThreadP2Ctrl_MessageBox = null;
        private System.Threading.Thread FVI_Thread;

        public class ThreadData
        {
            public ThreadP_Message.delegate_Procedure Procedure = null;
            public object ParameterAsObject = null;
            public int timeOutInSec = 0;
            public ThreadP2Ctrl_MessageBox m_ThreadP2Ctrl_MessageBox = null;
            public ThreadData(ThreadP_Message.delegate_Procedure procedure,object xParameterAsObject, int xtimeOutInSec, ThreadP2Ctrl_MessageBox x_ThreadP2Ctrl_MessageBox)
            {
                Procedure = procedure;
                ParameterAsObject = xParameterAsObject;
                timeOutInSec = xtimeOutInSec;
                m_ThreadP2Ctrl_MessageBox = x_ThreadP2Ctrl_MessageBox;

            }
        }


        private void Run(object othdata)
        {

            ThreadData thdata = (ThreadData)othdata;
            ThreadP2Ctrl_MessageBox xThreadP2Ctrl_MessageBox = thdata.m_ThreadP2Ctrl_MessageBox;
            ThreadP_Message p_message = new ThreadP_Message(0, ThreadP_Message.eMessage.NONE, null,null);
            ThreadP2Ctrl_Message xThreadP2Ctrl_Message = new ThreadP2Ctrl_Message(0, ThreadP2Ctrl_Message.eMessage.START, null,null,null);
            xThreadP2Ctrl_MessageBox.Post(xThreadP2Ctrl_Message);
            for (;;)
            {
                switch (message_box.Get(ref p_message))
                {
                    case Result_MessageBox_Get.OK:
                        switch (p_message.Message)
                        {

                            case ThreadP_Message.eMessage.TASK:
                                ThreadP_Message.delegate_Procedure proc = p_message.Procedure;
                                object oParam = p_message.ParameterAsObject;
                                string Err = null;
                                object oResult = proc(oParam, ref Err);
                                xThreadP2Ctrl_Message.Set(0, ThreadP2Ctrl_Message.eMessage.MESSAGE, proc, oResult, Err);
                                xThreadP2Ctrl_MessageBox.Post(xThreadP2Ctrl_Message);
                                break;


                            case ThreadP_Message.eMessage.END:
                                xThreadP2Ctrl_Message.Set(0, ThreadP2Ctrl_Message.eMessage.END, null,null,null);
                                xThreadP2Ctrl_MessageBox.Post(xThreadP2Ctrl_Message);
                                return;
                        }
                        break;
                    case Result_MessageBox_Get.TIMEOUT:
                        break;
                }
            }
        }


        public bool End()
        {
            ThreadP2Ctrl_Message xThreadP2Ctrl_Message_END = new ThreadP2Ctrl_Message(0, ThreadP2Ctrl_Message.eMessage.NONE, null,null,null);
            ThreadP_Message ThreadP_message_END = new ThreadP_Message(0, ThreadP_Message.eMessage.END, null,null);
            message_box.Post(ThreadP_message_END);
            long StartTicks = DateTime.Now.Ticks;

            for (;;)
            {
                if (m_ThreadP2Ctrl_MessageBox.Get(ref xThreadP2Ctrl_Message_END) == Result_MessageBox_Get.OK)
                {
                    if (xThreadP2Ctrl_Message_END.Message == ThreadP2Ctrl_Message.eMessage.END)
                    {
                        return true;
                    }
                }
                if ((DateTime.Now.Ticks - StartTicks) > 100000000)
                {
                    return false;
                }
            }
        }


        public bool Start(int message_box_length, ThreadP_Message.delegate_Procedure proc, object xparam, int timeOutInSec, ref string ErrReason)
        {
            try
            {
                m_ThreadP2Ctrl_MessageBox = new ThreadP2Ctrl_MessageBox(message_box_length);
                ThreadData thdata = new ThreadData(proc, xparam, timeOutInSec, m_ThreadP2Ctrl_MessageBox);
                message_box = new ThreadP_MessageBox(message_box_length);
                FVI_Thread = new System.Threading.Thread(Run);
                FVI_Thread.SetApartmentState(ApartmentState.STA);
                FVI_Thread.Start(thdata);
                return true;
            }
            catch (Exception ex)
            {
                ErrReason = ex.Message;
                return false;
            }
        }

    }
}
