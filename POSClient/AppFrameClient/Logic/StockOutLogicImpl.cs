using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class StockOutLogicImpl : IStockOutLogic
    {
        private IStockOutDAO _stockOutDAO;

        public IStockOutDAO StockOutDAO
        {
            get 
            { 
                return _stockOutDAO; 
            }
            set 
            { 
                _stockOutDAO = value; 
            }
        }
        
        /// <summary>
        /// Find StockOut object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockOut</param>
        /// <returns></returns>
        public StockOut FindById(object id)
        {
            return StockOutDAO.FindById(id);
        }
        
        /// <summary>
        /// Add StockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockOut Add(StockOut data)
        {
            StockOutDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update StockOut to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockOut data)
        {
            StockOutDAO.Update(data);
        }
        
        /// <summary>
        /// Delete StockOut from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockOut data)
        {
            StockOutDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete StockOut from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockOutDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockOut from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return StockOutDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockOut from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return StockOutDAO.FindPaging(criteria);
        }

        #region IStockOutLogic Members


        public IList FindByProductMaster(System.DateTime date, System.DateTime toDate)
        {
            return null;//return StockOutDAO.FindByProductMaster(date, toDate);
        }

        #endregion

        #region IStockOutLogic Members


        public IList FindByProductMaster(long id, System.DateTime date, System.DateTime toDate)
        {
            return StockOutDAO.FindByProductMaster(id,date, toDate);
        }

        #endregion

        #region IStockOutLogic Members


        public long FindMaxId()
        {
            object maxId = StockOutDAO.SelectSpecificType(null, Projections.Max("StockoutId"));
            return maxId != null ? (long)maxId : 0;
        }

        #endregion

        #region IStockOutLogic Members


        public IList FindStockOut(System.DateTime date, System.DateTime toDate)
        {
            return StockOutDAO.FindStockOut(date, toDate);
        }

        #endregion
    }
}