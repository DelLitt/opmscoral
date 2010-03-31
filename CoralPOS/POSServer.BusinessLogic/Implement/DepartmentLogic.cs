			 


using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Base;
using POSServer.BusinessLogic.Common;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class DepartmentLogic : IDepartmentLogic
    {
        private IDepartmentDao _innerDao;
        public IDepartmentDao DepartmentDao
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
        /// Find Department object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Department</param>
        /// <returns></returns>
        public Department FindById(object id)
        {
            return DepartmentDao.FindById(id);
        }

        /// <summary>
        /// Add Department to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public Department Add(Department data)
        {
            DepartmentDao.Add(data);
            return data;
        }

        /// <summary>
        /// Update Department to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Update(Department data)
        {
            DepartmentDao.Update(data);
        }

        /// <summary>
        /// Delete Department from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Delete(Department data)
        {
            DepartmentDao.Delete(data);
        }

        /// <summary>
        /// Delete Department from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void DeleteById(object id)
        {
            DepartmentDao.DeleteById(id);
        }

        /// <summary>
        /// Find all Department from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<Department> FindAll(ObjectCriteria<Department> criteria)
        {
            return DepartmentDao.FindAll(criteria);
        }

        /// <summary>
        /// Find all Department from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<Department> criteria)
        {
            return DepartmentDao.FindPaging(criteria);
        }

        public void LoadDefinition(IFlowSession flowSession)
        {
            IList<Department> departments = DepartmentDao.FindAll(new ObjectCriteria<Department>());
            flowSession.Put(FlowConstants.DEPARTMENTS, departments);
        }

        public void Update(IList departments)
        {
            var maxIdResult = DepartmentDao.SelectSpecificType(null, Projections.Max("DepartmentId"));
            long maxDeptId = maxIdResult != null ? Int64.Parse(maxIdResult.ToString()) + 1 : 1;
            foreach (Department department in departments)
            {
                if (department.DepartmentId > 0)
                {
                    Department current = DepartmentDao.FindById(department.DepartmentId);
                    current.DepartmentName = department.DepartmentName;
                    current.UpdateDate = DateTime.Now;
                    DepartmentDao.Update(current);
                }
                else
                {
                    department.DepartmentId = maxDeptId++;
                    department.CreateDate = DateTime.Now;
                    department.UpdateDate = DateTime.Now;
                    DepartmentDao.Add(department);
                }
            }
        }
    }
}