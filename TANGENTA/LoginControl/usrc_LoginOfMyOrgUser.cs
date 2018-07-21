using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class usrc_LoginOfMyOrgUser : UserControl
    {
        TangentaDB.myOrg_Person m_Item_Data = null;
        public usrc_LoginOfMyOrgUser()
        {
            InitializeComponent();
        }

        private void RePaint()
        {

            string sUserName = "";
            //            this.txt_InStock.Text = dAllStockQuantity.ToString();
            //this.lbl_User.Text = m_Item_Data.FirstName_v.v;

        }

        internal void DoPaint(DataRow dr, string[] s_name_Group, object xobj)
        {
            RePaint();
        }
    }
}
