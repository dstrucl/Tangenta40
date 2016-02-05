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
    public class Address
    {
        public string StreetName = null;
        public string HouseNumber = null;
        public string ZIP = null;
        public string City = null;
        public string State = null;
        public string Country = null;

        public AddressToken token = null;
        private ltext token_prefix_Organisation;

        public Address(ltext token_prefix,
                       string _StreetName,
                       string _HouseNumber,
                       string _ZIP,
                       string _City,
                       string _State,
                       string _Country
                       )

        {
            StreetName = _StreetName;
            HouseNumber = _HouseNumber;
            ZIP = _ZIP;
            City = _City;
            State = _State;
            Country = _Country;
            ltext ltAddress_prefix = token_prefix.AddAtTheEnd(lngToken.st_Address);
            token = new AddressToken(ltAddress_prefix,
                                    StreetName,
                                    HouseNumber,
                                    ZIP,
                                    City,
                                    State,
                                    Country
                                    );

            
        }

        public Address(ltext token_prefix)
        {
            StreetName = "";
            HouseNumber = "";
            ZIP = "";
            City = "";
            State = "";
            Country = "";
            ltext ltAddress_prefix = token_prefix.AddAtTheEnd(lngToken.st_Address);
            token = new AddressToken(ltAddress_prefix);
        }
    }
}
