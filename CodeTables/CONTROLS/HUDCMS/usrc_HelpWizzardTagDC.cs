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
            if (Hlptagdc.Name != null)
            {
                this.txt_Name.Text = Hlptagdc.Name;
            }
            if (Hlptagdc.Type != null)
            {
                this.txt_Type.Text = Hlptagdc.Type;
            }
            if (Hlptagdc.condtition != null)
            {
                this.txt_Condition.Text = Hlptagdc.condtition;
                this.txt_Name.Text += "$" + Hlptagdc.condtition;
            }
            this.fastColoredTextBox1.Text = Hlptagdc.Text;
        }
        
    }
}
