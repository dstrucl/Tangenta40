using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynEditControls;
using static DynEditControls.usrc_NumericUpDown2;

namespace ShopC_Forms
{
    public partial class usrc_btn_Item : UserControl
    {
        public event System.EventHandler ClickItem = null;
        public event System.EventHandler ValueChanged = null;

        public string PriceLabelText
        {
            get
            {
                return this.usrc_NumericUpDown21.Label1;
            }
            set
            {
                this.usrc_NumericUpDown21.Label1 = value;
            }
        }

        public string PriceText
        {
            get
            {
                return this.usrc_NumericUpDown21.Label2;
            }
            set
            {
                this.usrc_NumericUpDown21.Label2 = value;
            }
        }

        public string QuantityText
        {
            get
            {
                return this.usrc_NumericUpDown21.Label3;
            }
            set
            {
                this.usrc_NumericUpDown21.Label3 = value;
            }
        }

        public string ButtonItemText
        {
            get
            {
                return this.btn_Item.Text;
            }
            set
            {
                this.btn_Item.Text = value;
            }
        }

        public string StockLabelText
        {
            get
            {
                return this.usrc_NumericUpDown21.Label4;
            }
            set
            {
                this.usrc_NumericUpDown21.Label4 = value;
            }
        }

        public string StockText
        {
            get
            {
                return this.usrc_NumericUpDown21.Label5;
            }
            set
            {
                this.usrc_NumericUpDown21.Label5 = value;
            }
        }

        public Image Image
        {
            get
            {
                return btn_Item.Image;
            }
            set
            {
                btn_Item.Image = value;
            }
        }


        public eType Type
        {
            get { return usrc_NumericUpDown21.Type; }

            set
            {
                usrc_NumericUpDown21.Type = value;
            }

        }
        public string Unit
        {
            get { return usrc_NumericUpDown21.Unit; }

            set { usrc_NumericUpDown21.Unit = value; }
        }

        public decimal Increment
        {
            get { return usrc_NumericUpDown21.Increment; }

            set { usrc_NumericUpDown21.Increment = value; }
        }

        public decimal Value
        {
            get { return usrc_NumericUpDown21.Value; }

            set { usrc_NumericUpDown21.Value = value; }
        }

        public decimal ValueMultiplier
        {
            get { return usrc_NumericUpDown21.ValueMultiplier; }

            set { usrc_NumericUpDown21.ValueMultiplier = value; }
        }

        public bool ReadOnly
        {
            get { return usrc_NumericUpDown21.ReadOnly; }

            set
            {
                usrc_NumericUpDown21.ReadOnly = value;
            }
        }

        public int DecimalPlaces
        {
            get { return usrc_NumericUpDown21.DecimalPlaces; }

            set
            {
                usrc_NumericUpDown21.DecimalPlaces = value;
            }
        }


        public decimal Maximum
        {
            get { return usrc_NumericUpDown21.Maximum; }

            set { usrc_NumericUpDown21.Maximum = value; }
        }



        public decimal Minimum
        {
            get { return usrc_NumericUpDown21.Minimum; }

            set { usrc_NumericUpDown21.Minimum = value; }
        }

        public usrc_btn_Item()
        {
            InitializeComponent();
        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            if (ClickItem!=null)
            {
                ClickItem(sender, e);
            }
        }

        private void usrc_NumericUpDown21_ValueChanged(object sender, EventArgs e)
        {
            if (this.usrc_NumericUpDown21.Value != 0)
            {
                this.btn_Item.Enabled = true;
            }
            else
            {
                this.btn_Item.Enabled = false;
            }
            if (ValueChanged!=null)
            {
                ValueChanged(this, e);
            }
        }
    }
}
