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
        public static ltext s_New_Password = new ltext(new string[] { "New password:", "Novo geslo:" });

        public static ltext s_ComputerName = new ltext(new string[] { "Computer:", "Računalnik:" });

        public static ltext s_Max_Password_Age = new ltext(new string[] {"Number of days:",
                                                                         "Število dni:" });
        public static ltext s_UserThatChangesPassword = new ltext(new string[] { "UserName:", "Uporabnik:" });

        public static ltext s_Password = new ltext(new string[] { "Password	", " Geslo" });

        public static ltext s_Confirm_New_Password = new ltext(new string[] { "Confirm new password:", "Ponovite novo geslo:" });

        public static ltext s_YouCanNotSetMinumumPasswordLengthLessThan3 = new ltext(new string[]{"You can not set property minimum password length less than 3!",
                                                                                      "Najmanjša možna nastavitev dolžine gesla je 3 znake!"});

        public static ltext s_ActiveUsers = new ltext(new string[]{"Active users:", "Prijavljeni uporabniki:"});

        public static ltext s_LoginHistoryForUser = new ltext(new string[]{"Login History for user:", "Zgodovina prijav za uporabnika:"});


        public static ltext s_Login = new ltext(new string[]{"Log-in", " Prijava"});

        public static ltext s_OK = new ltext(new string[]{"OK", " Potrdi"});

        public static ltext s_Cancel = new ltext(new string[]{"Cancel", "Prekliči"});

        public static ltext s_UserName = new ltext(new string[]{"User Name",
                                                    "Uporabniško Ime"});

        public static ltext s_LoginConnection = new ltext(new string[]{"Login connection:", "Prijavna povezava:"});

        public static ltext s_Password_does_not_match = new ltext(new string[]{"Password does not match!",
                                                                   "Gesli se ne ujemata"});

        public static ltext s_CreateLoginTablesQuestion = new ltext(new string[]{"Users and Roles tables are missing.\r\nCreate Users and Roles tables?", "Manjkajo tabele \"Users\" and \"Roles\".\r\n Ustvarim tabele potrebne za prijavo?"});

        public static ltext s_FirstName = new ltext(new string[]{"First Name",
                                             "Ime"});

        public static ltext s_LastName = new ltext(new string[]{"Last Name",
                                             "Priimek"});

        public static ltext s_IdentityNumber = new ltext(new string[]{"Identity",
                                                 "Identiteta"});


        public static ltext s_Contact = new ltext(new string[]{"Contact",
                                                "Kontakt"});

        public static ltext s_LoginTime = new ltext(new string[]{"Login Time", "Čas prijave"});
        public static ltext s_LogoutTime = new ltext(new string[]{"Logout Time", "Čas odjave"});
        public static ltext s_LoginHistoryAndActiveUsers = new ltext(new string[]{"Show Active Users and Login History", "Prikaži aktivne uporabnike in zgodovino prijav"});

        public static ltext s_UserInfo = new ltext(new string[]{"User Info", "Informacija o uporabniku"});
        public static ltext s_Roles = new ltext(new string[]{"Roles:", "Vloge:"});

        public static ltext s_PasswordExpiresAfter = new ltext(new string[]{"Days after password expires:", "Število dni do poteka veljavnosti gesla:"});
        public static ltext s_RoleManagerForm = new ltext(new string[]{"Manage Roles", "Urejanje Vlog"});
        public static ltext s_btn_ManageRoles = new ltext(new string[]{"Manage Roles", "Urejanje Vlog"});
        public static ltext s_lbl_ManageRoles = new ltext(new string[]{"Roles:", "Vloge:"});

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

        public static ltext s_lblPassword_UserManager = new ltext(new string[]{"Password:",
                                                               "Geslo:"});

        public static ltext s_lblConfirmPassword_UserManager = new ltext(new string[]{"Confirm Password:",
                                                                      "Potrdi geslo:"});

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

        public static ltext s_OnComputer = new ltext(new string[]{"on computer",
                                                         "na računalniku"});

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

        public static ltext s_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers3 = new ltext(new string[]{
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
        public static ltext s_Active = new ltext(new string[]{"Active",
                                                 "Aktivno"});

        public static ltext s_AddUser = new ltext(new string[]{"Add User",
                                                  "Dodaj uporabnika"});

        public static ltext s_UserNameIsNotWritten = new ltext(new string[]{"User name may not be empty!",
                                                               "Uporabniško ime ni vpisano!"});

        public static ltext s_Warning = new ltext(new string[]{"Warning",
                                            "Opozorilo"});

        public static ltext s_NewUser = new ltext(new string[]{"New User",
                                                  "Nov uporabnik"});

    }
}
