             
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSServer.DataLayer.Implement
{
    public class DepartmentStockInCostDao : IDepartmentStockInCostDao
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
        /// Find DepartmentStockInCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockInCost</param>
        /// <returns></returns>
        public DepartmentStockInCost FindById(object id)
        {
            return (DepartmentStockInCost) _hibernateTemplate.Get(typeof(DepartmentStockInCost), id);
        }
        
        /// <summary>
        /// Add DepartmentStockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DepartmentStockInCost Add(DepartmentStockInCost data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Save("CoralPOS.Models.DepartmentStockInCost", data);
                        return data;
                    }
                );
            //_hibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(DepartmentStockInCost data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Update("CoralPOS.Models.DepartmentStockInCost", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Update(data);
            return 0;
        }
        
        /// <summary>
        /// Delete DepartmentStockInCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(DepartmentStockInCost data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Delete("CoralPOS.Models.DepartmentStockInCost", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Delete(data);
            return 0;
        }
        
        /// <summary>
        /// Delete DepartmentStockInCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(object id)
        {
            DepartmentStockInCost obj = (DepartmentStockInCost) HibernateTemplate.Get(typeof (DepartmentStockInCost), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
            return 0;
        }
        
        /// <summary>
        /// Find all DepartmentStockInCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockInCost> FindAll(LinqCriteria<DepartmentStockInCost> criteria)
        {
            return (IList<DepartmentStockInCost>) HibernateTemplate.Execute(
                                delegate(ISession session)
                                    {                                        
                                        QueryHandler<DepartmentStockInCost> handler = new QueryHandler<DepartmentStockInCost>(session);
                                        var result = handler.GetList(criteria);
                                        return result;
                                        
                                    }
                                    );
        }

        public IList<DepartmentStockInCost> FindAll(ObjectCriteria<DepartmentStockInCost> criteria)
        {
            return (IList<DepartmentStockInCost>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<DepartmentStockInCost> result = new List<DepartmentStockInCost>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStockInCost));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<DepartmentStockInCost>();
                                        return result;
                                    }
                                    catch(Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );
            
            
        }

        public object FindFirst(ObjectCriteria<DepartmentStockInCost> criteria)
        {
            return HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    object result = null;
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStockInCost));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<DepartmentStockInCost>()[0];
                                        return result;
                                    }
                                    catch (Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );


        }

        /// <summary>
        /// Find all DepartmentStockInCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentStockInCost> criteria)
        {
            return (QueryResult)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    QueryResult queryResult = new QueryResult();
                                    if (criteria == null)
                                    {
                                        return queryResult;
                                    }
                                    int page = criteria.PageIndex;
                                    int pageSize = criteria.PageSize;
                                    queryResult.Page = page;

                                    int count = Count(criteria);
                                    if (count == 0)
                                    {
                                        return queryResult;
                                    }

            
                                    queryResult.TotalPage = (((count % pageSize == 0) ? (count / pageSize) : (count / pageSize + 1)));

                                    IList<DepartmentStockInCost> result = new List<DepartmentStockInCost>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStockInCost));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        hibernateCriteria.SetFirstResult((page - 1) * pageSize);
                                        hibernateCriteria.SetMaxResults(pageSize);
                                        IList list = hibernateCriteria.List();
                                        queryResult.Result = list;
                                        return queryResult;
                                    }
                                    catch (Exception ex)
                                    {
                                        return queryResult;
                                    }
                                }
                                    );
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public int Count(ObjectCriteria<DepartmentStockInCost> criteria)
        {

            return (int)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    int result = 0;
                                    try
                                    {
                                        ICriteria hibernateCriteria =
                                            session.CreateCriteria(typeof (DepartmentStockInCost)).SetProjection(Projections.RowCount());
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<int>()[0];
                                        return result;
                                    }
                                    catch (Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object SelectSpecificType(ObjectCriteria<DepartmentStockInCost> criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentStockInCost)).SetProjection(type); ;
                if (criteria != null)
                {
                    PosContext.SetCriteria(hibernateCriteria, criteria);
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

        private void SetCriteria(ICriteria hibernateCriteria, ObjectCriteria<DepartmentStockInCost> criteria)
        {
            IList<ICriterion> criterionList = criteria.GetWhere();
            foreach (ICriterion criterion in criterionList)
            {
                hibernateCriteria.Add(criterion);
            }
            foreach (KeyValuePair<Expression<Func<DepartmentStockInCost, object>>, Func<string, Order>> pair in criteria.GetOrder())
            {
                hibernateCriteria.AddOrder(pair.Key, pair.Value);

            }
            if(criteria.MaxResult > 0)
                hibernateCriteria.SetMaxResults(criteria.MaxResult);
        }
    }
}

