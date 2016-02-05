﻿using LanguageControl;
using System;
using System.Drawing;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Windows.Forms;




namespace FiscalVerificationOfInvoices_SLO
{
    public partial class usrc_FVI_SLO : UserControl
    {


        #region Declaration

        public bool DEBUG = false;
        public int timeOutInSec = 0;

        private FormFURSCommunication FormFURSCommunication = null;
        private Form_MainFiscal frm_main = null;

        public delegate void delegate_Response_SingleInvoice(long Message_ID, string xml);
        public delegate void delegate_Response_ManyInvoices(long Message_ID, string xml);
        public delegate void delegate_Response_PP(long Message_ID, string xml);
        public delegate void delegate_Response_ECHO(long Message_ID, string xml);

        public event delegate_Response_SingleInvoice Response_SingleInvoice = null;
        public event delegate_Response_ManyInvoices Response_ManyInvoices = null;
        public event delegate_Response_PP Response_PP = null;
        public event delegate_Response_ECHO Response_ECHO = null;

        private bool bRun = false;
        internal usrc_FVI_SLO_MessageBox message_box = null;

        internal Thread_FVI thread_fvi = new Thread_FVI();

        private usrc_FVI_SLO_Message message = new usrc_FVI_SLO_Message(0, usrc_FVI_SLO_Message.eMessage.NONE, null);

        private int m_message_box_length = 100;
        private long LastMessageID = 0;


        #endregion

        #region Properties

        public bool   FursTESTEnvironment
        {
                 get { return Properties.Settings.Default.fursTEST_Environment; }
        }

        public string FursCertificateFileName { get; set; }
        public string FursCertificatePassword { get; set; }
        public string FursWebServiceURL { get; set; }
        public string FursXmlNamespace { get; set; }
        public string FursD_BuildingNumber { get; set; }
        public string FursD_BuildingSectionNumber { get; set; }
        public string FursD_Community { get; set; }
        public string FursD_CadastralNumber { get; set; }
        public DateTime FursD_ValidityDate { get; set; }
        public string FursD_ClosingTag { get; set; }
        public string FursD_SoftwareSupplierTaxID { get; set; }
        public string FursD_PremiseType { get; set; }
        public string FursD_MyOrgTaxID { get; set; }
        public string FursD_BussinesPremiseID { get; set; }
        public string FursD_InvoiceAuthorTaxID { get; set; }



        public int MessageBox_Length
        {
            get { return m_message_box_length; }
            set { m_message_box_length = value; }
        }


        #endregion

        #region Metods
        public usrc_FVI_SLO()
        {
            InitializeComponent();
            btn_FVI.Enabled = false;
            LoadSettingsValues(FursTESTEnvironment);
            
        }

        private void usrc_FVI_SLO_Load(object sender, EventArgs e)
        {
        }

        public bool Start(string xcertificateFileName, string xCertPass, string xfursWebServiceURL, string xfursXmlNamespace, int xtimeOutInSec, Control ParentForm, ref string ErrReason)
        {
            if (!bRun)
            {
                message_box = new usrc_FVI_SLO_MessageBox(MessageBox_Length);
                thread_fvi.Start(message_box, MessageBox_Length,FursTESTEnvironment,  xcertificateFileName, xCertPass, xfursWebServiceURL, xfursXmlNamespace, xtimeOutInSec, ref ErrReason);
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

        public void Write_SalesBookInvoice(long Invoice_ID, int FiscalYear, int InvoiceNumber,ref string xSerialNumber,ref string xSetNumber,ref string xInvoiceNumber)
        {
          Form_EnterData_to_SalesBookInvoice fsb = new Form_EnterData_to_SalesBookInvoice(Invoice_ID, FiscalYear, InvoiceNumber, null, null, null, Form_EnterData_to_SalesBookInvoice.eMode.WRITE);
            fsb.ShowDialog();
            xSerialNumber = fsb.SerialNumber;
            xSetNumber = fsb.SetNumber;
            xInvoiceNumber = fsb.InvoiceNumber;

        }

        public void Update_SalesBookInvoice(long Invoice_ID, int FiscalYear, int InvoiceNumber, ref string xSerialNumber, ref string xSetNumber, ref string xInvoiceNumber)
        {
          Form_EnterData_to_SalesBookInvoice fsb = new Form_EnterData_to_SalesBookInvoice(Invoice_ID, FiscalYear, InvoiceNumber, xSerialNumber, xSetNumber, xInvoiceNumber, Form_EnterData_to_SalesBookInvoice.eMode.WRITE);
          fsb.ShowDialog();
          xSerialNumber = fsb.SerialNumber;
          xSetNumber = fsb.SetNumber;
          xInvoiceNumber = fsb.InvoiceNumber;
        }

        public bool Start(ref string ErrReason)
        {
            if (!bRun)
            {
                message_box = new usrc_FVI_SLO_MessageBox(MessageBox_Length);
                DialogResult dlgResult = DialogResult.None;
                while (dlgResult != DialogResult.Cancel)
                {
                    DEBUG = Properties.Settings.Default.DEBUG;
                    timeOutInSec = Properties.Settings.Default.timeOutInSec;
                    if (thread_fvi.Start(message_box, MessageBox_Length,FursTESTEnvironment, FursCertificateFileName, FursCertificatePassword, FursWebServiceURL, FursXmlNamespace, timeOutInSec, ref ErrReason))
                    {
                        timer_MessagePump.Enabled = true;
                        bRun = true;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(ErrReason);
                        Form_Settings fvi_settings = new Form_Settings(this);
                        dlgResult = fvi_settings.ShowDialog();
                    }
                }
                return false;
            }
            else
            {
                ErrReason = "0 Not run";
                return false;
            }
        }

        public bool End()
        {
            if (bRun)
            {
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

        public Result_MessageBox_Post Send_SingleInvoice(string xml, Control ParentForm, ref string UniqeMsgID, ref string UniqueInvID, ref string barcode_value, ref Image Image_QR)
        {
            LastMessageID++;
            Thread_FVI_Message msg = new Thread_FVI_Message(LastMessageID, Thread_FVI_Message.eMessage.POST_SINGLE_INVOICE, xml);
            FormFURSCommunication = new FormFURSCommunication(this, msg);
            if (FormFURSCommunication.ShowDialog()== DialogResult.OK)
            {
                UniqeMsgID = FormFURSCommunication.ProtectedID;
                UniqueInvID = FormFURSCommunication.UniqueInvoiceID;
                barcode_value = FormFURSCommunication.BarCodeValue;
                Image_QR = FormFURSCommunication.Image_QRCode;
                return Result_MessageBox_Post.OK;
            }
            else
            {
                return Result_MessageBox_Post.ERROR;
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
                        case usrc_FVI_SLO_Message.eMessage.ERROR:
                            btn_FVI.Enabled = true;
                            bRun = false;
                            LogFile.Error.Show(message.ErrorMessage);
                            break;

                        case usrc_FVI_SLO_Message.eMessage.Thread_FVI_START:
                            btn_FVI.Enabled = true;
                            break;
                        case usrc_FVI_SLO_Message.eMessage.Thread_FVI_END:
                            btn_FVI.Enabled = false;
                            bRun = false;
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_ECHO:
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
                            if (frm_main != null)
                            {
                                if (message.Success == true)
                                {
                                    frm_main.FVI_Response_ECHO(message.Success, message.ErrorMessage);



    }


                            }

                            if (Response_ECHO!=null)
                            {
                                Response_ECHO(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_SINGLE_INVOICE:
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
                            if (Response_SingleInvoice!=null)
                            {
                                Response_SingleInvoice(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_MANY_INVOICES:
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

                            if (Response_ManyInvoices!=null)
                            {
                                Response_ManyInvoices(message.Message_ID, message.XML_Data);
                            }
                            break;

                        case usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_PP:

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

        private void btn_FVI_Click(object sender, EventArgs e)
        {

            frm_main = new Form_MainFiscal(this);
            frm_main.ShowDialog(this);

            frm_main = null;
        }

        public void Settings_Reset(Control ctrl_owner)
        {
            if (MessageBox.Show(ctrl_owner, lngRPM.s_DoYouRealyWantToResetSettingsFor_FiscalVerificationOfInvoices.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
            }
        }

        public void LoadSettingsValues(bool TestValues)
        {

            if (TestValues)
            {
                FursCertificateFileName = Properties.Settings.Default.furscertificateFileName_TEST;
                FursCertificatePassword= Properties.Settings.Default.fursCertPass_TEST;
                FursWebServiceURL= Properties.Settings.Default.fursWebServiceURL_TEST;
                FursXmlNamespace= Properties.Settings.Default.fursXmlNamespace_TEST;
                FursD_BuildingNumber= Properties.Settings.Default.fursD_BuildingNumber_TEST;
                FursD_BuildingSectionNumber=Properties.Settings.Default.fursD_BuildingSectionNumber_TEST;
                FursD_Community = Properties.Settings.Default.fursD_Community_TEST;
                FursD_CadastralNumber= Properties.Settings.Default.fursD_CadastralNumber_TEST;
                FursD_ValidityDate= Properties.Settings.Default.fursD_ValidityDate_TEST;
                FursD_ClosingTag= Properties.Settings.Default.fursD_ClosingTag_TEST;
                FursD_SoftwareSupplierTaxID= Properties.Settings.Default.fursD_SoftwareSupplierTaxID_TEST;
                FursD_PremiseType= Properties.Settings.Default.fursD_SoftwareSupplierTaxID_TEST;
                FursD_MyOrgTaxID= Properties.Settings.Default.fursD_MyOrgTaxID_TEST;
                FursD_BussinesPremiseID = Properties.Settings.Default.fursD_BussinesPremiseID_TEST;
                FursD_InvoiceAuthorTaxID= Properties.Settings.Default.fursD_InvoiceAuthorTaxID_TEST;

            }
            else
            {
                FursCertificateFileName = Properties.Settings.Default.furscertificateFileName;
                FursCertificatePassword = Properties.Settings.Default.fursCertPass;
                FursWebServiceURL = Properties.Settings.Default.fursWebServiceURL;
                FursXmlNamespace = Properties.Settings.Default.fursXmlNamespace;
                FursD_BuildingNumber = Properties.Settings.Default.fursD_BuildingNumber;
                FursD_BuildingSectionNumber = Properties.Settings.Default.fursD_BuildingSectionNumber;
                FursD_Community = Properties.Settings.Default.fursD_Community;
                FursD_CadastralNumber = Properties.Settings.Default.fursD_CadastralNumber;
                FursD_ValidityDate = Properties.Settings.Default.fursD_ValidityDate;
                FursD_ClosingTag = Properties.Settings.Default.fursD_ClosingTag;
                FursD_SoftwareSupplierTaxID = Properties.Settings.Default.fursD_SoftwareSupplierTaxID;
                FursD_PremiseType = Properties.Settings.Default.fursD_SoftwareSupplierTaxID;
                FursD_MyOrgTaxID = Properties.Settings.Default.fursD_MyOrgTaxID;
                FursD_BussinesPremiseID = Properties.Settings.Default.fursD_BussinesPremiseID;
                FursD_InvoiceAuthorTaxID = Properties.Settings.Default.fursD_InvoiceAuthorTaxID;
            }



        }


        public bool ManageErrors(string errorDesc)
        {
            bool ret = true;

            //  two groups of errors    a. error incorect data   b. communication errors  
             // a no repeat  goto sales book 

           // b try to 




            return ret;
        }

        #endregion

    }
}
