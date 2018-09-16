using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopC
{
    public partial class Form_plus : Form
    {
        public Form_plus()
        {
            InitializeComponent();
            this.Visible = false;
            this.Enabled = false;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void Flash(Control ctrl)
        {
            this.Width = 20;
            this.Height = 20;
            Point locationOnForm = ctrl.FindForm().PointToClient(
            ctrl.Parent.PointToScreen(ctrl.Location));
            this.Top = locationOnForm.Y - this.Height;
            this.Left = locationOnForm.X - this.Width;
            this.Visible = true;
            timer1.Enabled = true;
        }

        private void Form_plus_Load(object sender, EventArgs e)
        {
            this.Width = 20;
            this.Height = 20;
        }
    }
}
