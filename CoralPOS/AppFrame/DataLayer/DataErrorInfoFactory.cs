using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Caliburn.DynamicProxy.Interceptors;
using Caliburn.PresentationFramework.ViewModels;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using NHibernate;

namespace AppFrame.DataLayer
{
    public class DataErrorInfoFactory
    {
            private static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

            public static T Create<T>()
            {
                return (T)Create(typeof(T));
            }

            public static object Create(Type type)
            {
                return ProxyGenerator.CreateClassProxy(type, new[] {
			typeof (IDataErrorInfo)
            ,typeof (IMarkerInterface)  
                },  
            new DataErrorInfoInterceptor(new DefaultValidator()));
            }

            public interface IMarkerInterface
            {
                string TypeName { get; }
            }
    }

    public class PosDataErrorInfoIntercepter : EmptyInterceptor
    {
        public ISessionFactory SessionFactory { set; get; }

        public override object Instantiate(string clazz, EntityMode entityMode, object id)
        {
            if (entityMode == EntityMode.Poco)
            {
                Type type = Type.GetType(clazz);
                if (type != null)
                {
                    var instance = DataErrorInfoFactory.Create(type);
                    SessionFactory.GetClassMetadata(clazz).SetIdentifier(instance, id, entityMode);
                    return instance;
                }
            }
            return base.Instantiate(clazz, entityMode, id);
        }

        public override string GetEntityName(object entity)
        {
            var markerInterface = entity as DataErrorInfoFactory.IMarkerInterface;
            if (markerInterface != null) return markerInterface.TypeName;
            return base.GetEntityName(entity);
        }
    }
}
