using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class SimilarProductLogicImpl : ISimilarProductLogic
    {
        private ISimilarProductDAO _similarProductDAO;

        public ISimilarProductDAO SimilarProductDAO
        {
            get 
            { 
                return _similarProductDAO; 
            }
            set 
            { 
                _similarProductDAO = value; 
            }
        }
        
        /// <summary>
        /// Find SimilarProduct object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of SimilarProduct</param>
        /// <returns></returns>
        public SimilarProduct FindById(object id)
        {
            return SimilarProductDAO.FindById(id);
        }
        
        /// <summary>
        /// Add SimilarProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public SimilarProduct Add(SimilarProduct data)
        {
            SimilarProductDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update SimilarProduct to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(SimilarProduct data)
        {
            SimilarProductDAO.Update(data);
        }
        
        /// <summary>
        /// Delete SimilarProduct from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(SimilarProduct data)
        {
            SimilarProductDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete SimilarProduct from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            SimilarProductDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all SimilarProduct from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return SimilarProductDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all SimilarProduct from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return SimilarProductDAO.FindPaging(criteria);
        }
    }
}