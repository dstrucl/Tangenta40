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
        public static ltext s_SelectCountryWhereYouPayTaxes = new ltext("Country of tax residency", "Država katere ste davčni zavezanec");

        public static ltext sl_MyOrg_Name =  new ltext("Organisation name", "Ime organizacije");
        public static ltext s_MyOrg_Name_v = new ltext("Organisation1", "Podjetje1");
        public static ltext sh_MyOrg_Name = new ltext("Enter your organisation name", "Vpišite ime vaše organizacije");

        public static ltext sl_MyOrg_Tax_ID = new ltext("Organisation VAT number", "Davčna številka");
        public static ltext s_MyOrg_Tax_ID_v = new ltext("12345678", "12345678");
        public static ltext sh_MyOrg_Tax_ID = new ltext("Enter your organisation VAT number", "Vpišite davčno številko");

        public static ltext sl_MyOrg_Registration_ID = new ltext("Your Organisation Registration Number", "Matična številka vaše organizacije");
        public static ltext s_MyOrg_Registration_ID_v = new ltext("00000001", "00000001");
        public static ltext sh_MyOrg_Registration_ID = new ltext("Enter Your Organisation Registration Number", "Vpišite matično številko vaše organizacije");

        public static ltext sl_MyOrg_OrganisationTYPE = new ltext("Type of organisation", "Tip organizacije");
        public static ltext s_MyOrg_OrganisationTYPE_v = new ltext("ltd", "d.o.o.");
        public static ltext sh_MyOrg_OrganisationTYPE = new ltext("Enter type of your organisation (ltd., gov.,)", "Vpišite vrsto vaše organizacije (d.d.,d.o.o.,javni zavod,..)");

        public static ltext sl_MyOrg_PhoneNumber = new ltext("Organisation phone number", "Številka telefona vaše organizacije");
        public static ltext s_MyOrg_PhoneNumber_v = new ltext("000000", "0000000");
        public static ltext sh_MyOrg_PhoneNumber = new ltext("Enter your organisation phone number", "Vpišite številko telefona vaše organizacije");

        public static ltext sl_MyOrg_FaxNumber = new ltext("Organisation fax number", "Številka fax-a vaše organizacije");
        public static ltext s_MyOrg_FaxNumber_v = new ltext("000000", "00000");
        public static ltext sh_MyOrg_FaxNumber = new ltext("Enter your organisation fax number", "Vpišite številko fax-a vaše organizacije");

        public static ltext sl_MyOrg_Email = new ltext("Organisation email", "Elektronski naslov vaše organizacije");
        public static ltext s_MyOrg_Email_v = new ltext("Organisation1@email.com", "Podjetje1@email.com");
        public static ltext sh_MyOrg_Email = new ltext("Enter your organisation email", "Vpišite elektronski naslov (email) vaše organizacije");

        public static ltext sl_MyOrg_HomePage = new ltext("Organisation homepage", "Domači naslov vaše organizacije");
        public static ltext s_MyOrg_HomePage_v = new ltext("www.Organisation1.com", "www.Podjetje1.si");
        public static ltext sh_MyOrg_HomePage = new ltext("Enter your organisation homepage", "Vpišite domači naslov (homepage) vaše organizacije");

        public static ltext sl_MyOrg_BankName = new ltext("The name of bank of your organisation bank account", "Ime banke vašega TRR računa vaše organizacije");
        public static ltext s_MyOrg_BankName_v = new ltext("Bank1", "Banka1");
        public static ltext sh_MyOrg_BankName = new ltext("Enter the name of bank of your organisation bank account", "Vpišite ime banke vašega TRR računa vaše organizacije");

        public static ltext sl_MyOrg_TRR = new ltext("Bank account", "Številka TRR računa vaše organizacije");
        public static ltext s_MyOrg_TRR_v = new ltext("0000-0000-000-000", "0000-0000-000-000");
        public static ltext sh_MyOrg_TRR = new ltext("Enter bank account", "Vpišite številko TRR računa vaše organizacije");


        public static ltext sl_MyOrg_Address_StreetName = new ltext("Street", "Cesta");
        public static ltext s_MyOrg_Address_StreetName_v = new ltext("MyStreet1", "Cesta1");
        public static ltext sh_MyOrg_Address_StreetName = new ltext("Enter street name", "Vpišite ime ceste");

        public static ltext sl_MyOrg_Address_HouseNumber = new ltext("House number", "Hišna številka");
        public static ltext s_MyOrg_Address_HouseNumber_v = new ltext("1", "1");
        public static ltext sh_MyOrg_Address_HouseNumber = new ltext("Enter house number", "Vpišite hišno številko");

        public static ltext sl_MyOrg_Address_ZIP = new ltext("ZIP", "Številka pošte");
        public static ltext s_MyOrg_Address_ZIP_v = new ltext("Zip1", "ŠtevilkaPošte1");
        public static ltext sh_MyOrg_Address_ZIP = new ltext("Enter ZIP", "Vpišite številko pošte");

        public static ltext sl_MyOrg_Address_City = new ltext("City", "Mesto");
        public static ltext s_MyOrg_Address_City_v = new ltext("City1", "Mesto1");
        public static ltext sh_MyOrg_Address_City = new ltext("Enter city", "Vpišite mesto");

        public static ltext sl_MyOrg_Address_State = new ltext("State", "Dežela");
        public static ltext s_MyOrg_Address_State_v = new ltext("", "");
        public static ltext sh_MyOrg_Address_State = new ltext("Enter State", "Vpišite deželo");


        public static ltext sl_MyOrg_Addres_Country = new ltext("Country", "Država");
        public static ltext s_MyOrg_Address_Country_v = new ltext("Country1", "Država1");
        public static ltext sh_MyOrg_Address_Country = new ltext("Enter country", "Vpišite državo");

        public static ltext sl_MyOrg_Address_Country_ISO_3166_a2 = new ltext("Country abbreviation (2 characters)", "Okrajšavo za državo (2 znaka)");
        public static ltext s_MyOrg_Address_Country_ISO_3166_a2_v = new ltext("??", "??");
        public static ltext sh_MyOrg_Address_Country_ISO_3166_a2 = new ltext("Enter country abbreviation (2 characters)", "Vpišite okrajšavo za državo (2 znaka)");

        public static ltext sl_MyOrg_Address_Country_ISO_3166_a3 = new ltext("Country abbreviation (3 characters)", "Okrajšavo za državo (3 znaki)");
        public static ltext s_MyOrg_Address_Country_ISO_3166_a3_v = new ltext("??", "??");
        public static ltext sh_MyOrg_Address_Country_ISO_3166_a3 = new ltext("Enter country abbreviation (3 characters)", "Vpišite okrajšavo za državo (3 znaki)");

        public static ltext sl_MyOrg_Address_Country_ISO_3166_num = new ltext("Country code number", "Kodna številka države");
        public static ltext s_MyOrg_Address_Country_ISO_3166_num_v = new ltext("", "");
        public static ltext sh_MyOrg_Address_Country_ISO_3166_num = new ltext("Enter country iso code number", "Vpišite kodno ISO 3166 številko države");


        public static ltext sl_MyOrg_Office_Address_StreetName = new ltext("Street", "Cesta");
        public static ltext s_MyOrg_Office_Address_StreetName_v = new ltext("MyStreet1", "Cesta1");
        public static ltext sh_MyOrg_Office_Address_StreetName = new ltext("Enter street name", "Vpišite ime ceste");

        public static ltext sl_MyOrg_Office_Address_HouseNumber = new ltext("House number", "Hišna številka");
        public static ltext s_MyOrg_Office_Address_HouseNumber_v = new ltext("1", "1");
        public static ltext sh_MyOrg_Office_Address_HouseNumber = new ltext("Enter house number", "Vpišite hišno številko");

        public static ltext sl_MyOrg_Office_Address_ZIP = new ltext("ZIP", "Številka pošte");
        public static ltext s_MyOrg_Office_Address_ZIP_v = new ltext("Zip1", "ŠtevilkaPošte1");
        public static ltext sh_MyOrg_Office_Address_ZIP = new ltext("Enter ZIP", "Vpišite številko pošte");

        public static ltext sl_MyOrg_Office_Address_City = new ltext("City", "Mesto");
        public static ltext s_MyOrg_Office_Address_City_v = new ltext("City1", "Mesto1");
        public static ltext sh_MyOrg_Office_Address_City = new ltext("Enter city", "Vpišite mesto");

        public static ltext sl_MyOrg_Office_Address_State = new ltext("State", "Dežela");
        public static ltext s_MyOrg_Office_Address_State_v = new ltext("", "");
        public static ltext sh_MyOrg_Office_Address_State = new ltext("Enter State", "Vpišite deželo");


        public static ltext sl_MyOrg_Office_Address_Country = new ltext("Country", "Država");
        public static ltext s_MyOrg_Office_Address_Country_v = new ltext("Country1", "Država1");
        public static ltext sh_MyOrg_Office_Address_Country = new ltext("Enter country", "Vpišite državo");

        public static ltext sl_MyOrg_Office_Address_Country_ISO_3166_a2 = new ltext("Country abbreviation (2 characters)", "Okrajšavo za državo (2 znaka)");
        public static ltext s_MyOrg_Office_Address_Country_ISO_3166_a2_v = new ltext("??", "??");
        public static ltext sh_MyOrg_Office_Address_Country_ISO_3166_a2 = new ltext("Enter country abbreviation (2 characters)", "Vpišite okrajšavo za državo (2 znaka)");

        public static ltext sl_MyOrg_Office_Address_Country_ISO_3166_a3 = new ltext("Country abbreviation (3 characters)", "Okrajšavo za državo (3 znaki)");
        public static ltext s_MyOrg_Office_Address_Country_ISO_3166_a3_v = new ltext("??", "??");
        public static ltext sh_MyOrg_Office_Address_Country_ISO_3166_a3 = new ltext("Enter country abbreviation (3 characters)", "Vpišite okrajšavo za državo (3 znaki)");

        public static ltext sl_MyOrg_Office_Address_Country_ISO_3166_num = new ltext("Country code number", "Kodna številka države");
        public static ltext s_MyOrg_Office_Address_Country_ISO_3166_num_v = new ltext("", "");
        public static ltext sh_MyOrg_Office_Address_Country_ISO_3166_num = new ltext("Enter country iso code number", "Vpišite kodno ISO 3166 številko države");

        public static ltext sl_MyOrg_OfficeName = new ltext("Office name", "Ime poslovne enote");
        public static ltext s_MyOrg_OfficeName_v = new ltext("Office1", "Pisarna1");
        public static ltext sh_MyOrg_OfficeName = new ltext("Enter office name", "Vpišite ime poslovne enote");

        public static ltext sl_MyOrg_OfficeShortName = new ltext("Office short name", "Skrajšano ime poslovne enote");
        public static ltext s_MyOrg_OfficeShortName_v = new ltext("Off1", "Pis1");
        public static ltext sh_MyOrg_OfficeShortName = new ltext("Enter office short name", "Vpišite skrajšano ime poslovne enote");




        public static ltext sl_MyOrg_Person_FirstName = new ltext("Organisation administrator First Name", "Ime glavnega administratorja v podjetju");
        public static ltext s_MyOrg_Person_FirstName_v = new ltext("Organisation1Person1FirstName", "ImeOsebe1Podjetja1");
        public static ltext sh_MyOrg_Person_FirstName = new ltext("Enter organisation administrator First Name", "Vpišite ime glavnega administratorja, ki bo imel vse uporabniške pravice");

        public static ltext sl_MyOrg_Person_LastName = new ltext("Organisation administrator Last Name", "Priimek glavnega administratorja v podjetju");
        public static ltext s_MyOrg_Person_LastName_v = new ltext("Organisation1Person1LastName", "PrimekOsebe1Podjetja1");
        public static ltext sh_MyOrg_Person_LastName = new ltext("Enter organisation administrator Lasst Name who gets all user rights", "Vpišite priimek glavnega administratorja, ki bo imel vse uporabniške pravice");

        public static ltext sl_MyOrg_Person_Gender = new ltext("Administrator gender", "Spol glavnega administratorja v podjetju");
        public static ltext s_MyOrg_Person_Gender_v = null;
        public static ltext sh_MyOrg_Person_Gender = new ltext("Enter gender of administrator", "Označite spol administratorja, ki bo imel vse uporabniške pravice");

        
        public static ltext sl_MyOrg_Person_DateOfBirth = new ltext("Administrator date of birth", "Datum rojstva glavnega administratorja v podjetju");
        public static ltext s_MyOrg_Person_DateOfBirth_v = null;
        public static ltext sh_MyOrg_Person_DateOfBirth = new ltext("Enter date of birth of administrator", "Vpišite datum rojstva glavnega administratorja");




        public static ltext sl_MyOrg_Person_UserName = new ltext("Administrator user name", "Uporabniško ime glavnega administratorja");
        public static ltext s_MyOrg_Person_UserName_v = new ltext("Organisation1Person1UserName1", "UporabniškoIme1Osebe1Podjetja1");
        public static ltext sh_MyOrg_Person_UserName = new ltext("Enter administrator user name", "Vpišiti uporabniško ime glavnega administratorja");

        public static ltext sl_MyOrg_Person_Password = new ltext("Administrator password", "Geslo glavnega administratorja");
        public static ltext s_MyOrg_Person_Password_v = new ltext("Organisation1Person1Password1", "GesloOsebe1Podjetja1");
        public static ltext sh_MyOrg_Person_Password = new ltext("Enter administrator password", "Vpišite geslo glavnega administratorja");

        public static ltext sl_MyOrg_Person_Job = new ltext("Administrator Job Title", "Delovno mesto glavnega administratorja");
        public static ltext s_MyOrg_Person_Job_v = new ltext("Organisation1Person1Job", "DelovnoMestoOsebe1Podjetja1");
        public static ltext sh_MyOrg_Person_Job = new ltext("Organisation1Person1Job", "DelovnoMestoOsebe1Podjetja1");

        public static ltext sl_MyOrg_Person_Description = new ltext("Administrator description", "Glavni administrator opis");
        public static ltext s_MyOrg_Person_Description_v = new ltext("Organisation1Person1Description", "Osebe1Podjetja1Opis");
        public static ltext sh_MyOrg_Person_Description = new ltext("Enter job description of administrator", "Vpišite opis dela glavnega administratorja");


        public static ltext sl_MyOrg_Person_Tax_ID = new ltext("Administrator's Tax ID", "Davčna številka glavnega administratorja");
        public static ltext s_MyOrg_Person_Tax_ID_v = new ltext("12345678", "12345678");
        public static ltext sh_MyOrg_Person_Tax_ID = new ltext("Enter administrator's Tax ID", "Vpišite davčno številka glavnega administratorja");

        public static ltext sl_MyOrg_Person_Registration_ID = new ltext("Administrator's registration ID", "EMŠO glavnega administratorja");
        public static ltext s_MyOrg_Person_Registration_ID_v = new ltext("", "");
        public static ltext sh_MyOrg_Person_Registration_ID = new ltext("Enter administrator's registration ID", "Vpišite EMŠO glavnega administratorja");

        public static ltext sl_MyOrg_Person_GsmNumber = new ltext("Administrator's mobile phone naumber", "Mobilni telefon glavnega administratorja");
        public static ltext s_MyOrg_Person_GsmNumber_v = new ltext("", "");
        public static ltext sh_MyOrg_Person_GsmNumber = new ltext("Administrator's mobile phone naumber", "Vpišite številko mobilnega telefona glavnega administratorja");

        public static ltext sl_MyOrg_Person_PhoneNumber = new ltext("Administrator's phone naumber", "Telefon glavnega administratorja");
        public static ltext s_MyOrg_Person_PhoneNumber_v = new ltext("00386 15839410", "0038615839410");
        public static ltext sh_MyOrg_Person_PhoneNumber = new ltext("Enter administrator's phone naumber", "Vpišite telefon glavnega administratorja");

        public static ltext sl_MyOrg_Person_Email = new ltext("Administrator's email", "Email administratorja");
        public static ltext s_MyOrg_Person_Email_v = new ltext("Person1@mail.com", "Person1@mail.com");
        public static ltext sh_MyOrg_Person_Email = new ltext("Enter Administrator's email", "Vpišite email administratorja");

        public static ltext sl_MyOrg_Office_Person_Address_StreetName = new ltext("Street", "Cesta");
        public static ltext s_MyOrg_Office_Person_Address_StreetName_v = new ltext("MyStreet1", "Cesta1");
        public static ltext sh_MyOrg_Office_Person_Address_StreetName = new ltext("Enter street name", "Vpišite ime ceste");

        public static ltext sl_MyOrg_Office_Person_Address_HouseNumber = new ltext("House number", "Hišna številka");
        public static ltext s_MyOrg_Office_Person_Address_HouseNumber_v = new ltext("1", "1");
        public static ltext sh_MyOrg_Office_Person_Address_HouseNumber = new ltext("Enter house number", "Vpišite hišno številko");

        public static ltext sl_MyOrg_Office_Person_Address_ZIP = new ltext("ZIP", "Številka pošte");
        public static ltext s_MyOrg_Office_Person_Address_ZIP_v = new ltext("Zip1", "ŠtevilkaPošte1");
        public static ltext sh_MyOrg_Office_Person_Address_ZIP = new ltext("Enter ZIP", "Vpišite številko pošte");

        public static ltext sl_MyOrg_Office_Person_Address_City = new ltext("City", "Mesto");
        public static ltext s_MyOrg_Office_Person_Address_City_v = new ltext("City1", "Mesto1");
        public static ltext sh_MyOrg_Office_Person_Address_City = new ltext("Enter city", "Vpišite mesto");

        public static ltext sl_MyOrg_Office_Person_Address_State = new ltext("State", "Dežela");
        public static ltext s_MyOrg_Office_Person_Address_State_v = new ltext("", "");
        public static ltext sh_MyOrg_Office_Person_Address_State = new ltext("Enter State", "Vpišite deželo");


        public static ltext sl_MyOrg_Office_Person_Address_Country = new ltext("Country", "Država");
        public static ltext s_MyOrg_Office_Person_Address_Country_v = new ltext("Country1", "Država1");
        public static ltext sh_MyOrg_Office_Person_Address_Country = new ltext("Enter country", "Vpišite državo");

        public static ltext sl_MyOrg_Office_Person_Address_Country_ISO_3166_a2 = new ltext("Country abbreviation (2 characters)", "Okrajšavo za državo (2 znaka)");
        public static ltext s_MyOrg_Office_Person_Address_Country_ISO_3166_a2_v = new ltext("??", "??");
        public static ltext sh_MyOrg_Office_Person_Address_Country_ISO_3166_a2 = new ltext("Enter country abbreviation (2 characters)", "Vpišite okrajšavo za državo (2 znaka)");

        public static ltext sl_MyOrg_Office_Person_Address_Country_ISO_3166_a3 = new ltext("Country abbreviation (3 characters)", "Okrajšavo za državo (3 znaki)");
        public static ltext s_MyOrg_Office_Person_Address_Country_ISO_3166_a3_v = new ltext("??", "??");
        public static ltext sh_MyOrg_Office_Person_Address_Country_ISO_3166_a3 = new ltext("Enter country abbreviation (3 characters)", "Vpišite okrajšavo za državo (3 znaki)");

        public static ltext sl_MyOrg_Office_Person_Address_Country_ISO_3166_num = new ltext("Country code number", "Kodna številka države");
        public static ltext s_MyOrg_Office_Person_Address_Country_ISO_3166_num_v = new ltext("", "");
        public static ltext sh_MyOrg_Office_Person_Address_Country_ISO_3166_num = new ltext("Enter country iso code number", "Vpišite kodno ISO 3166 številko države");

        public static ltext sh_MhyOrg_Person_CardNumber = null;

        public static ltext sl_MyOrg_Person_CardType = null;
        public static ltext s_MyOrg_Person_CardType_v = null;
        public static ltext sh_MyOrg_Person_CardType = null;

        public static ltext sl_MyOrg_Person_Image_Hash = null;
        public static ltext s_MyOrg_Person_Image_Hash_v = null;
        public static ltext sh_MhyOrg_Person_Image_Hash = null;

        public static ltext sl_MyOrg_Person_Image_Data = null;
        public static ltext s_MyOrg_Person_Image_Data_v = null;
        public static ltext sh_MyOrg_Person_Image_Data = null;

        public static ltext sl_MyOrg_Person_Atom_Person_ID = null;
        public static ltext s_MyOrg_Person_Atom_Person_ID_v = null;
        public static ltext sh_MyOrg_Person_Atom_Person_ID = null;

        public static ltext PriceList_Name = new ltext("PRICE LIST CUSTOMERS", "CENIK STRANKE");
        public static ltext PriceList_Description = new ltext("Price list for usual customers.", "Cenik za stalne stranke.");
        public static ltext ShopB_Item_Name_Item1 = new ltext("ShopBItem1","ProtajalnaBArtikel1");
        public static ltext ShopB_Item_Abbreviation_SB1 = new ltext("SB1", "SB1");
        public static ltext ShopB_Item_ParentGroup1 = new ltext("ShopBGroup1","ProdajalnaBSkupina1" );
        public static ltext ShopC_Item_UniquName_UniqueItemName1 = new ltext("UniqueItemName1", "UnikatnoImeArtikla1");
        public static ltext ShopC_Item_Name_ItemName1 = new ltext("ItemName1", "ImeArtikla1");
        public static ltext ShopC_Item_ParentGroup1 = new ltext("ShopCGroup1", "ProdajalnaCSkupina1");
    }
}
     
