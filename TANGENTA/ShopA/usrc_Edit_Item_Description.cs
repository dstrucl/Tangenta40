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
using DBTypes;

namespace ShopA
{
    public partial class usrc_Edit_Item_Description : UserControl
    {
        public usrc_Edit_Item_Description()
        {
            InitializeComponent();
        }

        internal void Fill(ref Atom_ItemShopA_Price m_Atom_ItemShopA_Price)
        {
            throw new NotImplementedException();
        }

        internal void Fill(ref Atom_ItemShopA m_Atom_ItemShopA)
        {
            if (this.txt_Item_Description.Text.Length>0)
            {
                m_Atom_ItemShopA.Description.set(this.txt_Item_Description.Text);
            }
            else
            {
                m_Atom_ItemShopA.Description.set(null);
            }
        }

        internal void SetControls(string_v type_v)
        {
            this.txt_Item_Description.Text = "";
            if (type_v != null)
            {
                if (type_v is string_v)
                {
                    this.txt_Item_Description.Text = type_v.v;
                }
            }
        }
    }
}
