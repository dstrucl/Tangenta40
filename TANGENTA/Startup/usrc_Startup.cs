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
        startup m_startup = null;
        Form Main_form = null;
        public usrc_Startup(Form main_form)
        {
            InitializeComponent();
            lngRPM.s_StartupProgram.Text(lbl_StartUp);
            Main_form = main_form;
            Visible = true;
            Dock = DockStyle.Fill;
            Main_form.Controls.Add(this);
            m_startup = new startup(this);
        }
    }
}
