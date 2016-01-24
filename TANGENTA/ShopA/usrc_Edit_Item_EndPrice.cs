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

namespace ShopA
{
    public partial class usrc_Edit_Item_EndPrice : UserControl
    {
        public usrc_Edit_Item_EndPrice()
        {
            InitializeComponent();
        }

        internal void Fill(ref Atom_ItemShopA_Price m_Atom_ItemShopA_Price)
        {
            m_Atom_ItemShopA_Price.EndPriceWithDiscountAndTax.set(nm_EndPrice.Value);

        }
        internal void Fill(ref Atom_ItemShopA_Price m_Atom_ItemShopA_Price, decimal calculated_end_price)
        {
            this.nm_EndPrice.Value = calculated_end_price;
            Fill(ref m_Atom_ItemShopA_Price);

        }
    }
}
