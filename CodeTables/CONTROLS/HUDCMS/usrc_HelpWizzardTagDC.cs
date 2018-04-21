using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class usrc_HelpWizzardTagDC : UserControl
    {
        public usrc_HelpWizzardTagDC()
        {
            InitializeComponent();
        }

        internal void Init(HelpWizzardTagDC hlptagdc)
        {
            this.txt_Condition.Text = "Name:" + hlptagdc.Name + ",Type:" + hlptagdc.Type + ",Condition:" + hlptagdc.condtition;
            this.fastColoredTextBox1.Text = hlptagdc.Text;
        }
    }
}
