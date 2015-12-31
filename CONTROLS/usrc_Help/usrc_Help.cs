using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usrc_Help
{
    public partial class usrc_Help: UserControl
    {
        public usrc_Help()
        {
            InitializeComponent();
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            Form_Help hlp_dlg = new Form_Help();
            hlp_dlg.ShowDialog();

        }
    }
}
