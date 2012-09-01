using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows;
using AppFrame.Extensions;
using NHibernate.Linq;
using Remotion.Linq.Utilities;
using Expression = System.Linq.Expressions.Expression;

namespace AppFrame.DataLayer
{
    public static class LinqFetchMethods
    {
        public static ILinqCriteria<TOriginating> Fetch<TOriginating, TRelated>(
            this ILinqCriteria<TOriginating> query, Expression<Func<TOriginating, TRelated>> relatedObjectSelector)
        {
            ArgumentUtility.CheckNotNull("query", query);
            ArgumentUtility.CheckNotNull("relatedObjectSelector", relatedObjectSelector);

            var methodInfo = ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TOriginating), typeof(TRelated));
            return CreateFluentFetchRequest<TOriginating, TRelated>(methodInfo, query, relatedObjectSelector);
        }

        public static ILinqCriteria<TOriginating> FetchMany<TOriginating, TRelated>(
            this ILinqCriteria<TOriginating> query, Expression<Func<TOriginating, IEnumerable<TRelated>>> relatedObjectSelector)
        {
            ArgumentUtility.CheckNotNull("query", query);
            ArgumentUtility.CheckNotNull("relatedObjectSelector", relatedObjectSelector);

            var methodInfo = ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TOriginating), typeof(TRelated));
            return CreateFluentFetchRequest<TOriginating, TRelated>(methodInfo, query, relatedObjectSelector);
        }

        public static ILinqCriteria<TQueried> ThenFetch<TQueried, TFetch, TRelated>(
            this ILinqCriteria<TQueried> query, Expression<Func<TFetch, TRelated>> relatedObjectSelector)
        {
            ArgumentUtility.CheckNotNull("query", query);
            ArgumentUtility.CheckNotNull("relatedObjectSelector", relatedObjectSelector);

            var methodInfo = ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TQueried), typeof(TFetch), typeof(TRelated));
            return CreateFluentFetchRequest<TQueried, TRelated>(methodInfo, query, relatedObjectSelector);
        }

        public static ILinqCriteria<TQueried> ThenFetchMany<TQueried, TFetch, TRelated>(
            this ILinqCriteria<TQueried> query, Expression<Func<TFetch, IEnumerable<TRelated>>> relatedObjectSelector)
        {
            ArgumentUtility.CheckNotNull("query", query);
            ArgumentUtility.CheckNotNull("relatedObjectSelector", relatedObjectSelector);

            var methodInfo = ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TQueried), typeof(TFetch), typeof(TRelated));
            return CreateFluentFetchRequest<TQueried, TRelated>(methodInfo, query, relatedObjectSelector);
        }

        private static ILinqCriteria<TOriginating> CreateFluentFetchRequest<TOriginating, TRelated>(
            MethodInfo currentFetchMethod,
            ILinqCriteria<TOriginating> query,
            LambdaExpression relatedObjectSelector)
        {
            KeyValuePair<MethodInfo,LambdaExpression> pair = new KeyValuePair<MethodInfo, LambdaExpression>(currentFetchMethod,relatedObjectSelector);
            query.FetchList.Add(pair);
            return query;
        }
    }

    public interface ILinqCriteria<T> : IQueryable<T>
    {
        IList<KeyValuePair<MethodInfo, LambdaExpression>> FetchList { get; }
    }

    public class LinqCriteria<T> : NhQueryable<T>, ILinqCriteria<T>
    {
        private IList<Expression<Func<T, bool>>> _where;
        private IList<Expression<Func<T, bool>>> _order;
        private IList<LambdaExpression> _fetchProps;
        
        private RepositoryContext _context  = new RepositoryContext();
        private IList<KeyValuePair<MethodInfo, LambdaExpression>> _methodCalls;
        

        public IList<LambdaExpression> FetchProps
        {
            get { return _fetchProps; }
            set { _fetchProps = value; }
        }

        public int MaxResult { get; set; }

        // THIS CONSTRUCTOR IS RESERVED FOR QueryHandler ONLY !
        public LinqCriteria(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
            // DO NOTHING IN HERE
        }

        public LinqCriteria() : base(null)
        {
            _where = new List<Expression<Func<T, bool>>>();
            _order = new List<Expression<Func<T, bool>>>();
            _fetchProps = new List<LambdaExpression>();
            //_internalQuery = from item in _context.CurrentSession().Query<T>()
            //                             select item;
            
            FetchList = new List<KeyValuePair<MethodInfo, LambdaExpression>>();
            
        }
        public LinqCriteria<T> AddCriteria(Expression<Func<T, bool>> lambdaFunc)
        {
            _where.Add(lambdaFunc);
            
            return this;
        }

        public LinqCriteria<T> AddOrder(Expression<Func<T, bool>> lambdaFunc)
        {
            _order.Add(lambdaFunc);
            
            return this;
        }

        private LinqCriteria<T> AddFetch<K>(Expression<Func<T, K>> expression)
        {
            _fetchProps.Add(expression);
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

        public IList<KeyValuePair<MethodInfo, LambdaExpression>> FetchList
        {
            get { return _methodCalls; }
            set { _methodCalls = value; }
        }
    }
}
