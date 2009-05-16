using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Spring.Data.NHibernate;
using AppFrame.Model;

namespace AppFrame.DataLayer
{
    public class DepartmentManagementDAOImpl : IDepartmentManagementDAO
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
        /// Find DepartmentManagement object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentManagement</param>
        /// <returns></returns>
        public DepartmentManagement FindById(object id)
        {
            return (DepartmentManagement) HibernateTemplate.Get(typeof(DepartmentManagement), id);
        }
        
        /// <summary>
        /// Add DepartmentManagement to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DepartmentManagement Add(DepartmentManagement data)
        {
            HibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentManagement to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Update(DepartmentManagement data)
        {
            HibernateTemplate.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentManagement from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Delete(DepartmentManagement data)
        {
            HibernateTemplate.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentManagement from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(object id)
        {
            DepartmentManagement obj = (DepartmentManagement) HibernateTemplate.Get(typeof (DepartmentManagement), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
        }
        
        /// <summary>
        /// Find all DepartmentManagement from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try 
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentManagement));
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
        /// Find all DepartmentManagement from database. Has pagination.
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
    
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentManagement));
    
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
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentManagement)).SetProjection(Projections.RowCount()); ;
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
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentManagement)).SetProjection(type); ;
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

        #region IDepartmentManagementDAO Members


        public DepartmentManagement FindLastPeriod()
        {
            return (DepartmentManagement) HibernateTemplate.Execute(
                delegate (ISession session)
                    {
                        try
                        {
                            string sql = "SELECT DISTINCT dm from DepartmentManagement dm WHERE dm.EndTime < dm.StartTime ORDER BY dm.StartTime DESC";
                            IList result = session.CreateQuery(sql).SetMaxResults(5).List();
                            
                            // if we has more than 1 result
                            if(result.Count > 1)
                            {
                                // fix department management
                                foreach (DepartmentManagement departmentManagement in result)
                                {
                                    departmentManagement.EndTime = DateTime.Now;
                                    session.Update(departmentManagement);
                                }    
                            }
                            return result[0];
                        }
                        catch (Exception)
                        {

                            return null;
                        }
                    }
                                              );
        }

        #endregion
    }
}