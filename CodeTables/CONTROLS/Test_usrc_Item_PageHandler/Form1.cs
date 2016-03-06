using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_usrc_Item_PageHandler
{
    public partial class Form1 : Form
    {
        int iNumberOfItems = 77;
        int iNumberOfObjectsPerPage = 10;
        DataTable dt_Item_id_array = null;
        usrc_Item[] u_Item_array = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            long id = 1;
            
            int i=0;
            dt_Item_id_array = new DataTable();
            dt_Item_id_array.Columns.Add("ID", typeof(long));

            for (i = 0; i < iNumberOfItems; i++)
            {
                DataRow dr = dt_Item_id_array.NewRow();
                dr["ID"] = id;
                dt_Item_id_array.Rows.Add(dr);
                id++;
            }

            int iTop = 0;
            u_Item_array = new usrc_Item[iNumberOfObjectsPerPage];
            for (i = 0; i < iNumberOfObjectsPerPage; i++)
            {
                usrc_Item u_Item = new usrc_Item();
                u_Item.Top = iTop;
                u_Item.lbl_Item.Text = "";// "Item " + (i + 1).ToString();
                u_Item_array[i] = u_Item;
                this.pnl_Items.Controls.Add(u_Item);
                iTop += u_Item.Height + 2;
            }
            usrc_Item_PageHandler.Init(dt_Item_id_array, 7, u_Item_array);
        }

        private void usrc_Item_PageHandler_ShowObject(int Item_id_index, object o_data, object o_usrc, bool bVisible)
        {
            usrc_Item u_Item = (usrc_Item)o_usrc;
            if (bVisible)
            {
                u_Item.Visible = true;
                DataRow dr = (DataRow) o_data;
                long id = (long)dr["ID"];
                u_Item.lbl_Item.Text = "Item " + id.ToString();
            }
            else
            {
                u_Item.Visible = false;
            }

            
        }
    }
}
