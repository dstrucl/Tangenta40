﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBConnectionControl_Settings.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class RemoteDB4 : global::System.Configuration.ApplicationSettingsBase {
        
        private static RemoteDB4 defaultInstance = ((RemoteDB4)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new RemoteDB4())));
        
        public static RemoteDB4 Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public uint RemoteDB_uiDataBaseType {
            get {
                return ((uint)(this["RemoteDB_uiDataBaseType"]));
            }
            set {
                this["RemoteDB_uiDataBaseType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool RemoteDB_bWindowsAuthentication {
            get {
                return ((bool)(this["RemoteDB_bWindowsAuthentication"]));
            }
            set {
                this["RemoteDB_bWindowsAuthentication"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string RemoteDB_DataSource {
            get {
                return ((string)(this["RemoteDB_DataSource"]));
            }
            set {
                this["RemoteDB_DataSource"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string RemoteDB_DataBase {
            get {
                return ((string)(this["RemoteDB_DataBase"]));
            }
            set {
                this["RemoteDB_DataBase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string RemoteDB_UserName {
            get {
                return ((string)(this["RemoteDB_UserName"]));
            }
            set {
                this["RemoteDB_UserName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string RemoteDB_Password {
            get {
                return ((string)(this["RemoteDB_Password"]));
            }
            set {
                this["RemoteDB_Password"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string RemoteDB_strDataBaseFilePath {
            get {
                return ((string)(this["RemoteDB_strDataBaseFilePath"]));
            }
            set {
                this["RemoteDB_strDataBaseFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string RemoteDB_strDataBaseLogFilePath {
            get {
                return ((string)(this["RemoteDB_strDataBaseLogFilePath"]));
            }
            set {
                this["RemoteDB_strDataBaseLogFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int RemoteDB_TryToConnectTimeout_in_seconds {
            get {
                return ((int)(this["RemoteDB_TryToConnectTimeout_in_seconds"]));
            }
            set {
                this["RemoteDB_TryToConnectTimeout_in_seconds"] = value;
            }
        }
    }
}
