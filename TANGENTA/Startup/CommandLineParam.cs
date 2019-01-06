using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup
{
    public static class CommandLineParam
    {
        public enum eCommandLineHelpResult { OK, DO_SELECT_LANGUAGE, EXIT }

        #region Constants
        public const string const_command_DOCINVOICE = "DOCINVOICE";
        public const string const_command_DOCPROFORMAINVOICE = "DOCPROFORMAINVOICE";
        public const string const_command_CHANGE_CONNECTION = "CHANGE-CONNECTION";
        public const string const_command_RESETNEW = "RESETNEW";
        public const string const_command_AUTONEXT = "AUTONEXT";
        public const string const_command_DIAGNOSTIC = "DIAGNOSTIC";
        public const string const_command_SYMULATOR = "SYMULATOR";
        public const string const_command_RS232MONITOR = "RS232MONITOR";
        public const string const_command_TRANSACTION_MONITOR = "TRANSACTION-MONITOR";
        public const string const_command_TRANSACTION_BREAK_DIALOG = "TRANSACTION-BREAK-DIALOG";
        public const string const_command_STARTUP_CHECK_COLUMNS = "STARTUP-CHECK-COLUMNS";
        #endregion

        public static List<CommandLineHelp.CommandLineHelp> command_line_help = new List<CommandLineHelp.CommandLineHelp>();

        public static bool bResetNew = false;
        public static bool bChangeConnection = false;
        public static bool bSymulator = false;
        public static bool bRS232Monitor = false;
        public static bool bTransactionMonitor = false;
        public static bool bBreakOnTransactionDialog = false;
        public static bool bStartupCheckColumns = false;

        public static bool bShowCommandLineHelp = false;
        public static bool bDemo = false;

        public static bool m_bProgramDiagnostic = false;

    }
}
