using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using ThreadProcessor;

namespace RPC
{
    public class RPC
    {
        private ThreadP threadp = new ThreadP();
        private int msg_ID = 0;
        private bool SendCompleted = false;

        //example for xrpcd.Function: "http://www.tangenta.si/AddUser.php"

        private void  SendUser(RPCd xrpcd)
        {
            RPCClient wc = new RPCClient(xrpcd);

            var URI = new Uri(xrpcd.Function);

            //If any encoding is needed.
            //wc.Headers["Content-Type"] = "UserData";
            //Or any other encoding type.
            wc.Encoding = System.Text.Encoding.UTF8;

            //If any key needed
            //wc.Headers["KEY"] = "name=Data_To_Be_sent1";

            var bytes = Encoding.UTF8.GetBytes(xrpcd.data);

            string CodedBase64data = Convert.ToBase64String(bytes);

            wc.UploadStringCompleted +=
                new UploadStringCompletedEventHandler(mywc_UploadStringCompleted);

            wc.UploadStringAsync(URI, "POST", CodedBase64data);
        }


        public bool Start(ref string Err)
        {
            return threadp.Start(100, null, null, 100, ref Err);
        }



        public void Execute(RPCd rpcd)
        {
            ThreadP_Message msg = new ThreadP_Message(msg_ID, ThreadP_Message.eMessage.TASK, SendUser_WaitResponse, rpcd);
            threadp.message_box.Post(msg);
        }

        public void End()
        {
            threadp.End();
        }


        private object SendUser_WaitResponse(object o, ref string Err)
        {
            if (o is RPCd)
            {
                SendCompleted = false;
                SendUser((RPCd)o);
                long dtStart = DateTime.Now.Ticks;
                while (!SendCompleted)
                {
                    if (DateTime.Now.Ticks - dtStart > 10000000)
                    {
                        ((RPCd)o).SetResult("ERROR:Timeout SendUser_WaitResponse");
                        return (RPCd)o;
                    }
                }
                return (RPCd)o;
            }
            else
            {
                return null;
            }

        }

        private void mywc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
             string eResult = null;
             SendCompleted = true;
            try
            {
                eResult = (e.Result);
                //e.result fetches you the response against your POST request.         
            }
            catch (Exception exc)
            {
                eResult = exc.ToString();
            }
            ((RPCClient)sender).rpcd.SetResult(eResult);
            ((RPCClient)sender).Dispose();
        }

    }
}

