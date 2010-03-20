using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NHibernate.Linq;
using NHibernate.Linq.Expressions;
namespace AppFrame.DataLayer
{
    public class QueryHandler<T>
    {
        
        private IList<Expression<Func<T, bool>>> _criteria;
        private NHibernateContext _context;
        public QueryHandler(NHibernateContext context)
        {
            _criteria = new List<Expression<Func<T, bool>>>();
            _context = context;
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
    }
}
