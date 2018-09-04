using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usrc_Item_InsidePageHandler
{
    public partial class Form1 : Form
    {

        public Form_Items_Samples frmitemssamples = null;
        public class Item
        {
            public bool bSelected = false;
            public string sitem = null;
            public Item(string s)
            {
                sitem = s;
                bSelected = false;
            }
            
        }

        private Item[] Items_array = null;

        private List<Item> Items_list = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void usrc_Item_InsidePageHandler1_CreateControl(ref Control ctrl)
        {
            ctrl = new Button();
        }

        private void usrc_Item_InsidePageHandler1_FillControl(Control ctrl, object oData)
        {
            if (ctrl is Button)
            {
                if (oData is Item)
                {

                    if (((Item)oData).bSelected)
                    {
                        ctrl.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        ctrl.BackColor = Color.White;
                    }

                    ((Button)ctrl).Text = ((Item)oData).sitem;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int icount = Convert.ToInt32(numericUpDown1.Value);
            if (rdb_Array.Checked)
            {
                Items_array = new Item[icount];
                for (int i = 0; i < icount; i++)
                {
                    Items_array[i] = new Item("Item " + i.ToString());
                }
                usrc_Item_InsidePageHandler1.Init(Items_array);
            }

            if (rdb_List.Checked)
            {
                if (Items_list == null)
                {
                    Items_list = new List<Item>();
                }
                else
                {
                    Items_list.Clear();
                }

                for (int i = 0; i < icount; i++)
                {
                    Items_list.Add(new Item("Item " + i.ToString()));
                }
                usrc_Item_InsidePageHandler1.Init(Items_list.Cast<object>().ToList());
            }

            usrc_Item_InsidePageHandler1.ShowPage(0);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int iPage = Convert.ToInt32(numericUpDown2.Value);
            usrc_Item_InsidePageHandler1.ShowPage(iPage);
        }

        private void usrc_Item_InsidePageHandler1_Select(object oData, int index)
        {
            if (oData is Item)
            {
                ((Item)oData).bSelected = true;
            }
        }

        private void usrc_Item_InsidePageHandler1_SelectControl(Control ctrl, object oData, int index, bool select)
        {
            if (select)
            {
                ctrl.BackColor = Color.MistyRose;
                if (oData is Item)
                {
                    ((Item)oData).bSelected = true;
                }
            }
            else
            {
                ctrl.BackColor = Color.White;
                if (oData is Item)
                {
                    ((Item)oData).bSelected = false;
                }
            }
        }

        private void usrc_Item_InsidePageHandler1_Deselect(object oData, int index)
        {
            if (oData is Item)
            {
                ((Item)oData).bSelected = false;
            }
        }

        private void nmUpDn_SelectItem_ValueChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(nmUpDn_SelectItem.Value);
            usrc_Item_InsidePageHandler1.SelectObject(index);
        }

        private void usrc_Item_InsidePageHandler1_PageChanged(int iPage)
        {
            lbl_Page.Text = iPage.ToString();
        }

        private void numUpDn_decimal_ValueChanged(object sender, EventArgs e)
        {
            LanguageControl.DynSettings.LanguageID = LanguageControl.DynSettings.Slovensko_ID;
            this.textBox1.Text = LanguageControl.DynSettings.SetLanguageCurrencyString(numUpDn_decimal.Value, 2, "€");
        }

        private void btn_usrc_GroupHandler_Click(object sender, EventArgs e)
        {
            if (frmitemssamples==null)
            {
                frmitemssamples = new Form_Items_Samples();
                frmitemssamples.Owner = this;
            }
            frmitemssamples.Show();
        }
    }
}
