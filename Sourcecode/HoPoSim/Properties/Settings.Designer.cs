﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HoPoSim.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DatabaseDirectory {
            get {
                return ((string)(this["DatabaseDirectory"]));
            }
            set {
                this["DatabaseDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DocumentsDirectory {
            get {
                return ((string)(this["DocumentsDirectory"]));
            }
            set {
                this["DocumentsDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BaseLight")]
        public string UITheme {
            get {
                return ((string)(this["UITheme"]));
            }
            set {
                this["UITheme"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Green")]
        public string UIColor {
            get {
                return ((string)(this["UIColor"]));
            }
            set {
                this["UIColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("fortan AGR / KWF ")]
        public string ApplicationOwner {
            get {
                return ((string)(this["ApplicationOwner"]));
            }
            set {
                this["ApplicationOwner"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Simulator3dExeFile {
            get {
                return ((string)(this["Simulator3dExeFile"]));
            }
            set {
                this["Simulator3dExeFile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Export3dDirectoryPath {
            get {
                return ((string)(this["Export3dDirectoryPath"]));
            }
            set {
                this["Export3dDirectoryPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ExportImgDirectoryPath {
            get {
                return ((string)(this["ExportImgDirectoryPath"]));
            }
            set {
                this["ExportImgDirectoryPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2048")]
        public int ExportImgWidth {
            get {
                return ((int)(this["ExportImgWidth"]));
            }
            set {
                this["ExportImgWidth"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1152")]
        public int ExportImgHeight {
            get {
                return ((int)(this["ExportImgHeight"]));
            }
            set {
                this["ExportImgHeight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ShowBaumartInformationMessages {
            get {
                return ((bool)(this["ShowBaumartInformationMessages"]));
            }
            set {
                this["ShowBaumartInformationMessages"] = value;
            }
        }
    }
}
