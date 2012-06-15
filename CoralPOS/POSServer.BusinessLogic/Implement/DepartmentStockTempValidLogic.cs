			 


using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Linq;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
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
        public IProductDao ProductDao { get; set; }
        public IDepartmentInventoryCheckingDao DepartmentInventoryCheckingDao { get; set; }
        
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
                    var query = session.Query<MainStock>();
                    /*query.Expand("Product");
                    query.Expand("ProductMaster");*/
                    var stockList = from stock in query.Fetch(x=>x.Product).ThenFetch(x=>x.ProductMaster)
                                    where stock.Quantity > 0 
                                    select stock;
                    
                    var result = from stock in (stockList.ToList())
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
                                     GoodQuantity = 0,
                                     LostQuantity = 0,
                                     ExFld1 = 0,
                                     ExFld2 = 0,
                                     ExFld3 = 0,
                                     ExFld4 = "",
                                     ExFld5 = "",
                                     Fixed = 0,
                                     OnStorePrice = 0,
                                     UnconfirmQuantity = 0

                                 };
                    return result.ToList();
                }
                );
            }
            else // department stock
            {
                return (IList<DepartmentStockTempValid>)DepartmentStockTempValidDao.Execute(delegate(ISession session)
                {
                    var query = session.Query<DepartmentStock>();
                    /*query.Expand("Product");
                    query.Expand("ProductMaster");*/
                    var stockList = from stock in query.Fetch(x=>x.Product).ThenFetch(x=>x.ProductMaster)
                                    where stock.Quantity > 0
                                    select stock;

                    var result = from stock in (stockList.ToList())
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

        public DepartmentStockTempValid CreateFromProductId(string productId,long departmentId )
        {
            return (DepartmentStockTempValid)DepartmentStockTempValidDao.Execute(delegate(ISession session)
            {
                DepartmentStockTempValid tempValid = null;
                var query = session.Query<Product>();
                /*query.Expand("ProductMaster");*/
                Product foundedProduct =(from product in query.Fetch(x=>x.ProductMaster)
                                where product.ProductId == productId
                                select product).FirstOrDefault();
                if(foundedProduct!=null) // if found in db
                {
                    tempValid = new DepartmentStockTempValid
                                    {
                                        DepartmentStockTempValidPK = new DepartmentStockTempValidPK
                                        {
                                            CreateDate = DateTime.Now,
                                            DepartmentId = departmentId,
                                            ProductId = foundedProduct.ProductId
                                        },
                                        CreateId = "admin",
                                        UpdateId = "admin",
                                        UpdateDate = DateTime.Now,
                                        ProductMaster = foundedProduct.ProductMaster,
                                        Product = foundedProduct,
                                        DamageQuantity = 0,
                                        DelFlg = 0,
                                        ErrorQuantity = 0,
                                        ExclusiveKey = 0,
                                        Quantity = 0,
                                        GoodQuantity = 0
                                    };
                }
                else
                {
                    // TODO: SHOULD CREATE A TEMP PRODUCT HERE
                }

                
                return tempValid;
            }
                 ); 
        }

        public void AddBatch(IList<DepartmentStockTempValid> stockInventoryList)
        {
            bool addInventoryChecking = false;
            foreach (DepartmentStockTempValid departmentStockTempValid in stockInventoryList)
            {
                if (!addInventoryChecking)
                {
                    DepartmentInventoryCheckingDao.Add(departmentStockTempValid.DepartmentInventoryChecking);
                    addInventoryChecking = true;
                }
                DepartmentStockTempValidDao.Add(departmentStockTempValid);
            }
        }

        public IList<DepartmentStockTempValid> FindByDate(DateTime fromDate, DateTime toDate)
        {
            return (IList<DepartmentStockTempValid>)DepartmentStockTempValidDao.Execute((session) =>
                                                    {
                                                        var rs = session.Query<DepartmentStockTempValid>();
                                                        /*rs.Expand("ProductMaster");
                                                        rs.Expand("Product");*/
                                                        var list =
                                                            from tempValid in rs.Fetch(x=>x.Product).ThenFetch(x=>x.ProductMaster)
                                                            where
                                                                tempValid.DepartmentStockTempValidPK.CreateDate <=
                                                                toDate
                                                                &&
                                                                tempValid.DepartmentStockTempValidPK.CreateDate >=
                                                                fromDate
                                                                && tempValid.Fixed == 0
                                                            select tempValid;
                                                        return list.ToList();
                                                    });
        }

        public IList<DepartmentInventoryChecking> FindInventoryChecking(DateTime fromDate, DateTime toDate)
        {
            ObjectCriteria<DepartmentInventoryChecking> criteria = new ObjectCriteria<DepartmentInventoryChecking>();
            criteria.Add(a => a.CreateDate >= fromDate);
            criteria.Add(a => a.CreateDate <= toDate);
            return DepartmentInventoryCheckingDao.FindAll(criteria);
        }

        public IList<DepartmentStockTempValid> LoadDepartmentStockTempValid(DepartmentInventoryChecking checking)
        {
            return (IList<DepartmentStockTempValid>) DepartmentStockTempValidDao.Execute((session) =>
                                                                                             {
                                                                                                 var rs = session.Query<DepartmentStockTempValid>();
                                                                                                 var list = from valid in rs.Fetch(x=>x.Product).ThenFetch(x=>x.ProductMaster)
                                                                                                            where valid.DepartmentInventoryChecking.DepartmentInventoryId == checking.DepartmentInventoryId && valid.Fixed ==0
                                                                                                            select valid    ;
                                                                                                 return list.ToList();
                                                                                             });
        }
    }
}