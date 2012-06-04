			 


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
    public class MainPriceLogic : IMainPriceLogic
    {
        private IMainPriceDao _innerDao;
        public IMainPriceDao MainPriceDao
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
        /// Find MainPrice object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of MainPrice</param>
        /// <returns></returns>
        public MainPrice FindById(object id)
        {
            return MainPriceDao.FindById(id);
        }
        
        /// <summary>
        /// Add MainPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public MainPrice Add(MainPrice data)
        {
            MainPriceDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update MainPrice to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(MainPrice data)
        {
            MainPriceDao.Update(data);
        }
        
        /// <summary>
        /// Delete MainPrice from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(MainPrice data)
        {
            MainPriceDao.Delete(data);
        }
        
        /// <summary>
        /// Delete MainPrice from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            MainPriceDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all MainPrice from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<MainPrice> FindAll(ObjectCriteria<MainPrice> criteria)
        {
            return MainPriceDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all MainPrice from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<MainPrice> criteria)
        {
            return MainPriceDao.FindPaging(criteria);
        }

        public void PreloadDefinition(IFlowSession session)
        {
            IList<MainPrice> mainPrices = MainPriceDao.FindAll(new ObjectCriteria<MainPrice>());
            session.Put(FlowConstants.MAINPRICE_LIST, mainPrices);
        }

        public MainPrice Save(MainPrice mainPrice)
        {
            ObjectCriteria<MainPrice> findPrice = new ObjectCriteria<MainPrice>();
            string productMasterId = mainPrice.MainPricePK.ProductMasterId;
            findPrice.Add(
                price => price.MainPricePK.ProductMasterId == productMasterId);
            MainPrice currentPrice = MainPriceDao.FindFirst(findPrice) as MainPrice;
            if (currentPrice == null)
            {
                MainPriceDao.Add(mainPrice);
                return mainPrice;
            }
            else
            {
                currentPrice.Price = mainPrice.Price;
                currentPrice.WholeSalePrice = mainPrice.WholeSalePrice;
                MainPriceDao.Update(currentPrice);
                return currentPrice;
            }
        }
    }
}