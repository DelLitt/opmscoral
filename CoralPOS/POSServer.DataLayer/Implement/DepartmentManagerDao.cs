             
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
    public class DepartmentManagerDao : IDepartmentManagerDao
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
        /// Find DepartmentManager object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentManager</param>
        /// <returns></returns>
        public DepartmentManager FindById(object id)
        {
            return (DepartmentManager) _hibernateTemplate.Get(typeof(DepartmentManager), id);
        }
        
        /// <summary>
        /// Add DepartmentManager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DepartmentManager Add(DepartmentManager data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Save("CoralPOS.Models.DepartmentManager", data);
                        return data;
                    }
                );
            //_hibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentManager to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(DepartmentManager data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Update("CoralPOS.Models.DepartmentManager", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Update(data);
            return 0;
        }
        
        /// <summary>
        /// Delete DepartmentManager from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(DepartmentManager data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Delete("CoralPOS.Models.DepartmentManager", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Delete(data);
            return 0;
        }
        
        /// <summary>
        /// Delete DepartmentManager from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(object id)
        {
            DepartmentManager obj = (DepartmentManager) HibernateTemplate.Get(typeof (DepartmentManager), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
            return 0;
        }
        
        /// <summary>
        /// Find all DepartmentManager from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentManager> FindAll(LinqCriteria<DepartmentManager> criteria)
        {
            return (IList<DepartmentManager>) HibernateTemplate.Execute(
                                delegate(ISession session)
                                    {                                        
                                        QueryHandler<DepartmentManager> handler = new QueryHandler<DepartmentManager>(session);
                                        var result = handler.GetList(criteria);
                                        return result;
                                        
                                    }
                                    );
        }

        public IList<DepartmentManager> FindAll(ObjectCriteria<DepartmentManager> criteria)
        {
            return (IList<DepartmentManager>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<DepartmentManager> result = new List<DepartmentManager>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentManager));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<DepartmentManager>();
                                        return result;
                                    }
                                    catch(Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );
            
            
        }

        public object FindFirst(ObjectCriteria<DepartmentManager> criteria)
        {
            return HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    object result = null;
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentManager));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<DepartmentManager>()[0];
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
        /// Find all DepartmentManager from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentManager> criteria)
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

                                    IList<DepartmentManager> result = new List<DepartmentManager>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentManager));
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
        public int Count(ObjectCriteria<DepartmentManager> criteria)
        {

            return (int)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    int result = 0;
                                    try
                                    {
                                        ICriteria hibernateCriteria =
                                            session.CreateCriteria(typeof (DepartmentManager)).SetProjection(Projections.RowCount());
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
        public object SelectSpecificType(ObjectCriteria<DepartmentManager> criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentManager)).SetProjection(type); ;
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

        private void SetCriteria(ICriteria hibernateCriteria, ObjectCriteria<DepartmentManager> criteria)
        {
            IList<ICriterion> criterionList = criteria.GetWhere();
            foreach (ICriterion criterion in criterionList)
            {
                hibernateCriteria.Add(criterion);
            }
            foreach (KeyValuePair<Expression<Func<DepartmentManager, object>>, Func<string, Order>> pair in criteria.GetOrder())
            {
                hibernateCriteria.AddOrder(pair.Key, pair.Value);

            }
            if(criteria.MaxResult > 0)
                hibernateCriteria.SetMaxResults(criteria.MaxResult);
        }
    }
}

