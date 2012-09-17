using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Objects.Factory.Xml;

namespace AppFrame.SpringSupport
{
    [NamespaceParser(
        Namespace = "http://www.newcoral.com.vn/schema/pos",
        SchemaLocationAssemblyHint = typeof(FlowNamespaceParser),
        SchemaLocation = "/AppFrame/spring-support.xsd"
        )
    ]
    public class FlowNamespaceParser : NamespaceParserSupport
    {
        public override void Init()
        {
            RegisterObjectDefinitionParser("flow", new DefaultFlowObjectDefinitionParser());
            RegisterObjectDefinitionParser("childflow", new ChildFlowObjectDefinitionParser());
        }
    }
}
