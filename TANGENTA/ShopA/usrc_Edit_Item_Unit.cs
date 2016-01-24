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
using LanguageControl;

namespace ShopA
{
    public partial class usrc_Edit_Item_Unit : UserControl
    {
        public decimal dEndPrice = 0;
        public decimal dPricePerUnit = 0;
        public decimal dQuantity = 0;

        xUnitList m_xUnitList = null;
        public usrc_Edit_Item_Unit()
        {
            InitializeComponent();
            lbl_Price.Text = "";
            chk_Unit.CheckedChanged += Chk_Unit_CheckedChanged;
            chk_Unit.Checked = false;
            enable(chk_Unit.Checked);
        }

        private void enable(bool bEnabled)
        { 
            if (bEnabled)
            {
                this.cmb_Unit.Enabled = true;
                this.nm_dQuantity.Enabled = true;
                this.nm_PricePerUnit.Enabled = true;
                this.lbl_Item_Unit.Enabled = true;
                this.lbl_Price.Enabled = true;
                this.lbl_PricePerUnit.Enabled = true;
                this.lbl_Quantity.Enabled = true;
            }
            else
            {
                this.cmb_Unit.Enabled = false;
                this.nm_dQuantity.Enabled = false;
                this.nm_PricePerUnit.Enabled = false;
                this.lbl_Item_Unit.Enabled = false;
                this.lbl_Price.Enabled = false;
                this.lbl_PricePerUnit.Enabled = false;
                this.lbl_Quantity.Enabled = false;
            }
     }

    private void Chk_Unit_CheckedChanged(object sender, EventArgs e)
        {
            enable(chk_Unit.Checked);
        }

        public void Init(xUnitList xxUnitList)
        {
            m_xUnitList = xxUnitList;
            this.cmb_Unit.DataSource = m_xUnitList.items;
            this.cmb_Unit.DisplayMember = "Name";
            this.cmb_Unit.ValueMember = "Index";
        }

        internal void Fill(ref Unit xUnit)
        {
            if (chk_Unit.Checked)
            {
                if (this.cmb_Unit.SelectedValue is int)
                {
                    int i = (int)this.cmb_Unit.SelectedValue;
                    xUnit.ID.set(m_xUnitList.items[i].ID);
                    xUnit.StorageOption.set(m_xUnitList.items[i].StorageOption);
                    xUnit.Symbol.set(m_xUnitList.items[i].Symbol);
                    xUnit.Description.set(m_xUnitList.items[i].Description);
                }
            }
            else
            {
                xUnit.ID.set(null);
                xUnit.Name.set(null);
                xUnit.Symbol.set(null);
                xUnit.StorageOption.set(null);
                xUnit.DecimalPlaces.set(null);
                xUnit.Description.set(null);
            }
        }

        private void nm_dQuantity_ValueChanged(object sender, EventArgs e)
        {
            dQuantity = nm_dQuantity.Value;
            CalculateEndPrice();
        }

        private void nm_PricePerUnit_ValueChanged(object sender, EventArgs e)
        {
            dPricePerUnit = nm_PricePerUnit.Value;
            CalculateEndPrice();
        }

        private void CalculateEndPrice()
        {
            dEndPrice = dPricePerUnit * dQuantity;
            lngRPM.s_Price_for.Text(lbl_Price, dQuantity.ToString() + " " + cmb_Unit.Text + " = " + dEndPrice.ToString());
        }

    }
}
