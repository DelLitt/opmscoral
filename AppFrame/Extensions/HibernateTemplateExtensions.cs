using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Spring.Data.NHibernate;

namespace AppFrame.Extensions
{
    public static class HibernateTemplateExtensions
    {
        public static T Save<T>(this HibernateTemplate template,T obj)
        {
            return (T)template.Execute(session => session.Save(typeof (T).FullName, obj));
        }
        public static void Update<T>(this HibernateTemplate template, T obj)
        {
            template.Execute(delegate(ISession session) { 
                                                            session.Update(typeof(T).FullName, obj);
                                                            return 0; });
        }
        public static void Delete<T>(this HibernateTemplate template, T obj)
        {
            template.Execute(delegate(ISession session)
            {
                session.Delete(typeof(T).FullName, obj);
                return 0;
            });
        }
    }
}
