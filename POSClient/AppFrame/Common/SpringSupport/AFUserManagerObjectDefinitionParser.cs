using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Spring.Objects.Factory.Support;
using Spring.Objects.Factory.Xml;

namespace AppFrame.Common.SpringSupport
{
    class AFUserManagerObjectDefinitionParser : AbstractSimpleObjectDefinitionParser
    {
        protected override Type GetObjectType(XmlElement element)
        {
            return typeof(IUserManager);
        }

        protected override void DoParse(XmlElement element, ObjectDefinitionBuilder builder)
        {
            // this will never be null since the schema explicitly requires that a value be supplied
            string user = element.GetAttribute("user");
            builder.AddPropertyReference("User", user);
        }

        protected override bool ShouldGenerateIdAsFallback
        {
            get { return true; }
        }
    }
}
