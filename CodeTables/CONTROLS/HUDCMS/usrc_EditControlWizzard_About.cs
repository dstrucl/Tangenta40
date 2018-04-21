using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class usrc_EditControlWizzard_About : UserControl
    {
        public usrc_EditControlWizzard_About()
        {
            InitializeComponent();
        }

        public void Init(HelpWizzardTag hlpTag)
        {
            if (hlpTag!=null)
            {
                foreach (HelpWizzardTagDC hlptagdc in hlpTag.tagDCs)
                {

                }
            }
            else
            {
                MessageBox.Show("ERROR:HUDCMS:usrc_EditControlWizzard_About:Init:hlpTag==null !");
            }
        }

    }
}
