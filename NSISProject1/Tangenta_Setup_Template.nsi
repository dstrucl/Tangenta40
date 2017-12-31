; NSIS Modern User Interface

; Include Modern UI
!include "MUI2.nsh"

; General

  ; Name and output file
  Name "Tangenta_Setup"
  OutFile "Output\Tangenta_Setup.exe"

  ; Default installation folder
  InstallDir "$LOCALAPPDATA\Tangenta"
  
  ; Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Tangenta" ""

  ; Request application privileges for Windows Vista/7/8/10
  RequestExecutionLevel user

; --------------------------------
; Interface Settings

  !define MUI_ABORTWARNING

; --------------------------------
; Pages

  !insertmacro MUI_PAGE_LICENSE "${NSISDIR}\Docs\Modern UI\License.txt"
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
  ;</FilesToUninstall>

  RMDir "$INSTDIR"

  DeleteRegKey /ifempty HKCU "Software\Tangenta"

SectionEnd
