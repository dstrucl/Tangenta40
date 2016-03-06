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

namespace DBConnectionControl40
{

    public class conData_MYSQL
    {

        int[] encrypt_num = new int[32] { 1, 2, -3, 4, 5, -6, 7, -8, 9, -10, 11, 12, 13, 14, 15, 16, 7, 8, 9, 2, 1, 2, 3, 4, 5, 6, 7, 8, 9, -1, 1, -2 };

        internal Crypt m_Crypt;

        //public String ConnectionString = null;
        public string m_DataSource = "";

        public string m_DataBase = "";
        //public string strDataBaseFilePath = "";
        //public string strDataBaseLogFilePath = "";
        public string m_UserName;
        public string m_crypted_Password;

        //public string m_WindowsAuthentication_UserName = SystemInformation.UserDomainName + "\\" + SystemInformation.UserName;


        public conData_MYSQL(string xDataSource,
                                     string xDataBase,
                                     string xUserName,
                                     string xcrypted_Password)
        {
            m_DataSource = xDataSource;
            m_DataBase = xDataBase;
            m_UserName = xUserName;
            m_crypted_Password = xcrypted_Password;
            m_Crypt = new Crypt(encrypt_num);
        }

        public conData_MYSQL()
        {
            m_DataSource = "";
            m_DataBase = "";
            m_UserName = "";
            m_crypted_Password = "";
            m_Crypt = new Crypt(encrypt_num);
        }

        public string GetConnectionString()
        {
           //    ConnectionString = "Data Source=" + strServerName + ";Persist Security Info=True;User ID=" + strLoginID + ";Password=" + strPassword;
            return "server=" + m_DataSource + ";User ID=" + m_UserName + ";password=" + m_Crypt.DecryptString(m_crypted_Password) + ";database=" + m_DataBase;
        }

        public string GetServerConnectionString()
        {
            return "server=" + m_DataSource + ";User ID=" + m_UserName + ";Password=" + m_Crypt.DecryptString(m_crypted_Password);
        }


        public void WriteProp(Action<string> setOutput, string s)
        {
            setOutput(s);
        }

        public bool Equals(conData_MYSQL xConData)
        {
            if (this.m_DataSource.Equals(xConData.m_DataSource) &&
                this.m_DataBase.Equals(xConData.m_DataBase) &&
                this.m_UserName.Equals(xConData.m_UserName) &&
                this.m_crypted_Password.Equals(xConData.m_crypted_Password) //&&
                //this.strDataBaseFilePath.Equals(xConData.strDataBaseFilePath) &&
                //this.strDataBaseLogFilePath.Equals(xConData.strDataBaseLogFilePath)
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
}
