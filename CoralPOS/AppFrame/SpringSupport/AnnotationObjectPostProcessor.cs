using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using AppFrame.CustomAttributes;
using Spring.Context;
using Spring.Objects;
using Spring.Objects.Factory.Config;
using Spring.Objects.Factory.Support;

namespace AppFrame.SpringSupport
{
    public class AnnotationObjectPostProcessor : InstantiationAwareObjectPostProcessorAdapter,IObjectFactoryPostProcessor,IApplicationContextAware
    {
        private static IApplicationContext _context;
        public override IPropertyValues PostProcessPropertyValues(IPropertyValues pvs, PropertyInfo[] pis, object objectInstance, string objectName)
        {
            foreach(var pi in pis)
            {
                if(IsAutowiredProperty(pi))
                {
                    var att = (AutowiredAttribute)pi.GetCustomAttributes(typeof(AutowiredAttribute), true)[0];
                    IDictionary dic = ApplicationContext.GetObjectsOfType(pi.PropertyType);
                    if(dic.Keys.Count == 0)
                    {
                        
                        if(att.Required == false)
                        {
                            continue;
                        }
                    }
                    IDictionaryEnumerator enumerator = dic.GetEnumerator();
                    enumerator.MoveNext();
                    object autowireObject = enumerator.Value;
                    MutablePropertyValues mutablePvs = (MutablePropertyValues) pvs;
                    if (mutablePvs.GetPropertyValue(pi.Name) == null)
                        mutablePvs.Add(pi.Name, autowireObject);
                }
            }
            return pvs;
        }

        protected bool IsAutowiredProperty(PropertyInfo pi)
        {
            return (pi.GetSetMethod() != null && pi.GetCustomAttributes(typeof(AutowiredAttribute), true).Length > 0);
        }

        public override bool PostProcessAfterInstantiation(object objectInstance, string objectName)
        {
            return base.PostProcessAfterInstantiation(objectInstance, objectName);
        }

        // process PerRequest, Singleton and AutowiredAttribute attributes
        public void PostProcessObjectFactory(IConfigurableListableObjectFactory factory)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            
            foreach (Assembly assembly in assemblies)
            {
                // register all singleton and per request attribute
                //(from type in assembly.GetTypes()
                // let attributes = type.GetCustomAttributes(typeof(SingletonAttribute), false)
                // where attributes != null && attributes.Length > 0
                // select new { CreateType = type, Attribute = attributes.Cast<SingletonAttribute>().First() })
                //    .ToList()
                //    .ForEach(x =>
                //        {                            
                //            string name = x.CreateType.Name;
                //            if (x.Attribute.Type != null) name = x.Attribute.Type.Name;
                //            if (x.Attribute.Name != null) name = x.Attribute.Name;
                //            object singletonObj = factory.Autowire(x.CreateType, AutoWiringMode.No, false);
                //            factory.RegisterSingleton(name, singletonObj);
                //        });

                //// register all perrequest attribute
                //(from type in assembly.GetTypes()
                // let attributes = type.GetCustomAttributes(typeof(PerRequestAttribute), false)
                // where attributes != null && attributes.Length > 0
                // select new { CreateType = type, Attribute = attributes.Cast<PerRequestAttribute>().First() })
                //    .ToList()
                //    .ForEach(x =>
                //        {
                //        var defaultFactory = new DefaultObjectDefinitionFactory();
                //        AbstractObjectDefinition def = defaultFactory.CreateObjectDefinition(x.CreateType.FullName + "," + x.CreateType.Assembly.GetName(), null, AppDomain.CurrentDomain);
                //        string name = x.CreateType.Name;
                //        if (x.Attribute.Type != null) name = x.Attribute.Type.Name;
                //        if (x.Attribute.Name != null) name = x.Attribute.Name;
                //        factory.RegisterObjectDefinition(name, def);
                //    });

                // register all perrequest and singleton attribute
                (from type in assembly.GetTypes()
                 let attributes = type.GetCustomAttributes(false)
                 from attribute in attributes
                 where attributes != null && attributes.Length > 0
                       && (attribute is PerRequestAttribute || attribute is SingletonAttribute)  
                 select new { CreateType = type, Attribute = attribute })
                    .ToList()
                    .ForEach(x =>
                        {
                            dynamic objX = x;
                            var defaultFactory = new DefaultObjectDefinitionFactory();
                            AbstractObjectDefinition def = defaultFactory.CreateObjectDefinition(x.CreateType.FullName + "," + x.CreateType.Assembly.GetName(), null, AppDomain.CurrentDomain);
                            string name = objX.CreateType.Name;
                            if (objX.Attribute.Type != null) name = objX.Attribute.Type.Name;
                            if (objX.Attribute.Name != null) name = objX.Attribute.Name;
                            if(objX.Attribute is SingletonAttribute)
                            {
                                def.IsSingleton = true;
                            }
                            ConstructorArgumentValues cav = def.ConstructorArgumentValues;
                            object[] constructValues = objX.Attribute.ConstructorArgs;
                            if(constructValues!=null && constructValues.Length>0)
                                {
                                    for(int i=0;i<constructValues.Length;i++)
                                    {
                                        cav.AddIndexedArgumentValue(i,constructValues[i]);
                                    }
                                }
                            
                            factory.RegisterObjectDefinition(name, def);
                        });
            }
        }

        public IApplicationContext ApplicationContext 
        {
            private get { return _context; }
            set { _context = value; }    
        } 
    }
}
