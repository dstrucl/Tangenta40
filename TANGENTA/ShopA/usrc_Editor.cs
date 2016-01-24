using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceDB;
using BlagajnaTableClass;

namespace ShopA
{
    public partial class usrc_Editor : UserControl
    {
        ShopABC m_ShopABC = null;
        Atom_ItemShopA_Price m_Atom_ItemShopA_Price = null;
        public usrc_Editor()
        {
            InitializeComponent();
        }

        private void usrc_Edit_Item_Name2_Load(object sender, EventArgs e)
        {

        }

        internal void Init(ShopABC xShopABC, Atom_ItemShopA_Price xAtom_ItemShopA_Price)
        {
            m_ShopABC = xShopABC;
            m_Atom_ItemShopA_Price = xAtom_ItemShopA_Price;
            this.usrc_Edit_Item_Tax1.Init(m_ShopABC.m_xTaxationList);
            this.usrc_Edit_Item_Unit1.Init(m_ShopABC.m_xUnitList);
        }

        private void btn_AddNewLine_Click(object sender, EventArgs e)
        {
            if (Fill())
            {

            }
        }

        private bool Fill()
        {
            if (this.usrc_Edit_Item_Name1.Fill(ref m_Atom_ItemShopA_Price.m_Atom_ItemShopA))
            {
                if (this.usrc_Edit_Item_Tax1.Fill(ref m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Taxation))
                {
                    this.usrc_Edit_Item_Description1.Fill(ref m_Atom_ItemShopA_Price.m_Atom_ItemShopA);
                    this.usrc_Edit_Item_Unit1.Fill(ref m_Atom_ItemShopA_Price.m_Atom_ItemShopA.m_Unit);
                    this.usrc_Edit_Item_EndPrice1.Fill(ref m_Atom_ItemShopA_Price);
                    return true;
                }

            }
            return false;
        }
    }
}
