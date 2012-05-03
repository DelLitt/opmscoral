             
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
    public class DepartmentPurchaseOrderDetailLogDao : IDepartmentPurchaseOrderDetailLogDao
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
        /// Find DepartmentPurchaseOrderDetailLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentPurchaseOrderDetailLog</param>
        /// <returns></returns>
        public DepartmentPurchaseOrderDetailLog FindById(object id)
        {
            return (DepartmentPurchaseOrderDetailLog) _hibernateTemplate.Get(typeof(DepartmentPurchaseOrderDetailLog), id);
        }
        
        /// <summary>
        /// Add DepartmentPurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DepartmentPurchaseOrderDetailLog Add(DepartmentPurchaseOrderDetailLog data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Save("CoralPOS.Models.DepartmentPurchaseOrderDetailLog", data);
                        return data;
                    }
                );
            //_hibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentPurchaseOrderDetailLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(DepartmentPurchaseOrderDetailLog data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Update("CoralPOS.Models.DepartmentPurchaseOrderDetailLog", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Update(data);
            return 0;
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(DepartmentPurchaseOrderDetailLog data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Delete("CoralPOS.Models.DepartmentPurchaseOrderDetailLog", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Delete(data);
            return 0;
        }
        
        /// <summary>
        /// Delete DepartmentPurchaseOrderDetailLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(object id)
        {
            DepartmentPurchaseOrderDetailLog obj = (DepartmentPurchaseOrderDetailLog) HibernateTemplate.Get(typeof (DepartmentPurchaseOrderDetailLog), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
            return 0;
        }
        
        /// <summary>
        /// Find all DepartmentPurchaseOrderDetailLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentPurchaseOrderDetailLog> FindAll(LinqCriteria<DepartmentPurchaseOrderDetailLog> criteria)
        {
            return (IList<DepartmentPurchaseOrderDetailLog>) HibernateTemplate.Execute(
                                delegate(ISession session)
                                    {                                        
                                        QueryHandler<DepartmentPurchaseOrderDetailLog> handler = new QueryHandler<DepartmentPurchaseOrderDetailLog>(session);
                                        var result = handler.GetList(criteria);
                                        return result;
                                        
                                    }
                                    );
        }

        public IList<DepartmentPurchaseOrderDetailLog> FindAll(ObjectCriteria<DepartmentPurchaseOrderDetailLog> criteria)
        {
            return (IList<DepartmentPurchaseOrderDetailLog>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<DepartmentPurchaseOrderDetailLog> result = new List<DepartmentPurchaseOrderDetailLog>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentPurchaseOrderDetailLog));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<DepartmentPurchaseOrderDetailLog>();
                                        return result;
                                    }
                                    catch(Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );
            
            
        }

        public object FindFirst(ObjectCriteria<DepartmentPurchaseOrderDetailLog> criteria)
        {
            return HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    object result = null;
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentPurchaseOrderDetailLog));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<DepartmentPurchaseOrderDetailLog>()[0];
                                        return result;
                                    }
                                    catch (Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );


        }
		
		public IList<TClass> FindAllSubProperty<TClass>(LinqCriteria<DepartmentPurchaseOrderDetailLog> criteria,Func<DepartmentPurchaseOrderDetailLog,TClass> subProp)
        {
            return (IList<TClass>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<TClass> res = new List<TClass>();
                                    QueryHandler<DepartmentPurchaseOrderDetailLog> handler = new QueryHandler<DepartmentPurchaseOrderDetailLog>(session);
                                    IList<DepartmentPurchaseOrderDetailLog> products = handler.GetList(criteria);
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
        /// Find all DepartmentPurchaseOrderDetailLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentPurchaseOrderDetailLog> criteria)
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

                                    IList<DepartmentPurchaseOrderDetailLog> result = new List<DepartmentPurchaseOrderDetailLog>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentPurchaseOrderDetailLog));
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
        public int Count(ObjectCriteria<DepartmentPurchaseOrderDetailLog> criteria)
        {

            return (int)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    int result = 0;
                                    try
                                    {
                                        ICriteria hibernateCriteria =
                                            session.CreateCriteria(typeof (DepartmentPurchaseOrderDetailLog)).SetProjection(Projections.RowCount());
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
        public object SelectSpecificType(ObjectCriteria<DepartmentPurchaseOrderDetailLog> criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(DepartmentPurchaseOrderDetailLog)).SetProjection(type); ;
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

        private void SetCriteria(ICriteria hibernateCriteria, ObjectCriteria<DepartmentPurchaseOrderDetailLog> criteria)
        {
            IList<ICriterion> criterionList = criteria.GetWhere();
            foreach (ICriterion criterion in criterionList)
            {
                hibernateCriteria.Add(criterion);
            }
            foreach (KeyValuePair<Expression<Func<DepartmentPurchaseOrderDetailLog, object>>, Func<string, Order>> pair in criteria.GetOrder())
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

