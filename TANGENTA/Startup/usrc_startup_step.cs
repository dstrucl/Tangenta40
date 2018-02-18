using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Startup
{
    public partial class usrc_startup_step : UserControl
    {
        
        public startup_step startup_step;

        public delegate void delegate_ExitProgram(object sender);
        public event delegate_ExitProgram ExitProgram;

        public delegate void delegate_Finished();
        public event delegate_Finished Finished;

        public delegate void delegate_ExitPrev();
        public event delegate_ExitPrev ExitPrev;

        public bool bNO_FORM_BUT_CHECK_OK = false;


        public usrc_startup_step(startup_step xstartup_step)
        {
            InitializeComponent();
            this.ForeColor = Colors.usrc_startup_step.ForeColor;
            this.BackColor = Colors.usrc_startup_step.BackColor;
            startup_step = xstartup_step;
            startup_step.m_usrc_startup_step = this;
            this.lbl_startup_step.Text = startup_step.s_Title;
            Set_UNDEFINED();
            this.lbl_startup_step.ForeColor = this.ForeColor;
        }

        private void Set_UNDEFINED()
        {
            this.check1.State = Check.check.eState.UNDEFINED;
            this.check1.Refresh();
        }

        private void Set_WAIT()
        {
            this.check1.State = Check.check.eState.WAIT;
            this.check1.Refresh();
        }

        private void Set_TRUE()
        {
            this.check1.State = Check.check.eState.TRUE;
            this.check1.Refresh();
        }


        private void Something_ready(object sender, EventArgs e)
        {
            //this is soemthing ready in 
            if (sender is NavigationButtons.SomethingReadyNotifier)
            {
                if (((NavigationButtons.SomethingReadyNotifier)sender).Startup_Step is startup_step)
                {
                    if(((startup_step)((NavigationButtons.SomethingReadyNotifier)sender).Startup_Step).Step != startup_step.Step)
                    {
                        return;
                    }
                }
            }
            if (this.startup_step.showform_procedure != null)
            {
                string Err = null;
                bNO_FORM_BUT_CHECK_OK = false;
                startup_step.Startup_onformresult_proc_Result eRes = startup_step.Execute_onformresult_procedure(sender, ref Err);
                switch (eRes)
                {
                    case startup_step.Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN:
                        Set_WAIT();
                        
                        if (startup_step.check_procedure!=null)
                        {
                          startup_step.Startup_check_proc_Result e_check_result =  startup_step.check_procedure(startup_step, null, ref startup_step.showform_procedure, ref Err);
                            switch (e_check_result)
                            {
                                case startup_step.Startup_check_proc_Result.WAIT_USER_INTERACTION:
                                    startup_step.showform_procedure(startup_step, startup_step.nav, ref startup_step.onformresult_procedure);
                                    break;
                                case startup_step.Startup_check_proc_Result.CHECK_OK:
                                    Set_TRUE();
                                    startup_step.myStartup.StartNextStepExecution();
                                    break;
                            }
                        }
                        break;

                    case startup_step.Startup_onformresult_proc_Result.WAIT_USER_INTERACTION:
                        Set_WAIT();
                        startup_step.showform_procedure(startup_step, startup_step.nav, ref startup_step.onformresult_procedure);
                        break;

                   
                    case startup_step.Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK:
                        Set_TRUE();
                        bNO_FORM_BUT_CHECK_OK = true;
                        break;

                    case startup_step.Startup_onformresult_proc_Result.NEXT:
                        Set_TRUE();
                        if (!startup_step.myStartup.StartNextStepExecution())
                        {
                            if (Finished != null)
                            {
                                Finished();
                            }
                        }
                        break;

                    case startup_step.Startup_onformresult_proc_Result.PREV:
                        Set_UNDEFINED();
                        Err = null;
                        if (!startup_step.myStartup.StartPrevStepExecution(ref Err))
                        {
                            if (Err == null)
                            {
                                if (ExitPrev != null)
                                {
                                    ExitPrev();
                                }
                            }
                        }
                        break;

                    case startup_step.Startup_onformresult_proc_Result.EXIT:
                        Set_UNDEFINED();
                        if (ExitProgram != null)
                        {
                            ExitProgram(this);
                        }
                        break;

                    default:
                        LogFile.Error.Show("ERROR:Startup:usrc_startup_step:Something_ready: startup_step.Startup_onformresult_proc_Result eRes = " + eRes.ToString() + " not implemented!");
                        break;
                }
            }
            else
            {
                //No form was showed
                switch (startup_step.eResult_Of_check_procedure)
                {
                    case startup_step.Startup_check_proc_Result.CHECK_OK:
                        Set_TRUE();
                        if (!startup_step.myStartup.StartNextStepExecution())
                        {
                            if (Finished!=null)
                            {
                                Finished();
                            }
                        }
                        break;
                    case startup_step.Startup_check_proc_Result.CHECK_ERROR:
                        break;
                }
            }
        }

        internal void UndoProcedure(ref string Err)
        {
            if (startup_step.undo_procedure!=null)
            {
                startup_step.undo_procedure(startup_step, ref Err);
            }

        }

        internal startup_step.Startup_check_proc_Result DoStartup_check_proc_Result()
        {
            Set_WAIT();
            string Err = null;
            startup_step.Startup_check_proc_Result eResult = startup_step.Execute_check_procedure(null, ref Err);
            return Action_on_DoStartup_check_proc_Result(eResult, ref Err);
        }

        private startup_step.Startup_check_proc_Result Action_on_DoStartup_check_proc_Result(startup_step.Startup_check_proc_Result eResult, ref string Err)
        {
            switch (eResult)
            {
                case startup_step.Startup_check_proc_Result.CHECK_OK:
                    this.check1.State = Check.check.eState.TRUE;

                    if (startup_step.nav.DialogClosingNotifier != null)
                    {
                        startup_step.nav.DialogClosingNotifier.SomethingReady -= Something_ready;
                    }
                    else
                    {
                        startup_step.nav.DialogClosingNotifier = new NavigationButtons.SomethingReadyNotifier(SynchronizationContext.Current, this);
                    }
                    startup_step.nav.DialogClosingNotifier.Startup_Step = startup_step;
                    startup_step.nav.DialogClosingNotifier.SomethingReady += Something_ready;
                    startup_step.nav.DialogClosingNotifier.NotifySomethingReady();
                    return startup_step.Startup_check_proc_Result.CHECK_OK;


                case startup_step.Startup_check_proc_Result.CHECK_ERROR:
                    this.check1.State = Check.check.eState.FALSE;
                    return startup_step.Startup_check_proc_Result.CHECK_ERROR;


                case startup_step.Startup_check_proc_Result.WAIT_USER_INTERACTION:
                    this.check1.State = Check.check.eState.WAIT;
                    if (startup_step.showform_procedure(this.startup_step,this.startup_step.nav, ref this.startup_step.onformresult_procedure))
                    {
                        //show error
                        if (startup_step.nav.DialogClosingNotifier != null)
                        {
                            startup_step.nav.DialogClosingNotifier.SomethingReady -= Something_ready;
                        }
                        else
                        {
                            startup_step.nav.DialogClosingNotifier = new NavigationButtons.SomethingReadyNotifier(SynchronizationContext.Current, this);
                        }
                        startup_step.nav.DialogClosingNotifier.Startup_Step = startup_step;
                        startup_step.nav.DialogClosingNotifier.SomethingReady += Something_ready;
                        return startup_step.Startup_check_proc_Result.WAIT_USER_INTERACTION;
                    }
                    else
                    {
                        return startup_step.Startup_check_proc_Result.CHECK_ERROR;
                    }

                default:
                    return startup_step.Startup_check_proc_Result.CHECK_ERROR;

            }
        }

        internal void Remove_DialogClosingNotifier_SomethingReady()
        {
            if (startup_step.nav.DialogClosingNotifier != null)
            {
                startup_step.nav.DialogClosingNotifier.SomethingReady -= Something_ready;
            }
        }
    }
}
