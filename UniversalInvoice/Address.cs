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
            ltext ltAddress_prefix = new ltext(token_prefix.sText[0] + "_Address", token_prefix.sText[1] + "_Naslov");
            token = new AddressToken(ltAddress_prefix,
                                    StreetName,
                                    HouseNumber,
                                    ZIP,
                                    City,
                                    State,
                                    Country
                                    );

            
        }
    }
}
