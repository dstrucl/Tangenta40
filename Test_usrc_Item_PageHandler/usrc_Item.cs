
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_usrc_Item_PageHandler
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




        public enum eMode { STOCK, FACTORY, STOCK_AND_FACTORY }
        public eMode Mode = eMode.STOCK_AND_FACTORY;
        public decimal ExtraDiscount = 0;
        private decimal TotalDiscount = 0;
        private Arrangement m_Arrangement = null;
        private Color DefaultColor = Color.Gray;


        public usrc_Item()
        {
            InitializeComponent();
        }

        bool disposed = false;

        // Protected implementation of Dispose pattern. 
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            this.nmUpDn_StockQuantity.ValueChanged -=  (System.EventHandler)this.nmUpDn_StockQuantity_ValueChanged;
            this.nmUpDn_FactoryQuantity.ValueChanged -= (System.EventHandler) this.nmUpDn_FactoryQuantity_ValueChanged;
            this.btn_Discount.Click -= (System.EventHandler)this.btn_Discount_Click;
            this.btn_EditItem.Click -=  (System.EventHandler)this.btn_EditItem_Click;

            if (disposing)
            {
                int i= 0;
                for (i = Controls.Count-1;i >= 0 ;i--)
                {
                    Control c = Controls[i];
                    Controls.Remove(c);
                    c.Dispose();
                }
                Controls.Clear();
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
            // Call base class implementation. 
            base.Dispose(disposing);
        }


        public decimal dQuantity
        {
            get
            {
                switch (Mode)
                {
                    case eMode.STOCK_AND_FACTORY:
                        return GetValue(nmUpDn_StockQuantity) + GetValue(nmUpDn_FactoryQuantity);

                    case eMode.STOCK:
                        return GetValue(nmUpDn_StockQuantity);

                    case eMode.FACTORY:
                        return GetValue(nmUpDn_FactoryQuantity);

                    default:
                        return 0;
                }
            }

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

        internal void Init()
        {
        }


        private void Set_Item_Mode(eMode xeMode)
        {
            Mode = xeMode;
            switch (Mode)
            {
                case eMode.STOCK_AND_FACTORY:
                    m_Arrangement.Set(0, btn_Stock, nmUpDn_StockQuantity, true);
                    m_Arrangement.Set(1, btn_NoStock, nmUpDn_FactoryQuantity, true);
                    this.BackColor = DefaultColor;
                    break;

                case eMode.STOCK:
                    m_Arrangement.Set(0, btn_Stock, nmUpDn_StockQuantity, true);
                    m_Arrangement.Set(1, btn_NoStock, nmUpDn_FactoryQuantity, false);
                    this.BackColor = DefaultColor;
                    break;

                case eMode.FACTORY:
                    m_Arrangement.Set(0, btn_Stock, nmUpDn_StockQuantity, false);
                    m_Arrangement.Set(0, btn_NoStock, nmUpDn_FactoryQuantity, true);
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
                    break;
            }
        }


        private void Set_btn_Discount_Text()
        {
        }

        private void Set_txt_Price()
        {
        }

        internal void Init_NotInStock()
        {

        }

        private decimal Get_Stock_RetailPricePerUnit()
        {
            return 0;
        }


        private void btn_EditItem_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private bool EditItem()
        {
            return true;
        }
        private void btn_Discount_Click(object sender, EventArgs e)
        {
        }


        internal void HideStock()
        {
            this.btn_Stock.Visible = false;
            this.txt_InStock.Visible = false;
            this.nmUpDn_StockQuantity.Visible = false;
            HideAll();
        }
        internal void HideFactory()
        {
            this.btn_NoStock.Visible = false;
            this.nmUpDn_FactoryQuantity.Visible = false;
            HideAll();
        }

        private void HideAll()
        {
            if (!this.nmUpDn_FactoryQuantity.Visible && !this.nmUpDn_StockQuantity.Visible)
            {
                this.lbl_ItemPrice.Visible = false;
                this.txt_Price.Visible = false;
                btn_Discount.Visible = false;
            }
            else
            {
                this.lbl_ItemPrice.Visible = true;
                this.txt_Price.Visible = true;
                btn_Discount.Visible = true;

            }
        }

        internal void ShowFromStock()
        {
            this.btn_Stock.Visible = true;
            this.txt_InStock.Visible = true;
            this.nmUpDn_StockQuantity.Visible = true;

            this.lbl_ItemPrice.Visible = true;
            this.txt_Price.Visible = true;
            btn_Discount.Visible = true;

            Set_txt_Price();
        }

        internal void ShowFromFactory()
        {
            this.btn_NoStock.Visible = true;
            this.nmUpDn_FactoryQuantity.Visible = true;
            this.lbl_ItemPrice.Visible = true;
            this.txt_Price.Visible = true;
            btn_Discount.Visible = true;
            Set_txt_Price();
        }

        private void nmUpDn_StockQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (this.nmUpDn_StockQuantity.Value != 0)
            {
                this.btn_Stock.Enabled = true;
            }
            else
            {
                this.btn_Stock.Enabled = false;
            }

            Set_txt_Price();
        }

        private void nmUpDn_FactoryQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (this.nmUpDn_FactoryQuantity.Value != 0)
            {
                this.btn_NoStock.Enabled = true;
            }
            else
            {
                this.btn_NoStock.Enabled = false;
            }
            Set_txt_Price();
        }



        internal void ClearAll()
        {
            this.nmUpDn_StockQuantity.ValueChanged -= (System.EventHandler)this.nmUpDn_StockQuantity_ValueChanged;
            this.nmUpDn_FactoryQuantity.ValueChanged -= (System.EventHandler)this.nmUpDn_FactoryQuantity_ValueChanged;
            this.btn_Discount.Click -= (System.EventHandler)this.btn_Discount_Click;
            this.btn_EditItem.Click -= (System.EventHandler)this.btn_EditItem_Click;
            foreach (Control ctrl in Controls)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                ctrl.Dispose();
                if (!ctrl.IsDisposed)
                {
                    MessageBox.Show("!ctrl.IsDisposed");
                }
            }
        }
    }
}
