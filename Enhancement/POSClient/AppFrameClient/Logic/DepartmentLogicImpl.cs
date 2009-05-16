using System;
using System.Collections;
using AppFrame.Common;
using AppFrame.Utility;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentLogicImpl : IDepartmentLogic
    {
        private IDepartmentDAO _departmentDAO;
        private IEmployeeDetailDAO employeeDetailDAO;
        private IEmployeeDAO employeeDAO;

        public IEmployeeDetailDAO EmployeeDetailDAO
        {
            get { return employeeDetailDAO; }
            set { employeeDetailDAO = value; }
        }

        public IEmployeeDAO EmployeeDAO
        {
            get { return employeeDAO; }
            set { employeeDAO = value; }
        }

        public IDepartmentDAO DepartmentDAO
        {
            get 
            { 
                return _departmentDAO; 
            }
            set 
            { 
                _departmentDAO = value; 
            }
        }
        
        /// <summary>
        /// Find Department object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of Department</param>
        /// <returns></returns>
        public Department FindById(object id)
        {
            return DepartmentDAO.FindById(id);
        }
        
        /// <summary>
        /// Add Department to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public Department Add(Department data)
        {
            var maxId = DepartmentDAO.SelectSpecificType(null, Projections.Max("DepartmentId"));
            var departmentId = maxId == null ? 1 : (Int64.Parse(maxId.ToString()) + 1);
            data.DepartmentId = departmentId;
            if (data.Active == 1)
            {
                DepartmentDAO.SetInActiveAll();
            }

            DepartmentDAO.Add(data);
            IList employees = data.Employees;
            SaveEmployees(employees,departmentId);
            
            return data;
        }

        private void SaveEmployees(IList employees,long departmentId)
        {
            /*var maxId = EmployeeDetailDAO.SelectSpecificType(null, Projections.Max("EmployeePK.EmployeeId"));
            var employeeId = maxId == null ? 0 : (Int64.Parse(maxId.ToString()));*/
            if(employees == null)
            {
                return;
            }
            foreach (EmployeeInfo employeeInfo in employees)
            { 
                if(string.IsNullOrEmpty(employeeInfo.EmployeePK.EmployeeId))
                {
                    string employeeId = ConvertEmployeeNameToId(employeeInfo.EmployeeName);
                    //employeeInfo.EmployeePK.DepartmentId = departmentId;
                    var employeePK = new EmployeePK { DepartmentId = departmentId, EmployeeId = employeeId };
                    
                    employeeInfo.EmployeePK = employeePK;
                    //employeeInfo.EmployeeId = employeeId;
                    

                    employeeInfo.Employee.EmployeePK = employeePK;
                    /*employeeInfo.Employee.EmployeeId = employeeId;
                    employeeInfo.Employee.DepartmentId = departmentId;*/
                    employeeInfo.CreateDate = DateTime.Now;
                    employeeInfo.CreateId = ClientInfo.getInstance().LoggedUser.Name;

                    employeeInfo.Employee.CreateDate = DateTime.Now;
                    employeeInfo.Employee.CreateId = ClientInfo.getInstance().LoggedUser.Name;

                    EmployeeDAO.Add(employeeInfo.Employee);
                    EmployeeDetailDAO.Add(employeeInfo);
                }
                else
                {
                    
                    employeeInfo.UpdateDate = DateTime.Now;
                    employeeInfo.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

                    employeeInfo.Employee.UpdateDate = DateTime.Now;
                    employeeInfo.Employee.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    
                    EmployeeDetailDAO.Update(employeeInfo);
                    EmployeeDAO.Update(employeeInfo.Employee);
                    
                }
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameInput"></param>
        /// <returns></returns>
        private string ConvertEmployeeNameToId(string nameInput)
        {
            string name = StringUtility.ConvertUnicodeToUnmarkVI(nameInput);
            string[] nameparts = name.Split(' ');
            string retName = nameparts[nameparts.Length - 1];
            for (int i = 0;i<nameparts.Length-1; i++)
            {
                retName += nameparts[i][0];                
            }
            string maxName = EmployeeDetailDAO.GetMaxId(retName);
            string originalName = retName;
            if(string.IsNullOrEmpty(maxName))
            {
                maxName = retName;
            }
            int maxNum = GetNumberFromString(maxName,out originalName);
            if(maxNum == 0)
            {
                retName = originalName + "1"; 
            }
            else
            {
                retName = originalName + (maxNum + 1).ToString();
            }
            return retName;
        }

        private int GetNumberFromString(string name,out string originalName)
        {
            if(string.IsNullOrEmpty(name))
            {
                
                originalName = name;
                return 0;
            }
            int max = name.Length - 1;
            string builder = "";
            originalName = name;
            while(max > 0 )
            {
                char charTest = name[max];
                if(charTest >= '0' && charTest <= '9')
                {
                    builder += charTest;                    
                }
                else
                {
                    originalName = name.Substring(0, name.LastIndexOf(charTest) + 1);
                    break;
                }
                max -= 1;
            }
            
            return string.IsNullOrEmpty(builder) ? 0 : int.Parse(builder);
        }

        /// <summary>
        /// Update Department to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(Department data)
        {
            if (data.Active == 1)
            {
                DepartmentDAO.SetInActiveAll();
            }

            DepartmentDAO.Update(data);
            if (data.DelFlg != 1)
            {
                SaveEmployees(data.Employees, data.DepartmentId);
            }
        }
        
        /// <summary>
        /// Delete Department from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(Department data)
        {
            DepartmentDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete Department from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all Department from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all Department from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentDAO.FindPaging(criteria);
        }

        #region IDepartmentLogic Members


        public Department LoadDepartment(Department department)
        {
            return DepartmentDAO.LoadDepartment(department);
        }

        #endregion
    }
}