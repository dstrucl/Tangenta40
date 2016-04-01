#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadProcessor
{
    public class ThreadP2Ctrl_MessageBox
    {
        private Mutex myMutex = new Mutex();

        private CircularBuffer_ThreadP2Ctrl_Message message_buff = null;

        public ThreadP2Ctrl_MessageBox(int Length)
        {
            message_buff = new CircularBuffer_ThreadP2Ctrl_Message(Length);
        }

        public Result_MessageBox_Get Get(ref ThreadP2Ctrl_Message Message)
        {
            Result_MessageBox_Get res = Result_MessageBox_Get.TIMEOUT;
            if (myMutex.WaitOne(3000))
            {
                if (message_buff.Get(ref Message))
                {
                    if (Message.Message == ThreadP2Ctrl_Message.eMessage.ERROR)
                    {
                        res = Result_MessageBox_Get.ERROR;
                    }
                    else
                    {
                        res = Result_MessageBox_Get.OK;
                    }
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

        public Result_MessageBox_Post Post(ThreadP2Ctrl_Message Message)
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
