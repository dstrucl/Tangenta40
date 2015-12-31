using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLTableControl;
using BlagajnaTableClass;
using DBConnectionControl40;
using System.Data;
using System.Drawing;
using DBTypes;

namespace Tangenta
{
    public static class myOrg_Person
    {
        public static long ID = 0;
        public static string_v FirstName_v = null;
        public static string_v LastName_v = null;
        public static string_v Job_v = null;
        public static string_v UserName_v = null;
        public static string_v Password_v = null;
        public static bool_v Active_v = null;
    }

    public static class myOrg
    {

        public enum enum_GetCompany_Person_Data
        {
            MyCompany_Data_OK,
            No_MyCompany_Tax_ID,
            No_MyCompany_name,
            No_MyCompany_StreetName,
            No_MyCompany_HouseNumber,
            No_MyCompany_ZIP,
            No_MyCompany_City,
            No_MyCompany_State,
            No_MyCompany_Country,
            No_MyCompanyData,
            No_MyCompany_Person_FirstName,
            No_MyCompany_Person,
            Error_Load_MyCompany_data

        };

        public static long ID = 0;
        public static string_v Name_v = null;
        public static PostAddress_v Address_v = new PostAddress_v();
        public static string_v Tax_ID_v = null;
        public static string_v Registration_ID_v = null;
        public static string_v OrganisationTYPE_v = null;
        public static long_v Office_ID_v = null;
        public static string_v Office_Name_v = null;
        public static string_v PhoneNumber_v = null;
        public static string_v FaxNumber_v = null;
        public static string_v Email_v = null;
        public static string_v HomePage_v = null;
        public static string_v BankName_v = null;
        public static string_v TRR_v = null;
        public static Image Logo = null;
        public static string_v Logo_Hash_v = null;
        public static byte_array_v Logo_Image_Data_v = null;
        public static string_v Logo_Description_v = null;





        public static enum_GetCompany_Person_Data SelectCompanyData(DataTable dt_myCompany_Person, long Last_myCompany_id,long Last_myCompany_Person_id, ref string sAddress)
        {

            string sql_my_company_person = @"Select 
                                              myCompany_Person.ID  as myCompany_Person_ID, 
                                              myCompany.ID as myCompany_ID,
                                              Office.ID as Office_ID,
                                              Office.Name as Office_Name,
                                              myorg.Name,
                                              myCompany_Person.UserName,
                                              cFirstName.FirstName,
                                              cLastName.LastName,
                                              myCompany_Person.Password,
                                              myCompany_Person.Job,
                                              cStreetName_Org.StreetName,
                                              cHouseNumber_Org.HouseNumber,
                                              cZIP_Org.ZIP,
                                              cCity_Org.City,
                                              cState_Org.State,
                                              cState_Org.State_ISO_3166_a2,
                                              cState_Org.State_ISO_3166_a3,
                                              cState_Org.State_ISO_3166_num,
                                              cCountry_Org.Country,
                                              myorg.Tax_ID,
                                              myorg.Registration_ID,
                                              orgtype.OrganisationTYPE,
                                              bank_org.Name as BankName,
                                              bankacc_org.TRR,
                                              cPhoneNumber_Org.PhoneNumber,
                                              cEmail_Org.Email,
                                              cHomePage_Org.HomePage,
                                              cPhoneNumber_Org.PhoneNumber,
                                              cFaxNumber_Org.FaxNumber,
                                              myorgdata_Logo.Image_Hash as Logo_Hash,
                                              myorgdata_Logo.Image_Data as Logo,
                                              myorgdata_Logo.Description as Logo_Description
                                              from myCompany
                                              inner join OrganisationData myorgdata on myorgdata.Organisation_ID = myCompany.ID
                                              inner join Organisation myorg on myorgdata.Organisation_ID = myorg.ID
					                          inner join Office on  Office.myCompany_ID = myCompany.id
					                          inner join myCompany_Person on  myCompany_Person.Office_ID = Office.id
					                          inner join Person on  myCompany_Person.Person_ID = Person.id 
                                              inner join cFirstName on  Person.cFirstName_ID = cFirstName.id 
                                              inner join cLastName on  Person.cLastName_ID = cLastName.id 
                                              left join cOrgType orgtype on myorgdata.cOrgType_ID = orgtype.ID
                                              left join OrganisationAccount on OrganisationAccount.Organisation_ID = myorg.ID
					                          left join PersonData on PersonData.Person_ID =  Person.id
					                          left join BankAccount bankacc_org on bankacc_org.id = OrganisationAccount.BankAccount_ID
                                              left join Bank on Bank.id = bankacc_org .Bank_ID
					                          left join Organisation bank_org on bank_org.id = Bank.Organisation_ID
                                              left join Logo myorgdata_Logo on myorgdata.Logo_ID = myorgdata_Logo.ID
					                          left join cPhoneNumber_Org on myorgdata.cPhoneNumber_Org_ID = cPhoneNumber_Org.ID
					                          left join cFaxNumber_Org on myorgdata.cFaxNumber_Org_ID = cFaxNumber_Org.ID
					                          left join cEmail_Org on myorgdata.cEmail_Org_ID = cEmail_Org.ID
					                          left join cHomePage_Org on myorgdata.cHomePage_Org_ID = cHomePage_Org.ID
                                                                left join cAddress_Org on myorgdata.cAddress_Org_ID = cAddress_Org.ID
                                                                left join cStreetName_Org on cAddress_Org.cStreetName_Org_ID = cStreetName_Org.id 
                                                                left join cHouseNumber_Org on cAddress_Org.cHouseNumber_Org_ID  = cHouseNumber_Org.id 
                                                                left join cZIP_Org on cAddress_Org.cZIP_Org_ID = cZIP_Org.id 
                                                                left join cCity_Org on cAddress_Org.cCity_Org_ID  = cCity_Org.id 
                                                                left join cState_Org on cAddress_Org.cState_Org_ID  = cState_Org.id 
                                                                left join cCountry_Org on cAddress_Org.cCountry_Org_ID  = cCountry_Org.id "
                                                                + " where myCompany.id = " + Last_myCompany_id.ToString() + " and myCompany_Person.id = " + Last_myCompany_Person_id.ToString()
                                                                + " and myCompany_Person.Active = 1 ";
            string Err = null;
            dt_myCompany_Person.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_myCompany_Person, sql_my_company_person, ref Err))
            {
                if (dt_myCompany_Person.Rows.Count > 0)
                {
                    if ((dt_myCompany_Person.Rows[0]["Name"].GetType() == typeof(string)) &&
                        (dt_myCompany_Person.Rows[0]["myCompany_ID"].GetType() == typeof(long)) &&
                        (dt_myCompany_Person.Rows[0]["myCompany_Person_ID"].GetType() == typeof(long)))
                    {
                        myOrg.ID = (long)dt_myCompany_Person.Rows[0]["myCompany_ID"];
                        myOrg_Person.ID = (long)dt_myCompany_Person.Rows[0]["myCompany_Person_ID"];
                        myOrg.Name_v = func.set_string(dt_myCompany_Person.Rows[0]["Name"]);
                        if (dt_myCompany_Person.Rows[0]["StreetName"].GetType() == typeof(string))
                        {
                            myOrg.Address_v.StreetName_v = func.set_string(dt_myCompany_Person.Rows[0]["StreetName"]);
                            if (dt_myCompany_Person.Rows[0]["HouseNumber"].GetType() == typeof(string))
                            {
                                myOrg.Address_v.HouseNumber_v = func.set_string(dt_myCompany_Person.Rows[0]["HouseNumber"]);
                                if (dt_myCompany_Person.Rows[0]["ZIP"].GetType() == typeof(string))
                                {
                                    myOrg.Address_v.ZIP_v = func.set_string(dt_myCompany_Person.Rows[0]["ZIP"]);
                                    if (dt_myCompany_Person.Rows[0]["City"].GetType() == typeof(string))
                                    {
                                        myOrg.Address_v.City_v = func.set_string(dt_myCompany_Person.Rows[0]["City"]);
                                        if (dt_myCompany_Person.Rows[0]["State"].GetType() == typeof(string))
                                        {
                                            myOrg.Address_v.State_v = func.set_string(dt_myCompany_Person.Rows[0]["State"]);
                                            myOrg.Address_v.State_ISO_3166_a2_v = func.set_string(dt_myCompany_Person.Rows[0]["State_ISO_3166_a2"]);
                                            myOrg.Address_v.State_ISO_3166_a3_v = func.set_string(dt_myCompany_Person.Rows[0]["State_ISO_3166_a3"]);
                                            myOrg.Address_v.State_ISO_3166_num_v = func.set_short(dt_myCompany_Person.Rows[0]["State_ISO_3166_num"]);
                                            if (dt_myCompany_Person.Rows[0]["Country"].GetType() == typeof(string))
                                            {
                                                myOrg.Address_v.Country_v = func.set_string(dt_myCompany_Person.Rows[0]["Country"]);
                                            }
                                            if (dt_myCompany_Person.Rows[0]["Tax_ID"].GetType() == typeof(string))
                                            {
                                                myOrg.Tax_ID_v = func.set_string(dt_myCompany_Person.Rows[0]["Tax_ID"]);

                                                myOrg.Registration_ID_v = func.set_string(dt_myCompany_Person.Rows[0]["Registration_ID"]);

                                                 myOrg.OrganisationTYPE_v = func.set_string(dt_myCompany_Person.Rows[0]["OrganisationTYPE"]);
                                                
                                                 myOrg.Office_ID_v = func.set_long(dt_myCompany_Person.Rows[0]["Office_ID"]);

                                                 myOrg.Office_Name_v = func.set_string(dt_myCompany_Person.Rows[0]["Office_Name"]);

                                                 myOrg.BankName_v = func.set_string(dt_myCompany_Person.Rows[0]["BankName"]);

                                                 myOrg.TRR_v = func.set_string(dt_myCompany_Person.Rows[0]["TRR"]);

                                                 myOrg.PhoneNumber_v = func.set_string(dt_myCompany_Person.Rows[0]["PhoneNumber"]);

                                                 myOrg.HomePage_v = func.set_string(dt_myCompany_Person.Rows[0]["HomePage"]);

                                                 myOrg.Email_v = func.set_string(dt_myCompany_Person.Rows[0]["Email"]);

                                                 myOrg.FaxNumber_v = func.set_string(dt_myCompany_Person.Rows[0]["FaxNumber"]);

                                                myOrg.Logo_Image_Data_v = func.set_byte_array(dt_myCompany_Person.Rows[0]["Logo"]);

                                                if (myOrg.Logo_Image_Data_v != null)
                                                {
                                                    ImageConverter ic = new ImageConverter();
                                                    myOrg.Logo = (Image)ic.ConvertFrom(myOrg.Logo_Image_Data_v.v);
                                                }

                                                myOrg.Logo_Hash_v = func.set_string(dt_myCompany_Person.Rows[0]["Logo_Hash"]);

                                                myOrg.Logo_Description_v = func.set_string(dt_myCompany_Person.Rows[0]["Logo_Description"]);

                                                //if (company_Company_id.Length > 0)
                                                //{
                                                //    company_Company_id = "\r\nMatična Številka:" + company_Company_id;
                                                //}

                                                //if (company_PhoneNumber.Length > 0)
                                                //{
                                                //    company_PhoneNumber = "\r\nTelefon:" + company_PhoneNumber;
                                                //}
                                                //if (company_Email.Length > 0)
                                                //{
                                                //    company_Email = "\r\nEmail:" + company_Email;
                                                //}
                                                //if (company_HomePage.Length > 0)
                                                //{
                                                //    company_HomePage = "\r\nDomača stran:" + company_HomePage;
                                                //}

                                                
                                                if (myOrg.Address_v.Country_v != null)
                                                {
                                                    sAddress = myOrg.Address_v.StreetName + " " + myOrg.Address_v.HouseNumber + "," + myOrg.Address_v.ZIP + " " + myOrg.Address_v.City + " " + myOrg.Address_v.Country + " " + myOrg.Address_v.State;
                                                }
                                                else
                                                {
                                                    sAddress = myOrg.Address_v.StreetName + " " + myOrg.Address_v.HouseNumber + "," + myOrg.Address_v.ZIP + " " + myOrg.Address_v.City + " " + myOrg.Address_v.State;
                                                }


                                                if (dt_myCompany_Person.Rows[0]["FirstName"].GetType() == typeof(string))
                                                {
                                                    myOrg_Person.FirstName_v = func.set_string(dt_myCompany_Person.Rows[0]["FirstName"]);

                                                    myOrg_Person.LastName_v = func.set_string(dt_myCompany_Person.Rows[0]["LastName"]);

                                                    myOrg_Person.Job_v = func.set_string(dt_myCompany_Person.Rows[0]["Job"]);

                                                    myOrg_Person.UserName_v = func.set_string(dt_myCompany_Person.Rows[0]["UserName"]);

                                                    myOrg_Person.Password_v = func.set_string(dt_myCompany_Person.Rows[0]["Password"]);
                                                    

                                                    return enum_GetCompany_Person_Data.MyCompany_Data_OK;
                                                }
                                                else
                                                {
                                                    return enum_GetCompany_Person_Data.No_MyCompany_Person_FirstName;
                                                }

                                            }
                                            else
                                            {
                                                return enum_GetCompany_Person_Data.No_MyCompany_Tax_ID;
                                            }
                                        }
                                        else
                                        {
                                            return enum_GetCompany_Person_Data.No_MyCompany_State;
                                        }
                                    }
                                    else
                                    {
                                        return enum_GetCompany_Person_Data.No_MyCompany_City;
                                    }
                                }
                                else
                                {
                                    return enum_GetCompany_Person_Data.No_MyCompany_ZIP;
                                }
                            }
                            else
                            {
                                return enum_GetCompany_Person_Data.No_MyCompany_HouseNumber;
                            }
                        }
                        else
                        {
                            return enum_GetCompany_Person_Data.No_MyCompany_StreetName;
                        }
                    }
                    else
                    {
                        return enum_GetCompany_Person_Data.No_MyCompany_name;
                    }
                }
                else
                {
                    return enum_GetCompany_Person_Data.No_MyCompany_Person;
                }

            }
            else
            {
                return enum_GetCompany_Person_Data.Error_Load_MyCompany_data;
            }

        }






    }
}
