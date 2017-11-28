#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
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
            ErrorMessage = GetStackTrace(ErrorMessage);
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, "Error", null, SystemIcons.Error);
            errdlg.TopMost = true;
            errdlg.ShowDialog();
        }

        private static string GetStackTrace(string errorMessage)
        {
            if (errorMessage.Contains("STACK TRACE"))
            {
                return errorMessage;
            }
            else
            {
                return errorMessage + GetStackTrace();
            }
        }

        private static string GetStackTrace()
        {
            string stack_trace = Environment.StackTrace;
            if (stack_trace == null)
            {
                stack_trace = "\r\nNo STACK TRACE in the Environment!";
            }
            else
            {
                stack_trace = "\r\n STACK TRACE : \r\n    " + stack_trace;
            }

            return stack_trace;
        }

        public static void Show(Form pOwner, string ErrorMessage, string sErrorTitle,System.Windows.Forms.MessageBoxButtons MB_buttons, System.Windows.Forms.MessageBoxIcon MB_Icon)
        {
            ErrorMessage = GetStackTrace(ErrorMessage);
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
            ErrorMessage = GetStackTrace(ErrorMessage);
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, sErrorTitle, null, SystemIcons.Error);
            errdlg.TopMost = true;
            errdlg.ShowDialog();
        }

        public static void Show(string ErrorMessage, string sErrorTitle, Icon icon)
        {
            ErrorMessage = GetStackTrace(ErrorMessage);
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, sErrorTitle, null, icon);
            errdlg.TopMost = true;
            errdlg.ShowDialog();
        }

        public static void Show(Form pOwner, string ErrorMessage, string sErrorTitle)
        {
            ErrorMessage = GetStackTrace(ErrorMessage);
            LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "E", ErrorMessage);
            ErrorDialog errdlg = new ErrorDialog(ErrorMessage, sErrorTitle, pOwner, SystemIcons.Error);
            errdlg.TopMost = true;
            errdlg.ShowDialog(pOwner);
        }

        public static void Show(string ErrorMessage, string sErrorTitle, MessageBoxIcon messageBoxIcon)
        {
            ErrorMessage = GetStackTrace(ErrorMessage);
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
            sText = GetStackTrace(sText);
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
