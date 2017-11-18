using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataGridView_2xls_base;

namespace LanguageControl
{
    public partial class Form_Language_Dictionary : Form
    {
        private DataTable dt_Languages = null;

        public Form_Language_Dictionary()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
            return;
        }

        private void Form_Language_Dictionary_Shown(object sender, EventArgs e)
        {
            Cursor cur = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            lng.s_Dictonary_of_controls_text.Text(this);
            DynSettings.LoadLanguages(ref dt_Languages, false);
            dataGridView2xls1.DataSource = dt_Languages;
            dataGridView2xls1.Columns[DynSettings.LANGUAGE_COLUMN_PREFIX+"0"].HeaderText = DynSettings.s_language.sTextArr[0];
            dataGridView2xls1.Columns[DynSettings.LANGUAGE_COLUMN_PREFIX + "1"].HeaderText = DynSettings.s_language.sTextArr[1];
            dataGridView2xls1.Columns[DynSettings.MODULE_NAME].HeaderText = lng.s_ModuleName.s;
            dataGridView2xls1.Columns[DynSettings.VARIABLE_NAME].HeaderText = lng.s_Variable.s;
            this.Cursor = cur;
        }
    }
}
