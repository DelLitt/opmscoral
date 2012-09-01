
using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Utils;
using NHibernate.Criterion;
using NHibernate.Type;

namespace POSServer.DataLayer.Implement
{
    [Serializable]
    public class ObjectCriteria : SearchCriteria
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
        private IList<Order> order = new List<Order>();
        private IDictionary<string, SubObjectCriteria> subCriteria = new SortedDictionary<string, SubObjectCriteria>();

        private List<SQLQueryCriteria> queryCriteria = new List<SQLQueryCriteria>();

        public ObjectCriteria() {}
        public ObjectCriteria(bool isUsingQuery) 
        {
            this.isUsingQuery = isUsingQuery; 
        }

        public void ClearAllCriteria()
        {
            where.Clear();
        }

        public ObjectCriteria AddEqCriteria(string propertyName, object value)
        {
            
            if (value != null)
            {
                where.Add(Restrictions.Eq(propertyName, value));
                if (isUsingQuery)
                {
                    queryCriteria.Add(new SQLQueryCriteria { PropertyName = propertyName, SQLString = " = ", Value = value, Type = ObjectConverter.ConvertToNHibernateType(value.GetType()) });
                }
            }
            return this;
        }

        public ObjectCriteria AddGreaterOrEqualsCriteria(string propertyName, object value)
        {

            if (value != null)
            {
                where.Add(Restrictions.Ge(propertyName, value));
                if (isUsingQuery)
                {
                    queryCriteria.Add(new SQLQueryCriteria { PropertyName = propertyName, SQLString = " >= ", Value = value, Type = ObjectConverter.ConvertToNHibernateType(value.GetType()) });
                }
            }
            return this;
        }

        public ObjectCriteria AddGreaterCriteria(string propertyName, object value)
        {

            if (value != null)
            {
                where.Add(Restrictions.Gt(propertyName, value));
                if (isUsingQuery)
                {
                    queryCriteria.Add(new SQLQueryCriteria { PropertyName = propertyName, SQLString = " > ", Value = value, Type = ObjectConverter.ConvertToNHibernateType(value.GetType()) });
                }
            }
            return this;
        }

        public ObjectCriteria AddLesserOrEqualsCriteria(string propertyName, object value)
        {

            if (value != null)
            {
                where.Add(Restrictions.Le(propertyName, value));
                if (isUsingQuery)
                {
                    queryCriteria.Add(new SQLQueryCriteria 
                                          { 
                                              PropertyName = propertyName, 
                                              SQLString = " <= ", 
                                              Value = value,
                                              Type = ObjectConverter.ConvertToNHibernateType(value.GetType())
                                          });
                }
            }
            return this;
        }

        public ObjectCriteria AddLesserCriteria(string propertyName, object value)
        {

            if (value != null)
            {
                where.Add(Restrictions.Lt(propertyName, value));
                if (isUsingQuery)
                {
                    queryCriteria.Add(new SQLQueryCriteria
                                          {
                                              PropertyName = propertyName,
                                              SQLString = " < ",
                                              Value = value,
                                              Type = ObjectConverter.ConvertToNHibernateType(value.GetType())
                                          });
                }
            }
            return this;
        }

        public ObjectCriteria AddNotEqualsCriteria(string propertyName, object value)
        {

            if (value != null)
            {
                where.Add(Restrictions.Not(Restrictions.Eq(propertyName, value)));
                if (isUsingQuery)
                {
                    queryCriteria.Add(new SQLQueryCriteria
                                          {
                                              PropertyName = propertyName,
                                              SQLString = " <> ",
                                              Value = value,
                                              Type = ObjectConverter.ConvertToNHibernateType(value.GetType())
                                          });
                }
            }
            return this;
        }

        public ObjectCriteria AddLikeCriteria(string propertyName, object value)
        {

            if (value != null)
            {
                where.Add(Restrictions.Like(propertyName, value));
                if (isUsingQuery)
                {
                    queryCriteria.Add(new SQLQueryCriteria
                                          {
                                              PropertyName = propertyName,
                                              SQLString = " like ",
                                              Value = value,
                                              Type = ObjectConverter.ConvertToNHibernateType(value.GetType())
                                          });
                }
            }
            return this;
        }

        public ObjectCriteria AddIsNullCriteria(string propertyName)
        {
            where.Add(Restrictions.IsNull(propertyName));
            if (isUsingQuery)
            {
                queryCriteria.Add(new SQLQueryCriteria
                                      {
                                          PropertyName = propertyName,
                                          SQLString = " is null "
                                      });
            }
            return this;
        }

        public ObjectCriteria AddIsNotNullCriteria(string propertyName)
        {
            where.Add(Restrictions.IsNotNull(propertyName));
            if (isUsingQuery)
            {
                queryCriteria.Add(new SQLQueryCriteria
                                      {
                                          PropertyName = propertyName,
                                          SQLString = " is not null "
                                      });
            }
            return this;
        }

        public ObjectCriteria AddIsEmptyCriteria(string propertyName)
        {
            where.Add(Expression.IsEmpty(propertyName));
            return this;
        }

        public ObjectCriteria AddIsNotEmptyCriteria(string propertyName)
        {
            where.Add(Restrictions.IsNotEmpty(propertyName));
            return this;
        }

        public ObjectCriteria AddBetweenCriteria(string propertyName, object low, object high)
        {

            if (low != null && high != null)
            {
                where.Add(Expression.Between(propertyName, low, high));
            }

            else
            {
                AddGreaterOrEqualsCriteria(propertyName, low);
                AddLesserOrEqualsCriteria(propertyName, high);
            }
            return this;
        }

        public ObjectCriteria AddBetweenNotEqualsCriteria(string propertyName, object low, object high)
        {
            AddGreaterCriteria(propertyName, low);
            AddLesserCriteria(propertyName, high);
            return this;
        }

        public ObjectCriteria AddSearchInCriteria(string propertyName, ICollection collection)
        {
            if (collection != null && collection.Count > 0)
            {
                where.Add(Restrictions.In(propertyName, collection));
            }
            return this;
        }

        public ObjectCriteria AddOrder(string propertyName, bool isAscending)
        {

            if (isAscending)
            {
                order.Add(Order.Asc(propertyName));
            }

            else
            {
                order.Add(Order.Desc(propertyName));
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

        public void AddSubCriteria(string propertyName, SubObjectCriteria criteria)
        {
            subCriteria.Add(propertyName, criteria);
        }

        public void RemoveSubCriteria(string propertyName)
        {
            subCriteria.Remove(propertyName);
        }

        public IDictionary<string, SubObjectCriteria> GetSubCriteria()
        {
            return subCriteria;
        }

        public List<SQLQueryCriteria> GetQueryCriteria()
        {
            return queryCriteria;
        }

        public bool IsUsingQuery
        {
            get { return isUsingQuery;  }
            set { isUsingQuery = value;}
        }
    }
}