			 


using System;
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
using NHibernate.Linq;
using System.Linq;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class DepartmentStockTempValidLogic : IDepartmentStockTempValidLogic
    {
        private IDepartmentStockTempValidDao _innerValidDao;
        public IDepartmentStockTempValidDao DepartmentStockTempValidDao
        {
            get 
            { 
                return _innerValidDao; 
            }
            set 
            { 
                _innerValidDao = value; 
            }
        }


        public IDepartmentStockDao DepartmentStockDao { get; set; }
        public IMainStockDao MainStockDao { get; set; }
        /// <summary>
        /// Find DepartmentStockTemployeeValid object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockTemployeeValid</param>
        /// <returns></returns>
        public DepartmentStockTempValid FindById(object id)
        {
            return DepartmentStockTempValidDao.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockTemployeeValid to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockTempValid Add(DepartmentStockTempValid data)
        {
            DepartmentStockTempValidDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update DepartmentStockTemployeeValid to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockTempValid data)
        {
            DepartmentStockTempValidDao.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemployeeValid from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockTempValid data)
        {
            DepartmentStockTempValidDao.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockTemployeeValid from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockTempValidDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemployeeValid from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<DepartmentStockTempValid> FindAll(ObjectCriteria<DepartmentStockTempValid> criteria)
        {
            return DepartmentStockTempValidDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockTemployeeValid from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<DepartmentStockTempValid> criteria)
        {
            return DepartmentStockTempValidDao.FindPaging(criteria);
        }

        public IList<DepartmentStockTempValid> FindStockTempValidForDepartment(Department selectedDepartment)
        {
            if(selectedDepartment.DepartmentId == 0) // main stock
            {
                return (IList<DepartmentStockTempValid>)DepartmentStockTempValidDao.Execute(delegate(ISession session)
                {
                    var result = from stock in session.Linq<MainStock>()
                                  select new DepartmentStockTempValid
                                 {
                                     DepartmentStockTempValidPK = new DepartmentStockTempValidPK
                                     {
                                         CreateDate = DateTime.Now,
                                         DepartmentId = selectedDepartment.DepartmentId,
                                         ProductId = stock.Product.ProductId
                                     },
                                     CreateId = "admin",
                                     UpdateId = "admin",
                                     ProductMaster = stock.ProductMaster,
                                     Product = stock.Product,
                                     UpdateDate = DateTime.Now,
                                     DamageQuantity = 0,
                                     DelFlg = 0,
                                     ErrorQuantity = 0,
                                     ExclusiveKey = 0,
                                     Quantity = stock.Quantity,
                                     GoodQuantity = 0
                                 };
                    return result.ToList();
                }
                );
            }
            else // department stock
            {
                return (IList<DepartmentStockTempValid>)DepartmentStockTempValidDao.Execute(delegate(ISession session)
                {
                    var result = from stock in session.Linq<DepartmentStock>()
                                 select new DepartmentStockTempValid
                                            {
                                                DepartmentStockTempValidPK = new DepartmentStockTempValidPK
                                                                                 {
                                                                                     CreateDate = DateTime.Now,
                                                                                     DepartmentId =selectedDepartment.DepartmentId,
                                                                                     ProductId = stock.Product.ProductId
                                                                                 },
                                               CreateId = "admin",
                                               UpdateId = "admin",
                                               UpdateDate = DateTime.Now,
                                               ProductMaster = stock.ProductMaster,
                                               Product = stock.Product,
                                               DamageQuantity = 0,
                                               DelFlg = 0,
                                               ErrorQuantity = 0,
                                               ExclusiveKey = 0,
                                               Quantity = stock.Quantity,
                                               GoodQuantity = 0
                                            };
                    return result.ToList();
                }
                );
            }
        }
    }
}