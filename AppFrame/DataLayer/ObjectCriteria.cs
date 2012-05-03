
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Utils;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Type;
using NHibernate.Linq.Expressions;
using System.Linq.Expressions;
using Expression=NHibernate.Criterion.Expression;

namespace AppFrame.DataLayer
{
    [Serializable]
    public class ObjectCriteria<T>
    {
        private int _maxResult = Int32.MaxValue;
        public int MaxResult {
            get
            {
                return _maxResult;   
            }
            set
            {
                _maxResult = value;
            }
        }
        private bool isUsingQuery = false;
        private IList<ICriterion> _where = new List<ICriterion>();
        private IDictionary<Expression<Func<T, object>>,Func<string,Order>> _order = new Dictionary<Expression<Func<T, object>>, Func<string, Order>>();
        
        private IDictionary<Expression<Func<T,object>>,FetchMode> _fetchObjects = new Dictionary<Expression<Func<T, object>>, FetchMode>();

        public ObjectCriteria()
        {
            
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public void ClearAllCriteria()
        {
            _where.Clear();
            _order.Clear();
        }
        
        public ObjectCriteria<T> Add(Expression<Func<T, bool>> func)
        {

            if (func != null)
            {
                _where.Add(SqlExpression.CriterionFor(func));
            }
            return this;
        }

        public ObjectCriteria<T> Add(Expression<Func<bool>> func)
        {

            if (func != null)
            {
                _where.Add(SqlExpression.CriterionFor(func));
            }
            return this;
        }

        public ObjectCriteria<T> SetFetchMode(Expression<Func<T,object>> func,FetchMode fetchMode)
        {
            _fetchObjects.Add(func,fetchMode);
            return this;
        }

        
        public ObjectCriteria<T> Add(ICriterion criterion)
        {
            if(criterion!=null) _where.Add(criterion);
            return this;
        }

        public ObjectCriteria<T> AddOrder(Expression<Func<T,object>> func,Func<string,Order> orderType)
        {
            _order.Add(func,orderType);
            return this;
        }

        public void ClearWhere()
        {
            _where.Clear();
        }
        public void ClearOrder()
        {
            _order.Clear();
        }

        public IList<ICriterion> GetWhere()
        {
            return _where;
        }

        public IDictionary<Expression<Func<T, object>>, Func<string, Order>> GetOrder()
        {
            return _order;
        }

        public IDictionary<Expression<Func<T,object>>,FetchMode> GetFetchs()
        {
            return _fetchObjects;
        }
    }
}