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
        Form Main_form = null;

        public usrc_Startup(Form xMain_form, startup_step[] Step_ResetNew, startup_step[] Step_ProgramInstalled)
        {
            InitializeComponent();
            lngRPM.s_StartupProgram.Text(lbl_StartUp);
            Main_form = xMain_form;
            Visible = true;
            Dock = DockStyle.Fill;
            Main_form.Controls.Add(this);
            m_startup = new startup(this);
            this.Step_ResetNew = Step_ResetNew;
            this.step_ProgramInstalled = Step_ProgramInstalled;
        }
    }
}
