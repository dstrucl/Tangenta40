using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class usrc_FURS_BussinesPremiseData : UserControl
    {
        private bool Test = false;
        private bool m_ReadOnly = false;

        public bool ReadOnly
        {
            get { return m_ReadOnly;  }
            set { m_ReadOnly = value; }
        }

        public usrc_FURS_BussinesPremiseData()
        {
            InitializeComponent();
            lngRPM.s_fursBuildingNumber.Text(lbl_BuildingNumber);
            lngRPM.s_lbl_FURS_BussinesData.Text(lbl_FURS_BussinesData);
            lngRPM.s_lbl_BuildingSectionNumber.Text(lbl_BuildingSectionNumber);
            lngRPM.s_lbl_Community.Text(lbl_Community);
            lngRPM.s_lbl_CadastralNumber.Text(lbl_CadastralNumber);
            lngRPM.s_lbl_ValidityDate.Text(lbl_ValidityDate);
            lngRPM.s_lbl_ClosingTag.Text(lbl_ClosingTag);
            lngRPM.s_lbl_SoftwareSupplier_TaxNumber.Text(lbl_SoftwareSupplier_TaxNumber);
            lngRPM.s_lbl_PremiseType.Text(lbl_PremiseType);
            lngRPM.s_lbl_MyOrganisation_TaxID.Text(lbl_MyOrganisation_TaxID);
            lngRPM.s_lbl_BussinesPremiseID.Text(lbl_BussinesPremiseID);
          //  lngRPM.s_lbl_InvoiceAuthor_TaxID.Text(lbl_InvoiceAuthor_TaxID);
            lngRPM.s_btn_ImportFromDataBase.Text(btn_ImportFromDataBase);



        }

        public void Init(bool bTest)
        {
            Test = bTest;
            if (Test)
            {
                this.txt_BuildingNumber.Text = Properties.Settings.Default.fursD_BuildingNumber_TEST;
                this.txt_BuildingSectionNumber.Text = Properties.Settings.Default.fursD_BuildingSectionNumber_TEST;
                this.txt_Community.Text = Properties.Settings.Default.fursD_Community_TEST;
                this.txt_CadastralNumber.Text = Properties.Settings.Default.fursD_CadastralNumber_TEST;
                this.dt_ValidityDate.Value = Properties.Settings.Default.fursD_ValidityDate_TEST;
                this.txt_ClosingTag.Text = Properties.Settings.Default.fursD_ClosingTag_TEST;
                this.txt_SoftwareSupplier_TaxNumber.Text = Properties.Settings.Default.fursD_SoftwareSupplierTaxID_TEST;
                this.txt_PremiseType.Text = Properties.Settings.Default.fursD_PremiseType_TEST;
                this.txt_MyOrganisation_TaxID.Text = Properties.Settings.Default.fursD_MyOrgTaxID_TEST;
                this.txt_BussinesPremiseID.Text = Properties.Settings.Default.fursD_BussinesPremiseID_TEST;
          //      this.txt_InvoiceAuthor_TaxID.Text = Properties.Settings.Default.fursD_InvoiceAuthorTaxID_TEST;
            }
            else
            {
                this.txt_BuildingNumber.Text = Properties.Settings.Default.fursD_BuildingNumber;
                this.txt_BuildingSectionNumber.Text = Properties.Settings.Default.fursD_BuildingSectionNumber;
                this.txt_Community.Text = Properties.Settings.Default.fursD_Community;
                this.txt_CadastralNumber.Text = Properties.Settings.Default.fursD_CadastralNumber;
                this.dt_ValidityDate.Value = Properties.Settings.Default.fursD_ValidityDate;
                this.txt_ClosingTag.Text = Properties.Settings.Default.fursD_ClosingTag;
                this.txt_SoftwareSupplier_TaxNumber.Text = Properties.Settings.Default.fursD_SoftwareSupplierTaxID;
                this.txt_PremiseType.Text = Properties.Settings.Default.fursD_PremiseType;
                this.txt_MyOrganisation_TaxID.Text = Properties.Settings.Default.fursD_MyOrgTaxID;
                this.txt_BussinesPremiseID.Text = Properties.Settings.Default.fursD_BussinesPremiseID;
             //   this.txt_InvoiceAuthor_TaxID.Text = Properties.Settings.Default.fursD_InvoiceAuthorTaxID;
            }

            this.txt_BuildingNumber.ReadOnly = m_ReadOnly;
            this.txt_BuildingSectionNumber.ReadOnly = m_ReadOnly;
            this.txt_Community.ReadOnly = m_ReadOnly;
            this.txt_CadastralNumber.ReadOnly = m_ReadOnly;
            this.dt_ValidityDate.Enabled = !m_ReadOnly;
            this.txt_ClosingTag.ReadOnly = m_ReadOnly;
            this.txt_SoftwareSupplier_TaxNumber.ReadOnly = m_ReadOnly;
            this.txt_PremiseType.ReadOnly = m_ReadOnly;
            this.txt_MyOrganisation_TaxID.ReadOnly = m_ReadOnly;
            this.txt_BussinesPremiseID.ReadOnly = m_ReadOnly;
        //    this.txt_InvoiceAuthor_TaxID.ReadOnly = m_ReadOnly;
            this.btn_ImportFromDataBase.Visible = !m_ReadOnly;

        }

        internal void Save()
        {
            if (Test)
            {
                Properties.Settings.Default.fursD_BuildingNumber_TEST = this.txt_BuildingNumber.Text;
                Properties.Settings.Default.fursD_BuildingSectionNumber_TEST = this.txt_BuildingSectionNumber.Text;
                Properties.Settings.Default.fursD_Community_TEST = this.txt_Community.Text;
                Properties.Settings.Default.fursD_CadastralNumber_TEST = this.txt_CadastralNumber.Text;
                Properties.Settings.Default.fursD_ValidityDate_TEST = this.dt_ValidityDate.Value;
                Properties.Settings.Default.fursD_ClosingTag_TEST = this.txt_ClosingTag.Text;
                Properties.Settings.Default.fursD_SoftwareSupplierTaxID_TEST = this.txt_SoftwareSupplier_TaxNumber.Text;
                Properties.Settings.Default.fursD_PremiseType_TEST = this.txt_PremiseType.Text;
                Properties.Settings.Default.fursD_MyOrgTaxID_TEST = this.txt_MyOrganisation_TaxID.Text;
                Properties.Settings.Default.fursD_BussinesPremiseID_TEST = this.txt_BussinesPremiseID.Text;
         //       Properties.Settings.Default.fursD_InvoiceAuthorTaxID_TEST = this.txt_InvoiceAuthor_TaxID.Text;
            }
            else
            {
                Properties.Settings.Default.fursD_BuildingNumber = this.txt_BuildingNumber.Text;
                Properties.Settings.Default.fursD_BuildingSectionNumber = this.txt_BuildingSectionNumber.Text;
                Properties.Settings.Default.fursD_Community = this.txt_Community.Text;
                Properties.Settings.Default.fursD_CadastralNumber = this.txt_CadastralNumber.Text;
                Properties.Settings.Default.fursD_ValidityDate = this.dt_ValidityDate.Value;
                Properties.Settings.Default.fursD_ClosingTag = this.txt_ClosingTag.Text;
                Properties.Settings.Default.fursD_SoftwareSupplierTaxID = this.txt_SoftwareSupplier_TaxNumber.Text;
                Properties.Settings.Default.fursD_PremiseType = this.txt_PremiseType.Text;
                Properties.Settings.Default.fursD_MyOrgTaxID = this.txt_MyOrganisation_TaxID.Text;
                Properties.Settings.Default.fursD_BussinesPremiseID = this.txt_BussinesPremiseID.Text;
            //    Properties.Settings.Default.fursD_InvoiceAuthorTaxID = this.txt_InvoiceAuthor_TaxID.Text;
            }
        }
    }
}
