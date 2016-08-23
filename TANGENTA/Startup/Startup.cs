using LanguageControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadProcessor;
using TangentaDB;
using TangentaSampleDB;

namespace Startup
{
   

    public class startup
        {
        public SampleDB sbd;
        NavigationButtons.Navigation nav = null;

        startup_step.eResult eResult = startup_step.eResult.NEXT;
        startup_step.eStep eStep = startup_step.eStep.NoStep;

        public startup_step.eStep eNextStep = startup_step.eStep.NoStep;
        public bool bNewDatabaseCreated = false;
        public bool bInsertSampleData = false;
        public bool bUpgradeDone = false;

        public Form m_parent_form = null;
        public usrc_Startup m_usrc_Startup = null;
        internal startup_step[] Step = null;
        public Image m_ImageCancel = null;
        private bool m_bCancel = false;
        public Icon m_FormIconQuestion = null;
        public fs.enum_GetDBSettings eGetDBSettings_Result = fs.enum_GetDBSettings.No_TextValue;
        public string CurrentDataBaseVersionTextValue = null;

        public bool bCanceled
        {
            get { return m_bCancel; }
            set { m_bCancel = value; }
        }

        public startup(Form parent_form, startup_step[] xStep, NavigationButtons.Navigation xnav, Icon xFormIconQuestion)
        {
            sbd = new SampleDB();
            m_parent_form = parent_form;
            Step = xStep;
            m_usrc_Startup = new usrc_Startup(this);
            nav = xnav;
            nav.web_Help = m_usrc_Startup.usrc_web_Help1;
            m_FormIconQuestion = xFormIconQuestion;
        }


        public bool Execute(startup_step[] step, ref string Err)
        {
            eStep = startup_step.eStep.Check_DataBase;
            eNextStep = eStep;
            while ((eStep != startup_step.eStep.Cancel)&&(eStep != startup_step.eStep.End))
            {
                object odata = null;
                bool bRet = step[(int)eStep].Execute(this,odata, nav, ref Err);
                if (bRet)
                {
                    int iStep = -1;
                    int iNextStep = -1;
                    switch (nav.eExitResult)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            if ((eStep != startup_step.eStep.Cancel) && (eStep != startup_step.eStep.End))
                            {
                                iStep = (int)eStep + 1;
                                iNextStep = (int)eNextStep;
                                while (iStep < iNextStep)
                                {
                                    step[iStep].SetOK();
                                    iStep++;
                                }
                            }
                            break;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            iStep = (int)eStep;
                            iNextStep = (int)eNextStep;
                            while (iStep > iNextStep)
                            {
                                step[iStep].SetNotDone();
                                iStep--;
                            }
                            break;
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
