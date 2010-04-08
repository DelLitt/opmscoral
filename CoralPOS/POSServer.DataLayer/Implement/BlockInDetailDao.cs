             
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
    public class BlockInDetailDao : IBlockInDetailDao
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
        /// Find BlockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of BlockInDetail</param>
        /// <returns></returns>
        public BlockInDetail FindById(object id)
        {
            return (BlockInDetail) _hibernateTemplate.Get(typeof(BlockInDetail), id);
        }
        
        /// <summary>
        /// Add BlockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BlockInDetail Add(BlockInDetail data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Save("CoralPOS.Models.BlockInDetail", data);
                        return data;
                    }
                );
            //_hibernateTemplate.Save(data);
            return data;
        }
        
        /// <summary>
        /// Update BlockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Update(BlockInDetail data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Update("CoralPOS.Models.BlockInDetail", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Update(data);
            return 0;
        }
        
        /// <summary>
        /// Delete BlockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(BlockInDetail data)
        {
			_hibernateTemplate.Execute(delegate(ISession session) 
                    {
                        session.Delete("CoralPOS.Models.BlockInDetail", data);
                        return 0;
                    }
                );
            //_hibernateTemplate.Delete(data);
            return 0;
        }
        
        /// <summary>
        /// Delete BlockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(object id)
        {
            BlockInDetail obj = (BlockInDetail) HibernateTemplate.Get(typeof (BlockInDetail), id);
            if (obj != null)
            {
                HibernateTemplate.Delete(obj);
            }
            return 0;
        }
        
        /// <summary>
        /// Find all BlockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<BlockInDetail> FindAll(LinqCriteria<BlockInDetail> criteria)
        {
            return (IList<BlockInDetail>) HibernateTemplate.Execute(
                                delegate(ISession session)
                                    {                                        
                                        QueryHandler<BlockInDetail> handler = new QueryHandler<BlockInDetail>(session);
                                        var result = handler.GetList(criteria);
                                        return result;
                                        
                                    }
                                    );
        }

        public IList<BlockInDetail> FindAll(ObjectCriteria<BlockInDetail> criteria)
        {
            return (IList<BlockInDetail>)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    IList<BlockInDetail> result = new List<BlockInDetail>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(BlockInDetail));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<BlockInDetail>();
                                        return result;
                                    }
                                    catch(Exception ex)
                                    {
                                        return result;
                                    }
                                }
                                    );
            
            
        }

        public object FindFirst(ObjectCriteria<BlockInDetail> criteria)
        {
            return HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    object result = null;
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(BlockInDetail));
                                        if (criteria != null)
                                        {
                                            PosContext.SetCriteria(hibernateCriteria, criteria);
                                        }
                                        result = hibernateCriteria.List<BlockInDetail>()[0];
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
        /// Find all BlockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<BlockInDetail> criteria)
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

                                    IList<BlockInDetail> result = new List<BlockInDetail>();
                                    try
                                    {
                                        ICriteria hibernateCriteria = session.CreateCriteria(typeof(BlockInDetail));
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
        public int Count(ObjectCriteria<BlockInDetail> criteria)
        {

            return (int)HibernateTemplate.Execute(
                                delegate(ISession session)
                                {
                                    int result = 0;
                                    try
                                    {
                                        ICriteria hibernateCriteria =
                                            session.CreateCriteria(typeof (BlockInDetail)).SetProjection(Projections.RowCount());
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
        public object SelectSpecificType(ObjectCriteria<BlockInDetail> criteria, IProjection type)
        {

            ISession session = HibernateTemplate.SessionFactory.OpenSession();
            try
            {
                ICriteria hibernateCriteria = session.CreateCriteria(typeof(BlockInDetail)).SetProjection(type); ;
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

        private void SetCriteria(ICriteria hibernateCriteria, ObjectCriteria<BlockInDetail> criteria)
        {
            IList<ICriterion> criterionList = criteria.GetWhere();
            foreach (ICriterion criterion in criterionList)
            {
                hibernateCriteria.Add(criterion);
            }
            foreach (KeyValuePair<Expression<Func<BlockInDetail, object>>, Func<string, Order>> pair in criteria.GetOrder())
            {
                hibernateCriteria.AddOrder(pair.Key, pair.Value);

            }
            if(criteria.MaxResult > 0)
                hibernateCriteria.SetMaxResults(criteria.MaxResult);
        }
    }
}

