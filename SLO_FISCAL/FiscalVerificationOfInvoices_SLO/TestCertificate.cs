using LanguageControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiscalVerificationOfInvoices_SLO
{
    public static class TestCertificate
    {
        public static string TestCertName = "10286853-1.p12";
        public static string TestCertPath = null;
        private static string Certificate = @"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
BBRcHGW4NPpzQ7I9OIz4hopjurrM6AICBAA=";

        public static bool Save(ref string CertificateFullPath)
        {
            try
            {
                byte[] u8_Data = Convert.FromBase64String(Certificate);
                if (CertificateFullPath == null)
                {
                    string CertificatePath = System.Windows.Forms.Application.StartupPath;

                    if (CertificatePath[CertificatePath.Length - 1] != '\\')
                    {
                        CertificateFullPath = CertificatePath + '\\' + TestCertName;
                    }
                    else
                    {
                        CertificateFullPath = CertificatePath + TestCertName;
                    }
                }
                File.WriteAllBytes(CertificateFullPath, u8_Data);
                TestCertPath = CertificateFullPath;
                return true;
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:SLO_FISCAL:TestCertificate:Save:Error File.WriteAllBytes  to " + CertificateFullPath + "\r\nExcpetion=" + Ex.Message);
                return false;
            }
        }

        public static bool Compare(string CertificateFullPath)
        {

            try
            {
                byte[] u8_Data = Convert.FromBase64String(Certificate);
                byte[] CertificateData = File.ReadAllBytes(CertificateFullPath);
                int iCount = u8_Data.Length;
                if (iCount == CertificateData.Length)
                {
                    for (int i=0;i<iCount;i++)
                    {
                        if (u8_Data[i]!= CertificateData[i])
                        {
                            MessageBox.Show(lngRPM.s_CertificateNotEqualToBuiltInTestCertificate.s);
                            return false;
                        }
                    }
                    MessageBox.Show(lngRPM.s_CertificateIsEqualToBuiltInTestCertificate.s);
                }
                else
                {
                    MessageBox.Show(lngRPM.s_CertificateNotEqualToBuiltInTestCertificate.s +"\r\n "+ lngRPM.ss_Length.s + ":" + iCount.ToString() + "!=" + CertificateData.Length.ToString());
                    return false;
                }
                TestCertPath = CertificateFullPath;
                return true;
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:SLO_FISCAL:TestCertificate:Save:Error File.WriteAllBytes  to " + CertificateFullPath + "\r\nExcpetion=" + Ex.Message);
                return false;
            }
        }
    }
}
