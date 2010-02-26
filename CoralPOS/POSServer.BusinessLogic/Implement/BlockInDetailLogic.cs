			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class BlockInDetailLogicImpl : IBlockInDetailLogic
    {
        private IBlockInDetailDao _innerDao;

        public IBlockInDetailDao BlockInDetailDao
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
        /// Find BlockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of BlockInDetail</param>
        /// <returns></returns>
        public BlockInDetail FindById(object id)
        {
            return _innerDao.FindById(id);
        }
        
        /// <summary>
        /// Add BlockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public BlockInDetail Add(BlockInDetail data)
        {
            _innerDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update BlockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(BlockInDetail data)
        {
            _innerDao.Update(data);
        }
        
        /// <summary>
        /// Delete BlockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(BlockInDetail data)
        {
            _innerDao.Delete(data);
        }
        
        /// <summary>
        /// Delete BlockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            _innerDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all BlockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<BlockInDetail> FindAll(ObjectCriteria criteria)
        {
            return _innerDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all BlockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return _innerDao.FindPaging(criteria);
        }
    }
}