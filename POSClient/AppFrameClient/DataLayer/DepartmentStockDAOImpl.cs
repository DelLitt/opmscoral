using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Utility;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using AppFrame.Model;

namespace AppFrame.DataLayer
{
    public class DepartmentStockDAOImpl : IDepartmentStockDAO
    {
        private HibernateTemplate _hibernateTemplate;

        public HibernateTemplate HibernateTemplate
        {
            get 
            { 
                return _hibernateTemplate; 
            }
            set 
            { 
                _hibernateTemplate = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentStock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStock</param>
        /// <returns></returns>
        public DepartmentStock FindById(object id)
        {
            return (DepartmentStock) HibernateTemplate.Get(typeof(DepartmentStock), id);
        }
        
        /// <summary>
        /// Add DepartmentStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DepartmentStock Add(DepartmentStock data)
        {
            HibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Update(DepartmentStock data)
        {
            HibernateTemplate.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Delete(DepartmentStock data)
        {
            HibernateTemplate.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(object id)
        {
            DepartmentStock obj = (DepartmentStock) HibernateTemplate.Get(typeof (DepartmentStock), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
        }
        
        /// <summary>
        /// Find all DepartmentStock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try 
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStock));
                if (criteria != null)
                {
                    IDictionary<string, SubObjectCriteria> map = criteria.GetSubCriteria();
                    if (map.Count > 0)
                    {
                        foreach (string key in map.Keys)
                        {
                            hibernateCriteria.CreateAlias(key, key);
                        }
                        AddCriteriaAndOrder(hibernateCriteria, criteria.GetWhere(), criteria.GetOrder());
    
                        foreach (string key in map.Keys)
                        {
                            SubObjectCriteria subCriteria = null;
                            map.TryGetValue(key, out subCriteria);
                            AddCriteriaAndOrder(hibernateCriteria, subCriteria.GetWhere(), subCriteria.GetOrder());
                        }
                    } 
                    else
                    {
                        AddCriteriaAndOrder(hibernateCriteria, criteria.GetWhere(), criteria.GetOrder());
                    }
                }
                return hibernateCriteria.List();
            }
            finally 
            {
                if (session != null)
                {
                    session.Disconnect();
                }
            }
        }
        
        /// <summary>
        /// Find all DepartmentStock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            QueryResult queryResult = new QueryResult();
            if (criteria == null)
            {
                return null;
            }

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try 
            {
                int page = criteria.PageIndex;
                int pageSize = criteria.PageSize;
                queryResult.Page = page;
    
                int count = Count(criteria);
                if (count == 0)
                {
                   return null;
                }
                queryResult.TotalPage = (((count % pageSize == 0) ? (count / pageSize) : (count / pageSize + 1)));
    
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStock));
    
                IDictionary<string, SubObjectCriteria> map = criteria.GetSubCriteria();
                if (map.Count > 0)
                {
                    foreach (string key in map.Keys)
                    {
                        hibernateCriteria.CreateAlias(key, key);
                    }
                    AddCriteriaAndOrder(hibernateCriteria, criteria.GetWhere(), criteria.GetOrder());
    
                    SubObjectCriteria subCriteria = null;
                    foreach (string key in map.Keys)
                    {
                        map.TryGetValue(key, out subCriteria);
                        AddCriteriaAndOrder(hibernateCriteria, subCriteria.GetWhere(), subCriteria.GetOrder());
                    }
                }
                else
                {
                    AddCriteriaAndOrder(hibernateCriteria, criteria.GetWhere(), criteria.GetOrder());
                }
                hibernateCriteria.SetFirstResult((page - 1) * pageSize);
                hibernateCriteria.SetMaxResults(pageSize);
                IList list = hibernateCriteria.List();
                if (list.Count == 0)
                {
                   return null;
                }
                else
                {
                   queryResult.Result = list;
                }
            }
            finally 
            {
                if (session != null)
                {
                    session.Disconnect();
                }
            }
         
            return queryResult;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        private int Count(ObjectCriteria criteria)
        {
           
            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try 
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStock)).SetProjection(Projections.RowCount()); ;
                if (criteria != null)
                {
                    IDictionary<string, SubObjectCriteria> map = criteria.GetSubCriteria();
                    if (map.Count > 0)
                    {
                        foreach (string key in map.Keys)
                        {
                            hibernateCriteria.CreateAlias(key, key);
                        }
                        foreach (ICriterion criterion in criteria.GetWhere())
                        {
                            hibernateCriteria.Add(criterion);
                        }
    
                        SubObjectCriteria subCriteria;
                        foreach (string key in map.Keys)
                        {
                            map.TryGetValue(key, out subCriteria);
                            foreach (ICriterion criterion in subCriteria.GetWhere())
                            {
                                hibernateCriteria.Add(criterion);
                            }
                        }
                    }
                    else
                    {
                        foreach (ICriterion criterion in criteria.GetWhere())
                        {
                            hibernateCriteria.Add(criterion);
                        }
                    }
                }
                return ((int)hibernateCriteria.List()[0]);
            }
            finally 
            {
                if (session != null)
                {
                    session.Disconnect();
                }
            }
        }
        
        public object SelectSpecificType(ObjectCriteria criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStock)).SetProjection(type); ;
                if (criteria != null)
                {
                    IDictionary<string, SubObjectCriteria> map = criteria.GetSubCriteria();
                    if (map.Count > 0)
                    {
                        foreach (string key in map.Keys)
                        {
                            hibernateCriteria.CreateAlias(key, key);
                        }
                        foreach (ICriterion criterion in criteria.GetWhere())
                        {
                            hibernateCriteria.Add(criterion);
                        }

                        SubObjectCriteria subCriteria;
                        foreach (string key in map.Keys)
                        {
                            map.TryGetValue(key, out subCriteria);
                            foreach (ICriterion criterion in subCriteria.GetWhere())
                            {
                                hibernateCriteria.Add(criterion);
                            }
                        }
                    }
                    else
                    {
                        foreach (ICriterion criterion in criteria.GetWhere())
                        {
                            hibernateCriteria.Add(criterion);
                        }
                    }
                }
                return (hibernateCriteria.List()[0]);
            }
            finally
            {
                if (session != null)
                {
                    session.Disconnect();
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hibernateCriteria"></param>
        /// <param name="where"></param>
        /// <param name="orders"></param>
        private void AddCriteriaAndOrder(ICriteria hibernateCriteria, IEnumerable<ICriterion> where, IEnumerable<Order> orders)
        {
            foreach (ICriterion criterion in where)
            {
                hibernateCriteria.Add(criterion);
            }

            foreach (Order order in orders)
            {
                hibernateCriteria.AddOrder(order);
            }
        }

        public IList FindByQuery(string sqlString, ObjectCriteria criteria)
        {
            List<SQLQueryCriteria> query = criteria.GetQueryCriteria();
            var paramNames = new List<string>();
            var values = new List<object>();
            foreach (SQLQueryCriteria crit in query)
            {
                //sqlString += " AND " + crit.PropertyName + " " + crit.SQLString + " :" + crit.PropertyName + " ";
                paramNames.Add(crit.PropertyName);
                values.Add(crit.Value);
            }

            IList list = HibernateTemplate.FindByNamedParam(sqlString, paramNames.ToArray(), values.ToArray());

            IList returnList = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                object[] obj = (object[]) list[i];
                long qty = Int64.Parse(obj[1].ToString());
                var result = new DepartmentStockSearchResult
                                 {
                                     DepartmentStock = ((DepartmentStock)obj[0]),
                                     SumQuantity = qty,
                                     SumInPrice = Int64.Parse(obj[2].ToString()),
                                     SumSellPrice = obj[3] != null ? ((DepartmentPrice)obj[3]).Price * qty : 0//Int64.Parse(obj[3].ToString())
                                 };
                returnList.Add(result);
            }
            return returnList;
        }

        public IList FindStockQuantityForPurchaseOrder(string sqlString, ObjectCriteria criteria)
        {
            List<SQLQueryCriteria> query = criteria.GetQueryCriteria();
            var paramNames = new List<string>();
            var values = new List<object>();
            foreach (SQLQueryCriteria crit in query)
            {
                paramNames.Add(crit.PropertyName);
                values.Add(crit.Value);
            }

            IList list = HibernateTemplate.FindByNamedParam(sqlString, paramNames.ToArray(), values.ToArray());

            IList returnList = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                var obj = (object[])list[i];
                var result = new DepartmentStockSearchResult
                {
                    DepartmentStock = ((DepartmentStock)obj[0]),
                    DepartmentPrice = ((DepartmentPrice)obj[1])
                };
                returnList.Add(result);
            }
            return returnList;
        }

        public IList ListProductMasterStockQuery(string sqlString, ObjectCriteria criteria)
        {
            List<SQLQueryCriteria> query = criteria.GetQueryCriteria();
            var paramNames = new List<string>();
            var values = new List<object>();
            foreach (SQLQueryCriteria crit in query)
            {
                //sqlString += " AND " + crit.PropertyName + " " + crit.SQLString + " :" + crit.PropertyName + " ";
                paramNames.Add(crit.PropertyName);
                values.Add(crit.Value);
            }

            return HibernateTemplate.FindByNamedParam(sqlString, paramNames.ToArray(), values.ToArray());
        }

        public IList FindByQueryForDeptStock(string sqlString, ObjectCriteria criteria)
        {
            ISession session = DbUtility.getSession(HibernateTemplate);
            try
            {
                List<SQLQueryCriteria> query = criteria.GetQueryCriteria();
                var paramNames = new List<string>();
                var values = new List<object>();
                foreach (SQLQueryCriteria crit in query)
                {
                    //sqlString += " AND " + crit.PropertyName + " " + crit.SQLString + " :" + crit.PropertyName + " ";
                    paramNames.Add(crit.PropertyName);
                    values.Add(crit.Value);
                }
                IList list = HibernateTemplate.FindByNamedParam(sqlString, paramNames.ToArray(), values.ToArray());
                IList returnList = new ArrayList();
                for (int i = 0; i < list.Count; i++)
                {
                    var stock = (DepartmentStock)((object[])list[i])[0];
                    stock.Quantity = Int64.Parse(((object[])list[i])[1].ToString());
                    returnList.Add(stock);
                }
                return returnList;
            }
            finally
            {
                session.Close();
            }

        }
    }
}