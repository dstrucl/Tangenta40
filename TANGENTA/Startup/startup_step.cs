using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadProcessor;

namespace Startup
{
    public class startup_step
    {
        public enum eStep : int { Check_DataBase,
                                  Read_DBSettings,
                                  GetOrganisationData,
                                  GetBaseCurrency,
                                  GetTaxation,
                                  Get_shops_in_use,
                                  GetSimpleItemData,
                                  GetItemData,
                                  GetWorkPeriod,
                                  End,
                                  NoStep
                                };

        public delegate bool delegate_startup_proc(startup myStartup,object oData, ref string Err);

        public string s_Title = null;
        public usrc_startup_step m_usrc_startup_step = null;
        public delegate_startup_proc procedure;
        public eStep eStep_Label = eStep.NoStep;

        public startup_step(string xs_Title, delegate_startup_proc proc, eStep xeStep_Label)
        {
            s_Title = xs_Title;
            procedure = proc;
            eStep_Label = xeStep_Label;
        }

        internal void SetOK()
        {
            m_usrc_startup_step.check1.State = Check.check.eState.TRUE;
        }

        public bool Execute(startup myStartup,object oData, ref string Err)
        {

            m_usrc_startup_step.check1.State = Check.check.eState.WAIT;
            Application.DoEvents();
            bool bRet = this.procedure(myStartup,oData, ref Err);
            if (bRet)
            {
                m_usrc_startup_step.check1.State = Check.check.eState.TRUE;
            }
            else
            {
                m_usrc_startup_step.check1.State = Check.check.eState.FALSE;
            }
            return bRet;
        }
    }
}
