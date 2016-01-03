using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalInvoice
{
    public class AddressToken
    {
        public TemplateToken tStreet = null;
        public TemplateToken tHouseNumber = null;
        public TemplateToken tZIP = null;
        public TemplateToken tCity = null;
        public TemplateToken tState = null;
        public TemplateToken tCountry = null;
        public List<TemplateToken> list = new List<TemplateToken>();

        public AddressToken(ltext token_prefix,
                            string Street,
                            string HouseNumber,
                            string ZIP,
                            string City,
                            string State,
                            string Country)
        {
            tStreet = new TemplateToken(token_prefix, new string[] { "Street", "Cesta" }, Street,null);
            tHouseNumber = new TemplateToken(token_prefix, new string[] { "HouseNumber", "HišnaŠtevilka" }, HouseNumber, null);
            tZIP = new TemplateToken(token_prefix, new string[] { "ZIP", "Pošta" }, ZIP, null);
            tCity = new TemplateToken(token_prefix, new string[] { "City", "Kraj" }, City, null);
            tState = new TemplateToken(token_prefix, new string[] { "State", "Država" }, State, null);
            tCountry = new TemplateToken(token_prefix, new string[] { "Country", "Dežela" }, Country, null);
            list.Add(tStreet);
            list.Add(tHouseNumber);
            list.Add(tZIP);
            list.Add(tState);
            list.Add(tCountry);
        }

    }
}
