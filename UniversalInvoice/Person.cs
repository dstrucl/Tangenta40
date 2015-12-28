using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalInvoice
{
    public class Person
    {
        public bool Gender = false;
        public string FirstName = null;
        public string LastName = null;
        public DateTime DateOfBirth = DateTime.MinValue;
        public string Tax_ID = null;
        public string Registration_ID = null;
        public string MobilePhoneNumber = null;
        public string PhoneNumber = null;
        public string Email = null;
        public string CardNumber = null;
        public string CardType = null;
        public byte[] PersonImage = null;
        Address Address = null;

        public TemplateToken tGender;
        public TemplateToken tFirstName;
        public TemplateToken tLastName;
        public TemplateToken tDateOfBirth;
        public TemplateToken tTaxID;
        public TemplateToken tRegistration_ID;
        public TemplateToken tMobilePhoneNumber;
        public TemplateToken tPhoneNumber;
        public TemplateToken tEmail;
        public TemplateToken tCardNumber;
        public TemplateToken tCardType;


        public Person(ltext token_prefix,
                        bool _Gender,
                        string _FirstName,
                        string _LastName,
                        DateTime _DateOfBirth,
                        string _Tax_ID,
                        string _Registration_ID,
                        string _MobilePhoneNumber,
                        string _PhoneNumber,
                        string _Email,
                        string _CardNumber,
                        string _CardType,
                        byte[] _PersonImage,
                        string _StreetName,
                        string _HouseNumber,
                        string _ZIP,
                        string _City,
                        string _State,
                        string _Country
                        )
        {
            Gender = _Gender;
            FirstName = _FirstName;
            LastName = _LastName;
            DateOfBirth = _DateOfBirth;
            Tax_ID = _Tax_ID;
            Registration_ID = _Registration_ID;
            MobilePhoneNumber = _MobilePhoneNumber;
            PhoneNumber = _PhoneNumber;
            Email = _Email;
            CardNumber = _CardNumber;
            CardType = _CardType;
            PersonImage = _PersonImage;
            ltext token_prefix_Address = new ltext(token_prefix.sText[0] + "_Person", token_prefix.sText[0] + "_Oseba");
            Address = new Address(token_prefix_Address,_StreetName,
                                           _HouseNumber,
                                           _ZIP,
                                           _City,
                                           _State,
                                           _Country);

            tGender = new TemplateToken(token_prefix, new string[] { "@@_Gender", "@@_Spol" }, DBTypes.func.GenderAsString(Gender));
            tFirstName = new TemplateToken(token_prefix, new string[] { "@@_FirstName", "@@_Ime" }, FirstName);
            tLastName = new TemplateToken(token_prefix, new string[] { "@@_LastName", "@@_Priimek" }, LastName);
            tDateOfBirth = new TemplateToken(token_prefix, new string[] { "@@_DateOfBirth", "@@_DatumRojstva" },DBTypes.func.Get_DATE_dd_mm_yyyy(DateOfBirth));
            tTaxID = new TemplateToken(token_prefix, new string[] { "@@_Tax_ID", "@@_DavčnaŠtevilka" }, Tax_ID);
            tRegistration_ID = new TemplateToken(token_prefix, new string[] { "@@_tRegistration_ID", "@@_MatičnaŠtevilka" }, Registration_ID);
            tMobilePhoneNumber = new TemplateToken(token_prefix, new string[] { "@@_MobilePhoneNumber", "@@_MobilniTelefonŠtevilka" }, MobilePhoneNumber);
            tPhoneNumber = new TemplateToken(token_prefix, new string[] { "@@_PhoneNumber", "@@_TelefonskaŠtevilka" }, PhoneNumber);
            tEmail = new TemplateToken(token_prefix, new string[] { "@@_Email", "@@_Email" }, Email);
            tCardNumber = new TemplateToken(token_prefix, new string[] { "@@_CardNumber", "@@_ŠtevilkaKartice" }, CardNumber);
            tCardType = new TemplateToken(token_prefix, new string[] { "@@_CardType", "@@_VrstaKartice" }, CardType);

    }
}
}
