; -- Tangenta.iss --
; Same as Example1.iss, but creates some registry entries too.

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!

[Setup]
AppName=Setup_Tangenta
AppVersion=1.5
DefaultDirName={pf}\Tangenta
DefaultGroupName=Tangenta
UninstallDisplayIcon={app}\Tangenta.exe
OutputDir=userdocs:Inno Setup Examples Output

[Files]
;<FilesToInstall>

;--- Project Libraries -- 

  Source: "C:\Tangenta40\Release\Tangenta.exe";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\Check.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\ComboBox_Recent.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\CommandLineHelp.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\LanguageControl.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\NavigationButtons.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\usrc_Help.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\Country.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\CodeTables.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\Crom.Controls.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\DataGridView_2xls.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\Excell_Export.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\DynEditControls.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\DBTypes.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\DBConnectionControl40.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\IniFile.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\LogFile.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\DigitalRune.Windows.TextEditor.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\SearchLocalNetwork.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\ProgramDiagnostic.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\DBConnectionControl_Settings.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\Password.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\TextBoxRecent.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\SelectGender.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\StaticLib.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\usrc_Group_Handler.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\usrc_Item_PageHandler.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\XMessage.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\DB.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\TangentaDataBaseDef.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\TangentaTableClass.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\ThreadProcessor.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\FiscalVerificationOfInvoices_SLO.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\TangentaDB.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\ShopA_dbfunc.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\UniversalInvoice.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\SLOTaxService.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\Form_Discount.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\PriseLists.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\ShopA.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\ShopB.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\ShopC.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\Startup.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\TangentaSampleDB.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\ProgressForm.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\UpgradeDB.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\Release\uwpf_GUI.dll";  DestDir: "{app}"

;--- External DLLs -- 

  Source: "C:\Tangenta40\DLL\oExcel.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\DLL\MySql.Data.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\DLL\System.Data.SQLite.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\SLO_FISCAL\common_reference\Gma.QrCodeNet.Encoding.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\SLO_FISCAL\common_reference\nunit.framework.dll";  DestDir: "{app}"
  Source: "C:\Tangenta40\packages\Security.Cryptography.1.7.2\lib\net35\Security.Cryptography.dll";  DestDir: "{app}"

;</FilesToInstall>

[Icons]
Name: "{group}\Tangenta"; Filename: "{app}\Tangenta.exe"

; NOTE: Most apps do not need registry entries to be pre-created. If you
; don't know what the registry is or if you need to use it, then chances are
; you don't need a [Registry] section.

[Registry]
; Start "Software\My Company\My Program" keys under HKEY_CURRENT_USER
; and HKEY_LOCAL_MACHINE. The flags tell it to always delete the
; "My Program" keys upon uninstall, and delete the "My Company" keys
; if there is nothing left in them.
Root: HKCU; Subkey: "Software\Tangenta org"; Flags: uninsdeletekeyifempty
Root: HKCU; Subkey: "Software\Tangenta org\Tangenta"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Tangenta org"; Flags: uninsdeletekeyifempty
Root: HKLM; Subkey: "Software\Tangenta org\Tangenta"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Tangenta org\Tangenta\Settings"; ValueType: string; ValueName: "Path"; ValueData: "{app}"
