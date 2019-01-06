using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using TangentaProperties;

namespace TangentaCore
{
    public partial class usrc_MethodOfPayment_Data : UserControl
    {
        public bool IsDocInvoice
        {
            get
            { string s = GlobalData.const_DocInvoice;
                return TSettings.RunAs.ToUpper().Equals(s.ToUpper());
            }
        }

        public bool IsDocProformaInvoice
        {
            get
            {
                string s = GlobalData.const_DocProformaInvoice;
                return TSettings.RunAs.ToUpper().Equals(s.ToUpper());
            }
        }

        public usrc_MethodOfPayment_Data()
        {
            InitializeComponent();
        }


    }
}
