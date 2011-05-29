using System;
using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ProductSizeLogicImpl : IProductSizeLogic
    {
        public IProductSizeDAO ProductSizeDAO { get; set; }

        /// <summary>
        /// Find ProductSize object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductSize</param>
        /// <returns></returns>
        public ProductSize FindById(object id)
        {
            return ProductSizeDAO.FindById(id);
        }
        
        /// <summary>
        /// Add ProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ProductSize Add(ProductSize data)
        {
            var maxId = ProductSizeDAO.SelectSpecificType(null, Projections.Max("SizeId"));

            data.SizeId = maxId == null ? 1 : (Int64.Parse(maxId.ToString()) + 1);
            ProductSizeDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ProductSize to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ProductSize data)
        {
            ProductSizeDAO.Update(data);
        }
        
        /// <summary>
        /// Delete ProductSize from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ProductSize data)
        {
            ProductSizeDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete ProductSize from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ProductSizeDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ProductSize from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ProductSizeDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ProductSize from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ProductSizeDAO.FindPaging(criteria);
        }
    }
}