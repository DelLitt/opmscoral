﻿using System;
using System.Collections;
using AppFrame.Model;
using NHibernate.Criterion;

namespace AppFrame.DataLayer
{
    public interface IDepartmentStockHistoryDAO
    {
        /// <summary>
        /// Find DepartmentStockDefect object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockDefect</param>
        /// <returns></returns>
        DepartmentStockHistory FindById(object id);

        /// <summary>
        /// Add DepartmentStockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DepartmentStockHistory Add(DepartmentStockHistory data);

        /// <summary>
        /// Update DepartmentStockDefect to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Update(DepartmentStockHistory data);

        /// <summary>
        /// Delete DepartmentStockDefect from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        void Delete(DepartmentStockHistory data);

        /// <summary>
        /// Delete DepartmentStockDefect from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);

        /// <summary>
        /// Find all DepartmentStockDefect from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList FindAll(ObjectCriteria criteria);

        /// <summary>
        /// Find all DepartmentStockDefect from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        QueryResult FindPaging(ObjectCriteria criteria);

        /// <summary>
        /// Find min, max, count... DepartmentStockDefect from database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object SelectSpecificType(ObjectCriteria criteria, IProjection type);

        IList FindAllProductMasters();
        IList FindByProductMasterName(ProductMaster master);
    }
}