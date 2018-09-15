#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class myOrg_Office
    {
        public ID ID = null;
        public ID Office_Data_ID = null;
        public string_v Name_v = null;
        public string_v ShortName_v = null;
        public PostAddress_v Address_v = new PostAddress_v();
        public string_v Description_v = null;
        public myOrg_Office_FVI_SLO_RealEstate myOrg_Office_FVI_SLO_RealEstate = new myOrg_Office_FVI_SLO_RealEstate();

        public myOrg_Office_ElectronicDevice m_myOrg_Office_ElectronicDevice = null;

        public List<myOrg_Office_ElectronicDevice> myOrg_Office_ElectronicDevice_List = new List<myOrg_Office_ElectronicDevice>();


        public myOrg_Person m_myOrg_Person = null;

        public List<myOrg_Person> myOrg_Person_list = new List<myOrg_Person>();

        public ID ElectronicDevice_ID
        {
            get {
                    if (m_myOrg_Office_ElectronicDevice!=null)
                    {
                        return m_myOrg_Office_ElectronicDevice.ID;
                    }
                    else
                    {
                        return null;
                    }
                }
        }

        public string ElectronicDevice_ComputerName
        {
            get
            {
                if (m_myOrg_Office_ElectronicDevice != null)
                {
                    return m_myOrg_Office_ElectronicDevice.ComputerName;
                }
                else
                {
                    return null;
                }
            }
        }

        public string Get_ElectronicDevice_ComputerUserName()
        {
            if (m_myOrg_Office_ElectronicDevice != null)
            {
                return m_myOrg_Office_ElectronicDevice.ComputerUserName;
            }
            else
            {
                return null;
            }
        }

        public string GetAtom_ElectronicDevice_MAC_address()
        {
            if (m_myOrg_Office_ElectronicDevice != null)
            {
                return m_myOrg_Office_ElectronicDevice.MAC_address;
            }
            else
            {
                return null;
            }
        }

        public string ElectronicDevice_IP_address
        {
            get
            {
                if (m_myOrg_Office_ElectronicDevice != null)
                {
                    return m_myOrg_Office_ElectronicDevice.IP_address;
                }
                else
                {
                    return null;
                }
            }
        }

     
        public bool Get(ID Office_ID)
        {
            string Err = null;
            ID = null;
            Name_v = null;
            Address_v.StreetName_v = null;
            Address_v.HouseNumber_v = null;
            Address_v.ZIP_v = null;
            Address_v.City_v = null;
            Address_v.Country_v = null;
            Address_v.Country_ISO_3166_a2_v = null;
            Address_v.Country_ISO_3166_a3_v = null;
            Address_v.Country_ISO_3166_num_v = null;

            myOrg_Office_FVI_SLO_RealEstate.ID = null;
            myOrg_Office_FVI_SLO_RealEstate.Office_Data_ID = null;
            myOrg_Office_FVI_SLO_RealEstate.BuildingNumber_v = null;
            myOrg_Office_FVI_SLO_RealEstate.BuildingSectionNumber_v = null;
            myOrg_Office_FVI_SLO_RealEstate.Community_v = null;
            myOrg_Office_FVI_SLO_RealEstate.CadastralNumber_v = null;
            myOrg_Office_FVI_SLO_RealEstate.ValidityDate_v = null;
            myOrg_Office_FVI_SLO_RealEstate.ClosingTag_v = null;
            myOrg_Office_FVI_SLO_RealEstate.SoftwareSupplier_TaxNumber_v = null;
            myOrg_Office_FVI_SLO_RealEstate.PremiseType_v = null;


            if (ID.Validate(Office_ID))
            {
                string sql = @"SELECT 
                                  ID,
                                  Name,
                                  ShortName
                                  FROM Office where ID = " + Office_ID.ToString();

                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        ID = tf.set_ID(dt.Rows[0]["ID"]);
                        Name_v = tf.set_string(dt.Rows[0]["Name"]);
                        ShortName_v = tf.set_string(dt.Rows[0]["ShortName"]);
                        dt.Columns.Clear();
                        dt.Clear();

                        sql = @"SELECT 
                              Office_Data.ID,
                              Office_Data_$_office.ID AS Office_Data_$_office_$$ID,
                              Office_Data_$_office.Name AS Office_Data_$_office_$$Name,
                              Office_Data_$_office.Name AS Office_Data_$_office_$$ShortName,
                              Office_Data_$_cadrorg.ID AS Office_Data_$_cadrorg_$$ID,
                              Office_Data_$_cadrorg_$_cstrnorg.StreetName AS Office_Data_$_cadrorg_$_cstrnorg_$$StreetName,
                              Office_Data_$_cadrorg_$_chounorg.HouseNumber AS Office_Data_$_cadrorg_$_chounorg_$$HouseNumber,
                              Office_Data_$_cadrorg_$_ccitorg.City AS Office_Data_$_cadrorg_$_ccitorg_$$City,
                              Office_Data_$_cadrorg_$_cziporg.ZIP AS Office_Data_$_cadrorg_$_cziporg_$$ZIP,
                              Office_Data_$_cadrorg_$_cstorg.Country AS Office_Data_$_cadrorg_$_ccouorg_$$Country,
                              Office_Data_$_cadrorg_$_cstorg.Country_ISO_3166_a2 AS Office_Data_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a2,
                              Office_Data_$_cadrorg_$_cstorg.Country_ISO_3166_a3 AS Office_Data_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a3,
                              Office_Data_$_cadrorg_$_cstorg.Country_ISO_3166_num AS Office_Data_$_cadrorg_$_ccouorg_$$Country_ISO_3166_num,
                              Office_Data_$_cadrorg_$_ccouorg.State AS Office_Data_$_cadrorg_$_cstorg_$$State,
                              Office_Data.Description AS Office_Data_$$Description
                              FROM Office_Data
                              INNER JOIN Office Office_Data_$_office ON Office_Data.Office_ID = Office_Data_$_office.ID
                              LEFT JOIN cAddress_Org Office_Data_$_cadrorg ON Office_Data.cAddress_Org_ID = Office_Data_$_cadrorg.ID
                              LEFT JOIN cStreetName_Org Office_Data_$_cadrorg_$_cstrnorg ON Office_Data_$_cadrorg.cStreetName_Org_ID = Office_Data_$_cadrorg_$_cstrnorg.ID
                              LEFT JOIN cHouseNumber_Org Office_Data_$_cadrorg_$_chounorg ON Office_Data_$_cadrorg.cHouseNumber_Org_ID = Office_Data_$_cadrorg_$_chounorg.ID
                              LEFT JOIN cCity_Org Office_Data_$_cadrorg_$_ccitorg ON Office_Data_$_cadrorg.cCity_Org_ID = Office_Data_$_cadrorg_$_ccitorg.ID
                              LEFT JOIN cZIP_Org Office_Data_$_cadrorg_$_cziporg ON Office_Data_$_cadrorg.cZIP_Org_ID = Office_Data_$_cadrorg_$_cziporg.ID
                              LEFT JOIN cCountry_Org Office_Data_$_cadrorg_$_cstorg ON Office_Data_$_cadrorg.cCountry_Org_ID = Office_Data_$_cadrorg_$_cstorg.ID
                              LEFT JOIN cState_Org Office_Data_$_cadrorg_$_ccouorg ON Office_Data_$_cadrorg.cState_Org_ID = Office_Data_$_cadrorg_$_ccouorg.ID
                              where Office_Data_$_office.ID = " + Office_ID.ToString();
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                ID = Office_ID;
                                Office_Data_ID = tf.set_ID(dt.Rows[0]["ID"]);
                                Description_v = tf.set_string(dt.Rows[0]["Office_Data_$$Description"]);
                                Address_v.StreetName_v = tf.set_dstring(dt.Rows[0]["Office_Data_$_office_$$Name"]);
                                Address_v.HouseNumber_v = tf.set_dstring(dt.Rows[0]["Office_Data_$_cadrorg_$_chounorg_$$HouseNumber"]);
                                Address_v.ZIP_v = tf.set_dstring(dt.Rows[0]["Office_Data_$_cadrorg_$_cziporg_$$ZIP"]);
                                Address_v.City_v = tf.set_dstring(dt.Rows[0]["Office_Data_$_cadrorg_$_ccitorg_$$City"]);
                                Address_v.Country_v = tf.set_dstring(dt.Rows[0]["Office_Data_$_cadrorg_$_ccouorg_$$Country"]);
                                Address_v.Country_ISO_3166_a2_v = tf.set_dstring(dt.Rows[0]["Office_Data_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a2"]);
                                Address_v.Country_ISO_3166_a3_v = tf.set_dstring(dt.Rows[0]["Office_Data_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a3"]);
                                Address_v.Country_ISO_3166_num_v = tf.set_dshort(fs.MyConvertToShort(dt.Rows[0]["Office_Data_$_cadrorg_$_ccouorg_$$Country_ISO_3166_num"]));
                                myOrg_Office_FVI_SLO_RealEstate.Get(Office_Data_ID);

                                if (Get_Atom_ElectronicDevice_List(this, ref myOrg_Office_ElectronicDevice_List))
                                {
                                    return myOrg_Person_List.Get(this, ref myOrg_Person_list);
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return true;
                            }

                            
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:myOrg_Office:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:myOrg_Office:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                }
                else
                {
                    LogFile.Error.Show("ERROR:myOrg_Office:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Find_myOrg_Person_SingleUser(ID m_my_Org_Person_ID)
        {
            if (ID.Validate(m_my_Org_Person_ID))
            {
                foreach (myOrg_Person mop in myOrg_Person_list)
                {
                    if (ID.Validate(mop.ID))
                    {
                        if (m_my_Org_Person_ID.Equals(mop.ID))
                        {
                            this.m_myOrg_Person = mop;
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public myOrg_Person Find_myOrg_Person(ID m_my_Org_Person_ID)
        {
            if (ID.Validate(m_my_Org_Person_ID))
            {
                foreach (myOrg_Person mop in myOrg_Person_list)
                {
                    if (ID.Validate(mop.ID))
                    {
                        if (m_my_Org_Person_ID.Equals(mop.ID))
                        {
                            return mop;
                        }
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public static bool Get_Atom_ElectronicDevice_List(myOrg_Office Office, ref List<myOrg_Office_ElectronicDevice> myOrg_Office_ElectronicDevice_list)
        {

            DataTable dt = new DataTable();
            myOrg_Office_ElectronicDevice_list.Clear();
            string sql = null;
            sql = @"select
                        ID
                        FROM ElectronicDevice where Office_id = " + Office.ID.ToString();

            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    int iCount = dt.Rows.Count;
                    for (i = 0; i < iCount; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        ID xElectronicDevice_ID = tf.set_ID(dr["ID"]);
                        myOrg_Office_ElectronicDevice xm_ElectronicDevice = new myOrg_Office_ElectronicDevice(Office);

                        if (xm_ElectronicDevice.Get(xElectronicDevice_ID))
                        {
                            myOrg_Office_ElectronicDevice_list.Add(xm_ElectronicDevice);
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:myOrg_Office_List:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public enum eGet_m_myOrg_Person_SingleUser_Result {OK,
                                                          ELECTRONIC_DEVICE_NOT_DEFINED_FOR_THIS_COMPUTER,
                                                          NO_MYORGANISATION_PERSON_SingleUser_FOR_THIS_ELECTRONIC_DEVICE_ID,
                                                          NO_myOrganisation_Person_ID_IN_myOrg_Person_list,
                                                          myOrg_Office_NOT_DEFINED,
                                                          ERROR };

        internal eGet_m_myOrg_Person_SingleUser_Result Get_m_myOrg_Person_SingleUser()
        {
            string Err = null;
            ID xElectronicDevice_ID = null;
            ID xAtom_Computer_ID = null;
            if (f_ElectronicDevice.Get(this.ID, ref xElectronicDevice_ID,ref xAtom_Computer_ID))
            {
                if (ID.Validate(xElectronicDevice_ID))
                {
                    string sql = @"select myOrganisation_Person_ID from myOrganisation_Person_SingleUser where ElectronicDevice_ID = " + xElectronicDevice_ID.ToString();
                    DataTable dt = new DataTable();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                    {
                        if (dt.Rows.Count == 0)
                        {
                            return eGet_m_myOrg_Person_SingleUser_Result.NO_MYORGANISATION_PERSON_SingleUser_FOR_THIS_ELECTRONIC_DEVICE_ID;
                        }
                        else if (dt.Rows.Count == 1)
                        {
                            ID myOrganisation_Person_ID = tf.set_ID(dt.Rows[0]["myOrganisation_Person_ID"]);
                            if (ID.Validate(myOrganisation_Person_ID))
                            {
                                foreach (myOrg_Person mop in myOrg_Person_list)
                                {
                                    if (ID.Validate(mop.ID))
                                    {
                                        if (myOrganisation_Person_ID.Equals(mop.ID))
                                        {
                                            this.m_myOrg_Person = mop;
                                            return eGet_m_myOrg_Person_SingleUser_Result.OK;
                                        }
                                    }
                                }
                            }
                            return eGet_m_myOrg_Person_SingleUser_Result.NO_myOrganisation_Person_ID_IN_myOrg_Person_list;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:myOrg_Office:Get_m_myOrg_Person_SingleUser:More than one row in myOrganisation_Person_SingleUser table: Rows.Count =" + dt.Rows.Count.ToString());
                            return eGet_m_myOrg_Person_SingleUser_Result.ERROR;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:myOrg_Office:Get_m_myOrg_Person_SingleUser:sql =" + sql + "\r\nErr=" + Err);
                        return eGet_m_myOrg_Person_SingleUser_Result.ERROR;
                    }
                }
                else
                {
                    //LogFile.Error.Show("ERROR:TangentaDB:myOrg_Office:Get_m_myOrg_Person_SingleUser:xAtom_ElectronicDevice_ID is not valid!");
                    return eGet_m_myOrg_Person_SingleUser_Result.ELECTRONIC_DEVICE_NOT_DEFINED_FOR_THIS_COMPUTER;
                }
            }
            else
            {
                if (this.Name_v != null)
                {
                    LogFile.Error.Show("ERROR:TangentaDB:myOrg_Office:Get_m_myOrg_Person_SingleUser: Can not get electronic device for this office! Office name = " + this.Name_v.v);
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:myOrg_Office:Get_m_myOrg_Person_SingleUser: Can not get electronic device for this office! Office name = null");
                }
                return eGet_m_myOrg_Person_SingleUser_Result.ERROR; 
            }
        }
    }
}
