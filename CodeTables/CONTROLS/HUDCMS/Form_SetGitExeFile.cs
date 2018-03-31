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
    public partial class Form_SetGitExeFile : Form
    {
        public Form_SetGitExeFile()
        {
            InitializeComponent();
            usrc_SelectFile1.FileName = Properties.Settings.Default.GitExeFile;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.GitExeFile = usrc_SelectFile1.FileName;
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Form_SetGitExeFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this code is because of a bug in OpenFileDialog
            // see https://www.experts-exchange.com/questions/24413526/Child-Dialog-Closes-Parent-Dialog-in-VB-NET.html
            if (e.CloseReason == CloseReason.None)
            {
                e.Cancel = true;
            }
        }
    }
}
