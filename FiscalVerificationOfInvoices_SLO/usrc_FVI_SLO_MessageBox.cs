using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FiscalVerificationOfInvoices_SLO
{
    public class usrc_FVI_SLO_MessageBox
    {
        private Mutex myMutex = new Mutex();

        private List<usrc_FVI_SLO_Message> Message_List = new List<usrc_FVI_SLO_Message>();

        public bool Get(ref usrc_FVI_SLO_Message Message)
        {
            bool bRet = false;
            if (myMutex.WaitOne(3000))
            {
                if (Message_List.Count > 0)
                {
                    Message.Message = Message_List[0].Message;
                    Message.XML_Data = Message_List[0].XML_Data;
                    Message_List.RemoveAt(0);
                    bRet = true;
                }
                myMutex.ReleaseMutex();
            }
            else
            {
                //Timeout !
                return false;
            }
            return bRet;
        }

        public bool Post(usrc_FVI_SLO_Message Message)
        {
            bool bRet = false;
            if (myMutex.WaitOne(3000))
            {
                Message_List.Add(Message);
                bRet = true;
                myMutex.ReleaseMutex();
            }
            else
            {

                return false;
            }
            return bRet;
        }

    }
}
