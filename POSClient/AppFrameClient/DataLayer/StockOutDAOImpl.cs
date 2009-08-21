using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using AppFrame.Model;

namespace AppFrame.DataLayer
{
    public class StockOutDAOImpl : IStockOutDAO
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
        /// Find StockOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOut</param>
        /// <returns></returns>
        public StockOut FindById(object id)
        {
            return (StockOut) HibernateTemplate.Get(typeof(StockOut), id);
        }
        
        /// <summary>
        /// Add StockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StockOut Add(StockOut data)
        {
            HibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update StockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Update(StockOut data)
        {
            HibernateTemplate.Update(data);
        }
        
        /// <summary>
        /// Delete StockOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Delete(StockOut data)
        {
            HibernateTemplate.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(object id)
        {
            StockOut obj = (StockOut) HibernateTemplate.Get(typeof (StockOut), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
        }
        
        /// <summary>
        /// Find all StockOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try 
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(StockOut));
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
        /// Find all StockOut from database. Has pagination.
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
    
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(StockOut));
    
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
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(StockOut)).SetProjection(Projections.RowCount()); ;
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
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(StockOut)).SetProjection(type); ;
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

        #region IStockOutDAO Members


        public IList FindByProductMaster(System.DateTime date, System.DateTime toDate)
        {
            return (IList)HibernateTemplate.Execute(
                               delegate(ISession session)
                               {
                                   IList list = null;
                                   try
                                   {
                                       string queryString =
                                           "SELECT pm,SUM(sodet.Quantity),SUM(sodet.Price) FROM ProductMaster pm,Product p,StockOutDetail sodet,DepartmentPrice dp" +
                                           " WHERE pm.ProductMasterId = p.ProductMaster.ProductMasterId AND sodet.StockOutDetailPK.ProductId = p.ProductId " +
                                           " AND sodet.StockOutDetailPK.StockOutId = so.StockOutId " +
                                           " AND pm.ProductMasterId = dp.DepartmentPricePK.ProductMasterId " +
                                           " AND sodet.StockOutDetailPK.StockOutId = so.StockOutId " +
                                           " AND so.DepartmentId = :deparmentId " +
                                           " AND sodet.CreateDate <= :toDate AND sodet.CreateDate >= :fromDate GROUP BY pm.ProductName";
                                       IQuery iQuery = session.CreateQuery(queryString);
                                       iQuery.SetParameter("toDate", toDate);
                                       iQuery.SetParameter("fromDate", date);
                                       list = iQuery.List();

                                   }
                                   catch (Exception e)
                                   {
                                       Console.Out.WriteLine(e.InnerException.Message);
                                   }
                                   return list;
                               }
                               );
        }

        #endregion

        #region IStockOutDAO Members


        public IList FindByProductMaster(long id, System.DateTime date, System.DateTime toDate)
        {
            return (IList)HibernateTemplate.Execute(
                               delegate(ISession session)
                               {
                                   IList list = null;
                                   try
                                   {
                                       string queryString =
                                           "SELECT pm,SUM(dsidet.Quantity),SUM(dp.Price) FROM ProductMaster pm,Product p,DepartmentStockInDetail dsidet,DepartmentPrice dp" +
                                           " WHERE pm.ProductMasterId = p.ProductMaster.ProductMasterId AND dsidet.StockOutDetailPK.ProductId = p.ProductId " +
                                           " AND pm.ProductMasterId = dp.DepartmentPricePK.ProductMasterId " +
                                           " AND dsidet.DepartmentStockInDetailPK.DepartmentId = :deparmentId " +
                                           " AND dsidet.CreateDate <= :toDate AND dsidet.CreateDate >= :fromDate GROUP BY pm.ProductName";
                                       IQuery iQuery = session.CreateQuery(queryString);
                                       iQuery.SetParameter("toDate", toDate);
                                       iQuery.SetParameter("fromDate", date);
                                       iQuery.SetParameter("departmentId", id);
                                       list = iQuery.List();

                                   }
                                   catch (Exception e)
                                   {
                                       Console.Out.WriteLine(e.InnerException.Message);
                                   }
                                   return list;
                               }
                               );
        }

        #endregion

        #region IStockOutDAO Members


        public IList FindStockOut(DateTime date, DateTime toDate)
        {
            return (IList)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList list = null;
                                    try
                                    {
                                        string queryString =
                                            "SELECT so, SUM(sodet.Quantity),so.DepartmentId FROM StockOut so,StockOutDetail sodet" +
                                            " WHERE so.StockoutId = sodet.StockOut.StockoutId  " +
                                            " AND so.DelFlg = 0 AND sodet.DelFlg = 0 " +
                                            " AND so.CreateDate <= :toDate AND so.CreateDate >= :fromDate GROUP BY so.StockoutId ";
                                        IQuery iQuery = session.CreateQuery(queryString);
                                        iQuery.SetParameter("toDate", toDate);
                                        iQuery.SetParameter("fromDate", date);
                                        list = iQuery.List();

                                    }
                                    catch (Exception e)
                                    {
                                        Console.Out.WriteLine(e.InnerException.Message);
                                    }
                                    return list;
                                }
                                );
        }

        #endregion
    }
}