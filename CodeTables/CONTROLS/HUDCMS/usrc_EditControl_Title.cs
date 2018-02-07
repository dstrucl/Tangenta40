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
    public partial class usrc_EditControl_Title : UserControl
    {
        public List<string> heading_list = new List<string>();
        public usrc_EditControl_Title()
        {
            InitializeComponent();
            heading_list.Add("h1");
            heading_list.Add("h2");
            heading_list.Add("h3");
            heading_list.Add("h4");
            heading_list.Add("h5");
            heading_list.Add("h6");
            this.cmb_HtmlTag.DataSource = heading_list;
            this.cmb_HtmlTag.SelectedIndex = 0;
        }

        internal void SetHeadingTag(string headingTag)
        {
            if (headingTag!=null)
            {
                if (headingTag.Length == 2)
                {
                    string sheading = Convert.ToString(headingTag[1]);
                    int iIndex = Convert.ToInt32(sheading) -1;
                    this.cmb_HtmlTag.SelectedIndex = iIndex;
                }
            }
        }
    }
}
