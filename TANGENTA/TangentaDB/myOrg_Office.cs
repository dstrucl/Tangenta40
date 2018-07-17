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

        public ID Atom_ElectronicDevice_ID
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

        public string Atom_ElectronicDevice_ComputerName
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

        public string Atom_ElectronicDevice_ComputerUserName
        {
            get
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
        }

        public string Atom_ElectronicDevice_MAC_address
        {
            get
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
        }

        public string Atom_ElectronicDevice_IP_address
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
                            }

                            return Get_Atom_ElectronicDevice_List(this, ref myOrg_Office_ElectronicDevice_List);
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

        public static bool Get_Atom_ElectronicDevice_List(myOrg_Office Office, ref List<myOrg_Office_ElectronicDevice> myOrg_Office_ElectronicDevice_list)
        {

            DataTable dt = new DataTable();
            myOrg_Office_ElectronicDevice_list.Clear();
            string sql = null;
            sql = @"select
                        ID
                        FROM Atom_ElectronicDevice where Office_id = " + Office.ID.ToString();

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
                        ID Atom_ElectronicDevice_ID = tf.set_ID(dr["ID"]);
                        myOrg_Office_ElectronicDevice mAtom_ElectronicDevice = new myOrg_Office_ElectronicDevice(Office);

                        if (mAtom_ElectronicDevice.Get(Atom_ElectronicDevice_ID))
                        {
                            myOrg_Office_ElectronicDevice_list.Add(mAtom_ElectronicDevice);
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

    }
}
