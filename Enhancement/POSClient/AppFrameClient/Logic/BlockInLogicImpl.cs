using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class BlockInLogicImpl : IBlockInLogic
    {
        private IBlockInDAO _blockInDAO;

        public IBlockInDAO BlockInDAO
        {
            get 
            { 
                return _blockInDAO; 
            }
            set 
            { 
                _blockInDAO = value; 
            }
        }
        
        /// <summary>
        /// Find BlockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of BlockIn</param>
        /// <returns></returns>
        public BlockIn FindById(object id)
        {
            return BlockInDAO.FindById(id);
        }
        
        /// <summary>
        /// Add BlockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public BlockIn Add(BlockIn data)
        {
            BlockInDAO.Add(data);
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
            BlockInDAO.Update(data);
        }
        
        /// <summary>
        /// Delete BlockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(BlockIn data)
        {
            BlockInDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete BlockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            BlockInDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all BlockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return BlockInDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all BlockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return BlockInDAO.FindPaging(criteria);
        }
    }
}