using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceDB;

namespace ShopA
{
    public partial class usrc_ShopA: UserControl
    {
        ShopBC m_ShopBC = null;
        DBTablesAndColumnNames DBtcn = null;
        public usrc_ShopA()
        {
            InitializeComponent();
        }

        public void Init(ShopBC xm_ShopBC, DBTablesAndColumnNames xDBtcn)
        {
            m_ShopBC = xm_ShopBC;
            DBtcn = xDBtcn;
        }

    }
}
