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
using System.Xml;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class usrc_FURS_BussinesPremiseData : UserControl
    {
        private bool Test = false;
        private bool m_ReadOnly = false;
        private usrc_FVI_SLO m_usrc_FVI_SLO;

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

        public void Init(bool bTest, usrc_FVI_SLO x_usrc_FVI_SLO)
        {

            m_usrc_FVI_SLO = x_usrc_FVI_SLO;
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

        private void Btn_Add_PP_to_FURS_Click(object sender, EventArgs e)
        {
            //save settings ? 
           string xml = MakePP_XML();

            m_usrc_FVI_SLO.Send_PP(xml);
      

        }

        string MakePP_XML()
        {
            string fu_TaxNumber = "10329048";                   // davčna  podjetja
            string fu_BusinessPremiseID = "KUNAVE6";     // Oznaka prostora vsak račun vsebuje oznako prostora 
            string fu_CadastralNumber = "1738";          // št. katastrske občine
            string fu_BuildingNumber = "2183";           // številka stavbe  (GURS)
            string fu_BuildingSectionNumber = "73";      //Oznaka dela stavbe (GURS)
            string fu_Street = "Kunaverjeva";            //ulica poslovnega prostora
            string fu_HouseNumber = "6";                 //hišna številka poslovnega prostora
            string fu_HouseNumberAdditional = " ";        //hišna številka dodatno  poslovnega prostora
            string fu_Community = "Dravlje";             // okraj 
            string fu_City = "Dravlje";                  //Kraj
            string fu_PostalCode = "1117";               // Poštna številka
            string fu_ValidityDate = "2020-08-25";       // do kdaj je veljaven poslovni prostor
            string fu_SpecialNotes = " ";                 //dodatno sporočilo za interno evidenco
            string fu_SoftwareSupplier_TaxNumber = "10000000";   //davvčna št izdelovalca programske opreme

            XmlDocument xdoc = null;
            XmlNodeList NList = null;

            try
            {
                string InvoiceXmlTemplate = Properties.Resources.FVI_SLO_BussinesPremises;
                xdoc = new XmlDocument();
                xdoc.LoadXml(InvoiceXmlTemplate);

                NList = xdoc.GetElementsByTagName("fu:TaxNumber"); NList.Item(0).InnerText = fu_TaxNumber;

                foreach (XmlNode nd in NList) 
                {
                    if (nd.ParentNode.Name == "fu:SoftwareSupplier")
                    {
                        nd.InnerText = fu_SoftwareSupplier_TaxNumber;
                        break;
                    }
                }

                NList = xdoc.GetElementsByTagName("fu:BusinessPremiseID"); NList.Item(0).InnerText = fu_BusinessPremiseID;
                NList = xdoc.GetElementsByTagName("fu:CadastralNumber"); NList.Item(0).InnerText = fu_CadastralNumber;
                NList = xdoc.GetElementsByTagName("fu:BuildingNumber"); NList.Item(0).InnerText = fu_BuildingNumber;
                NList = xdoc.GetElementsByTagName("fu:BuildingSectionNumber"); NList.Item(0).InnerText = fu_BuildingSectionNumber;
                NList = xdoc.GetElementsByTagName("fu:Street"); NList.Item(0).InnerText = fu_Street;
                NList = xdoc.GetElementsByTagName("fu:HouseNumber"); NList.Item(0).InnerText = fu_HouseNumber;
                NList = xdoc.GetElementsByTagName("fu:HouseNumberAdditional"); NList.Item(0).InnerText = fu_HouseNumberAdditional;
                NList = xdoc.GetElementsByTagName("fu:Community"); NList.Item(0).InnerText = fu_Community;
                NList = xdoc.GetElementsByTagName("fu:City"); NList.Item(0).InnerText = fu_City;
                NList = xdoc.GetElementsByTagName("fu:PostalCode"); NList.Item(0).InnerText = fu_PostalCode;
                NList = xdoc.GetElementsByTagName("fu:ValidityDate"); NList.Item(0).InnerText = fu_ValidityDate;
                NList = xdoc.GetElementsByTagName("fu:SpecialNotes"); NList.Item(0).InnerText = fu_SpecialNotes;


                string PPXml = XmlDcoumentToString(xdoc);
                return PPXml;
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:InvoiceData:Create_furs_InvoiceXML:Exception = " + Ex.Message);
                return null;
            }

   //<? xml version = "1.0" encoding = "UTF-8" ?>
   //< fu : BusinessPremiseRequest xmlns: fu = "http://www.fu.gov.si/" Id = "test" >
   //   < fu:BusinessPremise >
   //       < fu:TaxNumber > 10329048 </ fu:TaxNumber >
   //       < fu:BusinessPremiseID > KUNAV6 </ fu:BusinessPremiseID >
   //       < fu:BPIdentifier >
   //           < fu:RealEstateBP >
   //               < fu:PropertyID >
   //                    < fu:CadastralNumber > 365 </ fu:CadastralNumber >
   //                    < fu:BuildingNumber > 12 </ fu:BuildingNumber >
   //                     < fu:BuildingSectionNumber > 3 </ fu:BuildingSectionNumber >
   //               </ fu:PropertyID >
   //               < fu:Address >
   //                   < fu:Street > Dunajska cesta </ fu:Street >
   //                   < fu:HouseNumber > 24 </ fu:HouseNumber >
   //                   < fu:HouseNumberAdditional > B </ fu:HouseNumberAdditional >
   //                   < fu:Community > Ljubljana </ fu:Community >
   //                   < fu:City > Ljubljana </ fu:City >
   //                   < fu:PostalCode > 1000 </ fu:PostalCode >
   //               </ fu:Address >
   //           </ fu:RealEstateBP >
   //       </ fu:BPIdentifier >
   //       < fu:ValidityDate > 2020 - 08 - 25 </ fu:ValidityDate >
   //       < fu:SoftwareSupplier >
   //           < fu:TaxNumber > 24564444 </ fu:TaxNumber >
   //       </ fu:SoftwareSupplier >
   //       < fu:SpecialNotes > Primer prijave poslovnega prostora </ fu:SpecialNotes >
   //   </ fu:BusinessPremise >
   //</ fu:BusinessPremiseRequest >

        }

        private string XmlDcoumentToString(XmlDocument xmlDoc)
        {
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = false;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            var stringBuilder = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                xmlDoc.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }
    }
}
