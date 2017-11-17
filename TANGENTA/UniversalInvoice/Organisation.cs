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

namespace UniversalInvoice
{
    public class Organisation
    {
        public string Name = null;
        public string Tax_ID = null;
        public string Registration_ID = null;
        public bool_v TaxPayer_v = null;
        public string Comment1 = null;
        public string Atom_Office_Name = null;
        public string BankName = null;
        public string TRR = null;
        public string Email = null;
        public string HomePage = null;
        public string PhoneNumber = null;
        public string FaxNumber = null;
        public byte[] Logo_Data = null;

        public Address Address = null;
        public OrganisationToken token = null;

        public Organisation(ltext token_prefix,
                            string _Name,
                            string _Tax_ID,
                            string _Registration_ID,
                            bool_v _TaxPayer_v,
                            string_v _Comment1_v,
                            string _Atom_Office_Name,
                            string _BankName,
                            string _TRR,
                            string _Email,
                            string _HomePage,
                            string _PhoneNumber,
                            string _FaxNumber,
                            byte[] _Logo_Data,
                            string _StreetName,
                            string _HouseNumber,
                            string _ZIP,
                            string _City,
                            string _Country,
                            string _State
                            
                            )
        {

            Name = _Name;
            Tax_ID =                _Tax_ID;
            Registration_ID =       _Registration_ID;
            TaxPayer_v = _TaxPayer_v;
            if (_Comment1_v!=null)
            {
                Comment1 = _Comment1_v.v;
            }


            Atom_Office_Name =      _Atom_Office_Name;
            BankName =              _BankName;
            TRR =                   _TRR;
            Email =                 _Email;
            HomePage =              _HomePage;
            PhoneNumber =           _PhoneNumber;
            FaxNumber =             _FaxNumber;
            Logo_Data =             _Logo_Data;

            ltext token_prefix_Organisation = token_prefix.AddAtTheEnd(lng.st_Organisation);
            Address = new Address(token_prefix_Organisation,
                                    _StreetName,
                                    _HouseNumber,
                                    _ZIP,
                                    _City,
                                    _Country,
                                    _State);

            token = new OrganisationToken(token_prefix_Organisation,
                                            Name,
                                            Tax_ID,
                                            Registration_ID,
                                            _TaxPayer_v,
                                            Comment1,
                                            Atom_Office_Name,
                                            BankName,
                                            TRR,
                                            Email,
                                            HomePage,
                                            PhoneNumber,
                                            FaxNumber,
                                            Logo_Data);
        }

        public Organisation(ltext token_prefix)
        {

            Name = "";
            Tax_ID = "";
            Registration_ID = "";
            Atom_Office_Name = "";
            BankName = "";
            TRR = "";
            Email = "";
            HomePage = "";
            PhoneNumber ="";
            FaxNumber = "";
            Logo_Data = null;
            ltext token_prefix_Organisation = token_prefix.AddAtTheEnd(lng.st_Organisation);
            Address = new Address(token_prefix_Organisation);
            token = new OrganisationToken(token_prefix_Organisation);
        }
    }
}