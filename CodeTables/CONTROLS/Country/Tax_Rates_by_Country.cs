using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Country_ISO_3166
{
    public class tnr
    {
        public string Name = null;
        public decimal Rate = 0;
        public object Taxation_ID = null;

        public tnr()
        {

        }

        public tnr(decimal xRate)
        {
            Name = "Tax " + Rate.ToString() + "%";
            Rate = xRate / 100.0M;
        }
        public tnr(string xName, decimal xRate)
        {
            Name = xName;
            Rate = xRate / 100.0M;
        }

        public tnr Clone()
        {
            tnr new_tnr = new tnr();
            new_tnr.Name = this.Name;
            new_tnr.Rate = this.Rate;
            new_tnr.Taxation_ID = this.Taxation_ID;
            return new_tnr;
        }
    }
    public class Tax_Rates_by_Country
    {
        public string Country_Name = null;
        public int Country_Code_ISO_3166 = 0;
        public tnr[] rates = null;
        public Tax_Rates_by_Country(string xCountryName,int xCountry_Code_ISO_3166, tnr[] xrates)
        {
            Country_Name = xCountryName;
            Country_Code_ISO_3166 = xCountry_Code_ISO_3166;
            rates = xrates;
        }
    }

    public class Tax_Rates_by_Country_List
    {
        public Tax_Rates_by_Country[] item = null;

        public Tax_Rates_by_Country_List()
        {
            item = new Tax_Rates_by_Country[] {
             new Tax_Rates_by_Country("Afghanistan", 004, null)
            ,new Tax_Rates_by_Country("Åland Islands", 248, null)
            ,new Tax_Rates_by_Country("Albania", 008, new tnr[] {new tnr(20), new tnr(0)})
            ,new Tax_Rates_by_Country("Algeria", 012, null)
            ,new Tax_Rates_by_Country("American Samoa", 016, null)
            ,new Tax_Rates_by_Country("Andorra", 020, null)
            ,new Tax_Rates_by_Country("Angola", 024, null)
            ,new Tax_Rates_by_Country("Anguilla", 660, null)
            ,new Tax_Rates_by_Country("Antarctica", 010, null)
            ,new Tax_Rates_by_Country("Antigua and Barbuda", 028, null)
            ,new Tax_Rates_by_Country("Argentina", 032, new tnr[] { new tnr(27), new tnr(21), new tnr(10.5M), new tnr(0) })
            ,new Tax_Rates_by_Country("Armenia", 051, new tnr[] { new tnr(20), new tnr(0) })
            ,new Tax_Rates_by_Country("Aruba", 533, new tnr[] { new tnr(1.5M), new tnr(1) })
            ,new Tax_Rates_by_Country("Australia", 036, new tnr[] { new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Austria",040, new tnr[] { new tnr(20), new tnr(13), new tnr(10) })
            ,new Tax_Rates_by_Country("Azerbaijan", 031, new tnr[] { new tnr(18), new tnr(0) })
            ,new Tax_Rates_by_Country("Bahamas", 044, null)
            ,new Tax_Rates_by_Country("Bahrain", 048, null)
            ,new Tax_Rates_by_Country("Bangladesh", 050, null)
            ,new Tax_Rates_by_Country("Barbados", 052, new tnr[] { new tnr(17.5M), new tnr(7.5M), new tnr(0) })
            ,new Tax_Rates_by_Country("Belarus", 112, new tnr[] { new tnr(20), new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Belgium", 056, new tnr[] { new tnr(21), new tnr(12), new tnr(6), new tnr(0) })
            ,new Tax_Rates_by_Country("Belize", 084, null)
            ,new Tax_Rates_by_Country("Benin", 204, null)
            ,new Tax_Rates_by_Country("Bermuda", 060, null)
            ,new Tax_Rates_by_Country("Bhutan", 064, null)
            ,new Tax_Rates_by_Country("Bolivia",068, new tnr[] { new tnr(14.94M), new tnr(13), new tnr(0)})
            ,new Tax_Rates_by_Country("Bonaire, Sint Eustatius and Saba", 535, new tnr[] { new tnr(30), new tnr(25), new tnr(22), new tnr(18), new tnr(10), new tnr(8), new tnr(7), new tnr(6), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Bosnia and Herzegovina", 070, null)
            ,new Tax_Rates_by_Country("Botswana", 072, new tnr[] { new tnr(12), new tnr(0) })
            ,new Tax_Rates_by_Country("Bouvet Island", 074, null)
            ,new Tax_Rates_by_Country("Brazil",076, new tnr[] { new tnr(35), new tnr(7.6M), new tnr(3M), new tnr(5), new tnr(1.65M), new tnr(0.65M) })
            ,new Tax_Rates_by_Country("British Indian Ocean Territory",086, null)
            ,new Tax_Rates_by_Country("Brunei Darussalam",096, new tnr[] { new tnr(35), new tnr(7.6M), new tnr(3M), new tnr(5), new tnr(1.65M), new tnr(0.65M) })
            ,new Tax_Rates_by_Country("Bulgaria",100,null)
            ,new Tax_Rates_by_Country("Burkina Faso",854,null)
            ,new Tax_Rates_by_Country("Burundi",108,null)
            ,new Tax_Rates_by_Country("Cambodia",116, null)
            ,new Tax_Rates_by_Country("Cameroon",120, null)
            ,new Tax_Rates_by_Country("Canada",124, new tnr[] { new tnr(5), new tnr(9.975M), new tnr(0)})
            ,new Tax_Rates_by_Country("Cabo Verde",132, null)
            ,new Tax_Rates_by_Country("Cayman Islands",136, null)
            ,new Tax_Rates_by_Country("Central African Republic",140,null)
            ,new Tax_Rates_by_Country("Chad",148,null)
            ,new Tax_Rates_by_Country("Chile", 152, new tnr[] { new tnr(19), new tnr(15) })
            ,new Tax_Rates_by_Country("China",156, new tnr[] { new tnr(17), new tnr(13), new tnr(11), new tnr(6), new tnr(3)})
            ,new Tax_Rates_by_Country("Christmas Island",162,null)
            ,new Tax_Rates_by_Country("Cocos (Keeling)Islands",166,null)
            ,new Tax_Rates_by_Country("Colombia", 170, new tnr[] { new tnr(16), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Comoros", 174, null)
            ,new Tax_Rates_by_Country("Congo", 178, null)
            ,new Tax_Rates_by_Country("Congo(Democratic Republic of the)", 180, null)
            ,new Tax_Rates_by_Country("Cook Islands", 184, null)
            ,new Tax_Rates_by_Country("Costa Rica", 188, new tnr[] { new tnr(13), new tnr(10), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Côte d'Ivoire", 384, null)
            ,new Tax_Rates_by_Country("Croatia", 191, new tnr[] { new tnr("PDV 25%",25), new tnr("PDV 13%",13), new tnr("PDV 5%",5) })
            ,new Tax_Rates_by_Country("Cuba", 192,null)
            ,new Tax_Rates_by_Country("Curaçao", 531, new tnr[] { new tnr(9), new tnr(7), new tnr(6) })
            ,new Tax_Rates_by_Country("Cyprus", 196, new tnr[] { new tnr(19), new tnr(9), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Czech Republic", 203, new tnr[] { new tnr(21), new tnr(15), new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Denmark", 208, new tnr[] { new tnr(25), new tnr(0) })
            ,new Tax_Rates_by_Country("Djibouti", 262, null)
            ,new Tax_Rates_by_Country("Dominica", 212, null)
            ,new Tax_Rates_by_Country("Dominican Republic", 214, new tnr[] { new tnr(18), new tnr(13), new tnr(0) })
            ,new Tax_Rates_by_Country("Ecuador",218, new tnr[] { new tnr(12), new tnr(0) })
            ,new Tax_Rates_by_Country("Egypt", 818, new tnr[] { new tnr(10), new tnr(1.2M) })
            ,new Tax_Rates_by_Country("El Salvador", 222, new tnr[] { new tnr(13), new tnr(0) })
            ,new Tax_Rates_by_Country("Equatorial Guinea", 226,null)
            ,new Tax_Rates_by_Country("Eritrea", 232, null)
            ,new Tax_Rates_by_Country("Estonia", 233, new tnr[] { new tnr(20), new tnr(9), new tnr(0) })
            ,new Tax_Rates_by_Country("Ethiopia", 231,null)
            ,new Tax_Rates_by_Country("Falkland Islands(Malvinas)", 238,null)
            ,new Tax_Rates_by_Country("Faroe Islands", 234,null)
            ,new Tax_Rates_by_Country("Fiji", 242,null)
            ,new Tax_Rates_by_Country("Finland",246, new tnr[] { new tnr(24), new tnr(14), new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("France", 250, new tnr[] { new tnr(20), new tnr(10), new tnr(5.5M), new tnr(2.1M) })
            ,new Tax_Rates_by_Country("French Polynesia", 258, null)
            ,new Tax_Rates_by_Country("Gabon",266, null)
            ,new Tax_Rates_by_Country("Gambia",270, null)
            ,new Tax_Rates_by_Country("Georgia",268, new tnr[] { new tnr(18), new tnr(0.54M) })
            ,new Tax_Rates_by_Country("Germany",276, new tnr[] { new tnr(19), new tnr(7) })
            ,new Tax_Rates_by_Country("Ghana",288, new tnr[] { new tnr(17.5M), new tnr(15), new tnr(5), new tnr(3), new tnr(0) })
            ,new Tax_Rates_by_Country("Gibraltar",292,null)
            ,new Tax_Rates_by_Country("Greece",300, new tnr[] { new tnr(23), new tnr(13), new tnr(6)})
            ,new Tax_Rates_by_Country("Greenland",304,null)
            ,new Tax_Rates_by_Country("Grenada",308,null)
            ,new Tax_Rates_by_Country("Guadeloupe",312,null)
            ,new Tax_Rates_by_Country("Guam",316,null)
            ,new Tax_Rates_by_Country("Guatemala",320, new tnr[] { new tnr(12), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Guernsey",381, null)
            ,new Tax_Rates_by_Country("Guinea",324, null)
            ,new Tax_Rates_by_Country("Guinea- Bissau",624, null)
            ,new Tax_Rates_by_Country("Guyana",328, null)
            ,new Tax_Rates_by_Country("Haiti",332, null)
            ,new Tax_Rates_by_Country("Heard Island and McDonald Islands",334, null)
            ,new Tax_Rates_by_Country("Holy See",336, null)
            ,new Tax_Rates_by_Country("Honduras",340, new tnr[] { new tnr(18), new tnr(15) })
            ,new Tax_Rates_by_Country("Hong Kong",344,null)
            ,new Tax_Rates_by_Country("Hungary", 348, new tnr[] { new tnr(27), new tnr(18), new tnr(5) })
            ,new Tax_Rates_by_Country("Iceland", 352, new tnr[] { new tnr(24), new tnr(11), new tnr(0) })
            ,new Tax_Rates_by_Country("India",356, new tnr[] { new tnr(20), new tnr(15), new tnr(12.5M), new tnr(5.5M), new tnr(4), new tnr(1), new tnr(0) })
            ,new Tax_Rates_by_Country("Indonesia",360, new tnr[] { new tnr(10), new tnr(0)})
            ,new Tax_Rates_by_Country("Iran(Islamic Republic of)",364,null)
            ,new Tax_Rates_by_Country("Iraq",368,null)
            ,new Tax_Rates_by_Country("Ireland",372, new tnr[] { new tnr(23), new tnr(13.5M), new tnr(9) , new tnr(0) })
            ,new Tax_Rates_by_Country("Isle of Man",833, new tnr[] { new tnr(20), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Israel", 376, new tnr[] { new tnr(17), new tnr(0) })
            ,new Tax_Rates_by_Country("Italy", 380, new tnr[] { new tnr(22), new tnr(10), new tnr(5), new tnr(4) })
            ,new Tax_Rates_by_Country("Jamaica",388,null)
            ,new Tax_Rates_by_Country("Japan",392, new tnr[] { new tnr(8) })
            ,new Tax_Rates_by_Country("Jersey",832, new tnr[] { new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Jordan",400, new tnr[] { new tnr(16), new tnr(4), new tnr(0) })
            ,new Tax_Rates_by_Country("Kazakhstan",398, new tnr[] { new tnr(12), new tnr(0) })
            ,new Tax_Rates_by_Country("Kenya",404, new tnr[] { new tnr(16), new tnr(0) })
            ,new Tax_Rates_by_Country("Kiribati",296, null)
            ,new Tax_Rates_by_Country("Korea(Democratic People's Republic of)",408,null)
            ,new Tax_Rates_by_Country("Korea",410, new tnr[] { new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Kuwait",414,null)
            ,new Tax_Rates_by_Country("Kyrgyzstan",417,null)
            ,new Tax_Rates_by_Country("Lao People's Democratic Republic",418,null)
            ,new Tax_Rates_by_Country("Latvia",428,new tnr[] { new tnr(21), new tnr(12), new tnr(0) })
            ,new Tax_Rates_by_Country("Lebanon",422, new tnr[] { new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Lesotho",426,null)
            ,new Tax_Rates_by_Country("Liberia",430,null)
            ,new Tax_Rates_by_Country("Libya",434,null)
            ,new Tax_Rates_by_Country("Liechtenstein",438,null)
            ,new Tax_Rates_by_Country("Lithuania",440, new tnr[] { new tnr(21), new tnr(9), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Luxembourg",442, new tnr[] { new tnr(17), new tnr(14), new tnr(8), new tnr(3) })
            ,new Tax_Rates_by_Country("Macao",446,null)
            ,new Tax_Rates_by_Country("Macedonia(the former Yugoslav Republic of)",807, new tnr[] { new tnr(18), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Madagascar",450, new tnr[] { new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Malawi",454,null)
            ,new Tax_Rates_by_Country("Malaysia",458, new tnr[] { new tnr(6), new tnr(0) })
            ,new Tax_Rates_by_Country("Maldives", 462, new tnr[] { new tnr(12), new tnr(6), new tnr(0) })
            ,new Tax_Rates_by_Country("Mali", 466,null)
            ,new Tax_Rates_by_Country("Malta",470, new tnr[] { new tnr(18), new tnr(7), new tnr(5) })
            ,new Tax_Rates_by_Country("Marshall Islands",584,null)
            ,new Tax_Rates_by_Country("Martinique",474,null)
            ,new Tax_Rates_by_Country("Mauritius",480, new tnr[] { new tnr(15), new tnr(0) })
            ,new Tax_Rates_by_Country("Mayotte",175, null)
            ,new Tax_Rates_by_Country("Mexico",484, new tnr[] { new tnr(16), new tnr(0) })
            ,new Tax_Rates_by_Country("Micronesia(Federated Countrys of)",583,null)
            ,new Tax_Rates_by_Country("Moldova",498, new tnr[] { new tnr(20), new tnr(8), new tnr(0) })
            ,new Tax_Rates_by_Country("Mongolia",496, new tnr[] { new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Montenegro",499,null)
            ,new Tax_Rates_by_Country("Montserrat",500,null)
            ,new Tax_Rates_by_Country("Morocco",504, new tnr[] { new tnr(20), new tnr(14), new tnr(10), new tnr(7) })
            ,new Tax_Rates_by_Country("Mozambique",508,null)
            ,new Tax_Rates_by_Country("Myanmar",104, new tnr[] { new tnr(5), new tnr(3) })
            ,new Tax_Rates_by_Country("Namibia",516, new tnr[] { new tnr(15), new tnr(0) })
            ,new Tax_Rates_by_Country("Nauru",520,null)
            ,new Tax_Rates_by_Country("Nepal",524,null)
            ,new Tax_Rates_by_Country("Netherlands",528, new tnr[] { new tnr(21), new tnr(6), new tnr(0) })
            ,new Tax_Rates_by_Country("New Caledonia",540, null)
            ,new Tax_Rates_by_Country("New Zealand",554, new tnr[] { new tnr(15), new tnr(0) })
            ,new Tax_Rates_by_Country("Nicaragua",558, new tnr[] { new tnr(15), new tnr(0) })
            ,new Tax_Rates_by_Country("Niger", 562,null)
            ,new Tax_Rates_by_Country("Nigeria", 566, new tnr[] { new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Niue", 570,null)
            ,new Tax_Rates_by_Country("Norfolk Island", 574,null)
            ,new Tax_Rates_by_Country("Northern Mariana Islands", 580,null)
            ,new Tax_Rates_by_Country("Norway", 578, new tnr[] { new tnr(25), new tnr(15), new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Oman", 512,null)
            ,new Tax_Rates_by_Country("Pakistan",586, new tnr[] { new tnr(24), new tnr(19.5M), new tnr(18.5M), new tnr(18), new tnr(17), new tnr(16), new tnr(15), new tnr(14), new tnr(10), new tnr(8), new tnr(6), new tnr(5), new tnr(4), new tnr(3), new tnr(2), new tnr(1), new tnr(0) })
            ,new Tax_Rates_by_Country("Palau",585,null)
            ,new Tax_Rates_by_Country("Palestine, State of",275,null)
            ,new Tax_Rates_by_Country("Panama", 591, new tnr[] { new tnr(7), new tnr(15), new tnr(10) })
            ,new Tax_Rates_by_Country("Papua New Guinea",598,new tnr[] { new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Paraguay",600, new tnr[] { new tnr(10), new tnr(5) })
            ,new Tax_Rates_by_Country("Peru",604, new tnr[] { new tnr(18), new tnr(0) })
            ,new Tax_Rates_by_Country("Philippines",608, new tnr[] { new tnr(12), new tnr(0) })
            ,new Tax_Rates_by_Country("Pitcairn",612,null)
            ,new Tax_Rates_by_Country("Poland",616, new tnr[] { new tnr(23), new tnr(8), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Portugal",620, new tnr[] { new tnr(23), new tnr(13), new tnr(6) })
            ,new Tax_Rates_by_Country("Puerto Rico",630, new tnr[] { new tnr(10.5M), new tnr(4), new tnr(1) })
            ,new Tax_Rates_by_Country("Qatar",634,null)
            ,new Tax_Rates_by_Country("Réunion",638,null)
            ,new Tax_Rates_by_Country("Romania",642, new tnr[] { new tnr(20), new tnr(9), new tnr(5) })
            ,new Tax_Rates_by_Country("Russian Federation",643, new tnr[] { new tnr(18), new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Rwanda",646, new tnr[] { new tnr(18), new tnr(0) })
            ,new Tax_Rates_by_Country("Saint Barthélemy",652,null)
            ,new Tax_Rates_by_Country("Saint Helena and Tristan da Cunha",654,null)
            ,new Tax_Rates_by_Country("Saint Kitts and Nevis",659,null)
            ,new Tax_Rates_by_Country("Saint Lucia",662, new tnr[] { new tnr(15), new tnr(9.5M), new tnr(0) })
            ,new Tax_Rates_by_Country("Saint Martin(French part)",663,null)
            ,new Tax_Rates_by_Country("Saint Pierre and Miquelon",666,null)
            ,new Tax_Rates_by_Country("Saint Vincent and the Grenadines",670,null)
            ,new Tax_Rates_by_Country("Samoa",882,null)
            ,new Tax_Rates_by_Country("San Marino",674,null)
            ,new Tax_Rates_by_Country("Sao Tome and Principe",678,null)
            ,new Tax_Rates_by_Country("Saudi Arabia",682,null)
            ,new Tax_Rates_by_Country("Senegal",686,null)
            ,new Tax_Rates_by_Country("Serbia",688, new tnr[] { new tnr("PDV 20%",20), new tnr("PDV 10%", 10), new tnr("PDV 0%", 0) })
            ,new Tax_Rates_by_Country("Seychelles",690, new tnr[] { new tnr(15), new tnr(0) })
            ,new Tax_Rates_by_Country("Sierra Leone",694,null)
            ,new Tax_Rates_by_Country("Singapore",702, new tnr[] { new tnr(7), new tnr(0) })
            ,new Tax_Rates_by_Country("Sint Maarten(Dutch part)",534, new tnr[] { new tnr(5) })
            ,new Tax_Rates_by_Country("Slovak Republic",703, new tnr[] { new tnr(20), new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Slovenia",705, new tnr[] { new tnr("DDV 22%",22),new tnr("DDV 9.5%", 9.5M), new tnr("DDV 0%",0) })
            ,new Tax_Rates_by_Country("Solomon Islands",090, null)
            ,new Tax_Rates_by_Country("Somalia",706, null)
            ,new Tax_Rates_by_Country("South Africa",710, new tnr[] { new tnr(24), new tnr(0) })
            ,new Tax_Rates_by_Country("South Georgia and the South Sandwich Islands",239,null)
            ,new Tax_Rates_by_Country("South Sudan",728,null)
            ,new Tax_Rates_by_Country("Spain",724, new tnr[] { new tnr(21), new tnr(10), new tnr(4) })
            ,new Tax_Rates_by_Country("Sri Lanka",144,null)
            ,new Tax_Rates_by_Country("Suriname",740, new tnr[] { new tnr(25), new tnr(10), new tnr(8), new tnr(0) })
            ,new Tax_Rates_by_Country("Svalbard and Jan Mayen",744, null)
            ,new Tax_Rates_by_Country("Swaziland",748, null)
            ,new Tax_Rates_by_Country("Sweden",752, new tnr[] { new tnr(25), new tnr(12), new tnr(6) })
            ,new Tax_Rates_by_Country("Switzerland",756, new tnr[] { new tnr(8), new tnr(3.5M), new tnr(2.5M), new tnr(0) })
            ,new Tax_Rates_by_Country("Syrian Arab Republic",760,null)
            ,new Tax_Rates_by_Country("Taiwan",158, new tnr[] { new tnr(5) })
            ,new Tax_Rates_by_Country("Tajikistan",762,null)
            ,new Tax_Rates_by_Country("Tanzania",834, new tnr[] { new tnr(18), new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Thailand",764, new tnr[] { new tnr(7), new tnr(0) })
            ,new Tax_Rates_by_Country("Timor-Leste",626,null)
            ,new Tax_Rates_by_Country("Togo",768,null)
            ,new Tax_Rates_by_Country("Tokelau",772,null)
            ,new Tax_Rates_by_Country("Tonga",776,null)
            ,new Tax_Rates_by_Country("Trinidad and Tobago",780, new tnr[] { new tnr(12.5M), new tnr(0) })
            ,new Tax_Rates_by_Country("Tunisia",788, new tnr[] { new tnr(18), new tnr(12), new tnr(6) })
            ,new Tax_Rates_by_Country("Turkey",792, new tnr[] { new tnr(18), new tnr(8), new tnr(1) })
            ,new Tax_Rates_by_Country("Turkmenistan",795,null)
            ,new Tax_Rates_by_Country("Turks and Caicos Islands",796,null)
            ,new Tax_Rates_by_Country("Tuvalu",798,null)
            ,new Tax_Rates_by_Country("Uganda",800, new tnr[] { new tnr(18), new tnr(0) })
            ,new Tax_Rates_by_Country("Ukraine",804, new tnr[] { new tnr(20), new tnr(7), new tnr(0) })
            ,new Tax_Rates_by_Country("United Arab Emirates",784, new tnr[] { new tnr(20), new tnr(7), new tnr(0) })
            ,new Tax_Rates_by_Country("United Kingdom",826, new tnr[] { new tnr(20), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("United States",840, new tnr[] { new tnr(7.5M), new tnr(0) })
            ,new Tax_Rates_by_Country("United Countrys Minor Outlying Islands",581,null)
            ,new Tax_Rates_by_Country("Uruguay",858, new tnr[] { new tnr(22), new tnr(10), new tnr(0) })
            ,new Tax_Rates_by_Country("Uzbekistan",860, null)
            ,new Tax_Rates_by_Country("Vanuatu",548, null)
            ,new Tax_Rates_by_Country("Venezuela",862, new tnr[] { new tnr(12), new tnr(8), new tnr(0) })
            ,new Tax_Rates_by_Country("Vietnam",704, new tnr[] { new tnr(10), new tnr(5), new tnr(0) })
            ,new Tax_Rates_by_Country("Virgin Islands(British)",092,null)
            ,new Tax_Rates_by_Country("Virgin Islands(U.S.)",850,null)
            ,new Tax_Rates_by_Country("Wallis and Futuna",876,null)
            ,new Tax_Rates_by_Country("Western Sahara",732,null)
            ,new Tax_Rates_by_Country("Yemen",887, null)
            ,new Tax_Rates_by_Country("Zambia",894, new tnr[] { new tnr(16), new tnr(0) })
            ,new Tax_Rates_by_Country("Zimbabwe",716, new tnr[] { new tnr(15), new tnr(0) })
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
                            LogFile.Error.Show("ERROR:Tax_Rates_by_Country_List:Country Code " + item[i].Country_Code_ISO_3166.ToString() + " for \"" + item[i].Country_Name + "\" is the same for country \"" + item[j].Country_Name+"\"");
                        }
                    }
                }
            }
        }
    }
}
