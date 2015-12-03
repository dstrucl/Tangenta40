using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FiscalVerificationOfInvoices_SLO
{
    public enum Result_MessageBox_Get { OK,TIMEOUT,EMPTY};
    public enum Result_MessageBox_Post { OK, TIMEOUT, FULL };

    public class Thread_FVI_MessageBox
    {
        private Mutex myMutex = new Mutex();

        private CircularBuffer_Thread_FVI_Message message_buff = null;

        public Thread_FVI_MessageBox(int Length)
        {
            message_buff = new CircularBuffer_Thread_FVI_Message(Length);
        }

        public Result_MessageBox_Get Get(ref Thread_FVI_Message Message)
        {
            Result_MessageBox_Get res = Result_MessageBox_Get.TIMEOUT;
            if (myMutex.WaitOne(3000))
            {
                if (message_buff.Get(ref Message))
                {
                    res = Result_MessageBox_Get.OK;
                }
                else
                {
                    res = Result_MessageBox_Get.EMPTY;
                }
                myMutex.ReleaseMutex();
            }
            else
            {
                //Timeout !
                res = Result_MessageBox_Get.TIMEOUT;
            }
            return res;
        }

        public Result_MessageBox_Post Post(Thread_FVI_Message Message)
        {
            Result_MessageBox_Post res = Result_MessageBox_Post.TIMEOUT; 
            if (myMutex.WaitOne(3000))
            {
                if (message_buff.PutIn(Message))
                {
                    res = Result_MessageBox_Post.OK;
                }
                else
                {
                    res = Result_MessageBox_Post.FULL;
                }
                myMutex.ReleaseMutex();
            }
            else
            {
                res = Result_MessageBox_Post.TIMEOUT;
            }
            return res;
        }

    }
}
