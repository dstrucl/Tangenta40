using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopC_Forms
{
    public partial class usrc_Item_TextSearch : UserControl
    {
        public usrc_Item_TextSearch()
        {
            InitializeComponent();
        }

        public string Item_UniqueName
        {
            get
            {
                return this.txt_Item_UniqueName.Text;
            }
            internal set
            {
                this.txt_Item_UniqueName.Text = value;
            }

        }

        internal void ShowGroup(string s1_name, string s2_name, string s3_name)
        {
            string sgroup = "..";
            if (s1_name != null)
            {
                sgroup = s1_name;
                if (s2_name != null)
                {
                    sgroup += "\\" + s2_name;
                    if (s3_name != null)
                    {
                        sgroup += "\\" + s3_name;
                    }
                }
            }
            lbl_Group.Text = sgroup;
        }
    }
}
