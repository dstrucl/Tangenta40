using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadProcessor;

namespace Startup
{
   

    public class startup
        {
        startup_step.eStep eStep = startup_step.eStep.NoStep;
        public startup_step.eStep eNextStep = startup_step.eStep.NoStep;
        public bool bNewDatabaseCreated = false;
        public bool bInsertSampleData = false;
        public Form m_parent_form = null;
        public usrc_Startup m_usrc_Startup = null;
        internal startup_step[] Step = null;


        public startup(Form parent_form, startup_step[] xStep)
        {
            m_parent_form = parent_form;
            Step = xStep;
            m_usrc_Startup = new usrc_Startup(this);
        }


        public bool Execute(startup_step[] step, ref string Err)
        {
            eStep = startup_step.eStep.Check_DataBase;
            eNextStep = eStep;
            while (eStep != startup_step.eStep.End)
            {
                object odata = null;
                bool bRet = step[(int)eStep].Execute(this,odata, ref Err);
                if (bRet)
                {
                    if (eNextStep != startup_step.eStep.End)
                    {
                        int iStep = (int)eStep + 1;
                        int iNextStep = (int)eNextStep;
                        while (iStep < iNextStep)
                        {
                            step[iStep].SetOK();
                            iStep++;
                        }
                    }
                }
                eStep = eNextStep;
                Application.DoEvents();
                if (!bRet)
                {
                    return false;
                }
            }
            return true;
        }

        public void RemoveControl()
        {
            m_parent_form.Controls.Remove(m_usrc_Startup);
            m_usrc_Startup.Dispose();
            m_usrc_Startup = null;
        }
    }
}
