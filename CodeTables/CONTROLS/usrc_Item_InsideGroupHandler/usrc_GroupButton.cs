using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usrc_Item_InsideGroup_Handler
{
    public partial class usrc_GroupButton : UserControl
    {
        public new event EventHandler<EventArgs> Click;

        protected override void OnClick(EventArgs e)
        {
            EventArgs myArgs = new EventArgs();
            EventHandler<EventArgs> myEvent = Click;
            if (myEvent != null)
                myEvent(this, myArgs);
            base.OnClick(e);
        }

    

        public usrc_GroupButton()
        {
            InitializeComponent();
        }
        public string Title
        {
            get
            {
                return this.button1.Text;
            }
            set
            {
                this.button1.Text = value;
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            OnClick(e);
        }
    }
}
