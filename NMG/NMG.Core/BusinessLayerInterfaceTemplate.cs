using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TC.CustomTemplating;

namespace NMG.Core
{
    public static class BusinessLayerInterfaceTemplate
    {
        public static string Transform(IGenerateArgument preferences)
        {
            BusinessGenerateArgument businessGenerateArgument = (BusinessGenerateArgument)preferences;
            
            //Get template from the embedded resources
            string template = TemplateResources.Get("NMG.Core.Templates.BusinessLayerInterfaceTemplate.tt", typeof(BusinessLayerInterfaceTemplate));
            var arguments = new TemplateArgumentCollection
                {    
                    //Argument             Name     &  Value
                    new TemplateArgument("ClassName", businessGenerateArgument.ClassName),
                    new TemplateArgument("NamespaceName",businessGenerateArgument.NamespaceName),
                    new TemplateArgument("ModelNamespaceName",businessGenerateArgument.ModelNamespaceName),
                    new TemplateArgument("DaoNamespaceName",businessGenerateArgument.DaoNamespaceName),
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
