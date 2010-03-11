using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TC.CustomTemplating;

namespace NMG.Core
{
    public static class BusinessLayerXmlTemplate
    {
        public static string Transform(IGenerateArgument preferences)
        {
            BusinessLayerXmlGenerateArgument businessGenerateArgument = (BusinessLayerXmlGenerateArgument)preferences;
            
            //Get template from the embedded resources
            string template = TemplateResources.Get("NMG.Core.Templates.BusinessLayerXmlTemplate.tt", typeof(BusinessLayerXmlTemplate));
            var arguments = new TemplateArgumentCollection
                {    
                    //Argument             Name     &  Value
                    new TemplateArgument("BusinessAssemblyName",businessGenerateArgument.BusinessAssemblyName),
                    new TemplateArgument("DaoNamespaceName",businessGenerateArgument.DaoNamespace),
                    new TemplateArgument("BusinessNamespaceName",businessGenerateArgument.Namespace),
                    new TemplateArgument("BusinessNamesList",businessGenerateArgument.BusinessNamesList),
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
