#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalInvoice
{
    public class OrganisationToken
    {
        public TemplateToken tName = null;
        public TemplateToken tTax_ID = null;
        public TemplateToken tRegistration_ID = null;
        public TemplateToken tTaxPayer = null;
        public TemplateToken tComment1 = null;
        public TemplateToken tComment2 = null;
        public TemplateToken tAtom_Office_Name = null;
        public TemplateToken tBankName = null;
        public TemplateToken tTRR = null;
        public TemplateToken tEmail = null;
        public TemplateToken tHomePage = null;
        public TemplateToken tPhoneNumber = null;
        public TemplateToken tFaxNumber = null;
        public TemplateToken tLogo_Data = null;
        public TemplateToken tStreetName = null;
        public TemplateToken tHouseNumber = null;
        public TemplateToken tZIP = null;
        public TemplateToken tCity = null;
        public TemplateToken tCountry= null;
        public TemplateToken tState = null;

        public List<TemplateToken> list = new List<TemplateToken>();
       

        public OrganisationToken(ltext token_prefix,
                                    string _Name,
                                    string _Tax_ID,
                                    string _Registration_ID,
                                    bool_v _TaxPayer_v,
                                    string _Comment1,
                                    string _Comment2,
                                    string _Atom_Office_Name,
                                    string _BankName,
                                    string _TRR,
                                    string _Email,
                                    string _HomePage,
                                    string _PhoneNumber,
                                    string _FaxNumber,
                                    byte[] _Logo_Data)
        {
            tName                    = new TemplateToken(token_prefix, new string[] { "Name", "Ime" }, _Name,null);
            tTax_ID                  = new TemplateToken(token_prefix, new string[] { "Tax_ID", "DavčnaŠtevilka" }, _Tax_ID, null);
            tRegistration_ID         = new TemplateToken(token_prefix, new string[] { "Regsitration_ID", "MatičnaŠtevilka" }, _Registration_ID, null);
            tTaxPayer                = new TemplateToken(token_prefix, new string[] { "TaxPayer", "DavčniZavezanec" }, _TaxPayer_v, null);
            tComment1                = new TemplateToken(token_prefix, new string[] { "Comment1", "Komentar1" }, _Comment1, null);
            tComment2                = new TemplateToken(token_prefix, new string[] { "Comment2", "Komentar2" }, _Comment2, null);
            tAtom_Office_Name        = new TemplateToken(token_prefix, new string[] { "Office", "PoslovnaEnota" }, _Atom_Office_Name, null);
            tBankName                = new TemplateToken(token_prefix, new string[] { "BankName", "Banka" }, _BankName, null);
            tTRR                     = new TemplateToken(token_prefix, new string[] { "BankAccount", "Bančni račun" }, _TRR, null);
            tEmail                   = new TemplateToken(token_prefix, new string[] { "Email", "Email" }, _Email, null);
            tHomePage                = new TemplateToken(token_prefix, new string[] { "HomePage", "DomačaStran" }, _HomePage, null);
            tPhoneNumber             = new TemplateToken(token_prefix, new string[] { "PhoneNumber", "Telefon" }, _PhoneNumber, null);
            tFaxNumber               = new TemplateToken(token_prefix, new string[] { "FaxNumber", "Fax" }, _FaxNumber, null);
            tLogo_Data               = new TemplateToken(token_prefix, new string[] { "Logo", "Logo" }, _Logo_Data, null);
            AddList();
        }


        public OrganisationToken(ltext token_prefix)
        {
            tName = new TemplateToken(token_prefix, new string[] { "Name", "Ime" }, "", null);
            tTax_ID = new TemplateToken(token_prefix, new string[] { "Tax_ID", "DavčnaŠtevilka" }, "", null);
            tRegistration_ID = new TemplateToken(token_prefix, new string[] { "Regsitration_ID", "MatičnaŠtevilka" }, "", null);
            tTaxPayer = new TemplateToken(token_prefix, new string[] { "TaxPayer", "DavčniZavezanec" }, "", null);
            tComment1 = new TemplateToken(token_prefix, new string[] { "Comment1", "Komentar1" }, "", null);
            tComment2 = new TemplateToken(token_prefix, new string[] { "Comment2", "Komentar2" }, "", null);
            tAtom_Office_Name = new TemplateToken(token_prefix, new string[] { "Office", "PoslovnaEnota" }, "", null);
            tBankName = new TemplateToken(token_prefix, new string[] { "BankName", "Banka" }, "", null);
            tTRR = new TemplateToken(token_prefix, new string[] { "BankAccount", "Bančni račun" }, "", null);
            tEmail = new TemplateToken(token_prefix, new string[] { "Email", "Email" }, "", null);
            tHomePage = new TemplateToken(token_prefix, new string[] { "HomePage", "DomačaStran" }, "", null);
            tPhoneNumber = new TemplateToken(token_prefix, new string[] { "PhoneNumber", "Telefon" }, "", null);
            tFaxNumber = new TemplateToken(token_prefix, new string[] { "FaxNumber", "Fax" }, "", null);
            tLogo_Data = new TemplateToken(token_prefix, new string[] { "Logo", "Logo" }, "", null);
            AddList();
        }

        private void AddList()
        {
            list.Clear();
            list.Add(tName);
            list.Add(tTax_ID);
            list.Add(tRegistration_ID);
            list.Add(tTaxPayer);
            list.Add(tComment1);
            list.Add(tComment2);
            list.Add(tAtom_Office_Name);
            list.Add(tBankName);
            list.Add(tTRR);
            list.Add(tEmail);
            list.Add(tHomePage);
            list.Add(tPhoneNumber);
            list.Add(tFaxNumber);
            list.Add(tLogo_Data);

        }

    }
}
