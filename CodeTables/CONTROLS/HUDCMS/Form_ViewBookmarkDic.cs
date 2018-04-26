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
    public partial class Form_ViewBookmarkDic : Form
    {
        private DataTable dic = null;
        public Form_ViewBookmarkDic(DataTable xdic)
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
    }
}
