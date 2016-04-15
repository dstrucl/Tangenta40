using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadProcessor;

namespace Startup
{
    public class startup_step
    {
        public string s_Title = null;
        public usrc_startup_step m_usrc_startup_step = null;
        public ThreadP_Message.delegate_Procedure procedure;

        public startup_step(string xs_Title, ThreadP_Message.delegate_Procedure proc)
        {
            s_Title = xs_Title;
            procedure = proc;
        }
    }
}
