using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class StockOutDetailLogicImpl : IStockOutDetailLogic
    {
        private IStockOutDetailDAO _stockOutDetailDAO;

        public IStockOutDetailDAO StockOutDetailDAO
        {
            get 
            { 
                return _stockOutDetailDAO; 
            }
            set 
            { 
                _stockOutDetailDAO = value; 
            }
        }
        
        /// <summary>
        /// Find StockOutDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOutDetail</param>
        /// <returns></returns>
        public StockOutDetail FindById(object id)
        {
            return StockOutDetailDAO.FindById(id);
        }
        
        /// <summary>
        /// Add StockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockOutDetail Add(StockOutDetail data)
        {
            StockOutDetailDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update StockOutDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockOutDetail data)
        {
            StockOutDetailDAO.Update(data);
        }
        
        /// <summary>
        /// Delete StockOutDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockOutDetail data)
        {
            StockOutDetailDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOutDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockOutDetailDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockOutDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return StockOutDetailDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockOutDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return StockOutDetailDAO.FindPaging(criteria);
        }
    }
}