﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZonePlayerWpf.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int NumberOfZones {
            get {
                return ((int)(this["NumberOfZones"]));
            }
            set {
                this["NumberOfZones"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("[\"Device1\", \"Device2\", \"Device3\"]")]
        public string AudioDevices {
            get {
                return ((string)(this["AudioDevices"]));
            }
            set {
                this["AudioDevices"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("{\"Satellite\":\"C:\\\\Users\\\\ronnybj\\\\OneDrive\\\\Playlists\\\\satellite.asx\",\"Internet\":" +
            "\"C:\\\\Users\\\\ronnybj\\\\OneDrive\\\\Playlists\\\\internet.asx\",\"Playlists\":\"C:\\\\Users\\\\" +
            "ronnybj\\\\OneDrive\\\\Playlists\\\\playlists.asx\"}")]
        public string DefaultPlaylists {
            get {
                return ((string)(this["DefaultPlaylists"]));
            }
            set {
                this["DefaultPlaylists"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("{\"Satellite\":\"C:\\\\Users\\\\ronnybj\\\\OneDrive\\\\Playlists\\\\satellite.asx\",\"Internet\":" +
            "\"C:\\\\Users\\\\ronnybj\\\\OneDrive\\\\Playlists\\\\internet.asx\",\"Playlists\":\"C:\\\\Users\\\\" +
            "ronnybj\\\\OneDrive\\\\Playlists\\\\playlists.asx\"}")]
        public string MasterPlaylists {
            get {
                return ((string)(this["MasterPlaylists"]));
            }
            set {
                this["MasterPlaylists"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(" [\"Zone1\", \"Zone2\", \"Zone3\"]")]
        public string ZoneNames {
            get {
                return ((string)(this["ZoneNames"]));
            }
            set {
                this["ZoneNames"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("{\"DllPath\":\"C:\\\\Program Files (x86)\\\\VideoLAN\\\\VLC\",\"PluginPath\":\"C:\\\\Program Fil" +
            "es (x86)\\\\VideoLAN\\\\VLC\\\\plugins\",\"StartupIgnoreConfig\":\"true\",\"StartupLogInFile" +
            "\":\"true\",\"StartupShowLoggerConsole\":\"true\",\"StartupVerbosity\":\"2\"}")]
        public string VlcSettings {
            get {
                return ((string)(this["VlcSettings"]));
            }
            set {
                this["VlcSettings"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string VolumeControl {
            get {
                return ((string)(this["VolumeControl"]));
            }
            set {
                this["VolumeControl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ShowVideo {
            get {
                return ((bool)(this["ShowVideo"]));
            }
            set {
                this["ShowVideo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int NumberOfPlayers {
            get {
                return ((int)(this["NumberOfPlayers"]));
            }
            set {
                this["NumberOfPlayers"] = value;
            }
        }
    }
}
