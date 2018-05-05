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
    public partial class usrc_EditControlWizzard_Description : UserControl
    {
        public usrc_EditControlWizzard_Description()
        {
            InitializeComponent();
        }

        public void Init(HelpWizzardTag hlpTag)
        {
            if (hlpTag != null)
            {
                int y = this.lbl_Description.Bottom + 10;
                int icountall = hlpTag.Description.tagDCs.Length;
                List<usrc_HelpWizzardTagDC> usrc_HelpWizzardTagDC_list = usrc_EditControlWizzard_About.Get_usrc_HelpWizzardTagDC_list(this);
                int icount_current = usrc_HelpWizzardTagDC_list.Count;

                if (icountall > icount_current)
                {
                    // add  controls
                    if (icount_current > 0)
                    {
                        y = usrc_HelpWizzardTagDC_list[icount_current - 1].Bottom + 4;
                    }
                    for (int i = icount_current; i < icountall; i++)
                    {
                        usrc_HelpWizzardTagDC uhlpwiztagdc = new usrc_HelpWizzardTagDC();
                        uhlpwiztagdc.BorderStyle = BorderStyle.Fixed3D;
                        uhlpwiztagdc.Top = y;
                        uhlpwiztagdc.Left = 4;
                        uhlpwiztagdc.Width = this.Width - 2 * uhlpwiztagdc.Left;
                        uhlpwiztagdc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        this.Controls.Add(uhlpwiztagdc);
                        y = uhlpwiztagdc.Bottom + 4;
                        usrc_HelpWizzardTagDC_list.Add(uhlpwiztagdc);
                    }
                }
                else if (icountall < icount_current)
                {
                    // remove controls
                    for (int i = icount_current - 1; i > icountall - 1; i--)
                    {
                        usrc_HelpWizzardTagDC uhlpwiztagdc = usrc_HelpWizzardTagDC_list[i];
                        this.Controls.Remove(uhlpwiztagdc);
                        usrc_HelpWizzardTagDC_list.RemoveAt(i);
                        uhlpwiztagdc.Dispose();
                    }
                }

                for (int i = 0; i < icountall; i++)
                {
                    HelpWizzardTagDC hlptagdc = hlpTag.Description.tagDCs[i];
                    usrc_HelpWizzardTagDC uhlpwiztagdc = usrc_HelpWizzardTagDC_list[i];
                    uhlpwiztagdc.Init(hlptagdc);
                }
            }
            else
            {
                MessageBox.Show("ERROR:HUDCMS:usrc_EditControlWizzard_Description:Init:hlpTag==null !");
            }
        }

        internal void GetData()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is usrc_HelpWizzardTagDC)
                {
                    usrc_HelpWizzardTagDC uhlpwiztagdc = (usrc_HelpWizzardTagDC)ctrl;
                    uhlpwiztagdc.Hlptagdc.Text = uhlpwiztagdc.fastColoredTextBox1.Text;
                }
            }
        }
    }
}
