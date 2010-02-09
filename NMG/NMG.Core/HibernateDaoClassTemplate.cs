using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TC.CustomTemplating;

namespace NMG.Core
{
    public static class HibernateDaoClassTemplate
    {
        public static string Transform(IGenerateArgument preferences)
        {
            DaoGenerateArgument daoGenerateArgument = (DaoGenerateArgument)preferences;
            
            //Get template from the embedded resources
            string template = TemplateResources.Get("NMG.Core.Templates.HibernateDaoClassTemplate.tt", typeof(HibernateDaoInterfaceTemplate));
            var arguments = new TemplateArgumentCollection
                {    
                    //Argument             Name     &  Value
                    new TemplateArgument("ClassName", daoGenerateArgument.ClassName),
                    new TemplateArgument("NamespaceName",daoGenerateArgument.NamespaceName),
                    new TemplateArgument("ModelNamespaceName",daoGenerateArgument.ModelNamespaceName)
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
