using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLogDataBaseDef
{
    public class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext lngt_Office = new ltext(new string[] { "Office", "Poslovna enota" });

        public static ltext lngt_TransactionName = new ltext(new string[] { "Transaction Name", "Ime transakcije" });

        public static ltext lngt_TransactionLog = new ltext(new string[] { "Transaction Log", "Transakcijski dnevnik" });

        public static ltext lngt_CommandText = new ltext(new string[] { "Command Text", "Komandni tekst" });

        public static ltext lngt_SQLCommand = new ltext(new string[] { "SQL Command", "SQL stavek" });

        public static ltext lngt_P_Int = new ltext(new string[] { "P_Int", "P_Int" });

        public static ltext lngt_P_Decimal = new ltext(new string[] { "P_Decimal", "lngt_P_Decimal" });

        public static ltext lngt_P_Float = new ltext(new string[] { "P_Float", "P_Float" });

        public static ltext lngt_P_bit = new ltext(new string[] { "P_bit", "P_bit" });

        public static ltext lngt_P_DateTime = new ltext(new string[] { "P_DateTime", "P_DateTime" });

        public static ltext lngt_P_Nvarchar = new ltext(new string[] { "P_Nvarchar", "P_Nvarchar" });

        public static ltext lngt_P_Varchar = new ltext(new string[] { "P_Varchar", "P_Varchar" });

        public static ltext lngt_P_Nchar = new ltext(new string[] { "P_Nchar", "P_Nchar" });

        public static ltext lngt_P_Bigint = new ltext(new string[] { "P_Bigint", "P_Bigint" });

        public static ltext lngt_P_smallInt = new ltext(new string[] { "P_smallInt", "P_smallInt" });

        public static ltext lngt_P_Varbinary = new ltext(new string[] { "P_Varbinary", "P_Varbinary" });

    }
}
