using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Startup
{
    public partial class usrc_startup_step : UserControl
    {
        private startup_step startup_step;

        public usrc_startup_step(startup_step xstartup_step)
        {
            InitializeComponent();
            startup_step = xstartup_step;
            startup_step.m_usrc_startup_step = this;
            this.lbl_startup_step.Text = startup_step.s_Title;
            this.check1.State = Check.check.eState.UNDEFINED;
        }
    }
}
