using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBTypes;

namespace DBSettings_TableClass
{

    public class ReadOnly : DB_bit
    {

    }

    public class Name:DB_varchar_264
    {

    }

    public class TextValue:DB_varchar_264
    {

    }

    public class DBSettings
    {
        public ID ID = new ID();
        public Name Name = new Name();
        public TextValue TextValue = new TextValue();
    }

    public class SQL_Database_Tables_Definition
    {
        /* 1 */
        public DBSettings m_DBSettings = new DBSettings();
    }

}
