using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using ThreadProcessor;

namespace LogFile
{
    internal class Add2UserList
    {
        ThreadP threadp = new ThreadP();
        private int msg_ID = 0;
        private bool SendCompleted = false;
        private string eResult = null;

        private void SendUser(string rawdata)
        {
            WebClient wc = new WebClient();

            var URI = new Uri("http://www.tangenta.si/AddUser.php");
            //var URI = new Uri("http://localhost/Tangenta/Users/AddUser.php");


            //If any encoding is needed.
            wc.Headers["Content-Type"] = "UserData";
            //Or any other encoding type.
            wc.Encoding = System.Text.Encoding.UTF8;
            //If any key needed

            //wc.Headers["KEY"] = "name=Data_To_Be_sent1";

            wc.UploadStringCompleted +=
                new UploadStringCompletedEventHandler(mywc_UploadStringCompleted);
            var bytes = Encoding.UTF8.GetBytes(rawdata);
            string CodedBase64data = Convert.ToBase64String(bytes);

            wc.UploadStringAsync(URI, "POST", CodedBase64data);
        }


        internal void Add(string user_data)
        {
            string Err = null;
            if (threadp.Start(100,null, null, 100, ref Err))
            {
                ThreadP_Message msg = new ThreadP_Message(msg_ID, ThreadP_Message.eMessage.TASK, SendUser_WaitResponse, user_data);
                threadp.message_box.Post(msg);
            }
        }

        internal void Stop()
        {
            threadp.End();
        }


        private object SendUser_WaitResponse(object o, ref string Err)
        {
            if (o is string)
            {
                SendCompleted = false;
                SendUser((string)o);
                long dtStart = DateTime.Now.Ticks;
                while (!SendCompleted)
                {
                    if (DateTime.Now.Ticks - dtStart > 10000000)
                    {
                        return null;
                    }
                }
                return this.eResult;
            }
            else
            {
                return null;
            }

        }

        private void mywc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {

            SendCompleted = true;
            try
            {
                this.eResult = (e.Result);
                //e.result fetches you the response against your POST request.         
            }
            catch (Exception exc)
            {
                this.eResult = exc.ToString();
            }
        }

    }
}
