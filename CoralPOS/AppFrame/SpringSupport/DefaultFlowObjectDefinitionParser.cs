using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using AppFrame.Base;
using Castle.DynamicProxy.Generators.Emitters;
using Spring.Objects.Factory.Config;
using Spring.Objects.Factory.Support;
using Spring.Objects.Factory.Xml;

namespace AppFrame.SpringSupport
{
    public class DefaultFlowObjectDefinitionParser : AbstractSimpleObjectDefinitionParser
    {
        protected override Type GetObjectType(XmlElement element)
        {
            return typeof (DefaultFlow);
        }

        protected override void DoParse(XmlElement element, ObjectDefinitionBuilder builder)
        {
            DoParseInternal(element, builder);
        }

        protected void DoParseInternal(XmlElement element, ObjectDefinitionBuilder builder)
        {
            builder.SetSingleton(false);
            string leftMenu = element.GetAttribute("menu");
            if(!string.IsNullOrEmpty(leftMenu)) builder.AddPropertyReference("Menu", leftMenu);
            string rightScreen = element.GetAttribute("screen");
            if(!string.IsNullOrEmpty(rightScreen)) builder.AddPropertyReference("MainScreen", rightScreen);
            foreach (XmlNode node in element.ChildNodes)
            {
                if (node is XmlComment) continue;

                switch (node.LocalName.ToLower())
                {
                    case "steps":
                        XmlNodeList steps = node.ChildNodes;
                        if (steps.Count > 0) // if flow is configured with a list of steps
                        {
                            IDictionary stepsDic = new System.Collections.Hashtable();
                            int count = 0;
                            foreach (XmlNode step in steps)
                            {
                                if(step is XmlComment) continue;
                                if (!step.LocalName.ToLower().Equals("step"))
                                {
                                    throw new Exception("Do not support node with name " + node.Name + " in config file.");
                                }
                                string key = "Step" + (++count).ToString();
                                stepsDic[key] = step.InnerText;
                            }
                            
                            builder.AddPropertyValue("FlowSteps", stepsDic);
                        }
                        break;
                    case "session":
                        string sessionRefBeanName = node.InnerText;
                        if(!string.IsNullOrEmpty(sessionRefBeanName))
                        {
                            builder.AddDependsOn(sessionRefBeanName);
                            builder.AddPropertyReference("Session", sessionRefBeanName);
                        }
                            
                        break;
                    case "menu":
                        string menuClassName = node.InnerText;
                        builder.AddPropertyValue("MenuClass", Type.GetType(menuClassName));
                        break;
                    case "screen":
                        string screenClassName = node.InnerText;
                        builder.AddPropertyValue("MainScreenClass", Type.GetType(screenClassName));
                        break;
                    default:
                        throw new Exception("Do not support node with name " + node.Name + " in config file.");
                        break;
                }
            }
        }

        protected override bool ShouldGenerateIdAsFallback
        {
            get { return true; }
        }
    }
}
