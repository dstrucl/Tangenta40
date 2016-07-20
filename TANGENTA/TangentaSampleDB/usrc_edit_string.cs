using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangentaSampleDB
{
    public partial class usrc_edit_string : UserControl
    {
        public string label
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        public string text
        {
            get { return this.textBox1.Text; }
            set { this.textBox1.Text = value; }
        }

        public usrc_edit_string()
        {
            InitializeComponent();
        }

        public void Set(string lbl,string txt)
        {
            label = lbl;
            text = txt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
