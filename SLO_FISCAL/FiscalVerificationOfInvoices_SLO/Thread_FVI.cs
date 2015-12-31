using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MNet.SLOTaxService.Services;
using System.IO;
using System.Xml;

using MNet.SLOTaxService;
using MNet.SLOTaxService.Messages;

namespace FiscalVerificationOfInvoices_SLO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class Thread_FVI
    {
        internal bool bEnd = false;
        public Thread_FVI_MessageBox message_box = null;

        private Settings FiscalSettings = null;
        private TaxService taxService = null;

        private System.Threading.Thread FVI_Thread;

        private void Run(object ousrc_FVI_SLO_MessageBox )
        {
            usrc_FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox = (usrc_FVI_SLO_MessageBox)ousrc_FVI_SLO_MessageBox;
            Thread_FVI_Message fvi_message = new Thread_FVI_Message(0,Thread_FVI_Message.eMessage.NONE,null);
            usrc_FVI_SLO_Message xusrc_FVI_SLO_Message = new usrc_FVI_SLO_Message(0,usrc_FVI_SLO_Message.eMessage.Thread_FVI_START, null);
            xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
            for (;;)
            {
                switch (message_box.Get(ref fvi_message))
                {
                    case Result_MessageBox_Get.OK:
                        switch (fvi_message.Message)
                        {
                            case Thread_FVI_Message.eMessage.POST_ECHO:
                            case Thread_FVI_Message.eMessage.POST_SINGLE_INVOICE:
                            case Thread_FVI_Message.eMessage.POST_BUSINESSPREMISE:

                                ReturnValue rv= taxService.Send(fvi_message.XML_Data);  //LK  po moje bi bilo dobr definirat kaj se rabi in se to poslje in ne vse 

                                string xml = prettyXml(rv.MessageReceivedFromFurs);
    
                                xusrc_FVI_SLO_Message.Set(fvi_message.Message_ID, usrc_FVI_SLO_Message.eMessage.FVI_RESPONSE_ECHO, xml);
                                xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
                                return;

                 

                            case Thread_FVI_Message.eMessage.POST_MANY_INVOICES:
                                break;

                            case Thread_FVI_Message.eMessage.END:
                                xusrc_FVI_SLO_Message.Set(0,usrc_FVI_SLO_Message.eMessage.Thread_FVI_END, null);
                                xusrc_FVI_SLO_MessageBox.Post(xusrc_FVI_SLO_Message);
                                return;
                        }
                        break;
                    case Result_MessageBox_Get.TIMEOUT:
                        break;
                }
            }
        }

        public bool End(usrc_FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox)
        {

            FiscalSettings = null;
            taxService = null;

            usrc_FVI_SLO_Message xusrc_FVI_SLO_Message_END = new usrc_FVI_SLO_Message(0,usrc_FVI_SLO_Message.eMessage.NONE, null);
            Thread_FVI_Message fvi_message_END = new Thread_FVI_Message(0,Thread_FVI_Message.eMessage.END, null);
            message_box.Post(fvi_message_END);
            long StartTicks = DateTime.Now.Ticks;
            for (;;)
            {
                if (xusrc_FVI_SLO_MessageBox.Get(ref xusrc_FVI_SLO_Message_END)== Result_MessageBox_Get.OK)
                { 
                    if (xusrc_FVI_SLO_Message_END.Message == usrc_FVI_SLO_Message.eMessage.Thread_FVI_END)
                    {
                        return true;
                    }
                }
                if ((DateTime.Now.Ticks- StartTicks)>100000000)
                {
                    return false;
                }
            }
        }


        public void Start(usrc_FVI_SLO_MessageBox xusrc_FVI_SLO_MessageBox,int message_box_length, string certificateFileName, string CertPass, string fursWebServiceURL, string fursXmlNamespace, int timeOutInSec, ref string ErrReason)
        {

            message_box = new Thread_FVI_MessageBox(message_box_length);
            FVI_Thread = new System.Threading.Thread(Run);
            FVI_Thread.SetApartmentState(ApartmentState.STA);
            FVI_Thread.Start(xusrc_FVI_SLO_MessageBox);

            try
            {
                X509Certificate2 certificate = GetCertFromFile(certificateFileName, CertPass);
                FiscalSettings = Settings.Create(certificate, fursWebServiceURL, fursXmlNamespace, timeOutInSec);
                taxService = TaxService.Create(FiscalSettings);  //create service with settings
                ErrReason= "";

            }
            catch (Exception ex)
            {
                ErrReason = ex.Message;
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
