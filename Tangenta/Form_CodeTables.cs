using LanguageControl;
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
    public partial class Form_CodeTables : Form
    {
        public Form_CodeTables()
        {
            InitializeComponent();
            lngRPM.s_CodeTables.Text(this);
        }

        private void usrc_CodeTables1_OK_Click()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void usrc_CodeTables1_EndDialog()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void usrc_CodeTables1_Load(object sender, EventArgs e)
        {

        }
    }
}
