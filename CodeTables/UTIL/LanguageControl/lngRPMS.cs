#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace LanguageControl
{
    public static class lngRPMS
    {
        public static ltext s_SelectCountryWhereYouPayTaxes = new ltext("Country of tax residency", "Država kateri plačujete davke");
        public static ltext s_MyOrg_Organisation_Name_v = new ltext("Organisation1", "Podjetje1");
        public static ltext s_MyOrg_Tax_ID_v = new ltext("12345678", "12345678");
        public static ltext s_MyOrg_Registration_ID_v = new ltext("00000001", "00000001");
        public static ltext s_MyOrg_OrganisationTYPE_v = new ltext("ltd", "d.o.o.");
        public static ltext s_MyOrg_PhoneNumber_v = new ltext("000000", "0000000");
        public static ltext s_MyOrg_FaxNumber_v = new ltext("000000", "00000");
        public static ltext s_MyOrg_Email_v = new ltext("Organisation1@email.com", "Podjetje1@email.com");
        public static ltext s_MyOrg_HomePage_v = new ltext("www.Organisation1.com", "www.Podjetje1.si");
        public static ltext s_MyOrg_BankName_v = new ltext("Bank1", "Banka1");
        public static ltext s_MyOrg_TRR_v = new ltext("0000-0000-000-000", "0000-0000-000-000");

        public static ltext s_MyOrg_Address_City_v = new ltext("City1", "Mesto1");
        public static ltext s_MyOrg_Address_ZIP_v = new ltext("Zip1", "ŠtevilkaPošte1");
        public static ltext s_MyOrg_Address_HouseNumber_v = new ltext("1", "1");
        public static ltext s_MyOrg_Address_StreetName_v = new ltext("MyStreet1", "Cesta1");
        public static ltext s_MyOrg_Address_State_v = new ltext("MyStreet1", "Cesta1");

        public static ltext s_MyOrg_OfficeName_v = new ltext("Office1", "Pisarna1");
        public static ltext s_MyOrg_OfficeShortName_v = new ltext("o1", "p1");
        

        public static ltext s_MyOrg_Person_UserName_v = new ltext("Organisation1Person1UserName1", "UporabniškoIme1Osebe1Podjetja1");
        public static ltext s_MyOrg_Person_Password_v = new ltext("Organisation1Person1Password1", "GesloOsebe1Podjetja1");
        public static ltext s_MyOrg_Person_Job_v = new ltext("Organisation1Person1Job", "DelovnoMestoOsebe1Podjetja1");



        public static ltext s_MyOrg_Person_FirstName_v = new ltext("Organisation1Person1FirstName", "ImeOsebe1Podjetja1");
        public static ltext s_MyOrg_Person_LastName_v = new ltext("Organisation1Person1LastName", "PriimekOsebe1Podjetja1");
        public static ltext s_MyOrg_Person_Tax_ID_v = new ltext("11111111", "11111111");
        public static ltext s_MyOrg_Person_Registration_ID_v = new ltext("222222222", "22222222");
        public static ltext s_MyOrg_Person_GsmNumber_v = new ltext("0038641 707369", "041 707369");
        public static ltext s_MyOrg_Person_PhoneNumber_v = new ltext("00386 15839410", "0038615839410");
        public static ltext s_MyOrg_Person_Email_v = new ltext("Person1@mail.com", "Person1@mail.com");
        public static ltext s_MyOrg_Person_StreetName_v = new ltext("Person1Street1", "Oseba1Cesta1");
        public static ltext s_MyOrg_Person_HouseNumber_v = new ltext("0", "0");
        public static ltext s_MyOrg_Person_City_v = new ltext("City1", "Mesto1");
        public static ltext s_MyOrg_Person_ZIP_v = new ltext("ZIP?", "ŠtevilkaPošte1");

        public static ltext s_MyOrg_Person_Country_v = null;
        public static ltext s_MyOrg_Person_Country_ISO_3166_a2 = null;
        public static ltext s_MyOrg_Person_Country_ISO_3166_a3 = null;
        public static ltext s_MyOrg_Person_Country_ISO_3166_num = null;

        public static ltext MyOrg_Person_State_v = null;
        public static ltext MyOrg_Person_CardNumber_v = null;
        public static ltext MyOrg_Person_CardType_v = null;
        public static ltext MyOrg_Person_Image_Hash_v = null;
        public static ltext MyOrg_Person_Image_Data_v = null;
        public static ltext MyOrg_Person_Atom_Person_ID_v = null;

        public static ltext SimpleItem_Name_Pedicure = new ltext("pedicure","pedikura");
        public static ltext SimpleItem_Abbreviation_Pedicure = new ltext("PED", "PED");
        public static ltext SimpleItem_ParentGroup1 = new ltext("Foot care","Nega stopal" );
        public static ltext PriceList_Name = new ltext("PRICE LIST CUSTOMERS","CENIK STRANKE");
        public static ltext PriceList_Description = new ltext("Price list for usual customers.","Cenik za stalne stranke.");
    }
}
     
