#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using Country_ISO_3166;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class xCurrencyList
    {
        public List<xCurrency> m_CurrencyList = new List<xCurrency>();
        public xCurrencyList()
        {
            m_CurrencyList.Clear();
            ISO_3166_Table iso_3166_table = new ISO_3166_Table();

            //First add EUR
            foreach (ISO_3166 iso in iso_3166_table.item)
            {
                if (iso.Currency_Name != null)
                {
                    if (iso.Currency_Code == 978) //Euro code
                    {
                        m_CurrencyList.Add(new xCurrency(iso.s_Name_In_Language.s, iso.Currency_Name, iso.Currency_Abbreviation, iso.Currency_Symbol, Convert.ToInt16(iso.Currency_Code), Convert.ToInt16(iso.Currency_DecimalPlaces)));
                        break;
                    }
                }
            }

            // add all other currencies
            foreach (ISO_3166 iso in iso_3166_table.item)
            {
                if (iso.Currency_Name != null)
                {
                    if (m_CurrencyList.FindIndex(a => a.CurrencyCode == iso.Currency_Code) >= 0)
                    {
                        continue;
                    }
                    else
                    {
                        m_CurrencyList.Add(new xCurrency(iso.s_Name_In_Language.s, iso.Currency_Name, iso.Currency_Abbreviation, iso.Currency_Symbol, Convert.ToInt16(iso.Currency_Code), Convert.ToInt16(iso.Currency_DecimalPlaces)));
                    }
                }
            }           
        }
    }
}
