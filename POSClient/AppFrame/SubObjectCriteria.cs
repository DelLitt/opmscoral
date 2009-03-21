using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace AppFrame
{
    [Serializable]
    public class SubObjectCriteria
    {
        private IList<ICriterion> where = new List<ICriterion>();
        private IList<Order> order = new List<Order>();
        private IDictionary<string, SubObjectCriteria> subCriteria = new SortedDictionary<string, SubObjectCriteria>();
        private string associateName = "";

        public SubObjectCriteria(string associateName)
        {
            this.associateName = associateName;
        }

        public void ClearAllCriteria()
        {
            where.Clear();
        }

        public void AddSubCriteria(string propertyName, SubObjectCriteria criteria)
        {
            subCriteria.Add(associateName + "." + propertyName, criteria);
        }

        public void RemoveSubCriteria(string propertyName)
        {
            subCriteria.Remove(associateName + "." + propertyName);
        }

        public IDictionary<string, SubObjectCriteria> GetSubCriteria()
        {
            return subCriteria;
        }

        public void AddEqCriteria(string propertyName, object value)
        {
            if (value != null)
            {
                where.Add(Expression.Eq(associateName + "." + propertyName, value));
            }
        }

        public void AddGreaterOrEqualsCriteria(string propertyName, object value)
        {
            if (value != null)
            {
                where.Add(Expression.Ge(associateName + "." + propertyName, value));
            }
        }

        public void AddGreaterCriteria(string propertyName, object value)
        {
            if (value != null)
            {
                where.Add(Expression.Gt(associateName + "." + propertyName, value));
            }
        }

        public void AddLesserOrEqualsCriteria(string propertyName, object value)
        {
            if (value != null)
            {
                where.Add(Expression.Le(associateName + "." + propertyName, value));
            }
        }

        public void AddLesserCriteria(string propertyName, object value)
        {
            if (value != null)
            {
                where.Add(Expression.Lt(associateName + "." + propertyName, value));
            }
        }

        public void AddNotEqualsCriteria(string propertyName, object value)
        {
            if (value != null)
            {
                where.Add(Expression.Not(Expression.Eq(associateName + "." + propertyName, value)));
            }
        }

        public void AddLikeCriteria(string propertyName, object value)
        {
            if (value != null)
            {
                where.Add(Expression.Like(associateName + "." + propertyName, value));
            }
        }

        public void AddIsNullCriteria(string propertyName)
        {
            where.Add(Expression.IsNull(associateName + "." + propertyName));
        }

        public void AddIsNotNullCriteria(string propertyName)
        {
            where.Add(Expression.IsNotNull(associateName + "." + propertyName));
        }

        public void AddIsEmptyCriteria(string propertyName)
        {
            where.Add(Expression.IsEmpty(associateName + "." + propertyName));
        }

        public void AddIsNotEmptyCriteria(string propertyName)
        {
            where.Add(Expression.IsNotEmpty(associateName + "." + propertyName));
        }

        public void AddBetweenCriteria(string propertyName, object low, object high)
        {
            if (low != null && high != null)
            {
                where.Add(Expression.Between(associateName + "." + propertyName, low, high));
            }
            else
            {
                AddGreaterOrEqualsCriteria(associateName + "." + propertyName, low);
                AddLesserOrEqualsCriteria(associateName + "." + propertyName, high);
            }
        }

        public void AddBetweenNotEqualsCriteria(string propertyName, object low, object high)
        {
            AddGreaterCriteria(associateName + "." + propertyName, low);
            AddLesserCriteria(associateName + "." + propertyName, high);
        }

        public void AddOrder(string propertyName, bool isAscending)
        {
            if (isAscending)
            {
                order.Add(Order.Asc(associateName + "." + propertyName));
            }
            else
            {
                order.Add(Order.Desc(associateName + "." + propertyName));
            }
        }
        public SubObjectCriteria AddSearchInCriteria(string propertyName, ICollection collection)
        {
            if (collection != null && collection.Count > 0)
            {
                where.Add(Restrictions.In(propertyName, collection));
            }
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

        public IList<Order> GetOrder()
        {
            return order;
        }
    }
}
