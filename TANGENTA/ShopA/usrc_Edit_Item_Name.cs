using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlagajnaTableClass;
using LanguageControl;
using DBTypes;

namespace ShopA
{
    public partial class usrc_Edit_Item_Name : UserControl
    {
        public string ItemName {
                                    get { return txt_ItemName.Text; }
                               }

        public usrc_Edit_Item_Name()
        {
            InitializeComponent();
        }

        private void txt_ItemName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        internal bool Fill(ref Atom_ItemShopA m_Atom_ItemShopA)
        {
            if (this.txt_ItemName.Text.Length > 0)
            {
                m_Atom_ItemShopA.Name.set(this.txt_ItemName.Text);
                return true;
            }
            else
            {
                MessageBox.Show(this, lngRPM.s_Item_name_must_be_defined.s);
                return false;
            }
        }

        internal void SetControls(string_v type_v)
        {
            this.txt_ItemName.Text = "";
            if (type_v!=null)
            {
                if (type_v is string_v)
                {
                    this.txt_ItemName.Text = type_v.v;
                }
            }
        }
    }
}
