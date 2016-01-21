﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tangenta
{
    public class Employee
    {
        private string m_FirstName = null;
        public string FirstName
        {
            get { return m_FirstName; }
        }

        private string m_LastName = null;
        public string LastName
        {
            get { return m_LastName; }
        }

        private string m_Job = null;
        public string Job
        {
            get { return m_Job; }
        }

        private string m_UserName = null;
        public string UserName
        {
            get { return m_UserName; }
        }

        private string m_Password = null;
        public string Password
        {
            get { return m_Password; }
        }

        private string m_Description = null;
        public string Description
        {
            get { return m_Description; }
        }
        private bool m_Active = false;
        public bool Active
        {
            get { return m_Active; }
        }

        private long m_myCompany_ID = 1;
        public long myCompany_ID
        {
            get { return m_myCompany_ID; }
        }

        private long m_myCompany_Person_ID = 1;
        public long myCompany_Person_ID
        {
            get { return m_myCompany_Person_ID; }
        }
        public string Person
        {
            get { return m_FirstName + " " + m_LastName; }
        }

        public Employee(string xFirstName,
                        string xLastName,
                        object xJob,
                        object xUserName,
                        object xPassword,
                        object xDescription,
                        bool xActive,
                        long x_myCompany_ID,
                        long x_myCompany_Person_ID
                        )
        {
            m_FirstName = xFirstName;
            m_LastName = xLastName;
            m_Job = set_string(xJob);
            m_UserName = set_string(xUserName);
            m_Password = set_string(xPassword);
            m_Description = set_string(xDescription);
            m_Active = xActive;
            m_myCompany_ID = x_myCompany_ID;
            m_myCompany_Person_ID = x_myCompany_Person_ID;
        }
        private string set_string(object obj)
        {
             if (obj.GetType() == typeof(string))
            {
                return (string)obj;
            }
            else
            {
                return null;
            }

        }
    }
}