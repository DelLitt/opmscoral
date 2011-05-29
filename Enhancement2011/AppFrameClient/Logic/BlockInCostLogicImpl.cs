using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class BlockInCostLogicImpl : IBlockInCostLogic
    {
        private IBlockInCostDAO _blockInCostDAO;

        public IBlockInCostDAO BlockInCostDAO
        {
            get 
            { 
                return _blockInCostDAO; 
            }
            set 
            { 
                _blockInCostDAO = value; 
            }
        }
        
        /// <summary>
        /// Find BlockInCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of BlockInCost</param>
        /// <returns></returns>
        public BlockInCost FindById(object id)
        {
            return BlockInCostDAO.FindById(id);
        }
        
        /// <summary>
        /// Add BlockInCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public BlockInCost Add(BlockInCost data)
        {
            BlockInCostDAO.Add(data);
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
            BlockInCostDAO.Update(data);
        }
        
        /// <summary>
        /// Delete BlockInCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(BlockInCost data)
        {
            BlockInCostDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete BlockInCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            BlockInCostDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all BlockInCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return BlockInCostDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all BlockInCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return BlockInCostDAO.FindPaging(criteria);
        }
    }
}