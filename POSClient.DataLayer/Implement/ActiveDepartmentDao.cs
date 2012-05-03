             
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using CoralPOS.Models;

namespace POSClient.DataLayer.Implement
{
    public class ActiveDepartmentDao : IActiveDepartmentDao
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
        /// Find ActiveDepartment object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ActiveDepartment</param>
        /// <returns></returns>
        public ActiveDepartment FindById(object id)
        {
            return (ActiveDepartment) _hibernateTemplate.Get(typeof(ActiveDepartment), id);
        }
        
        /// <summary>
        /// Add ActiveDepartment to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActiveDepartment Add(ActiveDepartment data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Save("CoralPOS.Models.ActiveDepartment", data);
                        return data;
                    }
                );
            //_hibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update ActiveDepartment to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(ActiveDepartment data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Update("CoralPOS.Models.ActiveDepartment", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Update(data);
            return 0;
        }
        
        /// <summary>
        /// Delete ActiveDepartment from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(ActiveDepartment data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Delete("CoralPOS.Models.ActiveDepartment", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Delete(data);
            return 0;
        }
        
        /// <summary>
        /// Delete ActiveDepartment from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(object id)
        {
            ActiveDepartment obj = (ActiveDepartment) HibernateTemplate.Get(typeof (ActiveDepartment), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
            return 0;
        }
        
        /// <summary>
        /// Find all ActiveDepartment from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ActiveDepartment> FindAll(LinqCriteria<ActiveDepartment> criteria)
        {
            return (IList<ActiveDepartment>) HibernateTemplate.Execute(
                                delegate(ISession session)
                                    {                                        
                                        QueryHandler<ActiveDepartment> handler = new QueryHandler<ActiveDepartment>(session);
                                        var result = handler.GetList(criteria);
                                        return result;
                                        
                                    }
                                    );
        }

        public IList<ActiveDepartment> FindAll(ObjectCriteria<ActiveDepartment> criteria)
        {
            return (IList<ActiveDepartment>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<ActiveDepartment> result = new List<ActiveDepartment>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(ActiveDepartment));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<ActiveDepartment>();
                                        return result;
                                    }
                                    catch(Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );
            
            
        }

        public object FindFirst(ObjectCriteria<ActiveDepartment> criteria)
        {
            return HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    object result = null;
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(ActiveDepartment));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<ActiveDepartment>()[0];
                                        return result;
                                    }
                                    catch (Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );


        }
		
		public IList<TClass> FindAllSubProperty<TClass>(LinqCriteria<ActiveDepartment> criteria,Func<ActiveDepartment,TClass> subProp)
        {
            return (IList<TClass>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<TClass> res = new List<TClass>();
                                    QueryHandler<ActiveDepartment> handler = new QueryHandler<ActiveDepartment>(session);
                                    IList<ActiveDepartment> products = handler.GetList(criteria);
                                    var list = products.Select(subProp);
                                    foreach (TClass classe in list)
                                    {
                                        res.Add(classe);
                                    }
                                    return res;

                                }
                                    );
        }

        /// <summary>
        /// Find all ActiveDepartment from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ActiveDepartment> criteria)
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

                                    IList<ActiveDepartment> result = new List<ActiveDepartment>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(ActiveDepartment));
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
        public int Count(ObjectCriteria<ActiveDepartment> criteria)
        {

            return (int)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    int result = 0;
                                    try
                                    {
                                        ICriteria hibernateCriteria =
                                            session.CreateCriteria(typeof (ActiveDepartment)).SetProjection(Projections.RowCount());
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
        public object SelectSpecificType(ObjectCriteria<ActiveDepartment> criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(ActiveDepartment)).SetProjection(type); ;
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

        private void SetCriteria(ICriteria hibernateCriteria, ObjectCriteria<ActiveDepartment> criteria)
        {
            IList<ICriterion> criterionList = criteria.GetWhere();
            foreach (ICriterion criterion in criterionList)
            {
                hibernateCriteria.Add(criterion);
            }
            foreach (KeyValuePair<Expression<Func<ActiveDepartment, object>>, Func<string, Order>> pair in criteria.GetOrder())
            {
                hibernateCriteria.AddOrder(pair.Key, pair.Value);

            }
            if(criteria.MaxResult > 0)
                hibernateCriteria.SetMaxResults(criteria.MaxResult);
        }
		
		/// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="exposeSession"></param>
        /// <returns></returns>
        public object Execute(IHibernateCallback callback, bool exposeSession)
        {
            return HibernateTemplate.Execute(callback, exposeSession);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delegated"></param>
        /// <returns></returns>
        public object Execute(HibernateDelegate delegated)
        {
            return HibernateTemplate.Execute(delegated);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delegated"></param>
        /// <returns></returns>
        public object ExecuteExposedSession(HibernateDelegate delegated)
        {
            return HibernateTemplate.Execute(delegated, true);
        }
    }
}

