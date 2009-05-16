using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class TaxLogicImpl : ITaxLogic
    {
        private ITaxDAO _taxDAO;

        public ITaxDAO TaxDAO
        {
            get 
            { 
                return _taxDAO; 
            }
            set 
            { 
                _taxDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Tax object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Tax</param>
        /// <returns></returns>
        public Tax FindById(object id)
        {
            return TaxDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Tax to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Tax Add(Tax data)
        {
            TaxDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Tax to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Tax data)
        {
            TaxDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Tax from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Tax data)
        {
            TaxDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Tax from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            TaxDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Tax from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return TaxDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Tax from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return TaxDAO.FindPaging(criteria);
        }
    }
}