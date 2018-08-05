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
    public partial class usrc_New_Copy_of_Another_DocType : UserControl
    {
        private string DocTyp = "";
        private string sInvoiceNumber = "";
        private DataTable m_dt_FiancialYear = null;

        private SettingsUserValues mSettingsUserValues = null;

        public delegate void delegate_Set_New_Copy_of_Another_DocType(string DocTyp,
                                                                      int FinancialYear
                                                                     );
        public event delegate_Set_New_Copy_of_Another_DocType Set_New_Copy_of_Another_DocType = null;

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
            { return DocTyp.Equals(Program.const_DocInvoice); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocTyp.Equals(Program.const_DocProformaInvoice); }
        }

        public usrc_New_Copy_of_Another_DocType()
        {
            InitializeComponent();
        }
        public void Init(string xDocTyp, string xsInvoiceNumber,SettingsUserValues xSettingsUserValues)
        {
            mSettingsUserValues = xSettingsUserValues;
            DocTyp = xDocTyp;
            sInvoiceNumber = xsInvoiceNumber;
            if (IsDocInvoice)
            {
                lng.s_New_Copy_ThisInvoice_ToNewProformaInvoice.Text(this.btn_New_Copy_To_Another_DocType);
            }
            else if (IsDocProformaInvoice)
            {
                lng.s_New_Copy_ThisProformaInvoice_ToInvoice.Text(this.btn_New_Copy_To_Another_DocType);
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_NewDocument.cs:Form_NewDocument: Unknown DocTyp type!");
            }
            btn_New_Copy_To_Another_DocType.Text = btn_New_Copy_To_Another_DocType.Text.Replace("%s", sInvoiceNumber);
            lng.s_IntoFinancialYear.Text(lbl_FinancialYear);
            cmb_FinancialYear.SelectedIndexChanged -= cmb_FinancialYear_SelectedIndexChanged;
            int Default_FinancialYear = mSettingsUserValues.FinancialYear;
            if (GlobalData.SetFinancialYears(cmb_FinancialYear, ref m_dt_FiancialYear, IsDocInvoice, IsDocProformaInvoice, ref Default_FinancialYear))
            {
                mSettingsUserValues.FinancialYear = Default_FinancialYear;
                cmb_FinancialYear.SelectedIndexChanged += cmb_FinancialYear_SelectedIndexChanged;
            }
        }

        private void btn_New_Copy_To_Another_DocType_Click(object sender, EventArgs e)
        {
            if (Set_New_Copy_of_Another_DocType != null)
            {
                Set_New_Copy_of_Another_DocType(DocTyp, FinancialYear);
            }
        
        }

        private void cmb_FinancialYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
