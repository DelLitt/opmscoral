			 


using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Base;
using NHibernate.Criterion;
using POSServer.BusinessLogic.Common;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
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
        public IList<Category> FindAll(ObjectCriteria criteria)
        {
            return CategoryDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Category from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return CategoryDao.FindPaging(criteria);
        }

        public void LoadDefinition(IFlowSession session)
        {
            IList<Category> categories = CategoryDao.FindAll(null);
            session.Put(FlowConstants.CATEGORY_LIST, categories);
        }

        public void Update(IList categoryList)
        {
            var maxIdResult = CategoryDao.SelectSpecificType(null, Projections.Max("CategoryId"));
            long maxColorId = maxIdResult != null ? Int64.Parse(maxIdResult.ToString()) + 1 : 1;
            foreach (Category category in categoryList)
            {
                if (category.CategoryId > 0)
                {
                    Category current = CategoryDao.FindById(category.CategoryId);
                    current.CategoryName = category.CategoryName;
                    current.UpdateDate = DateTime.Now;
                    CategoryDao.Update(current);
                }
                else
                {
                    category.CategoryId = maxColorId++;
                    category.CreateDate = DateTime.Now;
                    category.UpdateDate = DateTime.Now;
                    CategoryDao.Add(category);
                }
            } 
        }
    }
}