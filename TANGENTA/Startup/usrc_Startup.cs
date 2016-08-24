using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;
namespace Startup
{
    public partial class usrc_Startup : UserControl
    {

        public startup m_startup = null;
        
        public const int Y_DIST = 10;

        public usrc_Startup(startup xstartup)
        {
            InitializeComponent();
            m_startup = xstartup;
            usrc_NavigationButtons1.Init(m_startup.nav);
            lngRPM.s_StartupProgram.Text(lbl_StartUp);
            Visible = true;
            Dock = DockStyle.Fill;
            m_startup.m_parent_form.Controls.Add(this);
            int iStep = 0;
            int iCountStep1 = m_startup.Step.Count();
            for (iStep = 0; iStep < iCountStep1;iStep++)
            {
                usrc_startup_step xusrc_startup_step = new usrc_startup_step(m_startup.Step[iStep]);
                xusrc_startup_step.Left = lbl_StartUp.Left;
                xusrc_startup_step.Top = lbl_StartUp.Bottom+ Y_DIST + iStep * (xusrc_startup_step.Height + Y_DIST);
                this.Controls.Add(xusrc_startup_step);
            }
        }

        private void timer_Startup_Tick(object sender, EventArgs e)
        {
          
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            m_startup.nav.eExitResult = evt;
        }
    }
}
