using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Linq.Expressions;
namespace AppFrame.DataLayer
{
    public class QueryHandler<T>
    {

        private IList<Expression<Func<T, bool>>> _criteria;
        private NHibernateContext _context;
        private IList<string> fetchProps = new List<string>();
        public QueryHandler(NHibernateContext context)
        {
            _criteria = new List<Expression<Func<T, bool>>>();
            _context = context;
        }
        public QueryHandler(ISession session)
        {
            _context = new RepositoryContext(session);
        }
        public void AddCriteria(Expression<Func<T, bool>> lambdaFunc)
        {
            _criteria.Add(lambdaFunc);
        }



        public IList<T> GetList()
        {
            
            var query = from item in _context.Session.Linq<T>()
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
            /*var query = from item in _context.Session.Linq<T>()
                        select item;*/
            var items = _context.Session.Linq<T>();
            
            // set fetch mode
            foreach (string fetchProp in criteria.FetchProps)
            {
                items.Expand(fetchProp);
            }
            
            var query = from item in items
                        select item;

            //Tack on our query Criteria
            foreach (var criterion in criteria.Where)
            {
                query = query.Where<T>(criterion);

            }
            //Tack on our query Criteria
            foreach (var criterion in criteria.Order)
            {
                query = query.OrderBy(criterion);
            }
            
            
            return query.ToList();
        }

        public void AddFetch(string name)
        {
            fetchProps.Add(name);
        }
    }
    public class RepositoryContext : NHibernateContext
    {
        public RepositoryContext()
        {
            
        }
        public RepositoryContext(NHibernate.ISession session)
            : base(session)
        {
            
        }
    }
}
