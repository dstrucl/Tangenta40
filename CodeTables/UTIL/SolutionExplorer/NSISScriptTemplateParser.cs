using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionExplorer
{
    public class NSISScriptTemplateParser
    {
        private string m_Token_FilesToInstall = "FilesToInstall";
        private string m_Token_FilesToUninstall = "FilesToUninstall";

        public string Token_FilesToInstall
        {
            get { return m_Token_FilesToInstall; }
        }

        public string Token_FilesToUninstall
        {
            get { return m_Token_FilesToUninstall; }
        }

        public string DocumentText = null;

        public string FilesToInstallBlock(ref string Err)
        {

            if (Parser.dtLibraries.Rows.Count + Parser.dtExternalDll.Rows.Count > 0)
            {
                string sFilesBlock = "\r\n\r\n;--- Project Libraries -- \r\n";
                foreach (DataRow dr in Parser.dtLibraries.Rows)
                {
                    string sFile = "\r\n  File \"" + dr[Parser.dcln_AssemblyName] + "\"";
                    sFilesBlock += sFile;
                }
                sFilesBlock += "\r\n\r\n;--- External DLLs -- \r\n";
                foreach (DataRow dr in Parser.dtExternalDll.Rows)
                {
                    string sFile = "\r\n  File \"" + dr[Parser.dcln_ExternalDll_absolute_path] + "\"";
                    sFilesBlock += sFile;
                }
                sFilesBlock += "\r\n\r\n";
                return sFilesBlock;
            }
            else
            {
                Err = "No files to put in NSIS installer!";
                return null;
            }
        }

        public string FilesToUninstallBlock(ref string Err)
        {

            if (Parser.dtLibraries.Rows.Count + Parser.dtExternalDll.Rows.Count > 0)
            {
                string sFilesBlock = "\r\n\r\n;--- Remove Project Libraries -- \r\n";
                foreach (DataRow dr in Parser.dtLibraries.Rows)
                {
                    string sFile = "\r\n  Delete $INSTDIR\\\"" + System.IO.Path.GetFileName((string)dr[Parser.dcln_AssemblyName]) + "\"";
                    sFilesBlock += sFile;
                }
                sFilesBlock += "\r\n\r\n;--- Remove External DLLs -- \r\n";
                foreach (DataRow dr in Parser.dtExternalDll.Rows)
                {
                    string sFile = "\r\n  Delete $INSTDIR\\\"" + System.IO.Path.GetFileName((string)dr[Parser.dcln_ExternalDll_absolute_path]) + "\"";
                    sFilesBlock += sFile;
                }
                sFilesBlock += "\r\n\r\n";
                return sFilesBlock;
            }
            else
            {
                Err = "No files to put in NSIS installer!";
                return null;
            }
        }

        public string ReplaceDocumentText(string xToken,string sDocumentText,string sReplacementText, ref string Err)
        {
            string sReturnText = null;
            string StartToken = null;
            int iStartToken = -1;
            string EndToken = null;
            int iEndToken = -1;
            if (xToken != null)
            {
                if (xToken.Length > 0)
                {
                    if (DocumentText != null)
                    {
                        StartToken = ";<" + xToken + ">";
                        EndToken = ";</" + xToken + ">";
                        iStartToken = sDocumentText.IndexOf(StartToken);
                        if (iStartToken >= 0)
                        {
                            iStartToken += StartToken.Length;
                            iEndToken = sDocumentText.IndexOf(EndToken, iStartToken);
                            if (iEndToken>= iStartToken)
                            {
                                string sTextBlock_FirstPart = sDocumentText.Substring(0, iStartToken);
                                string sTextBlock_LastPart = sDocumentText.Substring(iEndToken);
                                sReturnText = sTextBlock_FirstPart + sReplacementText + sTextBlock_LastPart;
                            }
                            else
                            {
                                Err = "End Token " + EndToken + " not found!";
                            }
                        }
                        else
                        {
                            Err = "Start Token " + StartToken + " not found!";
                        }
                    }
                    else
                    {
                        Err = "Document text is not defined!";
                    }
                }
                else
                {
                    Err = "Token is empty string!";
                }
            }
            else
            {
                Err = "Token is not defined!";
            }
            return sReturnText;
        }
    }
}
