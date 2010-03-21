
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Utils;
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
        private IList<ICriterion> where = new List<ICriterion>();
        private IDictionary<Expression<Func<T, object>>,<Expression<Func<string,Order>>> order = new List<Expression<Func<T, object>>>();
        
        public ObjectCriteria() {}
        
        public void ClearAllCriteria()
        {
            where.Clear();
        }
        
        public ObjectCriteria<T> AddCriteria(Expression<Func<T, bool>> func)
        {

            if (func != null)
            {
                where.Add(SqlExpression.CriterionFor(func));
            }
            return this;
        }

        public ObjectCriteria<T> AddCriteria(Expression<Func<bool>> func)
        {

            if (func != null)
            {
                where.Add(SqlExpression.CriterionFor(func));
            }
            return this;
        }

        public ObjectCriteria<T> AddCriteria(ICriterion criterion)
        {
            if(criterion!=null) where.Add(criterion);
            return this;
        }

        public ObjectCriteria<T> AddOrder(Expression<Func<T,object>> func)
        {
            order.Add(func);
            return this;
        }

        public void ClearOrder()
        {
            order.Clear();
        }

        public IList<ICriterion> GetWhere()
        {
            return where;
        }

        public IList<Expression<Func<T, object>>> GetOrder()
        {
            return order;
        }
    }
}