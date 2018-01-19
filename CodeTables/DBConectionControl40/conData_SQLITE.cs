#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DBConnectionControl40
{
    public class conData_SQLITE
    {
        int[] encrypt_num = new int[32] { 1, 2, -3, 4, 5, -6, 7, -8, 9, -10, 11, 12, 13, 14, 15, 16, 7, 8, 9, 2, 1, 2, 3, 4, 5, 6, 7, 8, 9, -1, 1, -2 };

        private bool bSQLite_AllwaysCreateNew = false;

        internal Crypt m_Crypt;

        private string m_DataBaseFilePath = null;
        private string m_DataBaseFileName = null;

        public string DataBaseFileName
        {
            get
            {
                return m_DataBaseFileName;
            }
            set
            {
                m_DataBaseFileName = value;
            }
        }

        public string DataBaseFilePath
        {
            get
            {
                return m_DataBaseFilePath;
            }
            set
            {
                m_DataBaseFilePath = value;
            }
        }

        internal string m_crypted_Password = null;
        
        public bool SQLite_AllwaysCreateNew
        {
            get
            {
                return bSQLite_AllwaysCreateNew;
            }
            set
            {
                bSQLite_AllwaysCreateNew = value;
            }
        }

        public DateTime DataBaseFileCreationTime
        {
            get
            {
                return File.GetCreationTime(DataBaseFile);
            }
        }


        public string DataBaseFile
        {
            get
            {
                try
                { 
                        if (m_DataBaseFilePath != null)
                        {
                            if (m_DataBaseFileName != null)
                            {
                                return m_DataBaseFilePath + m_DataBaseFileName;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:DataBaseFile:" + ex.Message);
                    }
                
                return null;
            }
            set
            {
                try
                {

                    string sFile = value;
                    if (sFile.Length > 0)
                    {
                        m_DataBaseFilePath = Path.GetDirectoryName(sFile) + "\\";
                        m_DataBaseFileName = Path.GetFileName(sFile);
                    }
                    else
                    {
                        m_DataBaseFilePath = "";
                        m_DataBaseFileName = "";
                    }
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("Error setting property DataBaseFile:", ex.Message);
                }
            }
        }

        public conData_SQLITE(string xDataBaseFile, string xPassword)
        {
            DataBaseFile = xDataBaseFile;
            m_crypted_Password = xPassword;
            m_Crypt = new Crypt(encrypt_num);
        }

        public conData_SQLITE(string xDataBaseFilePath, string xDataBaseFileName, string Password)
        {
            m_DataBaseFilePath = xDataBaseFilePath;
            m_DataBaseFileName = xDataBaseFileName;
        }

        public conData_SQLITE()
        {
            
        }

        internal string GetConnectionString()
        {
            if (m_crypted_Password != null)
            {
                return "Data Source=" + DataBaseFile + ";Version=3;foreign keys=true;Legacy Format=True; Password = " + m_Crypt.DecryptString(m_crypted_Password) + ";";
            }
            else
            {
                return "Data Source=" + DataBaseFile + ";Version=3;foreign keys=true;";
            }

            //return "Data Source=" + DataBaseFile + ";";
        }

        internal bool IsValidDataBaseFilePath()
        {
            if (m_DataBaseFilePath != null)
            {
                if (m_DataBaseFilePath.Length > 0)
                {
                    char[] chInvalid = Path.GetInvalidPathChars();
                    foreach (char ch in chInvalid)
                    {
                        if (m_DataBaseFilePath.Contains(ch))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        internal bool IsValidDataBaseFileName()
        {
            if (m_DataBaseFileName != null)
            {
                if (m_DataBaseFileName.Length > 0)
                {
                    char[] chInvalid = Path.GetInvalidFileNameChars();
                    foreach (char ch in chInvalid)
                    {
                        if (m_DataBaseFileName.Contains(ch))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        internal bool IsValidDataBaseFile()
        {
            return (IsValidDataBaseFilePath() && IsValidDataBaseFileName());
        }
    }
}
