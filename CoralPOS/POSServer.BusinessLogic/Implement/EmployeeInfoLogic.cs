			 


using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Utility;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using System.Linq;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class EmployeeInfoLogic : IEmployeeInfoLogic
    {
        private IEmployeeInfoDao _innerDao;
        public IEmployeeInfoDao EmployeeInfoDao
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
        /// Find EmployeeInfo object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of EmployeeInfo</param>
        /// <returns></returns>
        public EmployeeInfo FindById(object id)
        {
            return EmployeeInfoDao.FindById(id);
        }
        
        /// <summary>
        /// Add EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public EmployeeInfo Add(EmployeeInfo data)
        {
            EmployeeInfoDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update EmployeeInfo to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(EmployeeInfo data)
        {
            EmployeeInfoDao.Update(data);
        }
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(EmployeeInfo data)
        {
            EmployeeInfoDao.Delete(data);
        }
        
        /// <summary>
        /// Delete EmployeeInfo from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            EmployeeInfoDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all EmployeeInfo from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<EmployeeInfo> FindAll(ObjectCriteria<EmployeeInfo> criteria)
        {
            return EmployeeInfoDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all EmployeeInfo from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<EmployeeInfo> criteria)
        {
            return EmployeeInfoDao.FindPaging(criteria);
        }

        public string GenerateEmpId(string employeeName)
        {
            int index = -1;
            string empId = StringUtility.ConvertUnicodeToUnmarkVI(employeeName);
            string[] nameParts = empId.Split(' ');
            string shortName = nameParts[nameParts.Length - 1];
            
            if(nameParts.Length > 1)
            {
                for(int i=0;i<nameParts.Length-1;i++)
                {
                    shortName += nameParts[i][0];
                }
            }
            
            string lastEmpId = (string)EmployeeInfoDao.Execute((m) =>
                                        {
                                            var result = (from emp in m.Linq<EmployeeInfo>()
                                                          where emp.EmployeeId.StartsWith(shortName)
                                                          select emp.EmployeeId).Max();
                                            return result;
                                        });
            if(string.IsNullOrEmpty(lastEmpId))
            {
                shortName += "1";
            }
            else
            {
                int nextId = Int32.Parse(lastEmpId.Substring(shortName.Length));
                shortName += (nextId + 1).ToString();
            }
            return shortName;
        }

        public string GetNextBarcode()
        {
            return (string)EmployeeInfoDao.Execute((m) =>
            {
                string nextBarcode = "NV000001";
                var result = (from emp in m.Linq<EmployeeInfo>()
                              select emp.Barcode).Max();
                
                if(!string.IsNullOrEmpty(result))
                {
                    nextBarcode = "NV" + string.Format("{0:000000}", Int32.Parse(result.Substring(2)) + 1);
                }
                return nextBarcode;
            }); 
        }
    }
}