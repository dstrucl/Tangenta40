﻿#region LICENSE 
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
        public TemplateToken tState = null;
        public TemplateToken tCountry = null;
        public List<TemplateToken> list = new List<TemplateToken>();
        private ltext ltAddress_prefix;

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
            AddList();
        }

        public AddressToken(ltext token_prefix)
        {
            tStreet = new TemplateToken(token_prefix, new string[] { "Street", "Cesta" }, "", null);
            tHouseNumber = new TemplateToken(token_prefix, new string[] { "HouseNumber", "HišnaŠtevilka" }, "", null);
            tZIP = new TemplateToken(token_prefix, new string[] { "ZIP", "Pošta" }, "", null);
            tCity = new TemplateToken(token_prefix, new string[] { "City", "Kraj" }, "", null);
            tState = new TemplateToken(token_prefix, new string[] { "State", "Država" }, "", null);
            tCountry = new TemplateToken(token_prefix, new string[] { "Country", "Dežela" }, "", null);
            AddList();
        }

        private void AddList()
        {
            list.Clear();
            list.Add(tStreet);
            list.Add(tHouseNumber);
            list.Add(tZIP);
            list.Add(tCity);
            list.Add(tState);
            list.Add(tCountry);

        }
    }
}
