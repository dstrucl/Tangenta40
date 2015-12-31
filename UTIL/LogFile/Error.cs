using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace LogFile
{
    public static class Error
    {
        public static void Show(string ErrorMessage)
        {
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage,"Error",null,SystemIcons.Error);
            errdlg.TopMost = true;
            errdlg.ShowDialog();
        }

        public static void Show(Form pOwner, string ErrorMessage, string sErrorTitle,System.Windows.Forms.MessageBoxButtons MB_buttons, System.Windows.Forms.MessageBoxIcon MB_Icon)
        {
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", ErrorMessage);
            Icon icon = null;
            switch (MB_Icon)
            {
                case System.Windows.Forms.MessageBoxIcon.None:
                    icon = null;
                    break;

                case System.Windows.Forms.MessageBoxIcon.Error:
                    icon = SystemIcons.Error;
                    break;

                case System.Windows.Forms.MessageBoxIcon.Question:
                    icon = SystemIcons.Question;
                    break;

                case System.Windows.Forms.MessageBoxIcon.Exclamation:
                    icon = SystemIcons.Exclamation;
                    break;


                case System.Windows.Forms.MessageBoxIcon.Information:
                    icon = SystemIcons.Information;
                    break;

            }
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, sErrorTitle, pOwner, icon);
            errdlg.TopMost = true;
            errdlg.ShowDialog(pOwner);
        }

        public static void Show(string ErrorMessage, string sErrorTitle)
        {
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, sErrorTitle, null, SystemIcons.Error);
            errdlg.TopMost = true;
            errdlg.ShowDialog();
        }

        public static void Show(string ErrorMessage, string sErrorTitle, Icon icon)
        {
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, sErrorTitle, null, icon);
            errdlg.TopMost = true;
            errdlg.ShowDialog();
        }

        public static void Show(Form pOwner, string ErrorMessage, string sErrorTitle)
        {
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, sErrorTitle, pOwner, SystemIcons.Error);
            errdlg.TopMost = true;
            errdlg.ShowDialog(pOwner);
        }

        public static void Show(string ErrorMessage, string sErrorTitle, MessageBoxIcon messageBoxIcon)
        {

            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", ErrorMessage);
            Icon icon = null;
            switch (messageBoxIcon)
            {
                case System.Windows.Forms.MessageBoxIcon.None:
                    icon = null;
                    break;

                case System.Windows.Forms.MessageBoxIcon.Error:
                    icon = SystemIcons.Error;
                    break;

                case System.Windows.Forms.MessageBoxIcon.Question:
                    icon = SystemIcons.Question;
                    break;

                case System.Windows.Forms.MessageBoxIcon.Exclamation:
                    icon = SystemIcons.Exclamation;
                    break;


                case System.Windows.Forms.MessageBoxIcon.Information:
                    icon = SystemIcons.Information;
                    break;

            }
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, sErrorTitle, null, icon);
            errdlg.TopMost = true;
            errdlg.ShowDialog(null);
        }

        public static void Show(string sText, string sTitle, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", sText);
            Icon icon = null;
            switch (messageBoxIcon)
            {
                case System.Windows.Forms.MessageBoxIcon.None:
                    icon = null;
                    break;

                case System.Windows.Forms.MessageBoxIcon.Error:
                    icon = SystemIcons.Error;
                    break;

                case System.Windows.Forms.MessageBoxIcon.Question:
                    icon = SystemIcons.Question;
                    break;

                case System.Windows.Forms.MessageBoxIcon.Exclamation:
                    icon = SystemIcons.Exclamation;
                    break;


                case System.Windows.Forms.MessageBoxIcon.Information:
                    icon = SystemIcons.Information;
                    break;

            }
            ErrorDialog errdlg = new ErrorDialog(sText, sTitle, null, messageBoxButtons, icon);        
            errdlg.TopMost = true;
            errdlg.ShowDialog();
        }
    }

    public static class Warning
    {
        public static void Show(string ErrorMessage)
        {

            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "W", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, " Warning", null, SystemIcons.Warning);
            errdlg.TopMost = true;
            errdlg.ShowDialog();
        }

        public static void Show(string ErrorMessage, string sTitle)
        {
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "W", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, sTitle, null, SystemIcons.Warning);
            errdlg.TopMost = true;
            errdlg.ShowDialog();
        }

        public static void Show(Form pOwner, string ErrorMessage, string sErrorTitle)
        {
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "W", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, sErrorTitle, pOwner, SystemIcons.Warning);
            errdlg.TopMost = true;
            errdlg.ShowDialog(pOwner);
        }

    }
}
