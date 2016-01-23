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
using ShopA_dbfunc;
using BlagajnaTableClass;

namespace ShopA
{
    public partial class usrc_ShopA: UserControl
    {
        ShopBC m_ShopBC = null;
        DBTablesAndColumnNames DBtcn = null;
        DataTable dt_Item_Price = new DataTable();
        Atom_ItemShopA_Price m_Atom_ItemShopA_Price = new Atom_ItemShopA_Price();

        public usrc_ShopA()
        {
            InitializeComponent();
        }

        public void Init(ShopBC xm_ShopBC, DBTablesAndColumnNames xDBtcn)
        {
            m_ShopBC = xm_ShopBC;
            DBtcn = xDBtcn;
            dt_Item_Price.Clear();
            if (dbfunc.ReadItems(ref dt_Item_Price, ref m_Atom_ItemShopA_Price, m_ShopBC.m_CurrentInvoice.ProformaInvoice_ID))
            {

            }
                
        }

        private void usrc_Editor1_Load(object sender, EventArgs e)
        {

        }
    }
}
