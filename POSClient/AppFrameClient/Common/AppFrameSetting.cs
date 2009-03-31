using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AppFrameClient.Common
{
    
    public class AppFrameSetting : System.Configuration.ApplicationSettingsBase
    {
        [ApplicationScopedSettingAttribute]
        public string SyncImportPath
        {
            get
            {
                return (string)this["SyncImportPath"];
            }
            set
            {
                this["SyncImportPath"] = value;
            }
        }

        [ApplicationScopedSettingAttribute]
        public string SyncExportPath
        {
            get
            {
                return (string)this["SyncExportPath"];
            }
            set
            {
                this["SyncExportPath"] = value;
            }
        }
        [ApplicationScopedSettingAttribute]
        public string SyncImportSuccessPath
        {
            get
            {
                return (string)this["SyncImportSuccessPath"];
            }
            set
            {
                this["SyncImportSuccessPath"] = value;
            }
        }

        [ApplicationScopedSettingAttribute]
        public string SyncImportErrorPath
        {
            get
            {
                return (string)this["SyncImportErrorPath"];
            }
            set
            {
                this["SyncImportErrorPath"] = value;
            }
        }

        [ApplicationScopedSettingAttribute]
        public string PrinterName
        {
            get
            {
                return (string)this["PrinterName"];
            }
            set
            {
                this["PrinterName"] = value;
            }
        }
    }
}
