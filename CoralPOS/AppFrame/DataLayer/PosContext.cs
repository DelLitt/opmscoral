using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate;
using NHibernate.LambdaExtensions;

namespace AppFrame.DataLayer
{
    public class PosContext : NHibernateContext
    {
        public PosContext()
        {
            
        }
        public PosContext(NHibernate.ISession session)
            : base(session)
        {
            
        }

        public static void SetCriteria<T>(ICriteria hibernateCriteria, ObjectCriteria<T> criteria)
        {
            IList<ICriterion> criterionList = criteria.GetWhere();
            foreach (ICriterion criterion in criterionList)
            {
                hibernateCriteria.Add(criterion);
            }
            foreach (var pair in criteria.GetOrder())
            {
                hibernateCriteria.AddOrder(pair.Key, pair.Value);

            }
            if (criteria.MaxResult > 0)
                hibernateCriteria.SetMaxResults(criteria.MaxResult);
        }
    }
}