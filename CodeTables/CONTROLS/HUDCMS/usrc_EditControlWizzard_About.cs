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
                int y = this.lbl_AboutControl.Bottom + 10;
                foreach (HelpWizzardTagDC hlptagdc in hlpTag.tagDCs)
                {
                    usrc_HelpWizzardTagDC hlpwiztagdc = new usrc_HelpWizzardTagDC();
                    hlpwiztagdc.Init(hlptagdc);
                    hlpwiztagdc.BorderStyle = BorderStyle.Fixed3D;
                    hlpwiztagdc.Top = y;
                    hlpwiztagdc.Left = 4;
                    this.Controls.Add(hlpwiztagdc);
                    y = hlpwiztagdc.Bottom + 4;
                }
            }
            else
            {
                MessageBox.Show("ERROR:HUDCMS:usrc_EditControlWizzard_About:Init:hlpTag==null !");
            }
        }

    }
}
