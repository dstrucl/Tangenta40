using System;

namespace ECB_ExchangeRates
{

	/// <summary>
	/// Summary description for convert.
	/// </summary>
	public class convert
	{
		public convert()
		{
			//
			// TODO: Add constructor logic here
			//
			//http://www.oanda.com/site/help/iso_code.shtml
			//  This index lists currency ISO codes by country and precious metal. You can also find an ISO currency code by code.
		}

		static public string MoneyName(string shortName)
		{
			string returnvalue = "NULL";
			switch(shortName)
			{
				case "DKK":  returnvalue = "Danish Krone"; break;
				case "EUR":  returnvalue = "Euro"; break;
				case "USD":  returnvalue = "US Dollar" ; break;
				case "GBP":  returnvalue = "United Kingdom Pound"; break;
				case "SEK":  returnvalue = "Swedish Krona"; break;
				case "NOK":  returnvalue = "Norwegian Kroner"; break;
				case "CNY":	 returnvalue = "Chinese Yuan Renminbi"; break;
				case "ISK":  returnvalue = "Islandske Kroner"; break;
				case "IDR":	 returnvalue = "Indonesian Rupiah"; break;
				case "CHF":  returnvalue = "Schweiziske Franc"; break;
				case "CAD":  returnvalue = "Canadian Dollar"; break;
				case "JPY":  returnvalue = "Japanese Yen"; break;
				case "RUB":  returnvalue = "Russian Rouble"; break;
				case "HRK":  returnvalue = "Croatian Kuna"; break;
				case "MYR":	 returnvalue = "Malaysian Ringgit"; break;
				case "PHP":	 returnvalue = "Philippine Peso"; break;
				case "THB":	 returnvalue = "Thai Baht"; break;
				case "AUD":  returnvalue = "Australske Dollars"; break;
				case "NZD":  returnvalue = "New Zealand. Dollar"; break;
				case "EEK":  returnvalue = "Estiske Kroon"; break;
				case "LVL":  returnvalue = "Lettiske Lats"; break;
				case "LTL":  returnvalue = "Litauiske Litas"; break;
				case "PLN":  returnvalue = "Polske Zloty"; break;
				case "CZK":  returnvalue = "Tjekkiske Koruna"; break;
				case "HUF":  returnvalue = "Ungarske Forint"; break;
				case "HKD":  returnvalue = "Hongkong Dollar"; break;
				case "SGD":  returnvalue = "Singapore Dollar"; break;
				case "SDR":  returnvalue = "Special Drawing Rights"; break;
				case "BGN":  returnvalue = "Bulgarske lev"; break;
				case "CYP":  returnvalue = "Cypriotiske pund"; break;
				case "MTL":  returnvalue = "Maltesiske lira"; break;
				case "ROL":  returnvalue = "Rumænske lei"; break;
				case "SIT":  returnvalue = "Slovenske tolar"; break;
				case "SKK":  returnvalue = "Slovakiske koruna"; break;
				case "TRY":  returnvalue = "Tyrkiske lira"; break;
				case "KRW":  returnvalue = "Sydkoreanske won"; break;
				case "ZAR":  returnvalue = "Sydafrikanske rand"; break;
				default: break;
			}

			return returnvalue;
		}
	}
}

