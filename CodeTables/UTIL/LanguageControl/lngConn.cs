#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;

using System.Text;

namespace LanguageControl
{

    public static class lngConn
    {

        public static ltext s_CREATE_OR_SELECT_NEW_ONE = new ltext("Create or select new one ?",
                                               "Želite ustvariti novo bazo ali izbrati drugo?");

        public static ltext s_AreYouSureToDeleteDataBase = new ltext("Are you sure to destroy database ",
                                                           "Ste prepričani, da uničite podatkovno bazo ");

        public static ltext s_allready_exists = new ltext("New Database allready exist ",
                                                "Nova podatkovna baza že obstaja");

        public static ltext s_Delete_existing_new_data_base = new ltext("Delete existing new database",
                                                              "Zbrišem novo podatkovno bazo");

        public static ltext s_Question = new ltext("Question",
                                         "Vprašanje");


        public static ltext s_ConnectionToNewOldDatabase = new ltext("Connection to new Database TabliceET is OK",
                                          "Povezava na novejšo podatkovno bazo TabliceET je OK.");

        public static ltext s_ConnectionNewDatabase = new ltext("Connection to New Database is OK",
                                          "Povezava na novo podatkovno bazo je OK.");

        public static ltext s_OldDatabase = new ltext("Old Database ",
                                          "Stara podatkovna baza ");

        public static ltext s_NewDatabase = new ltext("New Database ",
                                            "Nova podatkovna baza ");

        public static ltext s_FormTitle = new ltext("Import Database ",
                                          "Prenos podatkovne baze ");


        public static ltext s_DataBaseName = new ltext("Database name",
                                             "Podatkovna baza");

        public static ltext s_Password = new ltext("Password",
                                         "Geslo");

        public static ltext s_Browse__ = new ltext("Browse..",
                                         "Poišći..");

        public static ltext s_Finish = new ltext("Cancel",
                                      "prekini");


        public static ltext s_ConnectionOldDatabase = new ltext("Connection to old DataBase TabliceET",
                                                        "Povezava na staro bazo TabliceET");

        public static ltext s_lbl_Server = new ltext("Server:",
                                                        "Strežnik:");
        public static ltext s_lbl_ServerType = new ltext("Server type:",
                                                         "Tip strežnika:");
        public static ltext s_lbl_AuthenticationType = new ltext("Authentication type:",
                                                             "Način prijave:");

        public static ltext s_lbl_DataBase = new ltext("DataBase:",
                                                       "Baza podatkov:");

        public static ltext s_lbl_UserName = new ltext("User name:",
                                                       "Uporabniško ime:");

        public static ltext s_grp_UserRights = new ltext("User rights:",
                                                         "Uporabniške pravice:");

        public static ltext s_ConnectionDialogInfo_Titel = new ltext("DataBase Connection Info",
                                                                         "Podatki o povezavi na bazo podatkov");

        public static ltext s_AreYouShureToDeleteAllTablesAndCreateNewOnes = new ltext("Are you shure to delete ALL Tables and create new ones?", " Ste prepričani, da izbrišem vse tabele in ustvarim nove ?");
        public static ltext s_DeleteAllTablesAndCreateNewOnes = new ltext("Delete ALL Tables and create new ones?", " Izbrišem vse tabele in ustvarim nove ?");

        public static ltext s_Error_Creating_Tables_in_SQLITE = new ltext("Error creating tables in SQLITE", "Napaka pri tvorjenu tabel v SQLITE!");
        public static ltext sTableIsMissing = new ltext("Tabale is missing", " Manjka Tabela");
        public static ltext s_IsNotValid = new ltext("is not valid", " ni veljavno");

        public static ltext s_FileName = new ltext("File Name", "Ime Datoteke");
        public static ltext s_Folder = new ltext("Folder", "Mapa (pot do datoteke)");

        public static ltext s_Ok = new ltext("Ok",
                                             "V redu");

        public static ltext s_ServerType = new ltext("Server type",
                                           "Tip strežnika");

        public static ltext s_Server = new ltext("Server",
                                           "Strežnik");

        public static ltext s_Select = new ltext("Select",
                                                 "Izberite ");

        public static ltext s_Select_Server = new ltext("Selected Server",
                                                          "Izbrani strežnik");

        public static ltext s_SelectSQLiteDataBaseFileName = new ltext("Selected DataBase file name:",
                                                                       "Izberite datoteko podatkovne baze");

        public static ltext s_EnterDataBaseFileOnServer = new ltext("Enter DataBase file on server computer",
                                                                    "Vpišite ime zapisa (datoteke) podatkovne baze na strežniškem disku");


        public static ltext s_DataBaseFileNameCanNotBeEmpty = new ltext("DataBase file may not be empty!",
                                                                        "Ime zapisa (datoteke) podatkovne baze ne sme biti prazno!");

        public static ltext s_EnterDataBaseFileOnServerIfYouKnowDrivesAndFoldersOnServer = new ltext("Enter DataBase file on server computer only if you know drives and folders on server computer",
                                                                                                     "Vpišite ime zapisa (datoteke) podatkovne baze na strežniškem disku samo, če poznate naslove diskov in map na strežniku.");

        public static ltext s_OnLocalComputerDatabaseConstructionFileInstructions = new ltext("Warning! You are working on local computer and not on server computer where you want to create a database. While you are running this program on local WorkingPlaces and not on server computer, this program can not browse and show server's directories. If you know real drives or directories on server computer,you can define database file  in a text box. Are you going to define database file in a text box ?",
                                                                                              "Opozorilo! Ste na lokalnem računalniku in ne na strežniškem računalniku kateremu teče tudi podatkovni strežnik na katerem želite ustvariti novo podatkovno datoteko (bazo). Novo podaptkovno bazo lahko določite v vnosnem polju samo, če poznate pogone in mape na strežniškem računalniku. Želite določiti ime podatkvne baze v vnosnem polju?");


        public static ltext s_OnServerDatabaseConstructionFileInstructions = new ltext("Warning! The program recognize that you are working on Server Computer. If it is true you can define new database file in directory which is selected by file browse dialog ?",
                                                                                       "Opozorilo! Program je ugotovil, da ste prijavljeni na računalniku na kateren teče tudi podatkovni strežnik na katerem želite ustvariti novo podatkovno bazo. Če je temu res tako potem lahko izberete mapo v kateri bo nova podaptkovna baza z uporabo dialoga za izbiro mape?");


        public static ltext s_ConnectionOK = new ltext("Connection is OK!",
                                                 "Povezava je OK!");
        public static ltext s_CanNotMakeAConnection = new ltext("Can not make a connection with conection data ! \nChange connection data or press Cancel!",
                                                     "Povezava z navedenimi nastavitvami ni uspešna ! Spremenite podatke za povezavo ali pritisnite na gumb prekini");

        public static ltext s_CanNotMakeServerOnlyConnection = new ltext("Can not connect to server! \nChange connection data or press Cancel!",
                                                                         "Povezava z strežnikom ni uspešna ! Spremenite podatke za povezavo ali pritisnite na gumb prekini");

        public static ltext s_DatabaseNotDefined = new ltext("DataBase is not defined !",
                                                       "Niste določili podpatkovne baze !");

        public static ltext s_ViewPermissions = new ltext("View permission rights!",
                                                 "Pogled v pravice!");

        public static ltext s_Not_EnoughPermissions_To_List_Databases = new ltext("You don't have enough permission to view database list! Try to connect with administrator rights.",
                                                                                  "Nimate dovolj pravic za vpoogled v seznam podatkovnih baz! Na podatkovni strežnik se prijavite z adminsitratorskimi pravicami.");

        public static ltext s_GetDataBaseList = new ltext("Get DataBases on Server",
                                                    "Seznam podatkovnih baz na strežniku ");

        public static ltext s_DataBase = new ltext("Database",
                                             "Podatkovna baza");

        public static ltext s_DataBase_e = new ltext("Database",
                                                     "Podatkovna baze");

        public static ltext s_Can_Not_Be_Found_On_server = new ltext(" can not be found on server ",
                                                                    " ni na strežniku ");

        public static ltext s_Already_exist = new ltext(" allready exist! Select anaother name.",
                                                        " že obstaja! Izberite drugo ime.");

        public static ltext s_UserName = new ltext("UserName",
                                             "Uporabniško Ime");


        public static ltext s_Save = new ltext("Save",
                                         "Shrani");

        public static ltext s_Error = new ltext("Error",
                                          "Napaka");

        public static ltext s_Warning = new ltext("Warning",
                                            "Opozorilo");

        public static ltext s_Cancel = new ltext("Cancel",
                                          "Prekini");

        public static ltext s_ConnectDialog_Form_Title = new ltext("Set Connection Dialog",
                                                              "Vzpostavi povezavo s strežnikom");

        public static ltext s_ConnectWithDatabase = new ltext("Connect with database",
                                                        "Poveži se z bazo podatkov");

        public static ltext s_Enter_UsernName_and_Password_then_press_button = new ltext("Enter UsernName and Password, then press button \"Connect with database\".",
                                                                                           "Vnesite uporabniško ime in geslo. Nato pritisnite gumb poveži se z bazo podatkov.");

        public static ltext s_Try_Width_Different_Windows_Log_on_Or_Select_SQL_Authenticatio_UserName_AndPassword = new ltext("Log-off and then try to connect width another \"Windows-Log-On\",\n or Select_SQL Authentication with UserName and Password.",
                                                                                                                              "Prijavite se v Okna z drugim uporabniškim imenom,\n ali pa izberite SQL Strežniško prijavo z uporabniškim imenom in geslom.");

        public static ltext s_Connection_with_database_was_not_done_yet = new ltext("Connection with database was not done yet. It is the first time connection. Enter server name or IP address, database name,user name and password. After that press button \"Connect with database\".",
                                                                              "Povezava z bazo podatkov še ni bila vzpostavljena. Gre za začetno (prvo) vzpostavitev povezave z bazo. Vnesite ime ali IP naslov strežnika, ime podatkovne baze, uporabniško ime in geslo. Nato pritisnite gumb poveži se z bazo podatkov.");
        public static ltext s_Connection_with_database_not_succeeded_Try_again = new ltext("Connection with database not succeeded. Try again.",
                                                                                        "Povezava na bazo podatkov ni uspela, poizkusite znova.");

        public static ltext s_Connecting_with_database_was_not_successful_Enter_UserName_And_Password_Again_Then_Press_Connect_withDatabase = new ltext("Connection process with database was not successful. Enter UserName and Password again. Then press \"Connect with database\".",
                                                                                                                                                         "Povezavanje z bazo podatkov ni bilo uspešno. Ponovno preverite in vpišite ime ali IP naslov strežnika, ime podatkovne baze, uporabniško ime ter geslo. Nato pritisnite gumb \"Poveži se z bazo podatkov.\"");

        public static ltext s_Save_database_connection_data = new ltext(
            "Save database connection data ?",
            "Shrani podatke za povezavo z bazo podatkov ?");

        public static ltext s_Connection_is_OK_Click_on_button_Save_to_save_connection_data___ = new ltext(
            "Connection is OK. Click on button Save to save connection data, to avoid entering connection data again next time you start the program.",
            "Povezava z bazo je uspela. S klikom na gumb Shrani shranite podatke za povezavo z bazo podatkov, da vam jih nasldenjič (razen gesla) ne bo potrebno znova vpisovati.");


        public static ltext s_WindowsAuthentication = new ltext("Windows Autenthication",
                                                   "Windows prijava");

        public static ltext s_SQLServerAuthentication = new ltext("SQL Server Autenthication",
                                                   "SQL strežniška prijava");


        public static ltext s_Connection_to_Database = new ltext("Connection to DataBase:\"",
                                                          "Prijava na podatkovno bazo:\"");

        public static ltext s_with_Windows_authentication_is_OK = new ltext(" with Windows authentication is OK !\n\nPermissions for the Windows user ",
                                                          " s prijavo Windows uporabniškega0 imena je uspela!\n\nDovoljenja uporabnika ");

        public static ltext s_with_SQL_authentication_is_OK = new ltext("is OK !\n\nPermissions for the user ",
                                                                       "je uspela !\n\nDovoljenja uporabnika ");
        public static ltext s_are = new ltext(" are: ",
                                         " so: ");

        public static ltext s_DataBaseResult_Form_Title = new ltext("Database connection result",
                                                               "Povezava na podatkovno bazo");

        public static ltext s_CreateDataBaseDialog_Form_Title = new ltext("Create Database Dialog",
                                                                     "Ustvari podatkovno bazo");
        public static ltext s_General = new ltext(" General ",
                                         " Splošno ");
        public static ltext s_LogOnToTheServer = new ltext(" Log on to the server ",
                                                     " Prijava na strežnik ");
        public static ltext s_ConnectToDatabaseName = new ltext("Connect to Database name",
                                                          "Poveži se na podatkovno bazo");

        public static ltext s_TestConnection = new ltext("Test Connection",
                                                   "Preizkusi povezavo");
        public static ltext s_GetConnection = new ltext("Get Connection",
                                                   "Vzpostavi povezavo");

        public static ltext s_CreateNewDatabase = new ltext("Create New Database",
                                                      "Ustvari novo podatkovno bazo");

        public static ltext s_Error_Can_not_get_Databases_on_Server = new ltext("Error Can not get Databases on Server:",
                                                                          "Napaka, ni možno najti podatkovnih baz na strežniku:");
        public static ltext s_Execption = new ltext(" Execption ",
                                              " \"Execption\" ");

        public static ltext s_User_name_is_missing_Enter_User_Name = new ltext("User name is missing. Enter User Name.",
                                                                        "Manjka uporabniško ime. Vpišite uporabniško ime.");

        public static ltext s_Password_is_missing_Enter_Password = new ltext("Password is missing. Enter Password.",
                                                                          "Manjka geslo. Vpišite geslo.");

        public static ltext s_Please_wait_while_browsing_local_network_for_database_servers = new ltext("Please wait\nwhile browsing local network for database servers...",
                                                                                                 "Prosimo počakajte\nda se poiščejo podatkovni strežniki v lokalnem omrežju...");

        public static ltext s_Select_server_and_press_ok = new ltext("Select server and press OK.",
                                                              "Izberite strežnik in pritisnite OK.");

        public static ltext s_Error_browse_DataBase_servers_Error_Exception = new ltext("Error browse DataBase servers. Error_Exception =",
                                                                                   "Napaka pri iskanju podtakovnih strežnikov. \"Exception\" =");
        public static ltext s_No_server_selected_Please_select_server = new ltext("No server selected. Please select server.",
                                                                            "Niste izbrali strežnika. Prosimo izberite strežnik.");

    }

 }
