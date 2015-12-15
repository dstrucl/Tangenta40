using SQLTableControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_ISO_3166
{
    public class ISO_3166_Table
    {
        public ISO_3166[] Country_ISO_3166_array = null;
        public DataTable dt_ISO_3166 = new DataTable();

        public bool SetInputControls(SQLTable tbl)
        {
            Form_Select_State_ISO_3166 frm_Select_State_ISO_316 = new Form_Select_State_ISO_3166(dt_ISO_3166);
            if (frm_Select_State_ISO_316.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (Column col in tbl.Column)
                {
                    if (col.Name.Equals("State"))
                    {
                        col.InputControl.SetValue(frm_Select_State_ISO_316.State);
                    }
                    else if (col.Name.Equals("State_ISO_3166_a2"))
                    {
                        col.InputControl.SetValue(frm_Select_State_ISO_316.State_ISO_3166_a2);
                    }
                    else if (col.Name.Equals("State_ISO_3166_a3"))
                    {
                        col.InputControl.SetValue(frm_Select_State_ISO_316.State_ISO_3166_a3);
                    }
                    else if (col.Name.Equals("State_ISO_3166_num"))
                    {
                        col.InputControl.SetValue(frm_Select_State_ISO_316.State_ISO_3166_num);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public ISO_3166_Table()
        {
            Country_ISO_3166_array = new ISO_3166[] {
            new ISO_3166("Afghanistan","AF","AFG",004,"ISO 3166 - 2:AF","Afganistan"),
            new ISO_3166("Åland Islands","AX","ALA",248,"ISO 3166 - 2:AX","Åland otoki"),
            new ISO_3166("Albania","AL","ALB",008,"ISO 3166 - 2:AL","Albanija"),
            new ISO_3166("Algeria","DZ","DZA",012,"ISO 3166 - 2:DZ","Alžirija"),
            new ISO_3166("American Samoa","AS","ASM",016,"ISO 3166 - 2:AS","Ameriška Samoa"),
            new ISO_3166("Andorra","AD","AND",020,"ISO 3166 - 2:AD","Andora"),
            new ISO_3166("Angola","AO","AGO",024,"ISO 3166 - 2:AO","Angola"),
            new ISO_3166("Anguilla","AI","AIA",660,"ISO 3166 - 2:AI","Anguilla"),
            new ISO_3166("Antarctica","AQ","ATA",010,"ISO 3166 - 2:AQ","Antarktika"),
            new ISO_3166("Antigua and Barbuda","AG","ATG",028,"ISO 3166 - 2:AG", "Antigva in Barbuda"),
            new ISO_3166("Argentina","AR","ARG",032,"ISO 3166 - 2:AR","Argentina"),
            new ISO_3166("Armenia","AM","ARM",051,"ISO 3166 - 2:AM","Armenija"),
            new ISO_3166("Aruba","AW","ABW",533,"ISO 3166 - 2:AW","Aruba"),
            new ISO_3166("Australia","AU","AUS",036,"ISO 3166 - 2:AU","Avstralija"),
            new ISO_3166("Austria","AT","AUT",040,"ISO 3166 - 2:AT","Avstrija"),
            new ISO_3166("Azerbaijan","AZ","AZE",031,"ISO 3166 - 2:AZ","Azerbajdžan"),
            new ISO_3166("Bahamas","BS","BHS",044,"ISO 3166 - 2:BS","Bahami"),
            new ISO_3166("Bahrain","BH","BHR",048,"ISO 3166 - 2:BH","Bahrajn"),
            new ISO_3166("Bangladesh","BD","BGD",050,"ISO 3166 - 2:BD","Bangladeš"),
            new ISO_3166("Barbados","BB","BRB",052,"ISO 3166 - 2:BB","Barbados"),
            new ISO_3166("Belarus","BY","BLR",112,"ISO 3166 - 2:BY","Belorusija"),
            new ISO_3166("Belgium","BE","BEL",056,"ISO 3166 - 2:BE","Belgija"),
            new ISO_3166("Belize","BZ","BLZ",084,"ISO 3166 - 2:BZ","Belize"),
            new ISO_3166("Benin","BJ","BEN",204,"ISO 3166 - 2:BJ","Benin"),
            new ISO_3166("Bermuda","BM","BMU",060,"ISO 3166 - 2:BM","Bermuda"),
            new ISO_3166("Bhutan","BT","BTN",064,"ISO 3166 - 2:BT","Butan"),
            new ISO_3166("Bolivia(Plurinational State of)","BO","BOL",068,"ISO 3166 - 2:BO","Bolivija"),
            new ISO_3166("Bonaire, Sint Eustatius and Saba","BQ","BES",535,"ISO 3166 - 2:BQ","Bonaire, Sint Eustatius and Saba"),
            new ISO_3166("Bosnia and Herzegovina","BA","BIH",070,"ISO 3166 - 2:BA","Bosna in Hercegovina"),
            new ISO_3166("Botswana","BW","BWA",072,"ISO 3166 - 2:BW","Bocvana"),
            new ISO_3166("Bouvet Island","BV","BVT",074,"ISO 3166 - 2:BV","Buvetovi otoki"),
            new ISO_3166("Brazil","BR","BRA",076,"ISO 3166 - 2:BR","Brazilija"),
            new ISO_3166("British Indian Ocean Territory","IO","IOT",086,"ISO 3166 - 2:IO","Britansko ozemlje v Tihem oceanu"),
            new ISO_3166("Brunei Darussalam","BN","BRN",096,"ISO 3166 - 2:BN","Brunej"),
            new ISO_3166("Bulgaria","BG","BGR",100,"ISO 3166 - 2:BG","Bolgarija"),
            new ISO_3166("Burkina Faso","BF","BFA",854,"ISO 3166 - 2:BF","Burkina Faso"),
            new ISO_3166("Burundi","BI","BDI",108,"ISO 3166 - 2:BI","Burundi"),
            new ISO_3166("Cambodia","KH","KHM",116,"ISO 3166 - 2:KH","Kambodža"),
            new ISO_3166("Cameroon","CM","CMR",120,"ISO 3166 - 2:CM","Kamerun"),
            new ISO_3166("Canada","CA","CAN",124,"ISO 3166 - 2:CA","Kanada"),
            new ISO_3166("Cabo Verde","CV","CPV",132,"ISO 3166 - 2:CV","Zelenortski Otoki"),
            new ISO_3166("Cayman Islands","KY","CYM",136,"ISO 3166 - 2:KY","Kajmanski otoki"),
            new ISO_3166("Central African Republic","CF","CAF",140,"ISO 3166 - 2:CF","Centralna Afriška Republika"),
            new ISO_3166("Chad","TD","TCD",148,"ISO 3166 - 2:TD","Čad"),
            new ISO_3166("Chile","CL","CHL",152,"ISO 3166 - 2:CL","Čile"),
            new ISO_3166("China","CN","CHN",156,"ISO 3166 - 2:CN","Kitajska"),
            new ISO_3166("Christmas Island","CX","CXR",162,"ISO 3166 - 2:CX","Božični otoki"),
            new ISO_3166("Cocos(Keeling)Islands","CC","CCK",166,"ISO 3166 - 2:CC","Kokosovi otoki"),
            new ISO_3166("Colombia","CO","COL",170,"ISO 3166 - 2:CO","Kolumbija"),
            new ISO_3166("Comoros","KM","COM",174,"ISO 3166 - 2:KM","Komori"),
            new ISO_3166("Congo","CG","COG",178,"ISO 3166 - 2:CG","Kongo"),
            new ISO_3166("Congo(Democratic Republic of the)","CD","COD",180,"ISO 3166 - 2:CD","Kongo (Demokratična republika"),
            new ISO_3166("Cook Islands","CK","COK",184,"ISO 3166 - 2:CK","Kukovi otoki"),
            new ISO_3166("Costa Rica","CR","CRI",188,"ISO 3166 - 2:CR","Kostarika"),
            new ISO_3166("Côte d'Ivoire","CI","CIV",384,"ISO 3166-2:CI","Côte d'Ivoire"),
            new ISO_3166("Croatia","HR","HRV",191,"ISO 3166 - 2:HR","Hrvaška"),
            new ISO_3166("Cuba","CU","CUB",192,"ISO 3166 - 2:CU","Kuba"),
            new ISO_3166("Curaçao","CW","CUW",531,"ISO 3166 - 2:CW","Curaçao"),
            new ISO_3166("Cyprus","CY","CYP",196,"ISO 3166 - 2:CY","Ciper"),
            new ISO_3166("Czech Republic","CZ","CZE",203,"ISO 3166 - 2:CZ","Češka"),
            new ISO_3166("Denmark","DK","DNK",208,"ISO 3166 - 2:DK","Danska"),
            new ISO_3166("Djibouti","DJ","DJI",262,"ISO 3166 - 2:DJ","Džibuti"),
            new ISO_3166("Dominica","DM","DMA",212,"ISO 3166 - 2:DM","Dominika"),
            new ISO_3166("Dominican Republic","DO","DOM",214,"ISO 3166 - 2:DO","Dominikanska repuplika"),
            new ISO_3166("Ecuador","EC","ECU",218,"ISO 3166 - 2:EC","Ekvador"),
            new ISO_3166("Egypt","EG","EGY",818,"ISO 3166 - 2:EG","Egipt"),
            new ISO_3166("El Salvador","SV","SLV",222,"ISO 3166 - 2:SV","Salvador"),
            new ISO_3166("Equatorial Guinea","GQ","GNQ",226,"ISO 3166 - 2:GQ","Ekvatorialna Gvineja"),
            new ISO_3166("Eritrea","ER","ERI",232,"ISO 3166 - 2:ER","Eritreja"),
            new ISO_3166("Estonia","EE","EST",233,"ISO 3166 - 2:EE","Estonija"),
            new ISO_3166("Ethiopia","ET","ETH",231,"ISO 3166 - 2:ET","Etiopija"),
            new ISO_3166("Falkland Islands(Malvinas)","FK","FLK",238,"ISO 3166 - 2:FK","Falklanski otoki"),
            new ISO_3166("Faroe Islands","FO","FRO",234,"ISO 3166 - 2:FO","Ferski otoki"),
            new ISO_3166("Fiji","FJ","FJI",242,"ISO 3166 - 2:FJ","Fidži"),
            new ISO_3166("Finland","FI","FIN",246,"ISO 3166 - 2:FI","Finska"),
            new ISO_3166("France","FR","FRA",250,"ISO 3166 - 2:FR","Francija"),
            new ISO_3166("French Polynesia","PF","PYF",258,"ISO 3166 - 2:PF","Francoska Polinezija"),
            new ISO_3166("Gabon","GA","GAB",266,"ISO 3166 - 2:GA","Gabon"),
            new ISO_3166("Gambia","GM","GMB",270,"ISO 3166 - 2:GM","Gambija"),
            new ISO_3166("Georgia","GE","GEO",268,"ISO 3166 - 2:GE","Georgija"),
            new ISO_3166("Germany","DE","DEU",276,"ISO 3166 - 2:DE","Nemčija"),
            new ISO_3166("Ghana","GH","GHA",288,"ISO 3166 - 2:GH","Gana"),
            new ISO_3166("Gibraltar","GI","GIB",292,"ISO 3166 - 2:GI","Gibraltar"),
            new ISO_3166("Greece","GR","GRC",300,"ISO 3166 - 2:GR","Grčija"),
            new ISO_3166("Greenland","GL","GRL",304,"ISO 3166 - 2:GL","Grenlandija"),
            new ISO_3166("Grenada","GD","GRD",308,"ISO 3166 - 2:GD","Grenada"),
            new ISO_3166("Guadeloupe","GP","GLP",312,"ISO 3166 - 2:GP","Guadelupe"),
            new ISO_3166("Guam","GU","GUM",316,"ISO 3166 - 2:GU","Guam"),
            new ISO_3166("Guatemala","GT","GTM",320,"ISO 3166 - 2:GT","Gvatemala"),
            new ISO_3166("Guernsey","GG","GGY",831,"ISO 3166 - 2:GG","Guernsey"),
            new ISO_3166("Guinea","GN","GIN",324,"ISO 3166 - 2:GN","Gvineja"),
            new ISO_3166("Guinea- Bissau","GW","GNB",624,"ISO 3166 - 2:GW","Gvineja Bissau" ),
            new ISO_3166("Guyana","GY","GUY",328,"ISO 3166 - 2:GY","Gvajana"),
            new ISO_3166("Haiti","HT","HTI",332,"ISO 3166 - 2:HT","Haiti"),
            new ISO_3166("Heard Island and McDonald Islands","HM","HMD",334,"ISO 3166 - 2:HM","Otok Heard in otočje McDonald"),
            new ISO_3166("Holy See","VA","VAT",336,"ISO 3166 - 2:VA","Sveti sedež"),
            new ISO_3166("Honduras","HN","HND",340,"ISO 3166 - 2:HN","Honduras"),
            new ISO_3166("Hong Kong","HK","HKG",344,"ISO 3166 - 2:HK","Hong Kong"),
            new ISO_3166("Hungary","HU","HUN",348,"ISO 3166 - 2:HU","Madžarska"),
            new ISO_3166("Iceland","IS","ISL",352,"ISO 3166 - 2:IS","Islandija"),
            new ISO_3166("India","IN","IND",356,"ISO 3166 - 2:IN","Indija"),
            new ISO_3166("Indonesia","ID","IDN",360,"ISO 3166 - 2:ID","Indonezija"),
            new ISO_3166("Iran(Islamic Republic of)","IR","IRN",364,"ISO 3166 - 2:IR","Iran"),
            new ISO_3166("Iraq","IQ","IRQ",368,"ISO 3166 - 2:IQ","Irak"),
            new ISO_3166("Ireland","IE","IRL",372,"ISO 3166 - 2:IE","Irska "),
            new ISO_3166("Isle of Man","IM","IMN",833,"ISO 3166 - 2:IM","Man"),
            new ISO_3166("Israel","IL","ISR",376,"ISO 3166 - 2:IL","Izrael"),
            new ISO_3166("Italy","IT","ITA",380,"ISO 3166 - 2:IT","Italija"),
            new ISO_3166("Jamaica","JM","JAM",388,"ISO 3166 - 2:JM","Jamajka"),
            new ISO_3166("Japan","JP","JPN",392,"ISO 3166 - 2:JP","Japonska"),
            new ISO_3166("Jersey","JE","JEY",832,"ISO 3166 - 2:JE","Jersey"),
            new ISO_3166("Jordan","JO","JOR",400,"ISO 3166 - 2:JO","Jordanija"),
            new ISO_3166("Kazakhstan","KZ","KAZ",398,"ISO 3166 - 2:KZ","Kazahstan"),
            new ISO_3166("Kenya","KE","KEN",404,"ISO 3166 - 2:KE","Kenija"),
            new ISO_3166("Kiribati","KI","KIR",296,"ISO 3166 - 2:KI","Kiribati"),
            new ISO_3166("Korea(Democratic People's Republic of)","KP","PRK",408,"ISO 3166-2:KP ","Severna Koreja"),
            new ISO_3166("Korea(Republic of)","KR","KOR",410,"ISO 3166 - 2:KR","Južna Koreja"),
            new ISO_3166("Kuwait","KW","KWT",414,"ISO 3166 - 2:KW","Kuvajt"),
            new ISO_3166("Kyrgyzstan","KG","KGZ",417,"ISO 3166 - 2:KG","Kirgizistan"),
            new ISO_3166("Lao People's Democratic Republic","LA","LAO",418,"ISO 3166-2:LA ","Laos"),
            new ISO_3166("Latvia","LV","LVA",428,"ISO 3166 - 2:LV","Latvija "),
            new ISO_3166("Lebanon","LB","LBN",422,"ISO 3166 - 2:LB","Libanon"),
            new ISO_3166("Lesotho","LS","LSO",426,"ISO 3166 - 2:LS","Lesoto"),
            new ISO_3166("Liberia","LR","LBR",430,"ISO 3166 - 2:LR","Liberija"),
            new ISO_3166("Libya","LY","LBY",434,"ISO 3166 - 2:LY","Libija"),
            new ISO_3166("Liechtenstein","LI","LIE",438,"ISO 3166 - 2:LI","Lihtenštajn"),
            new ISO_3166("Lithuania","LT","LTU",440,"ISO 3166 - 2:LT","Litva"),
            new ISO_3166("Luxembourg","LU","LUX",442,"ISO 3166 - 2:LU", "Luksemburg"),
            new ISO_3166("Macao","MO","MAC",446,"ISO 3166 - 2:MO","Macao"),
            new ISO_3166("Macedonia(the former Yugoslav Republic of)","MK","MKD",807,"ISO 3166 - 2:MK","Makedonija"),
            new ISO_3166("Madagascar","MG","MDG",450,"ISO 3166 - 2:MG","Madagaskar"),
            new ISO_3166("Malawi","MW","MWI",454,"ISO 3166 - 2:MW","Malavi"),
            new ISO_3166("Malaysia","MY","MYS",458,"ISO 3166 - 2:MY","Malezija"),
            new ISO_3166("Maldives","MV","MDV",462,"ISO 3166 - 2:MV","Maldivi"),
            new ISO_3166("Mali","ML","MLI",466,"ISO 3166 - 2:ML","Mali"),
            new ISO_3166("Malta","MT","MLT",470,"ISO 3166 - 2:MT","Malta"),
            new ISO_3166("Marshall Islands","MH","MHL",584,"ISO 3166 - 2:MH","Marshallovi otoki"),
            new ISO_3166("Martinique","MQ","MTQ",474,"ISO 3166 - 2:MQ","Martinik"),
            new ISO_3166("Mauritania","MR","MRT",478,"ISO 3166 - 2:MR","Mavretanija"),
            new ISO_3166("Mauritius","MU","MUS",480,"ISO 3166 - 2:MU","Mauritius"),
            new ISO_3166("Mayotte","YT","MYT",175,"ISO 3166 - 2:YT","Mayotte"),
            new ISO_3166("Mexico","MX","MEX",484,"ISO 3166 - 2:MX","Mehika"),
            new ISO_3166("Micronesia(Federated States of)","FM","FSM",583,"ISO 3166 - 2:FM","Mikronezija"),
            new ISO_3166("Moldova(Republic of)","MD","MDA",498,"ISO 3166 - 2:MD","Moldavija"),
            new ISO_3166("Monaco","MC","MCO",492,"ISO 3166 - 2:MC","Monako"),
            new ISO_3166("Mongolia","MN","MNG",496,"ISO 3166 - 2:MN","Mongolija"),
            new ISO_3166("Montenegro","ME","MNE",499,"ISO 3166 - 2:ME","Črna gora"),
            new ISO_3166("Montserrat","MS","MSR",500,"ISO 3166 - 2:MS","Montserrat "),
            new ISO_3166("Morocco","MA","MAR",504,"ISO 3166 - 2:MA","Maroko"),
            new ISO_3166("Mozambique","MZ","MOZ",508,"ISO 3166 - 2:MZ","Mozambik"),
            new ISO_3166("Myanmar","MM","MMR",104,"ISO 3166 - 2:MM","Mjanmar"),
            new ISO_3166("Namibia","NA","NAM",516,"ISO 3166 - 2:NA","Namibija"),
            new ISO_3166("Nauru","NR","NRU",520,"ISO 3166 - 2:NR","Nauru"),
            new ISO_3166("Nepal","NP","NPL",524,"ISO 3166 - 2:NP","Nepal"),
            new ISO_3166("Netherlands","NL","NLD",528,"ISO 3166 - 2:NL", "Nizozemska"),
            new ISO_3166("New Caledonia","NC","NCL",540,"ISO 3166 - 2:NC","Nova Kaledonija"),
            new ISO_3166("New Zealand","NZ","NZL",554,"ISO 3166 - 2:NZ","Nova Zelandija"),
            new ISO_3166("Nicaragua","NI","NIC",558,"ISO 3166 - 2:NI","Nikaragva"),
            new ISO_3166("Niger","NE","NER",562,"ISO 3166 - 2:NE","Niger"),
            new ISO_3166("Nigeria","NG","NGA",566,"ISO 3166 - 2:NG","Nigerija"),
            new ISO_3166("Niue","NU","NIU",570,"ISO 3166 - 2:NU","Niue"),
            new ISO_3166("Norfolk Island","NF","NFK",574,"ISO 3166 - 2:NF","Norfolški otok"),
            new ISO_3166("Northern Mariana Islands","MP","MNP",580,"ISO 3166 - 2:MP","Severni Marianski otoki"),
            new ISO_3166("Norway","NO","NOR",578,"ISO 3166 - 2:NO","Norveška"),
            new ISO_3166("Oman","OM","OMN",512,"ISO 3166 - 2:OM","Oman"),
            new ISO_3166("Pakistan","PK","PAK",586,"ISO 3166 - 2:PK","Pakistan"),
            new ISO_3166("Palau","PW","PLW",585,"ISO 3166 - 2:PW","Palau"),
            new ISO_3166("Palestine, State of","PS","PSE",275,"ISO 3166 - 2:PS","Palestina"),
            new ISO_3166("Panama","PA","PAN",591,"ISO 3166 - 2:PA","Panama"),
            new ISO_3166("Papua New Guinea","PG","PNG",598,"ISO 3166 - 2:PG","Papua Nova Gvineja"),
            new ISO_3166("Paraguay","PY","PRY",600,"ISO 3166 - 2:PY","Paragvaj"),
            new ISO_3166("Peru","PE","PER",604,"ISO 3166 - 2:PE","Peru"),
            new ISO_3166("Philippines","PH","PHL",608,"ISO 3166 - 2:PH","Filipini"),
            new ISO_3166("Pitcairn","PN","PCN",612,"ISO 3166 - 2:PN","Pitcairnovi otoki"),
            new ISO_3166("Poland","PL","POL",616,"ISO 3166 - 2:PL","Poljska"),
            new ISO_3166("Portugal","PT","PRT",620,"ISO 3166 - 2:PT","Portugalska"),
            new ISO_3166("Puerto Rico","PR","PRI",630,"ISO 3166 - 2:PR","Portoriko"),
            new ISO_3166("Qatar","QA","QAT",634,"ISO 3166 - 2:QA","Katar"),
            new ISO_3166("Réunion","RE","REU",638,"ISO 3166 - 2:RE","Reunion"),
            new ISO_3166("Romania","RO","ROU",642,"ISO 3166 - 2:RO","Romunija"),
            new ISO_3166("Russian Federation","RU","RUS",643,"ISO 3166 - 2:RU","Rusija"),
            new ISO_3166("Rwanda","RW","RWA",646,"ISO 3166 - 2:RW","Ruanda"),
            new ISO_3166("Saint Barthélemy","BL","BLM",652,"ISO 3166 - 2:BL","Saint Barthélemy"),
            new ISO_3166("Saint Helena, Ascension and Tristan da Cunha","SH","SHN",654,"ISO 3166 - 2:SH","Sveta Helena"),
            new ISO_3166("Saint Kitts and Nevis","KN","KNA",659,"ISO 3166 - 2:KN","Saint Kitts in Nevis"),
            new ISO_3166("Saint Lucia","LC","LCA",662,"ISO 3166 - 2:LC","Saint Lucia"),
            new ISO_3166("Saint Martin(French part)","MF","MAF",663,"ISO 3166 - 2:MF","Saint Martin"),
            new ISO_3166("Saint Pierre and Miquelon","PM","SPM",666,"ISO 3166 - 2:PM","Saint Pierre and Miquelon"),
            new ISO_3166("Saint Vincent and the Grenadines","VC","VCT",670,"ISO 3166 - 2:VC","Saint Vincent in Grenadine"),
            new ISO_3166("Samoa","WS","WSM",882,"ISO 3166 - 2:WS","Samoa"),
            new ISO_3166("San Marino","SM","SMR",674,"ISO 3166 - 2:SM","San Marino"),
            new ISO_3166("Sao Tome and Principe","ST","STP",678,"ISO 3166 - 2:ST","Sao Tome in Principe"),
            new ISO_3166("Saudi Arabia","SA","SAU",682,"ISO 3166 - 2:SA","Saudova Arabija"),
            new ISO_3166("Senegal","SN","SEN",686,"ISO 3166 - 2:SN","Senegal"),
            new ISO_3166("Serbia","RS","SRB",688,"ISO 3166 - 2:RS","Srbija"),
            new ISO_3166("Seychelles","SC","SYC",690,"ISO 3166 - 2:SC","Sejšeli"),
            new ISO_3166("Sierra Leone","SL","SLE",694,"ISO 3166 - 2:SL","Sierra Leone"),
            new ISO_3166("Singapore","SG","SGP",702,"ISO 3166 - 2:SG","Singapur"),
            new ISO_3166("Sint Maarten(Dutch part)","SX","SXM",534,"ISO 3166 - 2:SX","Sint Maarten"),
            new ISO_3166("Slovakia","SK","SVK",703,"ISO 3166 - 2:SK","Slovaška "),
            new ISO_3166("Slovenia","SI","SVN",705,"ISO 3166 - 2:SI", "Slovenija "),
            new ISO_3166("Solomon Islands","SB","SLB",090,"ISO 3166 - 2:SB","Salomonovi otoki"),
            new ISO_3166("Somalia","SO","SOM",706,"ISO 3166 - 2:SO","Somalija"),
            new ISO_3166("South Africa","ZA","ZAF",710,"ISO 3166 - 2:ZA","Srednjeafriška republika"),
            new ISO_3166("South Georgia and the South Sandwich Islands","GS","SGS",239,"ISO 3166 - 2:GS","Južna Georgia in Južni Sandwichevi otoki" ),
            new ISO_3166("South Sudan","SS","SSD",728,"ISO 3166 - 2:SS","Južni Sudan"),
            new ISO_3166("Spain","ES","ESP",724,"ISO 3166 - 2:ES","Španija"),
            new ISO_3166("Sri Lanka","LK","LKA",144,"ISO 3166 - 2:LK","Šrilanka"),
            new ISO_3166("Sudan","SD","SDN",729,"ISO 3166 - 2:SD","Sudan"),
            new ISO_3166("Suriname","SR","SUR",740,"ISO 3166 - 2:SR","Surinam"),
            new ISO_3166("Svalbard and Jan Mayen","SJ","SJM",744,"ISO 3166 - 2:SJ","Svalbard in Jan Mayen"),
            new ISO_3166("Swaziland","SZ","SWZ",748,"ISO 3166 - 2:SZ","Svazi"),
            new ISO_3166("Sweden","SE","SWE",752,"ISO 3166 - 2:SE","Švedska"),
            new ISO_3166("Switzerland","CH","CHE",756,"ISO 3166 - 2:CH","Švica"),
            new ISO_3166("Syrian Arab Republic","SY","SYR",760,"ISO 3166 - 2:SY","Sirija"),
            new ISO_3166("Taiwan, Province of China[a]","TW","TWN",158,"ISO 3166 - 2:TW","Tajvan"),
            new ISO_3166("Tajikistan","TJ","TJK",762,"ISO 3166 - 2:TJ","Tadžikistan"),
            new ISO_3166("Tanzania, United Republic of","TZ","TZA",834,"ISO 3166 - 2:TZ","Tanzanija"),
            new ISO_3166("Thailand","TH","THA",764,"ISO 3166 - 2:TH","Tajska"),
            new ISO_3166("Timor-Leste","TL","TLS",626,"ISO 3166 - 2:TL","Vzhodni Timor"),
            new ISO_3166("Togo","TG","TGO",768,"ISO 3166 - 2:TG","Togo"),
            new ISO_3166("Tokelau","TK","TKL",772,"ISO 3166 - 2:TK","Tokelau"),
            new ISO_3166("Tonga","TO","TON",776,"ISO 3166 - 2:TO","Tonga"),
            new ISO_3166("Trinidad and Tobago","TT","TTO",780,"ISO 3166 - 2:TT","Trinidad in Tobago"),
            new ISO_3166("Tunisia","TN","TUN",788,"ISO 3166 - 2:TN","Tunizija"),
            new ISO_3166("Turkey","TR","TUR",792,"ISO 3166 - 2:TR","Turčija"),
            new ISO_3166("Turkmenistan","TM","TKM",795,"ISO 3166 - 2:TM","Turkmenistan"),
            new ISO_3166("Turks and Caicos Islands","TC","TCA",796,"ISO 3166 - 2:TC","Otoki Turks in Caicos"),
            new ISO_3166("Tuvalu","TV","TUV",798,"ISO 3166 - 2:TV","Tuvalu"),
            new ISO_3166("Uganda","UG","UGA",800,"ISO 3166 - 2:UG","Uganda"),
            new ISO_3166("Ukraine","UA","UKR",804,"ISO 3166 - 2:UA","Ukrajina"),
            new ISO_3166("United Arab Emirates","AE","ARE",784,"ISO 3166 - 2:AE","Združeni arabski emirati"),
            new ISO_3166("United Kingdom of Great Britain and Northern Ireland","GB","GBR",826,"ISO 3166 - 2:GB","Velika Britanija"),
            new ISO_3166("United States of America","US","USA",840,"ISO 3166 - 2:US","Združene države Amerike"),
            new ISO_3166("United States Minor Outlying Islands","UM","UMI",581,"ISO 3166 - 2:UM","United States Minor Outlying Islands"),
            new ISO_3166("Uruguay","UY","URY",858,"ISO 3166 - 2:UY","Urugvaj"),
            new ISO_3166("Uzbekistan","UZ","UZB",860,"ISO 3166 - 2:UZ","Uzbekistan "),
            new ISO_3166("Vanuatu","VU","VUT",548,"ISO 3166 - 2:VU","Vanuatu"),
            new ISO_3166("Venezuela(Bolivarian Republic of)","VE","VEN",862,"ISO 3166 - 2:VE","Venezuela"),
            new ISO_3166("Viet Nam","VN","VNM",704,"ISO 3166 - 2:VN","Vietnam"),
            new ISO_3166("Virgin Islands(British)","VG","VGB",092,"ISO 3166 - 2:VG","Britanski Deviški otoki"),
            new ISO_3166("Virgin Islands(U.S.)","VI","VIR",850,"ISO 3166 - 2:VI","Deviški otoki"),
            new ISO_3166("Wallis and Futuna","WF","WLF",876,"ISO 3166 - 2:WF","Wallis in Futuna"),
            new ISO_3166("Western Sahara","EH","ESH",732,"ISO 3166 - 2:EH","Zahodna Sahara"),
            new ISO_3166("Yemen","YE","YEM",887,"ISO 3166 - 2:YE","Jemen"),
            new ISO_3166("Zambia","ZM","ZMB",894,"ISO 3166 - 2:ZM","Zambija"),
            new ISO_3166("Zimbabwe","ZW","ZWE",716,"ISO 3166 - 2:ZW","Zimbabve")
            };
            dt_ISO_3166.Columns.Add("State", typeof(string));
            dt_ISO_3166.Columns.Add("a2", typeof(string));
            dt_ISO_3166.Columns.Add("a3", typeof(string));
            dt_ISO_3166.Columns.Add("num", typeof(short));
            foreach (ISO_3166 iso_3166 in Country_ISO_3166_array)
            {
                DataRow dr = dt_ISO_3166.NewRow();
                dr["State"] = iso_3166.s_Name_In_Language.s;
                dr["a2"] = iso_3166.Country_A2;
                dr["a3"] = iso_3166.Country_A3;
                dr["num"] = iso_3166.Country_Number;
                dt_ISO_3166.Rows.Add(dr);
            }
        }
    }
}
