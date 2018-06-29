﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace DBConnectionControl40
{


    public class SQLInfoEnumerator
    {
        [DllImport("odbc32.dll", EntryPoint = "SQLAllocHandle", CharSet = CharSet.Ansi)]
        static extern short SQLAllocHandle(short handleType, IntPtr inputHandle, ref IntPtr outputHandlePtr);

        [DllImport("odbc32.dll", EntryPoint = "SQLSetEnvAttr", CharSet = CharSet.Ansi)]
        static extern short SQLSetEnvAttr(IntPtr environmentHandle, int attribute, IntPtr valuePtr, int stringLength);

        [DllImport("odbc32.dll", EntryPoint = "SQLFreeHandle", CharSet = CharSet.Ansi)]
        static extern short SQLFreeHandle(short hType, IntPtr Handle);

        [DllImport("odbc32.dll", EntryPoint = "SQLBrowseConnect", CharSet = CharSet.Ansi)]
        static extern short SQLBrowseConnect(IntPtr handleConnection, StringBuilder inConnection, short stringLength, StringBuilder outConnection, short bufferLength, ref short stringLength2Ptr);
    
        private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";
        private const short SQL_SUCCESS = 0;
        private const short SQL_HANDLE_ENV = 1;
        private const short SQL_HANDLE_DBC = 2;
        private const int SQL_ATTR_ODBC_VERSION = 200;
        private const int SQL_OV_ODBC3 = 3;
        private const short SQL_NEED_DATA = 99;
        private const short DEFAULT_RESULT_SIZE = 1024;
        private const string START_STR = "{";
        private const string END_STR = "}";


        /// <summary>
        /// A string to hold the selected SQL Server
        /// </summary>
        private string m_SQLServer;
        /// <summary>
        /// A string to hold the username
        /// </summary>
        private string m_Username;
        /// <summary>
        /// A string to hold the password
        /// </summary>
        private string m_Password;
        /// <summary>
        /// Property to set the SQL Server instance
        /// </summary>
        public string SQLServer
        {
            set
            {
                m_SQLServer = value;
            }
        }

        /// <summary>
        /// Property to set the Username
        /// </summary>
        public string Username
        {
            set {
                m_Username = value;
                }
        }

        /// <summary>
        /// Property to set the Password
        /// </summary>
        public string Password
        {
            set {
                m_Password = value;
            }
        }

        /// <summary>
        /// Enumerate the SQL Servers returning a list (if any exist)
        /// </summary>
        /// <returns></returns>
        public string[] EnumerateSQLServers()
        {
            return RetrieveInformation(SQL_DRIVER_STR);
        }
        /// <summary>
        /// Enumerate the specified SQL server returning a list of databases (if any exist)
        /// </summary>
        /// <returns></returns>
        public string[] EnumerateSQLServersDatabases()
        {
            return RetrieveInformation(SQL_DRIVER_STR + ";SERVER=" + m_SQLServer + ";UID="+ m_Username+ ";PWD=" + m_Password);
        }

        /// <summary>
        /// Enumerate for SQLServer/Databases based on the passed information it the string
        /// The more information provided to SQLBrowseConnect the more granular it gets so
        /// if only DRIVER=SQL SERVER passed then a list of all SQL Servers is returned
        /// If DRIVER=SQL SERVER;Server=ServerName is passed then a list of all Databases on the
        /// servers is returned etc
        /// </summary>
        /// <param name="InputParam">A valid string to query for</param>
        /// <returns></returns>
        private string[] RetrieveInformation(string InputParam)
        {
            IntPtr m_environmentHandle = IntPtr.Zero;
            IntPtr m_connectionHandle = IntPtr.Zero;
            StringBuilder inConnection = new StringBuilder(InputParam);

            short stringLength = Convert.ToInt16(inConnection.Length);
            StringBuilder outConnection = new StringBuilder(DEFAULT_RESULT_SIZE);
            short stringLength2Ptr = 0;

            try
            {
                if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_ENV, m_environmentHandle, ref m_environmentHandle))
                {
                    if (SQL_SUCCESS == SQLSetEnvAttr(m_environmentHandle, SQL_ATTR_ODBC_VERSION, new IntPtr(SQL_OV_ODBC3), 0))
                    {
                        if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_DBC, m_environmentHandle, ref m_connectionHandle))
                        {
                            if (SQL_NEED_DATA == SQLBrowseConnect(m_connectionHandle, inConnection, stringLength, outConnection, DEFAULT_RESULT_SIZE, ref stringLength2Ptr))
                            {
                                if (SQL_NEED_DATA != SQLBrowseConnect(m_connectionHandle, inConnection, stringLength, outConnection, DEFAULT_RESULT_SIZE, ref stringLength2Ptr))
                                {
                                    throw new ApplicationException("No Data Returned.");
                                }
                            }
                        }
                    }
                }
            }

            catch 
            {
                throw new ApplicationException("Cannot Locate SQL Server.");
            }
            finally
            {
                FreeConnection(m_connectionHandle);
                FreeConnection(m_environmentHandle);
            }

            if (outConnection.ToString() != "")
            {
                return ParseSQLOutConnection(outConnection.ToString());
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Parse an outConnection string returned from SQLBrowseConnect
        /// </summary>
        /// <param name="outConnection">string to parse</param>
        /// <returns></returns>
        private string[] ParseSQLOutConnection(string outConnection)
        {
            int m_Start = outConnection.IndexOf(START_STR) + 1;
            int m_lenString = outConnection.IndexOf(END_STR) - m_Start;
            if ((m_Start > 0) && (m_lenString > 0))
            {
                outConnection = outConnection.Substring(m_Start, m_lenString);
            }
            else
            {
                outConnection = String.Empty;
            }
            return outConnection.Split(",".ToCharArray());
        }

        private void FreeConnection(IntPtr handleToFree)
        {
            if (handleToFree != IntPtr.Zero)
            {
                SQLFreeHandle(SQL_HANDLE_DBC, handleToFree);
            }
        }
    }
}
