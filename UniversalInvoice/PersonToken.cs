using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalInvoice
{
    public class PersonToken
    {
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

        public List<TemplateToken> list = null;

        public PersonToken(ltext token_prefix,
                                bool Gender,
                                string FirstName,
                                string LastName,
                                DateTime DateOfBirth,
                                string Tax_ID,
                                string Registration_ID,
                                string MobilePhoneNumber,
                                string PhoneNumber,
                                string Email,
                                string CardNumber,
                                string CardType)

        {
            tGender = new TemplateToken(token_prefix, new string[] { "Gender", "Spol" }, DBTypes.func.GenderAsString(Gender));
            tFirstName = new TemplateToken(token_prefix, new string[] { "FirstName", "Ime" }, FirstName);
            tLastName = new TemplateToken(token_prefix, new string[] { "LastName", "Priimek" }, LastName);
            tDateOfBirth = new TemplateToken(token_prefix, new string[] { "DateOfBirth", "DatumRojstva" }, DBTypes.func.Get_DATE_dd_mm_yyyy(DateOfBirth));
            tTaxID = new TemplateToken(token_prefix, new string[] { "Tax_ID", "DavčnaŠtevilka" }, Tax_ID);
            tRegistration_ID = new TemplateToken(token_prefix, new string[] { "Registration_ID", "MatičnaŠtevilka" }, Registration_ID);
            tMobilePhoneNumber = new TemplateToken(token_prefix, new string[] { "MobilePhoneNumber", "MobilnaTelefonŠtevilka" }, MobilePhoneNumber);
            tPhoneNumber = new TemplateToken(token_prefix, new string[] { "PhoneNumber", "TelefonskaŠtevilka" }, PhoneNumber);
            tEmail = new TemplateToken(token_prefix, new string[] { "Email", "Email" }, Email);
            tCardNumber = new TemplateToken(token_prefix, new string[] { "CardNumber", "ŠtevilkaKartice" }, CardNumber);
            tCardType = new TemplateToken(token_prefix, new string[] { "CardType", "VrstaKartice" }, CardType);

            list = new List<TemplateToken>();
            list.Add(tGender);
            list.Add(tFirstName);
            list.Add(tLastName);
            list.Add(tDateOfBirth);
            list.Add(tTaxID);
            list.Add(tRegistration_ID);
            list.Add(tMobilePhoneNumber);
            list.Add(tPhoneNumber);
            list.Add(tEmail);
            list.Add(tCardNumber);
            list.Add(tCardType);
        }  
    }
}
