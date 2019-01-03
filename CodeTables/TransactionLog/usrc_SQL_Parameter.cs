using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionLog
{
    public partial class usrc_SQL_Parameter : UserControl
    {
        public usrc_SQL_Parameter()
        {
            InitializeComponent();
        }

        public usrc_SQL_Parameter(int parameter_number,string name, string type, string value)
        {
            InitializeComponent();
            this.lbl_ParameterName.Text = parameter_number.ToString() + ": SQL Parameter Name:";
            this.txt_SQL_ParameterName.Text = name;
            this.txt_SQL_ParameterType.Text = type;
            this.txt_SQL_ParameterValue.Text = value;
        }
    }
}
