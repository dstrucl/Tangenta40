using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using DBTypes;
using System.Windows.Forms;
using SQLTableControl;
using LanguageControl;


namespace SQLTableControl
{
    public class SourceText
    {
        public String FileName;
        public String sLine;
        public int iLine;
        StreamReader reader = null;
        public SourceText(string fName)
        {
            FileName = fName;
            iLine = 0;
            sLine = "";
        }

        public DialogResult ShowParseError(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon Icon)
        {
            ParseErrorDialog ParseErrorDlg = new ParseErrorDialog(this, Globals.MainWindow, message, caption);
            if (Globals.MainWindow.GetType() == typeof(Form))
            {
                ParseErrorDlg.MdiParent = (Form)Globals.MainWindow;
            }
            else if (Globals.MainWindow.GetType().BaseType == typeof(Form))
            {
                ParseErrorDlg.MdiParent = (Form)Globals.MainWindow;
            }

            ParseErrorDlg.Show();
            return DialogResult.OK;
        }

        public bool CloseText()
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
                reader = null;
                return true;
            }
            else
            {
                MessageBox.Show(lngRPM.s_File_Not_Opened.s + ":" + FileName + "\n", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool OpenText()
        {
            if (reader == null)
            {
                try
                {
                    reader = File.OpenText(FileName);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(lngRPM.s_File_Not_Opened.s + ":" + FileName + "\n" + ex.Message, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(lngRPM.s_File_allready_Opened.s + ":" + FileName, lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool ReadLine()
        {
            for (; ; )
            {
                if (reader.EndOfStream)
                {
                    return false;
                }
                sLine = reader.ReadLine();
                this.iLine++;
                if (sLine.Length >= 2)
                {
                    if (!((sLine.Substring(0, 2).Equals("\\\\")) || (sLine.Substring(0, 2).Equals("//"))))
                    {
                        return true;
                    }
                }
            }
        }

        public bool EndOfStream()
        {
            if (reader != null)
            {
                return reader.EndOfStream;
            }
            else
            {
                MessageBox.Show(lngRPM.s_File_Not_Opened.s + ":" + FileName + "\n", lngRPM.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
        }
    }
}
