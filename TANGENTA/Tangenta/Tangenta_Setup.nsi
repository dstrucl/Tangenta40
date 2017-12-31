; NSIS Modern User Interface

; Include Modern UI
!include "MUI2.nsh"

; General

  ; Name and output file
  Name "Tangenta_Setup"
  OutFile "Output\Tangenta_Setup.exe"

  ; Default installation folder
  InstallDir "$PROGRAMFILES \Tangenta"
  
  ; Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Tangenta" ""

  ; Request application privileges for Windows Vista/7/8/10
  RequestExecutionLevel user

; --------------------------------
; Interface Settings

  !define MUI_ABORTWARNING

; --------------------------------
; Pages

  ;!insertmacro MUI_PAGE_LICENSE "${NSISDIR}\Docs\Modern UI\License.txt"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
; --------------------------------
; Languages
 
  !insertmacro MUI_LANGUAGE "English"

; --------------------------------
; Installer Sections

Section "Tangenta_Setup" SecDummy

  SetOutPath "$INSTDIR"
  
  ; ADD YOUR OWN FILES HERE...
  ;<FilesToInstall>

;--- Project Libraries -- 

  File ".\bin\Release\Check.dll"
  File ".\bin\Release\CodeTables.dll"
  File ".\bin\Release\ComboBox_Recent.dll"
  File ".\bin\Release\CommandLineHelp.dll"
  File ".\bin\Release\Country.dll"
  File ".\bin\Release\Crom.Controls.dll"
  File ".\bin\Release\DataGridViewDisableButtonCell.dll"
  File ".\bin\Release\DataGridViewWithRowNumberHeaders.dll"
  File ".\bin\Release\DataGridView_2xls.dll"
  File ".\bin\Release\DataGridView_2xls_base.dll"
  File ".\bin\Release\DB.dll"
  File ".\bin\Release\DBConnectionControl40.dll"
  File ".\bin\Release\DBConnectionControl_Settings.dll"
  File ".\bin\Release\DBTypes.dll"
  File ".\bin\Release\DigitalRune.Windows.TextEditor.dll"
  File ".\bin\Release\DynEditControls.dll"
  File ".\bin\Release\EWSoftware.ListControls.dll"
  File ".\bin\Release\EWSoftware.ListControls.xml"
  File ".\bin\Release\Excell_Export.dll"
  File ".\bin\Release\Excell_Export_base.dll"
  File ".\bin\Release\FiscalVerificationOfInvoices_SLO.dll"
  File ".\bin\Release\Form_Discount.dll"
  File ".\bin\Release\Gma.QrCodeNet.Encoding.dll"
  File ".\bin\Release\HtmlDoc.dll"
  File ".\bin\Release\HtmlRenderer.dll"
  File ".\bin\Release\HtmlRenderer.WinForms.dll"
  File ".\bin\Release\IniFile.dll"
  File ".\bin\Release\LanguageControl.dll"
  File ".\bin\Release\LogFile.dll"
  File ".\bin\Release\LoginControl.dll"
  File ".\bin\Release\MySql.Data.dll"
  File ".\bin\Release\NavigationButtons.dll"
  File ".\bin\Release\nunit.framework.dll"
  File ".\bin\Release\oExcel.dll"
  File ".\bin\Release\Password.dll"
  File ".\bin\Release\PriseLists.dll"
  File ".\bin\Release\ProgramDiagnostic.dll"
  File ".\bin\Release\ProgressForm.dll"
  File ".\bin\Release\RPC.dll"
  File ".\bin\Release\SearchLocalNetwork.dll"
  File ".\bin\Release\Security.Cryptography.dll"
  File ".\bin\Release\Security.Cryptography.xml"
  File ".\bin\Release\SelectGender.dll"
  File ".\bin\Release\ShopA.dll"
  File ".\bin\Release\ShopA_dbfunc.dll"
  File ".\bin\Release\ShopB.dll"
  File ".\bin\Release\ShopC.dll"
  File ".\bin\Release\SLOTaxService.dll"
  File ".\bin\Release\Startup.dll"
  File ".\bin\Release\StaticLib.dll"
  File ".\bin\Release\System.Data.SQLite.dll"
  File ".\bin\Release\Tangenta.exe"
  File ".\bin\Release\Tangenta.exe.config"
  File ".\bin\Release\TangentaDataBaseDef.dll"
  File ".\bin\Release\TangentaDB.dll"
  File ".\bin\Release\TangentaPrint.dll"
  File ".\bin\Release\TangentaSampleDB.dll"
  File ".\bin\Release\TangentaTableClass.dll"
  File ".\bin\Release\Tangenta_DefaultPrintTemplates.dll"
  File ".\bin\Release\TextBoxRecent.dll"
  File ".\bin\Release\ThreadProcessor.dll"
  File ".\bin\Release\UniversalInvoice.dll"
  File ".\bin\Release\UpgradeDB.dll"
  File ".\bin\Release\usrc_Group_Handler.dll"
  File ".\bin\Release\usrc_Help.dll"
  File ".\bin\Release\usrc_Item_PageHandler.dll"
  File ".\bin\Release\uwpfGUI.dll"
  File ".\bin\Release\XMessage.dll"

;--- External DLLs -- 

  File "..\..\DLL\MySql.Data.dll"
  File "..\..\DLL\oExcel.dll"
  File "..\..\DLL\System.Data.SQLite.dll"
  File "..\..\SLO_FISCAL\common_reference\Gma.QrCodeNet.Encoding.dll"
  File "..\..\SLO_FISCAL\common_reference\nunit.framework.dll"
  File "..\..\packages\Security.Cryptography.1.7.2\lib\net35\Security.Cryptography.dll"
  File "..\..\packages\PDFsharp.1.32.2602.0\lib\net20\PdfSharp.dll"
  File "..\..\packages\PDFsharp.1.32.2602.0\lib\net20\PdfSharp.Charting.dll"

;</FilesToInstall>
  
  ; Store installation folder
  WriteRegStr HKCU "Software\Tangenta" "" $INSTDIR
  
  ; Create uninstaller
  WriteUninstaller "$INSTDIR\TangentaUninstall.exe"

SectionEnd

; --------------------------------
; Descriptions

  ; Language strings
  LangString DESC_SecDummy ${LANG_ENGLISH} "A Tangenta section."

  ; Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecDummy} $(DESC_SecDummy)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

; --------------------------------
; Uninstaller Section

Section "Uninstall"

  ; ADD YOUR OWN FILES HERE...
  ;<FilesToUninstall>

;--- Remove Project Libraries -- 

  Delete $INSTDIR\"Tangenta.exe"
  Delete $INSTDIR\"Check.dll"
  Delete $INSTDIR\"LanguageControl.dll"
  Delete $INSTDIR\"ComboBox_Recent.dll"
  Delete $INSTDIR\"DataGridView_2xls_base.dll"
  Delete $INSTDIR\"Excell_Export_base.dll"
  Delete $INSTDIR\"NavigationButtons.dll"
  Delete $INSTDIR\"usrc_Help.dll"
  Delete $INSTDIR\"CommandLineHelp.dll"
  Delete $INSTDIR\"Country.dll"
  Delete $INSTDIR\"Excell_Export.dll"
  Delete $INSTDIR\"CodeTables.dll"
  Delete $INSTDIR\"Crom.Controls.dll"
  Delete $INSTDIR\"DataGridView_2xls.dll"
  Delete $INSTDIR\"DynEditControls.dll"
  Delete $INSTDIR\"DBTypes.dll"
  Delete $INSTDIR\"DBConnectionControl40.dll"
  Delete $INSTDIR\"IniFile.dll"
  Delete $INSTDIR\"LogFile.dll"
  Delete $INSTDIR\"DigitalRune.Windows.TextEditor.dll"
  Delete $INSTDIR\"RPC.dll"
  Delete $INSTDIR\"ThreadProcessor.dll"
  Delete $INSTDIR\"SearchLocalNetwork.dll"
  Delete $INSTDIR\"ProgramDiagnostic.dll"
  Delete $INSTDIR\"DBConnectionControl_Settings.dll"
  Delete $INSTDIR\"Password.dll"
  Delete $INSTDIR\"TextBoxRecent.dll"
  Delete $INSTDIR\"SelectGender.dll"
  Delete $INSTDIR\"StaticLib.dll"
  Delete $INSTDIR\"usrc_Group_Handler.dll"
  Delete $INSTDIR\"usrc_Item_PageHandler.dll"
  Delete $INSTDIR\"XMessage.dll"
  Delete $INSTDIR\"DB.dll"
  Delete $INSTDIR\"TangentaDataBaseDef.dll"
  Delete $INSTDIR\"TangentaTableClass.dll"
  Delete $INSTDIR\"ProgressForm.dll"
  Delete $INSTDIR\"FiscalVerificationOfInvoices_SLO.dll"
  Delete $INSTDIR\"TangentaDB.dll"
  Delete $INSTDIR\"HtmlRenderer.dll"
  Delete $INSTDIR\"SLOTaxService.dll"
  Delete $INSTDIR\"ShopA_dbfunc.dll"
  Delete $INSTDIR\"Tangenta_DefaultPrintTemplates.dll"
  Delete $INSTDIR\"UniversalInvoice.dll"
  Delete $INSTDIR\"Form_Discount.dll"
  Delete $INSTDIR\"LoginControl.dll"
  Delete $INSTDIR\"DataGridViewWithRowNumberHeaders.dll"
  Delete $INSTDIR\"PriseLists.dll"
  Delete $INSTDIR\"ShopA.dll"
  Delete $INSTDIR\"ShopB.dll"
  Delete $INSTDIR\"ShopC.dll"
  Delete $INSTDIR\"DataGridViewDisableButtonCell.dll"
  Delete $INSTDIR\"Startup.dll"
  Delete $INSTDIR\"TangentaSampleDB.dll"
  Delete $INSTDIR\"TangentaPrint.dll"
  Delete $INSTDIR\"EWSoftware.ListControls.dll"
  Delete $INSTDIR\"HtmlDoc.dll"
  Delete $INSTDIR\"HtmlRendererDemoCommon.dll"
  Delete $INSTDIR\"HtmlRendererWinFormsDemo.exe"
  Delete $INSTDIR\"HtmlRenderer.PdfSharp.dll"
  Delete $INSTDIR\"HtmlRenderer.WinForms.dll"
  Delete $INSTDIR\"UpgradeDB.dll"
  Delete $INSTDIR\"uwpfGUI.dll"

;--- Remove External DLLs -- 

  Delete $INSTDIR\"MySql.Data.dll"
  Delete $INSTDIR\"oExcel.dll"
  Delete $INSTDIR\"System.Data.SQLite.dll"
  Delete $INSTDIR\"Gma.QrCodeNet.Encoding.dll"
  Delete $INSTDIR\"nunit.framework.dll"
  Delete $INSTDIR\"Security.Cryptography.dll"
  Delete $INSTDIR\"PdfSharp.dll"
  Delete $INSTDIR\"PdfSharp.Charting.dll"

;</FilesToUninstall>

  RMDir "$INSTDIR"

  DeleteRegKey /ifempty HKCU "Software\Tangenta"

SectionEnd
