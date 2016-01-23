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

namespace ShopA
{
    public partial class usrc_Edit_Item_Tax : UserControl
    {
        xTaxationList m_xTaxationList = null;
        DataTable dt_Taxation = new DataTable();
        public usrc_Edit_Item_Tax()
        {
            InitializeComponent();
        }
        public void Init(xTaxationList xTaxationList)
        {
            m_xTaxationList = xTaxationList;
            this.cmb_TaxRate.DataSource = m_xTaxationList.items;
            this.cmb_TaxRate.DisplayMember = "Name";
            this.cmb_TaxRate.ValueMember = "Rate";
        }
    }
}
