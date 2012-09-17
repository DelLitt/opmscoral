using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using AppFrame.Base;
using Spring.Objects.Factory.Support;

namespace AppFrame.SpringSupport
{
    public class ChildFlowObjectDefinitionParser : DefaultFlowObjectDefinitionParser
    {
        protected override Type GetObjectType(XmlElement element)
        {
            return typeof (ChildFlow);
        }

        protected override void DoParse(XmlElement element, ObjectDefinitionBuilder builder)
        {
            string parentFlow = element.GetAttribute("parent");
            if (!string.IsNullOrEmpty(parentFlow))
            {
                builder.AddPropertyReference("ParentFlow", parentFlow);
            }
            DoParseInternal(element,builder);
        }
    }
}
