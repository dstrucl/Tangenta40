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
    public partial class usrc_Edit_Item_Tax : UserControl
    {
        xTaxationList m_xTaxationList = null;
        DataTable dt_Taxation = new DataTable();
        Color default_backcolor;

        public bool Fill(ref Taxation xTaxation)
        {
            if (this.cmb_TaxRate.SelectedValue is long)
            {
                long i = (long) this.cmb_TaxRate.SelectedValue;
                xTaxation.ID.set(m_xTaxationList.items[i].ID);
                xTaxation.Name.set(m_xTaxationList.items[i].Name);
                xTaxation.Rate.set(m_xTaxationList.items[i].Rate);
                this.BackColor = default_backcolor;
                return true;
            }
            else
            {
                this.BackColor = Color.Red;
                xTaxation.ID.set(null);
                xTaxation.Name.set(null);
                xTaxation.Rate.set(null);
                MessageBox.Show(this, lngRPM.s_TaxRate_must_be_defined.s);
                return false;
            }
        }

        public usrc_Edit_Item_Tax()
        {
            InitializeComponent();
            default_backcolor = BackColor;
        }
        public void Init(xTaxationList xTaxationList)
        {
            m_xTaxationList = xTaxationList;
            this.cmb_TaxRate.DataSource = m_xTaxationList.items;
            this.cmb_TaxRate.DisplayMember = "Name";
            this.cmb_TaxRate.ValueMember = "Index";
        }
    }
}
