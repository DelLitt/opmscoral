using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TC.CustomTemplating;

namespace NMG.Core
{
    public static class ViewModelClassTemplate
    {
        public static string Transform(IGenerateArgument preferences)
        {
            ViewModelGenerateArgument viewModelGenerateArgument = (ViewModelGenerateArgument)preferences;
            
            //Get template from the embedded resources
            string template = TemplateResources.Get("NMG.Core.Templates.ViewModelClassTemplate.tt", typeof(ViewModelClassTemplate));
            var arguments = new TemplateArgumentCollection
                {    
                    //Argument             Name     &  Value
                    new TemplateArgument("ClassName", viewModelGenerateArgument.ClassName),
                    new TemplateArgument("NamespaceName",viewModelGenerateArgument.NamespaceName),
                    new TemplateArgument("FieldNames",viewModelGenerateArgument.FieldNames),
                    new TemplateArgument("MethodNames",viewModelGenerateArgument.MethodNames),
                    new TemplateArgument("DetailList",viewModelGenerateArgument.DetailList),
                    new TemplateArgument("ListNames",viewModelGenerateArgument.ListName)
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
