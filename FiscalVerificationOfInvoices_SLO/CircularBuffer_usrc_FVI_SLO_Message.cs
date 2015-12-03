using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalVerificationOfInvoices_SLO
{
    public class CircularBuffer_usrc_FVI_SLO_Message
    {
        private int m_Length = 0;
        usrc_FVI_SLO_Message[] m_obuff = null;
        int pIn = 0;
        int pOut = 0;

        public int Length
        {
            get { return m_Length; }
        }

        public CircularBuffer_usrc_FVI_SLO_Message(int xLength)
        {
            if (xLength > 0)
            {
                m_Length = xLength;
                m_obuff = new usrc_FVI_SLO_Message[m_Length];
                for (int i = 0; i < m_Length; i++)
                {
                    usrc_FVI_SLO_Message mfvi = new usrc_FVI_SLO_Message(0,usrc_FVI_SLO_Message.eMessage.NONE, null);
                    m_obuff[i] = mfvi;
                }
            }
            pIn = 0;
            pOut = 0;

        }

        public bool PutIn(usrc_FVI_SLO_Message msg)
        {
            int pInNext = Next(pIn);
            if (pInNext == pOut)
            {
                return false;
            }
            else
            {
                m_obuff[pIn].Message = msg.Message;
                m_obuff[pIn].XML_Data = msg.XML_Data;
                m_obuff[pIn].Message_ID = msg.Message_ID;
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

        public bool Get(ref usrc_FVI_SLO_Message msg)
        {
            if (pOut != pIn)
            {
                msg.Message = m_obuff[pOut].Message;
                msg.XML_Data = m_obuff[pOut].XML_Data;
                msg.Message_ID = m_obuff[pOut].Message_ID;
                m_obuff[pOut].Message = usrc_FVI_SLO_Message.eMessage.NONE;
                m_obuff[pOut].XML_Data = null;
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
