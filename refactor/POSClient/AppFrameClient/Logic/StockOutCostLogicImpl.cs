using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class StockOutCostLogicImpl : IStockOutCostLogic
    {
        private IStockOutCostDAO _stockOutCostDAO;

        public IStockOutCostDAO StockOutCostDAO
        {
            get 
            { 
                return _stockOutCostDAO; 
            }
            set 
            { 
                _stockOutCostDAO = value; 
            }
        }
        
        /// <summary>
        /// Find StockOutCost object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOutCost</param>
        /// <returns></returns>
        public StockOutCost FindById(object id)
        {
            return StockOutCostDAO.FindById(id);
        }
        
        /// <summary>
        /// Add StockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockOutCost Add(StockOutCost data)
        {
            StockOutCostDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update StockOutCost to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockOutCost data)
        {
            StockOutCostDAO.Update(data);
        }
        
        /// <summary>
        /// Delete StockOutCost from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockOutCost data)
        {
            StockOutCostDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOutCost from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockOutCostDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockOutCost from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return StockOutCostDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockOutCost from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return StockOutCostDAO.FindPaging(criteria);
        }
    }
}