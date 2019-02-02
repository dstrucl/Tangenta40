using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayoutManager
{
    public partial class Form_ViewImageFileResults : Form
    {
        private DataTable dic = null;
        public Form_ViewImageFileResults(DataTable xdic)
        {
            InitializeComponent();
            dic = xdic;
            dgv_Dic.DataSource = dic;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_Erease_Click(object sender, EventArgs e)
        {
            dgv_Dic.DataSource = null;
            dic.Rows.Clear();
            dgv_Dic.DataSource = dic;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            dgv_Dic.DataSource = null;
            dgv_Dic.DataSource = dic;
        }
    }
}
