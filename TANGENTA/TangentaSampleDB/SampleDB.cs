using CodeTables;
using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;

namespace TangentaSampleDB
{
    public class SampleDB
    {
        string_v MyOrg_Name_v = null;
        string_v MyOrg_Tax_ID_v = null;
        string_v MyOrg_Registration_ID_v = null;
        string_v MyOrg_OrganisationTYPE_v = null;
        PostAddress_v MyOrg_Address_v = null;
        string_v MyOrg_PhoneNumber_v = null;
        string_v MyOrg_FaxNumber_v = null;
        string_v MyOrg_Email_v = null;
        string_v MyOrg_HomePage_v = null;
        string_v MyOrg_BankName_v = null;
        string_v MyOrg_TRR_v = null;



        string_v MyOrg_Image_Hash_v = null;
        byte_array_v MyOrg_Image_Data_v = null;
        string_v MyOrg_Image_Description_v = null;
        long_v MyOrg_Organisation_ID_v = null;
        long_v MyOrg_OrganisationData_ID_v = null;

        string_v MyOrg_OfficeName_v = null;
        string_v MyOrg_OfficeShortName_v = null;

        bool_v   MyOrg_Person_Gender_v = null;
        string_v MyOrg_Person_FirstName_v = null;
        string_v MyOrg_Person_LastName_v = null;
        DateTime_v MyOrg_Person_DateOfBirth_v = null;
        string_v MyOrg_Person_Tax_ID_v = null;
        string_v MyOrg_Person_Registration_ID_v = null;
        string_v MyOrg_Person_GsmNumber_v = null;
        string_v MyOrg_Person_PhoneNumber_v = null;
        string_v MyOrg_Person_Email_v = null;
        string_v MyOrg_Person_StreetName_v = null;
        string_v MyOrg_Person_HouseNumber_v = null;
        string_v MyOrg_Person_City_v = null;
        string_v MyOrg_Person_ZIP_v = null;


        string_v MyOrg_Person_UserName_v = null;
        string_v MyOrg_Person_Password_v = null;
        string_v MyOrg_Person_Job_v = null;
        bool_v MyOrg_Person_Active_v = null;
        string_v MyOrg_Person_Description_v = null;
        long_v MyOrg_Person_Person_ID_v = null;
        long_v MyOrg_Person_Office_ID_v = null;

        string_v MyOrg_Person_Country_v = null;
        string_v MyOrg_Person_Country_ISO_3166_a2 = null;
        string_v MyOrg_Person_Country_ISO_3166_a3 = null;
        short_v  MyOrg_Person_Country_ISO_3166_num = null;

        string_v MyOrg_Person_State_v = null;
        string_v MyOrg_Person_CardNumber_v = null;
        string_v MyOrg_Person_CardType_v = null;
        string_v MyOrg_Person_Image_Hash_v = null;
        byte_array_v MyOrg_Person_Image_Data_v = null;
        long_v MyOrg_Person_Atom_Person_ID_v = null;

        public SampleDB()
        {

            MyOrg_Name_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Organisation_Name_v.s);
            MyOrg_Tax_ID_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Tax_ID_v.s);
            MyOrg_Registration_ID_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Registration_ID_v.s);
            MyOrg_OrganisationTYPE_v = new DBTypes.string_v(lngRPMS.s_MyOrg_OrganisationTYPE_v.s);

            MyOrg_PhoneNumber_v = new DBTypes.string_v(lngRPMS.s_MyOrg_PhoneNumber_v.s);
            MyOrg_FaxNumber_v = new DBTypes.string_v(lngRPMS.s_MyOrg_FaxNumber_v.s);
            MyOrg_Email_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Email_v.s);
            MyOrg_HomePage_v = new DBTypes.string_v(lngRPMS.s_MyOrg_HomePage_v.s);
            MyOrg_BankName_v = new DBTypes.string_v(lngRPMS.s_MyOrg_BankName_v.s);
            MyOrg_TRR_v = new DBTypes.string_v(lngRPMS.s_MyOrg_TRR_v.s);


            if (LanguageControl.DynSettings.LanguageID == 0)
            {
                MyOrg_Person_Gender_v = new bool_v(true); //Male
            }
             else
            {
                MyOrg_Person_Gender_v = new bool_v(false); //Female
            }

            MyOrg_Person_FirstName_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_FirstName_v.s);
            MyOrg_Person_LastName_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_LastName_v.s);
            DateTime dt_DateOfBirth = new DateTime(2000, 1, 1);
            MyOrg_Person_DateOfBirth_v = new DateTime_v(dt_DateOfBirth);
            MyOrg_Person_Tax_ID_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_Tax_ID_v.s); 
            MyOrg_Person_Registration_ID_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Registration_ID_v.s);
            MyOrg_Person_GsmNumber_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_GsmNumber_v.s);
            MyOrg_Person_PhoneNumber_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_PhoneNumber_v.s);
            MyOrg_Person_Email_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_Email_v.s);

            MyOrg_Person_StreetName_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_StreetName_v.s); ;
            MyOrg_Person_HouseNumber_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_HouseNumber_v.s);
            MyOrg_Person_City_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_City_v.s);
            MyOrg_Person_ZIP_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_ZIP_v.s);

            MyOrg_OfficeName_v = new DBTypes.string_v(lngRPMS.s_MyOrg_OfficeName_v.s);
            MyOrg_OfficeShortName_v = new DBTypes.string_v(lngRPMS.s_MyOrg_OfficeShortName_v.s);


            MyOrg_Person_UserName_v =  new DBTypes.string_v(lngRPMS.s_MyOrg_Person_UserName_v.s); 
            MyOrg_Person_Password_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_Password_v.s);
            MyOrg_Person_Job_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Person_Job_v.s);
            MyOrg_Person_Active_v = new bool_v(true);
            MyOrg_Person_Description_v = null;
          

            //string_v MyOrg_Person_Country_v = null;
            //string_v MyOrg_Person_Country_ISO_3166_a2 = null;
            //string_v MyOrg_Person_Country_ISO_3166_a3 = null;
            //short_v MyOrg_Person_Country_ISO_3166_num = null;

            //string_v MyOrg_Person_State_v = null;
            //string_v MyOrg_Person_CardNumber_v = null;
            //string_v MyOrg_Person_CardType_v = null;
            //string_v MyOrg_Person_Image_Hash_v = null;
            //byte_array_v MyOrg_Person_Image_Data_v = null;
            //long_v MyOrg_Person_Atom_Person_ID_v = null;

        }
        public bool Write()
        {
            ID_v cAdressAtom_Org_iD_v = null;
            Country_ISO_3166.ISO_3166_Table myISO_3166_Table = new Country_ISO_3166.ISO_3166_Table();
            string DefaultCountry = null;
            if (DynSettings.LanguageID == DynSettings.Slovensko_ID)
            {
                DefaultCountry = "Slovenija";
            }
            Country_ISO_3166.Form_Select_Country_ISO_3166 frmsel_country = new Country_ISO_3166.Form_Select_Country_ISO_3166(myISO_3166_Table.dt_ISO_3166, DefaultCountry,lngRPMS.s_SelectCountryWhereYouPayTaxes.s);
            if (frmsel_country.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyOrg_Address_v = new PostAddress_v();
                MyOrg_Address_v.Country_v = new DBTypes.string_v(frmsel_country.Country);
                MyOrg_Address_v.Country_ISO_3166_a2_v = new DBTypes.string_v(frmsel_country.Country_ISO_3166_a2);
                MyOrg_Address_v.Country_ISO_3166_a3_v = new DBTypes.string_v(frmsel_country.Country_ISO_3166_a3);
                MyOrg_Address_v.Country_ISO_3166_num_v = new DBTypes.short_v(frmsel_country.Country_ISO_3166_num);

                MyOrg_Address_v.State_v = null;
                MyOrg_Address_v.City_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Address_City_v.s);
                MyOrg_Address_v.ZIP_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Address_ZIP_v.s);
                MyOrg_Address_v.StreetName_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Address_StreetName_v.s);
                MyOrg_Address_v.HouseNumber_v = new DBTypes.string_v(lngRPMS.s_MyOrg_Address_HouseNumber_v.s);
                

                if (f_Organisation.Get(MyOrg_Name_v,
                                     MyOrg_Tax_ID_v,
                                     MyOrg_Registration_ID_v,
                                     MyOrg_OrganisationTYPE_v,
                                     MyOrg_Address_v,
                                     MyOrg_PhoneNumber_v,
                                     MyOrg_FaxNumber_v,
                                     MyOrg_Email_v,
                                      MyOrg_HomePage_v,
                                      MyOrg_BankName_v,
                                      MyOrg_TRR_v,
                                      MyOrg_Image_Hash_v,
                                      MyOrg_Image_Data_v,
                                      MyOrg_Image_Description_v,
                                         ref cAdressAtom_Org_iD_v,
                                         ref  MyOrg_Organisation_ID_v,
                                         ref  MyOrg_OrganisationData_ID_v))
                {
                    long myOrganisation_ID = -1;
                    if (f_myOrganisation.Get(MyOrg_OrganisationData_ID_v.v, ref myOrganisation_ID))
                    {
                        long Office_ID = -1;
                        if (f_Office.Get(MyOrg_OfficeName_v.v, MyOrg_OfficeShortName_v.v, MyOrg_Organisation_ID_v.v, ref Office_ID))
                        {
                            long Office_Data_ID = -1;
                            if (f_Office_Data.Get(cAdressAtom_Org_iD_v.v, Office_ID, null, ref Office_Data_ID))
                            {
                                long_v Person_ID_v = null;
                                if (f_Person.Get(MyOrg_Person_Gender_v,
                                                 MyOrg_Person_FirstName_v,
                                                 MyOrg_Person_LastName_v,
                                                 MyOrg_Person_DateOfBirth_v,
                                                 MyOrg_Person_Tax_ID_v,
                                                 MyOrg_Person_Registration_ID_v,
                                                 ref Person_ID_v
                                                  ))
                                {
                                    MyOrg_Person_Person_ID_v = new long_v(Person_ID_v.v);
                                    MyOrg_Person_Office_ID_v = new long_v(Office_ID);
                                    long_v myOrganisation_Person_v = new long_v();
                                    if (f_myOrganisation_Person.Get(MyOrg_Person_UserName_v,
                                                                    MyOrg_Person_Password_v,
                                                                    MyOrg_Person_Job_v,
                                                                    MyOrg_Person_Active_v,
                                                                    MyOrg_Person_Description_v,
                                                                    MyOrg_Person_Person_ID_v,
                                                                    MyOrg_Person_Office_ID_v,
                                                                    ref myOrganisation_Person_v))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }



        public bool Insert_MyOrgData()
        {

            return false;
        }

        public bool WriteShopBItems()
        {
            string Currency_Name = null;
            string Currency_Abbreviation = null;
            string Currency_Symbol = null;
            int Currency_Code = 0;
            int Currency_DecimalPlaces = 2;

            //f myOrg.Default_Currency_ID

            SampleDB_Price_SimpleItem[] SampleDB_Price_SimpleItem_List = new SampleDB_Price_SimpleItem[]
            {new SampleDB_Price_SimpleItem(lngRPMS.SimpleItem_Name_Pedicure.s,
                                           lngRPMS.SimpleItem_Abbreviation_Pedicure.s,
                                           true,
                                           Properties.Resources.Pedikira,
                                           null,
                                           lngRPMS.SimpleItem_ParentGroup1.s,
                                           null,
                                           null,
                                           lngRPMS.PriceList_Name.s,
                                           true,
                                           null,
                                           null,
                                           new DateTime_v(DateTime.Now),
                                           lngRPMS.PriceList_Description.s,
                                           Currency_Abbreviation,
                                           Currency_Name,
                                           Currency_Symbol,
                                           Currency_Code,
                                           Currency_DecimalPlaces,null,0,0,null
                              )};
            return false;
        }
    }
}
