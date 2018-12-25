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

namespace LogFile
{

    public class conData_MSSQL
    {


        int[] encrypt_num = new int[32] { 1, 2, -3, 4, 5, -6, 7, -8, 9, -10, 11, 12, 13, 14, 15, 16, 7, 8, 9, 2, 1, 2, 3, 4, 5, 6, 7, 8, 9, -1, 1, -2 };

        internal bool m_bWindowsAuthentication = true;

        public string m_DataSource = "";

        public string m_DataBase = "";
        public string m_strDataBaseFilePath = "";
        public string m_strDataBaseLogFilePath = "";
        public string m_UserName;
        public string m_crypted_Password;
        public string m_WindowsAuthentication_UserName = SystemInformation.UserDomainName + "\\" + SystemInformation.UserName;
        internal Crypt m_Crypt;
        public int m_TryToConnectTimeout_in_seconds = 60;


        public conData_MSSQL(      bool xbWindowsAuthentication,
                                   string xDataSource,
                                   string xDataBase,
                                   string xUserName,
                                   string x_crypted_Password,
                                   string xstrDataBaseFilePath,
                                   string xstrDataBaseLogFilePath,
                                   int xTryToConnectTimeout_in_seconds)
        {
                m_DataSource = xDataSource;
                m_DataBase = xDataBase;
                m_UserName = xUserName;
                m_crypted_Password = x_crypted_Password;
                m_bWindowsAuthentication = xbWindowsAuthentication;
                m_strDataBaseFilePath = xstrDataBaseFilePath;
                m_strDataBaseLogFilePath = xstrDataBaseLogFilePath;
                m_Crypt = new Crypt(encrypt_num);
                m_TryToConnectTimeout_in_seconds = xTryToConnectTimeout_in_seconds;
        }


        public conData_MSSQL()
        {
            m_DataSource = "";
            m_DataBase = "";
            m_UserName = "";
            m_crypted_Password = "";
            m_bWindowsAuthentication = false;
            m_strDataBaseFilePath = "";
            m_strDataBaseLogFilePath = "";
            m_Crypt = new Crypt(encrypt_num);
            m_TryToConnectTimeout_in_seconds = 60;
        }

        public string GetConnectionString()
        {

            if (m_bWindowsAuthentication)
                return "Data Source=" + m_DataSource + ";Initial Catalog=" + m_DataBase + ";Integrated Security=True;Connect Timeout=" + m_TryToConnectTimeout_in_seconds.ToString();
            else
                return "Data Source=" + m_DataSource + ";Initial Catalog=" + m_DataBase + ";Persist Security Info=True;User ID=" + m_UserName + ";Password=" + m_Crypt.DecryptString(m_crypted_Password) + ";Connect Timeout=" + m_TryToConnectTimeout_in_seconds.ToString();; 

        }

        public string GetServerConnectionString()
        {

            if (m_bWindowsAuthentication)
                return "Data Source=" + m_DataSource + ";Initial Catalog=\"\";Integrated Security=True";
            else
                return "Data Source=" + m_DataSource + ";Initial Catalog=\"\";Persist Security Info=True;User ID=" + m_UserName + ";Password=" + m_Crypt.DecryptString(m_crypted_Password);
        }



        public void WriteProp(Action<string> setOutput, string s)
        {
            setOutput(s);
        }

        public bool Equals(conData_MSSQL xConData)
        {
            if ((this.m_bWindowsAuthentication == xConData.m_bWindowsAuthentication))
            {
                if (this.m_bWindowsAuthentication)
                {
                    return true;
                }
                else
                {
                    if (this.m_DataSource.Equals(xConData.m_DataSource) &&
                       this.m_DataBase.Equals(xConData.m_DataBase) &&
                       this.m_UserName.Equals(xConData.m_UserName) &&
                       this.m_crypted_Password.Equals(xConData.m_crypted_Password) &&
                       this.m_strDataBaseFilePath.Equals(xConData.m_strDataBaseFilePath) &&
                       this.m_strDataBaseLogFilePath.Equals(xConData.m_strDataBaseLogFilePath)
                       )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
