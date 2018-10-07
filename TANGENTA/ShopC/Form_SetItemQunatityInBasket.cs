using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace ShopC
{
    public partial class Form_SetItemQuantityInBasket : Form
    {

        private usrc_Item1366x768_selected m_usrc_Item1366x768_selected = null;
        private usrc_Atom_Item1366x768 m_usrc_Atom_Item1366x768 = null;
        private Atom_DocInvoice_ShopC_Item_Price_Stock_Data m_appisd = null;
        private Item_Data m_itemdata = null;
        private usrc_Item1366x768 m_usrc_Item1366x768 = null;


        public Form_SetItemQuantityInBasket()
        {
            InitializeComponent();
        }

        public Form_SetItemQuantityInBasket(ShopABC xShopBC,
            usrc_Item1366x768_selected xusrc_Item1366x768_selected,
            usrc_Atom_Item1366x768 xusrc_Atom_Item1366x768,
            Atom_DocInvoice_ShopC_Item_Price_Stock_Data xappisd,
            Item_Data idata,
            usrc_Item1366x768 xusrc_Item1366x768
            )
        {
            InitializeComponent();
            m_usrc_Item1366x768_selected = xusrc_Item1366x768_selected;
            m_usrc_Atom_Item1366x768 = xusrc_Atom_Item1366x768;
            m_appisd = xappisd;
            m_itemdata = idata;
            m_usrc_Item1366x768 = xusrc_Item1366x768;
            usrc_SetItemQuantityInBasket1.Init(xShopBC,
                                               m_usrc_Item1366x768_selected,
                                               m_usrc_Atom_Item1366x768,
                                              xappisd,
                                              idata,
                                              xusrc_Item1366x768);
        }

        private void usrc_SetItemQuantityInBasket1_ExitClick()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
