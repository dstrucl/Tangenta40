using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usrc_Item_InsidePageHandler
{
    public partial class UserControl1 : UserControl
    {
        private bool bSelected = false;
        private int ipenindex = 0;
        private float penwidth = 2;
        Pen[] pen = new Pen[5] {null, null, null, null,null };

        public new event EventHandler<EventArgs> Click;

        protected override void OnClick(EventArgs e)
        {
            EventArgs myArgs = new EventArgs();
            EventHandler<EventArgs> myEvent = Click;
            if (myEvent != null)
                myEvent(this, myArgs);
            base.OnClick(e);
        }
        public UserControl1()
        {
            InitializeComponent();
            //Color color = Color.FromArgb(255 - this.BackColor.R, 255 - this.BackColor.G, 255 - this.BackColor.B);
            Color color = Color.Black;
            Brush br = new SolidBrush(color);
            float[] dashValues0 = { 0.01F, 5, 5, 5, 5, 5, 5 };
            float[] dashValues1 = { 1.01F, 5, 5, 5, 5, 5, 5 };
            float[] dashValues2 = { 2.01F, 5, 5, 5, 5, 5, 5 };
            float[] dashValues3 = { 3.01F, 5, 5, 5, 5, 5, 5 };
            float[] dashValues4 = { 4.01F, 5, 5, 5, 5, 5, 5 };
            pen[0] = new Pen(br, penwidth);
            pen[0].DashPattern = dashValues0;
            pen[1] = new Pen(br, penwidth);
            pen[1].DashPattern = dashValues1;
            pen[2] = new Pen(br, penwidth);
            pen[2].DashPattern = dashValues2;
            pen[3] = new Pen(br, penwidth);
            pen[3].DashPattern = dashValues3;
            pen[4] = new Pen(br, penwidth);
            pen[4].DashPattern = dashValues4;
            timer1.Enabled = false;
            timer1.Interval = 100;
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OnClick(e);
            if (bSelected)
            {
                bSelected = false;
                timer1.Enabled = false;
            }
            else
            {
                bSelected = true;
                timer1.Enabled = true;
            }
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (bSelected)
            {
                //Region r = new Region(this.ClientRectangle);
                //Rectangle window = new Rectangle(
                //    Math.Min(mouseDownPoint.X, mousePoint.X),
                //    Math.Min(mouseDownPoint.Y, mousePoint.Y),
                //    Math.Abs(mouseDownPoint.X - mousePoint.X),
                //    Math.Abs(mouseDownPoint.Y - mousePoint.Y));
                //r.Xor(window);
                //e.Graphics.FillRegion(Brushes.Red, r);
                Rectangle rect = insideRect(this.ClientRectangle, Convert.ToInt32(penwidth));
                e.Graphics.DrawRectangle(pen[ipenindex], rect);
                ipenindex++;
                if (ipenindex >= pen.Length)
                {
                    ipenindex = 0;
                }
                //Console.WriteLine("Painted: " + window);
            }
        }

        private Rectangle insideRect(Rectangle clientRectangle, int penwidth)
        {
            return new Rectangle(clientRectangle.Left + penwidth, clientRectangle.Top + penwidth, clientRectangle.Width - 2* penwidth, clientRectangle.Height - 2* penwidth);
        }
    }
}
