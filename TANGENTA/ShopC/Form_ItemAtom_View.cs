using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ShopC
{
    public partial class Form_Atom_Item_View : Form
    {
        private InvoiceDB.ShopABC m_InvoiceDB =null;
        private long m_Atom_Item_ID = 0;
        public Form_Atom_Item_View(InvoiceDB.ShopABC xInvoiceDB,long xAtom_Item_ID)
        {
            InitializeComponent();
            m_InvoiceDB = xInvoiceDB;
            m_Atom_Item_ID = xAtom_Item_ID;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void Form_Atom_Item_View_Load(object sender, EventArgs e)
        {
            if (!this.usrc_Atom_Item_View.Init(m_InvoiceDB, m_Atom_Item_ID))
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }
    }
}
