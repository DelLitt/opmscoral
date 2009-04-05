using System;
using System.Collections;
using AppFrame.Common;
using AppFrame.Utility;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class EmployeeDetailLogicImpl : IEmployeeDetailLogic
    {
        private IEmployeeDetailDAO _employeeDetailDAO;

        public IEmployeeDAO EmployeeDAO { get; set; }

        public IEmployeeDetailDAO EmployeeDetailDAO
        {
            get 
            { 
                return _employeeDetailDAO; 
            }
            set 
            { 
                _employeeDetailDAO = value; 
            }
        }
        
        /// <summary>
        /// Find EmployeeInfo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeInfo</param>
        /// <returns></returns>
        public EmployeeInfo FindById(object id)
        {
            return EmployeeDetailDAO.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeInfo to database.
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeInfo Add(EmployeeInfo employeeInfo)
        {
            ObjectCriteria crit = new ObjectCriteria();
            crit.AddOrder("Barcode", false);
            crit.MaxResult = 3;
            IList list = EmployeeDetailDAO.FindAll(crit);
            string barCode = "NV000001";
            if(list!=null && list.Count > 0 )
            {
                EmployeeInfo info = (EmployeeInfo) list[0];
                barCode = "NV" + string.Format("{0:000000}",Int32.Parse(info.Barcode.Substring(2))+1);                
            }

            if (employeeInfo.Employee==null) // create new
            {
                string employeeId = ConvertEmployeeNameToId(employeeInfo.EmployeeName);
                //employeeInfo.EmployeePK.DepartmentId = departmentId;
                var employeePK = new EmployeePK { DepartmentId = 0, EmployeeId = employeeId };

                employeeInfo.EmployeePK = employeePK;
                //employeeInfo.EmployeeId = employeeId;

                if(employeeInfo.Employee == null)
                {
                    employeeInfo.Employee = new Employee();
                }
                employeeInfo.Employee.EmployeePK = employeePK;
                employeeInfo.Employee.CreateDate = DateTime.Now;
                employeeInfo.Employee.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                employeeInfo.DelFlg = 0;
                employeeInfo.ExclusiveKey = 1;
                employeeInfo.Employee.DelFlg = 0;
                employeeInfo.Employee.ExclusiveKey = 1;
                employeeInfo.Employee.Department = new Department {DepartmentId = 0};
                employeeInfo.Department = new Department{DepartmentId = 0};
                /*employeeInfo.Employee.EmployeeId = employeeId;
                employeeInfo.Employee.DepartmentId = departmentId;*/
                employeeInfo.CreateDate = DateTime.Now;
                employeeInfo.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                employeeInfo.Barcode = barCode;
                employeeInfo.Employee.CreateDate = DateTime.Now;
                employeeInfo.Employee.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                EmployeeDAO.Add(employeeInfo.Employee);
                EmployeeDetailDAO.Add(employeeInfo);
                
            }
            else // update
            {

                employeeInfo.UpdateDate = DateTime.Now;
                employeeInfo.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

                employeeInfo.Employee.UpdateDate = DateTime.Now;
                employeeInfo.Employee.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

                EmployeeDetailDAO.Update(employeeInfo);
                //EmployeeDAO.Update(employeeInfo.Employee);

            }

            //EmployeeDetailDAO.Add(data);
            return employeeInfo;
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
            for (int i = 0; i < nameparts.Length - 1; i++)
            {
                retName += nameparts[i][0];
            }
            string maxName = EmployeeDetailDAO.GetMaxId(retName);
            string originalName = retName;
            if (string.IsNullOrEmpty(maxName))
            {
                maxName = retName;
            }
            int maxNum = GetNumberFromString(maxName, out originalName);
            if (maxNum == 0)
            {
                retName = originalName + "1";
            }
            else
            {
                retName = originalName + (maxNum + 1).ToString();
            }
            return retName;
        }

        private int GetNumberFromString(string name, out string originalName)
        {
            if (string.IsNullOrEmpty(name))
            {

                originalName = name;
                return 0;
            }
            int max = name.Length - 1;
            string builder = "";
            originalName = name;
            while (max > 0)
            {
                char charTest = name[max];
                if (charTest >= '0' && charTest <= '9')
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
        /// Update EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(EmployeeInfo data)
        {
            EmployeeDetailDAO.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeInfo data)
        {
            EmployeeDetailDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeDetailDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return EmployeeDetailDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return EmployeeDetailDAO.FindPaging(criteria);
        }
    }
}