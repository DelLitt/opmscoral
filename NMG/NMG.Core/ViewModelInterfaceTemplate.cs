using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TC.CustomTemplating;

namespace NMG.Core
{
    public static class ViewModelInterfaceTemplate
    {
        public static string Transform(IGenerateArgument preferences)
        {
            ViewModelGenerateArgument businessGenerateArgument = (ViewModelGenerateArgument)preferences;
            
            //Get template from the embedded resources
            string template = TemplateResources.Get("NMG.Core.Templates.ViewModelInterfaceTemplate.tt", typeof(ViewModelInterfaceTemplate));
            var arguments = new TemplateArgumentCollection
                {    
                    //Argument             Name     &  Value
                    new TemplateArgument("ClassName", businessGenerateArgument.ClassName),
                    new TemplateArgument("NamespaceName",businessGenerateArgument.NamespaceName),
                    new TemplateArgument("FieldNames",businessGenerateArgument.FieldNames),
                    new TemplateArgument("MethodNames",businessGenerateArgument.MethodNames),
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
