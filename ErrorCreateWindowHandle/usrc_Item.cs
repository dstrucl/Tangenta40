
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ErrorCreateWindowHandle
{
    public partial class usrc_Item : UserControl
    {
        private class ControlPos
        {
            public int left_pos_initial_of_button = -1;
            public int left_pos_initial_of_nmUpDn = -1;
            public ControlPos(Button xbtn, NumericUpDown xnmUpDown)
            {
                left_pos_initial_of_button = xbtn.Left;
                left_pos_initial_of_nmUpDn = xnmUpDown.Left;
            }
        }
        private class Arrangement
        {
            ControlPos[] m_ControlPos = new ControlPos[2];

            public void Define(int index,Button xbtn,NumericUpDown xnmUpDown)
            {
                m_ControlPos[index] = new ControlPos(xbtn,xnmUpDown);
            }

            public void Set(int index, Button xbtn, NumericUpDown xnmUpDown, bool bVisible)
            {
                xbtn.Left = m_ControlPos[index].left_pos_initial_of_button;
                xbtn.Visible = bVisible;
                xnmUpDown.Left = m_ControlPos[index].left_pos_initial_of_nmUpDn;
                xnmUpDown.Visible = bVisible;
            }

        }


        public delegate void delegate_ItemAdded (/*pias_Atom_Item pias,*/ bool bNew);
        public event delegate_ItemAdded ItemAdded = null;


        public enum eMode { STOCK, FACTORY, STOCK_AND_FACTORY }
        public eMode Mode = eMode.STOCK_AND_FACTORY;
        //public Item Item = null;
        //private usrc_Atom_ItemsList m_usrc_Atom_ItemsList = null;
        //public List<CurrentInvoice.Price_Item_Stock> List_stock = new List<CurrentInvoice.Price_Item_Stock>();
        //public CurrentInvoice.Price_Item_Stock price_item_factory = null;
        public decimal ExtraDiscount = 0;
        //public usrc_Atom_Item m_usrc_Atom_Item = null;
        private decimal TotalDiscount = 0;
        private Arrangement m_Arrangement = null;
        private Color DefaultColor = Color.Gray;


        public usrc_Item()
        {
            InitializeComponent();
            //Item = new BlagajnaTableClass.Item();
            m_Arrangement = new Arrangement();
            m_Arrangement.Define(0, btn_Stock, nmUpDn_StockQuantity);
            m_Arrangement.Define(1, btn_NoStock, nmUpDn_FactoryQuantity);
            DefaultColor = BackColor;
        }

        bool disposed = false;

        // Protected implementation of Dispose pattern. 
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

                int i= 0;
                for (i = Controls.Count-1;i >=0 ;i--)
                {
                    Control c = Controls[i];
                    Controls.Remove(c);
                    string name = c.Name;
                    c.Dispose();
                    if (!c.IsDisposed)
                    {
                        MessageBox.Show("Control " + name + " is not disposed!");
                    }
                }
                Controls.Clear();
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
            // Call base class implementation. 
            base.Dispose(disposing);
        }


        private decimal GetValue(NumericUpDown nmUpDn_Quantity)
        {
            if (nmUpDn_Quantity.Visible)
            {
                return nmUpDn_Quantity.Value;
            }
            else
            {
                return 0;
            }
        }

        internal void Init(int i)
        {
            decimal dAllStockQuantity = 0;
                nmUpDn_StockQuantity.Minimum = 0;
                nmUpDn_StockQuantity.Maximum = 100;
                nmUpDn_StockQuantity.Value = 1;
                nmUpDn_StockQuantity.Increment = 1;

                nmUpDn_FactoryQuantity.Increment = 1;
                nmUpDn_FactoryQuantity.Value = 0;
                nmUpDn_FactoryQuantity.Minimum = 0;
                nmUpDn_FactoryQuantity.Maximum = 10000000;

            this.txt_InStock.Text = dAllStockQuantity.ToString();
            this.lbl_Item.Text = i.ToString();
            //this.lbl_Item.Text = "xprice_item_stock.Item_UniqueName"; //xprice_item_stock.Item_UniqueName.v;
            this.txt_Item_Description.Text = "xprice_item_stock.Item_Description.v";

        }

     

     













    }
}
