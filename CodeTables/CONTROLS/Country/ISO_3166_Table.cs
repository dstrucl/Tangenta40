#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using CodeTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Country_ISO_3166
{
    public class ISO_3166_Table
    {
        public const int SLOVENIA_COUNTRY_NUM = 705;

        public static ISO_3166 m_Afghanistan = new ISO_3166("Afghanistan", "AF", "AFG", 004, "ISO 3166 - 2:AF", "Afghani", "AFN", "AFN", 971, 2, "Afganistan");


        public static ISO_3166 m_Aland_Islands = new ISO_3166("Åland Islands", "AX", "ALA", 248, "ISO 3166 - 2:AX", "Euro", "EUR", "€", 978, 2, "Åland otoki");
        public static ISO_3166 m_Albania = new ISO_3166("Albania", "AL", "ALB", 008, "ISO 3166 - 2:AL", "Lek", "ALL", "ALL", 008, 2, "Albanija");
        public static ISO_3166 m_Algeria = new ISO_3166("Algeria", "DZ", "DZA", 012, "ISO 3166 - 2:DZ", "Algerian Dinar", "DZD", "DZD", 012, 2, "Alžirija");
        public static ISO_3166 m_American_Samoa = new ISO_3166("American Samoa","AS","ASM",016,"ISO 3166 - 2:AS","US Dollar","USD","$",840,2,"Ameriška Samoa");
        public static ISO_3166 m_Andorra = new ISO_3166("Andorra", "AD", "AND", 020, "ISO 3166 - 2:AD", "Euro", "EUR", "€", 978, 2, "Andora");
        public static ISO_3166 m_Angola = new ISO_3166("Angola", "AO", "AGO", 024, "ISO 3166 - 2:AO", "Kwanza", "AOA", "AOA", 973, 2, "Angola");
        public static ISO_3166 m_Anguilla = new ISO_3166("Anguilla", "AI", "AIA", 660, "ISO 3166 - 2:AI", "East Caribbean Dollar", "XCD", "XCD", 951, 2, "Anguilla");
        public static ISO_3166 m_Antarctica = new ISO_3166("Antarctica", "AQ", "ATA", 010, "ISO 3166 - 2:AQ", null, null, null, 0, 0, "Antarktika");
        public static ISO_3166 m_Antigua_and_Barbuda = new ISO_3166("Antigua and Barbuda", "AG", "ATG", 028, "ISO 3166 - 2:AG", "East Caribbean Dollar", "XCD", "XCD", 951, 2, "Antigva in Barbuda");
        public static ISO_3166 m_Argentina = new ISO_3166("Argentina", "AR", "ARG", 032, "ISO 3166 - 2:AR", "Argentine Peso", "ARS", "ARS", 032, 2, "Argentina");
        public static ISO_3166 m_Armenia = new ISO_3166("Armenia", "AM", "ARM", 051, "ISO 3166 - 2:AM", "Armenian Dram", "AMD", "AMD", 051, 2, "Armenija");
        public static ISO_3166 m_Aruba = new ISO_3166("Aruba", "AW", "ABW", 533, "ISO 3166 - 2:AW", "Aruban Florin", "AWG", "AWG", 533, 2, "Aruba");
        public static ISO_3166 m_Australia = new ISO_3166("Australia", "AU", "AUS", 036, "ISO 3166 - 2:AU", "Australian Dollar", "AUD", "$", 36, 2, "Avstralija");
        public static ISO_3166 m_Austria = new ISO_3166("Austria", "AT", "AUT", 040, "ISO 3166 - 2:AT", "Euro", "EUR", "€", 978, 2, "Avstrija");
        public static ISO_3166 m_Azerbaijan = new ISO_3166("Azerbaijan", "AZ", "AZE", 031, "ISO 3166 - 2:AZ", "Azerbaijanian Manat", "AZN", "AZN", 944, 2, "Azerbajdžan");
        public static ISO_3166 m_Bahamas = new ISO_3166("Bahamas", "BS", "BHS", 044, "ISO 3166 - 2:BS", "Bahamian Dollar", "BSD", "BSD", 044, 2, "Bahami");
        public static ISO_3166 m_Bahrain = new ISO_3166("Bahrain", "BH", "BHR", 048, "ISO 3166 - 2:BH", "Bahraini Dinar", "BHD", "BHD", 048, 3, "Bahrajn");
        public static ISO_3166 m_Bangladesh = new ISO_3166("Bangladesh", "BD", "BGD", 050, "ISO 3166 - 2:BD", "Taka", "BDT", "BDT", 050, 2, "Bangladeš");
        public static ISO_3166 m_Barbados = new ISO_3166("Barbados", "BB", "BRB", 052, "ISO 3166 - 2:BB", "Barbados Dollar", "BBD", "BBD", 052, 2, "Barbados");
        public static ISO_3166 m_Belarus = new ISO_3166("Belarus", "BY", "BLR", 112, "ISO 3166 - 2:BY", "Belarusian Ruble", "BYR", "BYR", 974, 0, "Belorusija");
        public static ISO_3166 m_Belgium = new ISO_3166("Belgium", "BE", "BEL", 056, "ISO 3166 - 2:BE", "Euro", "EUR", "€", 978, 2, "Belgija");
        public static ISO_3166 m_Belize = new ISO_3166("Belize", "BZ", "BLZ", 084, "ISO 3166 - 2:BZ", "Belize Dollar", "BZD", "BZD", 084, 2, "Belize");
        public static ISO_3166 m_Benin = new ISO_3166("Benin", "BJ", "BEN", 204, "ISO 3166 - 2:BJ", "CFA Franc BCEAO", "XOF", "XOF", 952, 0, "Benin");
        public static ISO_3166 m_Bermuda = new ISO_3166("Bermuda", "BM", "BMU", 060, "ISO 3166 - 2:BM", "Bermudian Dollar", "BMD", "BMD", 060, 2, "Bermuda");
        public static ISO_3166 m_Bhutan = new ISO_3166("Bhutan", "BT", "BTN", 064, "ISO 3166 - 2:BT", "Indian Rupee", "INR", "₹", 356, 2, "Butan");
        public static ISO_3166 m_Bolivia_Plurinational_Sate_of = new ISO_3166("Bolivia(Plurinational Sate of)", "BO", "BOL", 068, "ISO 3166 - 2:BO", "Boliviano", "BOB", "BOB", 068, 2, "Bolivija");
        public static ISO_3166 m_Bonaire_Sint_Eustatius_and_Saba = new ISO_3166("Bonaire, Sint Eustatius and Saba", "BQ", "BES", 535, "ISO 3166 - 2:BQ", "US Dollar", "USD", "$", 840, 2, "Bonaire, Sint Eustatius and Saba");
        public static ISO_3166 m_Bosnia_and_Herzegovina = new ISO_3166("Bosnia and Herzegovina", "BA", "BIH", 070, "ISO 3166 - 2:BA", "Convertible Mark", "BAM", "BAM", 977, 2, "Bosna in Hercegovina");
        public static ISO_3166 m_Botswana = new ISO_3166("Botswana", "BW", "BWA", 072, "ISO 3166 - 2:BW", "Pula", "BWP", "BWP", 072, 2, "Bocvana");
        public static ISO_3166 m_Bouvet_Island = new ISO_3166("Bouvet Island", "BV", "BVT", 074, "ISO 3166 - 2:BV", "Norwegian Krone", "NOK", "kr", 578, 2, "Buvetovi otoki");
        public static ISO_3166 m_Brazil = new ISO_3166("Brazil", "BR", "BRA", 076, "ISO 3166 - 2:BR", "Brazilian Real", "BRL", "R$", 986, 2, "Brazilija");
        public static ISO_3166 m_British_Indian_Ocean_Territory = new ISO_3166("British Indian Ocean Territory", "IO", "IOT", 086, "ISO 3166 - 2:IO", "US Dollar", "USD", "$", 840, 2, "Britansko ozemlje v Tihem oceanu");
        public static ISO_3166 m_Brunei_Darussalam = new ISO_3166("Brunei Darussalam", "BN", "BRN", 096, "ISO 3166 - 2:BN", "Brunei Dollar", "BND", "BND", 096, 2, "Brunej");
        public static ISO_3166 m_Bulgaria = new ISO_3166("Bulgaria", "BG", "BGR", 100, "ISO 3166 - 2:BG", "Bulgarian Lev", "BGN", "лв", 975, 2, "Bolgarija");
        public static ISO_3166 m_Burkina_Faso = new ISO_3166("Burkina Faso", "BF", "BFA", 854, "ISO 3166 - 2:BF", "CFA Franc BCEAO", "XOF", "XOF", 952, 0, "Burkina Faso");
        public static ISO_3166 m_Burundi = new ISO_3166("Burundi", "BI", "BDI", 108, "ISO 3166 - 2:BI", "Burundi Franc", "BIF", "BIF", 108, 0, "Burundi");
        public static ISO_3166 m_Cambodia = new ISO_3166("Cambodia", "KH", "KHM", 116, "ISO 3166 - 2:KH", "Riel", "KHR", "KHR", 116, 2, "Kambodža");
        public static ISO_3166 m_Cameroon = new ISO_3166("Cameroon", "CM", "CMR", 120, "ISO 3166 - 2:CM", "CFA Franc BEAC", "XAF", "XAF", 950, 0, "Kamerun");
        public static ISO_3166 m_Canada = new ISO_3166("Canada", "CA", "CAN", 124, "ISO 3166 - 2:CA", "Canadian Dollar", "CAD", "$", 124, 2, "Kanada");
        public static ISO_3166 m_Cabo_Verde = new ISO_3166("Cabo Verde", "CV", "CPV", 132, "ISO 3166 - 2:CV", "Cabo Verde Escudo", "CVE", "CVE", 132, 2, "Zelenortski Otoki");
        public static ISO_3166 m_Cayman_Islands = new ISO_3166("Cayman Islands", "KY", "CYM", 136, "ISO 3166 - 2:KY", "Cayman Islands Dollar", "KYD", "KYD", 136, 2, "Kajmanski otoki");
        public static ISO_3166 m_Central_African_Republic = new ISO_3166("Central African Republic", "CF", "CAF", 140, "ISO 3166 - 2:CF", "CFA Franc BEAC", "XAF", "XAF", 950, 0, "Centralna Afriška Republika");
        public static ISO_3166 m_Chad = new ISO_3166("Chad", "TD", "TCD", 148, "ISO 3166 - 2:TD", "CFA Franc BEAC", "XAF", "XAF", 950, 0, "Čad");
        public static ISO_3166 m_Chile = new ISO_3166("Chile", "CL", "CHL", 152, "ISO 3166 - 2:CL", "Chilean Peso", "CLP", "CLP", 152, 0, "Čile");
        public static ISO_3166 m_China = new ISO_3166("China", "CN", "CHN", 156, "ISO 3166 - 2:CN", "Yuan Renminbi", "CNY", "¥", 156, 2, "Kitajska");
        public static ISO_3166 m_Christmas_Island = new ISO_3166("Christmas Island", "CX", "CXR", 162, "ISO 3166 - 2:CX", "Australian Dollar", "AUD", "$", 36, 2, "Božični otoki");
        public static ISO_3166 m_Cocos_Keeling_Islands = new ISO_3166("Cocos(Keeling)Islands", "CC", "CCK", 166, "ISO 3166 - 2:CC", "Australian Dollar", "AUD", "$", 36, 2, "Kokosovi otoki");
        public static ISO_3166 m_Colombia = new ISO_3166("Colombia", "CO", "COL", 170, "ISO 3166 - 2:CO", "Colombian Peso", "COP", "COP", 170, 2, "Kolumbija");
        public static ISO_3166 m_Comoros = new ISO_3166("Comoros", "KM", "COM", 174, "ISO 3166 - 2:KM", "Comoro Franc", "KMF", "KMF", 174, 0, "Komori");
        public static ISO_3166 m_Congo = new ISO_3166("Congo", "CG", "COG", 178, "ISO 3166 - 2:CG", "CFA Franc BEAC", "XAF", "XAF", 950, 0, "Kongo");
        public static ISO_3166 m_Congo_Democratic_Republic_of_the = new ISO_3166("Congo(Democratic Republic of the)", "CD", "COD", 180, "ISO 3166 - 2:CD", "Congolese Franc", "CDF", "CDF", 976, 2, "Kongo (Demokratična republika");
        public static ISO_3166 m_Cook_Islands = new ISO_3166("Cook Islands", "CK", "COK", 184, "ISO 3166 - 2:CK", "New Zealand Dollar", "NZD", "NZD", 554, 2, "Kukovi otoki");
        public static ISO_3166 m_Costa_Rica = new ISO_3166("Costa Rica", "CR", "CRI", 188, "ISO 3166 - 2:CR", "Costa Rican Colon", "CRC", "CRC", 188, 2, "Kostarika");
        public static ISO_3166 m_Cote_d_Ivoire = new ISO_3166("Côte d'Ivoire", "CI", "CIV", 384, "ISO 3166-2:CI", "CFA Franc BCEAO", "XOF", "XOF", 952, 0, "Côte d'Ivoire");
        public static ISO_3166 m_Croatia = new ISO_3166("Croatia", "HR", "HRV", 191, "ISO 3166 - 2:HR", "Kuna", "HRK", "kn", 191, 2, "Hrvaška");
        public static ISO_3166 m_Cuba = new ISO_3166("Cuba", "CU", "CUB", 192, "ISO 3166 - 2:CU", "Cuban Peso", "CUP", "CUP", 192, 2, "Kuba");
        public static ISO_3166 m_Curaçao = new ISO_3166("Curaçao", "CW", "CUW", 531, "ISO 3166 - 2:CW", "Netherlands Antillean Guilder", "ANG", "ANG", 532, 2, "Curaçao");
        public static ISO_3166 m_Cyprus = new ISO_3166("Cyprus", "CY", "CYP", 196, "ISO 3166 - 2:CY", "Euro", "EUR", "€", 978, 2, "Ciper");
        public static ISO_3166 m_Czech_Republic = new ISO_3166("Czech Republic", "CZ", "CZE", 203, "ISO 3166 - 2:CZ", "Czech Koruna", "CZK", "Kč", 203, 2, "Češka");
        public static ISO_3166 m_Denmark = new ISO_3166("Denmark", "DK", "DNK", 208, "ISO 3166 - 2:DK", "Danish Krone", "DKK", "kr", 208, 2, "Danska");
        public static ISO_3166 m_Djibouti = new ISO_3166("Djibouti", "DJ", "DJI", 262, "ISO 3166 - 2:DJ", "Djibouti Franc", "DJF", "DJF", 262, 2, "Džibuti");
        public static ISO_3166 m_Dominica = new ISO_3166("Dominica", "DM", "DMA", 212, "ISO 3166 - 2:DM", "East Caribbean Dollar", "XCD", "XCD", 951, 2, "Dominika");
        public static ISO_3166 m_Dominican_Republic = new ISO_3166("Dominican Republic", "DO", "DOM", 214, "ISO 3166 - 2:DO", "Dominican Peso", "DOP", "DOP", 214, 2, "Dominikanska repuplika");
        public static ISO_3166 m_Ecuador = new ISO_3166("Ecuador", "EC", "ECU", 218, "ISO 3166 - 2:EC", "US Dollar", "USD", "$", 840, 2, "Ekvador");
        public static ISO_3166 m_Egypt = new ISO_3166("Egypt", "EG", "EGY", 818, "ISO 3166 - 2:EG", "Egyptian Pound", "EGP", "EGP", 818, 2, "Egipt");
        public static ISO_3166 m_El_Salvador = new ISO_3166("El Salvador", "SV", "SLV", 222, "ISO 3166 - 2:SV", "El Salvador Colon", "SVC", "SVC", 222, 2, "Salvador");
        public static ISO_3166 m_Equatorial_Guinea = new ISO_3166("Equatorial Guinea", "GQ", "GNQ", 226, "ISO 3166 - 2:GQ", "CFA Franc BEAC", "XAF", "XAF", 950, 0, "Ekvatorialna Gvineja");
        public static ISO_3166 m_Eritrea = new ISO_3166("Eritrea", "ER", "ERI", 232, "ISO 3166 - 2:ER", "Nakfa", "ERN", "ERN", 232, 2, "Eritreja");
        public static ISO_3166 m_Estonia = new ISO_3166("Estonia", "EE", "EST", 233, "ISO 3166 - 2:EE", "Euro", "EUR", "€", 978, 2, "Estonija");
        public static ISO_3166 m_Ethiopia = new ISO_3166("Ethiopia", "ET", "ETH", 231, "ISO 3166 - 2:ET", "Ethiopian Birr", "ETB", "ETB", 230, 2, "Etiopija");
        public static ISO_3166 m_Falkland_Islands_Malvinas = new ISO_3166("Falkland Islands(Malvinas)", "FK", "FLK", 238, "ISO 3166 - 2:FK", "Falkland Islands Pound", "FKP", "FKP", 238, 2, "Falklanski otoki");
        public static ISO_3166 m_Faroe_Islands = new ISO_3166("Faroe Islands", "FO", "FRO", 234, "ISO 3166 - 2:FO", "Danish Krone", "DKK", "kr", 208, 2, "Ferski otoki");
        public static ISO_3166 m_Fiji = new ISO_3166("Fiji", "FJ", "FJI", 242, "ISO 3166 - 2:FJ", "Fiji Dollar", "FJD", "FJD", 242, 2, "Fidži");
        public static ISO_3166 m_Finland = new ISO_3166("Finland", "FI", "FIN", 246, "ISO 3166 - 2:FI", "Euro", "EUR", "€", 978, 2, "Finska");
        public static ISO_3166 m_France = new ISO_3166("France", "FR", "FRA", 250, "ISO 3166 - 2:FR", "Euro", "EUR", "€", 978, 2, "Francija");
        public static ISO_3166 m_French_Polynesia = new ISO_3166("French Polynesia", "PF", "PYF", 258, "ISO 3166 - 2:PF", "Euro", "EUR", "€", 978, 2, "Francoska Polinezija");
        public static ISO_3166 m_Gabon = new ISO_3166("Gabon", "GA", "GAB", 266, "ISO 3166 - 2:GA", "CFA Franc BEAC", "XAF", "XAF", 950, 0, "Gabon");
        public static ISO_3166 m_Gambia = new ISO_3166("Gambia", "GM", "GMB", 270, "ISO 3166 - 2:GM", "Dalasi", "GMD", "GMD", 270, 2, "Gambija");
        public static ISO_3166 m_Georgia = new ISO_3166("Georgia", "GE", "GEO", 268, "ISO 3166 - 2:GE", "Lari", "GEL", "GEL", 981, 2, "Georgija");
        public static ISO_3166 m_Germany = new ISO_3166("Germany", "DE", "DEU", 276, "ISO 3166 - 2:DE", "Euro", "EUR", "€", 978, 2, "Nemčija");
        public static ISO_3166 m_Ghana = new ISO_3166("Ghana", "GH", "GHA", 288, "ISO 3166 - 2:GH", "Ghana Cedi", "GHS", "GHS", 936, 2, "Gana");
        public static ISO_3166 m_Gibraltar = new ISO_3166("Gibraltar", "GI", "GIB", 292, "ISO 3166 - 2:GI", "Gibraltar Pound", "GIP", "GIP", 292, 2, "Gibraltar");
        public static ISO_3166 m_Greece = new ISO_3166("Greece", "GR", "GRC", 300, "ISO 3166 - 2:GR", "Euro", "EUR", "€", 978, 2, "Grčija");
        public static ISO_3166 m_Greenland = new ISO_3166("Greenland", "GL", "GRL", 304, "ISO 3166 - 2:GL", "Danish Krone", "DKK", "kr", 208, 2, "Grenlandija");
        public static ISO_3166 m_Grenada = new ISO_3166("Grenada", "GD", "GRD", 308, "ISO 3166 - 2:GD", "East Caribbean Dollar", "XCD", "XCD", 951, 2, "Grenada");
        public static ISO_3166 m_Guadeloupe = new ISO_3166("Guadeloupe", "GP", "GLP", 312, "ISO 3166 - 2:GP", "Euro", "EUR", "€", 978, 2, "Guadelupe");
        public static ISO_3166 m_Guam = new ISO_3166("Guam", "GU", "GUM", 316, "ISO 3166 - 2:GU", "US Dollar", "USD", "$", 840, 2, "Guam");
        public static ISO_3166 m_Guatemala = new ISO_3166("Guatemala", "GT", "GTM", 320, "ISO 3166 - 2:GT", "Quetzal", "GTQ", "GTQ", 320, 2, "Gvatemala");
        public static ISO_3166 m_Guernsey = new ISO_3166("Guernsey", "GG", "GGY", 831, "ISO 3166 - 2:GG", "Pound Sterling", "GBP", "£", 826, 2, "Guernsey");
        public static ISO_3166 m_Guinea = new ISO_3166("Guinea", "GN", "GIN", 324, "ISO 3166 - 2:GN", "Guinea Franc", "GNF", "GNF", 324, 0, "Gvineja");
        public static ISO_3166 m_Guinea_Bissau = new ISO_3166("Guinea- Bissau","GW","GNB",624,"ISO 3166 - 2:GW","CFA Franc BCEAO","XOF","XOF",952,0,"Gvineja Bissau" );
        public static ISO_3166 m_Guyana = new ISO_3166("Guyana", "GY", "GUY", 328, "ISO 3166 - 2:GY", "Guyana Dollar", "GYD", "GYD", 328, 2, "Gvajana");
        public static ISO_3166 m_Haiti = new ISO_3166("Haiti", "HT", "HTI", 332, "ISO 3166 - 2:HT", "Gourde", "HTG", "HTG", 332, 2, "Haiti");
        public static ISO_3166 m_Heard_Island_and_McDonald_Islands = new ISO_3166("Heard Island and McDonald Islands", "HM", "HMD", 334, "ISO 3166 - 2:HM", "Australian Dollar", "AUD", "$", 36, 2, "Otok Heard in otočje McDonald");
        public static ISO_3166 m_Holy_See = new ISO_3166("Holy See", "VA", "VAT", 336, "ISO 3166 - 2:VA", "Euro", "EUR", "€", 978, 2, "Sveti sedež");
        public static ISO_3166 m_Honduras = new ISO_3166("Honduras", "HN", "HND", 340, "ISO 3166 - 2:HN", "Lempira", "HNL", "HNL", 340, 2, "Honduras");
        public static ISO_3166 m_Hong_Kong = new ISO_3166("Hong Kong", "HK", "HKG", 344, "ISO 3166 - 2:HK", "Hong Kong Dollar", "HKD", "$", 344, 2, "Hong Kong");
        public static ISO_3166 m_Hungary = new ISO_3166("Hungary", "HU", "HUN", 348, "ISO 3166 - 2:HU", "Forint", "HUF", "Ft", 348, 2, "Madžarska");
        public static ISO_3166 m_Iceland = new ISO_3166("Iceland", "IS", "ISL", 352, "ISO 3166 - 2:IS", "Iceland Krona", "ISK", "ISK", 352, 0, "Islandija");
        public static ISO_3166 m_India = new ISO_3166("India", "IN", "IND", 356, "ISO 3166 - 2:IN", "Indian Rupee", "INR", "₹", 356, 2, "Indija");
        public static ISO_3166 m_Indonesia = new ISO_3166("Indonesia", "ID", "IDN", 360, "ISO 3166 - 2:ID", "Rupiah", "IDR", "Rp", 360, 2, "Indonezija");
        public static ISO_3166 m_Iran_Islamic_Republic = new ISO_3166("Iran(Islamic Republic of)", "IR", "IRN", 364, "ISO 3166 - 2:IR", "Iranian Rial", "IRR", "IRR", 364, 2, "Iran");
        public static ISO_3166 m_Iraq = new ISO_3166("Iraq", "IQ", "IRQ", 368, "ISO 3166 - 2:IQ", "Iraqi Dinar", "IQD", "IQD", 369, 3, "Irak");
        public static ISO_3166 m_Ireland = new ISO_3166("Ireland", "IE", "IRL", 372, "ISO 3166 - 2:IE", "Euro", "EUR", "€", 978, 2, "Irska ");
        public static ISO_3166 m_Isle_of_Man = new ISO_3166("Isle of Man", "IM", "IMN", 833, "ISO 3166 - 2:IM", "Pound Sterling", "GBP", "£", 826, 2, "Man");
        public static ISO_3166 m_Israel = new ISO_3166("Israel", "IL", "ISR", 376, "ISO 3166 - 2:IL", "New Israeli Sheqel", "ILS", "₪", 376, 2, "Izrael");
        public static ISO_3166 m_Italy = new ISO_3166("Italy", "IT", "ITA", 380, "ISO 3166 - 2:IT", "Euro", "EUR", "€", 978, 2, "Italija");
        public static ISO_3166 m_Jamaica = new ISO_3166("Jamaica", "JM", "JAM", 388, "ISO 3166 - 2:JM", "Jamaican Dollar", "JMD", "JMD", 388, 2, "Jamajka");
        public static ISO_3166 m_Japan = new ISO_3166("Japan", "JP", "JPN", 392, "ISO 3166 - 2:JP", "Yen", "JPY", "¥", 392, 0, "Japonska");
        public static ISO_3166 m_Jersey = new ISO_3166("Jersey", "JE", "JEY", 832, "ISO 3166 - 2:JE", "Pound Sterling", "GBP", "£", 826, 2, "Jersey");
        public static ISO_3166 m_Jordan = new ISO_3166("Jordan", "JO", "JOR", 400, "ISO 3166 - 2:JO", "Jordanian Dinar", "JOD", "JOD", 400, 3, "Jordanija");
        public static ISO_3166 m_Kazakhstan = new ISO_3166("Kazakhstan", "KZ", "KAZ", 398, "ISO 3166 - 2:KZ", "Tenge", "KZT", "KZT", 398, 2, "Kazahstan");
        public static ISO_3166 m_Kenya = new ISO_3166("Kenya", "KE", "KEN", 404, "ISO 3166 - 2:KE", "Kenyan Shilling", "KES", "KES", 404, 2, "Kenija");
        public static ISO_3166 m_Kiribati = new ISO_3166("Kiribati", "KI", "KIR", 296, "ISO 3166 - 2:KI", "Australian Dollar", "AUD", "$", 36, 2, "Kiribati");
        public static ISO_3166 m_Korea_Democratic_People_s_Republic = new ISO_3166("Korea(Democratic People's Republic of)", "KP", "PRK", 408, "ISO 3166-2:KP ", "North Korean Won", "KPW", "KPW", 408, 2, "Severna Koreja");
        public static ISO_3166 m_Korea_Republic = new ISO_3166("Korea(Republic of)", "KR", "KOR", 410, "ISO 3166 - 2:KR", "Won", "KRW", "₩", 410, 0, "Južna Koreja");
        public static ISO_3166 m_Kuwait = new ISO_3166("Kuwait", "KW", "KWT", 414, "ISO 3166 - 2:KW", "Kuwaiti Dinar", "KWD", "KWD", 414, 3, "Kuvajt");
        public static ISO_3166 m_Kyrgyzstan = new ISO_3166("Kyrgyzstan", "KG", "KGZ", 417, "ISO 3166 - 2:KG", "Som", "KGS", "KGS", 417, 2, "Kirgizistan");
        public static ISO_3166 m_Lao_People_Democratic_Republic = new ISO_3166("Lao People's Democratic Republic","LA","LAO",418,"ISO 3166-2:LA ","Kip","LAK","LAK",418,2,"Laos");
        public static ISO_3166 m_Latvia = new ISO_3166("Latvia", "LV", "LVA", 428, "ISO 3166 - 2:LV", "Euro", "EUR", "€", 978, 2, "Latvija ");
        public static ISO_3166 m_Lebanon = new ISO_3166("Lebanon", "LB", "LBN", 422, "ISO 3166 - 2:LB", "Lebanese Pound", "LBP", "LBP", 422, 2, "Libanon");
        public static ISO_3166 m_Lesotho = new ISO_3166("Lesotho", "LS", "LSO", 426, "ISO 3166 - 2:LS", "Loti", "LSL", "LSL", 426, 2, "Lesoto");
        public static ISO_3166 m_Liberia = new ISO_3166("Liberia", "LR", "LBR", 430, "ISO 3166 - 2:LR", "Liberian Dollar", "LRD", "LRD", 430, 2, "Liberija");
        public static ISO_3166 m_Libya = new ISO_3166("Libya", "LY", "LBY", 434, "ISO 3166 - 2:LY", "Libyan Dinar", "LYD", "LYD", 434, 3, "Libija");
        public static ISO_3166 m_Liechtenstein = new ISO_3166("Liechtenstein", "LI", "LIE", 438, "ISO 3166 - 2:LI", "Swiss Franc", "CHF", "CHF", 756, 2, "Lihtenštajn");
        public static ISO_3166 m_Lithuania = new ISO_3166("Lithuania", "LT", "LTU", 440, "ISO 3166 - 2:LT", "Euro", "EUR", "€", 978, 2, "Litva");
        public static ISO_3166 m_Luxembourg = new ISO_3166("Luxembourg", "LU", "LUX", 442, "ISO 3166 - 2:LU", "Euro", "EUR", "€", 978, 2, "Luksemburg");
        public static ISO_3166 m_Macao = new ISO_3166("Macao", "MO", "MAC", 446, "ISO 3166 - 2:MO", "Pataca", "MOP", "MOP", 446, 2, "Macao");
        public static ISO_3166 m_Macedonia_the_former_Yugoslav_Republic = new ISO_3166("Macedonia(the former Yugoslav Republic of)", "MK", "MKD", 807, "ISO 3166 - 2:MK", "Denar", "MKD", "MKD", 807, 2, "Makedonija");
        public static ISO_3166 m_Madagascar = new ISO_3166("Madagascar", "MG", "MDG", 450, "ISO 3166 - 2:MG", "Malagasy Ariary", "MGA", "MGA", 969, 2, "Madagaskar");
        public static ISO_3166 m_Malawi = new ISO_3166("Malawi", "MW", "MWI", 454, "ISO 3166 - 2:MW", "Malawi Kwacha", "MWK", "MWK", 454, 2, "Malavi");
        public static ISO_3166 m_Malaysia = new ISO_3166("Malaysia", "MY", "MYS", 458, "ISO 3166 - 2:MY", "Malaysian Ringgit", "MYR", "RM", 458, 2, "Malezija");
        public static ISO_3166 m_Maldives = new ISO_3166("Maldives", "MV", "MDV", 462, "ISO 3166 - 2:MV", "Rufiyaa", "MVR", "MVR", 462, 2, "Maldivi");
        public static ISO_3166 m_Mali = new ISO_3166("Mali", "ML", "MLI", 466, "ISO 3166 - 2:ML", "CFA Franc BCEAO", "XOF", "XOF", 952, 0, "Mali");
        public static ISO_3166 m_Malta = new ISO_3166("Malta", "MT", "MLT", 470, "ISO 3166 - 2:MT", "Euro", "EUR", "€", 978, 2, "Malta");
        public static ISO_3166 m_Marshall_Islands = new ISO_3166("Marshall Islands", "MH", "MHL", 584, "ISO 3166 - 2:MH", "US Dollar", "USD", "$", 840, 2, "Marshallovi otoki");
        public static ISO_3166 m_Martinique = new ISO_3166("Martinique", "MQ", "MTQ", 474, "ISO 3166 - 2:MQ", "Euro", "EUR", "€", 978, 2, "Martinik");
        public static ISO_3166 m_Mauritania = new ISO_3166("Mauritania", "MR", "MRT", 478, "ISO 3166 - 2:MR", "Ouguiya", "MRO", "MRO", 478, 2, "Mavretanija");
        public static ISO_3166 m_Mauritius = new ISO_3166("Mauritius", "MU", "MUS", 480, "ISO 3166 - 2:MU", "Mauritius Rupee", "MUR", "MUR", 480, 2, "Mauritius");
        public static ISO_3166 m_Mayotte = new ISO_3166("Mayotte", "YT", "MYT", 175, "ISO 3166 - 2:YT", "Euro", "EUR", "€", 978, 2, "Mayotte");
        public static ISO_3166 m_Mexico = new ISO_3166("Mexico", "MX", "MEX", 484, "ISO 3166 - 2:MX", "Mexican Peso", "MXN", "$", 484, 2, "Mehika");
        public static ISO_3166 m_Micronesia_Federated_Countrys = new ISO_3166("Micronesia(Federated Countrys of)", "FM", "FSM", 583, "ISO 3166 - 2:FM", "US Dollar", "USD", "$", 840, 2, "Mikronezija");
        public static ISO_3166 m_Moldova_Republic = new ISO_3166("Moldova(Republic of)", "MD", "MDA", 498, "ISO 3166 - 2:MD", "Moldovan Leu", "MDL", "MDL", 498, 2, "Moldavija");
        public static ISO_3166 m_Monaco = new ISO_3166("Monaco", "MC", "MCO", 492, "ISO 3166 - 2:MC", "Euro", "EUR", "€", 978, 2, "Monako");
        public static ISO_3166 m_Mongolia = new ISO_3166("Mongolia", "MN", "MNG", 496, "ISO 3166 - 2:MN", "Tugrik", "MNT", "MNT", 496, 2, "Mongolija");
        public static ISO_3166 m_Montenegro = new ISO_3166("Montenegro", "ME", "MNE", 499, "ISO 3166 - 2:ME", "Euro", "EUR", "€", 978, 2, "Črna gora");
        public static ISO_3166 m_Montserrat = new ISO_3166("Montserrat", "MS", "MSR", 500, "ISO 3166 - 2:MS", "East Caribbean Dollar", "XCD", "XCD", 951, 2, "Montserrat ");
        public static ISO_3166 m_Morocco = new ISO_3166("Morocco", "MA", "MAR", 504, "ISO 3166 - 2:MA", "Moroccan Dirham", "MAD", "MAD", 504, 2, "Maroko");
        public static ISO_3166 m_Mozambique = new ISO_3166("Mozambique", "MZ", "MOZ", 508, "ISO 3166 - 2:MZ", "Mozambique Metical", "MZN", "MZN", 943, 2, "Mozambik");
        public static ISO_3166 m_Myanmar = new ISO_3166("Myanmar", "MM", "MMR", 104, "ISO 3166 - 2:MM", "Kyat", "MMK", "MMK", 104, 2, "Mjanmar");
        public static ISO_3166 m_Namibia = new ISO_3166("Namibia", "NA", "NAM", 516, "ISO 3166 - 2:NA", "Namibia Dollar", "NAD", "NAD", 516, 2, "Namibija");
        public static ISO_3166 m_Nauru = new ISO_3166("Nauru", "NR", "NRU", 520, "ISO 3166 - 2:NR", "Australian Dollar", "AUD", "$", 36, 2, "Nauru");
        public static ISO_3166 m_Nepal = new ISO_3166("Nepal", "NP", "NPL", 524, "ISO 3166 - 2:NP", "Nepalese Rupee", "NPR", "NPR", 524, 2, "Nepal");
        public static ISO_3166 m_Netherlands = new ISO_3166("Netherlands", "NL", "NLD", 528, "ISO 3166 - 2:NL", "Euro", "EUR", "€", 978, 2, "Nizozemska");
        public static ISO_3166 m_New_Caledonia = new ISO_3166("New Caledonia", "NC", "NCL", 540, "ISO 3166 - 2:NC", "CFP Franc", "XPF", "XPF", 953, 0, "Nova Kaledonija");
        public static ISO_3166 m_New_Zealand = new ISO_3166("New Zealand", "NZ", "NZL", 554, "ISO 3166 - 2:NZ", "New Zealand Dollar", "NZD", "$", 554, 2, "Nova Zelandija");
        public static ISO_3166 m_Nicaragua = new ISO_3166("Nicaragua", "NI", "NIC", 558, "ISO 3166 - 2:NI", "Cordoba Oro", "NIO", "NIO", 558, 2, "Nikaragva");
        public static ISO_3166 m_Niger = new ISO_3166("Niger", "NE", "NER", 562, "ISO 3166 - 2:NE", "CFA Franc BCEAO", "XOF", "XOF", 952, 0, "Niger");
        public static ISO_3166 m_Nigeria = new ISO_3166("Nigeria", "NG", "NGA", 566, "ISO 3166 - 2:NG", "Naira", "NGN", "NGN", 566, 2, "Nigerija");
        public static ISO_3166 m_Niue = new ISO_3166("Niue", "NU", "NIU", 570, "ISO 3166 - 2:NU", "New Zealand Dollar", "NZD", "NZD", 554, 2, "Niue");
        public static ISO_3166 m_Norfolk_Island = new ISO_3166("Norfolk Island", "NF", "NFK", 574, "ISO 3166 - 2:NF", "Australian Dollar", "AUD", "$", 36, 2, "Norfolški otok");
        public static ISO_3166 m_Northern_Mariana_Islands = new ISO_3166("Northern Mariana Islands", "MP", "MNP", 580, "ISO 3166 - 2:MP", "US Dollar", "USD", "$", 840, 2, "Severni Marianski otoki");
        public static ISO_3166 m_Norway = new ISO_3166("Norway", "NO", "NOR", 578, "ISO 3166 - 2:NO", "Norwegian Krone", "NOK", "kr", 578, 2, "Norveška");
        public static ISO_3166 m_Oman = new ISO_3166("Oman", "OM", "OMN", 512, "ISO 3166 - 2:OM", "Rial Omani", "OMR", "OMR", 512, 3, "Oman");
        public static ISO_3166 m_Pakistan = new ISO_3166("Pakistan", "PK", "PAK", 586, "ISO 3166 - 2:PK", "Pakistan Rupee", "PKR", "PKR", 586, 2, "Pakistan");
        public static ISO_3166 m_Palau = new ISO_3166("Palau", "PW", "PLW", 585, "ISO 3166 - 2:PW", "US Dollar", "USD", "$", 840, 2, "Palau");
        public static ISO_3166 m_Palestine = new ISO_3166("Palestine, State of", "PS", "PSE", 275, "ISO 3166 - 2:PS", null, null, null, 0, 0, "Palestina");
        public static ISO_3166 m_Panama = new ISO_3166("Panama", "PA", "PAN", 591, "ISO 3166 - 2:PA", "Balboa", "PAB", "PAB", 590, 2, "Panama");
        public static ISO_3166 m_Papua_New_Guinea = new ISO_3166("Papua New Guinea", "PG", "PNG", 598, "ISO 3166 - 2:PG", "Kina", "PGK", "PGK", 598, 2, "Papua Nova Gvineja");
        public static ISO_3166 m_Paraguay = new ISO_3166("Paraguay", "PY", "PRY", 600, "ISO 3166 - 2:PY", "Guarani", "PYG", "PYG", 600, 0, "Paragvaj");
        public static ISO_3166 m_Peru = new ISO_3166("Peru", "PE", "PER", 604, "ISO 3166 - 2:PE", "Sol", "PEN", "PEN", 604, 2, "Peru");
        public static ISO_3166 m_Philippines = new ISO_3166("Philippines", "PH", "PHL", 608, "ISO 3166 - 2:PH", "Philippine Peso", "PHP", "₱", 608, 2, "Filipini");
        public static ISO_3166 m_Pitcairn = new ISO_3166("Pitcairn", "PN", "PCN", 612, "ISO 3166 - 2:PN", "New Zealand Dollar", "NZD", "NZD", 554, 2, "Pitcairnovi otoki");
        public static ISO_3166 m_Poland = new ISO_3166("Poland", "PL", "POL", 616, "ISO 3166 - 2:PL", "Zloty", "PLN", "zł", 985, 2, "Poljska");
        public static ISO_3166 m_Portugal = new ISO_3166("Portugal", "PT", "PRT", 620, "ISO 3166 - 2:PT", "Euro", "EUR", "€", 978, 2, "Portugalska");
        public static ISO_3166 m_Puerto_Rico = new ISO_3166("Puerto Rico", "PR", "PRI", 630, "ISO 3166 - 2:PR", "US Dollar", "USD", "$", 840, 2, "Portoriko");
        public static ISO_3166 m_Qatar = new ISO_3166("Qatar", "QA", "QAT", 634, "ISO 3166 - 2:QA", "Qatari Rial", "QAR", "QAR", 634, 2, "Katar");
        public static ISO_3166 m_Reunion = new ISO_3166("Réunion", "RE", "REU", 638, "ISO 3166 - 2:RE", "Euro", "EUR", "€", 978, 2, "Reunion");
        public static ISO_3166 m_Romania = new ISO_3166("Romania", "RO", "ROU", 642, "ISO 3166 - 2:RO", "Romanian Leu", "RON", "lei", 946, 2, "Romunija");
        public static ISO_3166 m_Russian_Federation = new ISO_3166("Russian Federation", "RU", "RUS", 643, "ISO 3166 - 2:RU", "Ruble", "RUB", "руб", 643, 2, "Rusija");
        public static ISO_3166 m_Rwanda = new ISO_3166("Rwanda", "RW", "RWA", 646, "ISO 3166 - 2:RW", "Rwanda Franc", "RWF", "RWF", 646, 0, "Ruanda");
        public static ISO_3166 m_Saint_Barthélemy = new ISO_3166("Saint Barthélemy", "BL", "BLM", 652, "ISO 3166 - 2:BL", "Euro", "EUR", "€", 978, 2, "Saint Barthélemy");
        public static ISO_3166 m_Saint_Helena_Ascension_and_Tristan_da_Cunha = new ISO_3166("Saint Helena, Ascension and Tristan da Cunha", "SH", "SHN", 654, "ISO 3166 - 2:SH", "Saint Helena Pound", "SHP", "SHP", 654, 2, "Sveta Helena");
        public static ISO_3166 m_Saint_Kitts_and_Nevis = new ISO_3166("Saint Kitts and Nevis", "KN", "KNA", 659, "ISO 3166 - 2:KN", "East Caribbean Dollar", "XCD", "XCD", 951, 2, "Saint Kitts in Nevis");
        public static ISO_3166 m_Saint_Lucia = new ISO_3166("Saint Lucia", "LC", "LCA", 662, "ISO 3166 - 2:LC", "East Caribbean Dollar", "XCD", "XCD", 951, 2, "Saint Lucia");
        public static ISO_3166 m_Saint_Martin_French_part = new ISO_3166("Saint Martin(French part)", "MF", "MAF", 663, "ISO 3166 - 2:MF", "Euro", "EUR", "€", 978, 2, "Saint Martin");
        public static ISO_3166 m_Saint_Pierre_and_Miquelon = new ISO_3166("Saint Pierre and Miquelon", "PM", "SPM", 666, "ISO 3166 - 2:PM", "Euro", "EUR", "€", 978, 2, "Saint Pierre and Miquelon");
        public static ISO_3166 m_Saint_Vincent_and_the_Grenadines = new ISO_3166("Saint Vincent and the Grenadines", "VC", "VCT", 670, "ISO 3166 - 2:VC", "East Caribbean Dollar", "XCD", "XCD", 951, 2, "Saint Vincent in Grenadine");
        public static ISO_3166 m_Samoa = new ISO_3166("Samoa", "WS", "WSM", 882, "ISO 3166 - 2:WS", "Tala", "WST", "WST", 882, 2, "Samoa");
        public static ISO_3166 m_San_Marino = new ISO_3166("San Marino", "SM", "SMR", 674, "ISO 3166 - 2:SM", "Euro", "EUR", "€", 978, 2, "San Marino");
        public static ISO_3166 m_Sao_Tome_and_Principe = new ISO_3166("Sao Tome and Principe", "ST", "STP", 678, "ISO 3166 - 2:ST", "Dobra", "STD", "STD", 678, 1, "Sao Tome in Principe");
        public static ISO_3166 m_Saudi_Arabia = new ISO_3166("Saudi Arabia", "SA", "SAU", 682, "ISO 3166 - 2:SA", "Saudi Riyal", "SAR", "SAR", 682, 2, "Saudova Arabija");
        public static ISO_3166 m_Senegal = new ISO_3166("Senegal", "SN", "SEN", 686, "ISO 3166 - 2:SN", "CFA Franc BCEAO", "XOF", "XOF", 952, 0, "Senegal");
        public static ISO_3166 m_Serbia = new ISO_3166("Serbia", "RS", "SRB", 688, "ISO 3166 - 2:RS", "Serbian Dinar", "RSD", "RSD", 941, 2, "Srbija");
        public static ISO_3166 m_Seychelles = new ISO_3166("Seychelles", "SC", "SYC", 690, "ISO 3166 - 2:SC", "Seychelles Rupee", "SCR", "SCR", 690, 1, "Sejšeli");
        public static ISO_3166 m_Sierra_Leone = new ISO_3166("Sierra Leone", "SL", "SLE", 694, "ISO 3166 - 2:SL", "Leone", "SLL", "SLL", 694, 2, "Sierra Leone");
        public static ISO_3166 m_Singapore = new ISO_3166("Singapore", "SG", "SGP", 702, "ISO 3166 - 2:SG", "Singapore Dollar", "SGD", "$", 702, 2, "Singapur");
        public static ISO_3166 m_Sint_Maarten_Dutch_part = new ISO_3166("Sint Maarten(Dutch part)", "SX", "SXM", 534, "ISO 3166 - 2:SX", "Netherlands Antillean Guilder", "ANG", "ANG", 532, 2, "Sint Maarten");
        public static ISO_3166 m_Slovakia = new ISO_3166("Slovakia", "SK", "SVK", 703, "ISO 3166 - 2:SK", "Euro", "EUR", "€", 978, 2, "Slovaška ");
        public static ISO_3166 m_Slovenia = new ISO_3166("Slovenia", "SI", "SVN", SLOVENIA_COUNTRY_NUM, "ISO 3166 - 2:SI", "Euro", "EUR", "€", 978, 2, "Slovenija ");
        public static ISO_3166 m_Solomon_Islands = new ISO_3166("Solomon Islands", "SB", "SLB", 090, "ISO 3166 - 2:SB", "Solomon Islands Dollar", "SBD", "SBD", 090, 2, "Salomonovi otoki");
        public static ISO_3166 m_Somalia = new ISO_3166("Somalia", "SO", "SOM", 706, "ISO 3166 - 2:SO", "Somali Shilling", "SOS", "SOS", 706, 2, "Somalija");
        public static ISO_3166 m_South_Africa = new ISO_3166("South Africa", "ZA", "ZAF", 710, "ISO 3166 - 2:ZA", "Rand", "ZAR", "S", 710, 2, "Srednjeafriška republika");
        public static ISO_3166 m_South_Georgia_and_the_South_Sandwich_Islands = new ISO_3166("South Georgia and the South Sandwich Islands", "GS", "SGS", 239, "ISO 3166 - 2:GS", null, null, null, 0, 0, "Južna Georgia in Južni Sandwichevi otoki");
        public static ISO_3166 m_South_Sudan = new ISO_3166("South Sudan", "SS", "SSD", 728, "ISO 3166 - 2:SS", "South Sudanese Pound", "SSP", "SSP", 728, 2, "Južni Sudan");
        public static ISO_3166 m_Spain = new ISO_3166("Spain", "ES", "ESP", 724, "ISO 3166 - 2:ES", "Euro", "EUR", "€", 978, 2, "Španija");
        public static ISO_3166 m_Sri_Lanka = new ISO_3166("Sri Lanka", "LK", "LKA", 144, "ISO 3166 - 2:LK", "Sri Lanka Rupee", "LKR", "LKR", 144, 2, "Šrilanka");
        public static ISO_3166 m_Sudan = new ISO_3166("Sudan", "SD", "SDN", 729, "ISO 3166 - 2:SD", "Sudanese Pound", "SDG", "SDG", 938, 2, "Sudan");
        public static ISO_3166 m_Suriname = new ISO_3166("Suriname", "SR", "SUR", 740, "ISO 3166 - 2:SR", "Surinam Dollar", "SRD", "SRD", 968, 2, "Surinam");
        public static ISO_3166 m_Svalbard_and_Jan_Mayen = new ISO_3166("Svalbard and Jan Mayen", "SJ", "SJM", 744, "ISO 3166 - 2:SJ", "Norwegian Krone", "NOK", "kr", 578, 2, "Svalbard in Jan Mayen");
        public static ISO_3166 m_Swaziland = new ISO_3166("Swaziland", "SZ", "SWZ", 748, "ISO 3166 - 2:SZ", "Lilangeni", "SZL", "SZL", 748, 2, "Svazi");
        public static ISO_3166 m_Sweden = new ISO_3166("Sweden", "SE", "SWE", 752, "ISO 3166 - 2:SE", "Swedish Krona", "SEK", "kr", 752, 2, "Švedska");
        public static ISO_3166 m_Switzerland = new ISO_3166("Switzerland", "CH", "CHE", 756, "ISO 3166 - 2:CH", "Swiss Franc", "CHF", "CHF", 756, 2, "Švica");
        public static ISO_3166 m_Syrian_Arab_Republic = new ISO_3166("Syrian Arab Republic", "SY", "SYR", 760, "ISO 3166 - 2:SY", "Syrian Pound", "SYP", "SYP", 760, 2, "Sirija");
        public static ISO_3166 m_Taiwan_Province_of_China = new ISO_3166("Taiwan, Province of China[a]", "TW", "TWN", 158, "ISO 3166 - 2:TW", "New Taiwan Dollar", "TWD", "TWD", 901, 2, "Tajvan");
        public static ISO_3166 m_Tajikistan = new ISO_3166("Tajikistan", "TJ", "TJK", 762, "ISO 3166 - 2:TJ", "Somoni", "TJS", "TJS", 972, 2, "Tadžikistan");
        public static ISO_3166 m_Tanzania_United_Republic = new ISO_3166("Tanzania, United Republic of", "TZ", "TZA", 834, "ISO 3166 - 2:TZ", "Tanzanian Shilling", "TZS", "TZS", 834, 2, "Tanzanija");
        public static ISO_3166 m_Thailand = new ISO_3166("Thailand", "TH", "THA", 764, "ISO 3166 - 2:TH", "Baht", "THB", "฿", 764, 2, "Tajska");
        public static ISO_3166 m_Timor_Leste = new ISO_3166("Timor-Leste", "TL", "TLS", 626, "ISO 3166 - 2:TL", "US Dollar", "USD", "$", 840, 2, "Vzhodni Timor");
        public static ISO_3166 m_Togo = new ISO_3166("Togo", "TG", "TGO", 768, "ISO 3166 - 2:TG", "CFA Franc BCEAO", "XOF", "XOF", 952, 0, "Togo");
        public static ISO_3166 m_Tokelau = new ISO_3166("Tokelau", "TK", "TKL", 772, "ISO 3166 - 2:TK", "New Zealand Dollar", "NZD", "NZD", 554, 2, "Tokelau");
        public static ISO_3166 m_Tonga = new ISO_3166("Tonga", "TO", "TON", 776, "ISO 3166 - 2:TO", "Pa’anga", "TOP", "TOP", 776, 2, "Tonga");
        public static ISO_3166 m_Trinidad_and_Tobago = new ISO_3166("Trinidad and Tobago", "TT", "TTO", 780, "ISO 3166 - 2:TT", "Trinidad and Tobago Dollar", "TTD", "TTD", 780, 2, "Trinidad in Tobago");
        public static ISO_3166 m_Tunisia = new ISO_3166("Tunisia", "TN", "TUN", 788, "ISO 3166 - 2:TN", "Tunisian Dinar", "TND", "TND", 788, 2, "Tunizija");
        public static ISO_3166 m_Turkey = new ISO_3166("Turkey", "TR", "TUR", 792, "ISO 3166 - 2:TR", "Turkish Lira", "TRY", "₤", 949, 2, "Turčija");
        public static ISO_3166 m_Turkmenistan = new ISO_3166("Turkmenistan", "TM", "TKM", 795, "ISO 3166 - 2:TM", "Turkmenistan New Manat", "TMT", "TMT", 934, 2, "Turkmenistan");
        public static ISO_3166 m_Turks_and_Caicos_Islands = new ISO_3166("Turks and Caicos Islands", "TC", "TCA", 796, "ISO 3166 - 2:TC", "US Dollar", "USD", "$", 840, 2, "Otoki Turks in Caicos");
        public static ISO_3166 m_Tuvalu = new ISO_3166("Tuvalu", "TV", "TUV", 798, "ISO 3166 - 2:TV", "Australian Dollar", "AUD", "$", 36, 2, "Tuvalu");
        public static ISO_3166 m_Uganda = new ISO_3166("Uganda", "UG", "UGA", 800, "ISO 3166 - 2:UG", "Uganda Shilling", "UGX", "UGX", 800, 0, "Uganda");
        public static ISO_3166 m_Ukraine = new ISO_3166("Ukraine", "UA", "UKR", 804, "ISO 3166 - 2:UA", "Hryvnia", "UAH", "UAH", 980, 2, "Ukrajina");
        public static ISO_3166 m_United_Arab_Emirates = new ISO_3166("United Arab Emirates", "AE", "ARE", 784, "ISO 3166 - 2:AE", "UAE Dirham", "AED", "AED", 784, 2, "Združeni arabski emirati");
        public static ISO_3166 m_United_Kingdom_of_Great_Britain_and_Northern_Ireland = new ISO_3166("United Kingdom of Great Britain and Northern Ireland", "GB", "GBR", 826, "ISO 3166 - 2:GB", "Pound Sterling", "GBP", "£", 826, 2, "Velika Britanija");
        public static ISO_3166 m_United_States_of_America = new ISO_3166("United States of America", "US", "USA", 840, "ISO 3166 - 2:US", "US Dollar", "USD", "$", 840, 2, "Združene države Amerike");
        public static ISO_3166 m_United_States_Minor_Outlying_Islands = new ISO_3166("United States Minor Outlying Islands", "UM", "UMI", 581, "ISO 3166 - 2:UM", "US Dollar", "USD", "$", 840, 2, "United Countrys Minor Outlying Islands");
        public static ISO_3166 m_Uruguay = new ISO_3166("Uruguay", "UY", "URY", 858, "ISO 3166 - 2:UY", "Peso Uruguayo", "UYU", "UYU", 858, 2, "Urugvaj");
        public static ISO_3166 m_Uzbekistan = new ISO_3166("Uzbekistan", "UZ", "UZB", 860, "ISO 3166 - 2:UZ", "Uzbekistan Sum", "UZS", "UZS", 860, 2, "Uzbekistan ");
        public static ISO_3166 m_Vanuatu = new ISO_3166("Vanuatu", "VU", "VUT", 548, "ISO 3166 - 2:VU", "Vatu", "VUV", "VUV", 548, 0, "Vanuatu");
        public static ISO_3166 m_Venezuela_Bolivarian_Republic = new ISO_3166("Venezuela(Bolivarian Republic of)", "VE", "VEN", 862, "ISO 3166 - 2:VE", "Bolívar", "VEF", "VEF", 937, 2, "Venezuela");
        public static ISO_3166 m_Viet_Nam = new ISO_3166("Viet Nam", "VN", "VNM", 704, "ISO 3166 - 2:VN", "Dong", "VND", "VND", 704, 0, "Vietnam");
        public static ISO_3166 m_Virgin_Islands_British = new ISO_3166("Virgin Islands(British)","VG","VGB",092,"ISO 3166 - 2:VG","US Dollar","USD","$",840,2,"Britanski Deviški otoki");
        public static ISO_3166 m_Virgin_Islands_US = new ISO_3166("Virgin Islands(U.S.)","VI","VIR",850,"ISO 3166 - 2:VI","US Dollar","USD","$",840,2,"Deviški otoki");
        public static ISO_3166 m_Wallis_and_Futuna = new ISO_3166("Wallis and Futuna", "WF", "WLF", 876, "ISO 3166 - 2:WF", "CFP Franc", "XPF", "XPF", 953, 0, "Wallis in Futuna");
        public static ISO_3166 m_Western_Sahara = new ISO_3166("Western Sahara", "EH", "ESH", 732, "ISO 3166 - 2:EH", "Moroccan Dirham", "MAD", "MAD", 504, 2, "Zahodna Sahara");
        public static ISO_3166 m_Yemen = new ISO_3166("Yemen", "YE", "YEM", 887, "ISO 3166 - 2:YE", "Yemeni Rial", "YER", "YER", 886, 2, "Jemen");
        public static ISO_3166 m_Zambia = new ISO_3166("Zambia", "ZM", "ZMB", 894, "ISO 3166 - 2:ZM", "Zambian Kwacha", "ZMW", "ZMW", 967, 2, "Zambija");
        public static ISO_3166 m_Zimbabwe = new ISO_3166("Zimbabwe", "ZW", "ZWE", 716, "ISO 3166 - 2:ZW", "Zimbabwe Dollar", "ZWL", "ZWL", 932, 2, "Zimbabve");


        public ISO_3166[] item = null;
        public DataTable dt_ISO_3166 = new DataTable();
        NavigationButtons.Navigation xnav_Form_Select_Country_ISO_3166 = null;

        public bool SetInputControls(SQLTable tbl,NavigationButtons.Navigation xnav )
        {
            //NavigationButtons.Navigation xnav_Form_Select_Country_ISO_3166 = xnav;
            if (xnav_Form_Select_Country_ISO_3166 == null)
            {
                xnav_Form_Select_Country_ISO_3166 = new NavigationButtons.Navigation(null);
                xnav_Form_Select_Country_ISO_3166.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
                xnav_Form_Select_Country_ISO_3166.bDoModal = true;
            }

            xnav_Form_Select_Country_ISO_3166.ChildDialog = new Form_Select_Country_ISO_3166(dt_ISO_3166,null,null, xnav_Form_Select_Country_ISO_3166);
            Form parent = null;
            if (xnav!=null)
            {
                parent = xnav.ChildDialog;
            }
            xnav_Form_Select_Country_ISO_3166.ShowDialog(parent);
            if ((xnav_Form_Select_Country_ISO_3166.eExitResult== NavigationButtons.Navigation.eEvent.OK)|| (xnav_Form_Select_Country_ISO_3166.eExitResult == NavigationButtons.Navigation.eEvent.NEXT))
            {
                foreach (Column col in tbl.Column)
                {
                    if (col.Name.Equals("Country"))
                    {
                        col.InputControl.SetValue(((Form_Select_Country_ISO_3166)xnav_Form_Select_Country_ISO_3166.ChildDialog).Country);
                    }
                    else if (col.Name.Equals("Country_ISO_3166_a2"))
                    {
                        col.InputControl.SetValue(((Form_Select_Country_ISO_3166)xnav_Form_Select_Country_ISO_3166.ChildDialog).Country_ISO_3166_a2);
                    }
                    else if (col.Name.Equals("Country_ISO_3166_a3"))
                    {
                        col.InputControl.SetValue(((Form_Select_Country_ISO_3166)xnav_Form_Select_Country_ISO_3166.ChildDialog).Country_ISO_3166_a3);
                    }
                    else if (col.Name.Equals("Country_ISO_3166_num"))
                    {
                        col.InputControl.SetValue(((Form_Select_Country_ISO_3166)xnav_Form_Select_Country_ISO_3166.ChildDialog).Country_ISO_3166_num);
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
            item = new ISO_3166[] {
        m_Afghanistan,
        m_Aland_Islands,
        m_Albania,
        m_Algeria,
        m_American_Samoa,
        m_Andorra,
        m_Angola,
        m_Anguilla,
        m_Antarctica,
        m_Antigua_and_Barbuda,
        m_Argentina,
        m_Armenia,
        m_Aruba,
        m_Australia,
        m_Austria,
        m_Azerbaijan,
        m_Bahamas,
        m_Bahrain,
        m_Bangladesh,
        m_Barbados,
        m_Belarus,
        m_Belgium,
        m_Belize,
        m_Benin,
        m_Bermuda,
        m_Bhutan,
        m_Bolivia_Plurinational_Sate_of,
        m_Bonaire_Sint_Eustatius_and_Saba,
        m_Bosnia_and_Herzegovina,
        m_Botswana,
        m_Bouvet_Island,
        m_Brazil,
        m_British_Indian_Ocean_Territory,
        m_Brunei_Darussalam,
        m_Bulgaria,
        m_Burkina_Faso,
        m_Burundi,
        m_Cambodia,
        m_Cameroon,
        m_Canada,
        m_Cabo_Verde,
        m_Cayman_Islands,
        m_Central_African_Republic,
        m_Chad,
        m_Chile,
        m_China,
        m_Christmas_Island,
        m_Cocos_Keeling_Islands,
        m_Colombia,
        m_Comoros,
        m_Congo,
        m_Congo_Democratic_Republic_of_the,
        m_Cook_Islands,
        m_Costa_Rica,
        m_Cote_d_Ivoire,
        m_Croatia,
        m_Cuba,
        m_Curaçao,
        m_Cyprus,
        m_Czech_Republic,
        m_Denmark,
        m_Djibouti,
        m_Dominica,
        m_Dominican_Republic,
        m_Ecuador,
        m_Egypt,
        m_El_Salvador,
        m_Equatorial_Guinea,
        m_Eritrea,
        m_Estonia,
        m_Ethiopia,
        m_Falkland_Islands_Malvinas,
        m_Faroe_Islands,
        m_Fiji,
        m_Finland,
        m_France,
        m_French_Polynesia,
        m_Gabon,
        m_Gambia,
        m_Georgia,
        m_Germany,
        m_Ghana,
        m_Gibraltar,
        m_Greece,
        m_Greenland,
        m_Grenada,
        m_Guadeloupe,
        m_Guam,
        m_Guatemala,
        m_Guernsey,
        m_Guinea,
        m_Guinea_Bissau,
        m_Guyana,
        m_Haiti,
        m_Heard_Island_and_McDonald_Islands,
        m_Holy_See,
        m_Honduras,
        m_Hong_Kong,
        m_Hungary,
        m_Iceland,
        m_India,
        m_Indonesia,
        m_Iran_Islamic_Republic,
        m_Iraq,
        m_Ireland,
        m_Isle_of_Man,
        m_Israel,
        m_Italy,
        m_Jamaica,
        m_Japan,
        m_Jersey,
        m_Jordan,
        m_Kazakhstan,
        m_Kenya,
        m_Kiribati,
        m_Korea_Democratic_People_s_Republic,
        m_Korea_Republic,
        m_Kuwait,
        m_Kyrgyzstan,
        m_Lao_People_Democratic_Republic,
        m_Latvia,
        m_Lebanon,
        m_Lesotho,
        m_Liberia,
        m_Libya,
        m_Liechtenstein,
        m_Lithuania,
        m_Luxembourg,
        m_Macao,
        m_Macedonia_the_former_Yugoslav_Republic,
        m_Madagascar,
        m_Malawi,
        m_Malaysia,
        m_Maldives,
        m_Mali,
        m_Malta,
        m_Marshall_Islands,
        m_Martinique,
        m_Mauritania,
        m_Mauritius,
        m_Mayotte,
        m_Mexico,
        m_Micronesia_Federated_Countrys,
        m_Moldova_Republic,
        m_Monaco,
        m_Mongolia,
        m_Montenegro,
        m_Montserrat,
        m_Morocco,
        m_Mozambique,
        m_Myanmar,
        m_Namibia,
        m_Nauru,
        m_Nepal,
        m_Netherlands,
        m_New_Caledonia,
        m_New_Zealand,
        m_Nicaragua,
        m_Niger,
        m_Nigeria,
        m_Niue,
        m_Norfolk_Island,
        m_Northern_Mariana_Islands,
        m_Norway,
        m_Oman,
        m_Pakistan,
        m_Palau,
        m_Palestine,
        m_Panama,
        m_Papua_New_Guinea,
        m_Paraguay,
        m_Peru,
        m_Philippines,
        m_Pitcairn,
        m_Poland,
        m_Portugal,
        m_Puerto_Rico,
        m_Qatar,
        m_Reunion,
        m_Romania,
        m_Russian_Federation,
        m_Rwanda,
        m_Saint_Barthélemy,
        m_Saint_Helena_Ascension_and_Tristan_da_Cunha,
        m_Saint_Kitts_and_Nevis,
        m_Saint_Lucia,
        m_Saint_Martin_French_part,
        m_Saint_Pierre_and_Miquelon,
        m_Saint_Vincent_and_the_Grenadines,
        m_Samoa,
        m_San_Marino,
        m_Sao_Tome_and_Principe,
        m_Saudi_Arabia,
        m_Senegal,
        m_Serbia,
        m_Seychelles,
        m_Sierra_Leone,
        m_Singapore,
        m_Sint_Maarten_Dutch_part,
        m_Slovakia,
        m_Slovenia,
        m_Solomon_Islands,
        m_Somalia,
        m_South_Africa,
        m_South_Georgia_and_the_South_Sandwich_Islands,
        m_South_Sudan,
        m_Spain,
        m_Sri_Lanka,
        m_Sudan,
        m_Suriname,
        m_Svalbard_and_Jan_Mayen,
        m_Swaziland,
        m_Sweden,
        m_Switzerland,
        m_Syrian_Arab_Republic,
        m_Taiwan_Province_of_China,
        m_Tajikistan,
        m_Tanzania_United_Republic,
        m_Thailand,
        m_Timor_Leste,
        m_Togo,
        m_Tokelau,
        m_Tonga,
        m_Trinidad_and_Tobago,
        m_Tunisia,
        m_Turkey,
        m_Turkmenistan,
        m_Turks_and_Caicos_Islands,
        m_Tuvalu,
        m_Uganda,
        m_Ukraine,
        m_United_Arab_Emirates,
        m_United_Kingdom_of_Great_Britain_and_Northern_Ireland,
        m_United_States_of_America,
        m_United_States_Minor_Outlying_Islands,
        m_Uruguay,
        m_Uzbekistan,
        m_Vanuatu,
        m_Venezuela_Bolivarian_Republic,
        m_Viet_Nam,
        m_Virgin_Islands_British,
        m_Virgin_Islands_US,
        m_Wallis_and_Futuna,
        m_Western_Sahara,
        m_Yemen,
        m_Zambia,
        m_Zimbabwe
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
                        if (item[i].State_Number == item[j].State_Number)
                        {
                            LogFile.Error.Show("ERROR:ISO_3166_Table:Tax_Rates_by_Country_List:Country Code " + item[i].State_Number.ToString() + " for \"" + item[i].State_Name + "\" is the same for country \"" + item[j].State_Name + "\"");
                        }
                    }
                }
            }

            if (dt_ISO_3166.Columns.Count == 0)
            {
                dt_ISO_3166.Columns.Add("Country", typeof(string));
                dt_ISO_3166.Columns.Add("a2", typeof(string));
                dt_ISO_3166.Columns.Add("a3", typeof(string));
                dt_ISO_3166.Columns.Add("num", typeof(short));
                dt_ISO_3166.Columns.Add("Currency Name", typeof(string));
                dt_ISO_3166.Columns.Add("Currency Abbreviation", typeof(string));
                dt_ISO_3166.Columns.Add("Currency Symbol", typeof(string));
                dt_ISO_3166.Columns.Add("Currency Code", typeof(int));
                dt_ISO_3166.Columns.Add("Currency Decimal Places", typeof(int));
            }

            foreach (ISO_3166 iso_3166 in item)
            {
                DataRow dr = dt_ISO_3166.NewRow();
                dr["Country"] = iso_3166.s_Name_In_Language.s;
                dr["a2"] = iso_3166.State_A2;
                dr["a3"] = iso_3166.State_A3;
                dr["num"] = iso_3166.State_Number;
                dr["Currency Name"] = iso_3166.Currency_Name;
                dr["Currency Abbreviation"] = iso_3166.Currency_Abbreviation;
                dr["Currency Symbol"] = iso_3166.Currency_Symbol;
                dr["Currency Code"] = iso_3166.Currency_Code;
                dr["Currency Decimal Places"] = iso_3166.Currency_DecimalPlaces;
                dt_ISO_3166.Rows.Add(dr);
            }
            DataTable dt = convertStringToDataTable(Country.Properties.Resources.ISO_4217_country_currency_table);

        }

        private DataTable convertStringToDataTable(string xmlString)
        {
            DataSet dataSet = new DataSet();
            StringReader stringReader = new StringReader(xmlString);
            dataSet.ReadXml(stringReader);
            return dataSet.Tables[0];
        }

        public string GetCurrencyName(string shortName)
        {
            foreach (ISO_3166 iso_3166 in item)
            {
                if (iso_3166.Currency_Abbreviation != null)
                {
                    if (iso_3166.Currency_Abbreviation.Equals(shortName))
                    {
                        return iso_3166.Currency_Name;
                    }
                }
            }
            return null;
        }

    }
}
