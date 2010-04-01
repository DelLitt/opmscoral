			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public class BlockInCostLogic : IBlockInCostLogic
    {
        private IBlockInCostDao _innerDao;
        public IBlockInCostDao BlockInCostDao
        {
            get 
            { 
                return _innerDao; 
            }
            set 
            { 
                _innerDao = value; 
            }
        }
        
        /// <summary>
        /// Find BlockInCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of BlockInCost</param>
        /// <returns></returns>
        public BlockInCost FindById(object id)
        {
            return BlockInCostDao.FindById(id);
        }
        
        /// <summary>
        /// Add BlockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public BlockInCost Add(BlockInCost data)
        {
            BlockInCostDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update BlockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(BlockInCost data)
        {
            BlockInCostDao.Update(data);
        }
        
        /// <summary>
        /// Delete BlockInCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(BlockInCost data)
        {
            BlockInCostDao.Delete(data);
        }
        
        /// <summary>
        /// Delete BlockInCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            BlockInCostDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all BlockInCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<BlockInCost> FindAll(ObjectCriteria<BlockInCost> criteria)
        {
            return BlockInCostDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all BlockInCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<BlockInCost> criteria)
        {
            return BlockInCostDao.FindPaging(criteria);
        }
    }
}