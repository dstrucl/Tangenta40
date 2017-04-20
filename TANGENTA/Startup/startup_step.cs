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
        public enum eResult { NEXT, BACK, EXIT, ERROR};

        public enum eStep : int { Check_DataBase,
                                  Read_DBSettings_Version,
                                  CheckDBVersion,
                                  GetOrganisationData,
                                  GetBaseCurrency,
                                  GetTaxation,
                                  Get_ProgramSettings,
                                  SetShopsPricelists,
                                  GetSimpleItemData,
                                  GetItemData,
                                  GetPrinter,
                                  GetWorkPeriod,
                                  End,
                                  Cancel,
                                  NoStep
                                };

        public delegate bool delegate_startup_proc(startup myStartup,object oData, NavigationButtons.Navigation xnav, ref string Err);

        public string s_Title = null;
        public usrc_startup_step m_usrc_startup_step = null;
        public delegate_startup_proc procedure;
        public eStep eStep_Label = eStep.NoStep;
        public bool DialogShown = false;
        public int Index = -1;

        public startup_step(string xs_Title, delegate_startup_proc proc, eStep xeStep_Label,int xindex)
        {
            s_Title = xs_Title;
            procedure = proc;
            eStep_Label = xeStep_Label;
            Index = xindex;
        }

        internal void SetOK()
        {
            m_usrc_startup_step.check1.State = Check.check.eState.TRUE;
        }

        public bool Execute(startup myStartup,object oData, NavigationButtons.Navigation xnav, ref string Err)
        {

            m_usrc_startup_step.check1.State = Check.check.eState.WAIT;
            Application.DoEvents();
            xnav.DialogShown = false;
            xnav.StartupStep_index = this.Index;
            bool bRet = this.procedure(myStartup,oData, xnav, ref Err);
            this.DialogShown = xnav.DialogShown;
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

        internal void SetNotDone()
        {
            m_usrc_startup_step.check1.State = Check.check.eState.UNDEFINED;
        }
    }
}
