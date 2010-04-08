             
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
    public class MainftrDao : IMainftrDao
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
        /// Find Mainftr object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Mainftr</param>
        /// <returns></returns>
        public Mainftr FindById(object id)
        {
            return (Mainftr) _hibernateTemplate.Get(typeof(Mainftr), id);
        }
        
        /// <summary>
        /// Add Mainftr to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Mainftr Add(Mainftr data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Save("CoralPOS.Models.Mainftr", data);
                        return data;
                    }
                );
            //_hibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update Mainftr to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(Mainftr data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Update("CoralPOS.Models.Mainftr", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Update(data);
            return 0;
        }
        
        /// <summary>
        /// Delete Mainftr from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(Mainftr data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Delete("CoralPOS.Models.Mainftr", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Delete(data);
            return 0;
        }
        
        /// <summary>
        /// Delete Mainftr from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(object id)
        {
            Mainftr obj = (Mainftr) HibernateTemplate.Get(typeof (Mainftr), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
            return 0;
        }
        
        /// <summary>
        /// Find all Mainftr from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Mainftr> FindAll(LinqCriteria<Mainftr> criteria)
        {
            return (IList<Mainftr>) HibernateTemplate.Execute(
                                delegate(ISession session)
                                    {                                        
                                        QueryHandler<Mainftr> handler = new QueryHandler<Mainftr>(session);
                                        var result = handler.GetList(criteria);
                                        return result;
                                        
                                    }
                                    );
        }

        public IList<Mainftr> FindAll(ObjectCriteria<Mainftr> criteria)
        {
            return (IList<Mainftr>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<Mainftr> result = new List<Mainftr>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(Mainftr));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<Mainftr>();
                                        return result;
                                    }
                                    catch(Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );
            
            
        }

        public object FindFirst(ObjectCriteria<Mainftr> criteria)
        {
            return HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    object result = null;
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(Mainftr));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<Mainftr>()[0];
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
        /// Find all Mainftr from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<Mainftr> criteria)
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

                                    IList<Mainftr> result = new List<Mainftr>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(Mainftr));
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
        public int Count(ObjectCriteria<Mainftr> criteria)
        {

            return (int)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    int result = 0;
                                    try
                                    {
                                        ICriteria hibernateCriteria =
                                            session.CreateCriteria(typeof (Mainftr)).SetProjection(Projections.RowCount());
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
        public object SelectSpecificType(ObjectCriteria<Mainftr> criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(Mainftr)).SetProjection(type); ;
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

        private void SetCriteria(ICriteria hibernateCriteria, ObjectCriteria<Mainftr> criteria)
        {
            IList<ICriterion> criterionList = criteria.GetWhere();
            foreach (ICriterion criterion in criterionList)
            {
                hibernateCriteria.Add(criterion);
            }
            foreach (KeyValuePair<Expression<Func<Mainftr, object>>, Func<string, Order>> pair in criteria.GetOrder())
            {
                hibernateCriteria.AddOrder(pair.Key, pair.Value);

            }
            if(criteria.MaxResult > 0)
                hibernateCriteria.SetMaxResults(criteria.MaxResult);
        }
    }
}

