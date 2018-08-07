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
using LanguageControl;

namespace LoginControl
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_Person_with_UserName = new ltext(new string[] { "Person with UserName:", "Oseba z uporabniškim imenom:" });
        public static ltext s_IsFromOffice = new ltext(new string[] { " is from office ", " je iz poslovne enote " });
        public static ltext s_andThisElectronicDeviceWithName = new ltext(new string[] { " and this Electronic device with name:", " in ta elektronska naprava z imenom:" });

        public static ltext s_LoginToElectronicDeviceFromAnotherOffice = new ltext(new string[] { "Login to Electronic device from person from another office!", "Prijava na elektronsko napravo s strani osebe, ki pripada drugi poslovni enoti!" });
        public static ltext s_chk_ShowAdministrators = new ltext(new string[] { "Show Administrators", "Prikaži skrbnike" });

        public static ltext s_lbl_Instruction = new ltext(new string[] { "Program didn't closed properly.May be it was a power failure? .\r\nSome work periods are not closed. Press teh button  Close opened work periods.",
                                            "Program se v prejšnem zagonu ni normalno končal. Lahko je prišlo do izpada elektrike in podobno.\r\nOstali so nezaključeni šihti. Pritisnite na gumb Zaprite oprte šihte." });

        public static ltext s_Close_WorkingPeriods = new ltext(new string[] { "Close opened work periods", "Zaprite oprte šihte" });

        public static ltext s_WorkPeriod = new ltext(new string[] { "Work Period", "Šiht" });


        public static ltext s_chk_LogoutAll = new ltext(new string[] { "Logout all users", "Odjavi vse uporabnike" });
        
        public static ltext s_ThisOrgansiationPersonHasNoPIN_please_define_PIN = new ltext(new string[] {
            "There is no PIN for this user.\r\nYour administrator must define PIN number for this user!", "Uporabnik nima dodaljene PIN številke.\r\nSkrbnik tega programa mora vpisati PIN številko za to osebo vaše organizacije." });

        public static ltext s_WrongPIN = new ltext(new string[] { "Wrong PIN", "Napačen PIN" });

        public static ltext s_btn_GetAccess = new ltext(new string[] { "Casshier", "Prevzemi blagajno" });

        public static ltext s_YouCanNotExitProgramUntilAllUsersAreLoggedOut = new ltext(new string[] { "You can not end program until all users are logged out", "Program lahko končate šele, ko so vsi uporabniki odjavljeni!" });

        public static ltext s_New_Password = new ltext(new string[] { "New password:", "Novo geslo:" });

        public static ltext s_ComputerName = new ltext(new string[] { "Computer:", "Računalnik:" });

        public static ltext s_ComputerUserName = new ltext(new string[] { "UserName for computer login:", "Uporabniško ime za prijavo v računalnik." });

        public static ltext s_IP_Address = new ltext(new string[] { "Local computer IP address", "Lokalni IP naslov računalnika" });

        public static ltext s_MAC_address = new ltext(new string[] { "Local computer MAC address", "Lokalni MAC naslov računalnika" });

        
        public static ltext s_Max_Password_Age = new ltext(new string[] {"Number of days:",
                                                                         "Število dni:" });
        public static ltext s_UserThatChangesPassword = new ltext(new string[] { "UserName:", "Uporabnik:" });

        public static ltext s_Password = new ltext(new string[] { "Password	", " Geslo" });

        public static ltext s_Clear = new ltext(new string[] { "Clear", "Zbriši" });

        public static ltext s_PIN = new ltext(new string[] { "PIN", "PIN" });

        public static ltext s_Confirm_New_Password = new ltext(new string[] { "Confirm new password:", "Ponovite novo geslo:" });

        public static ltext s_YouCanNotSetMinumumPasswordLengthLessThan5 = new ltext(new string[]{"You can not set property minimum password length less than 5!",
                                                                                      "Najmanjša možna nastavitev dolžine gesla je 5 znakov!"});

        public static ltext s_ActiveUsers = new ltext(new string[]{"Active users:", "Prijavljeni uporabniki:"});

        public static ltext s_LoginHistoryForUser = new ltext(new string[]{"Login History for user:", "Zgodovina prijav za uporabnika:"});

        public static ltext s_TotalWorkTime = new ltext(new string[] { "Total work time:", "Skupni  čas dela:" });
        

        public static ltext s_Login = new ltext(new string[]{"Login", " Prijava"});

        public static ltext s_OK = new ltext(new string[]{"OK", " Potrdi"});

        public static ltext s_Cancel = new ltext(new string[]{"Cancel", "Prekliči"});

        public static ltext s_UserName = new ltext(new string[]{"User Name",
                                                    "Uporabniško Ime"});

        public static ltext s_ImportNewEmpleyees = new ltext(new string[]{"Selected empleyees to user account",
                                                    "Izberite zaposlene za uporabniški račun tega programa"});

        public static ltext s_btn_Select = new ltext(new string[] { "Select Person:", "Izberite osebo:" });
        
        public static ltext s_LoginConnection = new ltext(new string[]{"Login connection:", "Prijavna povezava:"});

        public static ltext s_Password_does_not_match = new ltext(new string[]{"Password does not match!",
                                                                   "Gesli se ne ujemata"});

        public static ltext s_CreateLoginTablesQuestion = new ltext(new string[]{"Users and Roles tables are missing.\r\nCreate Users and Roles tables?", "Manjkajo tabele \"Users\" and \"Roles\".\r\n Ustvarim tabele potrebne za prijavo?"});

        public static ltext s_Duration = new ltext(new string[] { "Duration", "Trajanje" });
        
        public static ltext s_LoginTime = new ltext(new string[]{"Login Time", "Čas prijave"});
        public static ltext s_LogoutTime = new ltext(new string[]{"Logout Time", "Čas odjave"});

        public static ltext s_Logout = new ltext(new string[] { "Logout", "Odjava" });

        public static ltext s_LoginHistoryAndActiveUsers = new ltext(new string[]{"Show Active Users and Login History", "Prikaži aktivne uporabnike in zgodovino prijav"});

        public static ltext s_ElectronicDevice_ID = new ltext(new string[] { "Casshier Name", "Ime elektronske blagajne" });
        public static ltext s_OfficeName = new ltext(new string[] { "Office Name", "Ime poslovne enote" });
        public static ltext s_OfficeNameShort = new ltext(new string[] { "Short Office Name", "Ime poslovne enote okrajšano" });


        public static ltext s_UserInfo = new ltext(new string[]{"User Info", "Informacija o uporabniku"});
        public static ltext s_Roles = new ltext(new string[]{"Roles:", "Vloge:"});

        public static ltext s_PasswordExpiresAfter = new ltext(new string[]{"Days after password expires:", "Število dni do poteka veljavnosti gesla:"});
        public static ltext s_lbl_UserRoles = new ltext(new string[]{"User Rights", "Uporabnikove pravice"});
        public static ltext s_lbl_OtherRoles = new ltext(new string[] { "Other Rights:", "Ostale pravice" });

        public static ltext s_LoginSuperAdministrator = new ltext(new string[]{"Enter password for SUPER-ADMINISTRATOR!\r\n SUPER-ADMINISTRATOR password expires in very short period of time. \r\n You can get this password by calling:\r\n Srečko Virant  (+386 41 771 339)\r\n or \r\nDamjan Štrucl (+386 41 707 369)", "Vnesite geslo za SUPER-ADMINISTRATOR!\r\nSUPER-ADMINISTRATOR geslo poteče prej kot v enem dnevu.\r\nZa SUPER-ADMINISTRATOR-sko geslo pokličite:\r\n +386 41 771 339 (g. Srečo Virant )\r\n ali\r\n +386 41 707 369 (g. Damjan Štrucl)"});

        public static ltext s_AdministratorRequestForNewPassword = new ltext(new string[]{"Adminstrator requests that you set your own secret password on first login!\r\nSet your password!",
                                                                             "Administrator zahteva, da določite lastno geslo ob prvi prijavi!\r\nDoločite lastno geslo!"});

        public static ltext s_YourUsernameHasExpired = new ltext(new string[]{"Your user-name has expired!",
                                                                 "Vaše uporabniško ime je poteklo!"});

        public static ltext s_YourUsernameIsDisabled = new ltext(new string[]{"User-name you've already written  is not activated!",
                                                                 "Uporabniško ime ni omogočeno!"});

        public static ltext s_Title_UserManager = new ltext(new string[]{"User Manager for:",
                                                            "Urejanje uporabnikov za:"});

        public static ltext s_lblUserName_UserManager = new ltext(new string[]{"User Name:",
                                                               "Uporabniško Ime:"});

        public static ltext s_lblPassword = new ltext(new string[]{"Password:",
                                                               "Geslo:"});

        public static ltext s_lblConfirmPassword_UserManager = new ltext(new string[]{"Confirm Password:",
                                                                      "Potrdi geslo:"});
        
        public static ltext s_btn_AddExistingUser = new ltext(new string[]{"Add Existing User",
                                                             "Dodaj že obstoječega uporabnika"});

        public static ltext s_btnAddUser_UserManager = new ltext(new string[]{"Add User:",
                                                             "Dodaj uporabnika:"});

        public static ltext s_btn_DeleteUser = new ltext(new string[]{"Delete",
                                                         "Zbriši"});

        public static ltext s_btnChangeData_UserManager = new ltext(new string[]{"Change",
                                                                    "Spremeni"});

        public static ltext s_sLoginEnterUserNameAndPasswordWithRights = new ltext(new string[]{"Please enter user name and password with rights for ",
                                                                         "Prosim vnesite uporabniško ime in geslo s pravicami "});

        public static ltext s_sLoginEnterUserNameAndPassword = new ltext(new string[]{"Please enter user name and password",
                                                                         "Prosim vnesite uporabniško ime in geslo"});

        public static ltext s_btnOK_UserManager = new ltext(new string[]{"OK",
                                                         "OK"});

        public static ltext s_btnCancel_UserManager = new ltext(new string[]{"Cancel",
                                                         "Prekini"});

        public static ltext s_LoginControl_Init_Error = new ltext(new string[]{"Error LoginControl Init: ",
                                                            "Napaka pri inicializaciji kontrole \"LoginControl\" v funkciji Init:"});

        public static ltext s_PasswordExpiredSetNewPassword = new ltext(new string[]{"Passwored expired!\r\nSet new password!",
            "Veljavnost gesla je potekla!\r\nDoločite novo geslo!"});

        public static ltext s_FristLognSetNewPassword = new ltext(new string[]{"!\r\nSet new password for user:",
                                                                "Veljavnost gesla je potekla!\r\nDoločite novo geslo za uporabnika:"});

        public static ltext s_rdb_AfterNumberOfDays = new ltext(new string[]{"After Number of Days",
                                                                "Po številu dni"});

        public static ltext s_rdb_DeactivateAfterNumberOfDays = new ltext(new string[]{"Not active after expires",
                                                                          "Ni veljavno po poteku"});
        public static ltext s_PasswordExpires = new ltext(new string[]{"Password expires :",
                                                          "Geslo preneha veljati :"});

        public static ltext s_RolesDataTableIsChanged_Question_SAVE = new ltext(new string[]{"Roles data table is changed!\r\nSave changes ?",
                                                                                "Tabela vlog je spremenjena!\r\nShranim spremembe ?"});

        public static ltext s_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers = new ltext(new string[]{
                            "You must define password which has at least ",
                            "Geslo morate določiti tako, da njegovo število znakov ne bo manjše od "});

        public static ltext s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers2 = new ltext(new string[]{
                            " !",
                            " !"});

        public static ltext s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers1 = new ltext(new string[]{
                            "Password is not defined!\r\n Password length must be at least ",
                            "Geslo ni določeno!\r\nGeslo morate določiti tako, da njegovo število znakov ne bo manjše od "});

        public static ltext sUserDataAreChanged = new ltext(new string[]{"User data are changed OK.", "Uporabniški podatki so spremenjeni."});

        public static ltext s_DataBaseFileCreationTime = new ltext(new string[]{"Database file creation time:", "Podatkovna baza čas ustvaritve:"});

        public static ltext s_DataBaseFile = new ltext(new string[]{"Database file:", "Podatkovna baza:"});

        public static ltext s_Administrator = new ltext(new string[]{"Administrator",
                                                "Administrator"});

        public static ltext s_chk_ChangePasswordOnFirstLogIn = new ltext(new string[]{"Change Password On First LogIn",
                                                                         "Spremeni geslo ob prvi prijavi"});

        public static ltext s_chk_PasswordNeverExpires = new ltext(new string[]{"Never",
                                                                   "Nikoli"});

        public static ltext s_UserNameNotFound = new ltext(new string[]{"User name not found.",
                                                            "Uporabniško ime ne obstaja"});

        public static ltext s_Password_Wrong = new ltext(new string[]{"Password wrong!",
                                                         "Geslo ni pravilno!"});

        public static ltext s_ManageUSers = new ltext(new string[]{"Manage Users",
    "Urejanje uporabnikov"});

        public static ltext s_AddUser = new ltext(new string[]{"Add User",
                                                  "Dodaj uporabnika"});

        public static ltext s_UserNameIsNotWritten = new ltext(new string[]{"User name may not be empty!",
                                                               "Uporabniško ime ni vpisano!"});

        public static ltext s_Warning = new ltext(new string[]{"Warning",
                                            "Opozorilo"});

        public static ltext s_NewUser = new ltext(new string[]{"New User",
                                                  "Nov uporabnik"});

        public static ltext s_Import = new ltext(new string[]{"Import",
                                            "Uvozi"});


        public static ltext s_btn_Edit_myOrganisation_Person = new ltext(new string[]{"Edit employees",
                                            "Urejanje kadrovske evidence"});

        public static ltext s_STDRoleManagerForm = new ltext(new string[]{"Role Manager",
                                            "Urejanje pravic"});

        public static ltext s_OnComputer = new ltext(new string[]{" on computer ",
                                            " na računalniku "});

        public static ltext s_FirstName = new ltext(new string[]{"First Name",
                                            "Ime"});

        public static ltext s_LastName = new ltext(new string[]{"Last Name",
                                            "Priimenk"});

        public static ltext s_IdentityNumber = new ltext(new string[]{"Identity Number",
                                            "EMŠO"});

        public static ltext s_Contact = new ltext(new string[]{"Contact",
                                            "Kontakt"});

        public static ltext s_btn_ManageRoles = new ltext(new string[]{"Manage roles",
                                            "Urejanje pravic"});

        public static ltext s_Active = new ltext(new string[]{"Active",
                                            "Oseba je aktivna"});

        public static ltext s_UserName_Is_Not_Defined = new ltext(new string[]{"User Name is empty",
                                                                              @"Uporabniško ime je prazno!
                                                                                \r\nVpisati morate uprabniško ime"});

        public static ltext s_UserName_AllreadyExist = new ltext(new string[]{"User Name is allready in use. Write different user name.",
                                                                              @"Uporabniško ime je že v uporabi!
                                                                                \r\nVpisati morate drugačno uprabniško ime."});

        public static ltext s_Tax_ID = new ltext(new string[]{"Tax ID",
                                            "Davčna številka"});
        public static ltext s_Registration_ID = new ltext(new string[]{"Registration ID",
                                            "EMŠO"});
        public static ltext s_DateOfBirth =  new ltext(new string[]{"Date of birth",
                                            "Datum rojstva"});

        public static ltext s_AllEmpleyeesHaveUserAccount = new ltext(new string[]{"All emplyees have user account.\r\nTo add new emplyye press button",
                                                                      "Vsi zaposleni imajo uporabniški račun.\r\nČe želite dodati novega zaposlenega ga morate najprej vnesti v kadrovsko evidenco\r\nkar storite s pritiskom na gumb ->"});

        public static ltext cn_myOrganisation_Person_office_Name = new ltext(new string[] { "Office*", "Poslovna enota*" });
        public static ltext cn_myOrganisation_Person_UserName = new ltext(new string[] { "User Name*", "Uporabniško ime*" });
        public static ltext cn_Enabled = new ltext(new string[] { "Login Enabled", "Prijava Omogočena" });
        public static ltext cn_myOrganisation_Person_Active = new ltext(new string[] { "Active*", "Oseba je aktivna*" });
        public static ltext cn_myOrganisation_Person__per__cfn_FirstName = new ltext(new string[] { "First name*", "Ime*" });
        public static ltext cn_myOrganisation_Person__per__cln_LastName = new ltext(new string[]{ "Last name*", "Priimek*" });
        public static ltext cn_myOrganisation_Person_Job = new ltext(new string[]{"Job", "Delovno mesto" });
        public static ltext cn_myOrganisation_Person__per_Tax_ID = new ltext(new string[]{ "Tax ID*", "Davčna št.*" });
        public static ltext cn_myOrganisation_Person__per_Registration_ID = new ltext(new string[]{"Registration ID", "EMŠO" });
        public static ltext cn_myOrganisation_Person_Description = new ltext(new string[]{"Description", "Opis" });
        public static ltext cn_myOrganisation_Person__per_DateOfBirth = new ltext(new string[]{"Date of birth", "Datum rojstva" });
        public static ltext cn_myOrganisation_Person__per_Gender = new ltext(new string[]{ "Gender*", "Spol*" });
        public static ltext cn_PersonData__cemailper_Email = new ltext(new string[]{"Email", "Email" });
        public static ltext cn_PersonData__cgsmnper_GsmNumber = new ltext(new string[]{"GSM", "GSM" });
        public static ltext cn_PersonData__cphnnper_PhoneNumber = new ltext(new string[]{"TEL", "TEL" });
        public static ltext cn_PersonData__cadrper__cstrnper_StreetName = new ltext(new string[]{"Street name", "Cesta" });
        public static ltext cn_PersonData__cadrper__chounper_HouseNumber = new ltext(new string[]{"House number", "Hišna št." });
        public static ltext cn_PersonData__cadrper__zipper_ZIP = new ltext(new string[]{"ZIP", "Poštna št." });
        public static ltext cn_PersonData__cadrper__ccitper_City = new ltext(new string[]{"City", "Mesto" });
        public static ltext cn_PersonData__cadrper__cstper_Country = new ltext(new string[]{"Country", "Država" });
        public static ltext cn_PersonData__cadrper__ccouper_State = new ltext(new string[]{"State", "Dežela" });
        public static ltext cn_PersonData_Description = new ltext(new string[]{"Description2", "Opis2" });
        public static ltext cn_PersonData__cardtper_CardType = new ltext(new string[]{"Card type", "Vrsta kartice" });
        public static ltext cn_PersonData_CardNumber = new ltext(new string[]{"Card number", "Številka kartice" });
        public static ltext cn_myOrganisation_Person__office_ShortName = new ltext(new string[]{"Office short name", "Poslovna enota okrajšava" });
        public static ltext cn_Selected = new ltext(new string[] { "Selected", "Izbrano" });
        public static ltext cn_Administrator = new ltext(new string[] { "Administrator", "Skrbnik" });
        public static ltext s_ImportUsersWithAtLeastOneAadministratorRights = new ltext(new string[] { "Select persons from may oragnisation to Login list.\r\nAt least one person must have Administrator rights checked!", "Izberite osebe iz vaše organizacije, ki se bodo lahko prijavile v program.\r\nNajmanj eni osebi morate označiti, da ima skrbniške pravice." });

        public static ltext s_YouMustSelectAtLeastOnePersonWithAdministratorChecked = new ltext(new string[] {"You must select at least one person from your organisation as Administrator", "Izbrati morate najmanj eno osebo iz vaše organizacije, ki ima odkljukano da je skrbnik" });

        public static ltext cn_Role_Administrator= new ltext(new string[] { "Administrator", "Skrbništvo" });
        public static ltext cn_Role_UserManagement = new ltext(new string[] { "User management", "Upravljanje kadrov " });
        public static ltext cn_Role_WriteInvoice = new ltext(new string[] { "Write Invoice", "Izdajanje računov" });
        public static ltext cn_Role_WriteProformaInvoice = new ltext(new string[] { "Write Proforma-Invoice", "Izdajanje predračunov" });
        public static ltext cn_Role_StockTakeManagemenent = new ltext(new string[] { "Stock take management", "Prevzem blaga" });
        public static ltext cn_Role_PriceListManagement = new ltext(new string[] { "Price list management", "Urejenje cenikov" });
        public static ltext cn_Role_ViewAndExport = new ltext(new string[] { "View and Export", "Vpogled in izvoz" });
        public static ltext cn_Role_WorkInShopA = new ltext(new string[] { "Work in Shop A", "Delo v prodajalni A" });
        public static ltext cn_Role_WorkInShopB = new ltext(new string[] { "Work in Shop B", "Delo v prodajalni B" });
        public static ltext cn_Role_WorkInShopC = new ltext(new string[] { "Work in Shop C", "Delo v prodajalni C" });

        public static ltext s_UserHasNoAccessRights = new ltext(new string[] { "There are no access rights for user : ","Nimate nobenih uporabniških pravic.Uporabik:" });
        public static ltext s_AskAdministratorToSetupYourUserAccessRights = new ltext(new string[] { "Please ask the Administrator to setup your user access rights.", "Pokličite skrbnika da vam dodeli uporabniške dostopne pravice" });
        public static ltext s_YouHaveChangedYourPassord = new ltext(new string[] { "You have changed your password.", "Spremenili ste vaše geslo." });

        public static ltext s_ChangePassord = new ltext(new string[] { "Change password", "Spremeni geslo" });

        public static ltext s_LoginHistory = new ltext(new string[] { "Login History", "Zgodovina prijav" });
    }
}
