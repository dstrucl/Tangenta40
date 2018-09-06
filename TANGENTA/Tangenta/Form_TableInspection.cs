using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_TableInspection : Form
    {
        public Form_TableInspection()
        {
            InitializeComponent();
            lng.s_Form_TableInspection.Text(this);
            lng.s_Shop_A.Text(btn_ShopA_TablesInspection);
            lng.s_Shop_B.Text(btn_ShopB_TablesInspection);
            lng.s_Shop_C.Text(btn_ShopC_TablesInspection);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_ShopB_TablesInspection_Click(object sender, EventArgs e)
        {
            ShopB.Form_Atom_SimpleItem_Check frm_ShopBCheck = new ShopB.Form_Atom_SimpleItem_Check();
            frm_ShopBCheck.ShowDialog(this);
        }
    }
}
