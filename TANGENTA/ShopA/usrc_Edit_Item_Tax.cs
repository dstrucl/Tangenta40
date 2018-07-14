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
using TangentaDB;
using TangentaTableClass;
using LanguageControl;

namespace ShopA
{
    public partial class usrc_Edit_Item_Tax : UserControl
    {
        public delegate void delegate_ValueChanged();
        public event delegate_ValueChanged ValueChanged;

        xTaxationList m_xTaxationList = null;
        DataTable dt_Taxation = new DataTable();
        Color default_backcolor;
        public Taxation m_Taxation = null;

        public Taxation Taxation
        {
            get
            {
                if (this.cmb_TaxRate.SelectedValue is long)
                {
                    long i = (long)this.cmb_TaxRate.SelectedValue;
                    m_Taxation.ID.Set(m_xTaxationList.items[i].ID);
                    m_Taxation.Name.set(m_xTaxationList.items[i].Name);
                    m_Taxation.Rate.set(m_xTaxationList.items[i].Rate);
                    return m_Taxation;
                }
                else
                {
                    //MessageBox.Show(this, lng.s_TaxRate_must_be_defined.s);
                    return null;
                }
            }

    }

        public decimal TaxRate {
                                get {
                                        if (this.cmb_TaxRate.SelectedValue is long)
                                        {
                                            long i = (long)this.cmb_TaxRate.SelectedValue;
                                            return m_xTaxationList.items[i].Rate;
                                        }
                                        else
                                        {
                                            //LogFile.Error.Show("ERROR:usrc_Edit_Item_Tax:TaxRate:!(this.cmb_TaxRate.SelectedValue is long)");
                                            return 0;
                                        }
                                    }
                                 }

        public bool Fill(ref Taxation xTaxation)
        {
            if (this.cmb_TaxRate.SelectedValue is long)
            {
                long i = (long) this.cmb_TaxRate.SelectedValue;
                xTaxation.ID.Set(m_xTaxationList.items[i].ID);
                xTaxation.Name.set(m_xTaxationList.items[i].Name);
                xTaxation.Rate.set(m_xTaxationList.items[i].Rate);
                this.BackColor = default_backcolor;
                return true;
            }
            else
            {
                this.BackColor = Color.Red;
                xTaxation.ID.Set(null);
                xTaxation.Name.set(null);
                xTaxation.Rate.set(null);
                //MessageBox.Show(this, lng.s_TaxRate_must_be_defined.s);
                return false;
            }
        }

        public usrc_Edit_Item_Tax()
        {
            InitializeComponent();
            m_Taxation = new Taxation();
            default_backcolor = BackColor;
        }

        private void Cmb_TaxRate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged!=null)
            {
                ValueChanged();
            }
            
        }

        public void Init(xTaxationList xTaxationList)
        {
            m_xTaxationList = xTaxationList;
            lng.s_lbl_Item_TaxRate.Text(lbl_Item_TaxRate);
            this.cmb_TaxRate.DataSource = m_xTaxationList.items;
            this.cmb_TaxRate.DisplayMember = "Name";
            this.cmb_TaxRate.ValueMember = "Index";
            cmb_TaxRate.SelectedValueChanged += Cmb_TaxRate_SelectedValueChanged;
        }
    }
}
