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
using InvoiceDB;
using BlagajnaTableClass;
using LanguageControl;
using DBTypes;

namespace ShopA
{
    public partial class usrc_Edit_Item_Unit : UserControl
    {
        xUnitList m_xUnitList = null;

        public delegate void delegate_ValueChanged();
        public event delegate_ValueChanged ValueChanged;

        public delegate bool delegate_EditUnis();
        public event delegate_EditUnis EditUnits;

        private decimal_v dPriceSum_v = null;
        private decimal_v dPricePerUnit_v = null;
        private decimal_v dQuantity_v = null;

        private Unit m_Unit = null;

        public Unit Unit
        {
            get
            {
                if (chk_Unit.Checked)
                {
                    if ((this.cmb_Unit.SelectedValue is long)|| (this.cmb_Unit.SelectedValue is int))
                    {
                        long i = Convert.ToInt64(this.cmb_Unit.SelectedValue);
                        m_Unit.ID.set(m_xUnitList.items[i].ID);
                        m_Unit.Name.set(m_xUnitList.items[i].Name);
                        m_Unit.DecimalPlaces.set(Convert.ToInt16(m_xUnitList.items[i].DecimalPlaces));
                        m_Unit.StorageOption.set(m_xUnitList.items[i].StorageOption);
                        m_Unit.Symbol.set(m_xUnitList.items[i].Symbol);
                        m_Unit.Description.set(m_xUnitList.items[i].Description);
                        return m_Unit;
                    }
                }
                m_Unit.ID.set(null);
                m_Unit.Name.set(null);
                m_Unit.Symbol.set(null);
                m_Unit.StorageOption.set(null);
                m_Unit.DecimalPlaces.set(null);
                m_Unit.Description.set(null);
                return m_Unit;
            }
        }

        public decimal PricePerUnit
        {
            get
            {
                if (chk_Unit.Checked)
                {
                    return nm_PricePerUnit.Value;
                }
                else
                {
                    return 0;
                }
            }
        }

        public decimal Quantity
        {
            get
            {
                if (chk_Unit.Checked)
                {
                    return nm_dQuantity.Value;
                }
                else
                {
                    return 0;
                }
            }
        }

        public decimal_v PriceSum_v
        {
            get {  if (chk_Unit.Checked)
                    {
                       return dPriceSum_v;
                    }
                    else
                    {
                        return null;
                    }
                }
        }

        public decimal_v Quantity_v
        {
            get
            {
                if (chk_Unit.Checked)
                {
                    return dQuantity_v;
                }
                else
                {
                    return null;
                }
            }
        }

        public decimal_v PricePerUnit_v
        {
            get
            {
                if (chk_Unit.Checked)
                {
                    return dPricePerUnit_v;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool UnitsEnabled
        {
            get { return chk_Unit.Checked; }
        }

        public usrc_Edit_Item_Unit()
        {
            InitializeComponent();
            dPriceSum_v = new decimal_v(0);
            dPricePerUnit_v = new decimal_v();
            dQuantity_v = new decimal_v();
            m_Unit = new Unit();
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
            if (ValueChanged!=null)
            {
                ValueChanged();
            }

        }
        private void Set_DataSource()
        {
            this.cmb_Unit.DataSource = m_xUnitList.items;
            this.cmb_Unit.DisplayMember = "Name";
            this.cmb_Unit.ValueMember = "Index";
            
        }

        public void Init(xUnitList xxUnitList)
        {
            m_xUnitList = xxUnitList;
            Set_DataSource();
            this.cmb_Unit.SelectedValueChanged += new System.EventHandler(this.cmb_Unit_SelectedValueChanged);
        }

        internal void Fill(ref Unit xUnit)
        {
            if (chk_Unit.Checked)
            {
                if ((this.cmb_Unit.SelectedValue is long)|| (this.cmb_Unit.SelectedValue is int))
                {
                    long i =  Convert.ToInt64(this.cmb_Unit.SelectedValue);
                    xUnit.ID.set(m_xUnitList.items[i].ID);
                    xUnit.Name.set(m_xUnitList.items[i].Name);
                    xUnit.DecimalPlaces.set(Convert.ToInt16(m_xUnitList.items[i].DecimalPlaces));
                    xUnit.StorageOption.set(m_xUnitList.items[i].StorageOption);
                    xUnit.Symbol.set(m_xUnitList.items[i].Symbol);
                    xUnit.Description.set(m_xUnitList.items[i].Description);
                    m_Unit.ID.set(m_xUnitList.items[i].ID);
                    m_Unit.Name.set(m_xUnitList.items[i].Name);
                    m_Unit.DecimalPlaces.set(Convert.ToInt16(m_xUnitList.items[i].DecimalPlaces));
                    m_Unit.StorageOption.set(m_xUnitList.items[i].StorageOption);
                    m_Unit.Symbol.set(m_xUnitList.items[i].Symbol);
                    m_Unit.Description.set(m_xUnitList.items[i].Description);
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
                m_Unit.ID.set(null);
                m_Unit.Name.set(null);
                m_Unit.Symbol.set(null);
                m_Unit.StorageOption.set(null);
                m_Unit.DecimalPlaces.set(null);
                m_Unit.Description.set(null);
            }
        }

        internal void SetControls(Unit m_Unit)
        {
            this.cmb_Unit.SelectedValueChanged -= new System.EventHandler(this.cmb_Unit_SelectedValueChanged);
            if (m_Unit.ID.type_v!=null)
             {
                this.chk_Unit.Checked = true;
                int i = FindIndex(m_Unit.ID.type_v.v);
                if (i>=0)
                {
                    cmb_Unit.SelectedIndex =  i;
                    if (m_Unit.DecimalPlaces.type_v != null)
                    {
                        nm_dQuantity.DecimalPlaces = Convert.ToInt32(m_Unit.DecimalPlaces.type_v.v);
                    }
                }
             }
             else
             {
                this.chk_Unit.Checked = false;
            }
            this.cmb_Unit.SelectedValueChanged += new System.EventHandler(this.cmb_Unit_SelectedValueChanged);
        }

        private int FindIndex(long ID)
        {
            int i = 0;
            int iCount = m_xUnitList.items.Count();
            for(i =0;i< iCount;i++ )
            {
                if (ID == m_xUnitList.items[i].ID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void nm_dQuantity_ValueChanged(object sender, EventArgs e)
        {
            CalculatePriceSum();
            if (ValueChanged!=null)
            {
                ValueChanged();
            }
        }

        private void nm_PricePerUnit_ValueChanged(object sender, EventArgs e)
        {
            CalculatePriceSum();
            if (ValueChanged!=null)
            {
                ValueChanged();
            }
        }

        private void CalculatePriceSum()
        {
            dPriceSum_v.v = nm_PricePerUnit.Value * nm_dQuantity.Value;
            dQuantity_v.v = nm_dQuantity.Value;
            dPricePerUnit_v.v = nm_PricePerUnit.Value;
            lngRPM.s_Price_for.Text(lbl_Price, dQuantity_v.v.ToString() + " " + cmb_Unit.Text + " = " + dPriceSum_v.v.ToString() +" "+ GlobalData.BaseCurrency.Symbol);
        }

        private void cmb_Unit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (chk_Unit.Checked)
            {
                if ((this.cmb_Unit.SelectedValue is long) || (this.cmb_Unit.SelectedValue is int))
                {
                    long i = Convert.ToInt64(this.cmb_Unit.SelectedValue);
                    nm_dQuantity.DecimalPlaces = m_xUnitList.items[i].DecimalPlaces;
                }
            }

            if (ValueChanged != null)
            {
                ValueChanged();
            }
        }

        public void set_when_endprice_changed(decimal dPriceSum)
        {
            if (chk_Unit.Checked)
            {
                if (nm_dQuantity.Value == 0)
                {
                    nm_dQuantity.ValueChanged -= nm_dQuantity_ValueChanged;
                    nm_dQuantity.Value = 1;
                    nm_dQuantity.ValueChanged += nm_dQuantity_ValueChanged;
                }
                nm_PricePerUnit.ValueChanged -= nm_PricePerUnit_ValueChanged;
                nm_PricePerUnit.Value = dPriceSum / nm_dQuantity.Value;
                nm_PricePerUnit.ValueChanged += nm_PricePerUnit_ValueChanged;
            }
        }

        private void btn_Edit_Units_Click(object sender, EventArgs e)
        {
            if (EditUnits!=null)
            {
                if (EditUnits())
                {
                    Set_DataSource();
                }
            }
        }
    }
}
