using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class SupplierLogicImpl : ISupplierLogic
    {
        private ISupplierDAO _supplierDAO;

        public ISupplierDAO SupplierDAO
        {
            get 
            { 
                return _supplierDAO; 
            }
            set 
            { 
                _supplierDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Supplier object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Supplier</param>
        /// <returns></returns>
        public Supplier FindById(object id)
        {
            return SupplierDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Supplier to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Supplier Add(Supplier data)
        {
            SupplierDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Supplier to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Supplier data)
        {
            SupplierDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Supplier from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Supplier data)
        {
            SupplierDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Supplier from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            SupplierDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Supplier from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return SupplierDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Supplier from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return SupplierDAO.FindPaging(criteria);
        }
    }
}