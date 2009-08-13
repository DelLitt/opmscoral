using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface IProductMasterLogic
    {
        /// <summary>
        /// Find ProductMaster object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductMaster</param>
        /// <returns></returns>
        ProductMaster FindById(object id);
        
        /// <summary>
        /// Add ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ProductMaster Add(ProductMaster data);

        /// <summary>
        /// Add ProductMaster to database.
        /// </summary>
        /// <param name="productMasters"></param>
        /// <returns></returns>
        void AddAll(List<ProductMaster> productMasters);
        
        /// <summary>
        /// Update ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(ProductMaster data);
        
        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(ProductMaster data);
        
        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);
        
        /// <summary>
        /// Find all ProductMaster from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);
        
        /// <summary>
        /// Find all ProductMaster from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        IList FindProductMasterById(object id, int limit,bool allDepartment);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        IList FindProductMasterByName(object name, int limit,bool allDepartments);

        IList FindProductColorsByName(string name);
        IList FindProductSizesByName(string name);
        IList FindProductMasterByNameAllDepartment(string name, int i);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="master"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        IList FindAllInDepartment(ProductMaster master, bool department);

        IList FindDistinctNames();
    }
}