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
        
        public static ltext lngt_TransactionLog = new ltext(new string[] { "Transaction Log", "Transakcijski dnevnik" });

        public static ltext lngt_SQLCommand = new ltext(new string[] { "SQL Command", "SQL stavek" });

        public static ltext lngt_P_Int32 = new ltext(new string[] { "P_Int32", "P_Int32" });

        public static ltext lngt_P_Int64 = new ltext(new string[] { "P_Int64", "P_Int64" });

        public static ltext lngt_P_Money = new ltext(new string[] { "P_Money", "P_Money" });

        public static ltext lngt_P_Decimal = new ltext(new string[] { "P_Decimal", "lngt_P_Decimal" });

        public static ltext lngt_P_Percent = new ltext(new string[] { "P_Percent", "P_Percent" });

        public static ltext lngt_P_smallInt = new ltext(new string[] { "P_smallInt", "P_smallInt" });

        public static ltext lngt_P_bit = new ltext(new string[] { "P_bit", "P_bit" });

        public static ltext lngt_P_DateTime = new ltext(new string[] { "P_DateTime", "P_DateTime" });

        public static ltext lngt_P_varbinary_max = new ltext(new string[] { "P_varbinary_max", "P_varbinary_max" });

        public static ltext lngt_P_varchar_264 = new ltext(new string[] { "P_varchar_264", "P_varchar_264" });

        public static ltext lngt_P_varchar_250 = new ltext(new string[] { "P_varchar_250", "P_varchar_250" });

        public static ltext lngt_P_varchar_64 = new ltext(new string[] { "P_varchar_64", "P_varchar_64" });

        public static ltext lngt_P_varchar_50 = new ltext(new string[] { "P_varchar_50", "P_varchar_50" });

        public static ltext lngt_P_varchar_45 = new ltext(new string[] { "P_varchar_45", "P_varchar_45" });

        public static ltext lngt_P_varchar_32 = new ltext(new string[] { "P_varchar_32", "P_varchar_32" });

        public static ltext lngt_P_varchar_25 = new ltext(new string[] { "P_varchar_25", "P_varchar_25" });

        public static ltext lngt_P_varchar_10 = new ltext(new string[] { "P_varchar_10", "P_varchar_10" });

        public static ltext lngt_P_varchar_5 = new ltext(new string[] { "P_varchar_5", "P_varchar_5" });

        public static ltext lngt_P_varchar_2000 = new ltext(new string[] { "P_varchar_2000", "P_varchar_2000" });

        public static ltext lngt_P_varchar_max = new ltext(new string[] { "P_varchar_max", "P_varchar_max" });

        public static ltext lngt_P_Document = new ltext(new string[] { "P_Document", "P_Document" });

        public static ltext lngt_P_Image = new ltext(new string[] { "P_Image", "P_Image" });

    }
}
