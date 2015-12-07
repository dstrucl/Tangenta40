using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace State_ISO_3166
{
    public class ISO_3166
    {

        private string m_Name = null;
        private string m_A2 = null;
        private string m_A3 = null;
        private string m_ISO_STANDARD = null;
        private int m_Number = -1;
        public ltext s_Name_In_Language = null;
        public string Country_Name
        {
            get { return m_Name; }
        }
        public string Country_A2
        {
            get { return m_A2; }
        }
        public string Country_A3
        {
            get { return m_A3; }
        }
        public int Country_Number
        {
            get {return m_Number;}
        }

        public ISO_3166(string xName,string xA2,string xA3, int xNumber,string xISO_STANDARD,string Slo_name)
        {
            m_Name = xName;
            m_A2 = xA2;
            m_A3 = xA3;
            m_Number = xNumber;
            m_ISO_STANDARD = xISO_STANDARD;
            s_Name_In_Language = new ltext(xName, Slo_name);
        }
    }


}
