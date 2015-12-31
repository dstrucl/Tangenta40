using DBSettings_TableClass;
using LanguageControl;
using SQLTableControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSettings_DataBaseDef
{
    public class MyDataBase_DBSettings
    {
        /* 1 */
        public SQLTable t_DBSettings = null;

        public void Define_SQL_Database_Tables(DBTableControl m_DBTables, DBSettings_TableClass.SQL_Database_Tables_Definition mt) // constructor;
        {
            /* 1 */
            t_DBSettings = new SQLTable((Object)new DBSettings(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBSettings);
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Name", "Ime nastavitve" });
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.TextValue, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new string[] { "Text value", "Vrednost" });
            m_DBTables.items.Add(t_DBSettings);
        }
    }
}
