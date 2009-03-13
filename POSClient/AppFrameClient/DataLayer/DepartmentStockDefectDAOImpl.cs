using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Common;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using AppFrame.Model;

namespace AppFrame.DataLayer
{
    public class DepartmentStockDefectDAOImpl : IDepartmentStockDefectDAO
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
        /// Find DepartmentStockDefect object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockDefect</param>
        /// <returns></returns>
        public DepartmentStockHistory FindById(object id)
        {
            return (DepartmentStockHistory)HibernateTemplate.Get(typeof(DepartmentStockHistory), id);
        }

        /// <summary>
        /// Add DepartmentStockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DepartmentStockHistory Add(DepartmentStockHistory data)
        {
            HibernateTemplate.Save(data);
            return data;
        }

        /// <summary>
        /// Update DepartmentStockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Update(DepartmentStockHistory data)
        {
            HibernateTemplate.Update(data);
        }

        /// <summary>
        /// Delete DepartmentStockDefect from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Delete(DepartmentStockHistory data)
        {
            HibernateTemplate.Delete(data);
        }

        /// <summary>
        /// Delete DepartmentStockDefect from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(object id)
        {
            DepartmentStockHistory obj = (DepartmentStockHistory)HibernateTemplate.Get(typeof(DepartmentStockHistory), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
        }

        /// <summary>
        /// Find all DepartmentStockDefect from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStockHistory));
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
        /// Find all DepartmentStockDefect from database. Has pagination.
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

                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStockHistory));

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
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStockHistory)).SetProjection(Projections.RowCount()); ;
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
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStockHistory)).SetProjection(type); ;
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

        #region IDepartmentStockDefectDAO Members


        public IList FindAllProductMasters()
        {
            return (IList)HibernateTemplate.Execute(
                 delegate(ISession session)
                 {
                     try
                     {
                         string queryString =
                                      " SELECT pm,SUM(st.Quantity) FROM ProductMaster pm,DepartmentStockDefect st " +
                                      " WHERE pm.ProductMasterId = st.ProductMaster.ProductMasterId " +
                                      " AND st.DepartmentStockDefectPK.DepartmentId = " + CurrentDepartment.Get().DepartmentId + " " +
                                      " GROUP BY pm.ProductName";
                         return session.CreateQuery(queryString).List();
                     }
                     catch (Exception)
                     {

                         return null;
                     }

                 }
               );
        }

        #endregion

        #region IDepartmentStockDefectDAO Members


        public IList FindByProductMasterName(ProductMaster master)
        {
            return (IList)HibernateTemplate.Execute(
                 delegate(ISession session)
                 {
                     try
                     {
                         string queryString =
                                      " SELECT st FROM ProductMaster pm,DepartmentStockDefect st " +
                                      " WHERE pm.ProductMasterId = st.ProductMaster.ProductMasterId AND st.ErrorCount > 0 " +
                                      " AND st.DepartmentStockDefectPK.DepartmentId = " + CurrentDepartment.Get().DepartmentId + " " +
                                      " AND pm.ProductName = '" + master.ProductName + "'";
                         return session.CreateQuery(queryString).List();
                     }
                     catch (Exception exp)
                     {

                         return null;
                     }

                 }
               );
        }

        #endregion
    }
}