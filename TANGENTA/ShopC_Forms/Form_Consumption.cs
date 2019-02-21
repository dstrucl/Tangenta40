using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopC_Forms
{
    public partial class Form_Consumption : Form
    {
        public Form_Consumption(LoginControl.LMOUser lmoUser,int financialYear)
        {
            InitializeComponent();
            lng.s_Form_Consumption.Text(this);
            this.usrc_ConsumptionMan1.Initialise(this, lmoUser, financialYear);
        }

        private void Form_Consumption_Load(object sender, EventArgs e)
        {
            if (this.usrc_ConsumptionMan1.Init())
            {
                this.usrc_ConsumptionMan1.Activate_dgvx_XConsumption_SelectionChanged();
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }
    }
}
