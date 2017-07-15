using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using TangentaDB;

namespace Tangenta
{
    public partial class usrc_New_Copy_of_Same_DocType : UserControl
    {
        private string DocInvoice = "";
        private string sInvoiceNumber = "";
        private DataTable m_dt_FiancialYear = null;

        public delegate void delegate_Set_New_Copy_of_Same_DocType(string DocInvoice,
                                                                  int FinancialYear
                                                                 );
        public event delegate_Set_New_Copy_of_Same_DocType Set_New_Copy_of_Same_DocType = null;

        public int FinancialYear
        {
            get { return GetFiancialYear(); }
        }

        private int GetFiancialYear()
        {
            System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
            if (drv["FinancialYear"] is int)
            {
                return (int)drv["FinancialYear"];
            }
            else
            {
                return -1;
            }
        }

        public bool IsDocInvoice
        {
            get
            { return DocInvoice.Equals(Program.const_DocInvoice); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocInvoice.Equals(Program.const_DocProformaInvoice); }
        }


        public usrc_New_Copy_of_Same_DocType()
        {
            InitializeComponent();
        }

        public void Init(string xDocInvoice, string xsInvoiceNumber)
        {
            DocInvoice = xDocInvoice;
            sInvoiceNumber = xsInvoiceNumber;
            if (IsDocInvoice)
            {
                lngRPM.s_New_Copy_ThisInvoice_ToNewOne.Text(this.btn_New_Copy_Of_SameDocType);
            }
            else if (IsDocProformaInvoice)
            {
                lngRPM.s_New_Copy_ThisProformaInvoice_ToNewOne.Text(this.btn_New_Copy_Of_SameDocType);
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_NewDocument.cs:Form_NewDocument: Unknown DocInvoice type!");
            }
            btn_New_Copy_Of_SameDocType.Text = btn_New_Copy_Of_SameDocType.Text.Replace("%s", sInvoiceNumber);
            lngRPM.s_IntoFinancialYear.Text(lbl_FinancialYear);
            cmb_FinancialYear.SelectedIndexChanged -= cmb_FinancialYear_SelectedIndexChanged;
            int Default_FinancialYear = DateTime.Now.Year;
            if (GlobalData.SetFinancialYears(cmb_FinancialYear, ref m_dt_FiancialYear,IsDocInvoice,IsDocProformaInvoice,ref Default_FinancialYear))
            {
                cmb_FinancialYear.SelectedIndexChanged += cmb_FinancialYear_SelectedIndexChanged;
            }
        }

        private void btn_New_Copy_Of_SameDocType_Click(object sender, EventArgs e)
        {
            if (Set_New_Copy_of_Same_DocType != null)
            {
                Set_New_Copy_of_Same_DocType(DocInvoice, FinancialYear);
            }
        }

        private void cmb_FinancialYear_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
