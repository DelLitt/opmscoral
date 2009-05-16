using System.Collections;
using System.Text;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class StockInDetailLogicImpl : IStockInDetailLogic
    {
        private IStockInDetailDAO _stockInDetailDAO;

        public IStockInDetailDAO StockInDetailDAO
        {
            get 
            { 
                return _stockInDetailDAO; 
            }
            set 
            { 
                _stockInDetailDAO = value; 
            }
        }
        
        /// <summary>
        /// Find StockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockInDetail</param>
        /// <returns></returns>
        public StockInDetail FindById(object id)
        {
            return StockInDetailDAO.FindById(id);
        }
        
        /// <summary>
        /// Add StockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockInDetail Add(StockInDetail data)
        {
            StockInDetailDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update StockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockInDetail data)
        {
            StockInDetailDAO.Update(data);
        }
        
        /// <summary>
        /// Delete StockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockInDetail data)
        {
            StockInDetailDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete StockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockInDetailDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return StockInDetailDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return StockInDetailDAO.FindPaging(criteria);
        }

        public IList FindByQueryForRemainStock(ObjectCriteria criteria, bool isMin)
        {
            var sqlString = new StringBuilder();
            if (isMin)
            {
                sqlString.Append("select stockindetail, min(stockin.StockInDate) FROM StockIn stockin, StockInDetail stockindetail, ProductMaster pm WHERE stockindetail.ProductMaster.ProductMasterId = pm.ProductMasterId AND stockin.StockInId = stockindetail.StockInId ");
            }
            else
            {
                sqlString.Append("select stockindetail, max(stockin.StockInDate) FROM StockIn stockin, StockInDetail stockindetail, ProductMaster pm WHERE stockindetail.ProductMaster.ProductMasterId = pm.ProductMasterId AND stockin.StockInId = stockindetail.StockInId ");
            }
            
            foreach (SQLQueryCriteria crit in criteria.GetQueryCriteria())
            {
                sqlString.Append(" AND ")
                       .Append(crit.PropertyName)
                       .Append(" ")
                       .Append(crit.SQLString)
                       .Append(" :")
                       .Append(crit.PropertyName)
                       .Append(" ");
            }
            sqlString.Append(" Group BY pm.ProductMasterId");
            return StockInDetailDAO.FindByQueryForRemainStockMin(sqlString.ToString(), criteria);
        }


    }
}