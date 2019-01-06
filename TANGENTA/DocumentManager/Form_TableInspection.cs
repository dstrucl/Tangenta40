//using ShopC;
using ShopC_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDataBaseDef;
using TangentaDB;

namespace DocumentManager
{
    public partial class Form_TableInspection : Form
    {

        private object m_usrc_DocumentMan = null;

        public Form_TableInspection(object x_usrc_DocumentMan)
        {
            InitializeComponent();
            lng.s_Form_TableInspection.Text(this);
            lng.s_Shop_A.Text(btn_ShopA_TablesInspection);
            lng.s_Shop_B.Text(btn_ShopB_TablesInspection);
            lng.s_Shop_C.Text(btn_ShopC_TablesInspection);
            m_usrc_DocumentMan = x_usrc_DocumentMan;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_ShopB_TablesInspection_Click(object sender, EventArgs e)
        {
            ShopB_Forms.Form_Atom_ShopB_Item_Check frm_ShopBCheck = new ShopB_Forms.Form_Atom_ShopB_Item_Check();
            Form pform = Global.f.GetParentForm((Control)m_usrc_DocumentMan);
            frm_ShopBCheck.Show(pform);
        }

        private void btn_View_SQL_StateMents_Click(object sender, EventArgs e)
        {
            Form pform = Global.f.GetParentForm((Control)m_usrc_DocumentMan);
            CodeTables.DBTableControl.Show_Form_dtSQLdb(pform,DBSync.DBSync.Con,  MyDataBase_Tangenta.VERSION);
        }

        private void btn_ShopC_TablesInspection_Click(object sender, EventArgs e)
        {
            Form pform = Global.f.GetParentForm((Control)m_usrc_DocumentMan);
            Form_ShopC_TableInspection.DoShow(pform);
        }

 
    }
}
