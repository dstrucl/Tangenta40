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

        public TemplateToken tStreet = null;
        public TemplateToken tHouseNumber = null;
        public TemplateToken tZIP = null;
        public TemplateToken tCity = null;
        public TemplateToken tState = null;
        public TemplateToken tCountry = null;


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

            tStreet = new TemplateToken(token_prefix, new string[] { "@@_Street", "@@_Cesta" }, null);
            tHouseNumber = new TemplateToken(token_prefix,new string[] { "@@_HouseNumber", "@@_HišnaŠtevilka" }, null);
            tZIP = new TemplateToken(token_prefix,new string[] { "@@_ZIP", "@@_Pošta" }, null);
            tCity = new TemplateToken(token_prefix, new string[] { "@@_City", "@@_Kraj" }, null);
            tState = new TemplateToken(token_prefix, new string[] { "@@_State", "@@_Država" }, null);
            tCountry = new TemplateToken(token_prefix, new string[] { "@@_Country", "@@_Dežela" }, null);
        }
    }
}
