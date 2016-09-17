using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace ProgressForm
{
    public partial class Progress_Form : Form
    {
        Progress_Thread m_Progress_Thread = null;

        public Progress_Form(Progress_Thread progr_thread,string sLabel1,string sLabel2, string sLabel3)
        {
            InitializeComponent();
            m_Progress_Thread = progr_thread;
            Label1.Text = sLabel1;
            Label2.Text = sLabel2;
            Label3.Text = sLabel3;
            progressBar.Maximum = 100;
            progressBar.Minimum = 0;
            progressBar.Value = 0;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Progress_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_Progress_Thread.bEnd = true;
            m_Progress_Thread.bCancel = true;
        }

    }
}
