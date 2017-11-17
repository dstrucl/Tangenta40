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
                MessageBox.Show(this, lng.s_Item_name_must_be_defined.s);
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

        internal void Clear()
        {
            this.txt_ItemName.Clear();
        }
    }
}
