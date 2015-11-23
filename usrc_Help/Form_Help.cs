using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usrc_Help
{
    public partial class Form_Help : Form
    {
        string HelpFile = null;
        public Form_Help()
        {
            InitializeComponent();
        }

        private void Form_Help_Load(object sender, EventArgs e)
        {
            String appdir = Path.GetDirectoryName(Application.ExecutablePath);
            String myfile = Path.Combine(appdir, "Tangenta.html");
            this.m_webBrowser.Url = new Uri("file:///" + myfile);
        }
    }
}
