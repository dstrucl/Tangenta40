using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Startup.startup_step;

namespace Tangenta
{
    public partial class Form_Document 
    {
        private startup_step CStartup_00_TangentaAbout()
        {
            return new startup_step(lng.s_Startup_Tangenta_About.s, m_startup, Program.nav, Startup_00_Check_TangentaAboutShown, 
                                    //m_startup.Startup_00_Do_showform_TangentaAbout,
                                    //Startup_00_onformresult_TangentaAbout,
                                    startup_step.eStep.Check_00_TangentaAbout);
        }

        private Startup_check_proc_Result Startup_00_Check_TangentaAboutShown(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            if (Properties.Settings.Default.Startup_TangentaAbout_Showed)
            {
                return Startup_check_proc_Result.CHECK_OK;
            }
            else
            {
                startup_ShowForm_proc = Startup_00_Show_Form_TangentaAbout;
                return Startup_check_proc_Result.WAIT_USER_INTERACTION;
            }
        }

        private bool Startup_00_Show_Form_TangentaAbout(startup_step myStartup_step,NavigationButtons.Navigation xnav, ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_00_onformresult_TangentaAbout;
            return m_startup.Startup_00_Do_showform_TangentaAbout(xnav);

        }

            private Startup_onformresult_proc_Result Startup_00_onformresult_TangentaAbout(startup_step myStartup_step,
                                                                                            Form form,
                                                                                            NavigationButtons.Navigation.eEvent eExitResult,
                                                                                            ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                            ref string Err)
        {
            switch (eExitResult)
            {
                case NavigationButtons.Navigation.eEvent.NEXT:
                    Properties.Settings.Default.Startup_TangentaAbout_Showed = true;
                    Properties.Settings.Default.Save();
                    return Startup_onformresult_proc_Result.NEXT;

                case NavigationButtons.Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case NavigationButtons.Navigation.eEvent.EXIT:
                    this.Close();
                    this.DialogResult = DialogResult.Cancel;
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:Form_Document:onformresult_TangentaAbout  xnav.eExitResult = " + eExitResult.ToString() + " not implemented");
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }

    }
}
