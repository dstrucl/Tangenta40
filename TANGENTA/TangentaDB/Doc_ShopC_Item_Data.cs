using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class Doc_ShopC_Item_Data
    {

        internal string t_FirstName = "(*FirstName*)";
        internal string t_LastName = "(*LastName*)";
        internal string t_OfficeName = "(*OfficeName*)";
        internal string t_OfficeShortName = "(*OfficeShortName*)";
        internal string t_PersonImage = "(*PersonImage*)";
        internal string t_Job = "(*Job*)";
        internal string t_DateOfBirth = "(*DateOfBirth*)";
        internal string t_Tax_ID = "(*Tax_ID*)";
        internal string t_Registration_ID = "(*Registration_ID*)";
        internal string t_Street = "(*Street*)";
        internal string t_HouseNumber = "(*HouseNumber*)";
        internal string t_ZIP = "(*ZIP*)";
        internal string t_City = "(*City*)";
        internal string t_Country = "(*Country*)";
        internal string t_UserName = "(*UserName*)";
        internal string t_AccessRight = "(*AccessRight*)";

        private ID m_DocInvoice_ID = null;
        public ID DocInvoice_ID
        {
            get { return m_DocInvoice_ID; }
        }
        private ID m_DocInvoice_ShopC_Item_ID = null;
        public ID DocInvoice_ShopC_Item_ID
        {
            get { return m_DocInvoice_ShopC_Item_ID; }
        }

        private ID m_DocProformaInvoice_ID = null;
        public ID DocProformaInvoice_ID
        {
            get { return m_DocProformaInvoice_ID; }
        }

        private ID m_DocProformaInvoice_ShopC_Item_ID = null;
        public ID DocProformaInvoice_ShopC_Item_ID
        {
            get { return m_DocProformaInvoice_ShopC_Item_ID; }
        }

        public Doc_ShopC_Item_Data(ID xDocInvoice_ID, ID xDocInvoice_ShopC_Item_ID, ID xDocProformaInvoice_ID, ID xDocProformaInvoice_ShopC_Item_ID)
        {
            this.m_DocInvoice_ID = xDocInvoice_ID;
            this.m_DocInvoice_ShopC_Item_ID = xDocInvoice_ShopC_Item_ID;
            this.m_DocProformaInvoice_ID = xDocProformaInvoice_ID;
            this.m_DocProformaInvoice_ShopC_Item_ID = xDocProformaInvoice_ShopC_Item_ID;
        }

        internal string GetHtml()
        {
            int iLanguage = LanguageControl.DynSettings.LanguageID;
            foreach (HtmlTemplate ht in TemplatesLoader.Templates)
            {
                if (iLanguage == 0)
                {
                    if (ht.Name.Equals("00_ENG_Doc_ShopC_Item_Data"))
                    {
                        return FillData(ht.Html);
                    }
                }
                else if (iLanguage == 1)
                {
                    if (ht.Name.Equals("01_SLO_Doc_ShopC_Item_Data"))
                    {
                        return FillData(ht.Html);
                    }
                }
                else
                {
                    return "<p>ERROR:LoginControl:AWPLoginData:GetHtml:Language index = " + iLanguage.ToString() + " not implemented!</p>";
                }
            }
            return "<p>ERROR:LoginControl:AWPLoginData:GetHtml:Template not found!</p>";
        }

        private string FillData(string html)
        {
            StringBuilder sb = new StringBuilder(html);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_FirstName, ref myOrganisation_Person__per__cfn_FirstName);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_LastName, ref myOrganisation_Person__per__cln_LastName);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_OfficeName, ref myOrganisation_Person__office_Name);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_OfficeShortName, ref myOrganisation_Person__office_ShortName);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_OfficeName, ref myOrganisation_Person__office_ShortName);
            bool bHasImage = false;
            if (PersonData__perimg_Image_Data is byte[])
            {
                if (PersonData__perimg_Image_Data != null)
                {
                    string sBase64image = Convert.ToBase64String(PersonData__perimg_Image_Data);
                    sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_PersonImage, ref sBase64image);
                    bHasImage = true;
                }
            }
            if (!bHasImage)
            {
                string t = "<img width=\"128\" height=\"156\" src=\"data:image/png;base64,(*PersonImage*)\">";
                string s = "";
                sb = TangentaDB.TemplatesLoader.Replace(sb, ref t, ref s);
            }

            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_Job, ref myOrganisation_Person_Job);
            string sDate = null;
            if (myOrganisation_Person__per_DateOfBirth != null)
            {
                if (LanguageControl.DynSettings.LanguageID == LanguageControl.DynSettings.Slovensko_ID)
                {
                    sDate = myOrganisation_Person__per_DateOfBirth.ToString("d", CultureInfo.CreateSpecificCulture("sl-SI"));
                }
                else
                {
                    sDate = myOrganisation_Person__per_DateOfBirth.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
                }
                if (sDate != null)
                {
                    sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_DateOfBirth, ref sDate);
                }
            }
            if (sDate == null)
            {
                string r = "";
                sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_DateOfBirth, ref r);
            }
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_Tax_ID, ref myOrganisation_Person__per_Tax_ID);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_Registration_ID, ref myOrganisation_Person__per_Registration_ID);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_Street, ref PersonData__cadrper__cstrnper_StreetName);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_HouseNumber, ref PersonData__cadrper__chounper_HouseNumber);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_ZIP, ref PersonData__cadrper__zipper_ZIP);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_City, ref PersonData__cadrper__ccitper_City);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_Country, ref PersonData__cadrper__cstper_Country);
            sb = TangentaDB.TemplatesLoader.Replace(sb, ref t_UserName, ref UserName);
            return sb.ToString();
        }

    }
}
