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
using System.Data;
using LogFile;
using DBTypes;
using CodeTables;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_Atom_myOrganisation
    {
        public static bool Get(ID myOrganisation_ID, ref ID Atom_myOrganisation_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();

            string sql_find_Atom_myOrganisation_ID = @"select
                                Atom_myOrganisation.ID as Atom_myOrganisation_ID
                                from Atom_myOrganisation
                                inner join Atom_OrganisationData on Atom_myOrganisation.Atom_OrganisationData_ID = Atom_OrganisationData.ID
                                inner join Atom_Organisation on Atom_OrganisationData.Atom_Organisation_ID = Atom_Organisation.ID
                                left join Atom_cAddress_Org on Atom_OrganisationData.Atom_cAddress_Org_ID = Atom_cAddress_Org.ID
                                left join Atom_cStreetName_Org on Atom_cAddress_Org.Atom_cStreetName_Org_ID = Atom_cStreetName_Org.ID
                                left join Atom_cHouseNumber_Org on Atom_cAddress_Org.Atom_cHouseNumber_Org_ID = Atom_cHouseNumber_Org.ID
                                left join Atom_cCity_Org on Atom_cAddress_Org.Atom_cCity_Org_ID = Atom_cCity_Org.ID
                                left join Atom_cZIP_Org on Atom_cAddress_Org.Atom_cZIP_Org_ID = Atom_cZIP_Org.ID
                                left join Atom_cCountry_Org on Atom_cAddress_Org.Atom_cCountry_Org_ID = Atom_cCountry_Org.ID
                                left join Atom_cState_Org on Atom_cAddress_Org.Atom_cState_Org_ID = Atom_cState_Org.ID
                                inner join Organisation on Organisation.Name = Atom_Organisation.Name
                                           and ((Organisation.Tax_ID = Atom_Organisation.Tax_ID) or ( Organisation.Tax_ID is null and  Atom_Organisation.Tax_ID is null))
                                           and ((Organisation.Registration_ID = Atom_Organisation.Registration_ID) or (Organisation.Registration_ID is null and Atom_Organisation.Registration_ID is null))
                                left  join OrganisationData on OrganisationData.Organisation_ID = Organisation.ID
				                left  join myOrganisation on myOrganisation.OrganisationData_ID = OrganisationData.ID
                                left  join cAddress_Org on OrganisationData.cAddress_Org_ID = cAddress_Org.ID
                                left  join cStreetName_Org on cAddress_Org.cStreetName_Org_ID = cStreetName_Org.ID
                                left  join cHouseNumber_Org on cAddress_Org.cHouseNumber_Org_ID = cHouseNumber_Org.ID
                                left  join cCity_Org on cAddress_Org.cCity_Org_ID = cCity_Org.ID
                                left  join cZIP_Org on cAddress_Org.cZIP_Org_ID = cZIP_Org.ID
                                left  join cCountry_Org on cAddress_Org.cCountry_Org_ID = cCountry_Org.ID
                                left  join cState_Org on cAddress_Org.cState_Org_ID = cState_Org.ID
                                left  join Logo on OrganisationData.Logo_ID = Logo.ID
                                left  join Atom_Logo on Atom_OrganisationData.Atom_Logo_ID = Atom_Logo.ID
                                where
                                ( (  Logo.Image_Hash is null  and   Atom_Logo.Image_Hash is null  ) or  (Logo.Image_Hash=Atom_Logo.Image_Hash) ) and
                                ( (  cStreetName_Org.StreetName is null  and   Atom_cStreetName_Org.StreetName  is null  ) or (cStreetName_Org.StreetName = Atom_cStreetName_Org.StreetName ) ) and
                                ( (  cHouseNumber_Org.HouseNumber is null  and   Atom_cHouseNumber_Org.HouseNumber is null  )or  ( cHouseNumber_Org.HouseNumber = Atom_cHouseNumber_Org.HouseNumber ) ) and
                                ( (  Atom_OrganisationData.cHomePage_Org_ID is null   and  OrganisationData.cHomePage_Org_ID is null  ) or  ( Atom_OrganisationData.cHomePage_Org_ID = OrganisationData.cHomePage_Org_ID ) ) and
                                ( (  Atom_OrganisationData.cEmail_Org_ID is null  and   OrganisationData.cEmail_Org_ID is null ) or  ( Atom_OrganisationData.cEmail_Org_ID = OrganisationData.cEmail_Org_ID ) ) and
                                ( (  Atom_OrganisationData.cPhoneNumber_Org_ID is null  and   OrganisationData.cPhoneNumber_Org_ID is null  ) or  ( Atom_OrganisationData.cPhoneNumber_Org_ID = OrganisationData.cPhoneNumber_Org_ID ) ) and
                                ( (  Atom_OrganisationData.cFaxNumber_Org_ID is null  and   OrganisationData.cFaxNumber_Org_ID is null  ) or  ( Atom_OrganisationData.cFaxNumber_Org_ID = OrganisationData.cFaxNumber_Org_ID ) ) and
                                ( (  cCity_Org.City is null ) and  Atom_cCity_Org.City is null   ) or  (cCity_Org.City = Atom_cCity_Org.City  ) and
                                ( (  cZip_Org.ZIP is null  and  Atom_cZIP_Org.ZIP is null  )or  (cZip_Org.ZIP = Atom_cZIP_Org.ZIP ) ) and
                                ( ( cCountry_Org.Country is null  and   Atom_cCountry_Org.Country is null )  or  ( cCountry_Org.Country = Atom_cCountry_Org.Country) ) and
                                ( ( cState_Org.State is null and  Atom_cState_Org.State is null  ) or  (cState_Org.State = Atom_cState_Org.State ) ) and
                                myOrganisation.id = " + myOrganisation_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql_find_Atom_myOrganisation_ID, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_myOrganisation_ID==null)
                    {
                        Atom_myOrganisation_ID = new ID();
                    }
                    Atom_myOrganisation_ID.Set(dt.Rows[0]["Atom_myOrganisation_ID"]);
                    return true;
                }
                else
                {
                    ID xAtom_myOrganisation_iD = null;
                    if (myOrg.Name_v == null)
                    {   
                        myOrg.Get();
                    }
                    if (!f_Atom_myOrganisation.Get(myOrg.Name_v,
                                              myOrg.Tax_ID_v,
                                              myOrg.Registration_ID_v,
                                              myOrg.TayPayer_v,
                                              myOrg.Comment1_v,
                                              myOrg.OrganisationTYPE_v,
                                              myOrg.Address_v,
                                              myOrg.PhoneNumber_v,
                                              myOrg.FaxNumber_v,
                                              myOrg.Email_v,
                                              myOrg.HomePage_v,
                                              myOrg.BankName_v,
                                              myOrg.TRR_v,
                                              myOrg.Logo_Hash_v,
                                              myOrg.Logo_Image_Data_v,
                                              myOrg.Logo_Description_v,
                                              ref xAtom_myOrganisation_iD))
                    {
                        return false;
                    }
                    if (xAtom_myOrganisation_iD != null)
                    {
                        Atom_myOrganisation_ID = xAtom_myOrganisation_iD;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:InsertInto_Atom_myOrganisation_Person:Atom_myOrganisation_iD_v == null!");
                        return false;
                    }

                }
            }
            else
            {
                LogFile.Error.Show(@"ERROR:Find_Atom_myOrganisation_Person_ID:select ...from Atom_myOrganisation:\r\nErr=" + Err);
                return false; 
            }

        }

        //string_v StreetName_v = tf.set_string(Address.StreetName);
        //string_v HouseNumber_v = tf.set_string(Address.HouseNumber);
        //string_v ZIP_v = tf.set_string(Address.ZIP);
        //string_v City_v = tf.set_string(Address.City);
        //string_v Country_v = tf.set_string(Address.Country);
        //string_v State_v = tf.set_string(Address.State);
        //string_v PhoneNumber_v = tf.set_string(PhoneNumber);
        //string_v FaxNumber_v = tf.set_string(FaxNumber);
        //string_v Email_v = tf.set_string(Email);
        //string_v HomePage_v = tf.set_string(HomePage);
        //string_v Logo_Hash_v = tf.set_string(Logo_Hash);
        //byte_array_v Logo_Image_Data_v = tf.set_byte_array(Logo);
        //string_v Logo_Description_v = tf.set_string(Logo_Description);

        public static bool Get( string_v Organisation_Name_v,
                                string_v Tax_ID_v,
                                string_v Registration_ID_v,
                                bool_v TaxPayer_v,
                                string_v Comment1_v,
                                string_v OrganisationTYPE_v,
                                PostAddress_v Address_v,
                                string_v PhoneNumber_v,
                                string_v FaxNumber_v,
                                string_v Email_v,
                                string_v HomePage_v,
                                string_v BankName_v,
                                string_v TRR_v,
                                string_v Logo_Hash_v,
                                byte_array_v Logo_Image_Data_v,
                                string_v Logo_Description_v,
                                ref ID iD)
        {
            string Err = null;
            ID Atom_Organisation_ID = null;
            ID Atom_OrganisationData_ID = null;

            if (f_Atom_Organisation.Get( Organisation_Name_v,
                                Tax_ID_v,
                                Registration_ID_v,
                                TaxPayer_v,
                                Comment1_v,
                                OrganisationTYPE_v,
                                Address_v,
                                PhoneNumber_v,
                                FaxNumber_v,
                                Email_v,
                                HomePage_v,
                                BankName_v,
                                TRR_v,
                                Logo_Hash_v,
                                Logo_Image_Data_v,
                                Logo_Description_v,
                                ref Atom_Organisation_ID,
                                ref Atom_OrganisationData_ID
                                ))
            {
                DataTable dt = new DataTable();
                string sql_select = "select ID from Atom_myOrganisation where Atom_OrganisationData_ID = " + Atom_OrganisationData_ID.ToString();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, null, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (iD == null)
                        {
                            iD = new ID();
                        }
                        iD.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        string sql_insert = " insert into Atom_myOrganisation  (Atom_OrganisationData_ID) values (" + Atom_OrganisationData_ID.ToString() + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, null, ref iD,  ref Err, "Atom_myOrganisation"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Insert_Atom_myOrganisation:sql_insert:Err=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:myOrg:Insert_Atom_myOrganisation:sql_select=" + sql_select + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
