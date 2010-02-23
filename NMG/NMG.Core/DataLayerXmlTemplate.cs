using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TC.CustomTemplating;

namespace NMG.Core
{
    public static class DataLayerXmlTemplate
    {
        public static string Transform(IGenerateArgument preferences)
        {
            DataLayerXmlGenerateArgument businessGenerateArgument = (DataLayerXmlGenerateArgument)preferences;
            
            //Get template from the embedded resources
            string template = TemplateResources.Get("NMG.Core.Templates.DataLayerXmlTemplate.tt", typeof(DataLayerXmlTemplate));
            var arguments = new TemplateArgumentCollection
                {    
                    //Argument             Name     &  Value
                    new TemplateArgument("AssemblyName", businessGenerateArgument.AssemblyName),
                    new TemplateArgument("DaoAssemblyName",businessGenerateArgument.DaoAssemblyName),
                    new TemplateArgument("DaoNamesList",businessGenerateArgument.DaoNamesList),
                };
            //Allows us to show the generated class
            var transformer = new TextTransformer();
            transformer.ClassDefinitionGenerated += HostClassDefinitionGenerated;

            //start the tranformation in th current appdomain
            var output = transformer.Transform(template, arguments);
            transformer.ClassDefinitionGenerated -= HostClassDefinitionGenerated;

            return output;
        }

        public static void HostClassDefinitionGenerated(object sender, ClassDefinitionEventArgs e)
        {
            
        }
    }
}
