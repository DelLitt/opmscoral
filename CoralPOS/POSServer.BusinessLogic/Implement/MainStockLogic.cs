			 


using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Utils;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class MainStockLogic : IMainStockLogic
    {
        private IMainStockDao _innerDao;
        public IMainStockDao MainStockDao
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
        /// Find MainStock object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of MainStock</param>
        /// <returns></returns>
        public MainStock FindById(object id)
        {
            return MainStockDao.FindById(id);
        }
        
        /// <summary>
        /// Add MainStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public MainStock Add(MainStock data)
        {
            MainStockDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update MainStock to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(MainStock data)
        {
            MainStockDao.Update(data);
        }
        
        /// <summary>
        /// Delete MainStock from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(MainStock data)
        {
            MainStockDao.Delete(data);
        }
        
        /// <summary>
        /// Delete MainStock from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            MainStockDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all MainStock from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<MainStock> FindAll(ObjectCriteria<MainStock> criteria)
        {
            return MainStockDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all MainStock from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<MainStock> criteria)
        {
            return MainStockDao.FindPaging(criteria);
        }

        public IList FindProductMasterAvailInStock(string name)
        {
            LinqCriteria<MainStock> crit = new LinqCriteria<MainStock>();
            crit.AddCriteria(stk =>stk.Quantity > 0);
            crit.AddCriteria(stk =>stk.ProductMaster.ProductName.Contains(name));
            crit.MaxResult = 20;
            IList<ProductMaster> list = MainStockDao.FindAllSubProperty(crit, stk => stk.ProductMaster);
            var reslist = new ArrayList();
            ObjectUtility.AddToList(reslist,list,"ProductName");
            return reslist;
        }

        public IList GetColorsFromAvailProductInStock(string productName)
        {
            LinqCriteria<MainStock> crit = new LinqCriteria<MainStock>();
            crit.AddCriteria(stk => stk.Quantity > 0);
            crit.AddCriteria(stk => stk.ProductMaster.ProductName == productName);
            IList<ExProductColor> list = MainStockDao.FindAllSubProperty(crit, stk => stk.Product.ProductColor);
            return ObjectConverter.ConvertFrom(list);
        }

        public IList GetSizesFromAvailProductInStock(string productName)
        {
            LinqCriteria<MainStock> crit = new LinqCriteria<MainStock>();
            crit.AddCriteria(stk => stk.Quantity > 0);
            crit.AddCriteria(stk => stk.ProductMaster.ProductName == productName);
            IList<ExProductSize> list = MainStockDao.FindAllSubProperty(crit, stk => stk.Product.ProductSize);
            return ObjectConverter.ConvertFrom(list);
        }

        public IList GetProductFromAvailProductInStock(string productName)
        {
            LinqCriteria<MainStock> crit = new LinqCriteria<MainStock>();
            crit.AddCriteria(stk => stk.Quantity > 0);
            crit.AddCriteria(stk => stk.ProductMaster.ProductName == productName);
            IList<Product> list = MainStockDao.FindAllSubProperty(crit, stk => stk.Product);
            return ObjectConverter.ConvertFrom(list);
        }

        public IList FindAll(LinqCriteria<MainStock> crit)
        {
            return ObjectConverter.ConvertFrom(MainStockDao.FindAll(crit));
        }
    }
}