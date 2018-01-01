using System;
using System.Diagnostics;
using System.Data;

using System.Xml;
using System.Text;
using System.Net;

namespace ECB_ExchangeRates
{
	/// <summary>
	/// Summary description for ExchangeLoad.
	/// </summary>
	public class RateLoad
	{
		private string _author = null;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public RateLoad(){}

		public string Author
		{
			get{ return _author; }
		}

		public ExchangeRate LoadNationalBankExRate()
		{
			// http://www.nationalbanken.dk/dndk/valuta.nsf/valuta.xml
			// http://www.nationalbanken.dk/DNDK/valuta.nsf/valuta-hist.xml
			// http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml
			// http://www.ecb.int/stats/eurofxref/eurofxref-hist.xml


			// Load the Xml.
			//string Address = "http://www.nationalbanken.dk/DNDK/valuta.nsf/valuta-hist.xml";
			string Address = "http://www.ecb.int/stats/eurofxref/eurofxref-hist.xml";

			ExchangeRate dsV = new ExchangeRate();

			dsV = parseWebXML(Address);

			return dsV;
		}

		private ExchangeRate parseWebXML(string WebAddress)
		{
			XmlTextReader xmlReader;

			ExchangeRate dsVa = new ExchangeRate();

			DataRow newRowVa = null;

			try
			{
				//Read data from the XML-file over the interNET
				xmlReader = new XmlTextReader(WebAddress);
			}
			catch( WebException )
			{
				throw new WebException("Der opstod fejl med at hente xmlfilen fra nettet");
			}

			try
			{
				while( xmlReader.Read() )
				{
					if (xmlReader.Name != "")
					{

						//Check that there are node call gesmes:name
						if (xmlReader.Name == "gesmes:name") 
						{
							_author = xmlReader.ReadString();
						}
						
						for (int i = 0 ; i < xmlReader.AttributeCount; i++)
						{

							//Check that there are node call Cube
							if (xmlReader.Name == "Cube") 
							{
								//Check that there are 1 attribut, then get the date
								if (xmlReader.AttributeCount == 1)
								{
									xmlReader.MoveToAttribute("time");

									DateTime tim = DateTime.Parse(xmlReader.Value);

									newRowVa = null;
									DataRow newRowCo = null;

									newRowVa = dsVa.Exchange.NewRow();
									newRowVa["Date"]= tim;
									dsVa.Exchange.Rows.Add(newRowVa);

									if( 0 < WebAddress.IndexOf("www.nationalbanken",0,WebAddress.Length))
									{
										newRowCo = dsVa.Country.NewRow();
										newRowCo["Initial"]= "DKK";
										newRowCo["Name"]= "Danske Kroner";
										newRowCo["Rate"]= 100.0;
										dsVa.Country.Rows.Add(newRowCo);
									}
									else
									{
										newRowCo = dsVa.Country.NewRow();
										newRowCo["Initial"]= "EUR";
										newRowCo["Name"]= convert.MoneyName("EUR");
										newRowCo["Rate"]= 1.0;
										dsVa.Country.Rows.Add(newRowCo);
									}
									newRowCo.SetParentRow(newRowVa);			
								}

								//If the number of attributs are 2, so get the ExchangeRate-node
								if (xmlReader.AttributeCount == 2)
								{
									xmlReader.MoveToAttribute("currency");
									string cur = xmlReader.Value;
                  
									xmlReader.MoveToAttribute("rate");
									decimal rat = decimal.Parse(xmlReader.Value.Replace(".",","));

									DataRow newRowCo = null;

									newRowCo = dsVa.Country.NewRow();
									newRowCo["Initial"]= cur;
									newRowCo["Name"]= convert.MoneyName(cur);
									newRowCo["Rate"]= rat;
									dsVa.Country.Rows.Add(newRowCo);

									newRowCo.SetParentRow(newRowVa);	
								}

								//If the number of attributs are 3, so get the ExchangeRate-node
								if (xmlReader.AttributeCount == 3)
								{
									xmlReader.MoveToAttribute("currency");
									string cur = xmlReader.Value;
                   
									xmlReader.MoveToAttribute("rate");
									decimal rat = 0;
									if( 0 <= xmlReader.Value.ToString().IndexOf("-",0,xmlReader.Value.ToString().Length) )
										rat = 0;
									else
										rat = decimal.Parse(xmlReader.Value.Replace(".",","));

									xmlReader.MoveToAttribute("name");
									string name = xmlReader.Value;

									DataRow newRowCo = null;

									newRowCo = dsVa.Country.NewRow();
									newRowCo["Initial"]= cur;
									newRowCo["Name"]= name;
									newRowCo["Rate"]= rat;
									dsVa.Country.Rows.Add(newRowCo);

									newRowCo.SetParentRow(newRowVa);	
								}
							}
							xmlReader.MoveToNextAttribute();
						}
					}
				}
			}
			catch( WebException )
			{
				throw new WebException("connections lost");
			}

			return dsVa;
		}

	}
}
