using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageControl;

namespace TangentaSampleDB
{
    public static class lng_SampleData
    {
        public static ltext sl_MyOrg_Name = new ltext("Organisation name", "Ime organizacije");
        public static ltext s_MyOrg_Name_v = new ltext("OrganisationX", "PodjetjeX");
        public static ltext sh_MyOrg_Name = new ltext("Enter your organisation name", "Vpišite ime vaše organizacije");

        public static ltext sl_MyOrg_Tax_ID = new ltext("Organisation VAT number", "Davčna številka");
        public static ltext s_MyOrg_Tax_ID_v = new ltext("12345678", "12345678");
        public static ltext sh_MyOrg_Tax_ID = new ltext("Enter your organisation VAT number", "Vpišite davčno številko");

        public static ltext sl_MyOrg_Registration_ID = new ltext("Your Organisation Registration Number", "Matična številka vaše organizacije");
        public static ltext s_MyOrg_Registration_ID_v = new ltext("00000001", "00000001");
        public static ltext sh_MyOrg_Registration_ID = new ltext("Enter Your Organisation Registration Number", "Vpišite matično številko vaše organizacije");

        public static ltext sl_MyOrg_TaxPayer = new ltext("Tax Payer", "Davčni zavezanec");
        public static ltext s_MyOrg_TaxPayer_v = new ltext("00000001", "00000001");
        public static ltext sh_MyOrg_TaxPayer = new ltext("Check if your organisation is tax-payer", "Odkljukajte če je vaša organizacija davčni zavezanec");

        public static ltext sl_MyOrg_Comment1 = new ltext("Comment 1", "Komentar 1");
        public static ltext s_MyOrg_Comment1_v = new ltext("VAT payer", "Davčni zavezanec za DDV");
        public static ltext sh_MyOrg_Comment1 = new ltext("Write comment 1 about your organisation", "Vpišite komentar 1 o vaši organizaciji (primer:Davčni zavezanec za DDV)");

        public static ltext sl_MyOrg_Comment2 = new ltext("Comment 2", "Komentar 2");
        public static ltext s_MyOrg_Comment2_v = null;
        public static ltext sh_MyOrg_Comment2 = new ltext("Write comment 2 about your organisation", "Vpišite komentar 2 o vaši organizaciji");

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
        public static ltext s_MyOrg_Email_v = new ltext("OrganisationX@email.com", "PodjetjeX@email.com");
        public static ltext sh_MyOrg_Email = new ltext("Enter your organisation email", "Vpišite elektronski naslov (email) vaše organizacije");

        public static ltext sl_MyOrg_HomePage = new ltext("Organisation homepage", "Domači naslov vaše organizacije");
        public static ltext s_MyOrg_HomePage_v = new ltext("www.OrganisationX.com", "www.PodjetjeX.si");
        public static ltext sh_MyOrg_HomePage = new ltext("Enter your organisation homepage", "Vpišite domači naslov (homepage) vaše organizacije");

        public static ltext sl_MyOrg_Bank_Name = new ltext("The name of bank of your organisation bank account", "Ime banke vašega TRR računa vaše organizacije");
        public static ltext s_MyOrg_Bank_Name_v = new ltext("XBank", "XBanka");
        public static ltext sh_MyOrg_Bank_Name = new ltext("Enter the name of bank of your organisation bank account", "Vpišite ime banke vašega TRR računa vaše organizacije");

        public static ltext sl_MyOrg_Bank_Tax_ID = new ltext("Bank VAT number", "Davčna številka banke");
        public static ltext s_MyOrg_Bank_Tax_ID_v = new ltext("23456789", "23456789");
        public static ltext sh_MyOrg_Bank_Tax_ID = new ltext("Enter your bank VAT number", "Vpišite davčno številko vaše banke");

        public static ltext sl_MyOrg_Bank_Registration_ID = new ltext("Your bank Registration Number", "Matična številka vaše banke");
        public static ltext s_MyOrg_Bank_Registration_ID_v = new ltext("00000003", "00000003");
        public static ltext sh_MyOrg_Bank_Registration_ID = new ltext("Enter Your Organisation Registration Number", "Vpišite matično številko vaše organizacije");

        public static ltext sl_MyOrg_Bank_OrganisationTYPE = new ltext("Type of bank", "Tip banke");
        public static ltext s_MyOrg_Bank_OrganisationTYPE_v = new ltext("ltd", "d.o.o.");
        public static ltext sh_MyOrg_Bank_OrganisationTYPE = new ltext("Enter type of your bank (ltd., gov.,)", "Vpišite tip vaše banke (d.d.,d.o.o.,javni zavod,..)");



        public static ltext sl_MyOrg_TRR = new ltext("Bank account", "Številka TRR računa vaše organizacije");
        public static ltext s_MyOrg_TRR_v = new ltext("0000-0000-000-000", "0000-0000-000-000");
        public static ltext sh_MyOrg_TRR = new ltext("Enter bank account", "Vpišite številko TRR računa vaše organizacije");

        public static ltext sl_MyOrg_TRR_Description = new ltext("Bank account desc.", "Opis TRR računa");
        public static ltext s_MyOrg_TRR_Description_v = new ltext("Casshier bank Account", "Račun za prihodke od blagajne");
        public static ltext sh_MyOrg_TRR_Description = new ltext("Enter bank Casshier account description", "Vpišite opis namena TRR računa vaše organizacije");

        public static ltext sl_MyOrg_TRR_Active = new ltext("Bank account Active", "TRR račun je aktiven");
        public static ltext s_MyOrg_TRR_Active_v = null;
        public static ltext sh_MyOrg_TRR_Active = new ltext("Check if bank account is Active", "Označite s kljukico, da je bančni račun aktiven");

        public static ltext sl_MyOrg_Logo = new ltext("Logo", "Logotip");
        public static ltext s_MyOrg_Logo_v = null;
        public static ltext sh_MyOrg_Logo = new ltext("Select Logo Image", "Izberite Logotip");


        public static ltext sl_MyOrg_Address_StreetName = new ltext("Street", "Cesta");
        public static ltext s_MyOrg_Address_StreetName_v = new ltext("XStreet", "CestaX");
        public static ltext sh_MyOrg_Address_StreetName = new ltext("Enter street name", "Vpišite ime ceste");

        public static ltext sl_MyOrg_Address_HouseNumber = new ltext("House number", "Hišna številka");
        public static ltext s_MyOrg_Address_HouseNumber_v = new ltext("1", "1");
        public static ltext sh_MyOrg_Address_HouseNumber = new ltext("Enter house number", "Vpišite hišno številko");

        public static ltext sl_MyOrg_Address_ZIP = new ltext("ZIP", "Številka pošte");
        public static ltext s_MyOrg_Address_ZIP_v = new ltext("1111", "1111");
        public static ltext sh_MyOrg_Address_ZIP = new ltext("Enter ZIP", "Vpišite številko pošte");

        public static ltext sl_MyOrg_Address_City = new ltext("City", "Mesto");
        public static ltext s_MyOrg_Address_City_v = new ltext("CityX", "MestoX");
        public static ltext sh_MyOrg_Address_City = new ltext("Enter city", "Vpišite mesto");

        public static ltext sl_MyOrg_Address_State = new ltext("State", "Dežela");
        public static ltext s_MyOrg_Address_State_v = new ltext("", "");
        public static ltext sh_MyOrg_Address_State = new ltext("Enter State", "Vpišite deželo");


        public static ltext sl_MyOrg_Address_Country = new ltext("Country", "Država");
        public static ltext s_MyOrg_Address_Country_v = null;// new ltext("Country1", "Država1");
        public static ltext sh_MyOrg_Address_Country = new ltext("Enter country", "Vpišite državo");

        public static ltext sl_MyOrg_Address_Country_ISO_3166_a2 = new ltext("Country abbreviation (2 characters)", "Okrajšavo za državo (2 znaka)");
        public static ltext s_MyOrg_Address_Country_ISO_3166_a2_v = null;// new ltext("??", "??");
        public static ltext sh_MyOrg_Address_Country_ISO_3166_a2 = new ltext("Enter country abbreviation (2 characters)", "Vpišite okrajšavo za državo (2 znaka)");

        public static ltext sl_MyOrg_Address_Country_ISO_3166_a3 = new ltext("Country abbreviation (3 characters)", "Okrajšavo za državo (3 znaki)");
        public static ltext s_MyOrg_Address_Country_ISO_3166_a3_v = null;// new ltext("??", "??");
        public static ltext sh_MyOrg_Address_Country_ISO_3166_a3 = new ltext("Enter country abbreviation (3 characters)", "Vpišite okrajšavo za državo (3 znaki)");

        public static ltext sl_MyOrg_Address_Country_ISO_3166_num = new ltext("Country code number", "Kodna številka države");
        public static ltext s_MyOrg_Address_Country_ISO_3166_num_v = null;// new ltext("", "");
        public static ltext sh_MyOrg_Address_Country_ISO_3166_num = new ltext("Enter country iso code number", "Vpišite kodno ISO 3166 številko države");


        public static ltext sl_MyOrg_Office_Address_StreetName = new ltext("Street", "Cesta");
        public static ltext s_MyOrg_Office_Address_StreetName_v = new ltext("StreetX", "CestaX");
        public static ltext sh_MyOrg_Office_Address_StreetName = new ltext("Enter street name", "Vpišite ime ceste");

        public static ltext sl_MyOrg_Office_Address_HouseNumber = new ltext("House number", "Hišna številka");
        public static ltext s_MyOrg_Office_Address_HouseNumber_v = new ltext("1", "1");
        public static ltext sh_MyOrg_Office_Address_HouseNumber = new ltext("Enter house number", "Vpišite hišno številko");

        public static ltext sl_MyOrg_Office_Address_ZIP = new ltext("ZIP", "Številka pošte");
        public static ltext s_MyOrg_Office_Address_ZIP_v = new ltext("1111", "1111");
        public static ltext sh_MyOrg_Office_Address_ZIP = new ltext("Enter ZIP", "Vpišite številko pošte");

        public static ltext sl_MyOrg_Office_Address_City = new ltext("City", "Mesto");
        public static ltext s_MyOrg_Office_Address_City_v = new ltext("CityX", "MestoX");
        public static ltext sh_MyOrg_Office_Address_City = new ltext("Enter city", "Vpišite mesto");

        public static ltext sl_MyOrg_Office_Address_State = new ltext("State", "Dežela");
        public static ltext s_MyOrg_Office_Address_State_v = new ltext("", "");
        public static ltext sh_MyOrg_Office_Address_State = new ltext("Enter State", "Vpišite deželo");


        public static ltext sl_MyOrg_Office_Address_Country = new ltext("Country", "Država");
        public static ltext s_MyOrg_Office_Address_Country_v = null;// new ltext("Country1", "Država1");
        public static ltext sh_MyOrg_Office_Address_Country = new ltext("Enter country", "Vpišite državo");

        public static ltext sl_MyOrg_Office_Address_Country_ISO_3166_a2 = new ltext("Country abbreviation (2 characters)", "Okrajšavo za državo (2 znaka)");
        public static ltext s_MyOrg_Office_Address_Country_ISO_3166_a2_v = null;// new ltext("??", "??");
        public static ltext sh_MyOrg_Office_Address_Country_ISO_3166_a2 = new ltext("Enter country abbreviation (2 characters)", "Vpišite okrajšavo za državo (2 znaka)");

        public static ltext sl_MyOrg_Office_Address_Country_ISO_3166_a3 = new ltext("Country abbreviation (3 characters)", "Okrajšavo za državo (3 znaki)");
        public static ltext s_MyOrg_Office_Address_Country_ISO_3166_a3_v = null;// new ltext("??", "??");
        public static ltext sh_MyOrg_Office_Address_Country_ISO_3166_a3 = new ltext("Enter country abbreviation (3 characters)", "Vpišite okrajšavo za državo (3 znaki)");

        public static ltext sl_MyOrg_Office_Address_Country_ISO_3166_num = new ltext("Country code number", "Kodna številka države");
        public static ltext s_MyOrg_Office_Address_Country_ISO_3166_num_v = null;// new ltext("", "");
        public static ltext sh_MyOrg_Office_Address_Country_ISO_3166_num = new ltext("Enter country iso code number", "Vpišite kodno ISO 3166 številko države");

        public static ltext sl_MyOrg_OfficeName = new ltext("Office name", "Ime poslovne enote");
        public static ltext s_MyOrg_OfficeName_v = new ltext("OfficeX", "PisarnaX");
        public static ltext sh_MyOrg_OfficeName = new ltext("Enter office name", "Vpišite ime poslovne enote");

        public static ltext sl_MyOrg_OfficeShortName = new ltext("Office short name", "Skrajšano ime poslovne enote");
        public static ltext s_MyOrg_OfficeShortName_v = new ltext("OffX", "PisX");
        public static ltext sh_MyOrg_OfficeShortName = new ltext("Enter office short name", "Vpišite skrajšano ime poslovne enote");




        public static ltext sl_MyOrg_Person_FirstName = new ltext("Organisation administrator First Name", "Ime glavnega administratorja v podjetju");
        public static ltext s_MyOrg_Person_FirstName_v = new ltext("Organisation1Person1FirstName", "ImeOsebe1Podjetja1");
        public static ltext sh_MyOrg_Person_FirstName = new ltext("Enter organisation administrator First Name", "Vpišite ime glavnega administratorja, ki bo imel vse uporabniške pravice");

        public static ltext sl_MyOrg_Person_LastName = new ltext("Organisation administrator Last Name", "Priimek glavnega administratorja v podjetju");
        public static ltext s_MyOrg_Person_LastName_v = new ltext("PersonXLastName", "OsebaXPriimek");
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

        public static ltext sl_MyOrg_Person_Password = new ltext("Administrator password", "Skrbniško geslo");
        public static ltext s_MyOrg_Person_Password_v = new ltext("12345", "12345");
        public static ltext sh_MyOrg_Person_Password = new ltext("Enter administrator password", "Vpišite geslo glavnega administratorja");

        public static ltext sl_MyOrg_Person_Job = new ltext("Administrator Job Title", "Delovno mesto glavnega administratorja");
        public static ltext s_MyOrg_Person_Job_v = new ltext("OrganisationXPersonXJob", "DelovnoMestoOsebaXPodjetjeX");
        public static ltext sh_MyOrg_Person_Job = new ltext("Organisation1Person1Job", "DelovnoMestoOsebe1Podjetja1");

        public static ltext sl_MyOrg_Person_Description = new ltext("Administrator description", "Glavni administrator opis");
        public static ltext s_MyOrg_Person_Description_v = new ltext("OrganisationXPersonXDescription", "OsebeXPodjetjeXOpis");
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
        public static ltext s_MyOrg_Person_Email_v = new ltext("PersonX@mail.com", "PersonX@mail.com");
        public static ltext sh_MyOrg_Person_Email = new ltext("Enter Administrator's email", "Vpišite email administratorja");

        public static ltext sl_MyOrg_Office_Person_Address_StreetName = new ltext("Street", "Cesta");
        public static ltext s_MyOrg_Office_Person_Address_StreetName_v = new ltext("MyStreetY", "CestaY");
        public static ltext sh_MyOrg_Office_Person_Address_StreetName = new ltext("Enter street name", "Vpišite ime ceste");

        public static ltext sl_MyOrg_Office_Person_Address_HouseNumber = new ltext("House number", "Hišna številka");
        public static ltext s_MyOrg_Office_Person_Address_HouseNumber_v = new ltext("1", "1");
        public static ltext sh_MyOrg_Office_Person_Address_HouseNumber = new ltext("Enter house number", "Vpišite hišno številko");

        public static ltext sl_MyOrg_Office_Person_Address_ZIP = new ltext("ZIP", "Številka pošte");
        public static ltext s_MyOrg_Office_Person_Address_ZIP_v = new ltext("2222", "2222");
        public static ltext sh_MyOrg_Office_Person_Address_ZIP = new ltext("Enter ZIP", "Vpišite številko pošte");

        public static ltext sl_MyOrg_Office_Person_Address_City = new ltext("City", "Mesto");
        public static ltext s_MyOrg_Office_Person_Address_City_v = new ltext("CityX", "MestoX");
        public static ltext sh_MyOrg_Office_Person_Address_City = new ltext("Enter city", "Vpišite mesto");

        public static ltext sl_MyOrg_Office_Person_Address_State = new ltext("State", "Dežela");
        public static ltext s_MyOrg_Office_Person_Address_State_v = new ltext("", "");
        public static ltext sh_MyOrg_Office_Person_Address_State = new ltext("Enter State", "Vpišite deželo");


        public static ltext sl_MyOrg_Office_Person_Address_Country = new ltext("Country", "Država");
        public static ltext s_MyOrg_Office_Person_Address_Country_v = null;// new ltext("Country1", "Država1");
        public static ltext sh_MyOrg_Office_Person_Address_Country = new ltext("Enter country", "Vpišite državo");

        public static ltext sl_MyOrg_Office_Person_Address_Country_ISO_3166_a2 = new ltext("Country abbreviation (2 characters)", "Okrajšavo za državo (2 znaka)");
        public static ltext s_MyOrg_Office_Person_Address_Country_ISO_3166_a2_v = null;// new ltext("??", "??");
        public static ltext sh_MyOrg_Office_Person_Address_Country_ISO_3166_a2 = new ltext("Enter country abbreviation (2 characters)", "Vpišite okrajšavo za državo (2 znaka)");

        public static ltext sl_MyOrg_Office_Person_Address_Country_ISO_3166_a3 = new ltext("Country abbreviation (3 characters)", "Okrajšavo za državo (3 znaki)");
        public static ltext s_MyOrg_Office_Person_Address_Country_ISO_3166_a3_v = null;// new ltext("??", "??");
        public static ltext sh_MyOrg_Office_Person_Address_Country_ISO_3166_a3 = new ltext("Enter country abbreviation (3 characters)", "Vpišite okrajšavo za državo (3 znaki)");

        public static ltext sl_MyOrg_Office_Person_Address_Country_ISO_3166_num = new ltext("Country code number", "Kodna številka države");
        public static ltext s_MyOrg_Office_Person_Address_Country_ISO_3166_num_v = null;// new ltext("", "");
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


    }
}
