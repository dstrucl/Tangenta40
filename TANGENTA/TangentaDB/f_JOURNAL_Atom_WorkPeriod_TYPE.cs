using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_JOURNAL_Atom_WorkPeriod_TYPE
    {
        public const string JOURNAL_Atom_WorkPeriod_TYPE = "JOURNAL_Atom_WorkPeriod_TYPE";
        public const string WorkPeriodNotClosedInPreviousSession = "Work period not closed in previuos session";

        private static ID m_JOURNAL_Atom_WorkPeriod_TYPE_ID_WorkPeriodNotClosedInPreviousSession = null;

        public static ID JOURNAL_Atom_WorkPeriod_TYPE_ID_WorkPeriodNotClosedInPreviousSession
        { get { return m_JOURNAL_Atom_WorkPeriod_TYPE_ID_WorkPeriodNotClosedInPreviousSession; } }

        public static bool Get_JOURNAL_Atom_WorkPeriod_TYPE_ID()
        {
            if (fs.Get_JOURNAL_TYPE(JOURNAL_Atom_WorkPeriod_TYPE, WorkPeriodNotClosedInPreviousSession, ref m_JOURNAL_Atom_WorkPeriod_TYPE_ID_WorkPeriodNotClosedInPreviousSession))
            {
                return true;
            }
            return false;
        }
    }
}
