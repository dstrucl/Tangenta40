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
        private startup_step startup_step;

        private SomethingReadyNotifier something_ready = null;

        public delegate void delegate_StartupFormClosed(object sender);
        public event delegate_StartupFormClosed StartupFormClosed;

        public usrc_startup_step(startup_step xstartup_step)
        {
            InitializeComponent();
            startup_step = xstartup_step;
            startup_step.m_usrc_startup_step = this;
            this.lbl_startup_step.Text = startup_step.s_Title;
            this.check1.State = Check.check.eState.UNDEFINED;
            something_ready = new SomethingReadyNotifier(SynchronizationContext.Current, startup_step);
            something_ready.SomethingReady += Something_ready_SomethingReady;
        }

        private void Something_ready_SomethingReady(object sender, EventArgs e)
        {
            //this is soemthing ready in 
            if (StartupFormClosed!=null)
            {
                StartupFormClosed(this);
            }
        }

        internal startup_step.Startup_check_proc_Result DoStartup_check_proc_Result()
        {
            this.check1.State = Check.check.eState.WAIT;
            string Err = null;
            startup_step.Startup_check_proc_Result eResult = startup_step.Execute_check_procedure(null, ref Err);
            switch (eResult)
            {
                case startup_step.Startup_check_proc_Result.CHECK_OK:
                    this.check1.State = Check.check.eState.TRUE;
                    break;

                case startup_step.Startup_check_proc_Result.CHECK_ERROR:
                    this.check1.State = Check.check.eState.FALSE;
                    //show error
                    break;

                case startup_step.Startup_check_proc_Result.WAIT_USER_INTERACTION:
                    this.check1.State = Check.check.eState.WAIT;
                    if (!startup_step.Execute_showform_procedure(null,ref Err))
                    {
                        //show error
                    }
                    break;
            }
            something_ready.NotifySomethingReady();
            return eResult;
        }
    }
}
