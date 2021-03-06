;Tangenta installation script
;Written by Damjan Strucl Hrncic <mailto:dstrucl@gmail.com>
;
;Requires NSIS >= 3.00
;--------------------------------
; Build environment
  !define top_srcdir @top_srcdir@
  !define srcdir @srcdir@
  !define VERSION "1.0.0.1"
  !addplugindir @srcdir@
;--------------------------------
;General

  ;Name and file
  Name "Tangenta ${VERSION}"
  OutFile "Tangenta_001_setup.exe"

  SetCompressor /SOLID LZMA

  ;Default installation folder
  ;InstallDir "$PROGRAMFILES\Tangenta"
  InstallDir "C:\Tangenta"

  ;Get installation folder from registry if available
  InstallDirRegKey HKLM "Software\Tangenta" ""

  RequestExecutionLevel user

;--------------------------------
; Libtool executable target path

;  !include libtoolexecutablesubdir.nsh
;  !ifndef LT_EXEDIR
;    !define LT_EXEDIR ""
;  !endif
;--------------------------------
;Include Modern UI and functions

  !include "MUI2.nsh"
  !include "WordFunc.nsh"
  !include Library.nsh
  !include "WinVer.nsh"
  !include "FileFunc.nsh"
  !include "Memento.nsh"

;--------------------------------
;Required functions

  !insertmacro GetParameters
  !insertmacro GetOptions
  !insertmacro un.GetParameters
  !insertmacro un.GetOptions

;--------------------------------
;Variables

  Var MUI_TEMP
  Var STARTMENU_FOLDER
  Var PREVIOUS_INSTALLDIR
  Var PREVIOUS_VERSION
  Var PREVIOUS_VERSION_STATE
  Var REINSTALL_UNINSTALL
  Var REINSTALL_UNINSTALLBUTTON
  Var ALL_USERS_DEFAULT
  Var ALL_USERS
  Var ALL_USERS_BUTTON
  Var IS_ADMIN
  Var USERNAME

;--------------------------------
;Interface Settings

  !define MUI_ICON ".\resources\TangentaInstaller_Icon.ico"
  !define MUI_UNICON ".\resources\TangentaUninstaller_Icon.ico"
  !define MUI_ABORTWARNING

;--------------------------------
;Memento settings

!define MEMENTO_REGISTRY_ROOT SHELL_CONTEXT
!define MEMENTO_REGISTRY_KEY "Software\Tangenta Invoice"

;--------------------------------
;Pages

  Page custom PageReinstall PageLeaveReinstall
  Page custom PageAllUsers PageLeaveAllUsers

  !define MUI_PAGE_CUSTOMFUNCTION_PRE PageComponentsPre
  !insertmacro MUI_PAGE_COMPONENTS

  !define MUI_PAGE_CUSTOMFUNCTION_PRE PageDirectoryPre
  !insertmacro MUI_PAGE_DIRECTORY

  ;Start Menu Folder Page Configuration
  !define MUI_STARTMENUPAGE_REGISTRY_ROOT "SHCTX"
  !define MUI_STARTMENUPAGE_REGISTRY_KEY "Software\Tangenta Invoice"
  !define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Startmenu"
  !define MUI_STARTMENUPAGE_DEFAULTFOLDER "Tangenta Invoice"

  !define MUI_PAGE_CUSTOMFUNCTION_PRE PageStartmenuPre
  !insertmacro MUI_PAGE_STARTMENU Application $STARTMENU_FOLDER

  !define MUI_PAGE_CUSTOMFUNCTION_SHOW PageInstfilesShow
  !define MUI_PAGE_CUSTOMFUNCTION_LEAVE PostInstPage
  
  !insertmacro MUI_PAGE_INSTFILES

;  !define MUI_FINISHPAGE_RUN_FUNCTION CustomFinishRun
  !define MUI_FINISHPAGE_RUN_TEXT "&Start Tangenta now"
  !define MUI_FINISHPAGE_RUN "$instdir\Tangenta.exe"
  !insertmacro MUI_PAGE_FINISH

  !define MUI_PAGE_CUSTOMFUNCTION_PRE un.ConfirmPagePre
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  !define MUI_PAGE_CUSTOMFUNCTION_PRE un.FinishPagePre
  !insertmacro MUI_UNPAGE_FINISH

Function GetUserInfo
  ClearErrors
  UserInfo::GetName
  ${If} ${Errors}
    StrCpy $IS_ADMIN 1
    Return
  ${EndIf}

  Pop $USERNAME
  UserInfo::GetAccountType
  Pop $R0
  ${Switch} $R0
    ${Case} "Admin"
    ${Case} "Power"
      StrCpy $IS_ADMIN 1
      ${Break}
    ${Default}
      StrCpy $IS_ADMIN 0
      ${Break}
  ${EndSwitch}

FunctionEnd

Function UpdateShellVarContext

  ${If} $ALL_USERS == 1
    SetShellVarContext all
  ${Else}
    SetShellVarContext current
  ${EndIf}

FunctionEnd

Function ReadAllUsersCommandline

  ${GetParameters} $R0

  ${GetOptions} $R0 "/user" $R1

  ${Unless} ${Errors}
    ${If} $R1 == "current"
    ${OrIf} $R1 == "=current"
      StrCpy $ALL_USERS 0
    ${ElseIf} $R1 == "all"
    ${OrIf} $R1 == "=all"
      StrCpy $ALL_USERS 1
    ${Else}
      MessageBox MB_ICONSTOP "Invalid option for /user. Has to be either /user=all or /user=current" /SD IDOK
      Abort
    ${EndIf}
  ${EndUnless}
  Call UpdateShellVarContext

FunctionEnd

Function CheckPrevInstallDirExists

  ${If} $PREVIOUS_INSTALLDIR != ""

    ; Make sure directory is valid
    Push $R0
    Push $R1
    StrCpy $R0 "$PREVIOUS_INSTALLDIR" "" -1
    ${If} $R0 == '\'
    ${OrIf} $R0 == '/'
      StrCpy $R0 $PREVIOUS_INSTALLDIR*.*
    ${Else}
      StrCpy $R0 $PREVIOUS_INSTALLDIR\*.*
    ${EndIf}
    ${IfNot} ${FileExists} $R0
      StrCpy $PREVIOUS_INSTALLDIR ""
    ${EndIf}
    Pop $R1
    Pop $R0

  ${EndIf}

FunctionEnd

Function ReadPreviousVersion

  ReadRegStr $PREVIOUS_INSTALLDIR HKLM "Software\Tangenta Invoice" ""

  Call CheckPrevInstallDirExists

  ${If} $PREVIOUS_INSTALLDIR != ""
   ;Detect version
    ReadRegStr $PREVIOUS_VERSION HKLM "Software\Tangenta Invoice" "Version"
    ${If} $PREVIOUS_VERSION != ""
	  StrCpy $ALL_USERS 1
      SetShellVarContext all
      return
    ${EndIf}
  ${EndIf}

  ReadRegStr $PREVIOUS_INSTALLDIR HKCU "Software\Tangenta Invoice" ""

  Call CheckPrevInstallDirExists

  ${If} $PREVIOUS_INSTALLDIR != ""
      ;Detect version
    ReadRegStr $PREVIOUS_VERSION HKCU "Software\Tangenta Invoice" "Version"
    ${If} $PREVIOUS_VERSION != ""
      StrCpy $ALL_USERS 0
      SetShellVarContext current
      return
    ${EndIf}
  ${EndIf}

FunctionEnd

Function LoadPreviousSettings

  ; Component selection
  ${MementoSectionRestore}

  ; Startmenu
  !define ID "Application"

  !ifdef MUI_STARTMENUPAGE_${ID}_REGISTRY_ROOT & MUI_STARTMENUPAGE_${ID}_REGISTRY_KEY & MUI_STARTMENUPAGE_${ID}_REGISTRY_VALUENAME

    ReadRegStr $mui.StartMenuPage.RegistryLocation "${MUI_STARTMENUPAGE_${ID}_REGISTRY_ROOT}" "${MUI_STARTMENUPAGE_${ID}_REGISTRY_KEY}" "${MUI_STARTMENUPAGE_${ID}_REGISTRY_VALUENAME}"

    ${if} $mui.StartMenuPage.RegistryLocation != ""
	  StrCpy "$STARTMENU_FOLDER" $mui.StartMenuPage.RegistryLocation
    ${else}
      StrCpy "$STARTMENU_FOLDER" ""
    ${endif}

    !undef ID

  !endif

  ${If} $PREVIOUS_INSTALLDIR != ""
      StrCpy $INSTDIR $PREVIOUS_INSTALLDIR
  ${EndIf}

FunctionEnd

Function .onInit

  ${Unless} ${AtLeastWin2000}
    MessageBox MB_YESNO|MB_ICONSTOP "Unsupported operating system.$\nTangenta ${VERSION} requires at least Windows XP and may not work correctly on your system.$\nDo you really want to continue with the installation?" /SD IDNO IDYES installonoldwindows
    Abort
installonoldwindows:
  ${EndUnless}

  ;UAC::RunElevated

  ;StrCmp 1223 $0 UAC_ElevationAborted ; UAC dialog aborted by user?
  ;StrCmp 0 $0 0 UAC_Err ; Error?
  ;StrCmp 1 $1 0 UAC_Success ;Are we the real deal or just the wrapper?
  ;Quit
;UAC_Err:
 ; MessageBox mb_iconstop "Could not elevate process (errorcode $0), continuing with normal user privileges." /SD IDOK
;UAC_ElevationAborted:
;UAC_Success:

  Call GetUserInfo

  ; Initialize $ALL_USERS with default value
  ${If} $IS_ADMIN == 1
    StrCpy $ALL_USERS 1
  ${Else}
    StrCpy $ALL_USERS 0
  ${EndIf}
  Call UpdateShellVarContext

  ; See if previous version exists
  ; This can change ALL_USERS
  Call ReadPreviousVersion

  ; Load _all_ previous settings.
  ; Need to do it now as up to now, $ALL_USERS was possibly reflecting a
  ; previous installation. After this call, $ALL_USERS reflects the requested
  ; installation mode for this installation.
  Call LoadPreviousSettings

  Call ReadAllUsersCommandline

  ${If} $ALL_USERS == 1
    ${If} $IS_ADMIN == 0

      ${If} $PREVIOUS_VERSION != ""
	    MessageBox MB_ICONSTOP "Tangenta has been previously installed for all users.$\nPlease restart the installer with Administrator privileges." /SD IDOK
        Abort
      ${Else}
        MessageBox MB_ICONSTOP "Cannot install for all users.$\nPlease restart the installer with Administrator privileges." /SD IDOK
        Abort
      ${EndIf}
    ${EndIf}
  ${EndIf}

  ${Unless} $PREVIOUS_VERSION == ""

    Push "${VERSION}"
    Push $PREVIOUS_VERSION
    Call TangentaVersionCompare

  ${EndUnless}

  StrCpy $ALL_USERS_DEFAULT $ALL_USERS

FunctionEnd

Function TangentaVersionCompare

  Exch $1
  Exch
  Exch $0

  Push $2
  Push $3
  Push $4

versioncomparebegin:
  ${If} $0 == ""
  ${AndIf} $1 == ""
    StrCpy $PREVIOUS_VERSION_STATE "same"
    goto versioncomparedone
  ${EndIf}

  StrCpy $2 0
  StrCpy $3 0

  ; Parse rc / beta suffixes for segments
  StrCpy $4 $0 2
  ${If} $4 == "rc"
    StrCpy $2 100
    StrCpy $0 $0 "" 2
  ${Else}
    StrCpy $4 $0 4
    ${If} $4 == "beta"
      StrCpy $0 $0 "" 4
    ${Else}
      StrCpy $2 10000
    ${EndIf}
  ${EndIf}

  StrCpy $4 $1 2
  ${If} $4 == "rc"
    StrCpy $3 100
    StrCpy $1 $1 "" 2
  ${Else}
    StrCpy $4 $1 4
    ${If} $4 == "beta"
      StrCpy $1 $1 "" 4
    ${Else}
      StrCpy $3 10000
    ${EndIf}
  ${EndIf}

split1loop:

  StrCmp $0 "" split1loopdone
  StrCpy $4 $0 1
  StrCpy $0 $0 "" 1
  StrCmp $4 "." split1loopdone
  StrCmp $4 "-" split1loopdone
  StrCpy $2 $2$4
  goto split1loop
split1loopdone:

split2loop:

  StrCmp $1 "" split2loopdone
  StrCpy $4 $1 1
  StrCpy $1 $1 "" 1
  StrCmp $4 "." split2loopdone
  StrCmp $4 "-" split2loopdone
  StrCpy $3 $3$4
  goto split2loop
split2loopdone:

  ${If} $2 > $3
    StrCpy $PREVIOUS_VERSION_STATE "newer"
  ${ElseIf} $3 > $2
    StrCpy $PREVIOUS_VERSION_STATE "older"
  ${Else}
    goto versioncomparebegin
  ${EndIf}


versioncomparedone:

  Pop $4
  Pop $3
  Pop $2
  Pop $1
  Pop $0

FunctionEnd

Function PageReinstall

  ${If} $PREVIOUS_VERSION == ""
    Abort
  ${EndIf}

  nsDialogs::Create /NOUNLOAD 1018
  Pop $0

  ${If} $PREVIOUS_VERSION_STATE == "newer"

    !insertmacro MUI_HEADER_TEXT "Already Installed" "Choose how you want to install Tangenta."
    nsDialogs::CreateItem /NOUNLOAD STATIC ${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS} 0 0 0 100% 40 "An older version of Tangenta is installed on your system. Select the operation you want to perform and click Next to continue."
    Pop $R0
    nsDialogs::CreateItem /NOUNLOAD BUTTON ${BS_AUTORADIOBUTTON}|${BS_VCENTER}|${BS_MULTILINE}|${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS}|${WS_GROUP}|${WS_TABSTOP} 0 10 55 100% 30 "Upgrade Tangenta using previous settings (recommended)"
    Pop $REINSTALL_UNINSTALLBUTTON
    nsDialogs::CreateItem /NOUNLOAD BUTTON ${BS_AUTORADIOBUTTON}|${BS_TOP}|${BS_MULTILINE}|${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS} 0 10 85 100% 50 "Change settings (advanced)"
    Pop $R0

    ${If} $REINSTALL_UNINSTALL == ""
      StrCpy $REINSTALL_UNINSTALL 1
    ${EndIf}

  ${ElseIf} $PREVIOUS_VERSION_STATE == "older"

    !insertmacro MUI_HEADER_TEXT "Already Installed" "Choose how you want to install Tangenta."
    nsDialogs::CreateItem /NOUNLOAD STATIC ${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS} 0 0 0 100% 40 "A newer version of Tangenta is already installed! It is not recommended that you downgrade to an older version. Select the operation you want to perform and click Next to continue."
    Pop $R0
    nsDialogs::CreateItem /NOUNLOAD BUTTON ${BS_AUTORADIOBUTTON}|${BS_VCENTER}|${BS_MULTILINE}|${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS}|${WS_GROUP}|${WS_TABSTOP} 0 10 55 100% 30 "Downgrade FileZilla using previous settings (recommended)"
    Pop $REINSTALL_UNINSTALLBUTTON
    nsDialogs::CreateItem /NOUNLOAD BUTTON ${BS_AUTORADIOBUTTON}|${BS_TOP}|${BS_MULTILINE}|${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS} 0 10 85 100% 50 "Change settings (advanced)"
    Pop $R0

    ${If} $REINSTALL_UNINSTALL == ""
      StrCpy $REINSTALL_UNINSTALL 1
    ${EndIf}

  ${ElseIf} $PREVIOUS_VERSION_STATE == "same"

    !insertmacro MUI_HEADER_TEXT "Already Installed" "Choose the maintenance option to perform."
    nsDialogs::CreateItem /NOUNLOAD STATIC ${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS} 0 0 0 100% 40 "Tangenta ${VERSION} is already installed. Select the operation you want to perform and click Next to continue."
    Pop $R0
    nsDialogs::CreateItem /NOUNLOAD BUTTON ${BS_AUTORADIOBUTTON}|${BS_VCENTER}|${BS_MULTILINE}|${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS}|${WS_GROUP}|${WS_TABSTOP} 0 10 55 100% 30 "Add/Remove/Reinstall components"
    Pop $R0
    nsDialogs::CreateItem /NOUNLOAD BUTTON ${BS_AUTORADIOBUTTON}|${BS_TOP}|${BS_MULTILINE}|${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS} 0 10 85 100% 50 "Uninstall Tangenta"
    Pop $REINSTALL_UNINSTALLBUTTON

    ${If} $REINSTALL_UNINSTALL == ""
      StrCpy $REINSTALL_UNINSTALL 2
    ${EndIf}

  ${Else}

    MessageBox MB_ICONSTOP "Unknown value of PREVIOUS_VERSION_STATE, aborting" /SD IDOK
    Abort

  ${EndIf}

  ${If} $REINSTALL_UNINSTALL == "1"
    SendMessage $REINSTALL_UNINSTALLBUTTON ${BM_SETCHECK} 1 0
  ${Else}
    SendMessage $R0 ${BM_SETCHECK} 1 0
  ${EndIf}

  nsDialogs::Show

FunctionEnd

Function RunUninstaller

  ${If} $ALL_USERS_DEFAULT == 1
    ReadRegStr $R1 HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "UninstallString"
  ${Else}
    ReadRegStr $R1 HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "UninstallString"
  ${EndIf}

  ${If} $R1 == ""
    Return
  ${EndIf}

  ;Run uninstaller
  HideWindow

  ClearErrors

  ${If} $PREVIOUS_VERSION_STATE == "same"
  ${AndIf} $REINSTALL_UNINSTALL == "1"
    ExecWait '$R1 _?=$INSTDIR'
  ${Else}
    ExecWait '$R1 /frominstall _?=$INSTDIR'
  ${EndIf}

  IfErrors no_remove_uninstaller

  IfFileExists "$INSTDIR\uninstall.exe" 0 no_remove_uninstaller

    Delete "$R1"
	RMDir $INSTDIR\Settings
    RMDir $INSTDIR

 no_remove_uninstaller:

FunctionEnd

Function PageLeaveReinstall

  SendMessage $REINSTALL_UNINSTALLBUTTON ${BM_GETCHECK} 0 0 $R0
  ${If} $R0 == 1
    ; Option to uninstall old version selected
    StrCpy $REINSTALL_UNINSTALL 1
  ${Else}
    ; Custom up/downgrade or add/remove/reinstall
    StrCpy $REINSTALL_UNINSTALL 2
  ${EndIf}

  ${If} $REINSTALL_UNINSTALL == 1

    ${If} $PREVIOUS_VERSION_STATE == "same"

      Call RunUninstaller
      Quit

    ${Else}

      ; Need to reload defaults. User could have
      ; chosen custom, change something, went back and selected
      ; the express option.
      StrCpy $ALL_USERS $ALL_USERS_DEFAULT
      Call UpdateShellVarContext
      Call LoadPreviousSettings

    ${EndIf}

  ${EndIf}

FunctionEnd

Function PageAllUsers

  ${If} $REINSTALL_UNINSTALL == 1
    ; Keep same settings
    Abort
  ${EndIf}

  !insertmacro MUI_HEADER_TEXT "Choose Installation Options" "Who should this application be installed for?"

  nsDialogs::Create /NOUNLOAD 1018
  Pop $0

  nsDialogs::CreateItem /NOUNLOAD STATIC ${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS} 0 0 0 100% 30 "Please select whether you wish to make this software available to all users or just yourself."
  Pop $R0

  ${If} $IS_ADMIN == 1
    StrCpy $R2 ${BS_AUTORADIOBUTTON}|${BS_VCENTER}|${BS_MULTILINE}|${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS}|${WS_GROUP}|${WS_TABSTOP}
  ${Else}
    StrCpy $R2 ${BS_AUTORADIOBUTTON}|${BS_VCENTER}|${BS_MULTILINE}|${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS}|${WS_GROUP}|${WS_TABSTOP}|${WS_DISABLED}
  ${EndIf}
  nsDialogs::CreateItem /NOUNLOAD BUTTON $R2 0 10 55 100% 30 "&Anyone who uses this computer (all users)"
  Pop $ALL_USERS_BUTTON

  StrCpy $R2 ${BS_AUTORADIOBUTTON}|${BS_TOP}|${BS_MULTILINE}|${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS}

  ${If} $USERNAME != ""
  nsDialogs::CreateItem /NOUNLOAD BUTTON $R2 0 10 85 100% 50 "&Only for me ($USERNAME)"
  ${Else}
    nsDialogs::CreateItem /NOUNLOAD BUTTON $R2 0 10 85 100% 50 "&Only for me"
  ${EndIf}
  Pop $R0

  ${If} $PREVIOUS_VERSION != ""
    ${If} $ALL_USERS_DEFAULT == 1
      nsDialogs::CreateItem /NOUNLOAD STATIC ${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS} 0 0 -30 100% 30 "Tangenta has been previously installed for all users."
    ${Else}
      nsDialogs::CreateItem /NOUNLOAD STATIC ${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS} 0 0 -30 100% 30 "Tangenta has been previously installed for this user only."
    ${EndIf}
  ${Else}
    nsDialogs::CreateItem /NOUNLOAD STATIC ${WS_VISIBLE}|${WS_CHILD}|${WS_CLIPSIBLINGS} 0 0 -30 100% 30 "Installation for all users requires Administrator privileges."
  ${EndIf}
  Pop $R1

  ${If} $ALL_USERS == "1"
    SendMessage $ALL_USERS_BUTTON ${BM_SETCHECK} 1 0
  ${Else}
    SendMessage $R0 ${BM_SETCHECK} 1 0
  ${EndIf}

  nsDialogs::Show

FunctionEnd

Function PageLeaveAllUsers

  SendMessage $ALL_USERS_BUTTON ${BM_GETCHECK} 0 0 $R0
  ${If} $R0 == 0
    StrCpy $ALL_USERS "0"
  ${Else}
    StrCpy $ALL_USERS "1"
  ${EndIf}
  Call UpdateShellVarContext

FunctionEnd

Function PageComponentsPre

  ${If} $REINSTALL_UNINSTALL == 1

    Abort

  ${EndIf}

FunctionEnd

Function PageDirectoryPre

  ${If} $REINSTALL_UNINSTALL == "1"

    Abort

  ${EndIf}

FunctionEnd

Function PageStartmenuPre

  ${If} $REINSTALL_UNINSTALL == "1"

    ${If} "$STARTMENU_FOLDER" == ""

      StrCpy "$STARTMENU_FOLDER" ">"

    ${EndIf}

    Abort

  ${EndIf}

FunctionEnd

Function PageInstfilesShow

  ${If} $REINSTALL_UNINSTALL != ""

    Call RunUninstaller
    BringToFront

  ${EndIf}

FunctionEnd

Function .OnInstFailed

;  UAC_unicode::Unload

FunctionEnd

Function .onInstSuccess

  ${MementoSectionSave}

;  UAC_unicode::Unload

FunctionEnd

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Tangenta Invoice" SecMain

  SectionIn 1 RO

  SetOutPath "$INSTDIR"

  ;<FilesToInstall>

;--- Project Libraries -- 

	File ".\bin\AnyCPU\Release\Check.dll"
	File ".\bin\AnyCPU\Release\CodeTables.dll"
	File ".\bin\AnyCPU\Release\ColorSettings.dll"
	File ".\bin\AnyCPU\Release\ComboBox_Recent.dll"
	File ".\bin\AnyCPU\Release\CommandLineHelp.dll"
	File ".\bin\AnyCPU\Release\Country.dll"
	File ".\bin\AnyCPU\Release\Crom.Controls.dll"
	File ".\bin\AnyCPU\Release\Cyotek.Windows.Forms.ColorPicker.dll"
	File ".\bin\AnyCPU\Release\DataGridViewDisableButtonCell.dll"
	File ".\bin\AnyCPU\Release\DataGridViewWithRowNumberHeaders.dll"
	File ".\bin\AnyCPU\Release\DataGridView_2xls.dll"
	File ".\bin\AnyCPU\Release\DataGridView_2xls_base.dll"
	File ".\bin\AnyCPU\Release\DB.dll"
	File ".\bin\AnyCPU\Release\DBConnectionControl40.dll"
	File ".\bin\AnyCPU\Release\DBConnectionControl_Settings.dll"
	File ".\bin\AnyCPU\Release\DBTypes.dll"
	File ".\bin\AnyCPU\Release\DigitalRune.Windows.TextEditor.dll"
	File ".\bin\AnyCPU\Release\DynEditControls.dll"
	File ".\bin\AnyCPU\Release\EWSoftware.ListControls.dll"
	File ".\bin\AnyCPU\Release\Excell_Export.dll"
	File ".\bin\AnyCPU\Release\Excell_Export_base.dll"
	File ".\bin\AnyCPU\Release\FastColoredTextBox.dll"
	File ".\bin\AnyCPU\Release\FiscalVerificationOfInvoices_SLO.dll"
	File ".\bin\AnyCPU\Release\Form_Discount.dll"
	File ".\bin\AnyCPU\Release\Global.dll"
	File ".\bin\AnyCPU\Release\Gma.QrCodeNet.Encoding.dll"
	File ".\bin\AnyCPU\Release\GongShell.dll"
	File ".\bin\AnyCPU\Release\HtmlDoc.dll"
	File ".\bin\AnyCPU\Release\HtmlRenderer.dll"
	File ".\bin\AnyCPU\Release\HtmlRenderer.WinForms.dll"
	File ".\bin\AnyCPU\Release\HUDCMS.dll"
	File ".\bin\AnyCPU\Release\IniFile.dll"
	File ".\bin\AnyCPU\Release\LanguageControl.dll"
	File ".\bin\AnyCPU\Release\LogFile.dll"
	File ".\bin\AnyCPU\Release\LoginControl.dll"
	File ".\bin\AnyCPU\Release\MySql.Data.dll"
	File ".\bin\AnyCPU\Release\NavigationButtons.dll"
	File ".\bin\AnyCPU\Release\nunit.framework.dll"
	File ".\bin\AnyCPU\Release\ObjectListView.dll"
	File ".\bin\AnyCPU\Release\oExcel.dll"
	File ".\bin\AnyCPU\Release\OSVer.dll"
	File ".\bin\AnyCPU\Release\Password.dll"
	File ".\bin\AnyCPU\Release\PriseLists.dll"
	File ".\bin\AnyCPU\Release\ProgramDiagnostic.dll"
	File ".\bin\AnyCPU\Release\ProgressForm.dll"
	File ".\bin\AnyCPU\Release\RPC.dll"
	File ".\bin\AnyCPU\Release\SearchLocalNetwork.dll"
	File ".\bin\AnyCPU\Release\SelectFile.dll"
	File ".\bin\AnyCPU\Release\SelectFolder.dll"
	File ".\bin\AnyCPU\Release\SelectGender.dll"
	File ".\bin\AnyCPU\Release\ShopA.dll"
	File ".\bin\AnyCPU\Release\ShopA_dbfunc.dll"
	File ".\bin\AnyCPU\Release\ShopB.dll"
	File ".\bin\AnyCPU\Release\ShopC.dll"
	File ".\bin\AnyCPU\Release\SLOTaxService.dll"
	File ".\bin\AnyCPU\Release\Startup.dll"
	File ".\bin\AnyCPU\Release\StaticLib.dll"
	File ".\bin\AnyCPU\Release\System.Data.SQLite.dll"
	File ".\bin\AnyCPU\Release\System.Management.Automation.dll"
	File ".\bin\AnyCPU\Release\TabStrip.dll"
	File ".\bin\AnyCPU\Release\TangentaDataBaseDef.dll"
	File ".\bin\AnyCPU\Release\TangentaDB.dll"
	File ".\bin\AnyCPU\Release\TangentaPrint.dll"
	File ".\bin\AnyCPU\Release\TangentaSampleDB.dll"
	File ".\bin\AnyCPU\Release\TangentaTableClass.dll"
	File ".\bin\AnyCPU\Release\Tangenta_DefaultPrintTemplates.dll"
	File ".\bin\AnyCPU\Release\TextBoxRecent.dll"
	File ".\bin\AnyCPU\Release\ThreadProcessor.dll"
	File ".\bin\AnyCPU\Release\UniqueControlNames.dll"
	File ".\bin\AnyCPU\Release\UniversalInvoice.dll"
	File ".\bin\AnyCPU\Release\UpgradeDB.dll"
	File ".\bin\AnyCPU\Release\usrc_Group_Handler.dll"
	File ".\bin\AnyCPU\Release\usrc_Item_PageHandler.dll"
	File ".\bin\AnyCPU\Release\uwpfGUI.dll"
	File ".\bin\AnyCPU\Release\XMessage.dll"
    File ".\bin\AnyCPU\Release\Tangenta.exe"

	File ".\bin\AnyCPU\Release\EWSoftware.ListControls.xml"
	File ".\bin\AnyCPU\Release\FastColoredTextBox.xml"
	File ".\bin\AnyCPU\Release\GongShell.xml"
;	File ".\bin\AnyCPU\Release\Cyotek.Windows.Forms.ColorPicker.xml"
	File ".\bin\AnyCPU\Release\ObjectListView.xml"

	File ".\bin\AnyCPU\Release\CodeTables.dll.config"
	File ".\bin\AnyCPU\Release\ColorSettings.dll.config"
	File ".\bin\AnyCPU\Release\ComboBox_Recent.dll.config"
	File ".\bin\AnyCPU\Release\Crom.Controls.dll.config"
	File ".\bin\AnyCPU\Release\DBConnectionControl40.dll.config"
	File ".\bin\AnyCPU\Release\DBConnectionControl_Settings.dll.config"
	File ".\bin\AnyCPU\Release\DBTypes.dll.config"
	File ".\bin\AnyCPU\Release\DynEditControls.dll.config"
	File ".\bin\AnyCPU\Release\FiscalVerificationOfInvoices_SLO.dll.config"
	File ".\bin\AnyCPU\Release\Form_Discount.dll.config"
	File ".\bin\AnyCPU\Release\HUDCMS.dll.config"
	File ".\bin\AnyCPU\Release\LogFile.dll.config"
	File ".\bin\AnyCPU\Release\LoginControl.dll.config"
	File ".\bin\AnyCPU\Release\SearchLocalNetwork.dll.config"
	File ".\bin\AnyCPU\Release\ShopA.dll.config"
	File ".\bin\AnyCPU\Release\ShopB.dll.config"
	File ".\bin\AnyCPU\Release\ShopC.dll.config"
	File ".\bin\AnyCPU\Release\Tangenta.exe.config"
	File ".\bin\AnyCPU\Release\TangentaDB.dll.config"
	File ".\bin\AnyCPU\Release\TangentaPrint.dll.config"

;--- External DLLs -- 

  File "..\..\packages\Security.Cryptography.1.7.2\lib\net35\Security.Cryptography.dll"
  File "..\..\packages\PDFsharp.1.32.2602.0\lib\net20\PdfSharp.dll"
  File "..\..\packages\PDFsharp.1.32.2602.0\lib\net20\PdfSharp.Charting.dll"

;</FilesToInstall>

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\TangentaUninstall.exe"

  WriteRegStr SHCTX "Software\Tangenta Invoice" "" $INSTDIR
  WriteRegStr SHCTX "Software\Tangenta Invoice" "Version" "${VERSION}"

  WriteRegExpandStr SHCTX "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "UninstallString" "$INSTDIR\TangentaUninstall.exe"
  WriteRegExpandStr SHCTX "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "InstallLocation" "$INSTDIR"
  WriteRegStr SHCTX "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "DisplayName" "Tangenta Invoice ${VERSION}"
  WriteRegStr SHCTX "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "DisplayIcon" "$INSTDIR\Tangenta.exe"
  WriteRegStr SHCTX "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "DisplayVersion" "${VERSION}"
  WriteRegStr SHCTX "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "URLInfoAbout" "http://www.tangenta.si/"
  WriteRegStr SHCTX "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "HelpLink" "http://www.tangenta.si"
  WriteRegDWORD SHCTX "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "NoModify" "1"
  WriteRegDWORD SHCTX "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice" "NoRepair" "1"


  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application

  ;Create shortcuts
  SetOutPath "$INSTDIR"
  CreateDirectory "$SMPROGRAMS\$STARTMENU_FOLDER"
  CreateShortCut "$SMPROGRAMS\$STARTMENU_FOLDER\TangentaUninstall.lnk" "$INSTDIR\TangentaUninstall.exe"
  CreateShortCut "$SMPROGRAMS\$STARTMENU_FOLDER\Tangenta.lnk" "$INSTDIR\Tangenta.exe"

  !insertmacro MUI_STARTMENU_WRITE_END

  Push $R0
  StrCpy $R0 "$STARTMENU_FOLDER" 1
  ${if} $R0 == ">"
    ;Write folder to registry
    WriteRegStr "${MUI_STARTMENUPAGE_Application_REGISTRY_ROOT}" "${MUI_STARTMENUPAGE_Application_REGISTRY_KEY}" "${MUI_STARTMENUPAGE_Application_REGISTRY_VALUENAME}" ">"
  ${endif}
  Pop $R0

SectionEnd


;${MementoSection} "Icon sets" SecIconSets

;  !insertmacro INSTALLICONSET cyril
;  !insertmacro INSTALLICONSET blukis
;  !insertmacro INSTALLICONSET lone
;  !insertmacro INSTALLICONSET minimal
;  !insertmacro INSTALLICONSET opencrystal

;${MementoSectionEnd}

;!if "@TANGENTA_LINGUAS@" != ""

;  !macro INSTALLLANGFILE LANG

;     SetOutPath "$INSTDIR\locales\${LANG}"
;     File /oname=filezilla.mo "..\locales\${LANG}.mo"

;  !macroend

;  ${MementoSection} "Language files" SecLang

    ; installlangfiles.nsh is generated by configure and just contains a series of
    ; !insertmacro INSTALLLANGFILE <lang>
;    !include installlangfiles.nsh

  ;${MementoSectionEnd}

;!endif

;${MementoSection} "Shell Extension" SecShellExt

;SetOutPath "$INSTDIR"
;  !define LIBRARY_SHELL_EXTENSION
;  !define LIBRARY_COM
;  !define LIBRARY_IGNORE_VERSION
;  !insertmacro InstallLib REGDLL NOTSHARED REBOOT_PROTECTED ../src/fzshellext/.libs\libfzshellext-0.dll $INSTDIR\fzshellext.dll "$INSTDIR"

;  !define LIBRARY_X64
;  ${If} ${RunningX64}
;    !insertmacro InstallLib REGDLL NOTSHARED REBOOT_PROTECTED "${top_srcdir}/src/fzshellext\fzshellext_64.dll" $INSTDIR\fzshellext_64.dll "$INSTDIR"
;  ${Else}
;    !insertmacro InstallLib DLL NOTSHARED REBOOT_PROTECTED "${top_srcdir}/src/fzshellext\fzshellext_64.dll" $INSTDIR\fzshellext_64.dll "$INSTDIR"
;  ${Endif}
;  !undef LIBRARY_X64

;${MementoSectionEnd}
${MementoUnselectedSection} "Desktop Icon" SecDesktop

  CreateShortCut "$DESKTOP\Tangenta Invoice.lnk" "$INSTDIR\Tangenta.exe" "" "$INSTDIR\Tangenta.exe" 0

${MementoSectionEnd}

${MementoSectionDone}

;--------------------------------
;Functions

Function PostInstPage

  ; Don't advance automatically if details expanded
  FindWindow $R0 "#32770" "" $HWNDPARENT
  GetDlgItem $R0 $R0 1016
  System::Call user32::IsWindowVisible(i$R0)i.s

  Pop $R0
  StrCmp $R0 0 +2
  SetAutoClose false
FunctionEnd

Function CustomFinishRun

;  UAC_unicode::Exec '' '"$INSTDIR/Tangenta.exe"' '' ''

FunctionEnd

;--------------------------------
;Descriptions

  ;Language strings
;  LangString DESC_SecMain ${LANG_ENGLISH} "Required program files."
;  LangString DESC_SecIconSets ${LANG_ENGLISH} "Additional icon sets."
;!if "@FILEZILLA_LINGUAS@" != ""
;  LangString DESC_SecLang ${LANG_ENGLISH} "Language files."
;!endif
;  LangString DESC_SecShellExt ${LANG_ENGLISH} "Shell extension for advanced drag && drop support. Required for drag && drop from FileZilla into Explorer."
  LangString DESC_SecDesktop ${LANG_ENGLISH} "Create desktop icon for Tangenta"

 ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecMain} $(DESC_SecMain)
    !insertmacro MUI_DESCRIPTION_TEXT ${SecIconSets} $(DESC_SecIconSets)
;!if "@FILEZILLA_LINGUAS@" != ""
;    !insertmacro MUI_DESCRIPTION_TEXT ${SecLang} $(DESC_SecLang)
;!endif
;    !insertmacro MUI_DESCRIPTION_TEXT ${SecShellExt} $(DESC_SecShellExt)
    !insertmacro MUI_DESCRIPTION_TEXT ${SecDesktop} $(DESC_SecDesktop)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Variables

Var un.REMOVE_ALL_USERS
Var un.REMOVE_CURRENT_USER

;--------------------------------
;Uninstaller Functions

Function un.GetUserInfo
  ClearErrors
  UserInfo::GetName
  ${If} ${Errors}
    StrCpy $IS_ADMIN 1
    Return
  ${EndIf}

  Pop $USERNAME
  UserInfo::GetAccountType
  Pop $R0
  ${Switch} $R0
    ${Case} "Admin"
    ${Case} "Power"
      StrCpy $IS_ADMIN 1
      ${Break}
    ${Default}
      StrCpy $IS_ADMIN 0
      ${Break}
  ${EndSwitch}

FunctionEnd

Function un.ReadPreviousVersion

  ReadRegStr $R0 HKLM "Software\Tangenta Invoice" ""

  ${If} $R0 != ""
   ;Detect version
    ReadRegStr $R2 HKLM "Software\Tangenta Invoice" "Version"
    ${If} $R2 == ""
	  StrCpy $R0 ""
    ${EndIf}
  ${EndIf}

  ReadRegStr $R1 HKCU "Software\Tangenta Invoice" ""

  ${If} $R1 != ""
    ;Detect version
    ReadRegStr $R2 HKCU "Software\Tangenta Invoice" "Version"
    ${If} $R2 == ""
      StrCpy $R1 ""
    ${EndIf}
  ${EndIf}

  ${If} $R1 == $INSTDIR
    Strcpy $un.REMOVE_CURRENT_USER 1
  ${EndIf}
  ${If} $R0 == $INSTDIR
    Strcpy $un.REMOVE_ALL_USERS 1
  ${EndIf}
  ${If} $un.REMOVE_CURRENT_USER != 1
    ${AndIf} $un.REMOVE_ALL_USERS != 1
    ${If} $R1 != ""
	  Strcpy $un.REMOVE_CURRENT_USER 1
      ${If} $R0 == $R1
        Strcpy $un.REMOVE_ALL_USERS 1
      ${EndIf}
    ${Else}
      StrCpy $un.REMOVE_ALL_USERS = 1
    ${EndIf}
  ${EndIf}

FunctionEnd

Function un.onInit

  Call un.GetUserInfo
  Call un.ReadPreviousVersion

  ${If} $un.REMOVE_ALL_USERS == 1
  ${AndIf} $IS_ADMIN == 0
    MessageBox MB_ICONSTOP "Tangenta has been installed for all users.$\nPlease restart the TangentaUninstaller with Administrator privileges to remove it." /SD IDOK
    Abort
  ${EndIf}

FunctionEnd

Function un.RemoveStartmenu

  !insertmacro MUI_STARTMENU_GETFOLDER Application $MUI_TEMP

  Delete "$SMPROGRAMS\$MUI_TEMP\TangentaUninstall.lnk"
  Delete "$SMPROGRAMS\$MUI_TEMP\Tangenta.lnk"

  ;Delete empty start menu parent diretories
  StrCpy $MUI_TEMP "$SMPROGRAMS\$MUI_TEMP"

  startMenuDeleteLoop:
    RMDir $MUI_TEMP
    GetFullPathName $MUI_TEMP "$MUI_TEMP\.."

    IfErrors startMenuDeleteLoopDone

    StrCmp $MUI_TEMP $SMPROGRAMS startMenuDeleteLoopDone startMenuDeleteLoop
  startMenuDeleteLoopDone:

FunctionEnd

Function un.ConfirmPagePre

  ${un.GetParameters} $R0

  ${un.GetOptions} $R0 "/frominstall" $R1
  ${Unless} ${Errors}
    Abort
  ${EndUnless}

FunctionEnd

Function un.FinishPagePre

  ${un.GetParameters} $R0

  ${un.GetOptions} $R0 "/frominstall" $R1
  ${Unless} ${Errors}
    SetRebootFlag false
    Abort
  ${EndUnless}

FunctionEnd

;--------------------------------
;Uninstaller Section

;!if "@FILEZILLA_LINGUAS@" != ""

;  !macro UNINSTALLLANGFILE LANG

;    Delete "$INSTDIR\locales\${LANG}\filezilla.mo"
;    RMDir "$INSTDIR\locales\${LANG}"

;  !macroend

;!endif

;!macro UNINSTALLICONSET SET

;  Delete "$INSTDIR\resources\${SET}\theme.xml"
;  Delete "$INSTDIR\resources\${SET}\16x16\*.png"
;  Delete "$INSTDIR\resources\${SET}\32x32\*.png"
;  Delete "$INSTDIR\resources\${SET}\48x48\*.png"
;  RMDir "$INSTDIR\resources\${SET}\16x16"
;  RMDir "$INSTDIR\resources\${SET}\32x32"
;  RMDir "$INSTDIR\resources\${SET}\48x48"
;  RMDir "$INSTDIR\resources\${SET}"

;!macroend

Section "Uninstall"

 ; !insertmacro UnInstallLib REGDLL NOTSHARED REBOOT_PROTECTED "$INSTDIR\fzshellext.dll"

;  !define LIBRARY_X64
;  ${If} ${RunningX64}
;    !insertmacro UnInstallLib REGDLL NOTSHARED REBOOT_PROTECTED "$INSTDIR\fzshellext_64.dll"
;  ${Else}
;    !insertmacro UnInstallLib DLL NOTSHARED REBOOT_PROTECTED "$INSTDIR\fzshellext_64.dll"
;  ${Endif}
;  !undef LIBRARY_X64

 ;<FilesToUninstall>

;--- Remove Project Libraries -- 

  Delete "C:\Tangenta\Tangenta.exe"
  Delete "C:\Tangenta\Check.dll"
  Delete "C:\Tangenta\CodeTables.dll"
  Delete "C:\Tangenta\ColorSettings.dll"
  Delete "C:\Tangenta\ComboBox_Recent.dll"
  Delete "C:\Tangenta\CommandLineHelp.dll"
  Delete "C:\Tangenta\Country.dll"
  Delete "C:\Tangenta\Crom.Controls.dll"
  Delete "C:\Tangenta\Cyotek.Windows.Forms.ColorPicker.dll"
  Delete "C:\Tangenta\DataGridViewDisableButtonCell.dll"
  Delete "C:\Tangenta\DataGridViewWithRowNumberHeaders.dll"
  Delete "C:\Tangenta\DataGridView_2xls.dll"
  Delete "C:\Tangenta\DataGridView_2xls_base.dll"
  Delete "C:\Tangenta\DB.dll"
  Delete "C:\Tangenta\DBConnectionControl40.dll"
  Delete "C:\Tangenta\DBConnectionControl_Settings.dll"
  Delete "C:\Tangenta\DBTypes.dll"
  Delete "C:\Tangenta\DigitalRune.Windows.TextEditor.dll"
  Delete "C:\Tangenta\DynEditControls.dll"
  Delete "C:\Tangenta\EWSoftware.ListControls.dll"
  Delete "C:\Tangenta\Excell_Export.dll"
  Delete "C:\Tangenta\Excell_Export_base.dll"
  Delete "C:\Tangenta\FastColoredTextBox.dll"
  Delete "C:\Tangenta\FiscalVerificationOfInvoices_SLO.dll"
  Delete "C:\Tangenta\Form_Discount.dll"
  Delete "C:\Tangenta\Global.dll"
  Delete "C:\Tangenta\Gma.QrCodeNet.Encoding.dll"
  Delete "C:\Tangenta\GongShell.dll"
  Delete "C:\Tangenta\HtmlDoc.dll"
  Delete "C:\Tangenta\HtmlRenderer.dll"
  Delete "C:\Tangenta\HtmlRenderer.WinForms.dll"
  Delete "C:\Tangenta\HUDCMS.dll"
  Delete "C:\Tangenta\IniFile.dll"
  Delete "C:\Tangenta\LanguageControl.dll"
  Delete "C:\Tangenta\LogFile.dll"
  Delete "C:\Tangenta\LoginControl.dll"
  Delete "C:\Tangenta\MySql.Data.dll"
  Delete "C:\Tangenta\NavigationButtons.dll"
  Delete "C:\Tangenta\nunit.framework.dll"
  Delete "C:\Tangenta\ObjectListView.dll"
  Delete "C:\Tangenta\oExcel.dll"
  Delete "C:\Tangenta\OSVer.dll"
  Delete "C:\Tangenta\Password.dll"
  Delete "C:\Tangenta\PriseLists.dll"
  Delete "C:\Tangenta\ProgramDiagnostic.dll"
  Delete "C:\Tangenta\ProgressForm.dll"
  Delete "C:\Tangenta\RPC.dll"
  Delete "C:\Tangenta\SearchLocalNetwork.dll"
  Delete "C:\Tangenta\SelectFile.dll"
  Delete "C:\Tangenta\SelectFolder.dll"
  Delete "C:\Tangenta\SelectGender.dll"
  Delete "C:\Tangenta\ShopA.dll"
  Delete "C:\Tangenta\ShopA_dbfunc.dll"
  Delete "C:\Tangenta\ShopB.dll"
  Delete "C:\Tangenta\ShopC.dll"
  Delete "C:\Tangenta\SLOTaxService.dll"
  Delete "C:\Tangenta\Startup.dll"
  Delete "C:\Tangenta\StaticLib.dll"
  Delete "C:\Tangenta\System.Data.SQLite.dll"
  Delete "C:\Tangenta\System.Management.Automation.dll"
  Delete "C:\Tangenta\TabStrip.dll"
  Delete "C:\Tangenta\TangentaDataBaseDef.dll"
  Delete "C:\Tangenta\TangentaDB.dll"
  Delete "C:\Tangenta\TangentaPrint.dll"
  Delete "C:\Tangenta\TangentaSampleDB.dll"
  Delete "C:\Tangenta\TangentaTableClass.dll"
  Delete "C:\Tangenta\Tangenta_DefaultPrintTemplates.dll"
  Delete "C:\Tangenta\TextBoxRecent.dll"
  Delete "C:\Tangenta\ThreadProcessor.dll"
  Delete "C:\Tangenta\UniqueControlNames.dll"
  Delete "C:\Tangenta\UniversalInvoice.dll"
  Delete "C:\Tangenta\UpgradeDB.dll"
  Delete "C:\Tangenta\usrc_Group_Handler.dll"
  Delete "C:\Tangenta\usrc_Item_PageHandler.dll"
  Delete "C:\Tangenta\uwpfGUI.dll"
  Delete "C:\Tangenta\XMessage.dll"

;--- Remove External DLLs -- 

  Delete $INSTDIR\"Security.Cryptography.dll"
  Delete $INSTDIR\"PdfSharp.dll"
  Delete $INSTDIR\"PdfSharp.Charting.dll"

;	Delete $INSTDIR\"Cyotek.Windows.Forms.ColorPicker.xml"
	Delete $INSTDIR\"EWSoftware.ListControls.xml"
	Delete $INSTDIR\"FastColoredTextBox.xml"
	Delete $INSTDIR\"GongShell.xml"
	Delete $INSTDIR\"ObjectListView.xml"
	Delete $INSTDIR\"CodeTables.dll.config"
	Delete $INSTDIR\"ColorSettings.dll.config"
	Delete $INSTDIR\"ComboBox_Recent.dll.config"
	Delete $INSTDIR\"Crom.Controls.dll.config"
	Delete $INSTDIR\"DBConnectionControl40.dll.config"
	Delete $INSTDIR\"DBConnectionControl_Settings.dll.config"
	Delete $INSTDIR\"DBTypes.dll.config"
	Delete $INSTDIR\"DynEditControls.dll.config"
	Delete $INSTDIR\"FiscalVerificationOfInvoices_SLO.dll.config"
	Delete $INSTDIR\"Form_Discount.dll.config"
	Delete $INSTDIR\"HUDCMS.dll.config"
	Delete $INSTDIR\"LogFile.dll.config"
	Delete $INSTDIR\"LoginControl.dll.config"
	Delete $INSTDIR\"SearchLocalNetwork.dll.config"
	Delete $INSTDIR\"ShopA.dll.config"
	Delete $INSTDIR\"ShopB.dll.config"
	Delete $INSTDIR\"ShopC.dll.config"
	Delete $INSTDIR\"Tangenta.exe.config"
	Delete $INSTDIR\"TangentaDB.dll.config"
	Delete $INSTDIR\"TangentaPrint.dll.config

  
;</FilesToUninstall>

;  !insertmacro UNINSTALLICONSET cyril
;  !insertmacro UNINSTALLICONSET blukis
;  !insertmacro UNINSTALLICONSET lone
;  !insertmacro UNINSTALLICONSET minimal
;  !insertmacro UNINSTALLICONSET opencrystal

;!if "@FILEZILLA_LINGUAS@" != ""
  ; uninstalllangfiles.nsh is generated by configure and just contains a series of
  ; !insertmacro UNINSTALLLANGFILE <lang>
;  !include uninstalllangfiles.nsh
;!endif

  Delete "$INSTDIR\TangentaUninstall.exe"

;  Delete "$INSTDIR\docs\fzdefaults.xml.example"

;!if "@FILEZILLA_LINGUAS@" != ""
;  RMDir "$INSTDIR\locales"
;!endif
;  RMDir "$INSTDIR\resources\48x48"
;  RMDir "$INSTDIR\resources\32x32"
;  RMDir "$INSTDIR\resources\16x16"
;  RMDir "$INSTDIR\resources"
;  RMDir "$INSTDIR\docs"
  RMDir "$INSTDIR"

  ${If} $un.REMOVE_ALL_USERS == 1
    SetShellVarContext all
    Call un.RemoveStartmenu

    DeleteRegKey /ifempty HKLM "Software\Tangenta Invoice"
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice"

    Delete "$DESKTOP\Tangenta Invoice.lnk"
  ${EndIf}
  ${If} $un.REMOVE_CURRENT_USER == 1
    SetShellVarContext current
    Call un.RemoveStartmenu

    DeleteRegKey /ifempty HKCU "Software\Tangenta Invoice"
    DeleteRegKey HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tangenta Invoice"

    Delete "$DESKTOP\Tangenta Invoice"
  ${EndIf}

SectionEnd
