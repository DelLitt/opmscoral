using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NHibernate;
using NHibernate.Linq;

namespace AppFrame.DataLayer
{
    public class QueryHandler<T>
    {
        
        private IList<Expression<Func<T, bool>>> _criteria;
        private RepositoryContext _context;
        private IQueryable<T> _query;
        public QueryHandler(RepositoryContext context)
        {
            _criteria = new List<Expression<Func<T, bool>>>();
            _context = context;
        }
        public QueryHandler(ISession session)
        {
            _context = new RepositoryContext(session);
            _criteria = new List<Expression<Func<T, bool>>>();
        }
        
        /*public void AddCriteria(Expression<Func<T, bool>> lambdaFunc)
        {
            _criteria.Add(lambdaFunc);
        }

        public LinqCriteria<T> AddOrder(Expression<Func<T, bool>> lambdaFunc)
        {
            _order.Add(lambdaFunc);
            return this;
        }

        public void Fetch<TK>(Expression<Func<T, TK>> fetchProp)
        {
            _fetchProps.Add(fetchProp);
        }*/

        public IList<T> GetList()
        {

            var query = from item in _context.CurrentSession().Query<T>()
                        select item;
            
            //Tack on our query Criteria
            foreach (var criterion in _criteria)
            {
                query = query.Where<T>(criterion);

            }
            return query.ToList();
        }

        public IList<T> GetList(LinqCriteria<T> criteria)
        {
            var query = from item in _context.CurrentSession().Query<T>()
                        select item;
            query = new NhQueryable<T>(query.Provider,criteria.InternalQuery.Expression);
            //Tack on  query Criteria parameter
           /* foreach (var criterion in criteria.Where)
            {
                query = query.Where<T>(criterion);
                
            }

            foreach (var criterion in criteria.Order)
            {
                query = query.OrderBy(criterion);

            }
            
            
            foreach (LambdaExpression expression in criteria.FetchProps)
            {
                
            }
            /*var queryProvider = query.Provider; // ArgumentUtility.CheckNotNullAndType<QueryProviderBase>("query.Provider", query.Provider);

            foreach (LambdaExpression expression in criteria.FetchProps)
            {
                
                var methodInfo = ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(T), typeof(TRelated));
                var callExpression = Expression.Call(currentFetchMethod, query.Expression, relatedObjectSelector);
            }#1#
           
            if (criteria.MaxResult > 0)
            {
                
            }*/
            return query.ToList();
        }

        public IQueryable<T> CreateLinqQuery() 
        {
            return _context.CurrentSession().Query<T>();
        }
    }

    public class RepositoryContext : NHibernate.Context.CurrentSessionContext
    {
        private ISession _session;
        public RepositoryContext() :base()
        {
        }

        public RepositoryContext(NHibernate.ISession session)
            : base()
        {
            _session = session;
            }

        protected override ISession Session
        {
            get { return _session; }
            set { _session = value; }
        }
    }
}
