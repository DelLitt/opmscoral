﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppFrameClient.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=NAMTN;Initial Catalog=PTracker;Persist Security Info=True;User ID=adm" +
            "inistrator;Password=rfchcm2008")]
        public string PTrackerConnectionString {
            get {
                return ((string)(this["PTrackerConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string IsClient {
            get {
                return ((string)(this["IsClient"]));
            }
            set {
                this["IsClient"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\POS\\CH-KHO")]
        public string SyncImportPath {
            get {
                return ((string)(this["SyncImportPath"]));
            }
            set {
                this["SyncImportPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\POS\\Success")]
        public string SyncSuccessPath {
            get {
                return ((string)(this["SyncSuccessPath"]));
            }
            set {
                this["SyncSuccessPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\POS\\Error")]
        public string SyncErrorPath {
            get {
                return ((string)(this["SyncErrorPath"]));
            }
            set {
                this["SyncErrorPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\POS\\KHO-CH")]
        public string SyncExportPath {
            get {
                return ((string)(this["SyncExportPath"]));
            }
            set {
                this["SyncExportPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("cboPrinters")]
        public string PrinterName {
            get {
                return ((string)(this["PrinterName"]));
            }
            set {
                this["PrinterName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files\\MySQL\\MySQL Server 5.1\\bin")]
        public string MySQLDump {
            get {
                return ((string)(this["MySQLDump"]));
            }
            set {
                this["MySQLDump"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\POS\\BackupDB")]
        public string DBBackupPath {
            get {
                return ((string)(this["DBBackupPath"]));
            }
            set {
                this["DBBackupPath"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Password=1qw45DCM9rl;user id=dbadmin;server=localhost;persist security info=True;" +
            "database=pos")]
        public string posConnectionString {
            get {
                return ((string)(this["posConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public string DeptMarket {
            get {
                return ((string)(this["DeptMarket"]));
            }
            set {
                this["DeptMarket"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("TcpBinding")]
        public string ServiceBinding {
            get {
                return ((string)(this["ServiceBinding"]));
            }
            set {
                this["ServiceBinding"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool NegativeStock {
            get {
                return ((bool)(this["NegativeStock"]));
            }
            set {
                this["NegativeStock"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10.0.0.10")]
        public string SubStockDB {
            get {
                return ((string)(this["SubStockDB"]));
            }
            set {
                this["SubStockDB"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10.0.0.8")]
        public string SalePointDB {
            get {
                return ((string)(this["SalePointDB"]));
            }
            set {
                this["SalePointDB"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ConfirmByEmployeeId {
            get {
                return ((bool)(this["ConfirmByEmployeeId"]));
            }
            set {
                this["ConfirmByEmployeeId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool NegativeSelling {
            get {
                return ((bool)(this["NegativeSelling"]));
            }
            set {
                this["NegativeSelling"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool NegativeExport {
            get {
                return ((bool)(this["NegativeExport"]));
            }
            set {
                this["NegativeExport"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ImportConfirmation {
            get {
                return ((bool)(this["ImportConfirmation"]));
            }
            set {
                this["ImportConfirmation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ExportConfirmation {
            get {
                return ((bool)(this["ExportConfirmation"]));
            }
            set {
                this["ExportConfirmation"] = value;
            }
        }
    }
}
