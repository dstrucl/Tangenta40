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

namespace ShopC_Forms
{
    public partial class Form_SetItemQuantityInBasket : Form
    {

        private usrc_CItem_selected m_usrc_Item_selected = null;
        private usrc_Atom_CItem m_usrc_Atom_Item = null;
        private TangentaDB.Consumption_ShopC_Item m_dsci = null;
        private Item_Data m_itemdata = null;
        private usrc_CItem m_usrc_Item = null;


        public Form_SetItemQuantityInBasket()
        {
            InitializeComponent();
        }

        public Form_SetItemQuantityInBasket(ConsumptionEditor xconsE,
            usrc_CItem_selected xusrc_Item_selected,
            usrc_Atom_CItem xusrc_Atom_Item,
            TangentaDB.Consumption_ShopC_Item xdsci,
            Item_Data idata,
            usrc_CItemList xusrc_ItemList,
            usrc_CItem xusrc_Item
            )
        {
            InitializeComponent();
            m_usrc_Item_selected = xusrc_Item_selected;
            m_usrc_Atom_Item = xusrc_Atom_Item;
            m_dsci = xdsci;
            m_itemdata = idata;
            m_usrc_Item = xusrc_Item;
            usrc_SetItemQuantityInBasket1.Init(xconsE,
                                               m_usrc_Item_selected,
                                               m_usrc_Atom_Item,
                                              xdsci,
                                              idata,
                                              xusrc_ItemList,
                                              xusrc_Item);
        }

        private void usrc_SetItemQuantityInBasket1_ExitClick()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
