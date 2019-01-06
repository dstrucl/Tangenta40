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

namespace ShopB_Forms
{
    public partial class Form_Atom_ShopB_Item_Check : Form
    {
        DataTable dt_DocInvoice_ShopB_Item_VIEW = null;
        DataTable dt_DocProformaInvoice_ShopB_Item_VIEW = null;

        public Form_Atom_ShopB_Item_Check()
        {
            InitializeComponent();
        }

        public bool Init()
        {
             dgvx_DocInvoice_ShopB_Item.DataSource = null;
             if (f_DocInvoice_ShopB_Item.GetView(ref dt_DocInvoice_ShopB_Item_VIEW))
             {
                dgvx_DocInvoice_ShopB_Item.DataSource = dt_DocInvoice_ShopB_Item_VIEW;
                dgvx_DocProformaInvoice_ShopB_Item.DataSource = null;
                if (f_DocProformaInvoice_ShopB_Item.GetView(ref dt_DocProformaInvoice_ShopB_Item_VIEW))
                {
                    dgvx_DocProformaInvoice_ShopB_Item.DataSource = dt_DocProformaInvoice_ShopB_Item_VIEW;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void Form_Atom_SimpleItem_Check_Load(object sender, EventArgs e)
        {
            if (!Init())
            {
                this.Close();
                DialogResult = DialogResult.Abort;
                return;
            }
            this.dgvx_DocInvoice_ShopB_Item.SelectionChanged += new System.EventHandler(this.dgvx_DocInvoice_ShopB_Item_SelectionChanged);
        }

        private void dgvx_DocInvoice_ShopB_Item_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
