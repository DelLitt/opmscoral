using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentTimelineLogicImpl : IDepartmentTimelineLogic
    {
        private IDepartmentTimelineDAO _departmentCostDAO;

        public IDepartmentTimelineDAO DepartmentTimelineDAO
        {
            get 
            { 
                return _departmentCostDAO; 
            }
            set 
            { 
                _departmentCostDAO = value; 
            }
        }
        
        /// <summary>
        /// Find DepartmentTimeline object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentTimeline</param>
        /// <returns></returns>
        public DepartmentTimeline FindById(object id)
        {
            return DepartmentTimelineDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentTimeline to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentTimeline Add(DepartmentTimeline data)
        {
            DepartmentTimelineDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentTimeline to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentTimeline data)
        {
            DepartmentTimelineDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentTimeline from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentTimeline data)
        {
            DepartmentTimelineDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentTimeline from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentTimelineDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentTimeline from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentTimelineDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentTimeline from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentTimelineDAO.FindPaging(criteria);
        }
    }
}