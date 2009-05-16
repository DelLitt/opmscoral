using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Spring.Objects.Factory.Support;
using Spring.Objects.Factory.Xml;

namespace AppFrame.Common.SpringSupport
{
    class AFUserObjectDefinitionParser : AbstractSimpleObjectDefinitionParser
    {
        protected override Type GetObjectType(XmlElement element)
        {
            return typeof(BaseUser);
        }

        protected override void DoParse(XmlElement element, ObjectDefinitionBuilder builder)
        {
            
        }

        protected override bool ShouldGenerateIdAsFallback
        {
            get { return true; }
        } 
    }
}
