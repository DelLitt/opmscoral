using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class PosLogLogicImpl : IPosLogLogic
    {
        private IPosLogDAO _posLogDAO;

        public IPosLogDAO PosLogDAO
        {
            get 
            { 
                return _posLogDAO; 
            }
            set 
            { 
                _posLogDAO = value; 
            }
        }
        
        /// <summary>
        /// Find PosLog object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of PosLog</param>
        /// <returns></returns>
        public PosLog FindById(object id)
        {
            return PosLogDAO.FindById(id);
        }
        
        /// <summary>
        /// Add PosLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public PosLog Add(PosLog data)
        {
            PosLogDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update PosLog to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(PosLog data)
        {
            PosLogDAO.Update(data);
        }
        
        /// <summary>
        /// Delete PosLog from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(PosLog data)
        {
            PosLogDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete PosLog from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            PosLogDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all PosLog from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return PosLogDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all PosLog from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return PosLogDAO.FindPaging(criteria);
        }
    }
}