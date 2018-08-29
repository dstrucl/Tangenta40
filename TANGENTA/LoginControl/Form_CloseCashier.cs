using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace LoginControl
{
    public partial class Form_CloseCashier : Form
    {
        private CashierActivity m_ca = null;
        public Form_CloseCashier()
        {
            InitializeComponent();
        }

        public Form_CloseCashier(CashierActivity ca)
        {
            InitializeComponent();
            lng.s_Form_CloseCashier.Text(this);
            m_ca = ca;
            this.usrc_CashierActivity1.Init(m_ca);
        }
    }
}
