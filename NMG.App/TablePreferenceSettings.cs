using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using NMG.Core;

namespace NHibernateMappingGenerator
{
    [Serializable]
    public class TablePreferenceSettings
    {
        public TablePreferenceSettings()
        {
            
        }

        public TablePreferenceSettings(List<ApplicationPreferences> list)
        {
            TablePreferences = list;
        }

        public List<ApplicationPreferences> TablePreferences { get; set; }
    }
}
