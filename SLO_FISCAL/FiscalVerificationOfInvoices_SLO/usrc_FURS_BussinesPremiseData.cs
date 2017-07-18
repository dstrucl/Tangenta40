#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

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
        public delegate void delegate_FURS_BussinesPremiseData_SignedUp(bool bResult);

        public event delegate_FURS_BussinesPremiseData_SignedUp FURS_BussinesPremiseData_SignedUp = null;

        private bool Test = false;
        private bool m_ReadOnly = false;
        private usrc_FVI_SLO m_usrc_FVI_SLO;

        public bool ReadOnly
        {
            get { return m_ReadOnly; }
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
            lngRPM.s_lbl_SoftwareSupplier_TaxNumber.Text(lbl_SoftwareSupplier_TaxNumber);
            lngRPM.s_lbl_PremiseType.Text(lbl_PremiseType);
            lngRPM.s_lbl_MyOrganisation_TaxID.Text(lbl_MyOrganisation_TaxID);
            lngRPM.s_lbl_BussinesPremiseID.Text(lbl_BussinesPremiseID);
            lngRPM.s_lbl_InvoiceAuthor_TaxID.Text(lbl_InvoiceAuthor_TaxID);
            // lngRPM.s_btn_ImportFromDataBase.Text(btn_ImportFromDataBase);

            lngRPM.s_lbl_StreetName.Text(lbl_StreetName);
            lngRPM.s_lbl_Street_Number.Text(lbl_Street_Number);
            lngRPM.s_lbl_Post.Text(lbl_Post);
            lngRPM.s_lbl_City.Text(lbl_City);




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

                this.txt_SoftwareSupplier_TaxNumber.Text = Properties.Settings.Default.fursD_SoftwareSupplierTaxID_TEST;
                this.txt_PremiseType.Text = Properties.Settings.Default.fursD_PremiseType_TEST;
                this.txt_MyOrganisation_TaxID.Text = Properties.Settings.Default.fursD_MyOrgTaxID_TEST;
                this.txt_BussinesPremiseID.Text = Properties.Settings.Default.fursD_BussinesPremiseID_TEST;
                this.txt_InvoiceAuthor_TaxID.Text = Properties.Settings.Default.fursD_InvoiceAuthorTaxID_TEST;

                this.txt_City.Text = Properties.Settings.Default.fursD_City_TEST;
                this.txt_PostNumber.Text = Properties.Settings.Default.fursD_PostNumber_TEST;
                this.txt_StreetNumber.Text = Properties.Settings.Default.fursD_StreetNumber_TEST;
                this.txt_StreetNumberAdt.Text = Properties.Settings.Default.fursD_StreetNumberAdt_TEST;
                this.txt_StreetName.Text = Properties.Settings.Default.fursD_StreetName_TEST;

                if (Properties.Settings.Default.fursD_ClosingTag_TEST == "Z")
                    this.Chk_StoreClosed.Checked = true;
                else
                    this.Chk_StoreClosed.Checked = false;

            }
            else
            {
                this.txt_BuildingNumber.Text = Properties.Settings.Default.fursD_BuildingNumber;
                this.txt_BuildingSectionNumber.Text = Properties.Settings.Default.fursD_BuildingSectionNumber;
                this.txt_Community.Text = Properties.Settings.Default.fursD_Community;
                this.txt_CadastralNumber.Text = Properties.Settings.Default.fursD_CadastralNumber;
                this.dt_ValidityDate.Value = Properties.Settings.Default.fursD_ValidityDate;
                this.txt_SoftwareSupplier_TaxNumber.Text = Properties.Settings.Default.fursD_SoftwareSupplierTaxID;
                this.txt_PremiseType.Text = Properties.Settings.Default.fursD_PremiseType;
                this.txt_MyOrganisation_TaxID.Text = Properties.Settings.Default.fursD_MyOrgTaxID;
                this.txt_BussinesPremiseID.Text = Properties.Settings.Default.fursD_BussinesPremiseID;
                this.txt_InvoiceAuthor_TaxID.Text = Properties.Settings.Default.fursD_InvoiceAuthorTaxID;

                this.txt_City.Text = Properties.Settings.Default.fursD_City;
                this.txt_PostNumber.Text = Properties.Settings.Default.fursD_PostNumber;
                this.txt_StreetNumber.Text = Properties.Settings.Default.fursD_StreetNumber;
                this.txt_StreetNumberAdt.Text = Properties.Settings.Default.fursD_StreetNumberAdt;
                this.txt_StreetName.Text = Properties.Settings.Default.fursD_StreetName;

                if (Properties.Settings.Default.fursD_ClosingTag == "Z")
                    this.Chk_StoreClosed.Checked = true;
                else
                    this.Chk_StoreClosed.Checked = false;

            }

            this.txt_BuildingNumber.ReadOnly = m_ReadOnly;
            this.txt_BuildingSectionNumber.ReadOnly = m_ReadOnly;
            this.txt_Community.ReadOnly = m_ReadOnly;
            this.txt_CadastralNumber.ReadOnly = m_ReadOnly;
            this.dt_ValidityDate.Enabled = !m_ReadOnly;
            this.Chk_StoreClosed.Enabled = !m_ReadOnly;
            this.txt_SoftwareSupplier_TaxNumber.ReadOnly = m_ReadOnly;
            this.txt_PremiseType.ReadOnly = m_ReadOnly;
            this.txt_MyOrganisation_TaxID.ReadOnly = m_ReadOnly;
            this.txt_BussinesPremiseID.ReadOnly = m_ReadOnly;
            this.txt_InvoiceAuthor_TaxID.ReadOnly = m_ReadOnly;
            // this.btn_ImportFromDataBase.Visible = !m_ReadOnly;

            this.txt_City.ReadOnly = m_ReadOnly;
            this.txt_PostNumber.ReadOnly = m_ReadOnly;
            this.txt_StreetNumber.ReadOnly = m_ReadOnly;
            this.txt_StreetNumberAdt.ReadOnly = m_ReadOnly;
            this.txt_StreetName.ReadOnly = m_ReadOnly;

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
                Properties.Settings.Default.fursD_SoftwareSupplierTaxID_TEST = this.txt_SoftwareSupplier_TaxNumber.Text;
                Properties.Settings.Default.fursD_PremiseType_TEST = this.txt_PremiseType.Text;
                Properties.Settings.Default.fursD_MyOrgTaxID_TEST = this.txt_MyOrganisation_TaxID.Text;
                Properties.Settings.Default.fursD_BussinesPremiseID_TEST = this.txt_BussinesPremiseID.Text;
                Properties.Settings.Default.fursD_InvoiceAuthorTaxID_TEST = this.txt_InvoiceAuthor_TaxID.Text;
                Properties.Settings.Default.fursD_City_TEST = this.txt_City.Text;
                Properties.Settings.Default.fursD_PostNumber_TEST = this.txt_PostNumber.Text;
                Properties.Settings.Default.fursD_StreetNumber_TEST = this.txt_StreetNumber.Text;
                Properties.Settings.Default.fursD_StreetNumberAdt_TEST = this.txt_StreetNumberAdt.Text;
                Properties.Settings.Default.fursD_StreetName_TEST = this.txt_StreetName.Text;
                if (this.Chk_StoreClosed.Checked == true)
                    Properties.Settings.Default.fursD_ClosingTag_TEST = "Z";
                else
                    Properties.Settings.Default.fursD_ClosingTag_TEST = "";
            }
            else
            {
                Properties.Settings.Default.fursD_BuildingNumber = this.txt_BuildingNumber.Text;
                Properties.Settings.Default.fursD_BuildingSectionNumber = this.txt_BuildingSectionNumber.Text;
                Properties.Settings.Default.fursD_Community = this.txt_Community.Text;
                Properties.Settings.Default.fursD_CadastralNumber = this.txt_CadastralNumber.Text;
                Properties.Settings.Default.fursD_ValidityDate = this.dt_ValidityDate.Value;
                Properties.Settings.Default.fursD_SoftwareSupplierTaxID = this.txt_SoftwareSupplier_TaxNumber.Text;
                Properties.Settings.Default.fursD_PremiseType = this.txt_PremiseType.Text;
                Properties.Settings.Default.fursD_MyOrgTaxID = this.txt_MyOrganisation_TaxID.Text;
                Properties.Settings.Default.fursD_BussinesPremiseID = this.txt_BussinesPremiseID.Text;
                Properties.Settings.Default.fursD_InvoiceAuthorTaxID = this.txt_InvoiceAuthor_TaxID.Text;
                Properties.Settings.Default.fursD_City = this.txt_City.Text;
                Properties.Settings.Default.fursD_PostNumber = this.txt_PostNumber.Text;
                Properties.Settings.Default.fursD_StreetNumber = this.txt_StreetNumber.Text;
                Properties.Settings.Default.fursD_StreetNumberAdt = this.txt_StreetNumberAdt.Text;
                Properties.Settings.Default.fursD_StreetName = this.txt_StreetName.Text;
                if (this.Chk_StoreClosed.Checked == true)
                    Properties.Settings.Default.fursD_ClosingTag = "Z";
                else
                    Properties.Settings.Default.fursD_ClosingTag = "";

            }
        }

        private void Btn_Add_PP_to_FURS_Click(object sender, EventArgs e)
        {
            //save settings ? 
            string xml = "";

            Save();

            if (MakePP_XML(ref xml))
            {
                if (m_usrc_FVI_SLO.Send_PP(xml)== Result_MessageBox_Post.OK)
                {
                    if (FURS_BussinesPremiseData_SignedUp!=null)
                    {
                        FURS_BussinesPremiseData_SignedUp(true);
                    }

                }
                else
                {
                    if (FURS_BussinesPremiseData_SignedUp != null)
                    {
                        FURS_BussinesPremiseData_SignedUp(false);
                    }
                }
            }
        }

        private void SendBussinesPremise()
        {
            //save settings ? 
            string xml = "";

            Save();

            if (MakePP_XML(ref xml))
            {
                m_usrc_FVI_SLO.Send_PP(xml);
            }
        }

        bool MakePP_XML(ref string xml)
        {

            string fu_TaxNumber = txt_MyOrganisation_TaxID.Text;                     // "10329048";                   // davčna  podjetja
            string fu_BusinessPremiseID = txt_BussinesPremiseID.Text;                //  "KUNAVE6";     // Oznaka prostora vsak račun vsebuje oznako prostora 
            string fu_CadastralNumber = txt_CadastralNumber.Text;                    //  "1738";          // št. katastrske občine
            string fu_BuildingNumber = txt_BuildingNumber.Text;                     // "2183";           // številka stavbe  (GURS)
            string fu_BuildingSectionNumber = txt_BuildingSectionNumber.Text;        // "73";      //Oznaka dela stavbe (GURS)
            string fu_ValidityDate = dt_ValidityDate.Value.ToString("yyyy-MM-dd");   //  "2020 -08-25";       // do kdaj je veljaven poslovni prostor
            string fu_SoftwareSupplier_TaxNumber = txt_SoftwareSupplier_TaxNumber.Text; // "10000000";   //davvčna št izdelovalca programske opreme
            string fu_PostalCode = this.txt_PostNumber.Text;                          // Poštna številka
            string fu_Street = this.txt_StreetName.Text;          //ulica poslovnega prostora
            if (fu_Street.Length == 0) fu_Street = " ";  // ne sme bit prazno javi error html
            string fu_HouseNumber = this.txt_StreetNumber.Text;                  //hišna številka poslovnega prostora
            if (fu_HouseNumber.Length == 0) fu_HouseNumber = " ";  // ne sme bit prazno javi error html
            string fu_HouseNumberAdditional = this.txt_StreetNumberAdt.Text;     //hišna številka dodatno  poslovnega prostora
            if (fu_HouseNumberAdditional.Length == 0) fu_HouseNumberAdditional = " ";  // ne sme bit prazno javi error html
            string fu_City = this.txt_City.Text;          //Kraj
            if (fu_City.Length == 0) fu_City = " ";  // ne sme bit prazno javi error html
            string fu_Community = txt_Community.Text; // "Dravlje";             // okraj 
            if (fu_Community.Length == 0) fu_Community = " ";  // ne sme bit prazno javi error html

            //TODO: LK  do edit box on form
            string fu_SpecialNotes = " ";                 //dodatno sporočilo za interno evidenco

            #region CheckValues

            // check values 
            if (fu_TaxNumber.Length != 8 || GetIntValueFromString(fu_TaxNumber) == 0)
            {
                MessageBox.Show("Davčna številka podjetja mora biti osem mestna številka!");
                return false;
            }
            if (txt_InvoiceAuthor_TaxID.Text.Length != 8 || GetIntValueFromString(txt_InvoiceAuthor_TaxID.Text) == 0)
            {
                MessageBox.Show("Davčna številka izdajatelja računa mora biti osem mestna številka!");
                return false;
            }
            if (fu_SoftwareSupplier_TaxNumber.Length != 8 || GetIntValueFromString(fu_SoftwareSupplier_TaxNumber) == 0)
            {
                MessageBox.Show("Davčna številka prozivajalca programske opreme mora biti osem mestna številka!");
                return false;
            }
            if (fu_BusinessPremiseID.Trim().Length == 0)
            {
                MessageBox.Show("Oznaka prostora ne sme biti prazna");
                return false;
            }

            if (!IsNumeric(fu_PostalCode) || fu_PostalCode.Length != 4)
            {
                MessageBox.Show("Vnesi poštno številko štiri številke!");
                return false;
            }

            if (GetIntValueFromString(fu_CadastralNumber) == 0)
            {
                MessageBox.Show("Vnesi katastrsko občino!");
            }

            if (GetIntValueFromString(fu_BuildingNumber) == 0)
            {
                MessageBox.Show("Vnesi številko stavbe!");
            }
            if (GetIntValueFromString(fu_BuildingSectionNumber) == 0)
            {
                MessageBox.Show("Vnesi številko dela stavbe!");
            }

            #endregion

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


                //TODO: LK ne dela 
                // <fu:ClosingTag></fu:ClosingTag>
                if (Chk_StoreClosed.Checked)  // je Z če je trgovina prenehala z obratovanjem 
                {
                    NList = xdoc.GetElementsByTagName("fu:BusinessPremise");
                    string ns = NList.Item(0).GetNamespaceOfPrefix("fu");
                    XmlNode xClosingTag = xdoc.CreateNode("element", "ClosingTag", ns);
                    xClosingTag.Prefix = "fu";
                    xClosingTag.InnerText = "Z";
                    NList.Item(0).AppendChild(xClosingTag);
                }





                xml = XmlDcoumentToString(xdoc);
                return true;
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:InvoiceData:Create_furs_InvoiceXML:Exception = " + Ex.Message);
                return false;
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
            // ClosingTag ></ fu:ClosingTag >
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

        private bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s.Trim(), out output);
        }

        private int GetIntValueFromString(string s)
        {
            int output = 0;
            bool ret = int.TryParse(s.Trim(), out output);

            return output;

        }

    }
}
