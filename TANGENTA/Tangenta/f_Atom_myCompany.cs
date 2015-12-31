using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LogFile;
using DBTypes;
using SQLTableControl;
namespace Tangenta
{
    internal static class f_Atom_myCompany
    {
        internal static myOrg.enum_GetCompany_Person_Data Get(long myCompany_ID, ref long Atom_myCompany_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();

            string sql_find_Atom_myCompany_ID = @"select
                                Atom_myCompany.ID as Atom_myCompany_ID
                                from Atom_myCompany
                                inner join Atom_OrganisationData on Atom_myCompany.Atom_OrganisationData_ID = Atom_OrganisationData.ID
                                inner join Atom_Organisation on Atom_OrganisationData.Atom_Organisation_ID = Atom_Organisation.ID
                                left join Atom_cAddress_Org on Atom_OrganisationData.Atom_cAddress_Org_ID = Atom_cAddress_Org.ID
                                left join Atom_cStreetName_Org on Atom_cAddress_Org.Atom_cStreetName_Org_ID = Atom_cStreetName_Org.ID
                                left join Atom_cHouseNumber_Org on Atom_cAddress_Org.Atom_cHouseNumber_Org_ID = Atom_cHouseNumber_Org.ID
                                left join Atom_cCity_Org on Atom_cAddress_Org.Atom_cCity_Org_ID = Atom_cCity_Org.ID
                                left join Atom_cZIP_Org on Atom_cAddress_Org.Atom_cZIP_Org_ID = Atom_cZIP_Org.ID
                                left join Atom_cState_Org on Atom_cAddress_Org.Atom_cState_Org_ID = Atom_cState_Org.ID
                                left join Atom_cCountry_Org on Atom_cAddress_Org.Atom_cCountry_Org_ID = Atom_cCountry_Org.ID
                                inner join Organisation on Organisation.Name = Atom_Organisation.Name
                                           and ((Organisation.Tax_ID = Atom_Organisation.Tax_ID) or ( Organisation.Tax_ID is null and  Atom_Organisation.Tax_ID is null))
                                           and ((Organisation.Registration_ID = Atom_Organisation.Registration_ID) or (Organisation.Registration_ID is null and Atom_Organisation.Registration_ID is null))
                                left  join OrganisationData on OrganisationData.Organisation_ID = Organisation.ID
				                left  join myCompany on myCompany.OrganisationData_ID = OrganisationData.ID
                                left  join cAddress_Org on OrganisationData.cAddress_Org_ID = cAddress_Org.ID
                                left  join cStreetName_Org on cAddress_Org.cStreetName_Org_ID = cStreetName_Org.ID
                                left  join cHouseNumber_Org on cAddress_Org.cHouseNumber_Org_ID = cHouseNumber_Org.ID
                                left  join cCity_Org on cAddress_Org.cCity_Org_ID = cCity_Org.ID
                                left  join cZIP_Org on cAddress_Org.cZIP_Org_ID = cZIP_Org.ID
                                left  join cState_Org on cAddress_Org.cState_Org_ID = cState_Org.ID
                                left  join cCountry_Org on cAddress_Org.cCountry_Org_ID = cCountry_Org.ID
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
                                ( ( cState_Org.State is null  and   Atom_cState_Org.State is null )  or  ( cState_Org.State = Atom_cState_Org.State ) ) and
                                ( ( cCountry_Org.Country is null and  Atom_cCountry_Org.Country is null  ) or  (cCountry_Org.Country = Atom_cCountry_Org.Country ) ) and
                                myCompany.id = " + myCompany_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql_find_Atom_myCompany_ID, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_myCompany_ID = (long)dt.Rows[0]["Atom_myCompany_ID"];
                }
                else
                {
                    ID_v Atom_myCompany_iD_v = null;
                    if (myOrg.Name_v == null)
                    {   
                        DataTable dt_myCompanyData = new DataTable();
                        string s_Address = null;
                        return myOrg.SelectCompanyData(dt_myCompanyData, 1, 1, ref s_Address);
                    }
                    if (!f_Atom_myCompany.Get(myOrg.Name_v,
                                              myOrg.Tax_ID_v,
                                              myOrg.Registration_ID_v,
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
                                              ref Atom_myCompany_iD_v))
                    {
                        return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data;
                    }
                    if (Atom_myCompany_iD_v != null)
                    {
                        Atom_myCompany_ID = Atom_myCompany_iD_v.v;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:InsertInto_Atom_myCompany_Person:Atom_myCompany_iD_v == null!");
                        return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data; ;
                    }

                }
                return myOrg.enum_GetCompany_Person_Data.MyCompany_Data_OK;
            }
            else
            {
                LogFile.Error.Show(@"ERROR:Find_Atom_myCompany_Person_ID:select ...from Atom_myCompany:\r\nErr=" + Err);
                return myOrg.enum_GetCompany_Person_Data.Error_Load_MyCompany_data; 
            }

        }

        //string_v StreetName_v = func.set_string(Address.StreetName);
        //string_v HouseNumber_v = func.set_string(Address.HouseNumber);
        //string_v ZIP_v = func.set_string(Address.ZIP);
        //string_v City_v = func.set_string(Address.City);
        //string_v State_v = func.set_string(Address.State);
        //string_v Country_v = func.set_string(Address.Country);
        //string_v PhoneNumber_v = func.set_string(PhoneNumber);
        //string_v FaxNumber_v = func.set_string(FaxNumber);
        //string_v Email_v = func.set_string(Email);
        //string_v HomePage_v = func.set_string(HomePage);
        //string_v Logo_Hash_v = func.set_string(Logo_Hash);
        //byte_array_v Logo_Image_Data_v = func.set_byte_array(Logo);
        //string_v Logo_Description_v = func.set_string(Logo_Description);

        public static bool Get( string_v Organisation_Name_v,
                                string_v Tax_ID_v,
                                string_v Registration_ID_v,
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
                                ref ID_v iD_v)
        {
            string Err = null;
            long_v Atom_Organisation_ID_v = null;
            long_v Atom_OrganisationData_ID_v = null;

            if (f_Atom_Organisation.Get( Organisation_Name_v,
                                Tax_ID_v,
                                Registration_ID_v,
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
                                ref Atom_Organisation_ID_v,
                                ref Atom_OrganisationData_ID_v
                                ))
            {
                DataTable dt = new DataTable();
                string sql_select = "select ID from Atom_myCompany where Atom_OrganisationData_ID = " + Atom_OrganisationData_ID_v.v.ToString();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, null, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (iD_v == null)
                        {
                            iD_v = new ID_v();
                        }
                        iD_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        long Atom_myCompany_id = -1;
                        string sql_insert = " insert into Atom_myCompany  (Atom_OrganisationData_ID) values (" + Atom_OrganisationData_ID_v.v.ToString() + ")";
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, null, ref Atom_myCompany_id, ref oret, ref Err, "Atom_myCompany"))
                        {
                            if (iD_v == null)
                            {
                                iD_v = new ID_v();
                            }
                            iD_v.v = Atom_myCompany_id;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Insert_Atom_myCompany:sql_insert:Err=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:myOrg:Insert_Atom_myCompany:sql_select=" + sql_select + "\r\nErr=" + Err);
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
