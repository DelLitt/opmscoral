using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using AppFrame.Extensions;
using NHibernate.Linq;

namespace AppFrame.DataLayer
{
    public class LinqCriteria<T> 
    {
        private IList<Expression<Func<T, bool>>> _where;
        private IList<Expression<Func<T, bool>>> _order;
        private IList<LambdaExpression> _fetchProps;
        private IQueryable<T> _internalQuery;
        private RepositoryContext _context  = new RepositoryContext();
        public IQueryable<T> InternalQuery
        {
            get { return _internalQuery; }
            set { _internalQuery = value; }
        }

        public IList<LambdaExpression> FetchProps
        {
            get { return _fetchProps; }
            set { _fetchProps = value; }
        }

        public int MaxResult { get; set; }

        public LinqCriteria()
        {
            _where = new List<Expression<Func<T, bool>>>();
            _order = new List<Expression<Func<T, bool>>>();
            _fetchProps = new List<LambdaExpression>();
            //_internalQuery = from item in _context.CurrentSession().Query<T>()
            //                             select item;
            _internalQuery = new NhQueryable<T>(null);
            
        }
        public LinqCriteria<T> AddCriteria(Expression<Func<T, bool>> lambdaFunc)
        {
            _where.Add(lambdaFunc);
            _internalQuery = _internalQuery.Where(lambdaFunc);
            return this;
        }

        public LinqCriteria<T> AddOrder(Expression<Func<T, bool>> lambdaFunc)
        {
            _order.Add(lambdaFunc);
            _internalQuery = _internalQuery.OrderBy(lambdaFunc);
            return this;
        }

        public LinqCriteria<T> Fetch<TK>(Expression<Func<T, TK>> fetchProp)
        {
            _internalQuery = _internalQuery.Fetch(fetchProp);
            return this;
        }
        

        public IList<Expression<Func<T, bool>>> Where
        {
            get
            {
                return _where;
            }
            set
            {
                _where = value;
            }
        }
        public IList<Expression<Func<T, bool>>> Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
            }
        }
        
    }
}
