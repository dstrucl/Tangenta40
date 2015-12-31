using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ErrorCreateWindowHandle
{
    public partial class usrc_ItemList : UserControl
    {


        public delegate void delegate_ItemAdded(bool bNew);
        public event delegate_ItemAdded ItemAdded = null;

        DataTable dt_Price_Item_Stock = new DataTable();

        DataTable dt_Price_Item_Group = new DataTable();

        public List<usrc_Item> List_usrc_Item = new List<usrc_Item>();

        public usrc_ItemList()
        {
            InitializeComponent();
        }

        internal void Init(/*InvoiceDB xm_InvoiceDB, DBTablesAndColumnNames xDBtcn*/)
        {
            foreach (Control ctrl in this.pnl_Group.Controls)
            {
                    ctrl.Dispose();
            }
            this.pnl_Group.Controls.Clear();
        }



        private void Insert_usrc_Item(int i,ref int yPos)
        {
            usrc_Item usrc_item = new usrc_Item();
            usrc_item.Init(i);
            usrc_item.Top = yPos;
            usrc_item.Left = 5;
            usrc_item.Width = this.pnl_Items.Width - 10;
            usrc_item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            yPos += usrc_item.Height + 1;
            usrc_item.ItemAdded += new usrc_Item.delegate_ItemAdded(usrc_item_ItemAdded);
            //List_usrc_Item.Add(usrc_item);
            if (yPos>0x8000)
            {
                MessageBox.Show("yPos > " + yPos.ToString());
            }
            try
            { 
            this.pnl_Items.Controls.Add(usrc_item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception = " + ex.Message);
            }
        }


        void usrc_item_ItemAdded(/*pias_Atom_Item pias,*/ bool bNew)
        {
            if (ItemAdded != null)
            {
                ItemAdded(/*pias,*/ bNew);
            }
        }


   

        public bool DeleteAndCreateNew(ref int yPos)
        {
         
                // clear usrc_Item
                Program.iGDIcUser100 = Program.getGuiResourcesUserCount();
                int i= 0;
                for (i = pnl_Items.Controls.Count-1;i >=0 ;i--)
                {
                    Control c = pnl_Items.Controls[i];
                    //if (c is usrc_Item)
                    //{
                    //    usrc_Item uitm =  (usrc_Item)c;
                    //    uitm.ItemAdded -= new usrc_Item.delegate_ItemAdded(usrc_item_ItemAdded);
                    //}
                    pnl_Items.Controls.Remove(c);
                    c.Dispose();
                }
                pnl_Items.Controls.Clear();

                Program.iGDIcUser101 = Program.getGuiResourcesUserCount();

                for (i=0;i<245;i++)
                {
                    Insert_usrc_Item(i,ref yPos);
                }
                this.Refresh();
                Program.iGDIcUser102 = Program.getGuiResourcesUserCount();
                dt_Price_Item_Group.Clear();
                dt_Price_Item_Group.Columns.Clear();
                Program.iGDIcUser103 = Program.getGuiResourcesUserCount();
                return true;
        }
    }
}
