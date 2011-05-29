using System;
using System.Collections;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class ProductColorLogicImpl : IProductColorLogic
    {
        public IProductColorDAO ProductColorDAO { get; set; }

        /// <summary>
        /// Find ProductColor object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductColor</param>
        /// <returns></returns>
        public ProductColor FindById(object id)
        {
            return ProductColorDAO.FindById(id);
        }
        
        /// <summary>
        /// Add ProductColor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ProductColor Add(ProductColor data)
        {
            var maxId = ProductColorDAO.SelectSpecificType(null, Projections.Max("ColorId"));

            data.ColorId = maxId == null ? 1 : (Int64.Parse(maxId.ToString()) + 1);

            ProductColorDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ProductColor to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ProductColor data)
        {
            ProductColorDAO.Update(data);
        }
        
        /// <summary>
        /// Delete ProductColor from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ProductColor data)
        {
            ProductColorDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete ProductColor from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ProductColorDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ProductColor from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return ProductColorDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ProductColor from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return ProductColorDAO.FindPaging(criteria);
        }
    }
}