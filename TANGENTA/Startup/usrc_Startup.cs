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
using UpgradeDB;

namespace Startup
{
    public partial class usrc_Startup : UserControl
    {
        public delegate void delegate_WebBrowserControl_DocumentCompleted(string url);
        public event delegate_WebBrowserControl_DocumentCompleted WebBrowserControl_DocumentCompleted = null;

        public delegate void delegate_ExitProgram();
        public event delegate_ExitProgram ExitProgram = null;

        public delegate void delegate_ExitPrev();
        public event delegate_ExitProgram ExitPrev = null;

        public delegate void delegate_Finished();
        public event delegate_Finished Finished = null;

        public UpgradeDB_inThread m_UpgradeDB = null;


        int xusrc_startup_step_Width = 0;

        public startup m_startup = null;
        
        public const int Y_DIST = 10;

        public bool m_Exit = false;

        public bool Exit { get { return m_Exit; } }

        public usrc_Startup(startup xstartup)
        {
            InitializeComponent();
            m_UpgradeDB = new UpgradeDB_inThread(this);
            m_startup = xstartup;
            lng.s_StartupProgram.Text(lbl_StartUp);
            Visible = true;
            Dock = DockStyle.Fill;
            m_startup.m_parent_form.Controls.Add(this);
        }

        public void Init()
        {
            this.BackColor = Colors.usrc_startup.BackColor;
            this.lbl_StartUp.ForeColor = Colors.usrc_startup.ForeColor;
            int iStep = 0;
            int iCountStep1 = m_startup.Steps.Count();
            for (iStep = 0; iStep < iCountStep1; iStep++)
            {
                usrc_startup_step xusrc_startup_step = new usrc_startup_step(m_startup.Steps[iStep]);
                xusrc_startup_step.Left = lbl_StartUp.Left;
                xusrc_startup_step.Top = lbl_StartUp.Bottom + Y_DIST + iStep * (xusrc_startup_step.Height + Y_DIST);
                if (xusrc_startup_step_Width < xusrc_startup_step.Width) { }
                {
                    xusrc_startup_step_Width = xusrc_startup_step.Width;
                }
                xusrc_startup_step.ExitProgram += Xusrc_startup_step_ExitProgram;
                xusrc_startup_step.ExitPrev += Xusrc_startup_step_ExitPrev;
                xusrc_startup_step.Finished += Xusrc_startup_step_Finished;
                xusrc_startup_step.BackColor = Colors.usrc_startup_step.BackColor;
                xusrc_startup_step.ForeColor = Colors.usrc_startup_step.ForeColor;
                this.Controls.Add(xusrc_startup_step);
            }
        }

        private void Xusrc_startup_step_ExitPrev()
        {
            if (ExitPrev!=null)
            {
                ExitPrev();
            }
        }

        private void Xusrc_startup_step_ExitProgram(object sender)
        {
            if (this.ExitProgram!=null)
            {
                m_Exit = true;
                this.ExitProgram();
            }
        }

        private void Xusrc_startup_step_Finished()
        {
            if (this.Finished != null)
            {
                this.Finished();
            }
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            m_startup.nav.eExitResult = evt;
        }

        private void usrc_Startup_Load(object sender, EventArgs e)
        {
            this.usrc_web_Help1.Left = lbl_StartUp.Left + xusrc_startup_step_Width + 5;
            this.usrc_web_Help1.Width = this.Width - (lbl_StartUp.Left + xusrc_startup_step_Width + 5);
        }

        internal void ShowNews()
        {
            this.usrc_web_Help1.ShowNews();
        }

        private void usrc_web_Help1_DocumentCompleted(string url)
        {
            if (WebBrowserControl_DocumentCompleted!=null)
            {
                WebBrowserControl_DocumentCompleted(url);
            }
        }
    }
}
