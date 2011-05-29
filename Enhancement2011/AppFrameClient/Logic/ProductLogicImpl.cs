using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ProductLogicImpl : IProductLogic
    {
        private IProductDAO _productDAO;

        public IProductDAO ProductDAO
        {
            get 
            { 
                return _productDAO; 
            }
            set 
            { 
                _productDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Product object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Product</param>
        /// <returns></returns>
        public Product FindById(object id)
        {
            return ProductDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Product to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Product Add(Product data)
        {
            ProductDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Product to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Product data)
        {
            ProductDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Product from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Product data)
        {
            ProductDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Product from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ProductDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Product from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ProductDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Product from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ProductDAO.FindPaging(criteria);
        }

        #region IProductLogic Members


        public IList FindProductById(string id, int limit, bool allDepartment)
        {
            return ProductDAO.FindLikeId(id, limit, allDepartment);
        }

        #endregion
    }
}