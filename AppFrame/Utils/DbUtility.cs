using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using Spring.Data.NHibernate;

namespace AppFrame.Utility
{
    public class DbUtility
    {
        public static readonly string DEPARTMENT = "20";
        public static readonly string EMPLOYEE = "30";
        public static ISession session = null;

        public static string DepartmentRandomPKGenerator()
        {
            string _prefix = DEPARTMENT;
            string randomKey = RandomGenerator.GenerateInteger(4);
            return _prefix + randomKey;
        }
        public static string EmployeeRandomPKGenerator(string departmentId)
        {
            string _prefix = EMPLOYEE;
            string randomKey = RandomGenerator.GenerateInteger(4);
            return _prefix + randomKey;
        }

        public static ISession getSession(HibernateTemplate template)
        {
            if (session == null || !session.IsConnected)
            {
                session = template.SessionFactory.OpenSession();
            }
            return session;
        }
        /*public static ISession CurrentSession()
        {
            HibernateTemplate template = GlobalUtility.GetObject("HibernateTemplate") as HibernateTemplate;

            return SessionFactoryUtils.GetSession(template.SessionFactory, true); ;
        }
*/
        
    }
}
