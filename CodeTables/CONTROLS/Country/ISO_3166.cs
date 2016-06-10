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


namespace Country_ISO_3166
{
    public class ISO_3166
    {

        private string m_Name = null;
        private string m_A2 = null;
        private string m_A3 = null;
        private string m_ISO_STANDARD = null;
        private int m_Number = -1;
        private string m_Currency_Abbreviation = null;
        private string m_Currency_Name = null;
        private string m_Currency_Symbol = null;
        private int m_Currency_Code = 0;
        private int m_Currency_DecimalPlaces = 0;

        public ltext s_Name_In_Language = null;

        public string Currency_Abbreviation
        {
            get { return m_Currency_Abbreviation; }
        }

        public string Currency_Name
        {
            get { return m_Currency_Name; }
        }
        public string Currency_Symbol
        {
            get { return m_Currency_Symbol; }
        }

        public int Currency_Code
        {
            get { return m_Currency_Code; }
        }

        public int Currency_DecimalPlaces
        {
            get { return m_Currency_DecimalPlaces; }
        }


        public string State_Name
        {
            get { return m_Name; }
        }
        public string State_A2
        {
            get { return m_A2; }
        }
        public string State_A3
        {
            get { return m_A3; }
        }
        public int State_Number
        {
            get {return m_Number;}
        }

        public ISO_3166(string xName, string xA2, string xA3, int xNumber, string xISO_STANDARD,string xCurrency_Name,string xCurrency_Abbreviation, string xCurrency_Symbol,int xCurrency_Code, int xCurrency_DecimalPlaces, string Slo_name)
        {
            m_Name = xName;
            m_A2 = xA2;
            m_A3 = xA3;
            m_Number = xNumber;
            m_ISO_STANDARD = xISO_STANDARD;
            m_Currency_Name = xCurrency_Name;
            m_Currency_Abbreviation = xCurrency_Abbreviation;
            m_Currency_Symbol = xCurrency_Symbol;
            m_Currency_Code = xCurrency_Code;
            m_Currency_DecimalPlaces = xCurrency_DecimalPlaces;
            s_Name_In_Language = new ltext(xName, Slo_name);
        }
    }
}
