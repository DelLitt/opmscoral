using System.Collections;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class CategoryLogicImpl : ICategoryLogic
    {
        private ICategoryDAO _categoryDAO;

        public ICategoryDAO CategoryDAO
        {
            get 
            { 
                return _categoryDAO; 
            }
            set 
            { 
                _categoryDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Category object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Category</param>
        /// <returns></returns>
        public Category FindById(object id)
        {
            return CategoryDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Category to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Category Add(Category data)
        {
            CategoryDAO.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update Category to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Category data)
        {
            CategoryDAO.Update(data);
        }
        
        /// <summary>
        /// Delete Category from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Category data)
        {
            CategoryDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Category from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CategoryDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Category from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return CategoryDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Category from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return CategoryDAO.FindPaging(criteria);
        }
    }
}