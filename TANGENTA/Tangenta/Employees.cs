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

        private long m_myOrganisation_ID = 1;
        public long myOrganisation_ID
        {
            get { return m_myOrganisation_ID; }
        }

        private long m_myOrganisation_Person_ID = 1;
        public long myOrganisation_Person_ID
        {
            get { return m_myOrganisation_Person_ID; }
        }
        public string Person
        {
            get { return m_FirstName + " " + m_LastName; }
        }

        public Employee(string xFirstName,
                        object xLastName,
                        object xJob,
                        object xUserName,
                        object xPassword,
                        object xDescription,
                        bool xActive,
                        long x_myOrganisation_ID,
                        long x_myOrganisation_Person_ID
                        )
        {
            m_FirstName = xFirstName;
            m_LastName = set_string(xLastName);
            m_Job = set_string(xJob);
            m_UserName = set_string(xUserName);
            m_Password = set_string(xPassword);
            m_Description = set_string(xDescription);
            m_Active = xActive;
            m_myOrganisation_ID = x_myOrganisation_ID;
            m_myOrganisation_Person_ID = x_myOrganisation_Person_ID;
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
