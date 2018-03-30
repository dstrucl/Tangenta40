using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class Form_SetGitFolder : Form
    {
        public Form_SetGitFolder()
        {
            InitializeComponent();
            this.usrc_SelectFolder1.SelectedFolder = Properties.Settings.Default.GitFolder;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.GitFolder = this.usrc_SelectFolder1.SelectedFolder;
            Properties.Settings.Default.Save();
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
