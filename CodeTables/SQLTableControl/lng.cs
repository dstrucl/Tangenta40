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

namespace CodeTables
{
    public static class lng
    {
 public static ltext s_NumberOfTabelsToCreate = new ltext( new string[]{"Number Of Tabels To Create = ",
                                                                 "Število tabel v podatkovni bazi : "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\CreateTables_WindowsForm.cs

 public static ltext s_WaitToCreate_Tables = new ltext( new string[]{"Wait to create tables in database",
                                                               "Počakajte, da se naredijo tabele v podatkovni bazi"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\CreateTables_WindowsForm.cs

 public static ltext s_Copyright_Tangenta = new ltext( new string[]{"(C)opyright Tangenta Public Licence.", "Ta program je zaščiten z licenco:\"(C)opyright Tangenta Public Licence!\""});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\CreateTables_WindowsForm.cs

 public static ltext s_Format = new ltext( new string[]{"Format", "Format"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_Width = new ltext( new string[]{"width", "širina"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_Height = new ltext( new string[]{"height", "višina"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_Size = new ltext( new string[]{"Size", "Velikost"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_Bytes = new ltext( new string[]{"Byte", "Bytov"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_ResizeImage = new ltext( new string[]{"Resize Image", "Spremeni Velikost Slike"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_KeepAspectRation = new ltext( new string[]{"Keep aspect ration", "Ohrani razmerje med širino in višino"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_UnknownPictureFormatSaveInJpg = new ltext( new string[]{"Error:Unknown picture format! Save in jpeg format?", "Nepoznan format slike! Shranim v Jpeg formatu?"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_SaveInJpgQuestion = new ltext( new string[]{"Save in jpeg format?", "Shranim v Jpeg formatu?"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_OK = new ltext( new string[]{"OK",
                                                 "V redu"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_Cancel = new ltext( new string[]{"Cancel",
                                          "Prekini"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\ResizeImage_Form.cs

 public static ltext s_Error_Table_DoesNotHavePrimary_ID = new ltext( new string[]{"Error table does not have primary ID!",
                                                                            "Napaka tabela nima indexnega stolpca!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTable.DeleteRows.cs

 public static ltext s_Value = new ltext( new string[]{"Value", "Podatek"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTable.Update.cs

 public static ltext s_MustBeUnique = new ltext( new string[]{" must be unique", " morajo biti unikatni"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTable.Update.cs

 public static ltext s_Data_in_Column = new ltext( new string[]{"Data in Column", "Podatki v stolpcu"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTable.Update.cs

 public static ltext s_AllreadyExistForTable = new ltext( new string[]{"Allready exist for table ",
                                                                 "že obstaja za tabelo "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTable.Update.cs

 public static ltext s_In_Table = new ltext( new string[]{" in tabel",
                                            " v tabeli"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTable.Update.cs


 public static ltext s_AreYouShureToDeleteAllTablesAndCreateNewOnes = new ltext( new string[]{"Are you shure to delete ALL Tables and create new ones?", " Ste prepričani, da izbrišem vse tabele in ustvarim nove ?"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_DeleteAllTablesAndCreateNewOnes = new ltext( new string[]{"Delete ALL Tables and create new ones?", " Izbrišem vse tabele in ustvarim nove ?"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_Error_Creating_Tables_in_SQLITE = new ltext( new string[]{"Error creating tables in SQLITE", "Napaka pri tvorjenu tabel v SQLITE!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext sTableIsMissing = new ltext( new string[]{"Tabale is missing", " Manjka Tabela"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_CanNotMakeAConnection = new ltext( new string[]{"Can not make a connection with conection data ! \nChange connection data or press Cancel!",
                                                     "Povezava z navedenimi nastavitvami ni uspešna ! Spremenite podatke za povezavo ali pritisnite na gumb prekini"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_DataBase = new ltext( new string[]{"Database",
                                             "Podatkovna baza"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_Error = new ltext( new string[]{"Error",
                                          "Napaka"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_err_CreateViews = new ltext( new string[]{"Error create views", "Napaka pri izdelavi prikazov (\"VIEWS\""});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_ErrorView = new ltext( new string[]{"Error creating view :",
                                                       "Napaka! V bazi podatkov je prišlo do napake pri ustvarjanju prikaza:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_File = new ltext( new string[]{"File",
                                       "Datoteka"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_Warning = new ltext( new string[]{"Warning",
                                           "Opozorilo"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_CreateTablesInDataBaseQuestion = new ltext( new string[]{"Create tables in database ",
                                                                   "Ali naj ustvarim tabele v podatkovni bazi "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_DropTablesInDataBaseQuestion = new ltext( new string[]{"Delete (drop) tables in database ",
                                                                 "Ali naj izbrišem tabele v podatkovni bazi "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_AllTablesCreatedOK = new ltext( new string[]{"All tables are created OK.",
                                                        "Vse tabele so uspešno ustvarjene."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_err_AllTablesCreated = new ltext( new string[]{"ERROR:All tables are not created.",
                                                        "NAPAKA:Vse tabele niso ustvarjene."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_AllTablesDropedOK = new ltext( new string[]{"All tables are deleted OK.",
                                                        "Vse tabele so uspešno izbrisane."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_err_AllTablesDroped = new ltext( new string[]{"ERROR:All tables are not deleted.",
                                                        "NAPAKA:Vse tabele niso izbrisane."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_Comma_is_missing_to_separate_cells_column_name_from_cell_value_in_line = new ltext( new string[]{"Comma (',') is missing to separate cell's column name from cell value in line:",
                                                                               "Manjka vejica(',') ki bi ločevala ime stolpca v kateri je celica in njeno vrednost v vrstici:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_TableNameIsExpectedToBeBeforeDataLines = new ltext( new string[]{"Table name is expected to be before column data lines !",
                                                                          "Manjka ime tabele pred podatki !"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_Illegal_end_table_XML_command_expected = new ltext( new string[]{"Illegal end table XML command expected",
                                                                          "Neveljaven XML zaključek tabele, pričakuje se"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_DropAllTablesNotSupported_for_data_base_type = new ltext( new string[]{"Drop all tables not supported for data base type", "Brisanje vseh tabel ni podprto za podtakovno bazo tipa "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_DataBaseHasNoTablesItIsEmpty = new ltext( new string[]{"Database has not tables.It is allready empty.",
                                                                       "Podatkovna baza nima tabel. Je prazna."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQLTableControl.cs

 public static ltext s_AreYouSureToDeleteView = new ltext( new string[]{"Are you sure to delete view", "Ste prepričani izbrisati prikaz"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs

 public static ltext s_DeleteViewTitle = new ltext( new string[]{"Delete View", "Zbriši prikaz"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs

 public static ltext s_Close = new ltext( new string[]{"Close",
                                         "Zapri"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs

 public static ltext s_DeleteViewForTable = new ltext( new string[]{"Delete view for table:",
                                                             "Zbriši prikaz tabele:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs

 public static ltext s_SelectViewForTable = new ltext( new string[]{"Select view for table:",
                                                             "Izberi prikaz tabele:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs

 public static ltext s_SelectAsDefaultView = new ltext( new string[]{"Select as default View",
                                                              "Izberi kot privzeti prikaz"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs

 public static ltext s_SelectedView = new ltext( new string[]{"Selected View = ",
                                                       "Izbrani prikaz = "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs

 public static ltext s_TableView = new ltext( new string[]{"Table View ",
                                                       "Vnešeni prikaz tabele "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs

 public static ltext s_DoesNotExist = new ltext( new string[]{" does not exist!",
                                                       " ne obstaja!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs

 public static ltext s_ViewWithName = new ltext( new string[]{"View with name:",
                                                          "Prikaz z imenom:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs

 
 public static ltext s_YouMustDefineViewNameOrCancel = new ltext( new string[]{"You must define View Name or press Cancel",
                                                                        "Ime prikaza morate izbrati ali pa pritisnite na gumb Prekini"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SelectView_Form.cs


 public static ltext s_File_does_not_exist = new ltext( new string[]{"File does not exist:",
                                                       "Datoteka ne obstaja :"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\Column.cs

 public static ltext s_Illegal_format_for = new ltext( new string[]{"Illegal format for",
                                                 "Neveljaven format for"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\Column.cs

 public static ltext s_UnsuportedType = new ltext( new string[]{"Unsupported type",
                                                  "Neveljaven typ"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\Column.cs

 public static ltext s_ErrorNoImage = new ltext( new string[]{"ERROR No image in Func.ImageStore!",
                                                "NAPAKA: Ni slike v Func.ImageStore!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\Column.cs


 public static ltext s_File_Not_Opened = new ltext( new string[]{"File not opened:",
                                              "Datoteka ni možno odpreti:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SourceText.cs

 public static ltext s_File_allready_Opened = new ltext( new string[]{"File is already opened:",
                                              "Datoteka je že odprta:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SourceText.cs

 public static ltext s_CanNotBeNull = new ltext( new string[]{": can not be undefined",
                                                                 ": ne sme biti nedoločeno!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.Create_DefineView_InputControls.cs

 public static ltext s_View = new ltext( new string[]{"View",
                                                "Prikaz"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.Create_DefineView_InputControls.cs

 public static ltext s_Error_Insert_Unique_the_same_allready_exists_at_id = new ltext( new string[]{"\r\nThe same value allready exists at ID =  %I64d", "\r\nIsta vrednost že obstaja pri ID =  %I64d"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.cs

 public static ltext s_Error_Insert_Unique = new ltext( new string[]{"Error, Can not insert values into table %s because of Unique constraint violation ", "Napaka pri vnosu v tabelo %s, ker unikatna vrednost že obstaja (angl. >>Unique constraint<<). Podrobno "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.cs

 
 public static ltext s_No_Table_or_Column_Name_in_Line = new ltext( new string[]{" No Table or Column Name in line ",
                                                           " Manjka ime tabela ali ime stolpca v vrtsici "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.cs

 public static ltext s_CanNotFindColumnName = new ltext( new string[]{"Can not find column name",
                                                        "V tabeli ni stolpca z imenom"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.cs

 public static ltext s_CanNotFindForeignKey = new ltext( new string[]{"Can not find foreign key",
                                                        "V tabeli ni ključa z imenom"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.cs

 public static ltext s_NoColumnName = new ltext( new string[]{"Missing column name",
                                                   "Manjka ime stolpca"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.cs

 public static ltext s_Columns_Are = new ltext( new string[]{"columns are",
                                               " so stolpci"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.cs

 public static ltext s_ForeignKeysAre = new ltext( new string[]{"Foreign keys are",
                                                  "Ključi (povezave) so"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.cs

 public static ltext s_ErrorNoData = new ltext( new string[]{"ERROR No Data! There are no InputControls!",
                                          "NAPAKA: Ni Podatkov! Input Kontrole niso ustvarjene!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\SQL_Table.cs

 public static ltext s_UseFilter = new ltext( new string[]{"Use filter",
                                                    "Uporabi filter"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\DefineView_InputControl.cs

 public static ltext s_Question = new ltext( new string[]{"?", "?"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_CreateNewViewQuestion = new ltext( new string[]{"Create new View? \r\nIf yes current column selection will be lost !",
                                                        "Ustvarim nov prikaz? \r\nČe kliknete gumb Da, boste izbrisali trenutni izbor stolpcev !"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_SelectColumnsBeforeShow = new ltext( new string[]{"You have not selected columns to show the view.\r\nSelect columns by dragging them in arrows directions.",
                                                                     "Niste izbrali stolpcev za prikaz.\r\nIzberite jih s povlačenjem kot kažeta puščici."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_Descending = new ltext( new string[]{"Descending",
                                                         "Padajoče"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_DeleteView = new ltext( new string[]{"Delete", "Zbriši"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_Limit = new ltext( new string[]{"Limit", "Omejitev"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_SelectView = new ltext( new string[]{"Select View",
                                                     "Izberi prikaz"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_CreateNewView = new ltext( new string[]{"Ceate New View",
                                                         "Ustvari Nov Prikaz"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_Show = new ltext( new string[]{"Show",
                                               "Prikaži"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_PrimaryView = new ltext( new string[]{"Primary View",
                                                        "Osnovni (začetni) prikaz"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_Save = new ltext( new string[]{"Save",
                                               "Shrani"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_DataView_Form = new ltext( new string[]{"Set Table View Criteria:",
                                                       "Nastavitve prikaza tabele:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\CreateView_Form.cs

 public static ltext s_ExportTemplateToolStripMenuItem = new ltext( new string[]{"Create Import/export Template",
                                                                   "Ustvari uvozno/izvozno predlogo"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\DataTable_Form.cs

 public static ltext s_Create = new ltext( new string[]{"Create",
                                          "Ustvari"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\DataTable_Form.cs

 public static ltext s_Edit = new ltext( new string[]{"Edit",
                                        "Uredi"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\DataTable_Form.cs

 public static ltext s_DeleteRows = new ltext( new string[]{"Delete Rows",
                                              "Zbriši vrstice"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\DataTable_Form.cs

 public static ltext s_Err_TableNameDoesNotExist = new ltext( new string[]{"Table name does not exist:",
                                                               "V bazi podatkov ne obstaja tabela z imenom:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\DataTable_Form.cs

 public static ltext s_CreateTableInstruction = new ltext( new string[]{"Table does not exist. You can create table ",
                                                         "Tabela ne obstaja. Ustvarite novo tabelo "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\DataTable_Form.cs

 public static ltext s_EditTable = new ltext( new string[]{"Edit Table :",
                                        "Urejanje tabele:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\EditTable_Form.cs

  public static ltext s_CanNotSaveViewWithNoColumn = new ltext( new string[]{"Can not create and save Table view without columns!",
                                                                     "Ni možno narediti  in shraniti tabelaričnega pogleda brez definiranih stolpcev!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SaveView_Form.cs

 public static ltext s_ViewToSave = new ltext( new string[]{"Save View : ",
                                                       "Shrani prikaz : "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SaveView_Form.cs

 public static ltext s_SaveViewForTable = new ltext( new string[]{"Save view for table:",
                                                           "Shrani prikaz tabele:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SaveView_Form.cs

 
 public static ltext s_CurrentViewIsSuccesfulySavedUnderName = new ltext( new string[]{"Current View is saved under name:",
                                                                                "Prikaz je shranjen pod imenom:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SaveView_Form.cs

 public static ltext s_OverWriteExistingView = new ltext( new string[]{"View name allready exist! Do you want to overwrite view name:",
                                                                "Prikaz že obstaja! Želite da se prepiši čez pogled:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SaveView_Form.cs

  public static ltext s_Info = new ltext( new string[]{"Info",
                                        "Opozorilo"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\SaveView_Form.cs

 public static ltext s_SaveWindowsConfiguration = new ltext( new string[]{"Save Windows Positions and Size ?",
                                                                   "Shranim pozicije in velikosti oken ?"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableDockingForm.cs

 public static ltext s_DataEditor = new ltext( new string[]{"Data Editor",
                                                     "Vnos podatkov"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableDockingForm.cs

 public static ltext s_ViewManager = new ltext( new string[]{"View Manager",
                                                      "Urejanje prikazov"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableDockingForm.cs

 public static ltext s_PrimaryTable = new ltext( new string[]{"Primary Table",
                                                       "Osnovna tabela"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableDockingForm.cs

 public static ltext s_Table_View_1 = new ltext( new string[]{"Table View 1",
                                                       "Tabelarični Prikaz 1"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableDockingForm.cs

 public static ltext s_Table_View_2 = new ltext( new string[]{"Table View 2",
                                                       "Tabelarični Prikaz 2"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableDockingForm.cs

 public static ltext s_Table_View_3 = new ltext( new string[]{"Table View 3",
                                                       "Tabelarični Prikaz 3"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableDockingForm.cs

 public static ltext s_Table_View_4 = new ltext( new string[]{"Table View 4",
                                                       "Tabelarični Prikaz 4"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableDockingForm.cs

 public static ltext s_SaveWindowConfiguration = new ltext( new string[]{"Save Window Configuration",
                                                                  "Shrani konfiguracijo oken"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableDockingForm.cs

 public static ltext s_Edit_XML_Configuration = new ltext( new string[]{"Edit XML Configuration record",
                                                                 "Preglej ali uredi XML konfiguracijski zapis"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableDockingForm.cs


 public static ltext sRowsCount = new ltext( new string[]{"Rows count = ", "Število vrstic = "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableView_Form.cs


 public static ltext s_ConnectWithEditTableForm = new ltext( new string[]{"Bind selection with Edit Table",
                                                                   "Poveži izbiro z oknom za vnos podatkov"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TableView_Form.cs

 public static ltext s_save = new ltext( new string[]{"save",
                                        "Datoteka"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\TextEditorDialog.cs


 public static ltext s_YouCanNotStartVirtualSecretaryUntilRandomDataParentAreSet = new ltext( new string[]{"You can not start Virtual Secretay until all Random Param Settings are defined.",
                                                                                                     "Virtualnega tajnika ni možno zagnati dogler niso podane vse nastavitve."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\usrc_EditRow.cs

 public static ltext s_DataInsertedIntoDataBaseOK = new ltext( new string[]{"Data Inserted Into Data Base OK.",
                                                                    "Podatki so vnešeni v bazo podatkov."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\usrc_EditRow.cs

 public static ltext sBtnCallSecretaryToWork = new ltext( new string[]{"Virtual Secretary",
                                                          "Virtualna tajnica"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\usrc_EditRow.cs

 public static ltext sInsertData = new ltext( new string[]{"Insert Data in Database",
                                             "Vpiši v bazo"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\usrc_EditRow.cs

 public static ltext sUpdate = new ltext( new string[]{"Update",
                                                    "Popravi"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\usrc_EditRow.cs

 public static ltext sNew = new ltext( new string[]{"New",
                                                    "Nov vnos"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\TableDocking_Form\usrc_EditRow.cs

 public static ltext s_null_means_nod_data = new ltext( new string[]{"null means no data", "nič pomeni da podatka ni"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_InputControl_Label.cs

 public static ltext s_ValueMustBeUnique = new ltext( new string[]{"Value must be unique!", "Podatek mora biti unikaten!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_InputControl_Label.cs

 public static ltext s_null = new ltext( new string[]{"null", "brez"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_InputControl_Label.cs

 public static ltext s_ReferencedTableRow = new ltext( new string[]{"Referenced Table Row:", "Naslovljena vrstica:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_RowReferencedFromTable.cs

 public static ltext s_Yes = new ltext( new string[]{"Yes", "Da"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_RowReferencedFromTable_List_Dialog.cs

 public static ltext s_No = new ltext( new string[]{"No", "Ne"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_RowReferencedFromTable_List_Dialog.cs

 public static ltext s_InTable = new ltext( new string[]{" int Table ", " v tabeli "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_RowReferencedFromTable_List_Dialog.cs

 public static ltext s_RowWithID = new ltext( new string[]{" Row with ID = ", "Vrstica katere ID = "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_RowReferencedFromTable_List_Dialog.cs

 public static ltext s_IsReferencedSeveralTimes = new ltext( new string[]{" is referenced several times from other tables!", " je naslovljena večkrat tudi iz drugih tabel!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_RowReferencedFromTable_List_Dialog.cs

 public static ltext s_IfYouChangeThisRowThisWillAffectAllRowsThatAreReferencingIt = new ltext( new string[]{"Changing data of this row will affect all rows from other tables that are referencing it.", "Če spremenite to vrstico, bo to imelo za posledico, da se bo spremenila vsebina vrstic v drugih tabelah, ki naslavljajo to vrstico."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_RowReferencedFromTable_List_Dialog.cs

 public static ltext s_BellowIsTheListOfTableReferences = new ltext( new string[]{"Bellow is the list of table references.", "Spodaj so prikazane vrstice drugih tabel, ki naslavljajo navedeno vrstico."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_RowReferencedFromTable_List_Dialog.cs

 public static ltext s_ChangeThisRowQuestion = new ltext( new string[]{"Change this row?", "Spremenim vrstico?"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\usrc_RowReferencedFromTable_List_Dialog.cs



 public static ltext s_Or = new ltext( new string[]{" or ",
                                        " ali "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\xml.cs

 public static ltext s_Error_Saving_XMLFile = new ltext( new string[]{"ERROR: Create New Folder",
                                                              "Prišlo je do napake pri ustvarjanju nove mape."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\xml.cs

 public static ltext s_XMLFolderIsNotDefined = new ltext( new string[]{"XMLFolder is not defined yet. Use Program Settings to define it!",
                                                               "XML mapa ni določene. V programskih nastavitvah izberite XML mapo!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\xml.cs

 public static ltext s_XmlFileNotLoadedInXmlDocument = new ltext( new string[]{"XML file is not loaded into XmlDocument!",
                                                                       "XML datoteka ni uspešno preprana v XmlDokument!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\xml.cs

 public static ltext s_XmlRootNotFound = new ltext( new string[]{"XML root node not found!",
                                                   "XML začetno vozlišče ni ustrezno!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\xml.cs

 public static ltext s_XmlNodeNotFound = new ltext( new string[]{"Can not find node ",
                                                   "Ne najdem vozlisča "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\xml.cs

 public static ltext s_Expected = new ltext( new string[]{" Expected ",
                                                   " Pričakuje se "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\xml.cs

 public static ltext s_XmlIlegalNode = new ltext( new string[]{" Illegal xml node ",
                                                       " Neveljavno xml stičišče "});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\xml.cs

 public static ltext sRandomDataSettings = new ltext( new string[]{"Settings",
                                                            "Nastavitve"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\Virtual Secretary\VirtualSecretary_Form.cs


 public static ltext s_Start = new ltext( new string[]{"Start!",
                                          "Začni!"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\Virtual Secretary\VirtualSecretary_Form.cs

 public static ltext s_Pause = new ltext( new string[]{"Pause",
                                          "Pavza"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\Virtual Secretary\VirtualSecretary_Form.cs

 public static ltext s_NumberOfEntries = new ltext( new string[]{"Number of Entries:",
                                                    "Število vnosov:"});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\Virtual Secretary\VirtualSecretary_Form.cs

 public static ltext s_WaitUntilRandomParamSettingDialogIsClosed = new ltext( new string[]{"Wait until Random Param Setting Dialog is closed.",
                                                                             "Čakanje, da se nastavitveni dialog nakjučnega generatorja konča."});   // referenced in C:\Tangenta40\CodeTables\SQLTableControl\Virtual Secretary\WaitRandomDataParamSettingsDialogClosed_Form.cs



 public static ltext s_Table = new ltext(new string[]{"Table",
                                         "Tabela" });

 public static ltext s_Select = new ltext(new string[]{"Select",
                                               "Izberi" });

 public static ltext s_Delete = new ltext(new string[]{"Drop Table ",
                                        "Zbriši Tabelo" });

 }
}
