#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaTableClass;
using DBTypes;

namespace ShopA
{
    public partial class usrc_Edit_Item_Description : UserControl
    {
        public usrc_Edit_Item_Description()
        {
            InitializeComponent();
        }

        internal void Fill(ref DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item)
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

        internal void Clear()
        {
            this.txt_Item_Description.Clear();
        }
    }
}
