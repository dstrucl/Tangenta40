﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanguageControl
{
    public class Official_language_by_Country
    {
        public string Country_Name = null;
        public int Country_Code_ISO_3166 = 0;
        public int language_id = 0;
        public Official_language_by_Country(string xCountryName, int xCountry_Code_ISO_3166, int xlanguage_ID)
        {
            Country_Name = xCountryName;
            Country_Code_ISO_3166 = xCountry_Code_ISO_3166;
            language_id = xlanguage_ID;
        }
    }
    public class Offical_language_by_Country_list
    {
        public Official_language_by_Country[] item = null;
        public Offical_language_by_Country_list()
        {
            item = new Official_language_by_Country[]
            {
            new Official_language_by_Country("Afghanistan",004,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Åland Islands",248,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Albania",008,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Algeria",012,DynSettings.NotDefined_ID),
            new Official_language_by_Country("American Samoa",016,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Andorra",020,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Angola",024,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Anguilla",660,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Antarctica",010,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Antigua and Barbuda",028,DynSettings.English_ID),
            new Official_language_by_Country("Argentina",032,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Armenia",051,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Aruba",533,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Australia",036,DynSettings.English_ID),
            new Official_language_by_Country("Austria",040,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Azerbaijan",031,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Bahamas",044,DynSettings.English_ID),
            new Official_language_by_Country("Bahrain",048,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Bangladesh",050,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Barbados",052,DynSettings.English_ID),
            new Official_language_by_Country("Belarus",112,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Belgium",056,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Belize",084,DynSettings.English_ID),
            new Official_language_by_Country("Benin",204,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Bermuda",060,DynSettings.English_ID),
            new Official_language_by_Country("Bhutan",064,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Bolivia(Plurinational Sate of)",068,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Bonaire, Sint Eustatius and Saba",535,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Bosnia and Herzegovina",070,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Botswana",072,DynSettings.English_ID),
            new Official_language_by_Country("Bouvet Island",074,DynSettings.English_ID),
            new Official_language_by_Country("Brazil",076,DynSettings.NotDefined_ID),
            new Official_language_by_Country("British Indian Ocean Territory",086,DynSettings.English_ID),
            new Official_language_by_Country("Brunei Darussalam",096,DynSettings.English_ID),
            new Official_language_by_Country("Bulgaria",100,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Burkina Faso",854,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Burundi",108,DynSettings.English_ID),
            new Official_language_by_Country("Cambodia",116,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Cameroon",120,DynSettings.English_ID),
            new Official_language_by_Country("Canada",124,DynSettings.English_ID),
            new Official_language_by_Country("Cabo Verde",132,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Cayman Islands",136,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Central African Republic",140,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Chad",148,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Chile",152,DynSettings.NotDefined_ID),
            new Official_language_by_Country("China",156,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Christmas Island",162,DynSettings.English_ID),
            new Official_language_by_Country("Cocos(Keeling)Islands",166,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Colombia",170,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Comoros",174,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Congo",178,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Congo(Democratic Republic of the)",180,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Cook Islands",184,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Costa Rica",188,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Côte d'Ivoire",384,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Croatia",191,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Cuba",192,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Curaçao",531,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Cyprus",196,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Czech Republic",203,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Denmark",208,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Djibouti",262,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Dominica",212,DynSettings.English_ID),
            new Official_language_by_Country("Dominican Republic",214,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Ecuador",218,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Egypt",818,DynSettings.NotDefined_ID),
            new Official_language_by_Country("El Salvador",222,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Equatorial Guinea",226,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Eritrea",232,DynSettings.English_ID),
            new Official_language_by_Country("Estonia",233,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Ethiopia",231,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Falkland Islands(Malvinas)",238,DynSettings.English_ID),
            new Official_language_by_Country("Faroe Islands",234,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Fiji",242,DynSettings.English_ID),
            new Official_language_by_Country("Finland",246,DynSettings.NotDefined_ID),
            new Official_language_by_Country("France",250,DynSettings.NotDefined_ID),
            new Official_language_by_Country("French Polynesia",258,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Gabon",266,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Gambia",270,DynSettings.English_ID),
            new Official_language_by_Country("Georgia",268,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Germany",276,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Ghana",288,DynSettings.English_ID),
            new Official_language_by_Country("Gibraltar",292,DynSettings.English_ID),
            new Official_language_by_Country("Greece",300,DynSettings.English_ID),
            new Official_language_by_Country("Greenland",304,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Grenada",308,DynSettings.English_ID),
            new Official_language_by_Country("Guadeloupe",312,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Guam",316,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Guatemala",320,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Guernsey",831,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Guinea",324,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Guinea- Bissau",624,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Guyana",328,DynSettings.English_ID),
            new Official_language_by_Country("Haiti",332,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Heard Island and McDonald Islands",334,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Holy See",336,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Honduras",340,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Hong Kong",344,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Hungary",348,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Iceland",352,DynSettings.NotDefined_ID),
            new Official_language_by_Country("India",356,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Indonesia",360,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Iran(Islamic Republic of)",364,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Iraq",368,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Ireland",372,DynSettings.English_ID),
            new Official_language_by_Country("Isle of Man",833,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Israel",376,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Italy",380,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Jamaica",388,DynSettings.English_ID),
            new Official_language_by_Country("Japan",392,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Jersey",832,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Jordan",400,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Kazakhstan",398,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Kenya",404,DynSettings.English_ID),
            new Official_language_by_Country("Kiribati",296,DynSettings.English_ID),
            new Official_language_by_Country("Korea(Democratic People's Republic of)",408,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Korea(Republic of)",410,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Kuwait",414,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Kyrgyzstan",417,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Lao People's Democratic Republic",418,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Latvia",428,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Lebanon",422,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Lesotho",426,DynSettings.English_ID),
            new Official_language_by_Country("Liberia",430,DynSettings.English_ID),
            new Official_language_by_Country("Libya",434,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Liechtenstein",438,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Lithuania",440,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Luxembourg",442,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Macao",446,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Macedonia(the former Yugoslav Republic of)",807,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Madagascar",450,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Malawi",454,DynSettings.English_ID),
            new Official_language_by_Country("Malaysia",458,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Maldives",462,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Mali",466,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Malta",470,DynSettings.English_ID),
            new Official_language_by_Country("Marshall Islands",584,DynSettings.English_ID),
            new Official_language_by_Country("Martinique",474,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Mauritania",478,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Mauritius",480,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Mayotte",175,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Mexico",484,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Micronesia(Federated Countrys of)",583,DynSettings.English_ID),
            new Official_language_by_Country("Moldova(Republic of)",498,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Monaco",492,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Mongolia",496,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Montenegro",499,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Montserrat",500,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Morocco",504,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Mozambique",508,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Myanmar",104,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Namibia",516,DynSettings.English_ID),
            new Official_language_by_Country("Nauru",520,DynSettings.English_ID),
            new Official_language_by_Country("Nepal",524,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Netherlands",528,DynSettings.NotDefined_ID),
            new Official_language_by_Country("New Caledonia",540,DynSettings.NotDefined_ID),
            new Official_language_by_Country("New Zealand",554,DynSettings.English_ID),
            new Official_language_by_Country("Nicaragua",558,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Niger",562,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Nigeria",566,DynSettings.English_ID),
            new Official_language_by_Country("Niue",570,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Norfolk Island",574,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Northern Mariana Islands",580,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Norway",578,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Oman",512,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Pakistan",586,DynSettings.English_ID),
            new Official_language_by_Country("Palau",585,DynSettings.English_ID),
            new Official_language_by_Country("Palestine, State of",275,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Panama",591,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Papua New Guinea",598,DynSettings.English_ID),
            new Official_language_by_Country("Paraguay",600,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Peru",604,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Philippines",608,DynSettings.English_ID),
            new Official_language_by_Country("Pitcairn",612,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Poland",616,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Portugal",620,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Puerto Rico",630,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Qatar",634,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Réunion",638,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Romania",642,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Russian Federation",643,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Rwanda",646,DynSettings.English_ID),
            new Official_language_by_Country("Saint Barthélemy",652,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Saint Helena and Tristan da Cunha",654,DynSettings.English_ID),
            new Official_language_by_Country("Saint Kitts and Nevis",659,DynSettings.English_ID),
            new Official_language_by_Country("Saint Lucia",662,DynSettings.English_ID),
            new Official_language_by_Country("Saint Martin(French part)",663,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Saint Pierre and Miquelon",666,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Saint Vincent and the Grenadines",670,DynSettings.English_ID),
            new Official_language_by_Country("Samoa",882,DynSettings.English_ID),
            new Official_language_by_Country("San Marino",674,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Sao Tome and Principe",678,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Saudi Arabia",682,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Senegal",686,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Serbia",688,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Seychelles",690,DynSettings.English_ID),
            new Official_language_by_Country("Sierra Leone",694,DynSettings.English_ID),
            new Official_language_by_Country("Singapore",702,DynSettings.English_ID),
            new Official_language_by_Country("Sint Maarten(Dutch part)",534,DynSettings.English_ID),
            new Official_language_by_Country("Slovakia",703,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Slovenia",705,DynSettings.Slovensko_ID),
            new Official_language_by_Country("Solomon Islands",090,DynSettings.English_ID),
            new Official_language_by_Country("Somalia",706,DynSettings.NotDefined_ID),
            new Official_language_by_Country("South Africa",710,DynSettings.English_ID),
            new Official_language_by_Country("South Georgia and the South Sandwich Islands",239,DynSettings.NotDefined_ID ),
            new Official_language_by_Country("South Sudan",728,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Spain",724,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Sri Lanka",144,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Sudan",729,DynSettings.English_ID),
            new Official_language_by_Country("Suriname",740,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Svalbard and Jan Mayen",744,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Swaziland",748,DynSettings.English_ID),
            new Official_language_by_Country("Sweden",752,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Switzerland",756,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Syrian Arab Republic",760,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Taiwan, Province of China[a]",158,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Tajikistan",762,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Tanzania, United Republic of",834,DynSettings.English_ID),
            new Official_language_by_Country("Thailand",764,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Timor-Leste",626,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Togo",768,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Tokelau",772,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Tonga",776,DynSettings.English_ID),
            new Official_language_by_Country("Trinidad and Tobago",780,DynSettings.English_ID),
            new Official_language_by_Country("Tunisia",788,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Turkey",792,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Turkmenistan",795,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Turks and Caicos Islands",796,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Tuvalu",798,DynSettings.English_ID),
            new Official_language_by_Country("Uganda",800,DynSettings.English_ID),
            new Official_language_by_Country("Ukraine",804,DynSettings.NotDefined_ID),
            new Official_language_by_Country("United Arab Emirates",784,DynSettings.NotDefined_ID),
            new Official_language_by_Country("United Kingdom of Great Britain and Northern Ireland",826,DynSettings.English_ID),
            new Official_language_by_Country("United Countrys of America",840,DynSettings.English_ID),
            new Official_language_by_Country("United Countrys Minor Outlying Islands",581,DynSettings.English_ID),
            new Official_language_by_Country("Uruguay",858,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Uzbekistan",860,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Vanuatu",548,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Venezuela(Bolivarian Republic of)",862,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Viet Nam",704,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Virgin Islands(British)",092,DynSettings.English_ID),
            new Official_language_by_Country("Virgin Islands(U.S.)",850,DynSettings.English_ID),
            new Official_language_by_Country("Wallis and Futuna",876,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Western Sahara",732,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Yemen",887,DynSettings.NotDefined_ID),
            new Official_language_by_Country("Zambia",894,DynSettings.English_ID),
            new Official_language_by_Country("Zimbabwe",716,DynSettings.NotDefined_ID)
            };
            int iCount = item.Count();
            int i = 0;
            for (i = 0; i < iCount; i++)
            {
                int j = i + 1;
                if (j < iCount - 1)
                {
                    for (j = i + 1; j < iCount; j++)
                    {
                        if (item[i].Country_Code_ISO_3166 == item[j].Country_Code_ISO_3166)
                        {
                            MessageBox.Show("ERROR:Tax_Rates_by_Country_List:Country Code " + item[i].Country_Code_ISO_3166 + " for \"" + item[i].Country_Name + "\" is the same for country \"" + item[j].Country_Name + "\"");
                        }
                    }
                }
            }
        }
    }
}