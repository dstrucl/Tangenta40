using Country_ISO_3166;
using System;

namespace ECB_ExchangeRates
{

	/// <summary>
	/// Summary description for convert.
	/// </summary>
	public class convert
	{
        ISO_3166_Table xISO_3166_Table = new ISO_3166_Table();

        public convert()
		{
			//
			// TODO: Add constructor logic here
			//
			//http://www.oanda.com/site/help/iso_code.shtml
			//  This index lists currency ISO codes by country and precious metal. You can also find an ISO currency code by code.
		}

		public string MoneyName(string shortName)
		{

            string returnvalue = null;

            returnvalue = xISO_3166_Table.GetCurrencyName(shortName);

			return returnvalue;
		}
	}
}

