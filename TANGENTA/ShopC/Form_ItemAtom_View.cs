#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
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
        private TangentaDB.ShopABC m_InvoiceDB =null;
        private ID m_Atom_Item_ID = null;
        public Form_Atom_Item_View(TangentaDB.ShopABC xInvoiceDB,ID xAtom_Item_ID)
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
