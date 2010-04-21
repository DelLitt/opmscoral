using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AopAlliance.Aop;
using Caliburn.DynamicProxy.Interceptors;
using Caliburn.PresentationFramework.ViewModels;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using NHibernate;
using NHibernate.Proxy;
using NHibernate.Type;
using Spring.Aop.Framework;
using Spring.Aop.Support;


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
                return ProxyGenerator.CreateClassProxy(type, 
                    new[] { typeof (IDataErrorInfo),
                            typeof (IMarkerInterface) },
                            new DataErrorInfoInterceptor(GlobalValidator.Instance));
            }
            public static T CreateProxyFor<T>(T obj)
            {
                ProxyFactory factory = new ProxyFactory(obj);
                factory.AddIntroduction(new DataErrorInfoAdvisor());
                factory.ProxyTargetType = true;
                return (T)factory.GetProxy();
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

        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            return true;
        }
    }

    public class GlobalValidator : DefaultValidator
    {
        private static GlobalValidator _validator = null;
        private GlobalValidator() : base()
        {
        }
        public static GlobalValidator Instance
        {
            get
            {
                if(_validator==null) _validator = new GlobalValidator();
                return _validator;
            }
        }
    }

    public class DataErrorInfoMixin : IDataErrorInfo,IAdvice
    {
        public virtual string this[string columnName]
        {
            get
            {
                var errors = GlobalValidator.Instance.Validate(this, columnName);
                    var arrayErrors= errors.Select(x => x.Message).ToArray();
                    return string.Join(Environment.NewLine, arrayErrors);
            }
        }

        public virtual string Error
        {
            get
            {
                var errors = GlobalValidator.Instance.Validate(this).Select(x => x.Message).ToArray();
                return string.Join(Environment.NewLine, errors);
            }
        }
    }
    public class DataErrorInfoAdvisor : DefaultIntroductionAdvisor
    {
        public DataErrorInfoAdvisor() : base(new DataErrorInfoMixin()) {}
    }
}
