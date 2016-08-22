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

namespace TangentaSampleDB
{
    public class SampleDB
    {
        private SHA1CryptoServiceProvider my_SHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();

        ID_v cAdressAtom_Org_iD_v = null;

        dstring_v MyOrg_Name_v = new dstring_v();
        dstring_v MyOrg_Tax_ID_v = new dstring_v();
        dstring_v MyOrg_Registration_ID_v = new dstring_v();
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


        dbool_v   MyOrg_Person_Gender_v = new dbool_v();
        dstring_v MyOrg_Person_FirstName_v = new dstring_v();
        dstring_v MyOrg_Person_LastName_v = new dstring_v();
        dDateTime_v MyOrg_Person_DateOfBirth_v = new dDateTime_v();
        dstring_v MyOrg_Person_Tax_ID_v = new dstring_v();
        dstring_v MyOrg_Person_Registration_ID_v = new dstring_v();
        dstring_v MyOrg_Person_GsmNumber_v = new dstring_v();
        dstring_v MyOrg_Person_PhoneNumber_v = new dstring_v();
        dstring_v MyOrg_Person_Email_v = new dstring_v();


        dstring_v MyOrg_Person_UserName_v = new dstring_v();
        dstring_v MyOrg_Person_Password_v = new dstring_v();
        dstring_v MyOrg_Person_Job_v = new dstring_v();
        dbool_v MyOrg_Person_Active_v = new dbool_v();
        dstring_v MyOrg_Person_Description_v = new dstring_v();
        long_v MyOrg_Person_Person_ID_v = null;
        long_v MyOrg_Person_Office_ID_v = null;

        PostAddress_v MyOrg_Office_Person_Address_v = new PostAddress_v();


        dstring_v MyOrg_Person_CardNumber_v = new dstring_v();
        dstring_v MyOrg_Person_CardType_v = new dstring_v();
        dstring_v MyOrg_Person_Image_Hash_v = new dstring_v();
        byte_array_v MyOrg_Person_Image_Data_v = null;
        long_v MyOrg_Person_Atom_Person_ID_v = null;

        DynGroupBox MyOrg_DynGroupBox = null;

        DynGroupBox MyOrg_BankAccount_DynGroupBox = null;

        DynGroupBox MyOrg_BankAccount_Bank_DynGroupBox = null;

        DynGroupBox MyOrg_BankAccount_Bank_Organisation_DynGroupBox = null;

        DynGroupBox MyOrg_Address_DynGroupBox = null;

        DynGroupBox MyOrg_Address_Country_DynGroupBox = null;

        DynGroupBox MyOrg_Office_DynGroupBox = null;

        DynGroupBox MyOrg_Office_Address_DynGroupBox = null;

        DynGroupBox MyOrg_Office_Address_Country_DynGroupBox = null;

        DynGroupBox MyOrg_Office_Person_DynGroupBox = null;

        DynGroupBox MyOrg_Office_Person_Address_DynGroupBox = null;

        DynGroupBox MyOrg_Office_Person_Address_Country_DynGroupBox = null;


        public SampleDB()
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

        public byte[] imageToByteArray(System.Drawing.Image imageIn, System.Drawing.Imaging.ImageFormat imgformat)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imgformat);
            //SaveImageInFormat(imageIn, ms);
            return ms.ToArray();
        }

        public void Init(usrc_DataEdit m_eds)
        {

            Image img = Properties.Resources.Logo;
            MyOrg_Image_Data_v.v = imageToByteArray(img, img.RawFormat);

            MyOrg_DynGroupBox = m_eds.AddGroupBox("grp_MyOrg", lngRPM.s_MyOrganisation);

            MyOrg_BankAccount_DynGroupBox = MyOrg_DynGroupBox.AddGroupBox("grp_MyOrg_BankAccount", lngRPM.s_BankAccount);

            MyOrg_BankAccount_Bank_DynGroupBox = MyOrg_BankAccount_DynGroupBox.AddGroupBox("grp_MyOrg_BankAccount_Bank", lngRPM.s_Bank);

            MyOrg_Address_DynGroupBox = MyOrg_DynGroupBox.AddGroupBox("grp_MyOrg_Address",lngRPM.s_Address);

            MyOrg_Address_Country_DynGroupBox = MyOrg_Address_DynGroupBox.AddGroupBox("grp_MyOrg_Address_Country", lngRPM.s_Country);

            MyOrg_Office_DynGroupBox = MyOrg_DynGroupBox.AddGroupBox("grp_MyOrg_Office",lngRPM.s_Office);

            MyOrg_Office_Address_DynGroupBox = MyOrg_Office_DynGroupBox.AddGroupBox("grp_MyOrg_Office_Address", lngRPM.s_Address);

            MyOrg_Office_Address_Country_DynGroupBox = MyOrg_Office_Address_DynGroupBox.AddGroupBox("grp_MyOrg_Office_Address_Country", lngRPM.s_Country);

            MyOrg_Office_Person_DynGroupBox = MyOrg_Office_DynGroupBox.AddGroupBox("grp_MyOrg_Office_Person",lngRPM.s_Person);

            MyOrg_Office_Person_Address_DynGroupBox = MyOrg_Office_Person_DynGroupBox.AddGroupBox("grp_MyOrg_Office_Person_Address", lngRPM.s_Address);

            MyOrg_Office_Person_Address_Country_DynGroupBox = MyOrg_Office_Person_Address_DynGroupBox.AddGroupBox("grp_MyOrg_Office_Person_Address_Country", lngRPM.s_Country);

            MyOrg_DynGroupBox.Visible = true;
            MyOrg_Address_DynGroupBox.Visible = true;
            MyOrg_Office_DynGroupBox.Visible = true;
            MyOrg_Office_Address_DynGroupBox.Visible = true;
            MyOrg_Office_Person_DynGroupBox.Visible = true;
            MyOrg_Office_Person_Address_DynGroupBox.Visible = true;


            new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_Name_v, "MyOrg_Name", lngRPMS.sl_MyOrg_Name, lngRPMS.s_MyOrg_Name_v, lngRPMS.sh_MyOrg_Name);

            new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_Tax_ID_v, "MyOrg_Tax_ID", lngRPMS.sl_MyOrg_Tax_ID, lngRPMS.s_MyOrg_Tax_ID_v, lngRPMS.sh_MyOrg_Tax_ID);

            new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_Registration_ID_v, "MyOrg_Registration_ID", lngRPMS.sl_MyOrg_Registration_ID, lngRPMS.s_MyOrg_Registration_ID_v, lngRPMS.sh_MyOrg_Registration_ID);


            new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_OrganisationTYPE_v, "MyOrg_OrganisationTYPE", lngRPMS.sl_MyOrg_OrganisationTYPE, lngRPMS.s_MyOrg_OrganisationTYPE_v, lngRPMS.sh_MyOrg_OrganisationTYPE);

            new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_PhoneNumber_v, "MyOrg_PhoneNumber", lngRPMS.sl_MyOrg_PhoneNumber, lngRPMS.s_MyOrg_PhoneNumber_v, lngRPMS.sh_MyOrg_PhoneNumber);

            new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_FaxNumber_v, "MyOrg_FaxNumber", lngRPMS.sl_MyOrg_FaxNumber, lngRPMS.s_MyOrg_FaxNumber_v, lngRPMS.sh_MyOrg_FaxNumber);

            new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_Email_v, "MyOrg_Email", lngRPMS.sl_MyOrg_Email, lngRPMS.s_MyOrg_Email_v, lngRPMS.sh_MyOrg_Email);

            new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_HomePage_v, "MyOrg_HomePage", lngRPMS.sl_MyOrg_HomePage, lngRPMS.s_MyOrg_HomePage_v, lngRPMS.sh_MyOrg_HomePage);

            new DynEditControls.EditControl(MyOrg_BankAccount_DynGroupBox, MyOrg_BankAccount_TRR_v, "MyOrg_BankAccount_TRR", lngRPMS.sl_MyOrg_TRR, lngRPMS.s_MyOrg_TRR_v, lngRPMS.sh_MyOrg_TRR);

            new DynEditControls.EditControl(MyOrg_BankAccount_DynGroupBox, MyOrg_BankAccount_Description_v, "MyOrg_BankAccount_Description", lngRPMS.sl_MyOrg_TRR_Description, lngRPMS.s_MyOrg_TRR_Description_v, lngRPMS.sh_MyOrg_TRR_Description);

            new DynEditControls.EditControl(MyOrg_BankAccount_DynGroupBox, MyOrg_BankAccount_Active_v, "MyOrg_BankAccount_Active", lngRPMS.sl_MyOrg_TRR_Active, lngRPMS.s_MyOrg_TRR_Active_v, lngRPMS.sh_MyOrg_TRR_Active);

            new DynEditControls.EditControl(MyOrg_BankAccount_Bank_DynGroupBox, MyOrg_Bank_Name_v, "MyOrg_Bank_Name", lngRPMS.sl_MyOrg_Bank_Name, lngRPMS.s_MyOrg_Bank_Name_v, lngRPMS.sh_MyOrg_Bank_Name);

            new DynEditControls.EditControl(MyOrg_BankAccount_Bank_DynGroupBox, MyOrg_Bank_Tax_ID_v, "MyOrg_Bank_Tax_ID", lngRPMS.sl_MyOrg_Bank_Tax_ID, lngRPMS.s_MyOrg_Bank_Tax_ID_v, lngRPMS.sh_MyOrg_Bank_Tax_ID);

            new DynEditControls.EditControl(MyOrg_BankAccount_Bank_DynGroupBox, MyOrg_Bank_Registration_ID_v, "MyOrg_Bank_Registration_ID", lngRPMS.sl_MyOrg_Bank_Registration_ID, lngRPMS.s_MyOrg_Bank_Registration_ID_v, lngRPMS.sh_MyOrg_Bank_Registration_ID);



            new DynEditControls.EditControl(MyOrg_DynGroupBox, MyOrg_Image_Data_v, "MyOrg_Logo", lngRPMS.sl_MyOrg_Logo, lngRPMS.s_MyOrg_Logo_v, lngRPMS.sh_MyOrg_Logo);

            new DynEditControls.EditControl(MyOrg_Address_DynGroupBox, MyOrg_Address_v.StreetName_v, "MyOrg_Address_StreetName", lngRPMS.sl_MyOrg_Address_StreetName, lngRPMS.s_MyOrg_Address_StreetName_v, lngRPMS.sh_MyOrg_Address_StreetName);
            new DynEditControls.EditControl(MyOrg_Address_DynGroupBox, MyOrg_Address_v.HouseNumber_v, "MyOrg_Address_HouseNumber", lngRPMS.sl_MyOrg_Address_HouseNumber, lngRPMS.s_MyOrg_Address_HouseNumber_v, lngRPMS.sh_MyOrg_Address_HouseNumber);
            new DynEditControls.EditControl(MyOrg_Address_DynGroupBox, MyOrg_Address_v.ZIP_v, "MyOrg_Address_ZIP", lngRPMS.sl_MyOrg_Address_ZIP, lngRPMS.s_MyOrg_Address_ZIP_v, lngRPMS.sh_MyOrg_Address_ZIP);
            new DynEditControls.EditControl(MyOrg_Address_DynGroupBox, MyOrg_Address_v.City_v, "MyOrg_Address_ZIP", lngRPMS.sl_MyOrg_Address_City, lngRPMS.s_MyOrg_Address_City_v, lngRPMS.sh_MyOrg_Address_City);
            new DynEditControls.EditControl(MyOrg_Address_DynGroupBox, MyOrg_Address_v.State_v, "MyOrg_Address_State", lngRPMS.sl_MyOrg_Address_State, lngRPMS.s_MyOrg_Address_State_v, lngRPMS.sh_MyOrg_Address_State);
            new DynEditControls.EditControl(MyOrg_Address_Country_DynGroupBox, MyOrg_Address_v.Country_v, "MyOrg_Addres_Country", lngRPMS.sl_MyOrg_Address_Country, lngRPMS.s_MyOrg_Address_Country_v, lngRPMS.sh_MyOrg_Address_Country);
            new DynEditControls.EditControl(MyOrg_Address_Country_DynGroupBox, MyOrg_Address_v.Country_ISO_3166_a2_v, "MyOrg_Address_Country_ISO_3166_a2", lngRPMS.sl_MyOrg_Address_Country_ISO_3166_a2, lngRPMS.s_MyOrg_Address_Country_ISO_3166_a2_v, lngRPMS.sh_MyOrg_Address_Country_ISO_3166_a2);
            new DynEditControls.EditControl(MyOrg_Address_Country_DynGroupBox, MyOrg_Address_v.Country_ISO_3166_a3_v, "MyOrg_Address_Country_ISO_3166_a3", lngRPMS.sl_MyOrg_Address_Country_ISO_3166_a3, lngRPMS.s_MyOrg_Address_Country_ISO_3166_a3_v, lngRPMS.sh_MyOrg_Address_Country_ISO_3166_a3);
            new DynEditControls.EditControl(MyOrg_Address_Country_DynGroupBox, MyOrg_Address_v.Country_ISO_3166_num_v, "MyOrg_Address_Country_ISO_3166_num", lngRPMS.sl_MyOrg_Address_Country_ISO_3166_num, lngRPMS.s_MyOrg_Address_Country_ISO_3166_num_v, lngRPMS.sh_MyOrg_Address_Country_ISO_3166_num);


            new DynEditControls.EditControl(MyOrg_Office_DynGroupBox, MyOrg_Office_Name_v, "MyOrg_OfficeName", lngRPMS.sl_MyOrg_OfficeName, lngRPMS.s_MyOrg_OfficeName_v, lngRPMS.sh_MyOrg_OfficeName);
            new DynEditControls.EditControl(MyOrg_Office_DynGroupBox, MyOrg_Office_ShortName_v, "MyOrg_OfficeShortName", lngRPMS.sl_MyOrg_OfficeShortName, lngRPMS.s_MyOrg_OfficeShortName_v, lngRPMS.sh_MyOrg_OfficeShortName);

            new DynEditControls.EditControl(MyOrg_Office_Address_DynGroupBox, MyOrg_Office_Address_v.StreetName_v, "MyOrg_Office_Address_StreetName", lngRPMS.sl_MyOrg_Office_Address_StreetName, lngRPMS.s_MyOrg_Office_Address_StreetName_v, lngRPMS.sh_MyOrg_Office_Address_StreetName);
            new DynEditControls.EditControl(MyOrg_Office_Address_DynGroupBox, MyOrg_Office_Address_v.HouseNumber_v, "MyOrg_Office_Address_HouseNumber", lngRPMS.sl_MyOrg_Office_Address_HouseNumber, lngRPMS.s_MyOrg_Office_Address_HouseNumber_v, lngRPMS.sh_MyOrg_Office_Address_HouseNumber);
            new DynEditControls.EditControl(MyOrg_Office_Address_DynGroupBox, MyOrg_Office_Address_v.ZIP_v, "MyOrg_Office_Address_ZIP", lngRPMS.sl_MyOrg_Office_Address_ZIP, lngRPMS.s_MyOrg_Office_Address_ZIP_v, lngRPMS.sh_MyOrg_Office_Address_ZIP);
            new DynEditControls.EditControl(MyOrg_Office_Address_DynGroupBox, MyOrg_Office_Address_v.City_v, "MyOrg_Office_Address_ZIP", lngRPMS.sl_MyOrg_Office_Address_City, lngRPMS.s_MyOrg_Office_Address_City_v, lngRPMS.sh_MyOrg_Office_Address_City);
            new DynEditControls.EditControl(MyOrg_Office_Address_DynGroupBox, MyOrg_Office_Address_v.State_v, "MyOrg_Office_Address_State", lngRPMS.sl_MyOrg_Office_Address_State, lngRPMS.s_MyOrg_Office_Address_State_v, lngRPMS.sh_MyOrg_Office_Address_State);
            new DynEditControls.EditControl(MyOrg_Office_Address_Country_DynGroupBox, MyOrg_Office_Address_v.Country_v, "MyOrg_Addres_Country", lngRPMS.sl_MyOrg_Address_Country, lngRPMS.s_MyOrg_Office_Address_Country_v, lngRPMS.sh_MyOrg_Office_Address_Country);
            new DynEditControls.EditControl(MyOrg_Office_Address_Country_DynGroupBox, MyOrg_Office_Address_v.Country_ISO_3166_a2_v, "MyOrg_Office_Address_Country_ISO_3166_a2", lngRPMS.sl_MyOrg_Office_Address_Country_ISO_3166_a2, lngRPMS.s_MyOrg_Office_Address_Country_ISO_3166_a2_v, lngRPMS.sh_MyOrg_Office_Address_Country_ISO_3166_a2);
            new DynEditControls.EditControl(MyOrg_Office_Address_Country_DynGroupBox, MyOrg_Office_Address_v.Country_ISO_3166_a3_v, "MyOrg_Office_Address_Country_ISO_3166_a3", lngRPMS.sl_MyOrg_Office_Address_Country_ISO_3166_a3, lngRPMS.s_MyOrg_Office_Address_Country_ISO_3166_a3_v, lngRPMS.sh_MyOrg_Office_Address_Country_ISO_3166_a3);
            new DynEditControls.EditControl(MyOrg_Office_Address_Country_DynGroupBox, MyOrg_Office_Address_v.Country_ISO_3166_num_v, "MyOrg_Office_Address_Country_ISO_3166_num", lngRPMS.sl_MyOrg_Office_Address_Country_ISO_3166_num, lngRPMS.s_MyOrg_Office_Address_Country_ISO_3166_num_v, lngRPMS.sh_MyOrg_Office_Address_Country_ISO_3166_num);




            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_FirstName_v, "MyOrg_Person_FirstName", lngRPMS.sl_MyOrg_Person_FirstName, lngRPMS.s_MyOrg_Person_FirstName_v, lngRPMS.sh_MyOrg_Person_FirstName);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_LastName_v, "MyOrg_Person_LastName", lngRPMS.sl_MyOrg_Person_LastName, lngRPMS.s_MyOrg_Person_LastName_v, lngRPMS.sh_MyOrg_Person_LastName);

            if (LanguageControl.DynSettings.LanguageID == DynSettings.Slovensko_ID)
            {
                MyOrg_Person_Gender_v.v = false;
            }
            else
            {
                MyOrg_Person_Gender_v.v = true;
            }
            MyOrg_Person_Gender_v.defined = true;
            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Gender_v, "MyOrg_Person_Gender", lngRPMS.sl_MyOrg_Person_Gender, lngRPMS.s_MyOrg_Person_Gender_v, lngRPMS.sh_MyOrg_Person_Gender);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_DateOfBirth_v, "MyOrg_Person_DateOfBirth", lngRPMS.sl_MyOrg_Person_DateOfBirth, lngRPMS.s_MyOrg_Person_DateOfBirth_v, lngRPMS.sh_MyOrg_Person_DateOfBirth);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_UserName_v, "MyOrg_Person_UserName", lngRPMS.sl_MyOrg_Person_UserName, lngRPMS.s_MyOrg_Person_UserName_v, lngRPMS.sh_MyOrg_Person_UserName);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Password_v, "MyOrg_Person_Password", lngRPMS.sl_MyOrg_Person_Password, lngRPMS.s_MyOrg_Person_Password_v, lngRPMS.sh_MyOrg_Person_Password);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Job_v, "MyOrg_Person_Job", lngRPMS.sl_MyOrg_Person_Job, lngRPMS.s_MyOrg_Person_Job_v, lngRPMS.sh_MyOrg_Person_Job);

            MyOrg_Person_Active_v = new dbool_v(true);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Description_v, " MyOrg_Person_Description", lngRPMS.sl_MyOrg_Person_Description, lngRPMS.s_MyOrg_Person_Description_v, lngRPMS.sh_MyOrg_Person_Description);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Tax_ID_v, "MyOrg_Person_Tax_ID", lngRPMS.sl_MyOrg_Person_Tax_ID, lngRPMS.s_MyOrg_Person_Tax_ID_v, lngRPMS.sh_MyOrg_Person_Tax_ID);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Registration_ID_v, "MyOrg_Person_Registration_ID", lngRPMS.sl_MyOrg_Person_Registration_ID, lngRPMS.s_MyOrg_Person_Registration_ID_v, lngRPMS.sh_MyOrg_Person_Registration_ID);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_GsmNumber_v, "MyOrg_Person_GsmNumber", lngRPMS.sl_MyOrg_Person_GsmNumber, lngRPMS.s_MyOrg_Person_GsmNumber_v, lngRPMS.sh_MyOrg_Person_GsmNumber);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_PhoneNumber_v, "MyOrg_Person_PhoneNumber", lngRPMS.sl_MyOrg_Person_PhoneNumber, lngRPMS.s_MyOrg_Person_PhoneNumber_v, lngRPMS.sh_MyOrg_Person_PhoneNumber);

            new DynEditControls.EditControl(MyOrg_Office_Person_DynGroupBox, MyOrg_Person_Email_v, "MyOrg_Person_Email", lngRPMS.sl_MyOrg_Person_Email, lngRPMS.s_MyOrg_Person_Email_v, lngRPMS.sh_MyOrg_Person_Email);

            new DynEditControls.EditControl(MyOrg_Office_Person_Address_DynGroupBox, MyOrg_Office_Person_Address_v.StreetName_v, "MyOrg_Office_Person_Address_StreetName", lngRPMS.sl_MyOrg_Office_Person_Address_StreetName, lngRPMS.s_MyOrg_Office_Person_Address_StreetName_v, lngRPMS.sh_MyOrg_Office_Person_Address_StreetName);
            new DynEditControls.EditControl(MyOrg_Office_Person_Address_DynGroupBox, MyOrg_Office_Person_Address_v.HouseNumber_v, "MyOrg_Office_Person_Address_HouseNumber", lngRPMS.sl_MyOrg_Office_Person_Address_HouseNumber, lngRPMS.s_MyOrg_Office_Person_Address_HouseNumber_v, lngRPMS.sh_MyOrg_Office_Person_Address_HouseNumber);
            new DynEditControls.EditControl(MyOrg_Office_Person_Address_DynGroupBox, MyOrg_Office_Person_Address_v.ZIP_v, "MyOrg_Office_Person_Address_ZIP", lngRPMS.sl_MyOrg_Office_Person_Address_ZIP, lngRPMS.s_MyOrg_Office_Person_Address_ZIP_v, lngRPMS.sh_MyOrg_Office_Person_Address_ZIP);
            new DynEditControls.EditControl(MyOrg_Office_Person_Address_DynGroupBox, MyOrg_Office_Person_Address_v.City_v, "MyOrg_Office_Person_Address_ZIP", lngRPMS.sl_MyOrg_Office_Person_Address_City, lngRPMS.s_MyOrg_Office_Person_Address_City_v, lngRPMS.sh_MyOrg_Office_Person_Address_City);
            new DynEditControls.EditControl(MyOrg_Office_Person_Address_DynGroupBox, MyOrg_Office_Person_Address_v.State_v, "MyOrg_Office_Person_Address_State", lngRPMS.sl_MyOrg_Office_Person_Address_State, lngRPMS.s_MyOrg_Office_Person_Address_State_v, lngRPMS.sh_MyOrg_Office_Person_Address_State);
            new DynEditControls.EditControl(MyOrg_Office_Person_Address_Country_DynGroupBox, MyOrg_Office_Person_Address_v.Country_v, "MyOrg_Office_Person_Address_Country", lngRPMS.sl_MyOrg_Address_Country, lngRPMS.s_MyOrg_Office_Person_Address_Country_v, lngRPMS.sh_MyOrg_Office_Person_Address_Country);
            new DynEditControls.EditControl(MyOrg_Office_Person_Address_Country_DynGroupBox, MyOrg_Office_Person_Address_v.Country_ISO_3166_a2_v, "MyOrg_Office_Person_Address_Country_ISO_3166_a2", lngRPMS.sl_MyOrg_Office_Person_Address_Country_ISO_3166_a2, lngRPMS.s_MyOrg_Office_Person_Address_Country_ISO_3166_a2_v, lngRPMS.sh_MyOrg_Office_Person_Address_Country_ISO_3166_a2);
            new DynEditControls.EditControl(MyOrg_Office_Person_Address_Country_DynGroupBox, MyOrg_Office_Person_Address_v.Country_ISO_3166_a3_v, "MyOrg_Office_Person_Address_Country_ISO_3166_a3", lngRPMS.sl_MyOrg_Office_Person_Address_Country_ISO_3166_a3, lngRPMS.s_MyOrg_Office_Person_Address_Country_ISO_3166_a3_v, lngRPMS.sh_MyOrg_Office_Person_Address_Country_ISO_3166_a3);
            new DynEditControls.EditControl(MyOrg_Office_Person_Address_Country_DynGroupBox, MyOrg_Office_Person_Address_v.Country_ISO_3166_num_v, "MyOrg_Office_Person_Address_Country_ISO_3166_num", lngRPMS.sl_MyOrg_Office_Person_Address_Country_ISO_3166_num, lngRPMS.s_MyOrg_Office_Person_Address_Country_ISO_3166_num_v, lngRPMS.sh_MyOrg_Office_Person_Address_Country_ISO_3166_num);


            //MyOrg_Office_Name_v = new DBTypes.dstring_v(lngRPMS.s_MyOrg_OfficeName_v.s);
            //MyOrg_Office_ShortName_v = new DBTypes.dstring_v(lngRPMS.s_MyOrg_OfficeShortName_v.s);

            MyOrg_Address_Country_DynGroupBox.ReadOnly = true;
            MyOrg_Office_Address_Country_DynGroupBox.ReadOnly = true;
            MyOrg_Office_Person_Address_Country_DynGroupBox.ReadOnly = true;
        }


        internal bool ShowDialog(ref bool bCanceled, NavigationButtons.Navigation xnav, Icon oIcon)
        {
            Country_ISO_3166.ISO_3166_Table myISO_3166_Table = new Country_ISO_3166.ISO_3166_Table();
            string DefaultCountry = null;
            if (DynSettings.LanguageID == DynSettings.Slovensko_ID)
            {
                DefaultCountry = "Slovenija";
            }
            Country_ISO_3166.Form_Select_Country_ISO_3166 frmsel_country = new Country_ISO_3166.Form_Select_Country_ISO_3166(myISO_3166_Table.dt_ISO_3166, DefaultCountry, lngRPMS.s_SelectCountryWhereYouPayTaxes.s, xnav);
            if (frmsel_country.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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

                Form_EditSampleData fedt = new Form_EditSampleData(this, xnav, oIcon);
                xnav.ChildDialog = fedt;
                xnav.ShowDialog();
                if ((xnav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT)|| (xnav.eExitResult == NavigationButtons.Navigation.eEvent.OK))
                {
                    return true;
                }
                
             }
            bCanceled = true;
            return false;
        }

        public string GetHash_SHA1(byte[] byteArray)
        {
            string hash = "";
            hash = Convert.ToBase64String(my_SHA1CryptoServiceProvider.ComputeHash(byteArray));
            return hash;
        }

        public bool DeleteAll()
        {

            if (f_OrganisationAccount.DeleteAll())
            {
                if (f_BankAccount.DeleteAll())
                {
                    if (f_Bank.DeleteAll())
                    {
                        if (f_OrganisationData.DeleteAll())
                        {
                            if (f_myOrganisation_Person.DeleteAll())
                            {
                                if (f_Person.DeleteAll())
                                {
                                    if (f_Office_Data.DeleteAll())
                                    {
                                        if (f_Office.DeleteAll())
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
            return false;
        }

        public bool Write()
        {
            if (MyOrg_Image_Data_v!=null)
            {
                if (MyOrg_Image_Data_v.v != null)
                {
                    MyOrg_Image_Hash_v.v = GetHash_SHA1(MyOrg_Image_Data_v.v);
                }
            }
            long_v Bank_Organisation_ID_v = null;
            if (f_Organisation.Get(MyOrg_Bank_Name_v,MyOrg_Bank_Tax_ID_v,MyOrg_Bank_Registration_ID_v,ref Bank_Organisation_ID_v))
            {
                long_v Bank_ID_v = null;
                if (f_Bank.Get(Bank_Organisation_ID_v, ref Bank_ID_v))
                {

                    long_v MyOrg_BankAccount_ID_v = null;
                    if (f_BankAccount.Get(MyOrg_BankAccount_TRR_v,MyOrg_BankAccount_Active_v,MyOrg_BankAccount_Description_v, Bank_ID_v,ref MyOrg_BankAccount_ID_v))
                    {
                        if (f_Organisation.Get(MyOrg_Name_v,
                                            MyOrg_Tax_ID_v,
                                            MyOrg_Registration_ID_v,
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
                                                ref MyOrg_OrganisationData_ID_v))
                        {
                            long_v OrganisationAccount_ID_v = null;
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
                    }
                }
            }
            return false;
        }



        public bool Insert_MyOrgData()
        {

            return false;
        }

        public bool Write_ShopB_Items()
        {
            string Currency_Name = null;
            string Currency_Abbreviation = null;
            string Currency_Symbol = null;
            int Currency_Code = 0;
            int Currency_DecimalPlaces = 2;

            if (f_Currency.Get(myOrg.Default_Currency_ID, ref Currency_Abbreviation, ref Currency_Name, ref Currency_Symbol, ref Currency_Code, ref Currency_DecimalPlaces))
            {

                SampleDB_Price_ShopB_Item[] SampleDB_Price_ShopB_Item_List = new SampleDB_Price_ShopB_Item[]
                {new SampleDB_Price_ShopB_Item(lngRPMS.ShopB_Item_Name_Item1.s,
                                               lngRPMS.ShopB_Item_Abbreviation_SB1.s,
                                               true,
                                               Properties.Resources.Pedikira,
                                               null,
                                               lngRPMS.ShopB_Item_ParentGroup1.s,
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
                                               Currency_DecimalPlaces,
                                               "DDV 22%",
                                               0.22M,
                                               2,
                                               null
                                  )};
                foreach (SampleDB_Price_ShopB_Item sample_ShopB_Item in SampleDB_Price_ShopB_Item_List)
                {
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
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Write_ShopC_Items()
        {
            string Currency_Name = null;
            string Currency_Abbreviation = null;
            string Currency_Symbol = null;
            int Currency_Code = 0;
            int Currency_DecimalPlaces = 2;

            if (f_Currency.Get(myOrg.Default_Currency_ID, ref Currency_Abbreviation, ref Currency_Name, ref Currency_Symbol, ref Currency_Code, ref Currency_DecimalPlaces))
            {

                SampleDB_Price_ShopC_Item[] SampleDB_Price_ShopC_Item_List = new SampleDB_Price_ShopC_Item[]
                {new SampleDB_Price_ShopC_Item(
                                               lngRPMS.ShopC_Item_UniquName_UniqueItemName1.s,
                                               lngRPMS.ShopB_Item_Abbreviation_SB1.s,
                                               new int_v(1),
                                               lngRPMS.ShopC_Item_ParentGroup1.s,
                                               null,
                                               null,
                                               "komad",
                                               "kom.",
                                               0,
                                               true,
                                               null,
                                               null,
                                               lngRPM.s_Description.s,
                                               180,
                                               60,
                                               10,
                                               null,
                                               -1,
                                               -1,
                                               null,
                                               null,
                                               true,
                                               lngRPMS.PriceList_Name.s,
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
                                               "DDV 22%",
                                               0.22M,
                                               10M,
                                               new decimal_v(0)
                                  )};
                foreach (SampleDB_Price_ShopC_Item sample_ShopC_Item in SampleDB_Price_ShopC_Item_List)
                {
                    f_Expiry.Expiry_v expiry_v = null;
                    if (sample_ShopC_Item.ShopC_Item_Expiry_ExpectedShelfLifeInDays >= 0)
                    {
                        expiry_v = new f_Expiry.Expiry_v();
                        expiry_v.ExpectedShelfLifeInDays = sample_ShopC_Item.ShopC_Item_Expiry_ExpectedShelfLifeInDays;
                        expiry_v.DiscardBeforeExpiryDateInDays = sample_ShopC_Item.ShopC_Item_Expiry_DiscardBeforeExpiryDateInDays;
                        expiry_v.SaleBeforeExpiryDateInDays = sample_ShopC_Item.ShopC_Item_Expiry_SaleBeforeExpiryDateInDays;
                        expiry_v.ExpiryDescription = sample_ShopC_Item.ShopC_Item_Expiry_ExpiryDescription;

                    }
                    f_Warranty.Warranty_v warranty_v = null;
                    if (sample_ShopC_Item.ShopC_Item_Warranty_WarrantyDuration >= 0)
                    {
                        warranty_v = new f_Warranty.Warranty_v();
                        warranty_v.WarrantyDuration = sample_ShopC_Item.ShopC_Item_Warranty_WarrantyDuration;
                        warranty_v.WarrantyDurationType = sample_ShopC_Item.ShopC_Item_Warranty_WarrantyDurationType;
                        warranty_v.WarrantyConditions = sample_ShopC_Item.ShopC_Item_Warranty_WarrantyConditions;

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
                                   expiry_v,
                                   warranty_v,
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
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
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
