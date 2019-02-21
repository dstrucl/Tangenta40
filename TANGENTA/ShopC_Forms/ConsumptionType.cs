using DBConnectionControl40;
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

        private string m_ConsumptionType_Name = null;

        public string ConsumptionType_Name
        {
            get { return m_ConsumptionType_Name; }
        }

        private string m_ConsumptionType_Description = null;

        public string ConsumptionType_Description
        {
            get { return m_ConsumptionType_Description; }
        }

        private ID m_ConsumptionType_ID = null;

        public ID ConsumptionType_ID
        {
            get { return m_ConsumptionType_ID; }
        }


        public long ConsumptionType_ID_as_long
        {
            get { 
                    if (ID.Validate(ConsumptionType_ID))
                    {
                        return (long)ConsumptionType_ID.V;
                    }
                    else
                    {
                        return -1;
                    }
                 }
        }

        public ConsumptionType(string consumptionType_Name_in_Language,string consumptionType_Name, ID xConsumptionType_ID )
        {
            m_ConsumptionType_Text_in_language = consumptionType_Name_in_Language;
            m_ConsumptionType_Name = consumptionType_Name;
            m_ConsumptionType_ID = xConsumptionType_ID;
        }
    }
}
