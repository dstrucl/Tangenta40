using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Excell_Export_base
{
    public partial class Progress_Form : Form
    {
        Progress_Thread m_Progress_Thread = null;

        public Progress_Form(Progress_Thread progr_thread)
        {
            InitializeComponent();
            m_Progress_Thread = progr_thread;
            lbl_Export_To_File.Text = static_lng_text.lng_s_ExportToFile_s+ ":" + m_Progress_Thread.m_FileName;
            lbl_Rows_Columns.Text = static_lng_text.lng_s_Rows_s + m_Progress_Thread.m_rows.ToString() + " , " + static_lng_text.lng_s_Columns_s+" = " + m_Progress_Thread.m_columns.ToString();
            lbl_PercentDone.Text = static_lng_text.lng_s_ExportDoneInXprocent_s + ": %0";
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
