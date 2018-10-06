using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usrc_NumKeypad
{
    public partial class usrc_NumKeys : UserControl
    {
        public delegate void delegate_ButtonClicked(char ch);
        public event delegate_ButtonClicked ButtonClicked = null;

        public char DecimalPoint
        {
            get
            {
                return btn_DecimalPoint.Text[0];
            }
            set
            {
                btn_DecimalPoint.Text = value.ToString();
            }
        }
        public usrc_NumKeys()
        {
            InitializeComponent();
            this.button0.Click += Button_Click;
            this.button1.Click += Button_Click;
            this.button2.Click += Button_Click;
            this.button3.Click += Button_Click;
            this.button4.Click += Button_Click;
            this.button5.Click += Button_Click;
            this.button6.Click += Button_Click;
            this.button7.Click += Button_Click;
            this.button8.Click += Button_Click;
            this.button9.Click += Button_Click;
            this.btn_DecimalPoint.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                if (ButtonClicked!=null)
                {
                    ButtonClicked(((Button)sender).Text[0]);
                }
            }
        }
    }
}
