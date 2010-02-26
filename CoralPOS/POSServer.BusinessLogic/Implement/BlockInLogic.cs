			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class BlockInLogicImpl : IBlockInLogic
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
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add BlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public BlockIn Add(BlockIn data)
        {
            _innerDao.Add(data);
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
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete BlockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(BlockIn data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete BlockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all BlockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<BlockIn> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all BlockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}