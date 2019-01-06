using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManager
{
    public class DocType
    {
        private string m_DocType_Text_in_language = null;

        public string  DocType_Text_in_language
        {
            get { return m_DocType_Text_in_language; }
        }

        private string m_Typ = null;

        public string Typ
        {
            get { return m_Typ; }
        }


        public DocType(string doctype_name_in_Language,string doc_type)
        {
            m_DocType_Text_in_language = doctype_name_in_Language;
            m_Typ = doc_type;
        }
    }
}
