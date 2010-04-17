using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Spring.Objects.Factory.Support;
using Spring.Objects.Factory.Xml;

namespace AppFrame.Common.SpringSupport
{
    public class AFAuthenticationObjectDefinitionParser : AbstractSimpleObjectDefinitionParser 
    {
        #region IObjectDefinitionParser Members

        protected override Type GetObjectType(XmlElement element)
        {
            return typeof(AuthManager);
        }

        protected override void DoParse(XmlElement element, ObjectDefinitionBuilder builder)
        {
            // this will never be null since the schema explicitly requires that a value be supplied
            string usermanager = element.GetAttribute("usermanager");
            builder.AddPropertyReference("UserManager", usermanager);
        }

        protected override bool ShouldGenerateIdAsFallback
        {
            get { return true; }
        }

        #endregion
    }
}
