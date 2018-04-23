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
        internal HelpWizzardTagDC Hlptagdc = null;
        public usrc_HelpWizzardTagDC()
        {
            InitializeComponent();
        }

        internal void Init(HelpWizzardTagDC xhlptagdc)
        {
            Hlptagdc = xhlptagdc;
            this.txt_Condition.Text = "Name:" + Hlptagdc.Name + ",Type:" + Hlptagdc.Type + ",Condition:" + Hlptagdc.condtition;
            this.fastColoredTextBox1.Text = Hlptagdc.Text;
        }
    }
}
