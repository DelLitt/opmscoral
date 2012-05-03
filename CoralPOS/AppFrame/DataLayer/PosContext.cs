using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NHibernate.Criterion;
using NHibernate;
using NHibernate.LambdaExtensions;

namespace AppFrame.DataLayer
{
    public class PosContext : NHibernate.Context.CurrentSessionContext
    {
        private ISession session = null;
        public PosContext() : base() {}
        public PosContext(NHibernate.ISession session) : base()
        {
            this.session = session;
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

            foreach (var fetch in criteria.GetFetchs())
            {
                hibernateCriteria.SetFetchMode(fetch.Key, fetch.Value);
            }
            
            if (criteria.MaxResult > 0)
                hibernateCriteria.SetMaxResults(criteria.MaxResult);
        }

        protected override ISession Session
        {
            get { return session; }
            set { session = value; }
        }
    }
}