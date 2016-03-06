#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadProcessor
{
    public class ThreadP2Ctrl_Message
    {
        public enum eMessage { NONE, START, END, MESSAGE, ERROR }
        private eMessage m_Message;
        private object m_oResult;
        private ThreadP_Message.delegate_Procedure m_Procedure;
        private string m_ErrorMessage = null;
        private long m_Message_ID;



        public eMessage Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }

        public long Message_ID
        {
            get { return m_Message_ID; }
            set { m_Message_ID = value; }
        }

        public object oResult
        {
            get { return m_oResult; }
            set { m_oResult = value; }
        }

        public ThreadP_Message.delegate_Procedure Procedure
        {
            get { return m_Procedure; }
            set { m_Procedure = value; }
        }

        public string ErrorMessage
        {
            get { return m_ErrorMessage; }
            set { m_ErrorMessage = value; }
        }

        public ThreadP2Ctrl_Message(long xMessage_ID, eMessage xMessage, ThreadP_Message.delegate_Procedure xporocedure, object oResult, string ErrorMessage)
        {
            Message_ID = xMessage_ID;
            m_Message = xMessage;
            m_Procedure = xporocedure;
            m_oResult = oResult;
            m_ErrorMessage = ErrorMessage;
        }

        public void Set(long xMessage_ID, eMessage xMessage, ThreadP_Message.delegate_Procedure xporocedure, object oResult, string ErrorMessage)
        {
            Message_ID = xMessage_ID;
            m_Message = xMessage;
            m_Procedure = xporocedure;
            m_oResult = oResult;
            m_ErrorMessage = ErrorMessage;
        }

        internal void Do_Dispose()
        {
            m_Procedure = null;
            m_oResult = null;
            m_ErrorMessage = null;
        }
    }
}
