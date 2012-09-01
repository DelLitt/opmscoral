			 


using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSClient.DataLayer.Implement;

namespace POSClient.BusinessLogic.Implement
{
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryDao _innerDao;
        public ICategoryDao CategoryDao
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
        /// Find Category object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Category</param>
        /// <returns></returns>
        public Category FindById(object id)
        {
            return CategoryDao.FindById(id);
        }
        
        /// <summary>
        /// Add Category to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Category Add(Category data)
        {
            CategoryDao.Add(data);
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
            CategoryDao.Update(data);
        }
        
        /// <summary>
        /// Delete Category from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Category data)
        {
            CategoryDao.Delete(data);
        }
        
        /// <summary>
        /// Delete Category from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            CategoryDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Category from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Category> FindAll(ObjectCriteria<Category> criteria)
        {
            return CategoryDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Category from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<Category> criteria)
        {
            return CategoryDao.FindPaging(criteria);
        }
    }
}