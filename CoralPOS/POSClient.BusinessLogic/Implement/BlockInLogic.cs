			 


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
    public class BlockInLogic : IBlockInLogic
    {
        private IBlockInDao _innerDao;
        public IBlockInDao BlockInDao
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
        /// Find BlockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of BlockIn</param>
        /// <returns></returns>
        public BlockIn FindById(object id)
        {
            return BlockInDao.FindById(id);
        }
        
        /// <summary>
        /// Add BlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public BlockIn Add(BlockIn data)
        {
            BlockInDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update BlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(BlockIn data)
        {
            BlockInDao.Update(data);
        }
        
        /// <summary>
        /// Delete BlockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(BlockIn data)
        {
            BlockInDao.Delete(data);
        }
        
        /// <summary>
        /// Delete BlockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            BlockInDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all BlockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<BlockIn> FindAll(ObjectCriteria<BlockIn> criteria)
        {
            return BlockInDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all BlockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<BlockIn> criteria)
        {
            return BlockInDao.FindPaging(criteria);
        }
    }
}