using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class FVI_SLO : Component
    {
        public enum eStartResult { OK,ALLREADY_RUNNING,ERROR};

        public usrc_FVI_SLO m_usrc_FVI_SLO = null;
        #region Declaration
        public const string FormFURSCommunication_ErrorMessage_BUSSINES_PREMISE_NOT_DEFINED = "[S006]";

        public bool DEBUG = false;
        public int timeOutInSec = 0;

        private FormFURSCommunication FormFURSCommunication = null;

        public delegate void delegate_Response_SingleInvoice(long Message_ID, string xml);
        public delegate void delegate_Response_ManyInvoices(long Message_ID, string xml);
        public delegate void delegate_Response_PP(long Message_ID, string xml);
        public delegate void delegate_Response_ECHO(long Message_ID, string xml);

        public event delegate_Response_SingleInvoice Response_SingleInvoice = null;
        public event delegate_Response_ManyInvoices Response_ManyInvoices = null;
        public event delegate_Response_PP Response_PP = null;
        public event delegate_Response_ECHO Response_ECHO = null;



        private bool bRun = false;

        public FVI_SLO_MessageBox message_box = null;

        public Thread_FVI thread_fvi = new Thread_FVI();

        private FVI_SLO_Message message = new FVI_SLO_Message(0, FVI_SLO_Message.eMessage.NONE, null);

        private int m_message_box_length = 100;
        private long LastMessageID = 0;


        #endregion

        internal Form_FURS_WEB_check_invoice m_Form_FURS_WEB_check_invoice = null;

        #region Properties

        public bool FursTESTEnvironment
        {
            get { return Properties.Settings.Default.fursTEST_Environment; }
            set
            {
                bool bTest = value;
                if (bTest)
                {
                    if (m_usrc_FVI_SLO != null)
                    {
                        m_usrc_FVI_SLO.btn_FVI.Image = Properties.Resources.TAX_Office_Connection_TEST_environment;
                    }
                    Properties.Settings.Default.fursTEST_Environment = true;
                }
                else
                {
                    if (m_usrc_FVI_SLO != null)
                    {
                        m_usrc_FVI_SLO.btn_FVI.Image = Properties.Resources.TAX_Office_Connection;
                    }
                    Properties.Settings.Default.fursTEST_Environment = false;
                }
            }
        }

        //if (TestValues)
        //{
        //    FursCertificateFileName = Properties.Settings.Default.furscertificateFileName_TEST;
        //    FursCertificatePassword= Properties.Settings.Default.fursCertPass_TEST;
        //    FursWebServiceURL= Properties.Settings.Default.fursWebServiceURL_TEST;



        //}
        //else
        //{
        //    FursCertificateFileName = Properties.Settings.Default.furscertificateFileName;
        //    FursCertificatePassword = Properties.Settings.Default.fursCertPass;
        //    FursWebServiceURL = Properties.Settings.Default.fursWebServiceURL;

        //}


        public string FursCertificateFileName
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.furscertificateFileName_TEST;
                }
                else
                {
                    return Properties.Settings.Default.furscertificateFileName;
                }
            }
        }


        public bool FVI_for_cash_payment
        {
            get { return Properties.Settings.Default.FVI_for_cash_payment; }
        }

        public bool FVI_for_card_payment
        {
            get { return Properties.Settings.Default.FVI_for_card_payment; }
        }

        public bool FVI_for_payment_on_bank_account
        {
            get { return Properties.Settings.Default.FVI_for_payment_on_bank_account; }
        }

        public string FursCertificatePassword
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursCertPass_TEST;
                }
                else
                {
                    return Properties.Settings.Default.fursCertPass;
                }
            }
        }

        public string FursWebServiceURL
        {

            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursWebServiceURL_TEST;
                }
                else
                {
                    return Properties.Settings.Default.fursWebServiceURL;
                }
            }
        }

        public string FursXmlNamespace
        {
            get
            {
                if (FursTESTEnvironment)
                {

                    return Properties.Settings.Default.fursXmlNamespace_TEST;
                }
                else
                {
                    return Properties.Settings.Default.fursXmlNamespace;
                }
            }
        }

        public string FursD_BuildingNumber
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursD_BuildingNumber_TEST;
                }
                else
                {
                    //return Properties.Settings.Default.fursD_BuildingNumber;
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate != null)
                        {
                            if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.BuildingNumber_v != null)
                            {
                                return myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.BuildingNumber_v.v.ToString();
                            }
                        }
                    }

                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property FursD_BuildingNumber is not defined!");
                    return null;
                }
            }
        }

        public string FursD_BuildingSectionNumber
        {
            get
            {
                if (FursTESTEnvironment)
                {

                    return Properties.Settings.Default.fursD_BuildingSectionNumber_TEST;
                }
                else
                {
                    //return Properties.Settings.Default.fursD_BuildingSectionNumber;
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate != null)
                        {
                            if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.BuildingSectionNumber_v != null)
                            {
                                return myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.BuildingSectionNumber_v.v.ToString();
                            }
                        }
                    }

                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property FursD_BuildingSectionNumber is not defined!");
                    return null;
                }
            }
        }

        public string FursD_Community
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursD_Community_TEST;
                }
                else
                {
                    //return Properties.Settings.Default.fursD_Community;
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate != null)
                        {
                            if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.Community_v != null)
                            {
                                return myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.Community_v.v.ToString();
                            }
                        }
                    }
                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property FursD_Community is not defined!");
                    return null;
                }
            }
        }

        public string FursD_CadastralNumber
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursD_CadastralNumber_TEST;
                }
                else
                {
                    //return Properties.Settings.Default.fursD_CadastralNumber;
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate != null)
                        {
                            if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.CadastralNumber_v != null)
                            {
                                return myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.CadastralNumber_v.v.ToString();
                            }
                        }
                    }
                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property FursD_CadastralNumber is not defined!");
                    return null;
                }
            }
        }


        public DateTime FursD_ValidityDate
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursD_ValidityDate_TEST;
                }
                else
                {
                    //return Properties.Settings.Default.fursD_ValidityDate;
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate != null)
                        {
                            if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.ValidityDate_v != null)
                            {
                                return myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.ValidityDate_v.v;
                            }
                        }
                    }
                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property FursD_ValidityDate is not defined!");
                    return DateTime.MinValue;
                }
            }
        }
        public string FursD_ClosingTag
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursD_ClosingTag_TEST;
                }
                else
                {
                    //return Properties.Settings.Default.fursD_ClosingTag;
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate != null)
                        {
                            if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.ClosingTag_v != null)
                            {
                                return myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.ClosingTag_v.v;
                            }
                        }
                    }
                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property FursD_ClosingTag is not defined!");
                    return null;
                }
            }
        }

        public string FursD_SoftwareSupplierTaxID
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursD_SoftwareSupplierTaxID_TEST;
                }
                else
                {
                    //return Properties.Settings.Default.fursD_SoftwareSupplierTaxID;
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate != null)
                        {
                            if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.SoftwareSupplier_TaxNumber_v != null)
                            {
                                return myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.SoftwareSupplier_TaxNumber_v.v;
                            }
                        }
                    }
                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property FursD_SoftwareSupplierTaxID is not defined!");
                    return null;
                }
            }
        }

        public string FursD_PremiseType
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursD_PremiseType_TEST;
                }
                else
                {
                    // return Properties.Settings.Default.fursD_PremiseType;
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate != null)
                        {
                            if (myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.PremiseType_v != null)
                            {
                                return myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.PremiseType_v.v;
                            }
                        }
                    }
                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property FursD_PremiseType is not defined!");
                    return null;
                }
            }
        }

        public enum Check_SLO_TaxID_Result { OK, LENGTH_ISNOT_8, ALL_CHARACTERS_ARE_NOT_NUMBERS, CHECK_FAILED }

        private Check_SLO_TaxID_Result Check_SLO_TaxID(string sTaxID)
        {
            if (sTaxID.Length == 8)
            {
                int[] digit = new int[8];
                int j = 7;
                int icontrol = -1;
                int iFact = 2;
                int isum = 0;
                for (j = 7; j >= 0; j--)
                {
                    char s = sTaxID[j];
                    if (!char.IsDigit(s))
                    {
                        return Check_SLO_TaxID_Result.ALL_CHARACTERS_ARE_NOT_NUMBERS;
                    }
                    string sdigit = s.ToString();
                    digit[j] = Convert.ToInt32(sdigit);
                    if (j == 7)
                    {
                        icontrol = digit[j];
                    }
                    else
                    {
                        isum += digit[j] * iFact;
                        iFact++;
                    }
                }
                int irem = isum % 11;
                int ic = 11 - irem;
                if (ic == icontrol)
                {
                    return Check_SLO_TaxID_Result.OK;
                }
                else
                {
                    return Check_SLO_TaxID_Result.CHECK_FAILED;
                }
            }
            else
            {
                return Check_SLO_TaxID_Result.LENGTH_ISNOT_8;
            }
        }

        public string FursD_MyOrgTaxID
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursD_MyOrgTaxID_TEST;
                }
                else
                {
                    //return Properties.Settings.Default.fursD_MyOrgTaxID;
                    if (myOrg.Tax_ID_v != null)
                    {
                        return myOrg.Tax_ID_v.v;
                    }
                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property string FursD_MyOrgTaxID is not defined!");
                    return null;
                }
            }
        }

        public string FursD_BussinesPremiseID
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursD_BussinesPremiseID_TEST;
                }
                else
                {
                    //Properties.Settings.Default.fursD_BussinesPremiseID;
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (myOrg.m_myOrg_Office.ShortName_v != null)
                        {
                            return myOrg.m_myOrg_Office.ShortName_v.v;
                        }
                    }
                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property FursD_BussinesPremiseID is not defined!");
                    return null;
                }
            }
        }

        private string m_FursD_ElectronicDeviceID = "";

        public string FursD_ElectronicDeviceID
        {
            get { return m_FursD_ElectronicDeviceID; }

            set { m_FursD_ElectronicDeviceID = value; }
        }


        public string FursD_InvoiceAuthorTaxID
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursD_InvoiceAuthorTaxID_TEST;
                }
                else
                {
                    //return Properties.Settings.Default.fursD_InvoiceAuthorTaxID;
                    if (myOrg.m_myOrg_Office != null)
                    {
                        if (myOrg.m_myOrg_Office.m_myOrg_Person != null)
                        {
                            if (myOrg.m_myOrg_Office.m_myOrg_Person != null)
                            {
                                if (myOrg.m_myOrg_Office.m_myOrg_Person.Tax_ID_v != null)
                                {
                                    return myOrg.m_myOrg_Office.m_myOrg_Person.Tax_ID_v.v;
                                }
                            }
                        }
                    }
                    if (!this.DesignMode) LogFile.Error.Show("FiscalVerificationOfInvoices_SLO:usrc_FVI_SLO:property FursD_InvoiceAuthorTaxID is not defined!");
                    return null;

                }
            }
        }

        public string FursD_WWW_check_invoice
        {
            get
            {
                if (FursTESTEnvironment)
                {
                    return Properties.Settings.Default.fursWWW_check_invoice_TEST;
                }
                else
                {
                    return Properties.Settings.Default.fursWWW_check_invoice;
                }
            }
        }

        public string XML_Template_FVI_SLO_SalesBook
        {
            get { return Properties.Resources.FVI_SLO_SalesBook; }

        }

        public int MessageBox_Length
        {
            get { return m_message_box_length; }
            set { m_message_box_length = value; }
        }

        public bool IsRunning
        {
            get
            {
                return bRun;
            }
        }


        #endregion


        public FVI_SLO()
        {
            InitializeComponent();
        }

        public FVI_SLO(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool SetTestCertificate()
        {
            string xfurscertificateFileName_TEST = Properties.Settings.Default.furscertificateFileName_TEST;
            if (xfurscertificateFileName_TEST.Length == 0)
            {
                return SaveTestCertficate();
            }
            return true;
        }

        private bool SaveTestCertficate()
        {
            string FullAssemblyPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string FullTestCertificatePath = Path.GetDirectoryName(FullAssemblyPath);
            if (FullTestCertificatePath.Length > 0)
            {
                if (FullTestCertificatePath[FullTestCertificatePath.Length - 1] == '\\')
                {
                    FullTestCertificatePath += TestCertificate.TestCertName;
                }
                else
                {
                    FullTestCertificatePath += '\\' + TestCertificate.TestCertName;
                }
                if (TestCertificate.Save(ref FullTestCertificatePath))
                {
                    Properties.Settings.Default.furscertificateFileName_TEST = FullTestCertificatePath;
                    Properties.Settings.Default.fursCertPass_TEST = "269BODLY9RBL";
                    this.FursTESTEnvironment = true;
                    Properties.Settings.Default.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:FiscalVerification_SLO:usrc_FVI_SLO:usrc_FVI_SLO():FullTestCertificatePath.Length==0!");
                return false;
            }
        }

        public bool Start(string xcertificateFileName, string xCertPass, string xfursWebServiceURL, string xfursXmlNamespace, int xtimeOutInSec, Control ParentForm, ref string ErrReason)
        {
            if (!bRun)
            {
                message_box = new FVI_SLO_MessageBox(MessageBox_Length);
                thread_fvi.Start(message_box, MessageBox_Length, FursTESTEnvironment, xcertificateFileName, xCertPass, xfursWebServiceURL, xfursXmlNamespace, xtimeOutInSec, ref ErrReason);
                timer_MessagePump.Enabled = true;
                bRun = true;
                return true;
            }
            else
            {
                ErrReason = "0 Not run";
                return false;
            }
        }

        internal string FURS_InvoiceNumber(int invoiceNumber)
        {
            return FursD_BussinesPremiseID + "-" + FursD_ElectronicDeviceID + "-" + invoiceNumber.ToString();
        }

        public void Check_SalesBookInvoice(ShopABC xShopABC, DocInvoice_AddOn xAddOnDPI, DocProformaInvoice_AddOn xDocProformaInvoice_AddOn)
        {
            List<InvoiceData> InvoiceData_List = null;
            Properties.Settings.Default.Reload();
            bool bTest = Properties.Settings.Default.fursTEST_Environment;
            if (f_FVI_SLO_SalesBookInvoice.Select_SalesBookInvoice_NotSent(xShopABC, xAddOnDPI, xDocProformaInvoice_AddOn, ref InvoiceData_List, FursD_ElectronicDeviceID))
            {
                if (InvoiceData_List != null)
                {
                    if (InvoiceData_List.Count > 0)
                    {
                        Form_SalesBookInvoice_Send frm_sbi_send = new Form_SalesBookInvoice_Send(this, InvoiceData_List);
                        frm_sbi_send.ShowDialog();
                    }
                }
            }
        }

        public bool Check_InvoiceNotConfirmedAtFURS(ShopABC xShopABC, DocInvoice_AddOn xAddOnDPI, DocProformaInvoice_AddOn xDocProformaInvoice_AddOn)
        {
            Properties.Settings.Default.Reload();
            bool bTest = Properties.Settings.Default.fursTEST_Environment;
            List<InvoiceData> InvoiceData_List = null;
            if (f_FVI_SLO_Invoice.Select_InvoiceNotConfirmed(xShopABC, xAddOnDPI, xDocProformaInvoice_AddOn, ref InvoiceData_List, FursD_ElectronicDeviceID))
            {
                if (InvoiceData_List != null)
                {
                    if (InvoiceData_List.Count > 0)
                    {
                        Form_InvoiceNotConfirmed_Send frm_sbi_send = new Form_InvoiceNotConfirmed_Send(this, InvoiceData_List);
                        frm_sbi_send.ShowDialog();
                        return true;
                    }
                }
            }
            return false;
        }

        public void Write_SalesBookInvoice(ID Invoice_ID, int FiscalYear, int InvoiceNumber, ref string xSerialNumber, ref string xSetNumber, ref string xInvoiceNumber)
        {
            Form_EnterData_to_SalesBookInvoice fsb = new Form_EnterData_to_SalesBookInvoice(this, Invoice_ID, FiscalYear, InvoiceNumber, null, null, null, Form_EnterData_to_SalesBookInvoice.eMode.WRITE);
            fsb.ShowDialog();
            xSerialNumber = fsb.SerialNumber;
            xSetNumber = fsb.SetNumber;
            xInvoiceNumber = fsb.InvoiceNumber;

        }


        public void Update_SalesBookInvoice(ID Invoice_ID, int FiscalYear, int InvoiceNumber, ref string xSerialNumber, ref string xSetNumber, ref string xInvoiceNumber)
        {
            Form_EnterData_to_SalesBookInvoice fsb = new Form_EnterData_to_SalesBookInvoice(this, Invoice_ID, FiscalYear, InvoiceNumber, xSerialNumber, xSetNumber, xInvoiceNumber, Form_EnterData_to_SalesBookInvoice.eMode.WRITE);
            fsb.ShowDialog();
            xSerialNumber = fsb.SerialNumber;
            xSetNumber = fsb.SetNumber;
            xInvoiceNumber = fsb.InvoiceNumber;
        }

        public eStartResult Start(ref string ErrReason)
        {
            if (!bRun)
            {
                Properties.Settings.Default.Reload();
                bool bTest = Properties.Settings.Default.fursTEST_Environment;
                FursTESTEnvironment = bTest;
                message_box = new FVI_SLO_MessageBox(MessageBox_Length);
                DialogResult dlgResult = DialogResult.None;
                while (dlgResult != DialogResult.Cancel)
                {
                    DEBUG = Properties.Settings.Default.DEBUG;
                    timeOutInSec = Properties.Settings.Default.timeOutInSec;
                    if (bTest)
                    {
                        if (!File.Exists(FursCertificateFileName))
                        {
                            SaveTestCertficate();
                        }
                    }
                    if (thread_fvi.Start(message_box, MessageBox_Length, FursTESTEnvironment, FursCertificateFileName, FursCertificatePassword, FursWebServiceURL, FursXmlNamespace, timeOutInSec, ref ErrReason))
                    {
                        timer_MessagePump.Enabled = true;
                        bRun = true;
                        return eStartResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(ErrReason);
                        NavigationButtons.Navigation nav_Form_Settings = new NavigationButtons.Navigation(null);
                        nav_Form_Settings.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
                        nav_Form_Settings.bDoModal = true;
                        bool Reset2FactorySettings_FiscalVerification_DLL = false;
                        Form_Settings fvi_settings = new Form_Settings(this, nav_Form_Settings, ref Reset2FactorySettings_FiscalVerification_DLL);
                        dlgResult = fvi_settings.ShowDialog();
                    }
                }
                return eStartResult.ERROR;
            }
            else
            {
                ErrReason = "Allready_Running";
                return eStartResult.ALLREADY_RUNNING;
            }
        }

        internal bool Send_SalesBookInvoice(Control pctrl, InvoiceData invoiceData, ref string ZOI, ref string EOR, ref string barCodeValue, ref Image img_QR)
        {
            string Xml_SalesBookInvoice_template = Properties.Resources.FVI_SLO_SalesBook;
            string Xml_SalesBookInvoice = invoiceData.AddOnDI.m_FURS.Create_furs_SalesBookInvoiceXML(Xml_SalesBookInvoice_template, FursD_MyOrgTaxID, FursD_BussinesPremiseID,
                                                                                     invoiceData.AddOnDI.m_FURS.FURS_SalesBookInvoice_SetNumber_v.v,
                                                                                     invoiceData.AddOnDI.m_FURS.FURS_SalesBookInvoice_SerialNumber_v.v,
                                                                                     invoiceData.IssueDate_v,
                                                                                     invoiceData.NumberInFinancialYear,
                                                                                     invoiceData.GrossSum,
                                                                                     invoiceData.taxSum);
            if (Send_SingleInvoice(true, Xml_SalesBookInvoice, pctrl, ref ZOI, ref EOR, ref barCodeValue, ref img_QR) == Result_MessageBox_Post.OK)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool End()
        {
            if (bRun)
            {
                if (m_Form_FURS_WEB_check_invoice != null)
                {
                    if (m_Form_FURS_WEB_check_invoice.IsDisposed)
                    {
                        m_Form_FURS_WEB_check_invoice = null;
                    }
                    else
                    {
                        m_Form_FURS_WEB_check_invoice.Close();
                        m_Form_FURS_WEB_check_invoice.Dispose();
                        m_Form_FURS_WEB_check_invoice = null;
                    }
                }
                bRun = false;
                timer_MessagePump.Enabled = false;
                thread_fvi.End(message_box);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Result_MessageBox_Post Send_SingleInvoice(bool bSendSalesBookInvoice, string xml, Control ParentForm, ref string UniqeMsgID, ref string UniqueInvID, ref string barcode_value, ref Image Image_QR)
        {
            for (;;)
            {
                LastMessageID++;
                Thread_FVI_Message msg = new Thread_FVI_Message(LastMessageID, Thread_FVI_Message.eMessage.POST_SINGLE_INVOICE, xml);
                FormFURSCommunication = new FormFURSCommunication(this, msg);
                DialogResult dlgRes = FormFURSCommunication.ShowDialog();
                if (dlgRes == DialogResult.OK)
                {
                    UniqeMsgID = FormFURSCommunication.ProtectedID;
                    UniqueInvID = FormFURSCommunication.UniqueInvoiceID;
                    barcode_value = FormFURSCommunication.BarCodeValue;
                    Image_QR = FormFURSCommunication.Image_QRCode;
                    return Result_MessageBox_Post.OK;
                }
                else
                {
                    if (FormFURSCommunication.ErrorMessage.Contains(FormFURSCommunication_ErrorMessage_BUSSINES_PREMISE_NOT_DEFINED))
                    {
                        Form_BussinesPremisse frm_BP = new Form_BussinesPremisse(this, this.FursTESTEnvironment, FormFURSCommunication.ErrorMessage + "\r\n" + lng.s_SignUpYourBussinesBremise.s);
                        if (frm_BP.ShowDialog(this.m_usrc_FVI_SLO) == DialogResult.OK)
                        {
                            if (frm_BP.FURS_BussinesPremiseData_SignedUp)
                            {
                                continue;
                            }
                        }
                    }

                    UniqeMsgID = FormFURSCommunication.ProtectedID;
                    UniqueInvID = FormFURSCommunication.UniqueInvoiceID;
                    barcode_value = FormFURSCommunication.BarCodeValue;
                    Image_QR = FormFURSCommunication.Image_QRCode;

                    if (bSendSalesBookInvoice)
                    {
                        return Result_MessageBox_Post.ERROR;
                    }
                    else
                    {
                        FormFURSCommunicationERRORhandler frm_com_err_handler = new FormFURSCommunicationERRORhandler(FormFURSCommunication.ErrorMessage);
                        switch (frm_com_err_handler.ShowDialog(m_usrc_FVI_SLO))
                        {
                            case DialogResult.Cancel:
                                return Result_MessageBox_Post.ERROR;
                            case DialogResult.Ignore:
                                return Result_MessageBox_Post.TIMEOUT;
                        }
                    }
                }
            }
        }

        public Result_MessageBox_Post Send_ManyInvoices(long Message_ID, string xml)
        {
            LastMessageID++;
            Thread_FVI_Message msg = new Thread_FVI_Message(LastMessageID, Thread_FVI_Message.eMessage.POST_MANY_INVOICES, xml);
            FormFURSCommunication = new FormFURSCommunication(this, msg);
            if (FormFURSCommunication.ShowDialog() == DialogResult.OK)
            {
                return Result_MessageBox_Post.OK;
            }
            else
            {
                return Result_MessageBox_Post.ERROR;
            }


        }

        public Result_MessageBox_Post Send_PP(string xml)
        {
            LastMessageID++;
            Thread_FVI_Message msg = new Thread_FVI_Message(LastMessageID, Thread_FVI_Message.eMessage.POST_BUSINESSPREMISE, xml);
            FormFURSCommunication = new FormFURSCommunication(this, msg);

            if (FormFURSCommunication.ShowDialog() == DialogResult.OK)
            {
                return Result_MessageBox_Post.OK;
            }
            else
            {
                return Result_MessageBox_Post.ERROR;
            }
        }

        public Result_MessageBox_Post Send_Echo(string xml)
        {
            LastMessageID++;
            Thread_FVI_Message msg = new Thread_FVI_Message(LastMessageID, Thread_FVI_Message.eMessage.POST_ECHO, xml);
            FormFURSCommunication = new FormFURSCommunication(this, msg);

            if (FormFURSCommunication.ShowDialog() == DialogResult.OK)
            {
                return Result_MessageBox_Post.OK;
            }
            else
            {
                return Result_MessageBox_Post.ERROR;
            }
        }



        private void timer_MessagePump_Tick(object sender, EventArgs e)
        {
            switch (message_box.Get(ref message))
            {
                case Result_MessageBox_Get.OK:
                    switch (message.Message)
                    {
                        case FVI_SLO_Message.eMessage.ERROR:
                            if (m_usrc_FVI_SLO != null)
                            {
                                m_usrc_FVI_SLO.btn_FVI.Enabled = true;
                            }
                            bRun = false;
                            LogFile.Error.Show(lng.s_FVI_SLO_Error.s + ":" + message.ErrorMessage);
                            break;

                        case FVI_SLO_Message.eMessage.Thread_FVI_START:
                            if (m_usrc_FVI_SLO != null)
                            {
                                m_usrc_FVI_SLO.btn_FVI.Enabled = true;
                            }
                            break;
                        case FVI_SLO_Message.eMessage.Thread_FVI_END:
                            if (m_usrc_FVI_SLO != null)
                            {
                                m_usrc_FVI_SLO.btn_FVI.Enabled = false;
                            }
                            bRun = false;
                            break;

                        case FVI_SLO_Message.eMessage.FVI_RESPONSE_ECHO:
                            if (FormFURSCommunication != null)
                            {
                                if (FormFURSCommunication.FVI_Response_ECHO(message.Message_ID,
                                                                         message.XML_Data,
                                                                         message.Success,
                                                                         message.MessageType,
                                                                         message.ErrorMessage
                                                                         ))
                                {
                                }
                            }
                            if (m_usrc_FVI_SLO != null)
                            {
                                if (m_usrc_FVI_SLO.frm_main != null)
                                {
                                    if (message.Success == true)
                                    {
                                        m_usrc_FVI_SLO.frm_main.FVI_Response_ECHO(message.Success, message.ErrorMessage);
                                    }
                                }
                            }

                            if (Response_ECHO != null)
                            {
                                Response_ECHO(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case FVI_SLO_Message.eMessage.FVI_RESPONSE_SINGLE_INVOICE:
                            if (FormFURSCommunication != null)
                            {
                                if (FormFURSCommunication.FVI_Response_Single_Invoice(message.Message_ID,
                                                                         message.XML_Data,
                                                                         message.Success,
                                                                         message.MessageType,
                                                                         message.ErrorMessage,
                                                                         message.ProtectedID,
                                                                         message.UniqueInvoiceID,
                                                                         message.BarCodeValue,
                                                                         message.Image_QRCode
                                                                         ))
                                {
                                }
                            }
                            if (Response_SingleInvoice != null)
                            {
                                Response_SingleInvoice(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case FVI_SLO_Message.eMessage.FVI_RESPONSE_MANY_INVOICES:
                            if (FormFURSCommunication != null)
                            {
                                if (FormFURSCommunication.FVI_Response_Many_Invoice(message.Message_ID,
                                                                         message.XML_Data,
                                                                         message.Success,
                                                                         message.MessageType,
                                                                         message.ErrorMessage,
                                                                         message.ProtectedID,
                                                                         message.UniqueInvoiceID,
                                                                         message.Image_QRCode
                                                                         ))
                                {
                                }
                            }

                            if (Response_ManyInvoices != null)
                            {
                                Response_ManyInvoices(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case FVI_SLO_Message.eMessage.FVI_RESPONSE_PP:

                            if (FormFURSCommunication.FVI_Response_PP(message.Message_ID,
                                                                     message.XML_Data,
                                                                     message.Success,
                                                                     message.MessageType,
                                                                     message.ErrorMessage
                                                                     ))
                            {
                            }


                            if (Response_PP != null)
                            {
                                Response_PP(message.Message_ID, message.XML_Data);
                            }
                            break;
                    }
                    break;
                case Result_MessageBox_Get.EMPTY:
                    break;
                case Result_MessageBox_Get.TIMEOUT:
                    break;

            }
        }

        public Image GetQRImage(string uniqInvID)
        {
            return MNet.SLOTaxService.Services.BarCodes.DrawQRCode(Properties.Settings.Default.QRImageWidth, System.Drawing.Imaging.ImageFormat.Png, uniqInvID);
        }

        public void Settings_Reset(Control ctrl_owner)
        {
            if (MessageBox.Show(ctrl_owner, lng.s_DoYouRealyWantToResetSettingsFor_FiscalVerificationOfInvoices.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
            }
        }

        public void LoadSettingsValues(bool TestValues)
        {




        }


        public bool ManageErrors(string errorDesc)
        {
            bool ret = true;

            //  two groups of errors    a. error incorect data   b. communication errors  
            // a no repeat  goto sales book 

            // b try to 


            // S001  Sporočilo ni v skladu s shemo XML / Message is not in compliance with XML schema
            // S003  Digitalni podpis ni ustrezen / Digital signature is not appropriate
            // S004  Identifikator digitalnega potrdila ni ustrezen / Digital certificate identifier is not appropriate
            // S005  Davčna številka v sporočilu ni enaka davčni številki iz digitalnega potrdila / Tax number in the message is not the same as the tax number from the digital certificate
            // S006  Podatki o poslovnem prostoru niso posredovani / Data about business premises are not submitted
            // S007              Digitalno potrdilo je preklicano / Digital certificate is withdrawn
            // S008  Digitalnemu potrdilu je potekla veljavnost / The validity of the digital certificate is expired
            // S100  Sistemska napaka pri obdelavi

            return ret;
        }



    }
}
