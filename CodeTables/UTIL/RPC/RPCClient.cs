using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RPC
{
    public class RPCClient : WebClient
    {
        private RPCd m_rpcd = null;
        public RPCd rpcd
        {
            get { return m_rpcd; }
        }

        public RPCClient(RPCd xrpcd)
        {
            m_rpcd = xrpcd;
        }
    }
}
