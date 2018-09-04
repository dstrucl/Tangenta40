using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Global_g_DrawStringWordWrap
{
    public partial class Form1 : Form
    {
        Font fArial = null;
        public Form1()
        {
            InitializeComponent();
            fArial = new Font("Arial", 12);

            panel1.Paint += Panel1_Paint;

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            string s = textBox1.Text;
            float ofs = 0;
            Global.g.DrawWordWrap(e.Graphics, s, fArial, Color.Blue, 120, 2, 180, ref ofs);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panel1.Refresh();
        }
    }
}
