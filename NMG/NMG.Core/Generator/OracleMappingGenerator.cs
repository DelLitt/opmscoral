using System;
using System.Collections.Generic;
using System.Xml;
using NMG.Core.Domain;
using NMG.Core.Util;

namespace NMG.Core.Generator
{
    public class OracleMappingGenerator : MappingGenerator
    {
        public OracleMappingGenerator(ApplicationPreferences applicationPreferences, ColumnDetails columnDetails) : base(applicationPreferences, columnDetails)
        {
        }

        
        protected override void AddIdGenerator(XmlDocument xmldoc, XmlElement idElement)
        {

            var generatorElement = xmldoc.CreateElement("generator");
            if (IsAssigned)
            {
                generatorElement.SetAttribute("class", "assigned");
                idElement.AppendChild(generatorElement);
            }
            else
            {
                generatorElement.SetAttribute("class", "sequence");
                idElement.AppendChild(generatorElement);

                var paramElement = xmldoc.CreateElement("param");
                paramElement.SetAttribute("name", "sequence");
                paramElement.InnerText = sequenceName;
                generatorElement.AppendChild(paramElement);
            }
        }

        protected override void AddCompositeIdGenerator(XmlDocument xmldoc, XmlElement idElement, List<ColumnDetail> compositeKey,ApplicationPreferences applicationPreferences)
        {
            foreach (ColumnDetail column in compositeKey)
            {
                var keyElement = xmldoc.CreateElement("key-property");
                string propertyName =
                    column.ColumnName.GetPreferenceFormattedText(applicationPreferences);

                if (applicationPreferences.FieldGenerationConvention == FieldGenerationConvention.Property)
                {
                    idElement.SetAttribute("name", propertyName.MakeFirstCharLowerCase());
                }
                else
                {
                    if (applicationPreferences.FieldGenerationConvention == FieldGenerationConvention.AutoProperty)
                    {
                        propertyName = column.ColumnName.GetFormattedText();
                    }

                    keyElement.SetAttribute("name", propertyName);
                }
                var mapper = new DataTypeMapper();
                Type mapFromDbType = mapper.MapFromDBType(column.DataType, column.DataLength,
                                                          column.DataPrecision,
                                                          column.DataScale);
                keyElement.SetAttribute("type", mapFromDbType.Name);
                keyElement.SetAttribute("column", column.ColumnName);
                if (applicationPreferences.FieldGenerationConvention != FieldGenerationConvention.AutoProperty)
                {
                    keyElement.SetAttribute("access", "field");
                }
                idElement.AppendChild(keyElement);
            }

        }
    }
}