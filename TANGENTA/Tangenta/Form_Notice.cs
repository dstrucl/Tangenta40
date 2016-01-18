using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_Notice : Form
    {
        private usrc_Notice usrc_Notice;

        public Form_Notice()
        {
            InitializeComponent();
        }

        public Form_Notice(usrc_Notice usrc_Notice)
        {
            InitializeComponent();
            this.usrc_Notice = usrc_Notice;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
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
