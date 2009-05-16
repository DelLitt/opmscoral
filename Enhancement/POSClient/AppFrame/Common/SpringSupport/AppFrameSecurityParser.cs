using System;
using System.Collections.Generic;
using System.Text;
using Spring.Objects.Factory.Xml;
namespace AppFrame.Common.SpringSupport
{
    
    public class AppFrameSecurityParser : NamespaceParserSupport
    {
        public override void Init()
        {
            RegisterObjectDefinitionParser("security", new AFSecurityObjectDefinitionParser());
            RegisterObjectDefinitionParser("user", new AFUserObjectDefinitionParser());
            RegisterObjectDefinitionParser("usermanager", new AFUserManagerObjectDefinitionParser());
            RegisterObjectDefinitionParser("authentication", new AFAuthenticationObjectDefinitionParser());
            
            

        }
    }
    
}
