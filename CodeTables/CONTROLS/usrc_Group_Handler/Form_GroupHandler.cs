using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace usrc_Item_Group_Handler
{
    public partial class Form_GroupHandler : Form
    {
        public Form_GroupHandler()
        {
            InitializeComponent();
        }

        public void SetLevel2()
        {
            this.splitContainer2.Panel2Collapsed = true;
        }

        public void SetLevel3()
        {
            this.splitContainer2.Panel2Collapsed = false;
        }

        private void Form_GroupHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }
    }
}
