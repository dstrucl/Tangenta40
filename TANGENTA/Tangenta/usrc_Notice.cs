using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class usrc_Notice : UserControl
    {
        public usrc_Notice()
        {
            InitializeComponent();
        }

        private void btn_Notice_Click(object sender, EventArgs e)
        {
            Form_Notice frm_notice = new Form_Notice(this);
            frm_notice.ShowDialog();
        }
    }
}
