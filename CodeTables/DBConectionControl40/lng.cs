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

namespace DBConnectionControl40
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_Password = new ltext( new string[]{"Password",
                                         "Geslo"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_Browse__ = new ltext(new string[]{"Browse..",
                                         "Poišći.."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_Server = new ltext(new string[]{"Server",
                                           "Strežnik"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_CanNotMakeServerOnlyConnection = new ltext(new string[]{"Can not connect to server! \nChange connection data or press Cancel!",
                                                                         "Povezava z strežnikom ni uspešna ! Spremenite podatke za povezavo ali pritisnite na gumb prekini"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_DataBase = new ltext(new string[]{"Database",
                                             "Podatkovna baza"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs


        public static ltext s_Warning = new ltext(new string[]{"Warning",
                                            "Opozorilo"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_ConnectWithDatabase = new ltext(new string[]{"Connect with database",
                                                        "Poveži se z bazo podatkov"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_Enter_UsernName_and_Password_then_press_button = new ltext(new string[]{"Enter UsernName and Password, then press button \"Connect with database\".",
                                                                                           "Vnesite uporabniško ime in geslo. Nato pritisnite gumb poveži se z bazo podatkov."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_Try_Width_Different_Windows_Log_on_Or_Select_SQL_Authenticatio_UserName_AndPassword = new ltext(new string[]{"Log-off and then try to connect width another \"Windows-Log-On\",\n or Select_SQL Authentication with UserName and Password.",
                                                                                                                              "Prijavite se v Okna z drugim uporabniškim imenom,\n ali pa izberite SQL Strežniško prijavo z uporabniškim imenom in geslom."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_Connection_with_database_was_not_done_yet = new ltext(new string[]{"Connection with database was not done yet. It is the first time connection. Enter server name or IP address, database name,user name and password. After that press button \"Connect with database\".",
                                                                              "Povezava z bazo podatkov še ni bila vzpostavljena. Gre za začetno (prvo) vzpostavitev povezave z bazo. Vnesite ime ali IP naslov strežnika, ime podatkovne baze, uporabniško ime in geslo. Nato pritisnite gumb poveži se z bazo podatkov."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_Connection_with_database_not_succeeded_Try_again = new ltext(new string[]{"Connection with database not succeeded. Try again.",
                                                                                        "Povezava na bazo podatkov ni uspela, poizkusite znova."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_Connecting_with_database_was_not_successful_Enter_UserName_And_Password_Again_Then_Press_Connect_withDatabase = new ltext(new string[]{"Connection process with database was not successful. Enter UserName and Password again. Then press \"Connect with database\".",
                                                                                                                                                         "Povezavanje z bazo podatkov ni bilo uspešno. Ponovno preverite in vpišite ime ali IP naslov strežnika, ime podatkovne baze, uporabniško ime ter geslo. Nato pritisnite gumb \"Poveži se z bazo podatkov.\""});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_Save_database_connection_data = new ltext(new string[]{
            "Save database connection data ?",
            "Shrani podatke za povezavo z bazo podatkov ?"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_Connection_is_OK_Click_on_button_Save_to_save_connection_data___ = new ltext(new string[]{
            "Connection is OK. Click on button Save to save connection data, to avoid entering connection data again next time you start the program.",
            "Povezava z bazo je uspela. S klikom na gumb Shrani shranite podatke za povezavo z bazo podatkov, da vam jih nasldenjič (razen gesla) ne bo potrebno znova vpisovati."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_WindowsAuthentication = new ltext(new string[]{"Windows Autenthication",
                                                   "Windows prijava"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_SQLServerAuthentication = new ltext(new string[]{"SQL Server Autenthication",
                                                   "SQL strežniška prijava"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_Connection_to_Database = new ltext(new string[]{"Connection to DataBase:\"",
                                                          "Prijava na podatkovno bazo:\""});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_NoConnectionToDatabase_You_must_set_Database_connection_to_go_next_step = new ltext(new string[]{"There was no succesfull database connection check!\r\nPlease make succesful database connection check.\r\nYou can not go to next step, until succesfull database connection check.\\To check database connection press button Check database connection",
                                                                                                                  "Ni bilo uspešnega preverjanja povezave na podatkovno bazo!\r\nDa bi lahko pritisnili gumb za naprej mora biti povezava na podatkovno bazo uspešno preverjena. Preverjanje povezave na podatkovno bazo naredite tako da pritisnete na gumb:\"Preveri povezavo na podatkovno bazo\""});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\ConnectionDialog.cs

        public static ltext s_ServerType = new ltext(new string[]{"Server type",
                                           "Tip strežnika"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Connection_Control.cs


        public static ltext s_DataBaseName = new ltext(new string[]{"Database name",
                                             "Podatkovna baza"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateDataBaseDialog.cs

        public static ltext s_EnterDataBaseFileOnServer = new ltext(new string[]{"Enter DataBase file on server computer",
                                                                    "Vpišite ime zapisa (datoteke) podatkovne baze na strežniškem disku"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateDataBaseDialog.cs

        public static ltext s_DataBaseFileNameCanNotBeEmpty = new ltext(new string[]{"DataBase file may not be empty!",
                                                                        "Ime zapisa (datoteke) podatkovne baze ne sme biti prazno!"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateDataBaseDialog.cs

        public static ltext s_EnterDataBaseFileOnServerIfYouKnowDrivesAndFoldersOnServer = new ltext(new string[]{"Enter DataBase file on server computer only if you know drives and folders on server computer",
                                                                                                     "Vpišite ime zapisa (datoteke) podatkovne baze na strežniškem disku samo, če poznate naslove diskov in map na strežniku."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateDataBaseDialog.cs

        public static ltext s_OnLocalComputerDatabaseConstructionFileInstructions = new ltext(new string[]{"Warning! You are working on local computer and not on server computer where you want to create a database. While you are running this program on local WorkingPlaces and not on server computer, this program can not browse and show server's directories. If you know real drives or directories on server computer,you can define database file  in a text box. Are you going to define database file in a text box ?",
                                                                                              "Opozorilo! Ste na lokalnem računalniku in ne na strežniškem računalniku kateremu teče tudi podatkovni strežnik na katerem želite ustvariti novo podatkovno datoteko (bazo). Novo podaptkovno bazo lahko določite v vnosnem polju samo, če poznate pogone in mape na strežniškem računalniku. Želite določiti ime podatkvne baze v vnosnem polju?"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateDataBaseDialog.cs

        public static ltext s_OnServerDatabaseConstructionFileInstructions = new ltext(new string[]{"Warning! The program recognize that you are working on Server Computer. If it is true you can define new database file in directory which is selected by file browse dialog ?",
                                                                                       "Opozorilo! Program je ugotovil, da ste prijavljeni na računalniku na kateren teče tudi podatkovni strežnik na katerem želite ustvariti novo podatkovno bazo. Če je temu res tako potem lahko izberete mapo v kateri bo nova podaptkovna baza z uporabo dialoga za izbiro mape?"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateDataBaseDialog.cs


        public static ltext s_CreateDataBaseDialog_Form_Title = new ltext(new string[]{"Create Database Dialog",
                                                                     "Ustvari podatkovno bazo"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateDataBaseDialog.cs

        public static ltext s_General = new ltext(new string[]{" General ",
                                         " Splošno "});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateDataBaseDialog.cs

        public static ltext s_DatabaseNotDefined = new ltext(new string[]{"DataBase is not defined !",
                                                       "Niste določili podpatkovne baze !"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateMySQLDataBase_Form.cs




        public static ltext s_CreateNewDatabase = new ltext(new string[]{"Create New Database",
                                                      "Ustvari novo podatkovno bazo"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateMySQLDataBase_Form.cs


        public static ltext s_Info = new ltext(new string[]{"Info",
                                        "Opozorilo"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateMySQLDataBase_Form.cs

        public static ltext s_Created = new ltext(new string[]{" is successfully created!",
                                            "je uspešno narejena."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\CreateMySQLDataBase_Form.cs

        public static ltext s_IsNotValid = new ltext(new string[] { "is not valid", " ni veljavno" });   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\SQLiteConnectionDialog.cs

        public static ltext s_FileName = new ltext(new string[] { "File Name", "Ime Datoteke" });   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\SQLiteConnectionDialog.cs

        public static ltext s_Folder = new ltext(new string[] { "Folder", "Mapa (pot do datoteke)" });   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\SQLiteConnectionDialog.cs

        public static ltext s_SelectSQLiteDataBaseFileName = new ltext(new string[]{"Selected DataBase file name:",
                                                                       "Izberite datoteko podatkovne baze"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\SQLiteConnectionDialog.cs

        public static ltext s_Error = new ltext(new string[]{"Error",
                                          "Napaka"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\SQLiteConnectionDialog.cs

        public static ltext s_File_does_not_exist = new ltext(new string[]{"File does not exist:",
                                                       "Datoteka ne obstaja :"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\SQLiteConnectionDialog.cs

        public static ltext s_ConnectionOK = new ltext(new string[]{"Connection is OK!",
                                                 "Povezava je OK!"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_CanNotMakeAConnection = new ltext(new string[]{"Can not make a connection with conection data ! \nChange connection data or press Cancel!",
                                                     "Povezava z navedenimi nastavitvami ni uspešna ! Spremenite podatke za povezavo ali pritisnite na gumb prekini"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs


        public static ltext s_ViewPermissions = new ltext(new string[]{"View permission rights!",
                                                 "Pogled v pravice!"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_Not_EnoughPermissions_To_List_Databases = new ltext(new string[]{"You don't have enough permission to view database list! Try to connect with administrator rights.",
                                                                                  "Nimate dovolj pravic za vpoogled v seznam podatkovnih baz! Na podatkovni strežnik se prijavite z adminsitratorskimi pravicami."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_GetDataBaseList = new ltext(new string[]{"Get DataBases on Server",
                                                    "Seznam podatkovnih baz na strežniku "});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_DataBase_e = new ltext(new string[]{"Database",
                                                     "Podatkovna baze"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_Can_Not_Be_Found_On_server = new ltext(new string[]{" can not be found on server ",
                                                                    " ni na strežniku "});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_Already_exist = new ltext(new string[]{" allready exist! Select anaother name.",
                                                        " že obstaja! Izberite drugo ime."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_UserName = new ltext(new string[]{"UserName",
                                             "Uporabniško Ime"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_Cancel = new ltext(new string[]{"Cancel",
                                          "Prekini"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_LogOnToTheServer = new ltext(new string[]{" Log on to the server ",
                                                     " Prijava na strežnik "});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_ConnectToDatabaseName = new ltext(new string[]{"Connect to Database name",
                                                          "Poveži se na podatkovno bazo"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_GetConnection = new ltext(new string[]{"Get Connection",
                                                   "Vzpostavi povezavo"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_Error_Can_not_get_Databases_on_Server = new ltext(new string[]{"Error Can not get Databases on Server:",
                                                                          "Napaka, ni možno najti podatkovnih baz na strežniku:"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_Execption = new ltext(new string[]{" Execption ",
                                              " \"Execption\" "});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_User_name_is_missing_Enter_User_Name = new ltext(new string[]{"User name is missing. Enter User Name.",
                                                                        "Manjka uporabniško ime. Vpišite uporabniško ime."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_Password_is_missing_Enter_Password = new ltext(new string[]{"Password is missing. Enter Password.",
                                                                          "Manjka geslo. Vpišite geslo."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataBase_Form.cs

        public static ltext s_Select_Server = new ltext(new string[]{"Selected Server",
                                                          "Izbrani strežnik"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataSource_Form.cs

        public static ltext s_Please_wait_while_browsing_local_network_for_database_servers = new ltext(new string[]{"Please wait\nwhile browsing local network for database servers...",
                                                                                                 "Prosimo počakajte\nda se poiščejo podatkovni strežniki v lokalnem omrežju..."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataSource_Form.cs

        public static ltext s_Select_server_and_press_ok = new ltext(new string[]{"Select server and press OK.",
                                                              "Izberite strežnik in pritisnite OK."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataSource_Form.cs

        public static ltext s_Error_browse_DataBase_servers_Error_Exception = new ltext(new string[]{"Error browse DataBase servers. Error_Exception =",
                                                                                   "Napaka pri iskanju podtakovnih strežnikov. \"Exception\" ="});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataSource_Form.cs

        public static ltext s_No_server_selected_Please_select_server = new ltext(new string[]{"No server selected. Please select server.",
                                                                            "Niste izbrali strežnika. Prosimo izberite strežnik."});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\Select_DataSource_Form.cs

        public static ltext s_AreYouSureToDeleteDataBase = new ltext(new string[]{"Are you sure to destroy database ",
                                                           "Ste prepričani, da uničite podatkovno bazo "});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\DBConnection.cs

        public static ltext s_Question = new ltext(new string[]{"Question",
                                         "Vprašanje"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\DBConnection.cs

        public static ltext sTableIsMissing = new ltext(new string[] { "Tabale is missing", " Manjka Tabela" });   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\DBConnection.cs


        public static ltext s_TestConnection = new ltext(new string[]{"Test Connection",
                                                   "Preizkusi povezavo"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\DBConnection.cs

        public static ltext s_Ok = new ltext(new string[]{"Ok",
                                             "V redu"});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\TextBoxDialog_Form.cs

        public static ltext s_with_Windows_authentication_is_OK = new ltext(new string[]{" with Windows authentication is OK !\n\nPermissions for the Windows user ",
                                                          " s prijavo Windows uporabniškega0 imena je uspela!\n\nDovoljenja uporabnika "});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\View_AccessRights_Form.cs

        public static ltext s_with_SQL_authentication_is_OK = new ltext(new string[]{"is OK !\n\nPermissions for the user ",
                                                                       "je uspela !\n\nDovoljenja uporabnika "});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\View_AccessRights_Form.cs

        public static ltext s_are = new ltext(new string[]{" are: ",
                                         " so: "});   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\View_AccessRights_Form.cs

        public static ltext s_DataBaseResult_Form_Title = new ltext(new string[]{"Database connection result",
                                                                           "Povezava na podatkovno bazo" });   // referenced in C:\Tangenta40\CodeTables\DBConectionControl40\View_AccessRights_Form.cs

        public static ltext s_Save = new ltext(new string[]{"Save",
                                         "Shrani" });

        public static ltext s_Select = new ltext(new string[]{"Select",
                                                 "Izberite " });

        public static ltext s_DefaultDataBaseName = new ltext(new string[]{"OrganisationX",
                                                 "PodjetjeX" });

    }
}
