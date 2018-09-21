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
        SampleDB sdb = null;

        public Form_Items_Samples frmitems = null;
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
            DoubleBuffered = true;
        }

        bool mouseDown = false;
        Point mouseDownPoint = Point.Empty;
        Point mousePoint = Point.Empty;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseDown = true;
            mousePoint = mouseDownPoint = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseDown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            mousePoint = e.Location;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (mouseDown)
            {
                Region r = new Region(this.ClientRectangle);
                Rectangle window = new Rectangle(
                    Math.Min(mouseDownPoint.X, mousePoint.X),
                    Math.Min(mouseDownPoint.Y, mousePoint.Y),
                    Math.Abs(mouseDownPoint.X - mousePoint.X),
                    Math.Abs(mouseDownPoint.Y - mousePoint.Y));
                r.Xor(window);
                e.Graphics.FillRegion(Brushes.Red, r);
                Console.WriteLine("Painted: " + window);
            }
        }

        private void usrc_Item_InsidePageHandler1_CreateControl(ref Control ctrl)
        {
            ctrl = new Button();
        }

        private void usrc_Item_InsidePageHandler1_FillControl(Control ctrl, object oData, usrc_Item_InsidePage_Handler.usrc_Item_InsidePageHandler.eMode emode)
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
            ShowItemsForm();
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
                usrc_Item_InsidePageHandler1.Init(Items_array, usrc_Item_InsidePage_Handler.usrc_Item_InsidePageHandler.eMode.EDIT);
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
                usrc_Item_InsidePageHandler1.Init(Items_list.Cast<object>().ToList(), usrc_Item_InsidePage_Handler.usrc_Item_InsidePageHandler.eMode.EDIT);
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

        private void ShowItemsForm()
        {
            if (frmitems != null)
            {
                if (frmitems.IsDisposed)
                {
                    frmitems = null;
                }
            }
            if (frmitems==null)
            {
                frmitems = new Form_Items_Samples();
                frmitems.Owner = this;
                frmitems.NewSampleData += Frmitems_NewSampleData;
            }
            frmitems.Show();
        }
        private void btn_usrc_GroupHandler_Click(object sender, EventArgs e)
        {
            ShowItemsForm();
        }

        private void Frmitems_NewSampleData(SampleDB xsdb)
        {
            sdb = xsdb;
            usrc_Item_InsidePageGroupHandler1.Init(sdb.dtItm);
        }

        private void usrc_Item_InsidePageHandler1_SelectionChanged(Control ctrl, object oData, int index)
        {

        }

        private void usrc_Item_InsidePageGroupHandler1_CreateControl(ref Control ctrl)
        {
            Button btn = new Button();
            ctrl = btn;
        }

        private void usrc_Item_InsidePageGroupHandler1_FillControl(Control ctrl, object oData, usrc_Item_InsidePage_Handler.usrc_Item_InsidePageHandler.eMode emode)
        {
            if (oData is DataRow)
            {
                DataRow dr = (DataRow)oData;
                ctrl.Text = (string)dr["ItemName"];
            }
        }

        private void usrc_Item_InsidePageGroupHandler1_SelectControl(Control ctrl, object oData, int index, bool selected)
        {
            if (selected)
            {
                ctrl.BackColor = Color.YellowGreen;
            }
            else
            {
                ctrl.BackColor = Color.White;
            }
        }

        private void usrc_Item_InsidePageGroupHandler1_SelectionChanged(Control ctrl, object oData, int index)
        {
            if (oData is DataRow)
            {
                lbl_Item.Text = (string)((DataRow)oData)["ItemName"];
            }
        }

        private void userControl11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("userControl11_Click");
        }
    }
}
