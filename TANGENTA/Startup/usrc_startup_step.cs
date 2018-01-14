﻿using System;
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
        internal startup_step startup_step;

        public delegate void delegate_StartupFormClosing(object sender);
        public event delegate_StartupFormClosing StartupFormClosing;
        public bool bNO_FORM_BUT_CHECK_OK = false;
        public bool bDoStepAgain = false;

        public usrc_startup_step(startup_step xstartup_step)
        {
            InitializeComponent();
            startup_step = xstartup_step;
            startup_step.m_usrc_startup_step = this;
            this.lbl_startup_step.Text = startup_step.s_Title;
            this.check1.State = Check.check.eState.UNDEFINED;
        }

        private void Something_ready_SomethingReady(object sender, EventArgs e)
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
            string Err = null;
            bNO_FORM_BUT_CHECK_OK = false;
            bDoStepAgain = false;
            startup_step.Startup_onformresult_proc_Result eRes = startup_step.Execute_onformresult_procedure(sender, ref Err);
            switch (eRes)
            {
                case startup_step.Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN:
                    this.check1.State = Check.check.eState.WAIT;
                    bDoStepAgain = true;
                    if (StartupFormClosing != null)
                    {
                        StartupFormClosing(this);
                    }
                    break;

                case startup_step.Startup_onformresult_proc_Result.WAIT_USER_INTERACTION_0:
                    this.check1.State = Check.check.eState.WAIT;
                    if (startup_step.Execute_showform_procedure(null,startup_step.Startup_check_proc_Result.WAIT_USER_INTERACTION_0, ref Err))
                    {
                    }
                    break;

                case startup_step.Startup_onformresult_proc_Result.WAIT_USER_INTERACTION_1:
                    this.check1.State = Check.check.eState.WAIT;
                    if (startup_step.Execute_showform_procedure(null, startup_step.Startup_check_proc_Result.WAIT_USER_INTERACTION_1, ref Err))
                    {
                    }
                    if (StartupFormClosing != null)
                    {
                        StartupFormClosing(this);
                    }
                    break;
                case startup_step.Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK:
                    this.check1.State = Check.check.eState.TRUE;
                    bNO_FORM_BUT_CHECK_OK = true;
                    if (StartupFormClosing != null)
                    {
                        StartupFormClosing(this);
                    }
                    break;
                case startup_step.Startup_onformresult_proc_Result.NEXT:
                    this.check1.State = Check.check.eState.TRUE;
                    if (StartupFormClosing != null)
                    {
                        StartupFormClosing(this);
                    }
                    break;

                case startup_step.Startup_onformresult_proc_Result.PREV:
                    this.check1.State = Check.check.eState.UNDEFINED;
                    if (StartupFormClosing != null)
                    {
                        StartupFormClosing(this);
                    }
                    break;

                case startup_step.Startup_onformresult_proc_Result.EXIT:
                    this.check1.State = Check.check.eState.UNDEFINED;
                    if (StartupFormClosing != null)
                    {
                        StartupFormClosing(this);
                    }
                    break;

                default:
                    if (StartupFormClosing != null)
                    {
                        StartupFormClosing(this);
                    }
                    break;
            }
        }

        internal startup_step.Startup_check_proc_Result DoStartup_check_proc_Result()
        {
            this.check1.State = Check.check.eState.WAIT;
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
                        startup_step.nav.DialogClosingNotifier.SomethingReady -= Something_ready_SomethingReady;
                    }
                    else
                    {
                        startup_step.nav.DialogClosingNotifier = new NavigationButtons.SomethingReadyNotifier(SynchronizationContext.Current, this);
                    }
                    startup_step.nav.DialogClosingNotifier.Startup_Step = startup_step;
                    startup_step.nav.DialogClosingNotifier.SomethingReady += Something_ready_SomethingReady;
                    startup_step.nav.DialogClosingNotifier.NotifySomethingReady();
                    return startup_step.Startup_check_proc_Result.CHECK_OK;


                case startup_step.Startup_check_proc_Result.CHECK_ERROR:
                    this.check1.State = Check.check.eState.FALSE;
                    return startup_step.Startup_check_proc_Result.CHECK_ERROR;


                case startup_step.Startup_check_proc_Result.WAIT_USER_INTERACTION_0:
                case startup_step.Startup_check_proc_Result.WAIT_USER_INTERACTION_1:
                    this.check1.State = Check.check.eState.WAIT;
                    if (startup_step.Execute_showform_procedure(null, eResult, ref Err))
                    {
                        //show error
                        if (startup_step.nav.DialogClosingNotifier != null)
                        {
                            startup_step.nav.DialogClosingNotifier.SomethingReady -= Something_ready_SomethingReady;
                        }
                        else
                        {
                            startup_step.nav.DialogClosingNotifier = new NavigationButtons.SomethingReadyNotifier(SynchronizationContext.Current, this);
                        }
                        startup_step.nav.DialogClosingNotifier.Startup_Step = startup_step;
                        startup_step.nav.DialogClosingNotifier.SomethingReady += Something_ready_SomethingReady;
                        return startup_step.Startup_check_proc_Result.WAIT_USER_INTERACTION_0;
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
                startup_step.nav.DialogClosingNotifier.SomethingReady -= Something_ready_SomethingReady;
            }
        }
    }
}
