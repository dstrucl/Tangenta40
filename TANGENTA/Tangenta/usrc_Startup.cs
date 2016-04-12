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
namespace Tangenta
{
    public partial class usrc_Startup : UserControl
    {
        public usrc_Startup()
        {
            InitializeComponent();
            lngRPM.s_StartupProgram.Text(lbl_StartUp);
        }
    }
}
