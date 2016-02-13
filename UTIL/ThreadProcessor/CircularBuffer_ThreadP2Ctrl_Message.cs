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
using System.Threading.Tasks;

namespace ThreadProcessor
{
    public class CircularBuffer_ThreadP2Ctrl_Message
    {
        private int m_Length = 0;
        ThreadP2Ctrl_Message[] m_obuff = null;
        int pIn = 0;
        int pOut = 0;

        public int Length
        {
            get { return m_Length; }
        }

        public CircularBuffer_ThreadP2Ctrl_Message(int xLength)
        {
            if (xLength > 0)
            {
                m_Length = xLength;
                m_obuff = new ThreadP2Ctrl_Message[m_Length];
                for (int i = 0; i < m_Length; i++)
                {
                    ThreadP2Ctrl_Message mfvi = new ThreadP2Ctrl_Message(0, ThreadP2Ctrl_Message.eMessage.NONE, null,null,null);
                    m_obuff[i] = mfvi;
                }
            }
            pIn = 0;
            pOut = 0;

        }

        public bool PutIn(ThreadP2Ctrl_Message msg)
        {
            int pInNext = Next(pIn);
            if (pInNext == pOut)
            {
                return false;
            }
            else
            {
                m_obuff[pIn].Set(msg.Message_ID,
                                 msg.Message,
                                 msg.Procedure,
                                 msg.oResult,
                                 msg.ErrorMessage
                                );
                pIn = pInNext;
                return true;
            }
        }

        private int Next(int xp)
        {
            xp++;
            if (xp >= m_Length)
            {
                xp = 0;
            }
            return xp;
        }

        public bool Get(ref ThreadP2Ctrl_Message msg)
        {
            if (pOut != pIn)
            {
                msg.Set(m_obuff[pOut].Message_ID,
                        m_obuff[pOut].Message,
                        m_obuff[pOut].Procedure,
                        m_obuff[pOut].oResult,
                        m_obuff[pOut].ErrorMessage);


                m_obuff[pOut].Do_Dispose();
                pOut = Next(pOut);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Count
        {
            get
            {
                int iCount = 0;
                int pout = pOut;
                while (pout != pIn)
                {
                    pout = Next(pout);
                    iCount++;
                }
                return iCount;
            }
        }
    }
}
