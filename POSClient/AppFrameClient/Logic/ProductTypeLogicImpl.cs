using System;
using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ProductTypeLogicImpl : IProductTypeLogic
    {
        private IProductTypeDAO _productTypeDAO;

        public IProductTypeDAO ProductTypeDAO
        {
            get 
            { 
                return _productTypeDAO; 
            }
            set 
            { 
                _productTypeDAO = value; 
            }
        }
        
        /// <summary>
        /// Find ProductType object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductType</param>
        /// <returns></returns>
        public ProductType FindById(object id)
        {
            return ProductTypeDAO.FindById(id);
        }
        
        /// <summary>
        /// Add ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ProductType Add(ProductType data)
        {
            var maxId = ProductTypeDAO.SelectSpecificType(null, Projections.Max("TypeId"));

            data.TypeId = maxId == null ? 1 : (Int64.Parse(maxId.ToString()) + 1);
            ProductTypeDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ProductType to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ProductType data)
        {
            ProductTypeDAO.Update(data);
        }
        
        /// <summary>
        /// Delete ProductType from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ProductType data)
        {
            ProductTypeDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete ProductType from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ProductTypeDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ProductType from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ProductTypeDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ProductType from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ProductTypeDAO.FindPaging(criteria);
        }
    }
}