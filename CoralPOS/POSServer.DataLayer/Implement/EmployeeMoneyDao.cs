             
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

namespace POSServer.DataLayer.Implement
{
    public class EmployeeMoneyDao : IEmployeeMoneyDao
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
        /// Find EmployeeMoney object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeMoney</param>
        /// <returns></returns>
        public EmployeeMoney FindById(object id)
        {
            return (EmployeeMoney) _hibernateTemplate.Get(typeof(EmployeeMoney), id);
        }
        
        /// <summary>
        /// Add EmployeeMoney to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public EmployeeMoney Add(EmployeeMoney data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Save("CoralPOS.Models.EmployeeMoney", data);
                        return data;
                    }
                );
            //_hibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update EmployeeMoney to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(EmployeeMoney data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Update("CoralPOS.Models.EmployeeMoney", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Update(data);
            return 0;
        }
        
        /// <summary>
        /// Delete EmployeeMoney from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(EmployeeMoney data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Delete("CoralPOS.Models.EmployeeMoney", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Delete(data);
            return 0;
        }
        
        /// <summary>
        /// Delete EmployeeMoney from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(object id)
        {
            EmployeeMoney obj = (EmployeeMoney) HibernateTemplate.Get(typeof (EmployeeMoney), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
            return 0;
        }
        
        /// <summary>
        /// Find all EmployeeMoney from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<EmployeeMoney> FindAll(LinqCriteria<EmployeeMoney> criteria)
        {
            return (IList<EmployeeMoney>) HibernateTemplate.Execute(
                                delegate(ISession session)
                                    {                                        
                                        QueryHandler<EmployeeMoney> handler = new QueryHandler<EmployeeMoney>(session);
                                        var result = handler.GetList(criteria);
                                        return result;
                                        
                                    }
                                    );
        }

        public IList<EmployeeMoney> FindAll(ObjectCriteria<EmployeeMoney> criteria)
        {
            return (IList<EmployeeMoney>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<EmployeeMoney> result = new List<EmployeeMoney>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(EmployeeMoney));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<EmployeeMoney>();
                                        return result;
                                    }
                                    catch(Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );
            
            
        }

        public object FindFirst(ObjectCriteria<EmployeeMoney> criteria)
        {
            return HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    object result = null;
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(EmployeeMoney));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<EmployeeMoney>()[0];
                                        return result;
                                    }
                                    catch (Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );


        }
		
		public IList<TClass> FindAllSubProperty<TClass>(LinqCriteria<EmployeeMoney> criteria,Func<EmployeeMoney,TClass> subProp)
        {
            return (IList<TClass>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<TClass> res = new List<TClass>();
                                    QueryHandler<EmployeeMoney> handler = new QueryHandler<EmployeeMoney>(session);
                                    IList<EmployeeMoney> products = handler.GetList(criteria);
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
        /// Find all EmployeeMoney from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<EmployeeMoney> criteria)
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

                                    IList<EmployeeMoney> result = new List<EmployeeMoney>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(EmployeeMoney));
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
        public int Count(ObjectCriteria<EmployeeMoney> criteria)
        {

            return (int)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    int result = 0;
                                    try
                                    {
                                        ICriteria hibernateCriteria =
                                            session.CreateCriteria(typeof (EmployeeMoney)).SetProjection(Projections.RowCount());
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
        public object SelectSpecificType(ObjectCriteria<EmployeeMoney> criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(EmployeeMoney)).SetProjection(type); ;
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

        private void SetCriteria(ICriteria hibernateCriteria, ObjectCriteria<EmployeeMoney> criteria)
        {
            IList<ICriterion> criterionList = criteria.GetWhere();
            foreach (ICriterion criterion in criterionList)
            {
                hibernateCriteria.Add(criterion);
            }
            foreach (KeyValuePair<Expression<Func<EmployeeMoney, object>>, Func<string, Order>> pair in criteria.GetOrder())
            {
                hibernateCriteria.AddOrder(pair.Key, pair.Value);

            }
            if(criteria.MaxResult > 0)
                hibernateCriteria.SetMaxResults(criteria.MaxResult);
        }
    }
}

