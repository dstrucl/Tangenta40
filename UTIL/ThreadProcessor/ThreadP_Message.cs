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
    public class ThreadP_Message
    {

        public enum eMessage {NONE,END,TASK}
        private eMessage m_Message;
        public delegate object delegate_Procedure(object o, ref string Err);
        private delegate_Procedure m_Procedure;
        private object m_ParameterAsObject = null;

        private long m_Message_ID;
        public long Message_ID
        {
            get { return m_Message_ID; }
            set { m_Message_ID = value; }
        }


        public eMessage Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }

        public delegate_Procedure Procedure
        {
            get { return m_Procedure; }
            set { m_Procedure = value; }
        }

        public object ParameterAsObject
        {
            get { return m_ParameterAsObject; }
            set { m_ParameterAsObject = value; }
        }

        public string MessageType
        {
            get {
                    switch (m_Message)
                    {
                        case eMessage.NONE:
                            return "eMessage = NONE";
                        case eMessage.END:
                            return "eMessage = END";
                        case eMessage.TASK:
                            return "eMessage = TASK";
                    }
                return "eMessage = ERROR wrong eMessage in ThreadP_Message";
                }

        }

        public ThreadP_Message(long xMessage_ID,eMessage xMessage, delegate_Procedure procedure, object parameterasobject)
        {
            Message = xMessage;
            Message_ID = xMessage_ID;
            m_Procedure = procedure;
            m_ParameterAsObject = parameterasobject;
        }

        public void Set(long xMessage_ID,eMessage xMessage, delegate_Procedure procedure, object parameterasobject)
        {
            Message_ID = xMessage_ID;
            Message = xMessage;
            m_ParameterAsObject = procedure;
            m_ParameterAsObject = parameterasobject;
        }
    }
}
