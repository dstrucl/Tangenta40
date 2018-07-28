#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System.Security.Cryptography.X509Certificates;
using MNet.SLOTaxService.Services;
using System.IO;
using System.Xml;
using MNet.SLOTaxService;
using MNet.SLOTaxService.Messages;
using LanguageControl;
using System;
using System.Drawing;
using System.Text;
using System.Threading;

namespace FiscalVerificationOfInvoices_SLO
{
    public class Thread_FVI
    {
        internal bool bEnd = false;
        public Thread_FVI_MessageBox message_box = null;
        private Settings FiscalSettings = null;
        private TaxService taxService = null;
        private System.Threading.Thread FVI_Thread;

        public class ThreadData
        {
            public bool fursTESTEnvironment = false;
            public string certificateFileName = null;
            public string CertPass = null;
            public string fursWebServiceURL = null;
            public string fursXmlNamespace = null;
            public int timeOutInSec = 0;
            public FVI_SLO_MessageBox m_usrc_FVI_SLO_MessageBox = null;

            public ThreadData(bool xfursTESTEnvironment,string xcertificateFileName, string xCertPass, string xfursWebServiceURL, string xfursXmlNamespace, int xtimeOutInSec, FVI_SLO_MessageBox x_usrc_FVI_SLO_MessageBox)
            {
                fursTESTEnvironment = xfursTESTEnvironment;
                certificateFileName = xcertificateFileName;
                CertPass = xCertPass;
                fursWebServiceURL = xfursWebServiceURL;
                fursXmlNamespace = xfursXmlNamespace;
                timeOutInSec = xtimeOutInSec;
                m_usrc_FVI_SLO_MessageBox = x_usrc_FVI_SLO_MessageBox;
            }
        }


        private void Run(object othdata)
        {

            ThreadData thdata = (ThreadData)othdata;
            FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox = thdata.m_usrc_FVI_SLO_MessageBox;
            Thread_FVI_Message fvi_message = new Thread_FVI_Message(0,Thread_FVI_Message.eMessage.NONE,null);
            usrc_FVI_SLO_Message xusrc_FVI_SLO_Message = new usrc_FVI_SLO_Message(0,usrc_FVI_SLO_Message.eMessage.Thread_FVI_START, null);
            xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);

            try
            {
                if (File.Exists(thdata.certificateFileName))
                {
                    X509Certificate2 certificate = GetCertFromFile(thdata.certificateFileName, thdata.CertPass);
                    FiscalSettings = Settings.Create(certificate, thdata.fursWebServiceURL, thdata.fursXmlNamespace, thdata.timeOutInSec);
                    taxService = TaxService.Create(FiscalSettings);  //create service with settings
                }
                else
                {
                    xusrc_FVI_SLO_Message.Set(fvi_message.Message_ID, usrc_FVI_SLO_Message.eMessage.ERROR,null, lng.sFileDoesNotExist.s + ":" + thdata.certificateFileName,MessageType.Unknown,null,false,null,null,null);
                    xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
                    return;
                }
            }
            catch (Exception ex)
            {
                xusrc_FVI_SLO_Message.Set(fvi_message.Message_ID, usrc_FVI_SLO_Message.eMessage.ERROR, null, ex.Message, MessageType.Unknown, null, false, null, null, null);
                xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
                return;
            }

            for (;;)
            {
                ReturnValue rv = null;
                string xml_returned = null;
                switch (message_box.Get(ref fvi_message))
                {
                    case Result_MessageBox_Get.OK:
                        switch (fvi_message.Message)
                        {

                            case Thread_FVI_Message.eMessage.POST_ECHO:
                                rv = taxService.Send(fvi_message.XML_Data);  
                                xml_returned = prettyXml(rv.OriginalMessage);
                                xusrc_FVI_SLO_Message.Set(fvi_message.Message_ID, usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_ECHO, xml_returned);
                                xusrc_FVI_SLO_Message.Success = rv.Success;
                                xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
                                break;

                            case Thread_FVI_Message.eMessage.POST_SINGLE_INVOICE:
                                rv = taxService.Send(fvi_message.XML_Data);  
                                xml_returned = prettyXml(rv.OriginalMessage);
                                if (rv.BarCodes!=null)
                                {
                                    string BarCodeValue = rv.BarCodes.BarCodeValue;
                                    if (BarCodeValue != null)
                                    {
                                        Image img_QRCode = rv.BarCodes.DrawQRCode(Properties.Settings.Default.QRImageWidth, System.Drawing.Imaging.ImageFormat.Png);
                                        xusrc_FVI_SLO_Message.Set(fvi_message.Message_ID, usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_SINGLE_INVOICE,
                                                                  xml_returned,
                                                                  rv.ErrorMessage,
                                                                  rv.MessageType,
                                                                  rv.ProtectedID,
                                                                  rv.Success,
                                                                  rv.UniqueInvoiceID,
                                                                  BarCodeValue,
                                                                  img_QRCode);

                                    }
                                    else
                                    {
                                        xusrc_FVI_SLO_Message.Set(fvi_message.Message_ID, usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_SINGLE_INVOICE,
                                                                 xml_returned,
                                                                 rv.ErrorMessage,
                                                                 rv.MessageType,
                                                                 rv.ProtectedID,
                                                                 rv.Success,
                                                                 rv.UniqueInvoiceID,
                                                                 null,
                                                                 null);
                                    }
                                }
                                else
                                {
                                    xusrc_FVI_SLO_Message.Set(fvi_message.Message_ID, usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_SINGLE_INVOICE,
                                                                xml_returned,
                                                                rv.ErrorMessage,
                                                                rv.MessageType,
                                                                rv.ProtectedID,
                                                                rv.Success,
                                                                rv.UniqueInvoiceID,
                                                                null,
                                                                null);
                                }                          
                                
                                xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
                                break;

                            case Thread_FVI_Message.eMessage.POST_BUSINESSPREMISE:
                                rv = taxService.Send(fvi_message.XML_Data);  
                                xml_returned = prettyXml(rv.OriginalMessage);
                                xusrc_FVI_SLO_Message.Set(fvi_message.Message_ID, usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_PP, xml_returned);
                                xusrc_FVI_SLO_Message.Success = rv.Success;
                                xusrc_FVI_SLO_Message.ErrorMessage  = rv.ErrorMessage;
                                xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
                                break;

                            case Thread_FVI_Message.eMessage.POST_MANY_INVOICES:
                                rv = taxService.Send(fvi_message.XML_Data);   
                                xml_returned = prettyXml(rv.OriginalMessage);
                                xusrc_FVI_SLO_Message.Set(fvi_message.Message_ID, usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_SINGLE_INVOICE, xml_returned);
                                xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
                                break;

                            case Thread_FVI_Message.eMessage.END:
                                if (xusrc_FVI_SLO_Message != null)
                                {
                                    xusrc_FVI_SLO_Message.Set(0, usrc_FVI_SLO_Message.eMessage.Thread_FVI_END, null);
                                    xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
                                }
                                return;
                        }
                        break;
                    case Result_MessageBox_Get.TIMEOUT:
                        break;
                }
                Thread.Sleep(100); //Must be called to avoid CPU time consumption!
                Thread.Yield();
            }
        }


        public bool End(FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox)
        {
            FiscalSettings = null;
            taxService = null;

            usrc_FVI_SLO_Message xusrc_FVI_SLO_Message_END = new usrc_FVI_SLO_Message(0,usrc_FVI_SLO_Message.eMessage.NONE, null);
            Thread_FVI_Message fvi_message_END = new Thread_FVI_Message(0,Thread_FVI_Message.eMessage.END, null);
            message_box.Post(fvi_message_END);
            long StartTicks = DateTime.Now.Ticks;

            for (;;)
            {
                if (xusrc_FVI_SLO_MessageBox != null)
                {
                    if (xusrc_FVI_SLO_MessageBox.Get(ref xusrc_FVI_SLO_Message_END) == Result_MessageBox_Get.OK)
                    {
                        if (xusrc_FVI_SLO_Message_END.Message == usrc_FVI_SLO_Message.eMessage.Thread_FVI_END)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    //Ocurs when crash and catch in Program.Main!
                    return true;
                }
                if ((DateTime.Now.Ticks- StartTicks)>100000000)
                {
                    return false;
                }
            }
        }


        public bool Start(FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox,int message_box_length,bool fursTESTEnvironment, string certificateFileName, string CertPass, string fursWebServiceURL, string fursXmlNamespace, int timeOutInSec, ref string ErrReason)
        {
            try
            {
                ThreadData thdata = new ThreadData(fursTESTEnvironment,certificateFileName, CertPass, fursWebServiceURL, fursXmlNamespace, timeOutInSec, xusrc_FVI_SLO_MessageBox);
                message_box = new Thread_FVI_MessageBox(message_box_length);
                FVI_Thread = new System.Threading.Thread(Run);
                FVI_Thread.SetApartmentState(ApartmentState.STA);
                FVI_Thread.Start(thdata);
                return true;
            }
            catch (Exception ex)
            {
                ErrReason = ex.Message;
                return false;
            }
        }


        public X509Certificate2 GetCertFromFile(string certificateFile, string password)
        {
            if (!File.Exists(certificateFile))
                throw new Exception("Ne najdem digitalnega potrdila / Can't find certificate");  //TODO: Lang

            return new X509Certificate2(certificateFile, password);
        }

        private string prettyXml(XmlDocument xmlDoc)
        {
            var stringBuilder = new StringBuilder();

            if (xmlDoc != null)
            {
                var settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = false;
                settings.Indent = true;
                settings.NewLineOnAttributes = true;

              
                using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
                {
                    xmlDoc.Save(xmlWriter);
                }
            }
            return stringBuilder.ToString();
        }


    }
}
