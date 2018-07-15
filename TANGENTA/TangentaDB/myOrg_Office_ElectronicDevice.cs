using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class myOrg_Office_ElectronicDevice
    {
        public ID ID = null;
        public myOrg_Office Office = null;

        private string m_ElectronicDevice_Name = null;
        private string m_ElectronicDevice_Description = null;
        private string m_ComputerName = null;
        private string m_ComputerName_Description = null;
        private string m_ComputerUserName = null;
        private string m_ComputerUserName_Description = null;
        private string m_MAC_address = null;
        private string m_MAC_address_Description = null;
        private string m_IP_address = null;
        private string m_IP_address_Description = null;

        public string ElectronicDevice_Name
        {
            get {
                return m_ElectronicDevice_Name;
                }
        }

        public string ElectronicDevice_Description
        {
            get
            {
                return m_ElectronicDevice_Description;
            }
        }
            

        public string ComputerName
        {
            get {
                    return m_ComputerName;
                }
        }

        public string ComputerName_Description
        {
            get
            {
                return m_ComputerName_Description;
            }
        }

        public string ComputerUserName
        {
            get
            {
                return m_ComputerUserName;
            }
        }

        public string ComputerUserName_Description
        {
            get
            {
                return m_ComputerUserName_Description;
            }
        }

        public string MAC_address
        {
            get
            {
                return m_MAC_address;
            }
        }

        public string MAC_address_Description
        {
            get
            {
                return m_MAC_address_Description;
            }
        }

        public string IP_address
        {
            get
            {
                return m_IP_address;
            }
        }

        public string IP_address_Description
        {
            get
            {
                return m_IP_address_Description;
            }
        }

        public myOrg_Office_ElectronicDevice(myOrg_Office xOffice)
        {
            Office = xOffice;
        }

        internal bool Get(ID atom_ElectronicDevice_ID)
        {
            return f_Atom_ElectronicDevice.Get(atom_ElectronicDevice_ID,
                                            ref m_ElectronicDevice_Name,
                                            ref m_ElectronicDevice_Description,
                                            ref m_ComputerName,
                                            ref m_ComputerName_Description,
                                            ref m_ComputerUserName,
                                            ref m_ComputerUserName_Description,
                                            ref m_MAC_address,
                                            ref m_MAC_address_Description,
                                            ref m_IP_address,
                                            ref m_IP_address_Description
                                            );
        }
    }
}
