			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class MainftrLogic : IMainftrLogic
    {
        private IMainftrDao _innerDao;
        public IMainftrDao MainftrDao
        {
            get 
            { 
                return _innerDao; 
            }
            set 
            { 
                _innerDao = value; 
            }
        }
        
        /// <summary>
        /// Find Mainftr object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Mainftr</param>
        /// <returns></returns>
        public Mainftr FindById(object id)
        {
            return MainftrDao.FindById(id);
        }
        
        /// <summary>
        /// Add Mainftr to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Mainftr Add(Mainftr data)
        {
            MainftrDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Mainftr to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Mainftr data)
        {
            MainftrDao.Update(data);
        }
        
        /// <summary>
        /// Delete Mainftr from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Mainftr data)
        {
            MainftrDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Mainftr from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            MainftrDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Mainftr from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Mainftr> FindAll(ObjectCriteria criteria)
        {
            return MainftrDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Mainftr from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return MainftrDao.FindPaging(criteria);
        }
    }
}