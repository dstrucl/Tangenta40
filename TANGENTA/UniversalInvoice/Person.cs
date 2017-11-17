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
        public Address Address = null;
        public PersonToken token = null;

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
                        string _Country,
                        string _State
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
            ltext token_prefix_Person = token_prefix.AddAtTheEnd(lng.st_Person);
            Address = new Address(token_prefix_Person, _StreetName,
                                           _HouseNumber,
                                           _ZIP,
                                           _City,
                                           _Country,
                                           _State);
            token = new PersonToken(token_prefix_Person,
                                    Gender,
                                    FirstName,
                                    LastName,
                                    DateOfBirth,
                                    Tax_ID,
                                    Registration_ID,
                                    MobilePhoneNumber,
                                    PhoneNumber,
                                    Email,
                                    CardNumber,
                                    CardType);

    }

        public Person(ltext token_prefix)
        {
            Gender = false;
            FirstName = "";
            LastName = "";
            DateOfBirth = DateTime.MinValue;
            Tax_ID = "";
            Registration_ID = "";
            MobilePhoneNumber = "";
            PhoneNumber = "";
            Email = "";
            CardNumber = "";
            CardType = "";
            PersonImage = null;
            ltext token_prefix_Person = token_prefix.AddAtTheEnd(lng.st_Person);
            Address = new Address(token_prefix_Person);

            token = new PersonToken(token_prefix_Person);
        }
    }
}
