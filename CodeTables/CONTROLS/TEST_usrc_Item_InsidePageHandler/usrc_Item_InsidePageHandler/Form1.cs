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

        private string[] Items = null;

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
                if (oData is string)
                {
                    ((Button)ctrl).Text = (string)oData;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int icount = Convert.ToInt32(numericUpDown1.Value);
            Items = new string[icount];
            for (int i = 0;i< icount;i++)
            {
                Items[i] = "Item " + i.ToString();
            }
            usrc_Item_InsidePageHandler1.Init(Items);
            usrc_Item_InsidePageHandler1.ShowPage(0);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int iPage = Convert.ToInt32(numericUpDown2.Value);
            usrc_Item_InsidePageHandler1.ShowPage(iPage);
        }
    }
}
