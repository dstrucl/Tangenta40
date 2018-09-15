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
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
