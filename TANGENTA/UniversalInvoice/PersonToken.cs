#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
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

        public List<TemplateToken> list = new List<TemplateToken>();

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
            tGender = new TemplateToken(token_prefix, new string[] { "Gender", "Spol" }, DBTypes.func.GenderAsString(Gender), null);
            tFirstName = new TemplateToken(token_prefix, new string[] { "FirstName", "Ime" }, FirstName, null);
            tLastName = new TemplateToken(token_prefix, new string[] { "LastName", "Priimek" }, LastName, null);
            tDateOfBirth = new TemplateToken(token_prefix, new string[] { "DateOfBirth", "DatumRojstva" }, DBTypes.func.Get_DATE_dd_mm_yyyy(DateOfBirth), null);
            tTaxID = new TemplateToken(token_prefix, new string[] { "Tax_ID", "DavčnaŠtevilka" }, Tax_ID, null);
            tRegistration_ID = new TemplateToken(token_prefix, new string[] { "Registration_ID", "MatičnaŠtevilka" }, Registration_ID, null);
            tMobilePhoneNumber = new TemplateToken(token_prefix, new string[] { "MobilePhoneNumber", "MobilnaTelefonŠtevilka" }, MobilePhoneNumber, null);
            tPhoneNumber = new TemplateToken(token_prefix, new string[] { "PhoneNumber", "TelefonskaŠtevilka" }, PhoneNumber, null);
            tEmail = new TemplateToken(token_prefix, new string[] { "Email", "Email" }, Email, null);
            tCardNumber = new TemplateToken(token_prefix, new string[] { "CardNumber", "ŠtevilkaKartice" }, CardNumber, null);
            tCardType = new TemplateToken(token_prefix, new string[] { "CardType", "VrstaKartice" }, CardType, null);
            AddList();
        }

        public PersonToken(ltext token_prefix)
        {
            tGender = new TemplateToken(token_prefix, new string[] { "Gender", "Spol" }, "",null);
            tFirstName = new TemplateToken(token_prefix, new string[] { "FirstName", "Ime" }, "", null);
            tLastName = new TemplateToken(token_prefix, new string[] { "LastName", "Priimek" }, "", null);
            tDateOfBirth = new TemplateToken(token_prefix, new string[] { "DateOfBirth", "DatumRojstva" }, "", null);
            tTaxID = new TemplateToken(token_prefix, new string[] { "Tax_ID", "DavčnaŠtevilka" }, "", null);
            tRegistration_ID = new TemplateToken(token_prefix, new string[] { "Registration_ID", "MatičnaŠtevilka" }, "", null);
            tMobilePhoneNumber = new TemplateToken(token_prefix, new string[] { "MobilePhoneNumber", "MobilnaTelefonŠtevilka" }, "", null);
            tPhoneNumber = new TemplateToken(token_prefix, new string[] { "PhoneNumber", "TelefonskaŠtevilka" }, "", null);
            tEmail = new TemplateToken(token_prefix, new string[] { "Email", "Email" }, "", null);
            tCardNumber = new TemplateToken(token_prefix, new string[] { "CardNumber", "ŠtevilkaKartice" }, "", null);
            tCardType = new TemplateToken(token_prefix, new string[] { "CardType", "VrstaKartice" }, "", null);

            AddList();
        }
        private void AddList()
        {
            list.Clear();
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
