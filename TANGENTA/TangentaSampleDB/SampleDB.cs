using CodeTables;
using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;
using DynEditControls;
using System.IO;
using System.Security.Cryptography;
using StaticLib;
using System.Windows.Forms;
using System.Data;

namespace TangentaSampleDB
{
    public class SampleDB
    {
        public enum eSampleType { DEMO,REAL,NONE};
        public static eSampleType eType = eSampleType.NONE;

        public class MyOrgSample
        {

            ID_v cAdressAtom_Org_iD_v = null;

            dstring_v MyOrg_Name_v = new dstring_v();
            dstring_v MyOrg_Tax_ID_v = new dstring_v();
            dstring_v MyOrg_Registration_ID_v = new dstring_v();
            dbool_v MyOrg_TaxPayer_v = new dbool_v(true);
            dstring_v MyOrg_Comment1_v = new dstring_v();
            dstring_v MyOrg_OrganisationTYPE_v = new dstring_v();

            PostAddress_v MyOrg_Address_v = new PostAddress_v();

            dstring_v MyOrg_Office_Name_v = new dstring_v();
            dstring_v MyOrg_Office_ShortName_v = new dstring_v();

            PostAddress_v MyOrg_Office_Address_v = new PostAddress_v();


            dstring_v MyOrg_PhoneNumber_v = new dstring_v();
            dstring_v MyOrg_FaxNumber_v = new dstring_v();
            dstring_v MyOrg_Email_v = new dstring_v();
            dstring_v MyOrg_HomePage_v = new dstring_v();


            dstring_v MyOrg_Bank_Name_v = new dstring_v();
            dstring_v MyOrg_Bank_Tax_ID_v = new dstring_v();
            dstring_v MyOrg_Bank_Registration_ID_v = new dstring_v();

            dstring_v MyOrg_BankAccount_Description_v = new DBTypes.dstring_v();
            dstring_v MyOrg_BankAccount_TRR_v = new dstring_v();
            dbool_v MyOrg_BankAccount_Active_v = new dbool_v();



            dstring_v MyOrg_Image_Hash_v = new dstring_v();
            dbyte_array_v MyOrg_Image_Data_v = new dbyte_array_v();
            dstring_v MyOrg_Image_Description_v = new dstring_v();
            long_v MyOrg_Organisation_ID_v = null;
            long_v MyOrg_OrganisationData_ID_v = null;


            dbool_v MyOrg_Person_Gender_v = new dbool_v();
            dstring_v MyOrg_Person_FirstName_v = new dstring_v();
            dstring_v MyOrg_Person_LastName_v = new dstring_v();
            dDateTime_v MyOrg_Person_DateOfBirth_v = new dDateTime_v();
            dstring_v MyOrg_Person_Tax_ID_v = new dstring_v();
            dstring_v MyOrg_Person_Registration_ID_v = new dstring_v();
            dstring_v MyOrg_Person_GsmNumber_v = new dstring_v();
            dstring_v MyOrg_Person_PhoneNumber_v = new dstring_v();
            dstring_v MyOrg_Person_Email_v = new dstring_v();


            dstring_v MyOrg_Person_Job_v = new dstring_v();
            dbool_v MyOrg_Person_Active_v = new dbool_v();
            dstring_v MyOrg_Person_Description_v = new dstring_v();
            long_v MyOrg_Person_Person_ID_v = null;
            long_v MyOrg_Person_Office_ID_v = null;

            PostAddress_v MyOrg_Office_Person_Address_v = new PostAddress_v();


            dstring_v MyOrg_Person_CardNumber_v = new dstring_v();
            dstring_v MyOrg_Person_CardType_v = new dstring_v();
            dstring_v MyOrg_Person_Image_Hash_v = new dstring_v();
            //byte_array_v MyOrg_Person_Image_Data_v = null;
            //long_v MyOrg_Person_Atom_Person_ID_v = null;

            DynGroupBox MyOrg_DynGroupBox = null;

            DynGroupBox MyOrg_Comment1_DynGroupBox = null;

            DynGroupBox MyOrg_BankAccount_DynGroupBox = null;

            DynGroupBox MyOrg_BankAccount_Bank_DynGroupBox = null;

            //DynGroupBox MyOrg_BankAccount_Bank_Organisation_DynGroupBox = null;

            DynGroupBox MyOrg_Address_DynGroupBox = null;

            DynGroupBox MyOrg_Address_Country_DynGroupBox = null;

            DynGroupBox MyOrg_Office_DynGroupBox = null;

            DynGroupBox MyOrg_Office_Address_DynGroupBox = null;

            DynGroupBox MyOrg_Office_Address_Country_DynGroupBox = null;

            DynGroupBox MyOrg_Office_Person_DynGroupBox = null;

            DynGroupBox MyOrg_Office_Person_Address_DynGroupBox = null;

            DynGroupBox MyOrg_Office_Person_Address_Country_DynGroupBox = null;

            public MyOrgSample()
            {
                MyOrg_Address_v.StreetName_v = new dstring_v();
                MyOrg_Address_v.HouseNumber_v = new dstring_v();
                MyOrg_Address_v.ZIP_v = new dstring_v();
                MyOrg_Address_v.City_v = new dstring_v();
                MyOrg_Address_v.State_v = new dstring_v();

                MyOrg_Office_Address_v.StreetName_v = new dstring_v();
                MyOrg_Office_Address_v.HouseNumber_v = new dstring_v();
                MyOrg_Office_Address_v.ZIP_v = new dstring_v();
                MyOrg_Office_Address_v.City_v = new dstring_v();
                MyOrg_Office_Address_v.State_v = new dstring_v();
                MyOrg_Office_Address_v.Country_v = new dstring_v();
                MyOrg_Office_Address_v.Country_ISO_3166_a2_v = new dstring_v();
                MyOrg_Office_Address_v.Country_ISO_3166_a3_v = new dstring_v();
                MyOrg_Office_Address_v.Country_ISO_3166_num_v = new dshort_v();

                MyOrg_Office_Person_Address_v.StreetName_v = new dstring_v();
                MyOrg_Office_Person_Address_v.HouseNumber_v = new dstring_v();
                MyOrg_Office_Person_Address_v.ZIP_v = new dstring_v();
                MyOrg_Office_Person_Address_v.City_v = new dstring_v();
                MyOrg_Office_Person_Address_v.State_v = new dstring_v();
                MyOrg_Office_Person_Address_v.Country_v = new dstring_v();
                MyOrg_Office_Person_Address_v.Country_ISO_3166_a2_v = new dstring_v();
                MyOrg_Office_Person_Address_v.Country_ISO_3166_a3_v = new dstring_v();
                MyOrg_Office_Person_Address_v.Country_ISO_3166_num_v = new dshort_v();
            }

            public void Init(usrc_DataEdit m_eds)
            {

                Image img = Properties.Resources.Logo;
                MyOrg_Image_Data_v.v = Func.imageToByteArray(img, img.RawFormat);

                MyOrg_DynGroupBox = m_eds.AddGroupBox("grp_MyOrg", lng.s_MyOrganisation);

                MyOrg_Comment1_DynGroupBox = MyOrg_DynGroupBox.AddGroupBox("grp_MyOrg_Comment1", lng.s_Comment1);

                MyOrg_BankAccount_DynGroupBox = MyOrg_DynGroupBox.AddGroupBox("grp_MyOrg_BankAccount", lng.s_BankAccount);

                MyOrg_BankAccount_Bank_DynGroupBox = MyOrg_BankAccount_DynGroupBox.AddGroupBox("grp_MyOrg_BankAccount_Bank", lng.s_Bank);

                MyOrg_Address_DynGroupBox = MyOrg_DynGroupBox.AddGroupBox("grp_MyOrg_Address", lng.s_Address);

                MyOrg_Address_Country_DynGroupBox = MyOrg_Address_DynGroupBox.AddGroupBox("grp_MyOrg_Address_Country", lng.s_Country);

                MyOrg_Office_DynGroupBox = MyOrg_DynGroupBox.AddGroupBox("grp_MyOrg_Office", lng.s_Office);

                MyOrg_Office_Address_DynGroupBox = MyOrg_Office_DynGroupBox.AddGroupBox("grp_MyOrg_Office_Address", lng.s_Address);

                MyOrg_Office_Address_Country_DynGroupBox = MyOrg_Office_Address_DynGroupBox.AddGroupBox("grp_MyOrg_Office_Address_Country", lng.s_Country);

                MyOrg_Office_Person_DynGroupBox = MyOrg_Office_DynGroupBox.AddGroupBox("grp_MyOrg_Office_Person", lng.s_Person);

                MyOrg_Office_Person_Address_DynGroupBox = MyOrg_Office_Person_DynGroupBox.AddGroupBox("grp_MyOrg_Office_Person_Address", lng.s_Address);

                MyOrg_Office_Person_Address_Country_DynGroupBox = MyOrg_Office_Person_Address_DynGroupBox.AddGroupBox("grp_MyOrg_Office_Person_Address_Country", lng.s_Country);

                MyOrg_DynGroupBox.Visible = true;
                MyOrg_Address_DynGroupBox.Visible = true;
                MyOrg_Office_DynGroupBox.Visible = true;
                MyOrg_Office_Address_DynGroupBox.Visible = true;
                MyOrg_Office_Person_DynGroupBox.Visible = true;
                MyOrg_Office_Person_Address_DynGroupBox.Visible = true;


                new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_Name_v, "MyOrg_Name", lng_SampleData.sl_MyOrg_Name, lng_SampleData.s_MyOrg_Name_v, lng_SampleData.sh_MyOrg_Name);

                new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_Tax_ID_v, "MyOrg_Tax_ID", lng_SampleData.sl_MyOrg_Tax_ID, lng_SampleData.s_MyOrg_Tax_ID_v, lng_SampleData.sh_MyOrg_Tax_ID);

                new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_Registration_ID_v, "MyOrg_Registration_ID", lng_SampleData.sl_MyOrg_Registration_ID, lng_SampleData.s_MyOrg_Registration_ID_v, lng_SampleData.sh_MyOrg_Registration_ID);

                new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_TaxPayer_v, "MyOrg_TaxPayer", lng_SampleData.sl_MyOrg_TaxPayer, lng_SampleData.s_MyOrg_TaxPayer_v, lng_SampleData.sh_MyOrg_TaxPayer);

                new DynEditControls.EditControl(MyOrg_Comment1_DynGroupBox, MyOrg_Comment1_v, "MyOrg_Comment1", lng_SampleData.sl_MyOrg_Comment1, lng_SampleData.s_MyOrg_Comment1_v, lng_SampleData.sh_MyOrg_Comment1);

                new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_OrganisationTYPE_v, "MyOrg_OrganisationTYPE", lng_SampleData.sl_MyOrg_OrganisationTYPE, lng_SampleData.s_MyOrg_OrganisationTYPE_v, lng_SampleData.sh_MyOrg_OrganisationTYPE);

                new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_PhoneNumber_v, "MyOrg_PhoneNumber", lng_SampleData.sl_MyOrg_PhoneNumber, lng_SampleData.s_MyOrg_PhoneNumber_v, lng_SampleData.sh_MyOrg_PhoneNumber);

                new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_FaxNumber_v, "MyOrg_FaxNumber", lng_SampleData.sl_MyOrg_FaxNumber, lng_SampleData.s_MyOrg_FaxNumber_v, lng_SampleData.sh_MyOrg_FaxNumber);

                new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_Email_v, "MyOrg_Email", lng_SampleData.sl_MyOrg_Email, lng_SampleData.s_MyOrg_Email_v, lng_SampleData.sh_MyOrg_Email);

                new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_HomePage_v, "MyOrg_HomePage", lng_SampleData.sl_MyOrg_HomePage, lng_SampleData.s_MyOrg_HomePage_v, lng_SampleData.sh_MyOrg_HomePage);

                new DynEditControls.EditControl(MyOrg_BankAccount_DynGroupBox, MyOrg_BankAccount_TRR_v, "MyOrg_BankAccount_TRR", lng_SampleData.sl_MyOrg_TRR, lng_SampleData.s_MyOrg_TRR_v, lng_SampleData.sh_MyOrg_TRR);

                new DynEditControls.EditControl(MyOrg_BankAccount_DynGroupBox, MyOrg_BankAccount_Description_v, "MyOrg_BankAccount_Description", lng_SampleData.sl_MyOrg_TRR_Description, lng_SampleData.s_MyOrg_TRR_Description_v, lng_SampleData.sh_MyOrg_TRR_Description);

                new DynEditControls.EditControl(MyOrg_BankAccount_DynGroupBox, MyOrg_BankAccount_Active_v, "MyOrg_BankAccount_Active", lng_SampleData.sl_MyOrg_TRR_Active, lng_SampleData.s_MyOrg_TRR_Active_v, lng_SampleData.sh_MyOrg_TRR_Active);

                new DynEditControls.EditControl(MyOrg_BankAccount_Bank_DynGroupBox, MyOrg_Bank_Name_v, "MyOrg_Bank_Name", lng_SampleData.sl_MyOrg_Bank_Name, lng_SampleData.s_MyOrg_Bank_Name_v, lng_SampleData.sh_MyOrg_Bank_Name);

                new DynEditControls.EditControl(MyOrg_BankAccount_Bank_DynGroupBox, MyOrg_Bank_Tax_ID_v, "MyOrg_Bank_Tax_ID", lng_SampleData.sl_MyOrg_Bank_Tax_ID, lng_SampleData.s_MyOrg_Bank_Tax_ID_v, lng_SampleData.sh_MyOrg_Bank_Tax_ID);

                new DynEditControls.EditControl(MyOrg_BankAccount_Bank_DynGroupBox, MyOrg_Bank_Registration_ID_v, "MyOrg_Bank_Registration_ID", lng_SampleData.sl_MyOrg_Bank_Registration_ID, lng_SampleData.s_MyOrg_Bank_Registration_ID_v, lng_SampleData.sh_MyOrg_Bank_Registration_ID);



                new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_Image_Data_v, "MyOrg_Logo", lng_SampleData.sl_MyOrg_Logo, lng_SampleData.s_MyOrg_Logo_v, lng_SampleData.sh_MyOrg_Logo);

                new DynEditControls.EditControl(MyOrg_Address_DynGroupBox, MyOrg_Address_v.StreetName_v, "MyOrg_Address_StreetName", lng_SampleData.sl_MyOrg_Address_StreetName, lng_SampleData.s_MyOrg_Address_StreetName_v, lng_SampleData.sh_MyOrg_Address_StreetName);
                new DynEditControls.EditControl(MyOrg_Address_DynGroupBox, MyOrg_Address_v.HouseNumber_v, "MyOrg_Address_HouseNumber", lng_SampleData.sl_MyOrg_Address_HouseNumber, lng_SampleData.s_MyOrg_Address_HouseNumber_v, lng_SampleData.sh_MyOrg_Address_HouseNumber);
                new DynEditControls.EditControl(MyOrg_Address_DynGroupBox, MyOrg_Address_v.ZIP_v, "MyOrg_Address_ZIP", lng_SampleData.sl_MyOrg_Address_ZIP, lng_SampleData.s_MyOrg_Address_ZIP_v, lng_SampleData.sh_MyOrg_Address_ZIP);
                new DynEditControls.EditControl(MyOrg_Address_DynGroupBox, MyOrg_Address_v.City_v, "MyOrg_Address_ZIP", lng_SampleData.sl_MyOrg_Address_City, lng_SampleData.s_MyOrg_Address_City_v, lng_SampleData.sh_MyOrg_Address_City);
                new DynEditControls.EditControl(MyOrg_Address_DynGroupBox, MyOrg_Address_v.State_v, "MyOrg_Address_State", lng_SampleData.sl_MyOrg_Address_State, lng_SampleData.s_MyOrg_Address_State_v, lng_SampleData.sh_MyOrg_Address_State);
                new DynEditControls.EditControl(MyOrg_Address_Country_DynGroupBox, MyOrg_Address_v.Country_v, "MyOrg_Addres_Country", lng_SampleData.sl_MyOrg_Address_Country, lng_SampleData.s_MyOrg_Address_Country_v, lng_SampleData.sh_MyOrg_Address_Country);
                new DynEditControls.EditControl(MyOrg_Address_Country_DynGroupBox, MyOrg_Address_v.Country_ISO_3166_a2_v, "MyOrg_Address_Country_ISO_3166_a2", lng_SampleData.sl_MyOrg_Address_Country_ISO_3166_a2, lng_SampleData.s_MyOrg_Address_Country_ISO_3166_a2_v, lng_SampleData.sh_MyOrg_Address_Country_ISO_3166_a2);
                new DynEditControls.EditControl(MyOrg_Address_Country_DynGroupBox, MyOrg_Address_v.Country_ISO_3166_a3_v, "MyOrg_Address_Country_ISO_3166_a3", lng_SampleData.sl_MyOrg_Address_Country_ISO_3166_a3, lng_SampleData.s_MyOrg_Address_Country_ISO_3166_a3_v, lng_SampleData.sh_MyOrg_Address_Country_ISO_3166_a3);
                new DynEditControls.EditControl(MyOrg_Address_Country_DynGroupBox, MyOrg_Address_v.Country_ISO_3166_num_v, "MyOrg_Address_Country_ISO_3166_num", lng_SampleData.sl_MyOrg_Address_Country_ISO_3166_num, lng_SampleData.s_MyOrg_Address_Country_ISO_3166_num_v, lng_SampleData.sh_MyOrg_Address_Country_ISO_3166_num);


                new DynEditControls.EditControl(MyOrg_Office_DynGroupBox, MyOrg_Office_Name_v, "MyOrg_OfficeName", lng_SampleData.sl_MyOrg_OfficeName, lng_SampleData.s_MyOrg_OfficeName_v, lng_SampleData.sh_MyOrg_OfficeName);
                new DynEditControls.EditControl(MyOrg_Office_DynGroupBox, MyOrg_Office_ShortName_v, "MyOrg_OfficeShortName", lng_SampleData.sl_MyOrg_OfficeShortName, lng_SampleData.s_MyOrg_OfficeShortName_v, lng_SampleData.sh_MyOrg_OfficeShortName);

                new DynEditControls.EditControl(MyOrg_Office_Address_DynGroupBox, MyOrg_Office_Address_v.StreetName_v, "MyOrg_Office_Address_StreetName", lng_SampleData.sl_MyOrg_Office_Address_StreetName, lng_SampleData.s_MyOrg_Office_Address_StreetName_v, lng_SampleData.sh_MyOrg_Office_Address_StreetName);
                new DynEditControls.EditControl(MyOrg_Office_Address_DynGroupBox, MyOrg_Office_Address_v.HouseNumber_v, "MyOrg_Office_Address_HouseNumber", lng_SampleData.sl_MyOrg_Office_Address_HouseNumber, lng_SampleData.s_MyOrg_Office_Address_HouseNumber_v, lng_SampleData.sh_MyOrg_Office_Address_HouseNumber);
                new DynEditControls.EditControl(MyOrg_Office_Address_DynGroupBox, MyOrg_Office_Address_v.ZIP_v, "MyOrg_Office_Address_ZIP", lng_SampleData.sl_MyOrg_Office_Address_ZIP, lng_SampleData.s_MyOrg_Office_Address_ZIP_v, lng_SampleData.sh_MyOrg_Office_Address_ZIP);
                new DynEditControls.EditControl(MyOrg_Office_Address_DynGroupBox, MyOrg_Office_Address_v.City_v, "MyOrg_Office_Address_ZIP", lng_SampleData.sl_MyOrg_Office_Address_City, lng_SampleData.s_MyOrg_Office_Address_City_v, lng_SampleData.sh_MyOrg_Office_Address_City);
                new DynEditControls.EditControl(MyOrg_Office_Address_DynGroupBox, MyOrg_Office_Address_v.State_v, "MyOrg_Office_Address_State", lng_SampleData.sl_MyOrg_Office_Address_State, lng_SampleData.s_MyOrg_Office_Address_State_v, lng_SampleData.sh_MyOrg_Office_Address_State);
                new DynEditControls.EditControl(MyOrg_Office_Address_Country_DynGroupBox, MyOrg_Office_Address_v.Country_v, "MyOrg_Addres_Country", lng_SampleData.sl_MyOrg_Address_Country, lng_SampleData.s_MyOrg_Office_Address_Country_v, lng_SampleData.sh_MyOrg_Office_Address_Country);
                new DynEditControls.EditControl(MyOrg_Office_Address_Country_DynGroupBox, MyOrg_Office_Address_v.Country_ISO_3166_a2_v, "MyOrg_Office_Address_Country_ISO_3166_a2", lng_SampleData.sl_MyOrg_Office_Address_Country_ISO_3166_a2, lng_SampleData.s_MyOrg_Office_Address_Country_ISO_3166_a2_v, lng_SampleData.sh_MyOrg_Office_Address_Country_ISO_3166_a2);
                new DynEditControls.EditControl(MyOrg_Office_Address_Country_DynGroupBox, MyOrg_Office_Address_v.Country_ISO_3166_a3_v, "MyOrg_Office_Address_Country_ISO_3166_a3", lng_SampleData.sl_MyOrg_Office_Address_Country_ISO_3166_a3, lng_SampleData.s_MyOrg_Office_Address_Country_ISO_3166_a3_v, lng_SampleData.sh_MyOrg_Office_Address_Country_ISO_3166_a3);
                new DynEditControls.EditControl(MyOrg_Office_Address_Country_DynGroupBox, MyOrg_Office_Address_v.Country_ISO_3166_num_v, "MyOrg_Office_Address_Country_ISO_3166_num", lng_SampleData.sl_MyOrg_Office_Address_Country_ISO_3166_num, lng_SampleData.s_MyOrg_Office_Address_Country_ISO_3166_num_v, lng_SampleData.sh_MyOrg_Office_Address_Country_ISO_3166_num);




                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_FirstName_v, "MyOrg_Person_FirstName", lng_SampleData.sl_MyOrg_Person_FirstName, lng_SampleData.s_MyOrg_Person_FirstName_v, lng_SampleData.sh_MyOrg_Person_FirstName);

                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_LastName_v, "MyOrg_Person_LastName", lng_SampleData.sl_MyOrg_Person_LastName, lng_SampleData.s_MyOrg_Person_LastName_v, lng_SampleData.sh_MyOrg_Person_LastName);

                if (LanguageControl.DynSettings.LanguageID == DynSettings.Slovensko_ID)
                {
                    MyOrg_Person_Gender_v.v = false;
                }
                else
                {
                    MyOrg_Person_Gender_v.v = true;
                }
                MyOrg_Person_Gender_v.defined = true;
                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Gender_v, "MyOrg_Person_Gender", lng_SampleData.sl_MyOrg_Person_Gender, lng_SampleData.s_MyOrg_Person_Gender_v, lng_SampleData.sh_MyOrg_Person_Gender);

                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_DateOfBirth_v, "MyOrg_Person_DateOfBirth", lng_SampleData.sl_MyOrg_Person_DateOfBirth, lng_SampleData.s_MyOrg_Person_DateOfBirth_v, lng_SampleData.sh_MyOrg_Person_DateOfBirth);

                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Job_v, "MyOrg_Person_Job", lng_SampleData.sl_MyOrg_Person_Job, lng_SampleData.s_MyOrg_Person_Job_v, lng_SampleData.sh_MyOrg_Person_Job);

                MyOrg_Person_Active_v = new dbool_v(true);

                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Description_v, " MyOrg_Person_Description", lng_SampleData.sl_MyOrg_Person_Description, lng_SampleData.s_MyOrg_Person_Description_v, lng_SampleData.sh_MyOrg_Person_Description);

                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Tax_ID_v, "MyOrg_Person_Tax_ID", lng_SampleData.sl_MyOrg_Person_Tax_ID, lng_SampleData.s_MyOrg_Person_Tax_ID_v, lng_SampleData.sh_MyOrg_Person_Tax_ID);

                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Registration_ID_v, "MyOrg_Person_Registration_ID", lng_SampleData.sl_MyOrg_Person_Registration_ID, lng_SampleData.s_MyOrg_Person_Registration_ID_v, lng_SampleData.sh_MyOrg_Person_Registration_ID);

                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_GsmNumber_v, "MyOrg_Person_GsmNumber", lng_SampleData.sl_MyOrg_Person_GsmNumber, lng_SampleData.s_MyOrg_Person_GsmNumber_v, lng_SampleData.sh_MyOrg_Person_GsmNumber);

                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_PhoneNumber_v, "MyOrg_Person_PhoneNumber", lng_SampleData.sl_MyOrg_Person_PhoneNumber, lng_SampleData.s_MyOrg_Person_PhoneNumber_v, lng_SampleData.sh_MyOrg_Person_PhoneNumber);

                new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Email_v, "MyOrg_Person_Email", lng_SampleData.sl_MyOrg_Person_Email, lng_SampleData.s_MyOrg_Person_Email_v, lng_SampleData.sh_MyOrg_Person_Email);

                new DynEditControls.EditControl(MyOrg_Office_Person_Address_DynGroupBox, MyOrg_Office_Person_Address_v.StreetName_v, "MyOrg_Office_Person_Address_StreetName", lng_SampleData.sl_MyOrg_Office_Person_Address_StreetName, lng_SampleData.s_MyOrg_Office_Person_Address_StreetName_v, lng_SampleData.sh_MyOrg_Office_Person_Address_StreetName);
                new DynEditControls.EditControl(MyOrg_Office_Person_Address_DynGroupBox, MyOrg_Office_Person_Address_v.HouseNumber_v, "MyOrg_Office_Person_Address_HouseNumber", lng_SampleData.sl_MyOrg_Office_Person_Address_HouseNumber, lng_SampleData.s_MyOrg_Office_Person_Address_HouseNumber_v, lng_SampleData.sh_MyOrg_Office_Person_Address_HouseNumber);
                new DynEditControls.EditControl(MyOrg_Office_Person_Address_DynGroupBox, MyOrg_Office_Person_Address_v.ZIP_v, "MyOrg_Office_Person_Address_ZIP", lng_SampleData.sl_MyOrg_Office_Person_Address_ZIP, lng_SampleData.s_MyOrg_Office_Person_Address_ZIP_v, lng_SampleData.sh_MyOrg_Office_Person_Address_ZIP);
                new DynEditControls.EditControl(MyOrg_Office_Person_Address_DynGroupBox, MyOrg_Office_Person_Address_v.City_v, "MyOrg_Office_Person_Address_ZIP", lng_SampleData.sl_MyOrg_Office_Person_Address_City, lng_SampleData.s_MyOrg_Office_Person_Address_City_v, lng_SampleData.sh_MyOrg_Office_Person_Address_City);
                new DynEditControls.EditControl(MyOrg_Office_Person_Address_DynGroupBox, MyOrg_Office_Person_Address_v.State_v, "MyOrg_Office_Person_Address_State", lng_SampleData.sl_MyOrg_Office_Person_Address_State, lng_SampleData.s_MyOrg_Office_Person_Address_State_v, lng_SampleData.sh_MyOrg_Office_Person_Address_State);
                new DynEditControls.EditControl(MyOrg_Office_Person_Address_Country_DynGroupBox, MyOrg_Office_Person_Address_v.Country_v, "MyOrg_Office_Person_Address_Country", lng_SampleData.sl_MyOrg_Address_Country, lng_SampleData.s_MyOrg_Office_Person_Address_Country_v, lng_SampleData.sh_MyOrg_Office_Person_Address_Country);
                new DynEditControls.EditControl(MyOrg_Office_Person_Address_Country_DynGroupBox, MyOrg_Office_Person_Address_v.Country_ISO_3166_a2_v, "MyOrg_Office_Person_Address_Country_ISO_3166_a2", lng_SampleData.sl_MyOrg_Office_Person_Address_Country_ISO_3166_a2, lng_SampleData.s_MyOrg_Office_Person_Address_Country_ISO_3166_a2_v, lng_SampleData.sh_MyOrg_Office_Person_Address_Country_ISO_3166_a2);
                new DynEditControls.EditControl(MyOrg_Office_Person_Address_Country_DynGroupBox, MyOrg_Office_Person_Address_v.Country_ISO_3166_a3_v, "MyOrg_Office_Person_Address_Country_ISO_3166_a3", lng_SampleData.sl_MyOrg_Office_Person_Address_Country_ISO_3166_a3, lng_SampleData.s_MyOrg_Office_Person_Address_Country_ISO_3166_a3_v, lng_SampleData.sh_MyOrg_Office_Person_Address_Country_ISO_3166_a3);
                new DynEditControls.EditControl(MyOrg_Office_Person_Address_Country_DynGroupBox, MyOrg_Office_Person_Address_v.Country_ISO_3166_num_v, "MyOrg_Office_Person_Address_Country_ISO_3166_num", lng_SampleData.sl_MyOrg_Office_Person_Address_Country_ISO_3166_num, lng_SampleData.s_MyOrg_Office_Person_Address_Country_ISO_3166_num_v, lng_SampleData.sh_MyOrg_Office_Person_Address_Country_ISO_3166_num);


                //MyOrg_Office_Name_v = new DBTypes.dstring_v(lng.s_MyOrg_OfficeName_v.s);
                //MyOrg_Office_ShortName_v = new DBTypes.dstring_v(lng.s_MyOrg_OfficeShortName_v.s);

                MyOrg_Address_Country_DynGroupBox.ReadOnly = true;
                MyOrg_Office_Address_Country_DynGroupBox.ReadOnly = true;
                MyOrg_Office_Person_Address_Country_DynGroupBox.ReadOnly = true;
            }

            public void SetCountry(Country_ISO_3166.Form_Select_Country_ISO_3166 frmsel_country)
            {
                MyOrg_Address_v.Country_v = new DBTypes.dstring_v(frmsel_country.Country);
                MyOrg_Address_v.Country_ISO_3166_a2_v = new DBTypes.dstring_v(frmsel_country.Country_ISO_3166_a2);
                MyOrg_Address_v.Country_ISO_3166_a3_v = new DBTypes.dstring_v(frmsel_country.Country_ISO_3166_a3);
                MyOrg_Address_v.Country_ISO_3166_num_v = new DBTypes.dshort_v(frmsel_country.Country_ISO_3166_num);

                MyOrg_Office_Address_v.Country_v = MyOrg_Address_v.Country_v.Clone();
                MyOrg_Office_Address_v.Country_ISO_3166_a2_v = MyOrg_Address_v.Country_ISO_3166_a2_v.Clone();
                MyOrg_Office_Address_v.Country_ISO_3166_a3_v = MyOrg_Address_v.Country_ISO_3166_a3_v.Clone();
                MyOrg_Office_Address_v.Country_ISO_3166_num_v = MyOrg_Address_v.Country_ISO_3166_num_v.Clone();

                MyOrg_Office_Person_Address_v.Country_v = MyOrg_Address_v.Country_v.Clone();
                MyOrg_Office_Person_Address_v.Country_ISO_3166_a2_v = MyOrg_Address_v.Country_ISO_3166_a2_v.Clone();
                MyOrg_Office_Person_Address_v.Country_ISO_3166_a3_v = MyOrg_Address_v.Country_ISO_3166_a3_v.Clone();
                MyOrg_Office_Person_Address_v.Country_ISO_3166_num_v = MyOrg_Address_v.Country_ISO_3166_num_v.Clone();
            }




            public bool Write()
            {
                if (MyOrg_Image_Data_v != null)
                {
                    if (MyOrg_Image_Data_v.v != null)
                    {
                        MyOrg_Image_Hash_v.v = Func.GetHash_SHA1(MyOrg_Image_Data_v.v);
                    }
                }
                long_v Bank_Organisation_ID_v = null;
                if (f_Organisation.Get(MyOrg_Bank_Name_v, MyOrg_Bank_Tax_ID_v, MyOrg_Bank_Registration_ID_v, ref Bank_Organisation_ID_v))
                {
                    long_v Bank_ID_v = null;
                    if (f_Bank.Get(Bank_Organisation_ID_v, ref Bank_ID_v))
                    {

                        long_v MyOrg_BankAccount_ID_v = null;
                        long_v OrganisationAccount_ID_v = null;
                        if (f_BankAccount.Get(MyOrg_BankAccount_TRR_v, MyOrg_BankAccount_Active_v, MyOrg_BankAccount_Description_v, Bank_ID_v, ref MyOrg_BankAccount_ID_v))
                        {
                            if (f_Organisation.Get(MyOrg_Name_v,
                                                MyOrg_Tax_ID_v,
                                                MyOrg_Registration_ID_v,
                                                MyOrg_TaxPayer_v,
                                                MyOrg_Comment1_v,
                                                MyOrg_OrganisationTYPE_v,
                                                MyOrg_Address_v,
                                                MyOrg_PhoneNumber_v,
                                                MyOrg_FaxNumber_v,
                                                MyOrg_Email_v,
                                                MyOrg_HomePage_v,
                                                MyOrg_BankAccount_ID_v,
                                                MyOrg_BankAccount_Description_v,
                                                MyOrg_Image_Hash_v,
                                                MyOrg_Image_Data_v,
                                                MyOrg_Image_Description_v,
                                                    ref cAdressAtom_Org_iD_v,
                                                    ref MyOrg_Organisation_ID_v,
                                                    ref MyOrg_OrganisationData_ID_v,
                                                    ref OrganisationAccount_ID_v))
                            {
                                if (f_OrganisationAccount.Get(MyOrg_BankAccount_ID_v, MyOrg_Organisation_ID_v, MyOrg_BankAccount_Description_v, ref OrganisationAccount_ID_v))
                                {
                                    long myOrganisation_ID = -1;
                                    if (f_myOrganisation.Get(MyOrg_OrganisationData_ID_v.v, ref myOrganisation_ID))
                                    {
                                        long Office_ID = -1;
                                        if (f_Office.Get(MyOrg_Office_Name_v.v, MyOrg_Office_ShortName_v.v, myOrganisation_ID, ref Office_ID))
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
                                                    if (f_myOrganisation_Person.Get(MyOrg_Person_Job_v,
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
                        }
                    }
                }
                return false;
            }
        }

        public bool WriteMyOrg()
        {
            return myOrgSample.Write();
        }

        public MyOrgSample myOrgSample = null;

        public SampleDB()
        {
            myOrgSample = new MyOrgSample();
        }


        public void Init(usrc_DataEdit m_eds)
        {
            myOrgSample.Init(m_eds);
        }


        public bool Startup_05_Show_Form_EditMyOrgSampleData(ref bool bCanceled, NavigationButtons.Navigation xnav, Icon oIcon)
        {
            xnav.ShowForm(new Form_EditMyOrgSampleData(this, xnav, oIcon), "TangentaSampleDB.Form_EditMyOrgSampleData");
            return true;
        }

        internal bool Evaluate_MyOrgSampleShowForm(ref bool bCanceled, NavigationButtons.Navigation xnav, Icon oIcon)
        {
            return true;
        }

        public bool Startup_05_Form_Select_Country_ISO_3166_ShowForm(ref bool bCanceled, NavigationButtons.Navigation xnav, Icon oIcon)
        {

            Country_ISO_3166.ISO_3166_Table myISO_3166_Table = new Country_ISO_3166.ISO_3166_Table();
            string DefaultCountry_State_A3 = null;
            if (DynSettings.LanguageID == DynSettings.Slovensko_ID)
            {
                DefaultCountry_State_A3 = "SVN";
            }
            xnav.ShowForm(new Country_ISO_3166.Form_Select_Country_ISO_3166(myISO_3166_Table.dt_ISO_3166, DefaultCountry_State_A3, lng.s_SelectCountryWhereYouPayTaxes.s, xnav), "Country_ISO_3166.Form_Select_Country_ISO_3166");
            return true;
        }

        public bool Startup_05_Form_Select_Country_ISO_3116_result(Country_ISO_3166.Form_Select_Country_ISO_3166 frm_Select_Country_ISO_3166)
        {
            myOrgSample.SetCountry(frm_Select_Country_ISO_3166);
            return true;
        }


        public bool DeleteAll()
        {

            if (f_OrganisationAccount.DeleteAll())
            {
                if (f_BankAccount.DeleteAll())
                {
                    if (f_Bank.DeleteAll())
                    {
                        if (f_Office_Data.DeleteAll())
                        {
                            if (f_myOrganisation_Person.DeleteAll())
                            {
                                if (f_Office.DeleteAll())
                                {
                                    if (f_myOrganisation.DeleteAll())
                                    {
                                        if (f_OrganisationData.DeleteAll())
                                        {
                                            if (f_Person.DeleteAll())
                                            {
                                                if (f_Organisation.DeleteAll())
                                                {
                                                    if (f_cAddress_Org.DeleteAll())
                                                    {
                                                        if (f_cStreetName_Org.DeleteAll())
                                                        {
                                                            if (f_cHouseNumber_Org.DeleteAll())
                                                            {
                                                                if (f_cCity_Org.DeleteAll())
                                                                {
                                                                    if (f_cZIP_Org.DeleteAll())
                                                                    {
                                                                        if (f_cCountry_Org.DeleteAll())
                                                                        {
                                                                            if (f_cState_Org.DeleteAll())
                                                                            {
                                                                                return true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
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


        public bool Startup_10_Write_ShopB_Items(Form_Items_Samples frm_Items_Samples)
        {
            string Currency_Name = null;
            string Currency_Abbreviation = null;
            string Currency_Symbol = null;
            int Currency_Code = 0;
            int Currency_DecimalPlaces = 2;
            int iItem1 = 0;
            int iItem2 = 0;
            string Taxation_Name_B = "";
            decimal Taxation_Rate_B = 0;
            DataTable dt_Taxation = TangentaDB.f_Taxation.GetTable(false);
            if (f_Currency.Get(myOrg.Default_Currency_ID, ref Currency_Abbreviation, ref Currency_Name, ref Currency_Symbol, ref Currency_Code, ref Currency_DecimalPlaces))
            {
                
                if (frm_Items_Samples.bAutoGenerateDemoSampleItems)
                {
                    int iNumberOfGroupsInLevel3 = frm_Items_Samples.iNumberOfGroupsInLevel3;
                    int iNumberOfGroupsInLevel2 = frm_Items_Samples.iNumberOfGroupsInLevel2;
                    int iNumberOfGroupsInLevel1 = frm_Items_Samples.iNumberOfGroupsInLevel1;
                    int iNumberOfItemsPerGroup = frm_Items_Samples.iNumberOfItemsPerGroup;
                    int iNumberOfAll = frm_Items_Samples.iNumberOffAll();
                    SampleDB_Price_ShopB_Item[] SampleDB_Price_ShopB_Item_List = new SampleDB_Price_ShopB_Item[iNumberOfAll];
                    int j = 0;
                    string ShopB_Item_Abbreviation = null;
                    string ShopB_Item_Name = null;
                    string sl3 = null;
                    string sl2 = null;
                    string sl1 = null;
                    int i1 = 0;
                    int i2 = 0;
                    int i3 = 0;
                    int ig = 0;
                    decimal BRandomPrice = 0;
                    if (iNumberOfGroupsInLevel3 > 0)
                    {
                        for (i3 = 0; i3 < iNumberOfGroupsInLevel3; i3++)
                        {
                            string sln3 = " L3g" + i3.ToString();
                            sl3 = "." + sln3;
                            for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                            {
                                string sln2 = sln3 + " L2g" + i2.ToString();
                                sl2 = "." + sln2;
                                for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                                {
                                    string sln1 = sln3 + sln2 + " L1g" + i1.ToString();
                                    sl1 = "." + sln1;
                                    for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                    {
                                        SetBValues(ref ShopB_Item_Abbreviation,
                                                    ref ShopB_Item_Name,
                                                    ref Taxation_Name_B,
                                                    ref Taxation_Rate_B,
                                                    ref BRandomPrice,
                                                    Currency_DecimalPlaces,
                                                    ref iItem1,
                                                    ref iItem2,
                                                    ig,
                                                    sln1,
                                                    sln1,
                                                    dt_Taxation
                                                    );


                                        SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                                ShopB_Item_Abbreviation,
                                                                true,
                                                                null,
                                                                null,
                                                                sl1,
                                                                sl2,
                                                                sl3,
                                                                lng.PriceList_Name.s,
                                                                true,
                                                                null,
                                                                null,
                                                                new DateTime_v(DateTime.Now),
                                                                lng.PriceList_Description.s,
                                                                Currency_Abbreviation,
                                                                Currency_Name,
                                                                Currency_Symbol,
                                                                Currency_Code,
                                                                Currency_DecimalPlaces,
                                                                Taxation_Name_B,
                                                                Taxation_Rate_B,
                                                                BRandomPrice,
                                                                null);
                                        j++;
                                    }
                                }
                                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                {
                                    SetBValues(ref ShopB_Item_Abbreviation,
                                                ref ShopB_Item_Name,
                                                ref Taxation_Name_B,
                                                ref Taxation_Rate_B,
                                                ref BRandomPrice,
                                                Currency_DecimalPlaces,
                                                ref iItem1,
                                                ref iItem2,
                                                ig,
                                                sln2,
                                                sln2,
                                                dt_Taxation
                                                );

                                    SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                            ShopB_Item_Abbreviation,
                                                            true,
                                                            null,
                                                            null,
                                                            sl2,
                                                            sl3,
                                                            null,
                                                            lng.PriceList_Name.s,
                                                            true,
                                                            null,
                                                            null,
                                                            new DateTime_v(DateTime.Now),
                                                            lng.PriceList_Description.s,
                                                            Currency_Abbreviation,
                                                            Currency_Name,
                                                            Currency_Symbol,
                                                            Currency_Code,
                                                            Currency_DecimalPlaces,
                                                            Taxation_Name_B,
                                                            Taxation_Rate_B,
                                                            BRandomPrice,
                                                            null);
                                    j++;
                                }

                            }
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetBValues(ref ShopB_Item_Abbreviation,
                                            ref ShopB_Item_Name,
                                            ref Taxation_Name_B,
                                            ref Taxation_Rate_B,
                                            ref BRandomPrice,
                                            Currency_DecimalPlaces,
                                            ref iItem1,
                                            ref iItem2,
                                            ig,
                                            sln3,
                                            sln3,
                                            dt_Taxation
                                            );
                                SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                    ShopB_Item_Abbreviation,
                                                    true,
                                                    null,
                                                    null,
                                                    sl3,
                                                    null,
                                                    null,
                                                    lng.PriceList_Name.s,
                                                    true,
                                                    null,
                                                    null,
                                                    new DateTime_v(DateTime.Now),
                                                    lng.PriceList_Description.s,
                                                    Currency_Abbreviation,
                                                    Currency_Name,
                                                    Currency_Symbol,
                                                    Currency_Code,
                                                    Currency_DecimalPlaces,
                                                    Taxation_Name_B,
                                                    Taxation_Rate_B,
                                                    BRandomPrice,
                                                    null);
                                j++;
                            }
                        }
                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                        {
                            SetBValues(ref ShopB_Item_Abbreviation,
                                        ref ShopB_Item_Name,
                                        ref Taxation_Name_B,
                                        ref Taxation_Rate_B,
                                        ref BRandomPrice,
                                        Currency_DecimalPlaces,
                                        ref iItem1,
                                        ref iItem2,
                                        ig,
                                        " noL1noL2noL3",
                                        " noL1noL2noL3",
                                        dt_Taxation
                                        );
                            SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                    ShopB_Item_Abbreviation,
                                                    true,
                                                    null,
                                                    null,
                                                    null,
                                                    null,
                                                    null,
                                                    lng.PriceList_Name.s,
                                                    true,
                                                    null,
                                                    null,
                                                    new DateTime_v(DateTime.Now),
                                                    lng.PriceList_Description.s,
                                                    Currency_Abbreviation,
                                                    Currency_Name,
                                                    Currency_Symbol,
                                                    Currency_Code,
                                                    Currency_DecimalPlaces,
                                                    Taxation_Name_B,
                                                    Taxation_Rate_B,
                                                    BRandomPrice,
                                                    null);
                            j++;
                        }
                    }
                    else if (iNumberOfGroupsInLevel2 > 0)
                    {
                        for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                        {
                            sl2 = ".L2g" + i2.ToString();
                            for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                            {
                                sl1 = ".L1g" + i1.ToString();
                                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                {
                                    SetBValues(ref ShopB_Item_Abbreviation,
                                        ref ShopB_Item_Name,
                                        ref Taxation_Name_B,
                                        ref Taxation_Rate_B,
                                        ref BRandomPrice,
                                        Currency_DecimalPlaces,
                                        ref iItem1,
                                        ref iItem2,
                                        ig,
                                        sl2 + sl1,
                                        sl2 + sl1,
                                        dt_Taxation
                                        );
                                    SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                            ShopB_Item_Abbreviation,
                                                            true,
                                                            null,
                                                            null,
                                                            sl1,
                                                            sl2,
                                                            null,
                                                            lng.PriceList_Name.s,
                                                            true,
                                                            null,
                                                            null,
                                                            new DateTime_v(DateTime.Now),
                                                            lng.PriceList_Description.s,
                                                            Currency_Abbreviation,
                                                            Currency_Name,
                                                            Currency_Symbol,
                                                            Currency_Code,
                                                            Currency_DecimalPlaces,
                                                            Taxation_Name_B,
                                                            Taxation_Rate_B,
                                                            BRandomPrice,
                                                            null);
                                    j++;
                                }
                            }
                        }
                        for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                        {
                            sl2 = ".L2g" + i2.ToString() + "(...)";
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetBValues(ref ShopB_Item_Abbreviation,
                                            ref ShopB_Item_Name,
                                            ref Taxation_Name_B,
                                            ref Taxation_Rate_B,
                                            ref BRandomPrice,
                                            Currency_DecimalPlaces,
                                            ref iItem1,
                                            ref iItem2,
                                            ig,
                                            sl2,
                                            sl2,
                                            dt_Taxation
                                            );
                                SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                        ShopB_Item_Abbreviation,
                                                        true,
                                                        null,
                                                        null,
                                                        sl2,
                                                        null,
                                                        null,
                                                        lng.PriceList_Name.s,
                                                        true,
                                                        null,
                                                        null,
                                                        new DateTime_v(DateTime.Now),
                                                        lng.PriceList_Description.s,
                                                        Currency_Abbreviation,
                                                        Currency_Name,
                                                        Currency_Symbol,
                                                        Currency_Code,
                                                        Currency_DecimalPlaces,
                                                        Taxation_Name_B,
                                                        Taxation_Rate_B,
                                                        BRandomPrice,
                                                        null);
                                j++;
                            }
                        }
                        sl2 = "(...)";
                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                        {
                            SetBValues(ref ShopB_Item_Abbreviation,
                                                                        ref ShopB_Item_Name,
                                                                        ref Taxation_Name_B,
                                                                        ref Taxation_Rate_B,
                                                                        ref BRandomPrice,
                                                                        Currency_DecimalPlaces,
                                                                        ref iItem1,
                                                                        ref iItem2,
                                                                        ig,
                                                                        sl2,
                                                                        sl2,
                                                                        dt_Taxation
                                                                        );
                            SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                    ShopB_Item_Abbreviation,
                                                    true,
                                                    null,
                                                    null,
                                                    null,
                                                    null,
                                                    null,
                                                    lng.PriceList_Name.s,
                                                    true,
                                                    null,
                                                    null,
                                                    new DateTime_v(DateTime.Now),
                                                    lng.PriceList_Description.s,
                                                    Currency_Abbreviation,
                                                    Currency_Name,
                                                    Currency_Symbol,
                                                    Currency_Code,
                                                    Currency_DecimalPlaces,
                                                    Taxation_Name_B,
                                                    Taxation_Rate_B,
                                                    BRandomPrice,
                                                    null);
                            j++;
                        }
                    }
                    else if (iNumberOfGroupsInLevel1 > 0)
                    {
                        for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                        {
                            sl1 = ".L1g" + i1.ToString();
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetBValues(ref ShopB_Item_Abbreviation,
                                                                            ref ShopB_Item_Name,
                                                                            ref Taxation_Name_B,
                                                                            ref Taxation_Rate_B,
                                                                            ref BRandomPrice,
                                                                            Currency_DecimalPlaces,
                                                                            ref iItem1,
                                                                            ref iItem2,
                                                                            ig,
                                                                            sl1,
                                                                            sl1,
                                                                            dt_Taxation
                                                                            );
                                SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                        ShopB_Item_Abbreviation,
                                                        true,
                                                        null,
                                                        null,
                                                        sl1,
                                                        null,
                                                        null,
                                                        lng.PriceList_Name.s,
                                                        true,
                                                        null,
                                                        null,
                                                        new DateTime_v(DateTime.Now),
                                                        lng.PriceList_Description.s,
                                                        Currency_Abbreviation,
                                                        Currency_Name,
                                                        Currency_Symbol,
                                                        Currency_Code,
                                                        Currency_DecimalPlaces,
                                                        Taxation_Name_B,
                                                        Taxation_Rate_B,
                                                        BRandomPrice,
                                                        null);
                                j++;
                            }
                        }
                        sl1 = "(...)";
                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                        {
                            SetBValues(ref ShopB_Item_Abbreviation,
                                                                            ref ShopB_Item_Name,
                                                                            ref Taxation_Name_B,
                                                                            ref Taxation_Rate_B,
                                                                            ref BRandomPrice,
                                                                            Currency_DecimalPlaces,
                                                                            ref iItem1,
                                                                            ref iItem2,
                                                                            ig,
                                                                            sl1,
                                                                            sl1,
                                                                            dt_Taxation
                                                                            );
                            SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                    ShopB_Item_Abbreviation,
                                                    true,
                                                    null,
                                                    null,
                                                    null,
                                                    null,
                                                    null,
                                                    lng.PriceList_Name.s,
                                                    true,
                                                    null,
                                                    null,
                                                    new DateTime_v(DateTime.Now),
                                                    lng.PriceList_Description.s,
                                                    Currency_Abbreviation,
                                                    Currency_Name,
                                                    Currency_Symbol,
                                                    Currency_Code,
                                                    Currency_DecimalPlaces,
                                                    Taxation_Name_B,
                                                    Taxation_Rate_B,
                                                    BRandomPrice,
                                                    null);
                            j++;
                        }
                    }
                    else
                    {
                        sl1 = "(...)";
                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                        {
                            SetBValues(ref ShopB_Item_Abbreviation,
                                                                            ref ShopB_Item_Name,
                                                                            ref Taxation_Name_B,
                                                                            ref Taxation_Rate_B,
                                                                            ref BRandomPrice,
                                                                            Currency_DecimalPlaces,
                                                                            ref iItem1,
                                                                            ref iItem2,
                                                                            ig,
                                                                            sl1,
                                                                            sl1,
                                                                            dt_Taxation
                                                                            );
                            SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                    ShopB_Item_Abbreviation,
                                                    true,
                                                    null,
                                                    null,
                                                    null,
                                                    null,
                                                    null,
                                                    lng.PriceList_Name.s,
                                                    true,
                                                    null,
                                                    null,
                                                    new DateTime_v(DateTime.Now),
                                                    lng.PriceList_Description.s,
                                                    Currency_Abbreviation,
                                                    Currency_Name,
                                                    Currency_Symbol,
                                                    Currency_Code,
                                                    Currency_DecimalPlaces,
                                                    Taxation_Name_B,
                                                    Taxation_Rate_B,
                                                    BRandomPrice,
                                                    null);
                            j++;
                        }
                    }
                    //{new 
                    if (j != iNumberOfAll)
                    {
                        LogFile.Error.Show("ERROR:SampleDB:Write_ShopB_Items:Calculated number of items " + iNumberOfAll.ToString() + " is not equal to iterating number j in loop:" + j.ToString());
                    }
                    int k = 0;
                    int SampleDB_Price_ShopB_Item_List_Count = SampleDB_Price_ShopB_Item_List.Count();
                    ProgressForm.Progress_Thread progress = new ProgressForm.Progress_Thread();
                    progress.sLabel1 = lng.s_WriteItemsToDatabase.s + SampleDB_Price_ShopB_Item_List_Count.ToString();
                    progress.Start();
                    for (k = 0; k < SampleDB_Price_ShopB_Item_List_Count; k++)
                    {
                        SampleDB_Price_ShopB_Item sample_ShopB_Item = SampleDB_Price_ShopB_Item_List[k];
                        if (f_SimpleItem.Get(sample_ShopB_Item.ShopB_Item_Name,
                                                sample_ShopB_Item.ShopB_Item_Abbreviation,
                                                sample_ShopB_Item.ShopB_Item_bToOffer,
                                                sample_ShopB_Item.ShopB_Item_Image,
                                                sample_ShopB_Item.ShopB_Item_Code_v,
                                                sample_ShopB_Item.ShopB_Item_ParentGroup1,
                                                sample_ShopB_Item.ShopB_Item_ParentGroup2,
                                                sample_ShopB_Item.ShopB_Item_ParentGroup3,
                                                ref sample_ShopB_Item.ShopB_Item_ID))
                        {
                            if (f_PriceList.Get(sample_ShopB_Item.PriceList_Name,
                                                sample_ShopB_Item.PriceList_valid,
                                                myOrg.Default_Currency_ID,
                                                sample_ShopB_Item.PriceList_ValidFrom_v,
                                                sample_ShopB_Item.PriceList_ValidTo_v,
                                                sample_ShopB_Item.PriceList_CreationDate_v,
                                                sample_ShopB_Item.PriceList_Description,
                                                ref sample_ShopB_Item.PriceList_ID))
                            {
                                if (f_Taxation.Get(sample_ShopB_Item.TaxationName,
                                                    sample_ShopB_Item.TaxationRate,
                                                    ref sample_ShopB_Item.Taxation_ID))
                                {
                                    if (f_Price_SimpleItem.Get(sample_ShopB_Item.RetailShopB_ItemPrice,
                                                                sample_ShopB_Item.Discount_v,
                                                                sample_ShopB_Item.Taxation_ID,
                                                                sample_ShopB_Item.ShopB_Item_ID,
                                                                sample_ShopB_Item.PriceList_ID,
                                                                ref sample_ShopB_Item.Price_ShopB_Item_ID
                                                                ))
                                    {
                                        if (k % 5 == 0)
                                        {
                                            GC.Collect();
                                            int iPercent = ((int)(k * 100) / SampleDB_Price_ShopB_Item_List_Count);
                                            progress.Message(null, lng.s_ItemsWrittenToDB.s + " " + k.ToString(), lng.s_JobInPercentDone.s + " " + iPercent.ToString() + "%", iPercent);
                                        }
                                        if (progress.bCancel || progress.bEnd)
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        progress.End();
                                        return false;
                                    }
                                }
                                else
                                {
                                    progress.End();
                                    return false;
                                }
                            }
                            else
                            {
                                progress.End();
                                return false;
                            }
                        }
                        else
                        {
                            progress.End();
                            return false;
                        }
                        SampleDB_Price_ShopB_Item_List[k] = null;
                        sample_ShopB_Item = null;
                    }
                    progress.End();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Write_ShopB_Items(NavigationButtons.Navigation xnav)
        {
            string Currency_Name = null;
            string Currency_Abbreviation = null;
            string Currency_Symbol = null;
            int Currency_Code = 0;
            int Currency_DecimalPlaces = 2;
            int iItem1 = 0;
            int iItem2 = 0;
            string Taxation_Name_B = "";
            decimal Taxation_Rate_B = 0;
            DataTable dt_Taxation = TangentaDB.f_Taxation.GetTable(false);
            if (f_Currency.Get(myOrg.Default_Currency_ID, ref Currency_Abbreviation, ref Currency_Name, ref Currency_Symbol, ref Currency_Code, ref Currency_DecimalPlaces))
            {
                xnav.ChildDialog = new Form_Items_Samples(xnav, lng.s_Shop_B.s);
                xnav.bDoModal = false;
                xnav.ShowDialog();
                if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT)
                {
                    if (((Form_Items_Samples)xnav.ChildDialog).bAutoGenerateDemoSampleItems)
                    {
                        int iNumberOfGroupsInLevel3 = ((Form_Items_Samples)xnav.ChildDialog).iNumberOfGroupsInLevel3;
                        int iNumberOfGroupsInLevel2 = ((Form_Items_Samples)xnav.ChildDialog).iNumberOfGroupsInLevel2;
                        int iNumberOfGroupsInLevel1 = ((Form_Items_Samples)xnav.ChildDialog).iNumberOfGroupsInLevel1;
                        int iNumberOfItemsPerGroup = ((Form_Items_Samples)xnav.ChildDialog).iNumberOfItemsPerGroup;
                        int iNumberOfAll = ((Form_Items_Samples)xnav.ChildDialog).iNumberOffAll();
                        SampleDB_Price_ShopB_Item[] SampleDB_Price_ShopB_Item_List = new SampleDB_Price_ShopB_Item[iNumberOfAll];
                        int j = 0;
                        string ShopB_Item_Abbreviation = null;
                        string ShopB_Item_Name = null;
                        string sl3 = null;
                        string sl2 = null;
                        string sl1 = null;
                        int i1 = 0;
                        int i2 = 0;
                        int i3 = 0;
                        int ig = 0;
                        decimal BRandomPrice = 0;
                        if (iNumberOfGroupsInLevel3 > 0)
                        {
                            for (i3 = 0; i3 < iNumberOfGroupsInLevel3; i3++)
                            {
                                string sln3 = " L3g" + i3.ToString();
                                sl3 = "." + sln3;
                                for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                                {
                                    string sln2 = sln3+" L2g" + i2.ToString();
                                    sl2 = "." + sln2;
                                    for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                                    {
                                        string sln1 = sln3 + sln2+ " L1g" + i1.ToString();
                                        sl1 = "."+ sln1;
                                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                        {
                                            SetBValues(ref ShopB_Item_Abbreviation,
                                                       ref ShopB_Item_Name,
                                                       ref Taxation_Name_B,
                                                       ref Taxation_Rate_B,
                                                       ref BRandomPrice,
                                                       Currency_DecimalPlaces,
                                                       ref iItem1,
                                                       ref iItem2,
                                                       ig,
                                                       sln1,
                                                       sln1,
                                                       dt_Taxation
                                                       );


                                            SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                                    ShopB_Item_Abbreviation,
                                                                    true,
                                                                    null,
                                                                    null,
                                                                    sl1,
                                                                    sl2,
                                                                    sl3,
                                                                    lng.PriceList_Name.s,
                                                                    true,
                                                                    null,
                                                                    null,
                                                                    new DateTime_v(DateTime.Now),
                                                                    lng.PriceList_Description.s,
                                                                    Currency_Abbreviation,
                                                                    Currency_Name,
                                                                    Currency_Symbol,
                                                                    Currency_Code,
                                                                    Currency_DecimalPlaces,
                                                                    Taxation_Name_B,
                                                                    Taxation_Rate_B,
                                                                    BRandomPrice,
                                                                    null);
                                            j++;
                                        }
                                    }
                                    for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                    {
                                        SetBValues(ref ShopB_Item_Abbreviation,
                                                   ref ShopB_Item_Name,
                                                   ref Taxation_Name_B,
                                                   ref Taxation_Rate_B,
                                                   ref BRandomPrice,
                                                   Currency_DecimalPlaces,
                                                   ref iItem1,
                                                   ref iItem2,
                                                   ig,
                                                   sln2,
                                                   sln2,
                                                   dt_Taxation
                                                   );

                                        SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                                ShopB_Item_Abbreviation,
                                                                true,
                                                                null,
                                                                null,
                                                                sl2,
                                                                sl3,
                                                                null,
                                                                lng.PriceList_Name.s,
                                                                true,
                                                                null,
                                                                null,
                                                                new DateTime_v(DateTime.Now),
                                                                lng.PriceList_Description.s,
                                                                Currency_Abbreviation,
                                                                Currency_Name,
                                                                Currency_Symbol,
                                                                Currency_Code,
                                                                Currency_DecimalPlaces,
                                                                Taxation_Name_B,
                                                                Taxation_Rate_B,
                                                                BRandomPrice,
                                                                null);
                                        j++;
                                    }

                                }
                                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                {
                                    SetBValues(ref ShopB_Item_Abbreviation,
                                               ref ShopB_Item_Name,
                                               ref Taxation_Name_B,
                                               ref Taxation_Rate_B,
                                               ref BRandomPrice,
                                               Currency_DecimalPlaces,
                                               ref iItem1,
                                               ref iItem2,
                                               ig,
                                               sln3,
                                               sln3,
                                               dt_Taxation
                                               );
                                    SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                        ShopB_Item_Abbreviation,
                                                        true,
                                                        null,
                                                        null,
                                                        sl3,
                                                        null,
                                                        null,
                                                        lng.PriceList_Name.s,
                                                        true,
                                                        null,
                                                        null,
                                                        new DateTime_v(DateTime.Now),
                                                        lng.PriceList_Description.s,
                                                        Currency_Abbreviation,
                                                        Currency_Name,
                                                        Currency_Symbol,
                                                        Currency_Code,
                                                        Currency_DecimalPlaces,
                                                        Taxation_Name_B,
                                                        Taxation_Rate_B,
                                                        BRandomPrice,
                                                        null);
                                    j++;
                                }
                            }
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetBValues(ref ShopB_Item_Abbreviation,
                                           ref ShopB_Item_Name,
                                           ref Taxation_Name_B,
                                           ref Taxation_Rate_B,
                                           ref BRandomPrice,
                                           Currency_DecimalPlaces,
                                           ref iItem1,
                                           ref iItem2,
                                           ig,
                                           " noL1noL2noL3",
                                           " noL1noL2noL3",
                                           dt_Taxation
                                           );
                                SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                        ShopB_Item_Abbreviation,
                                                        true,
                                                        null,
                                                        null,
                                                        null,
                                                        null,
                                                        null,
                                                        lng.PriceList_Name.s,
                                                        true,
                                                        null,
                                                        null,
                                                        new DateTime_v(DateTime.Now),
                                                        lng.PriceList_Description.s,
                                                        Currency_Abbreviation,
                                                        Currency_Name,
                                                        Currency_Symbol,
                                                        Currency_Code,
                                                        Currency_DecimalPlaces,
                                                        Taxation_Name_B,
                                                        Taxation_Rate_B,
                                                        BRandomPrice,
                                                        null);
                                j++;
                            }
                        }
                        else if (iNumberOfGroupsInLevel2 > 0)
                        {
                            for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                            {
                                sl2 = ".L2g" + i2.ToString();
                                for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                                {
                                    sl1 = ".L1g" + i1.ToString();
                                    for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                    {
                                        SetBValues(ref ShopB_Item_Abbreviation,
                                           ref ShopB_Item_Name,
                                           ref Taxation_Name_B,
                                           ref Taxation_Rate_B,
                                           ref BRandomPrice,
                                           Currency_DecimalPlaces,
                                           ref iItem1,
                                           ref iItem2,
                                           ig,
                                           sl2 + sl1,
                                           sl2 + sl1,
                                           dt_Taxation
                                           );
                                        SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                                ShopB_Item_Abbreviation,
                                                                true,
                                                                null,
                                                                null,
                                                                sl1,
                                                                sl2,
                                                                null,
                                                                lng.PriceList_Name.s,
                                                                true,
                                                                null,
                                                                null,
                                                                new DateTime_v(DateTime.Now),
                                                                lng.PriceList_Description.s,
                                                                Currency_Abbreviation,
                                                                Currency_Name,
                                                                Currency_Symbol,
                                                                Currency_Code,
                                                                Currency_DecimalPlaces,
                                                                Taxation_Name_B,
                                                                Taxation_Rate_B,
                                                                BRandomPrice,
                                                                null);
                                        j++;
                                    }
                                }
                            }
                            for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                            {
                                sl2 = ".L2g" + i2.ToString() + "(...)";
                                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                {
                                    SetBValues(ref ShopB_Item_Abbreviation,
                                               ref ShopB_Item_Name,
                                               ref Taxation_Name_B,
                                               ref Taxation_Rate_B,
                                               ref BRandomPrice,
                                               Currency_DecimalPlaces,
                                               ref iItem1,
                                               ref iItem2,
                                               ig,
                                               sl2,
                                               sl2,
                                               dt_Taxation
                                               );
                                    SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                            ShopB_Item_Abbreviation,
                                                            true,
                                                            null,
                                                            null,
                                                            sl2,
                                                            null,
                                                            null,
                                                            lng.PriceList_Name.s,
                                                            true,
                                                            null,
                                                            null,
                                                            new DateTime_v(DateTime.Now),
                                                            lng.PriceList_Description.s,
                                                            Currency_Abbreviation,
                                                            Currency_Name,
                                                            Currency_Symbol,
                                                            Currency_Code,
                                                            Currency_DecimalPlaces,
                                                            Taxation_Name_B,
                                                            Taxation_Rate_B,
                                                            BRandomPrice,
                                                            null);
                                    j++;
                                }
                            }
                            sl2 = "(...)";
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetBValues(ref ShopB_Item_Abbreviation,
                                                                           ref ShopB_Item_Name,
                                                                           ref Taxation_Name_B,
                                                                           ref Taxation_Rate_B,
                                                                           ref BRandomPrice,
                                                                           Currency_DecimalPlaces,
                                                                           ref iItem1,
                                                                           ref iItem2,
                                                                           ig,
                                                                           sl2,
                                                                           sl2,
                                                                           dt_Taxation
                                                                           );
                                SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                        ShopB_Item_Abbreviation,
                                                        true,
                                                        null,
                                                        null,
                                                        null,
                                                        null,
                                                        null,
                                                        lng.PriceList_Name.s,
                                                        true,
                                                        null,
                                                        null,
                                                        new DateTime_v(DateTime.Now),
                                                        lng.PriceList_Description.s,
                                                        Currency_Abbreviation,
                                                        Currency_Name,
                                                        Currency_Symbol,
                                                        Currency_Code,
                                                        Currency_DecimalPlaces,
                                                        Taxation_Name_B,
                                                        Taxation_Rate_B,
                                                        BRandomPrice,
                                                        null);
                                j++;
                            }
                        }
                        else if (iNumberOfGroupsInLevel1 > 0)
                        {
                            for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                            {
                                sl1 = ".L1g" + i1.ToString();
                                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                {
                                    SetBValues(ref ShopB_Item_Abbreviation,
                                                                               ref ShopB_Item_Name,
                                                                               ref Taxation_Name_B,
                                                                               ref Taxation_Rate_B,
                                                                               ref BRandomPrice,
                                                                               Currency_DecimalPlaces,
                                                                               ref iItem1,
                                                                               ref iItem2,
                                                                               ig,
                                                                               sl1,
                                                                               sl1,
                                                                               dt_Taxation
                                                                               );
                                    SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                            ShopB_Item_Abbreviation,
                                                            true,
                                                            null,
                                                            null,
                                                            sl1,
                                                            null,
                                                            null,
                                                            lng.PriceList_Name.s,
                                                            true,
                                                            null,
                                                            null,
                                                            new DateTime_v(DateTime.Now),
                                                            lng.PriceList_Description.s,
                                                            Currency_Abbreviation,
                                                            Currency_Name,
                                                            Currency_Symbol,
                                                            Currency_Code,
                                                            Currency_DecimalPlaces,
                                                            Taxation_Name_B,
                                                            Taxation_Rate_B,
                                                            BRandomPrice,
                                                            null);
                                    j++;
                                }
                            }
                            sl1 = "(...)";
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetBValues(ref ShopB_Item_Abbreviation,
                                                                              ref ShopB_Item_Name,
                                                                              ref Taxation_Name_B,
                                                                              ref Taxation_Rate_B,
                                                                              ref BRandomPrice,
                                                                              Currency_DecimalPlaces,
                                                                              ref iItem1,
                                                                              ref iItem2,
                                                                              ig,
                                                                              sl1,
                                                                              sl1,
                                                                              dt_Taxation
                                                                              );
                                SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                        ShopB_Item_Abbreviation,
                                                        true,
                                                        null,
                                                        null,
                                                        null,
                                                        null,
                                                        null,
                                                        lng.PriceList_Name.s,
                                                        true,
                                                        null,
                                                        null,
                                                        new DateTime_v(DateTime.Now),
                                                        lng.PriceList_Description.s,
                                                        Currency_Abbreviation,
                                                        Currency_Name,
                                                        Currency_Symbol,
                                                        Currency_Code,
                                                        Currency_DecimalPlaces,
                                                        Taxation_Name_B,
                                                        Taxation_Rate_B,
                                                        BRandomPrice,
                                                        null);
                                j++;
                            }
                        }
                        else
                        {
                            sl1 = "(...)";
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetBValues(ref ShopB_Item_Abbreviation,
                                                                              ref ShopB_Item_Name,
                                                                              ref Taxation_Name_B,
                                                                              ref Taxation_Rate_B,
                                                                              ref BRandomPrice,
                                                                              Currency_DecimalPlaces,
                                                                              ref iItem1,
                                                                              ref iItem2,
                                                                              ig,
                                                                              sl1,
                                                                              sl1,
                                                                              dt_Taxation
                                                                              );
                                SampleDB_Price_ShopB_Item_List[j] = new SampleDB_Price_ShopB_Item(ShopB_Item_Name,
                                                        ShopB_Item_Abbreviation,
                                                        true,
                                                        null,
                                                        null,
                                                        null,
                                                        null,
                                                        null,
                                                        lng.PriceList_Name.s,
                                                        true,
                                                        null,
                                                        null,
                                                        new DateTime_v(DateTime.Now),
                                                        lng.PriceList_Description.s,
                                                        Currency_Abbreviation,
                                                        Currency_Name,
                                                        Currency_Symbol,
                                                        Currency_Code,
                                                        Currency_DecimalPlaces,
                                                        Taxation_Name_B,
                                                        Taxation_Rate_B,
                                                        BRandomPrice,
                                                        null);
                                j++;
                            }
                        }
                        //{new 
                        if (j!= iNumberOfAll)
                        {
                            LogFile.Error.Show("ERROR:SampleDB:Write_ShopB_Items:Calculated number of items " + iNumberOfAll.ToString() + " is not equal to iterating number j in loop:" + j.ToString());
                        }
                        int k = 0;
                        int SampleDB_Price_ShopB_Item_List_Count = SampleDB_Price_ShopB_Item_List.Count();
                        ProgressForm.Progress_Thread progress = new ProgressForm.Progress_Thread();
                        progress.sLabel1 = lng.s_WriteItemsToDatabase.s + SampleDB_Price_ShopB_Item_List_Count.ToString();
                        progress.Start();
                        for (k=0;k<SampleDB_Price_ShopB_Item_List_Count;k++)
                        {
                            SampleDB_Price_ShopB_Item sample_ShopB_Item = SampleDB_Price_ShopB_Item_List[k];
                            if (f_SimpleItem.Get(sample_ShopB_Item.ShopB_Item_Name,
                                                    sample_ShopB_Item.ShopB_Item_Abbreviation,
                                                    sample_ShopB_Item.ShopB_Item_bToOffer,
                                                    sample_ShopB_Item.ShopB_Item_Image,
                                                    sample_ShopB_Item.ShopB_Item_Code_v,
                                                    sample_ShopB_Item.ShopB_Item_ParentGroup1,
                                                    sample_ShopB_Item.ShopB_Item_ParentGroup2,
                                                    sample_ShopB_Item.ShopB_Item_ParentGroup3,
                                                    ref sample_ShopB_Item.ShopB_Item_ID))
                            {
                                if (f_PriceList.Get(sample_ShopB_Item.PriceList_Name,
                                                    sample_ShopB_Item.PriceList_valid,
                                                    myOrg.Default_Currency_ID,
                                                    sample_ShopB_Item.PriceList_ValidFrom_v,
                                                    sample_ShopB_Item.PriceList_ValidTo_v,
                                                    sample_ShopB_Item.PriceList_CreationDate_v,
                                                    sample_ShopB_Item.PriceList_Description,
                                                    ref sample_ShopB_Item.PriceList_ID))
                                {
                                    if (f_Taxation.Get(sample_ShopB_Item.TaxationName,
                                                       sample_ShopB_Item.TaxationRate,
                                                       ref sample_ShopB_Item.Taxation_ID))
                                    {
                                        if (f_Price_SimpleItem.Get(sample_ShopB_Item.RetailShopB_ItemPrice,
                                                                   sample_ShopB_Item.Discount_v,
                                                                   sample_ShopB_Item.Taxation_ID,
                                                                   sample_ShopB_Item.ShopB_Item_ID,
                                                                   sample_ShopB_Item.PriceList_ID,
                                                                   ref sample_ShopB_Item.Price_ShopB_Item_ID
                                                                   ))
                                        {
                                            if (k % 5 == 0)
                                            {
                                                GC.Collect();
                                                int iPercent = ((int)(k * 100) / SampleDB_Price_ShopB_Item_List_Count);
                                                progress.Message(null, lng.s_ItemsWrittenToDB.s+" "+ k.ToString(),lng.s_JobInPercentDone.s + " " + iPercent.ToString()+"%", iPercent);
                                            }
                                            if (progress.bCancel|| progress.bEnd)
                                            {
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            progress.End();
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        progress.End();
                                        return false;
                                    }
                                }
                                else
                                {
                                    progress.End();
                                    return false;
                                }
                            }
                            else
                            {
                                progress.End();
                                return false;
                            }
                            SampleDB_Price_ShopB_Item_List[k] = null;
                            sample_ShopB_Item = null;
                        }
                        progress.End();
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetBValues(ref string ShopB_Item_Abbreviation,
            ref string ShopB_Item_Name,
            ref string Taxation_Name,
            ref decimal Taxation_Rate,
            ref decimal Price,
            int Currency_DecimalPlaces,
            ref int iItem1,
            ref int iItem2,
            int ig,
            string Abbreviation_sufix,
            string Name_sufix,
            DataTable dt_Taxation
            )
        {
            ShopB_Item_Abbreviation = SetBAbbreviation(ref iItem1, ig, Abbreviation_sufix);
            ShopB_Item_Name = SetBName(ref iItem2, ig, Name_sufix);
            GetRandomTaxation(ref Taxation_Name, ref Taxation_Rate, dt_Taxation);
            Price = GetBRandomPrice(Currency_DecimalPlaces);
        }

        private void SetCValues(ref string ShopC_Item_Abbreviation,
            ref string ShopC_Item_Name,
            ref string Taxation_Name,
            ref decimal Taxation_Rate,
            ref decimal Price,
            int Currency_DecimalPlaces,
            ref int iItem1,
            ref int iItem2,
            int ig,
            string Abbreviation_sufix,
            string Name_sufix,
            DataTable dt_Taxation
            )
        {
            ShopC_Item_Abbreviation = SetCAbbreviation(ref iItem1, ig, Abbreviation_sufix);
            ShopC_Item_Name = SetCName(ref iItem2, ig, Name_sufix);
            GetRandomTaxation(ref Taxation_Name, ref Taxation_Rate, dt_Taxation);
            Price = GetCRandomPrice(Currency_DecimalPlaces);
        }

        private void GetRandomTaxation(ref string taxation_Name_B, ref decimal taxation_Rate_B, DataTable dt_Taxation)
        {
            int imin = 0;
            int imax = dt_Taxation.Rows.Count - 1;
            int irand = GlobalData.GetRandomNumber(imin, imax);
            taxation_Name_B = (string)dt_Taxation.Rows[irand]["Name"];
            taxation_Rate_B = (decimal)dt_Taxation.Rows[irand]["Rate"];
        }

        private decimal GetBRandomPrice(int Currency_DecimalPlaces)
        {
            return GlobalData.GetRandomPrice(1.0M, 200.0M, Currency_DecimalPlaces);
        }

        private decimal GetCRandomPrice(int Currency_DecimalPlaces)
        {
            return GlobalData.GetRandomPrice(10.0M, 400.0M, Currency_DecimalPlaces);
        }

        private string SetBAbbreviation(ref int iItem, int ig, string sufix)
        {
            iItem++;
            return lng.ShopB_Item_Abbreviation_SB.s + iItem.ToString() + "    " + ig.ToString() + sufix;
        }

        private string SetBName(ref int iItem, int ig, string sufix)
        {
            iItem++;
            return lng.ShopB_Item_Name_Item.s + iItem.ToString() + "    " + ig.ToString() + sufix;
        }

        private string SetCAbbreviation(ref int iItem, int ig, string sufix)
        {
            iItem++;
            return lng.ShopC_Item_Abbreviation_SB.s + iItem.ToString() + "    " + ig.ToString() + sufix;
        }

        private string SetCName(ref int iItem, int ig, string sufix)
        {
            iItem++;
            return lng.ShopC_Item_Name_Item.s + iItem.ToString() + "    " + ig.ToString() + sufix;
        }

        public bool Startup_11_Write_ShopC_Items(Form_Items_Samples frm_Items_Samples)
        {
            string Currency_Name = null;
            string Currency_Abbreviation = null;
            string Currency_Symbol = null;
            int Currency_Code = 0;
            int Currency_DecimalPlaces = 2;
            int iItem1 = 0;
            int iItem2 = 0;
            string Taxation_Name_C = "";
            decimal Taxation_Rate_C = 0;
            DataTable dt_Taxation = TangentaDB.f_Taxation.GetTable(false);
            decimal CRandomPrice = 0;

            if (f_Currency.Get(myOrg.Default_Currency_ID, ref Currency_Abbreviation, ref Currency_Name, ref Currency_Symbol, ref Currency_Code, ref Currency_DecimalPlaces))
            {

                if (frm_Items_Samples.bAutoGenerateDemoSampleItems)
                {
                    int iNumberOfGroupsInLevel3 = frm_Items_Samples.iNumberOfGroupsInLevel3;
                    int iNumberOfGroupsInLevel2 = frm_Items_Samples.iNumberOfGroupsInLevel2;
                    int iNumberOfGroupsInLevel1 = frm_Items_Samples.iNumberOfGroupsInLevel1;
                    int iNumberOfItemsPerGroup = frm_Items_Samples.iNumberOfItemsPerGroup;
                    int iNumberOfAll = frm_Items_Samples.iNumberOffAll();

                    SampleDB_Price_ShopC_Item[] SampleDB_Price_ShopC_Item_List = new SampleDB_Price_ShopC_Item[iNumberOfAll];
                    int j = 0;
                    string ShopC_Item_Abbreviation = null;
                    string ShopC_Item_Name = null;
                    string sl3 = null;
                    string sl2 = null;
                    string sl1 = null;
                    int i1 = 0;
                    int i2 = 0;
                    int i3 = 0;
                    int ig = 0;
                    if (iNumberOfGroupsInLevel3 > 0)
                    {
                        for (i3 = 0; i3 < iNumberOfGroupsInLevel3; i3++)
                        {
                            string sln3 = "L3g" + i3.ToString();
                            sl3 = "." + sln3;
                            for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                            {
                                string sln2 = sln3 + "L2g" + i2.ToString();
                                sl2 = "." + sln2;
                                for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                                {
                                    string sln1 = sln3 + sln2 + "L1g" + i1.ToString();
                                    sl1 = "." + sln1;
                                    for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                    {
                                        SetCValues(ref ShopC_Item_Abbreviation,
                                                    ref ShopC_Item_Name,
                                                    ref Taxation_Name_C,
                                                    ref Taxation_Rate_C,
                                                    ref CRandomPrice,
                                                    Currency_DecimalPlaces,
                                                    ref iItem1,
                                                    ref iItem2,
                                                    ig,
                                                    sln1,
                                                    sln1,
                                                    dt_Taxation
                                                    );

                                        SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                        ShopC_Item_Name,
                                                                        ShopC_Item_Abbreviation,
                                                                        new int_v(1),
                                                                        sl1,
                                                                        sl2,
                                                                        sl3,
                                                                        lng.s_Piece.s,
                                                                        lng.s_PieceAbr.s,
                                                                        0,
                                                                        true,
                                                                        null,
                                                                        null,
                                                                        lng.s_Description.s,
                                                                        180,
                                                                        60,
                                                                        10,
                                                                        null,
                                                                        -1,
                                                                        -1,
                                                                        null,
                                                                        null,
                                                                        true,
                                                                        lng.PriceList_Name.s,
                                                                        true,
                                                                        Currency_Abbreviation,
                                                                        Currency_Name,
                                                                        Currency_Symbol,
                                                                        Currency_Code,
                                                                        Currency_DecimalPlaces,
                                                                        null,
                                                                        null,
                                                                        new DateTime_v(DateTime.Now),
                                                                        null,
                                                                        Taxation_Name_C,
                                                                        Taxation_Rate_C,
                                                                        CRandomPrice,
                                                                        new decimal_v(0)
                                                                        );

                                        j++;
                                    }
                                }
                                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                {
                                    SetCValues(ref ShopC_Item_Abbreviation,
                                                ref ShopC_Item_Name,
                                                ref Taxation_Name_C,
                                                ref Taxation_Rate_C,
                                                ref CRandomPrice,
                                                Currency_DecimalPlaces,
                                                ref iItem1,
                                                ref iItem2,
                                                ig,
                                                sln2,
                                                sln2,
                                                dt_Taxation
                                                );
                                    SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                    ShopC_Item_Name,
                                                                    ShopC_Item_Abbreviation,
                                                                    new int_v(1),
                                                                    sl2,
                                                                    sl3,
                                                                    null,
                                                                    lng.s_Piece.s,
                                                                    lng.s_PieceAbr.s,
                                                                    0,
                                                                    true,
                                                                    null,
                                                                    null,
                                                                    lng.s_Description.s,
                                                                    180,
                                                                    60,
                                                                    10,
                                                                    null,
                                                                    -1,
                                                                    -1,
                                                                    null,
                                                                    null,
                                                                    true,
                                                                    lng.PriceList_Name.s,
                                                                    true,
                                                                    Currency_Abbreviation,
                                                                    Currency_Name,
                                                                    Currency_Symbol,
                                                                    Currency_Code,
                                                                    Currency_DecimalPlaces,
                                                                    null,
                                                                    null,
                                                                    new DateTime_v(DateTime.Now),
                                                                    null,
                                                                    Taxation_Name_C,
                                                                    Taxation_Rate_C,
                                                                    CRandomPrice,
                                                                    new decimal_v(0)
                                                                    );
                                    j++;
                                }

                            }
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetCValues(ref ShopC_Item_Abbreviation,
                                        ref ShopC_Item_Name,
                                        ref Taxation_Name_C,
                                        ref Taxation_Rate_C,
                                        ref CRandomPrice,
                                        Currency_DecimalPlaces,
                                        ref iItem1,
                                        ref iItem2,
                                        ig,
                                        sln3,
                                        sln3,
                                        dt_Taxation
                                        );
                                SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                                                            ShopC_Item_Name,
                                                                                                            ShopC_Item_Abbreviation,
                                                                                                            new int_v(1),
                                                                                                            sl3,
                                                                                                            null,
                                                                                                            null,
                                                                                                            lng.s_Piece.s,
                                                                                                            lng.s_PieceAbr.s,
                                                                                                            0,
                                                                                                            true,
                                                                                                            null,
                                                                                                            null,
                                                                                                            lng.s_Description.s,
                                                                                                            180,
                                                                                                            60,
                                                                                                            10,
                                                                                                            null,
                                                                                                            -1,
                                                                                                            -1,
                                                                                                            null,
                                                                                                            null,
                                                                                                            true,
                                                                                                            lng.PriceList_Name.s,
                                                                                                            true,
                                                                                                            Currency_Abbreviation,
                                                                                                            Currency_Name,
                                                                                                            Currency_Symbol,
                                                                                                            Currency_Code,
                                                                                                            Currency_DecimalPlaces,
                                                                                                            null,
                                                                                                            null,
                                                                                                            new DateTime_v(DateTime.Now),
                                                                                                            null,
                                                                                                            Taxation_Name_C,
                                                                                                            Taxation_Rate_C,
                                                                                                            CRandomPrice,
                                                                                                            new decimal_v(0)
                                                                                                            ); j++;
                            }
                        }
                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                        {
                            SetCValues(ref ShopC_Item_Abbreviation,
                                        ref ShopC_Item_Name,
                                        ref Taxation_Name_C,
                                        ref Taxation_Rate_C,
                                        ref CRandomPrice,
                                        Currency_DecimalPlaces,
                                        ref iItem1,
                                        ref iItem2,
                                        ig,
                                        " noL1noL2noL3",
                                        " noL1noL2noL3",
                                        dt_Taxation
                                        );
                            SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                                                        ShopC_Item_Name,
                                                                                                        ShopC_Item_Abbreviation,
                                                                                                        new int_v(1),
                                                                                                        null,
                                                                                                        null,
                                                                                                        null,
                                                                                                        lng.s_Piece.s,
                                                                                                        lng.s_PieceAbr.s,
                                                                                                        0,
                                                                                                        true,
                                                                                                        null,
                                                                                                        null,
                                                                                                        lng.s_Description.s,
                                                                                                        180,
                                                                                                        60,
                                                                                                        10,
                                                                                                        null,
                                                                                                        -1,
                                                                                                        -1,
                                                                                                        null,
                                                                                                        null,
                                                                                                        true,
                                                                                                        lng.PriceList_Name.s,
                                                                                                        true,
                                                                                                        Currency_Abbreviation,
                                                                                                        Currency_Name,
                                                                                                        Currency_Symbol,
                                                                                                        Currency_Code,
                                                                                                        Currency_DecimalPlaces,
                                                                                                        null,
                                                                                                        null,
                                                                                                        new DateTime_v(DateTime.Now),
                                                                                                        null,
                                                                                                        Taxation_Name_C,
                                                                                                        Taxation_Rate_C,
                                                                                                        CRandomPrice,
                                                                                                        new decimal_v(0)
                                                                                                        ); j++;
                        }
                    }
                    else if (iNumberOfGroupsInLevel2 > 0)
                    {
                        for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                        {
                            sl2 = ".L2g" + i2.ToString();
                            for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                            {
                                sl1 = ".L1g" + i1.ToString();
                                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                                {
                                    SetCValues(ref ShopC_Item_Abbreviation,
                                        ref ShopC_Item_Name,
                                        ref Taxation_Name_C,
                                        ref Taxation_Rate_C,
                                        ref CRandomPrice,
                                        Currency_DecimalPlaces,
                                        ref iItem1,
                                        ref iItem2,
                                        ig,
                                        sl2 + sl1,
                                        sl2 + sl1,
                                        dt_Taxation
                                        );
                                    SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                    ShopC_Item_Name,
                                                                    ShopC_Item_Abbreviation,
                                                                    new int_v(1),
                                                                    sl1,
                                                                    sl2,
                                                                    null,
                                                                    lng.s_Piece.s,
                                                                    lng.s_PieceAbr.s,
                                                                    0,
                                                                    true,
                                                                    null,
                                                                    null,
                                                                    lng.s_Description.s,
                                                                    180,
                                                                    60,
                                                                    10,
                                                                    null,
                                                                    -1,
                                                                    -1,
                                                                    null,
                                                                    null,
                                                                    true,
                                                                    lng.PriceList_Name.s,
                                                                    true,
                                                                    Currency_Abbreviation,
                                                                    Currency_Name,
                                                                    Currency_Symbol,
                                                                    Currency_Code,
                                                                    Currency_DecimalPlaces,
                                                                    null,
                                                                    null,
                                                                    new DateTime_v(DateTime.Now),
                                                                    null,
                                                                    Taxation_Name_C,
                                                                    Taxation_Rate_C,
                                                                    CRandomPrice,
                                                                    new decimal_v(0)
                                                                    );
                                    j++;
                                }
                            }
                        }
                        for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                        {
                            sl2 = ".L2g" + i2.ToString() + "(...)";
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetCValues(ref ShopC_Item_Abbreviation,
                                    ref ShopC_Item_Name,
                                    ref Taxation_Name_C,
                                    ref Taxation_Rate_C,
                                    ref CRandomPrice,
                                    Currency_DecimalPlaces,
                                    ref iItem1,
                                    ref iItem2,
                                    ig,
                                    sl2,
                                    sl2,
                                    dt_Taxation
                                    );
                                SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                ShopC_Item_Name,
                                                                ShopC_Item_Abbreviation,
                                                                new int_v(1),
                                                                sl2,
                                                                null,
                                                                null,
                                                                lng.s_Piece.s,
                                                                lng.s_PieceAbr.s,
                                                                0,
                                                                true,
                                                                null,
                                                                null,
                                                                lng.s_Description.s,
                                                                180,
                                                                60,
                                                                10,
                                                                null,
                                                                -1,
                                                                -1,
                                                                null,
                                                                null,
                                                                true,
                                                                lng.PriceList_Name.s,
                                                                true,
                                                                Currency_Abbreviation,
                                                                Currency_Name,
                                                                Currency_Symbol,
                                                                Currency_Code,
                                                                Currency_DecimalPlaces,
                                                                null,
                                                                null,
                                                                new DateTime_v(DateTime.Now),
                                                                null,
                                                                Taxation_Name_C,
                                                                Taxation_Rate_C,
                                                                CRandomPrice,
                                                                new decimal_v(0)
                                                                );
                                j++;
                            }
                        }
                        sl2 = "(...)";
                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                        {
                            SetCValues(ref ShopC_Item_Abbreviation,
                                        ref ShopC_Item_Name,
                                        ref Taxation_Name_C,
                                        ref Taxation_Rate_C,
                                        ref CRandomPrice,
                                        Currency_DecimalPlaces,
                                        ref iItem1,
                                        ref iItem2,
                                        ig,
                                        sl2,
                                        sl2,
                                        dt_Taxation
                                        );

                            SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                            ShopC_Item_Name,
                                                            ShopC_Item_Abbreviation,
                                                            new int_v(1),
                                                            null,
                                                            null,
                                                            null,
                                                            lng.s_Piece.s,
                                                            lng.s_PieceAbr.s,
                                                            0,
                                                            true,
                                                            null,
                                                            null,
                                                            lng.s_Description.s,
                                                            180,
                                                            60,
                                                            10,
                                                            null,
                                                            -1,
                                                            -1,
                                                            null,
                                                            null,
                                                            true,
                                                            lng.PriceList_Name.s,
                                                            true,
                                                            Currency_Abbreviation,
                                                            Currency_Name,
                                                            Currency_Symbol,
                                                            Currency_Code,
                                                            Currency_DecimalPlaces,
                                                            null,
                                                            null,
                                                            new DateTime_v(DateTime.Now),
                                                            null,
                                                            Taxation_Name_C,
                                                            Taxation_Rate_C,
                                                            CRandomPrice,
                                                            new decimal_v(0)
                                                            );

                            j++;
                        }
                    }
                    else if (iNumberOfGroupsInLevel1 > 0)
                    {
                        for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                        {
                            sl1 = ".L1g" + i1.ToString();
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetCValues(ref ShopC_Item_Abbreviation,
                                        ref ShopC_Item_Name,
                                        ref Taxation_Name_C,
                                        ref Taxation_Rate_C,
                                        ref CRandomPrice,
                                        Currency_DecimalPlaces,
                                        ref iItem1,
                                        ref iItem2,
                                        ig,
                                        sl1,
                                        sl1,
                                        dt_Taxation
                                        );
                                SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                                                ShopC_Item_Name,
                                                                                                ShopC_Item_Abbreviation,
                                                                                                new int_v(1),
                                                                                                sl1,
                                                                                                null,
                                                                                                null,
                                                                                                lng.s_Piece.s,
                                                                                                lng.s_PieceAbr.s,
                                                                                                0,
                                                                                                true,
                                                                                                null,
                                                                                                null,
                                                                                                lng.s_Description.s,
                                                                                                180,
                                                                                                60,
                                                                                                10,
                                                                                                null,
                                                                                                -1,
                                                                                                -1,
                                                                                                null,
                                                                                                null,
                                                                                                true,
                                                                                                lng.PriceList_Name.s,
                                                                                                true,
                                                                                                Currency_Abbreviation,
                                                                                                Currency_Name,
                                                                                                Currency_Symbol,
                                                                                                Currency_Code,
                                                                                                Currency_DecimalPlaces,
                                                                                                null,
                                                                                                null,
                                                                                                new DateTime_v(DateTime.Now),
                                                                                                null,
                                                                                                Taxation_Name_C,
                                                                                                Taxation_Rate_C,
                                                                                                CRandomPrice,
                                                                                                new decimal_v(0)
                                                                                                );
                                j++;
                            }
                        }
                        sl1 = "(...)";
                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                        {
                            SetCValues(ref ShopC_Item_Abbreviation,
                                        ref ShopC_Item_Name,
                                        ref Taxation_Name_C,
                                        ref Taxation_Rate_C,
                                        ref CRandomPrice,
                                        Currency_DecimalPlaces,
                                        ref iItem1,
                                        ref iItem2,
                                        ig,
                                        sl1,
                                        sl1,
                                        dt_Taxation
                                        );

                            SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                                            ShopC_Item_Name,
                                                                                            ShopC_Item_Abbreviation,
                                                                                            new int_v(1),
                                                                                            null,
                                                                                            null,
                                                                                            null,
                                                                                            lng.s_Piece.s,
                                                                                            lng.s_PieceAbr.s,
                                                                                            0,
                                                                                            true,
                                                                                            null,
                                                                                            null,
                                                                                            lng.s_Description.s,
                                                                                            180,
                                                                                            60,
                                                                                            10,
                                                                                            null,
                                                                                            -1,
                                                                                            -1,
                                                                                            null,
                                                                                            null,
                                                                                            true,
                                                                                            lng.PriceList_Name.s,
                                                                                            true,
                                                                                            Currency_Abbreviation,
                                                                                            Currency_Name,
                                                                                            Currency_Symbol,
                                                                                            Currency_Code,
                                                                                            Currency_DecimalPlaces,
                                                                                            null,
                                                                                            null,
                                                                                            new DateTime_v(DateTime.Now),
                                                                                            null,
                                                                                            Taxation_Name_C,
                                                                                            Taxation_Rate_C,
                                                                                            CRandomPrice,
                                                                                            new decimal_v(0)
                                                                                            );
                            j++;
                        }
                    }
                    else
                    {
                        sl1 = "(...)";
                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                        {
                            SetCValues(ref ShopC_Item_Abbreviation,
                                        ref ShopC_Item_Name,
                                        ref Taxation_Name_C,
                                        ref Taxation_Rate_C,
                                        ref CRandomPrice,
                                        Currency_DecimalPlaces,
                                        ref iItem1,
                                        ref iItem2,
                                        ig,
                                        sl1,
                                        sl1,
                                        dt_Taxation
                                        );
                                                        SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                                                                            ShopC_Item_Name,
                                                                                                                            ShopC_Item_Abbreviation,
                                                                                                                            new int_v(1),
                                                                                                                            null,
                                                                                                                            null,
                                                                                                                            null,
                                                                                                                            lng.s_Piece.s,
                                                                                                                            lng.s_PieceAbr.s,
                                                                                                                            0,
                                                                                                                            true,
                                                                                                                            null,
                                                                                                                            null,
                                                                                                                            lng.s_Description.s,
                                                                                                                            180,
                                                                                                                            60,
                                                                                                                            10,
                                                                                                                            null,
                                                                                                                            -1,
                                                                                                                            -1,
                                                                                                                            null,
                                                                                                                            null,
                                                                                                                            true,
                                                                                                                            lng.PriceList_Name.s,
                                                                                                                            true,
                                                                                                                            Currency_Abbreviation,
                                                                                                                            Currency_Name,
                                                                                                                            Currency_Symbol,
                                                                                                                            Currency_Code,
                                                                                                                            Currency_DecimalPlaces,
                                                                                                                            null,
                                                                                                                            null,
                                                                                                                            new DateTime_v(DateTime.Now),
                                                                                                                            null,
                                                                                                                            Taxation_Name_C,
                                                                                                                            Taxation_Rate_C,
                                                                                                                            CRandomPrice,
                                                                                                                            new decimal_v(0)
                                                                                                                            ); j++;
                        }
                    }
                    //{new 
                    if (j != iNumberOfAll)
                    {
                        LogFile.Error.Show("ERROR:SampleDB:Write_ShopB_Items:Calculated number of items " + iNumberOfAll.ToString() + " is not equal to iterating number j in loop:" + j.ToString());
                    }
                    int k = 0;
                    int SampleDB_Price_ShopC_Item_List_Count = SampleDB_Price_ShopC_Item_List.Count();
                    ProgressForm.Progress_Thread progress = new ProgressForm.Progress_Thread();
                    progress.sLabel1 = lng.s_WriteItemsToDatabase.s + SampleDB_Price_ShopC_Item_List_Count.ToString();
                    progress.Start();
                    f_Expiry.Expiry_v expiry_v = new f_Expiry.Expiry_v();
                    f_Warranty.Warranty_v warranty_v = new f_Warranty.Warranty_v();
                    f_Expiry.Expiry_v xexpiry_v = null;
                    f_Warranty.Warranty_v xwarranty_v = null;
                    for (k = 0; k < SampleDB_Price_ShopC_Item_List_Count; k++)
                    {
                        xexpiry_v = null;
                        xwarranty_v = null;
                        SampleDB_Price_ShopC_Item sample_ShopC_Item = SampleDB_Price_ShopC_Item_List[k];
                        if (sample_ShopC_Item.ShopC_Item_Expiry_ExpectedShelfLifeInDays >= 0)
                        {
                            expiry_v.ExpectedShelfLifeInDays = sample_ShopC_Item.ShopC_Item_Expiry_ExpectedShelfLifeInDays;
                            expiry_v.DiscardBeforeExpiryDateInDays = sample_ShopC_Item.ShopC_Item_Expiry_DiscardBeforeExpiryDateInDays;
                            expiry_v.SaleBeforeExpiryDateInDays = sample_ShopC_Item.ShopC_Item_Expiry_SaleBeforeExpiryDateInDays;
                            expiry_v.ExpiryDescription = sample_ShopC_Item.ShopC_Item_Expiry_ExpiryDescription;
                            xexpiry_v = expiry_v;

                        }
                        if (sample_ShopC_Item.ShopC_Item_Warranty_WarrantyDuration >= 0)
                        {
                            warranty_v.WarrantyDuration = sample_ShopC_Item.ShopC_Item_Warranty_WarrantyDuration;
                            warranty_v.WarrantyDurationType = sample_ShopC_Item.ShopC_Item_Warranty_WarrantyDurationType;
                            warranty_v.WarrantyConditions = sample_ShopC_Item.ShopC_Item_Warranty_WarrantyConditions;
                            xwarranty_v = warranty_v;
                        }

                        if (f_Item.Get(sample_ShopC_Item.ShopC_Item_Name,
                                        sample_ShopC_Item.ShopC_Item_UniqueName,
                                        sample_ShopC_Item.ShopC_Item_ToOffer,
                                        sample_ShopC_Item.ShopC_Item_Image,
                                        sample_ShopC_Item.ShopC_Item_Code,
                                        "komad",
                                        "kom.",
                                        0,
                                        true,
                                        "Artikli kot komadi.",
                                        null,
                                        null,
                                        xexpiry_v,
                                        xwarranty_v,
                                        sample_ShopC_Item.ShopC_Item_ParentGroup1,
                                        sample_ShopC_Item.ShopC_Item_ParentGroup2,
                                        sample_ShopC_Item.ShopC_Item_ParentGroup3,
                                        ref sample_ShopC_Item.ShopC_Item_Unit_ID,
                                        ref sample_ShopC_Item.ShopC_Price_Item_Item_ID
                                        ))
                        {

                            if (f_PriceList.Get(sample_ShopC_Item.ShopC_Price_Item_PriceList_Name,
                                                sample_ShopC_Item.ShopC_Price_Item_PriceList_valid,
                                                myOrg.Default_Currency_ID,
                                                sample_ShopC_Item.ShopC_Price_Item_PriceList_ValidFrom_v,
                                                sample_ShopC_Item.ShopC_Price_Item_PriceList_ValidTo_v,
                                                sample_ShopC_Item.ShopC_Price_Item_PriceList_CreationDate_v,
                                                sample_ShopC_Item.ShopC_Price_Item_PriceList_Description,
                                                ref sample_ShopC_Item.ShopC_Price_Item_PriceList_ID))
                            {
                                if (f_Taxation.Get(sample_ShopC_Item.ShopC_Price_Item_TaxationName,
                                                    sample_ShopC_Item.ShopC_Price_Item_TaxationRate,
                                                    ref sample_ShopC_Item.ShopC_Price_Item_Taxation_ID))
                                {

                                    if (f_Price_Item.Get(sample_ShopC_Item.ShopC_Price_Item_RetailPricePerUnit,
                                                            sample_ShopC_Item.ShopC_Price_Item_Discount_v,
                                                            sample_ShopC_Item.ShopC_Price_Item_Taxation_ID,
                                                            sample_ShopC_Item.ShopC_Price_Item_Item_ID,
                                                            sample_ShopC_Item.ShopC_Price_Item_PriceList_ID,
                                                            ref sample_ShopC_Item.ShopC_Price_Item_ID
                                                            ))
                                    {
                                        if (k % 5 == 0)
                                        {
                                            GC.Collect();
                                            int iPercent = ((int)(k * 100) / SampleDB_Price_ShopC_Item_List_Count);
                                            progress.Message(null, lng.s_ItemsWrittenToDB.s + " " + k.ToString(), lng.s_JobInPercentDone.s + " " + iPercent.ToString() +"%", iPercent);
                                        }
                                        if (progress.bCancel || progress.bEnd)
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        progress.End();
                                        return false;
                                    }
                                }
                                else
                                {
                                    progress.End();
                                    return false;
                                }
                            }
                            else
                            {
                                progress.End();
                                return false;
                            }
                        }
                        else
                        {
                            progress.End();
                            return false;
                        }
                        SampleDB_Price_ShopC_Item_List[k] = null;
                        sample_ShopC_Item = null;
                    }
                    progress.End();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
