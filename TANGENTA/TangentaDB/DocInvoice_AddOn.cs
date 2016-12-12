using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace TangentaDB
{
    public class DocInvoice_AddOn
    {
        private long m_TermsOfPayment_ID = -1;
        private long m_MethodOfPayment_ID = -1;
        private DateTime m_PaymentDeadline;

        public DateTime PaymentDeadline
        {
            get { return m_PaymentDeadline; }
        }

        public long TermsOfPayment_ID
        {
            get { return m_TermsOfPayment_ID; }
            set { m_TermsOfPayment_ID = value; }
        }

        public long MethodOfPayment_ID
        {
            get { return m_MethodOfPayment_ID; }
            set { m_MethodOfPayment_ID = value; }
        }

        public string m_MethodOfPayment = null;
        public string MethodOfPayment
        {
            get { return m_MethodOfPayment; }
        }

        public string m_MethodOfPayment_BankAccount = null;
        public string MethodOfPayment_BankAccount
        {
            get { return m_MethodOfPayment_BankAccount; }
        }

        public string m_MethodOfPayment_BankName = null;
        public string MethodOfPayment_BankName
        {
            get { return m_MethodOfPayment_BankName; }
        }


        public bool b_FVI_SLO = false;

        public string_v FURS_ZOI_v = null;
        public string_v FURS_EOR_v = null;
        public string_v FURS_QR_v = null;
        public Image FURS_Image_QRcode = null;

        public string_v FURS_SalesBookInvoice_InvoiceNumber_v = null;
        public string_v FURS_SalesBookInvoice_SetNumber_v = null;
        public string_v FURS_SalesBookInvoice_SerialNumber = null;


        public long_v DocInvoice_Reference_ID_v = null;
        public bool bInvoiceStorno = false;


        public DateTime_v StornoIssueDate_v = null;
        public bool_v Invoice_Storno_v = null;
        public string_v Invoice_Reference_Type_v = null;

        public UniversalInvoice.FVI_SLO_RealEstateBP FVI_SLO_RealEstateBP = null;
        public UniversalInvoice.Invoice_FURS_Token Invoice_FURS_Token = null;


        public bool Write_FURS_Response_Data(long DocInvoice_ID)
        {
            object oret = null;
            string Err = null;
            string sql = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Invoice_ID = "@par_Invoice_ID";
            SQL_Parameter par_Invoice_ID = new SQL_Parameter(spar_Invoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, DocInvoice_ID);
            lpar.Add(par_Invoice_ID);
            sql = "select ID from fvi_slo_response where DocInvoice_ID = " + spar_Invoice_ID;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    LogFile.Error.Show("ERROR:InvoiceData:Write_FURS_Response_Data:sql=" + sql + "\r\n Invoice was confirmed in the past: Invoice_ID" + DocInvoice_ID.ToString() + " fvi_slo_response.ID=" + ((long)dt.Rows[0]["ID"]).ToString());
                    return true;

                }
            }
            string spar_MessageID = "@par_MessageID";
            SQL_Parameter par_MessageID = new SQL_Parameter(spar_MessageID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_ZOI_v.v);
            lpar.Add(par_MessageID);


            string spar_UniqueInvoiceID = "@par_UniqueInvoiceID";
            SQL_Parameter par_UniqueInvoiceID = new SQL_Parameter(spar_UniqueInvoiceID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_EOR_v.v);
            lpar.Add(par_UniqueInvoiceID);

            string spar_BarCodeValue = "@par_BarCodeValue";
            SQL_Parameter par_BarCodeValue = new SQL_Parameter(spar_BarCodeValue, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_QR_v.v);
            lpar.Add(par_BarCodeValue);

            DateTime resp_datetime = DateTime.Now;
            string spar_Response_DateTime = "@par_Response_DateTime";
            SQL_Parameter par_Response_DateTime = new SQL_Parameter(spar_Response_DateTime, SQL_Parameter.eSQL_Parameter.Datetime, false, resp_datetime);
            lpar.Add(par_Response_DateTime);


            sql = "insert into fvi_slo_response (DocInvoice_ID,MessageID,UniqueInvoiceID,BarCodeValue,Response_DateTime) values (" + spar_Invoice_ID + "," + spar_MessageID + "," + spar_UniqueInvoiceID + "," + spar_BarCodeValue + "," + spar_Response_DateTime + ")";
            long id = -1;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref oret, ref Err, "fvi_slo_response"))
            {
                Set_Invoice_Furs_Token();
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:InvoiceData:Write_FURS_Response_Data:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public void Set_Invoice_Furs_Token()
        {
            if (Invoice_FURS_Token == null)
            {
                Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
            }
            Invoice_FURS_Token.tUniqueMessageID.Set(this.FURS_ZOI_v.v);
            Invoice_FURS_Token.tUniqueInvoiceID.Set(this.FURS_EOR_v.v);

            if (this.FURS_Image_QRcode != null)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    this.FURS_Image_QRcode.Save(m, this.FURS_Image_QRcode.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    Invoice_FURS_Token.tQR.Set(base64String);
                }
            }
        }



        public bool Read_FURS_Response_Data(long DocProformaInvoice_ID, ref DataTable dt)
        {
            string sql = "select MessageID,UniqueInvoiceID,BarCodeValue from fvi_slo_response where DocInvoice_ID = " + DocProformaInvoice_ID.ToString();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    FURS_ZOI_v = tf.set_string(dt.Rows[0]["MessageID"]);
                    FURS_EOR_v = tf.set_string(dt.Rows[0]["UniqueInvoiceID"]);
                    FURS_QR_v = tf.set_string(dt.Rows[0]["BarCodeValue"]);
                    this.FURS_Image_QRcode = null;
                }
                else
                {
                    if (Invoice_FURS_Token == null)
                    {
                        Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
                    }
                    Invoice_FURS_Token.tUniqueMessageID.Set("");
                    Invoice_FURS_Token.tUniqueInvoiceID.Set("");
                    Invoice_FURS_Token.tQR.Set("");
                }
                return true;

            }
            else
            {
                LogFile.Error.Show("ERROR:InvoiceData:Read_FURS_Response_Data:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public string Create_furs_InvoiceXML(bool bStorno, 
                                            string InvoiceXmlTemplate,
                                            string FursD_MyOrgTaxID,
                                            string FursD_BussinesPremiseID,
                                            string CasshierName,
                                            string FursD_InvoiceAuthorTaxID,
                                            string stornoReferenceInvoiceNumber,
                                            string stornoReferenceInvoiceIssueDateTime,
                                            DateTime_v IssueDate_v,
                                            long NumberInFinancialYear,
                                            decimal GrossSum,
                                            StaticLib.TaxSum taxSum,
                                            UniversalInvoice.Person Invoice_Author)
        {
            try
            {
                //                string InvoiceXmlTemplate = Properties.Resources.FVI_SLO_Invoice;
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(InvoiceXmlTemplate);
                XmlNodeList ndl_TaxNumber = xdoc.GetElementsByTagName("fu:TaxNumber");
                //string sInnerText_MyOrgTaxID = Program.usrc_FVI_SLO1.FursD_MyOrgTaxID; // "10329048";//MyOrganisation.Tax_ID;
                ndl_TaxNumber.Item(0).InnerText = FursD_MyOrgTaxID;//Program.usrc_FVI_SLO1.FursD_MyOrgTaxID; //MyOrganisation.Tax_ID;
                XmlNodeList ndl_IssueDateTime = xdoc.GetElementsByTagName("fu:IssueDateTime");
                ndl_IssueDateTime.Item(0).InnerText = fs.GetFURS_Time_Formated(IssueDate_v.v);
                XmlNodeList ndl_BusinessPremiseID = xdoc.GetElementsByTagName("fu:BusinessPremiseID");
                //string sInnerText_FursD_BussinesPremiseID = Program.usrc_FVI_SLO1.FursD_BussinesPremiseID;
                ndl_BusinessPremiseID.Item(0).InnerText = FursD_BussinesPremiseID;// Program.usrc_FVI_SLO1.FursD_BussinesPremiseID; // "36CF"; //MyOrganisation.Atom_Office_Name;
                XmlNodeList ndl_ElectronicDeviceID = xdoc.GetElementsByTagName("fu:ElectronicDeviceID");
                ndl_ElectronicDeviceID.Item(0).InnerText = CasshierName;//Properties.Settings.Default.CasshierName;
                XmlNodeList ndl_InvoiceNumber = xdoc.GetElementsByTagName("fu:InvoiceNumber");
                ndl_InvoiceNumber.Item(0).InnerText = NumberInFinancialYear.ToString();
                XmlNodeList ndl_InvoiceAmount = xdoc.GetElementsByTagName("fu:InvoiceAmount");
                ndl_InvoiceAmount.Item(0).InnerText = sStorno(bStorno) + fs.GetFursDecimalString(GrossSum);
                XmlNodeList ndl_PaymentAmount = xdoc.GetElementsByTagName("fu:PaymentAmount");
                ndl_PaymentAmount.Item(0).InnerText = sStorno(bStorno) + fs.GetFursDecimalString(GrossSum);

                XmlNodeList ndl_TaxesPerSeller = xdoc.GetElementsByTagName("fu:TaxesPerSeller");
                string s_innertext = "";
                foreach (StaticLib.Tax tax in taxSum.TaxList)
                {
                    string sVat = "<fu:VAT>\r\n" +
                                          "<fu:TaxRate>" + sStorno(bStorno) + fs.GetFursDecimalString(tax.Rate * 100) + "</fu:TaxRate>\r\n" +
                                          "<fu:TaxableAmount>" + sStorno(bStorno) + fs.GetFursDecimalString(tax.TaxableAmount) + "</fu:TaxableAmount>\r\n" +
                                          "<fu:TaxAmount>" + sStorno(bStorno) + fs.GetFursDecimalString(tax.TaxAmount) + "</fu:TaxAmount>\r\n" +
                                   "</fu:VAT>" + "\r\n";
                    s_innertext += sVat;
                }
                ndl_TaxesPerSeller.Item(0).InnerXml = s_innertext;

                XmlNodeList ndl_OperatorTaxNumber = xdoc.GetElementsByTagName("fu:OperatorTaxNumber");

                string sFursD_InvoiceAuthorTaxID = FursD_InvoiceAuthorTaxID;// Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID;

                //Invoice_Author.Tax_ID = "59729481";

                Invoice_Author.Tax_ID = FursD_InvoiceAuthorTaxID;// Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID;


                ndl_OperatorTaxNumber.Item(0).InnerText = Invoice_Author.Tax_ID;

                //LK storno 
                if (bStorno)
                {
                    XmlNodeList Fu_Invoice = xdoc.GetElementsByTagName("fu:Invoice");
                    string ns = Fu_Invoice.Item(0).GetNamespaceOfPrefix("fu");

                    XmlNode xReferenceInvoice = xdoc.CreateNode("element", "ReferenceInvoice", ns);
                    XmlNode xReferenceInvoiceIdentifier = xdoc.CreateNode("element", "ReferenceInvoiceIdentifier", ns);
                    XmlNode xBusinessPremiseID = xdoc.CreateNode("element", "BusinessPremiseID", ns);
                    XmlNode xElectronicDeviceID = xdoc.CreateNode("element", "ElectronicDeviceID", ns);
                    XmlNode xInvoiceNumber = xdoc.CreateNode("element", "InvoiceNumber", ns);
                    XmlNode xReferenceInvoiceIssueDateTime = xdoc.CreateNode("element", "ReferenceInvoiceIssueDateTime", ns);
                    xReferenceInvoice.Prefix = "fu";
                    xReferenceInvoiceIdentifier.Prefix = "fu";
                    xBusinessPremiseID.Prefix = "fu";
                    xElectronicDeviceID.Prefix = "fu";
                    xInvoiceNumber.Prefix = "fu";
                    xReferenceInvoiceIssueDateTime.Prefix = "fu";


                    xBusinessPremiseID.InnerText = FursD_BussinesPremiseID;
                    xElectronicDeviceID.InnerText = CasshierName;
                    xInvoiceNumber.InnerText = stornoReferenceInvoiceNumber;
                    xReferenceInvoiceIssueDateTime.InnerText = stornoReferenceInvoiceIssueDateTime;

                    xReferenceInvoiceIdentifier.AppendChild(xBusinessPremiseID);
                    xReferenceInvoiceIdentifier.AppendChild(xElectronicDeviceID);
                    xReferenceInvoiceIdentifier.AppendChild(xInvoiceNumber);
                    xReferenceInvoice.AppendChild(xReferenceInvoiceIdentifier);
                    xReferenceInvoice.AppendChild(xReferenceInvoiceIssueDateTime);
                    Fu_Invoice.Item(0).AppendChild(xReferenceInvoice);

                    //<fu:ReferenceInvoice>
                    //  <fu:ReferenceInvoiceIdentifier >  
                    //    <fu:BusinessPremiseID > TRGOVINA1 </ fu:BusinessPremiseID >
                    //    <fu:ElectronicDeviceID > BLAG2 </ fu:ElectronicDeviceID >
                    //    <fu:InvoiceNumber > 145 </ fu:InvoiceNumber >
                    //  </fu:ReferenceInvoiceIdentifier >
                    //  <fu:ReferenceInvoiceIssueDateTime > 2015 - 09 - 07T12: 12:54 </ fu:ReferenceInvoiceIssueDateTime >
                    //</fu:ReferenceInvoice >
                }

                string InvoiceXml = XmlDcoumentToString(xdoc);
                return InvoiceXml;
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:InvoiceData:Create_furs_InvoiceXML:Exception = " + Ex.Message);
                return null;
            }

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


        private string sStorno(bool bStorno)
        {
            if (bStorno)
            {
                return "";
            }
            else
            {
                return "";
            }
        }


        public string Create_furs_SalesBookInvoiceXML(string InvoiceXmlTemplate,
                                                      string FursD_MyOrgTaxID,
                                                      string FursD_BussinesPremiseID,
                                                      string SalesBookSetNumber,
                                                      string SalesBookSerialNumber,
                                                      DateTime_v IssueDate_v,
                                                      long NumberInFinancialYear,
                                                      decimal GrossSum,
                                                      StaticLib.TaxSum taxSum)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(InvoiceXmlTemplate);
                XmlNodeList ndl_TaxNumber = xdoc.GetElementsByTagName("fu:TaxNumber");
                ndl_TaxNumber.Item(0).InnerText = FursD_MyOrgTaxID;
                XmlNodeList ndl_IssueDateTime = xdoc.GetElementsByTagName("fu:IssueDate");
                ndl_IssueDateTime.Item(0).InnerText = IssueDate_v.v.ToString("yyyy-MM-dd");
                XmlNodeList ndl_BusinessPremiseID = xdoc.GetElementsByTagName("fu:BusinessPremiseID");
                ndl_BusinessPremiseID.Item(0).InnerText = FursD_BussinesPremiseID;
                XmlNodeList ndl_InvoiceNumber = xdoc.GetElementsByTagName("fu:InvoiceNumber");
                ndl_InvoiceNumber.Item(0).InnerText = NumberInFinancialYear.ToString();
                XmlNodeList ndl_InvoiceAmount = xdoc.GetElementsByTagName("fu:InvoiceAmount");
                ndl_InvoiceAmount.Item(0).InnerText = fs.GetFursDecimalString(GrossSum);
                XmlNodeList ndl_PaymentAmount = xdoc.GetElementsByTagName("fu:PaymentAmount");
                ndl_PaymentAmount.Item(0).InnerText = fs.GetFursDecimalString(GrossSum);

                XmlNodeList ndl_TaxesPerSeller = xdoc.GetElementsByTagName("fu:TaxesPerSeller");
                string s_innertext = "";
                foreach (StaticLib.Tax tax in taxSum.TaxList)
                {
                    string sVat = "<fu:VAT>\r\n" +
                                          "<fu:TaxRate>" + fs.GetFursDecimalString(tax.Rate * 100) + "</fu:TaxRate>\r\n" +
                                          "<fu:TaxableAmount>" + fs.GetFursDecimalString(tax.TaxableAmount) + "</fu:TaxableAmount>\r\n" +
                                          "<fu:TaxAmount>" + fs.GetFursDecimalString(tax.TaxAmount) + "</fu:TaxAmount>\r\n" +
                                   "</fu:VAT>" + "\r\n";
                    s_innertext += sVat;
                }
                ndl_TaxesPerSeller.Item(0).InnerXml = s_innertext;

                // salesbook stuff
                XmlNodeList ndl_SetNumber = xdoc.GetElementsByTagName("fu:SetNumber");
                ndl_SetNumber.Item(0).InnerText = Convert.ToInt32(SalesBookSetNumber).ToString("D2");

                XmlNodeList ndl_SerialNumber = xdoc.GetElementsByTagName("fu:SerialNumber");
                ndl_SerialNumber.Item(0).InnerText = SalesBookSerialNumber;


                string InvoiceXml = XmlDcoumentToString(xdoc);
                return InvoiceXml;
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:InvoiceData:Create_furs_SalesBookInvoiceXML:Exception = " + Ex.Message);
                return null;
            }

        }

    }
}
