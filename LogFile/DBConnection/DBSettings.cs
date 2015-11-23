using System;
using System.Collections.Generic;

using System.Text;

namespace LogFile
{
    public class DBSettings
    {
        public bool bWindowsAuthentication;
        public string DataSource;
        public string DataBase;
        public string UserName;
        public string Password;
        public string strDataBaseFilePath;
        public string strDataBaseLogFilePath;
        public string RunTime_ConnectionString;
        public uint uiDataBaseType;

    public  DBSettings(bool bWndAuthentication,
                            string DatSource,
                            string DatBase,
                            string UsrName,
                            string Pswrd,
                            string sDataBaseFilePath,
                            string sDataBaseLogFilePath,
                            string RunTimeConnectionString,
                            uint uiDBsett)
        {
            bWindowsAuthentication = bWndAuthentication;
            DataSource = DatSource;
            DataBase = DatBase;
            UserName = UsrName;
            Password = Pswrd;
            strDataBaseFilePath = sDataBaseFilePath;
            strDataBaseLogFilePath = sDataBaseLogFilePath;
            RunTime_ConnectionString = RunTimeConnectionString;
            uiDataBaseType = uiDBsett;
        }
    }
}
