             
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
    public class ProductMasterDao : IProductMasterDao
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
        /// Find ProductMaster object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductMaster</param>
        /// <returns></returns>
        public ProductMaster FindById(object id)
        {
            return (ProductMaster)_hibernateTemplate.Get(typeof(ProductMaster), id);
        }

        /// <summary>
        /// Add ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ProductMaster Add(ProductMaster data)
        {
            _hibernateTemplate.Execute(delegate(ISession session)
                    {
                        session.Save("CoralPOS.Models.ProductMaster", data);
                        return data;
                    }
                );
            //_hibernateTemplate.Save(data);
            return data;
        }

        /// <summary>
        /// Update ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(ProductMaster data)
        {
            _hibernateTemplate.Execute(delegate(ISession session)
                    {
                        session.Update("CoralPOS.Models.ProductMaster", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Update(data);
            return 0;
        }

        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(ProductMaster data)
        {
            _hibernateTemplate.Execute(delegate(ISession session)
                    {
                        session.Delete("CoralPOS.Models.ProductMaster", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Delete(data);
            return 0;
        }

        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(object id)
        {
            ProductMaster obj = (ProductMaster)HibernateTemplate.Get(typeof(ProductMaster), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
            return 0;
        }

        /// <summary>
        /// Find all ProductMaster from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ProductMaster> FindAll(LinqCriteria<ProductMaster> criteria)
        {
            return (IList<ProductMaster>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    QueryHandler<ProductMaster> handler = new QueryHandler<ProductMaster>(session);
                                    var result = handler.GetList(criteria);
                                    return result;

                                }
                                    );
        }

        public IList<ProductMaster> FindAll(ObjectCriteria<ProductMaster> criteria)
        {
            return (IList<ProductMaster>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<ProductMaster> result = new List<ProductMaster>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductMaster));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<ProductMaster>();
                                        return result;
                                    }
                                    catch (Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );


        }

        public object FindFirst(ObjectCriteria<ProductMaster> criteria)
        {
            return HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    object result = null;
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductMaster));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<ProductMaster>()[0];
                                        return result;
                                    }
                                    catch (Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );


        }

        public IList<TClass> FindAllSubProperty<TClass>(LinqCriteria<ProductMaster> criteria, Func<ProductMaster, TClass> subProp)
        {
            return (IList<TClass>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<TClass> res = new List<TClass>();
                                    QueryHandler<ProductMaster> handler = new QueryHandler<ProductMaster>(session);
                                    IList<ProductMaster> products = handler.GetList(criteria);
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
        /// Find all ProductMaster from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ProductMaster> criteria)
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

                                    IList<ProductMaster> result = new List<ProductMaster>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductMaster));
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
        public int Count(ObjectCriteria<ProductMaster> criteria)
        {

            return (int)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    int result = 0;
                                    try
                                    {
                                        ICriteria hibernateCriteria =
                                            session.CreateCriteria(typeof(ProductMaster)).SetProjection(Projections.RowCount());
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
        public object SelectSpecificType(ObjectCriteria<ProductMaster> criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(ProductMaster)).SetProjection(type); ;
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

        private void SetCriteria(ICriteria hibernateCriteria, ObjectCriteria<ProductMaster> criteria)
        {
            IList<ICriterion> criterionList = criteria.GetWhere();
            foreach (ICriterion criterion in criterionList)
            {
                hibernateCriteria.Add(criterion);
            }
            foreach (KeyValuePair<Expression<Func<ProductMaster, object>>, Func<string, Order>> pair in criteria.GetOrder())
            {
                hibernateCriteria.AddOrder(pair.Key, pair.Value);

            }
            if (criteria.MaxResult > 0)
                hibernateCriteria.SetMaxResults(criteria.MaxResult);
        }
        public IList FindProductMasterWithTypes(string p)
        {
            return (IList)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList result;
                                    /*LinqCriteria<ProductMaster> crit = new LinqCriteria<ProductMaster>();
                                    crit.Add(pm => pm.ProductName.Contains(p));
                                    crit.MaxResult = 15;
                                    QueryHandler<ProductMaster> queryHandler = new QueryHandler<ProductMaster>(session);
                                    return queryHandler.GetList(crit);*/
                                    ObjectCriteria<ProductMaster> crit = new ObjectCriteria<ProductMaster>();
                                    crit.MaxResult = 15;
                                    crit.Add(SqlExpression.Like<ProductMaster>(pm=>pm.ProductName,p));
                                    ICriteria hibernateCriteria =
                                            session.CreateCriteria(typeof(ProductMaster));
                                    if (crit != null)
                                    {
                                        PosContext.SetCriteria(hibernateCriteria, crit);
                                    }
                                    hibernateCriteria.SetFetchMode("ProductType", FetchMode.Eager);
                                    result = hibernateCriteria.List();
                                    return result;
                                }
                                    );
        }
    }
}

