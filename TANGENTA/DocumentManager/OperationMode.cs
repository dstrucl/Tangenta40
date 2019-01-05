using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManager
{
    public static class OperationMode
    {
        public static bool MultiUser = true;
        public static bool SingleUserLoginAsAdministrator = false;
        public static bool StockCheckAtStartup = true;
        public static bool ShopC_ExclusivelySellFromStock = false;
        public static bool MultiCurrency = false;
        public static int NumberOfMonthAfterNewYearToAllowCreateNewInvoice = 1;
        public static bool FiscalVerificationOfInvoices = false;
    }
}
