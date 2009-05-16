using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Utility;
using NHibernate;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrame.Common
{
    public static class CurrentDepartment
    {
        
        private static readonly Department _hqDepartment = new Department{DepartmentId = 0, DepartmentName = "HQ"};

        public static Department Get()
        {
            Department _currentDepartment=null;
            /*if (_currentDepartment == null)
            {*/
                IApplicationContext ctx = ContextRegistry.GetContext();
                var departmentLogic = ctx.GetObject("AppFrame.Service.IDepartmentLogic") as IDepartmentLogic;
                var criteria = new ObjectCriteria();
                criteria.AddEqCriteria("Active", 1);
                criteria.AddEqCriteria("DelFlg", (long)0);
                if (departmentLogic != null)
                {
                    IList deptList = departmentLogic.FindAll(criteria);
                    if (deptList!= null && deptList.Count > 0)
                    {
                        _currentDepartment = deptList[0] as Department;
                    }
                }
                if (_currentDepartment == null)
                {
                    return _hqDepartment;
                }
                // detach object to session
                
                return _currentDepartment;
            /*}
            else
            {
                return _currentDepartment;
            }*/
        }

        public static Department Get(long deptId)
        {
            Department _currentDepartment = null;
            /*if (_currentDepartment == null)
            {*/
            IApplicationContext ctx = ContextRegistry.GetContext();
            var departmentLogic = ctx.GetObject("AppFrame.Service.IDepartmentLogic") as IDepartmentLogic;
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("Active", 1);
            criteria.AddEqCriteria("DelFlg", (long)0);
            criteria.AddEqCriteria("DepartmentId", deptId);
            if (departmentLogic != null)
            {
                IList deptList = departmentLogic.FindAll(criteria);
                if (deptList != null && deptList.Count > 0)
                {
                    _currentDepartment = deptList[0] as Department;
                }
            }
            if (_currentDepartment == null)
            {
                return null;
            }
            // detach object to session

            return _currentDepartment;
            /*}
            else
            {
                return _currentDepartment;
            }*/
        }

        /// <summary>
        /// Get Current Active Department , return false if HQ department and return true in case any department active
        /// </summary>
        /// <param name="department">Active department need to get</param>
        /// <returns></returns>
        public static bool CurrentActiveDepartment(out Department department)
        {
            department = Get();
            return department.DepartmentId > 0 ? true : false;
        }
    }
}
