using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManager
{
    public static class OperationMode
    {
        internal static bool MultiUser = true;
        internal static bool SingleUserLoginAsAdministrator = false;
        internal static bool StockCheckAtStartup = true;
        internal static bool ShopC_ExclusivelySellFromStock = false;
        internal static bool MultiCurrency = false;
        internal static int NumberOfMonthAfterNewYearToAllowCreateNewInvoice = 1;
        internal static bool FiscalVerificationOfInvoices = false;
    }
}
