             
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
    public class ProductTypeDao : IProductTypeDao
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
        /// Find ProductType object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductType</param>
        /// <returns></returns>
        public ProductType FindById(object id)
        {
            return (ProductType) _hibernateTemplate.Get(typeof(ProductType), id);
        }
        
        /// <summary>
        /// Add ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ProductType Add(ProductType data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Save("CoralPOS.Models.ProductType", data);
                        return data;
                    }
                );
            //_hibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(ProductType data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Update("CoralPOS.Models.ProductType", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Update(data);
            return 0;
        }
        
        /// <summary>
        /// Delete ProductType from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(ProductType data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Delete("CoralPOS.Models.ProductType", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Delete(data);
            return 0;
        }
        
        /// <summary>
        /// Delete ProductType from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(object id)
        {
            ProductType obj = (ProductType) HibernateTemplate.Get(typeof (ProductType), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
            return 0;
        }
        
        /// <summary>
        /// Find all ProductType from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ProductType> FindAll(LinqCriteria<ProductType> criteria)
        {
            return (IList<ProductType>) HibernateTemplate.Execute(
                                delegate(ISession session)
                                    {                                        
                                        QueryHandler<ProductType> handler = new QueryHandler<ProductType>(session);
                                        var result = handler.GetList(criteria);
                                        return result;
                                        
                                    }
                                    );
        }

        public IList<ProductType> FindAll(ObjectCriteria<ProductType> criteria)
        {
            return (IList<ProductType>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<ProductType> result = new List<ProductType>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductType));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<ProductType>();
                                        return result;
                                    }
                                    catch(Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );
            
            
        }

        public object FindFirst(ObjectCriteria<ProductType> criteria)
        {
            return HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    object result = null;
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductType));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<ProductType>()[0];
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
        /// Find all ProductType from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ProductType> criteria)
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

                                    IList<ProductType> result = new List<ProductType>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductType));
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
        public int Count(ObjectCriteria<ProductType> criteria)
        {

            return (int)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    int result = 0;
                                    try
                                    {
                                        ICriteria hibernateCriteria =
                                            session.CreateCriteria(typeof (ProductType)).SetProjection(Projections.RowCount());
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
        public object SelectSpecificType(ObjectCriteria<ProductType> criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductType)).SetProjection(type); ;
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

        private void SetCriteria(ICriteria hibernateCriteria, ObjectCriteria<ProductType> criteria)
        {
            IList<ICriterion> criterionList = criteria.GetWhere();
            foreach (ICriterion criterion in criterionList)
            {
                hibernateCriteria.Add(criterion);
            }
            foreach (KeyValuePair<Expression<Func<ProductType, object>>, Func<string, Order>> pair in criteria.GetOrder())
            {
                hibernateCriteria.AddOrder(pair.Key, pair.Value);

            }
            if(criteria.MaxResult > 0)
                hibernateCriteria.SetMaxResults(criteria.MaxResult);
        }
    }
}

