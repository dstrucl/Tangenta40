using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_Select_Notice : Form
    {
        public long_v Notice_ID_v = null;
        public string_v NoticeText_v = null;
        DataTable dtNotice = null;
        public Form_Select_Notice()
        {
            InitializeComponent();
            lngRPM.s_SelectNotice.Text(this);
        }

        private void Form_Select_Notice_Load(object sender, EventArgs e)
        {
            if (TangentaDB.f_Notice.GetTable(ref dtNotice))
            {
                this.dgvx_Notice.DataSource = dtNotice;
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgrvc = dgvx_Notice.SelectedRows;
            if (dgrvc.Count>0)
            {
                int i=dgrvc[0].Index;
                if (i>=0)
                {
                    Notice_ID_v =tf.set_long(dtNotice.Rows[i]["ID"]);
                    NoticeText_v = tf.set_string(dtNotice.Rows[i]["NoticeText"]);
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
