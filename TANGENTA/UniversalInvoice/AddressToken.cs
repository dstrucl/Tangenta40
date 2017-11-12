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
    public class AddressToken
    {
        public TemplateToken tStreet = null;
        public TemplateToken tHouseNumber = null;
        public TemplateToken tZIP = null;
        public TemplateToken tCity = null;
        public TemplateToken tCountry= null;
        public TemplateToken tState = null;
        public List<TemplateToken> list = new List<TemplateToken>();

        public AddressToken(ltext token_prefix,
                            string Street,
                            string HouseNumber,
                            string ZIP,
                            string City,
                            string Country,
                            string State)
        {
            tStreet = new TemplateToken(token_prefix, new string[] { "Street", "Cesta" }, Street,null);
            tHouseNumber = new TemplateToken(token_prefix, new string[] { "HouseNumber", "HišnaŠtevilka" }, HouseNumber, null);
            tZIP = new TemplateToken(token_prefix, new string[] { "ZIP", "Pošta" }, ZIP, null);
            tCity = new TemplateToken(token_prefix, new string[] { "City", "Kraj" }, City, null);
            tCountry= new TemplateToken(token_prefix, new string[] { "Country", "Država" }, Country, null);
            tState = new TemplateToken(token_prefix, new string[] { "State", "Dežela" }, State, null);
            AddList();
        }

        public AddressToken(ltext token_prefix)
        {
            tStreet = new TemplateToken(token_prefix, new string[] { "Street", "Cesta" }, "", null);
            tHouseNumber = new TemplateToken(token_prefix, new string[] { "HouseNumber", "HišnaŠtevilka" }, "", null);
            tZIP = new TemplateToken(token_prefix, new string[] { "ZIP", "Pošta" }, "", null);
            tCity = new TemplateToken(token_prefix, new string[] { "City", "Kraj" }, "", null);
            tCountry= new TemplateToken(token_prefix, new string[] { "Country", "Država" }, "", null);
            tState = new TemplateToken(token_prefix, new string[] { "State", "Dežela" }, "", null);
            AddList();
        }

        private void AddList()
        {
            list.Clear();
            list.Add(tStreet);
            list.Add(tHouseNumber);
            list.Add(tZIP);
            list.Add(tCity);
            list.Add(tCountry);
            list.Add(tState);

        }
    }
}
