using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopC_Forms
{
    public class ConsumptionType
    {
        private string m_ConsumptionType_Text_in_language = null;

        public string  ConsumptionType_Text_in_language
        {
            get { return m_ConsumptionType_Text_in_language; }
        }

        private string m_Typ = null;

        public string Typ
        {
            get { return m_Typ; }
        }


        public ConsumptionType(string doctype_name_in_Language,string doc_type)
        {
            m_ConsumptionType_Text_in_language = doctype_name_in_Language;
            m_Typ = doc_type;
        }
    }
}
