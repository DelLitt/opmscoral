			 


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AppFrame.Utility;
using AppFrame.Utils;
using Spring.Transaction.Interceptor;
using System.Linq.Expressions;
using AppFrame.DataLayer;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Linq;
using NHibernate.Linq.Expressions;
using Spring.Data.NHibernate;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;

namespace POSServer.BusinessLogic.Implement
{
    public class StockInLogic : IStockInLogic
    {
        private IStockInDao _innerDao;
        public IStockInDao StockInDao
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
        
        public IProductMasterDao ProductMasterDao { get; set; }
        public IProductDao ProductDao { get; set; }
        public IStockInDetailDao StockInDetailDao { get; set; }
        public IMainStockDao MainStockDao { get; set; }
        public IMainPriceDao MainPriceDao { get; set; }
        /// <summary>
        /// Find StockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockIn</param>
        /// <returns></returns>
        public StockIn FindById(object id)
        {
            return StockInDao.FindById(id);
        }
        
        /// <summary>
        /// Add StockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction()]
        public StockIn Add(StockIn data)
        {
            IDictionary<string,MainPrice> prices = new Dictionary<string, MainPrice>();
            var maxIdResult = StockInDao.SelectSpecificType(null, Projections.Max("StockInId"));
            long nextStockInId = maxIdResult != null ? Int64.Parse(maxIdResult.ToString()) + 1 : 1;
            // add or update stock
            var maxStockIdResult = MainStockDao.SelectSpecificType(null, Projections.Max("StockId"));
            long nextStockId = maxStockIdResult != null ? Int64.Parse(maxStockIdResult.ToString()) + 1 : 1;


            
            data.StockInId = nextStockInId;
            StockInDao.Add(data);
            foreach (StockInDetail inDetail in data.StockInDetails)
            {
                inDetail.StockInDetailPK.StockInId = nextStockInId;
                Product current = ProductDao.FindById(inDetail.Product.ProductId);
                if (current != null)
                {
                    inDetail.Product = current;
                }
                else
                {
                    ProductDao.Add(inDetail.Product);
                }
                StockInDetailDao.Add(inDetail);

                ObjectCriteria<MainStock> findStock = new ObjectCriteria<MainStock>();
                string productId = inDetail.Product.ProductId;
                findStock.Add(stk => stk.Product.ProductId==productId);

                MainStock currentStock = MainStockDao.FindFirst(findStock) as MainStock;
                if(currentStock == null) // create new stock
                {
                   MainStock newStock = new MainStock
                                            {
                                                StockId = nextStockId++,
                                                CreateDate = DateTime.Now,
                                                UpdateDate = DateTime.Now,
                                                CreateId = "admin",
                                                UpdateId = "admin",
                                                DelFlg = 0,
                                                ExclusiveKey = 1,
                                                Product = inDetail.Product,
                                                ProductMaster = inDetail.ProductMaster,
                                                Quantity = inDetail.Quantity,
                                                GoodQuantity = inDetail.Quantity
                                            };
                    MainStockDao.Add(newStock);
                }
                else // update current stock
                {
                    currentStock.Quantity += inDetail.Quantity;
                    currentStock.GoodQuantity += inDetail.Quantity;
                    currentStock.ExclusiveKey += 1;
                    MainStockDao.Update(currentStock);
                }

                // add price for update later
                prices[inDetail.MainPrice.MainPricePK.ProductMasterId] = inDetail.MainPrice;
            }
            
            // update price if have
            foreach (KeyValuePair<string, MainPrice> mainPrice in prices)
            {
                ObjectCriteria<MainPrice> findPrice = new ObjectCriteria<MainPrice>();
                string productMasterId = mainPrice.Key;
                findPrice.Add(
                    price => price.MainPricePK.ProductMasterId == productMasterId);
                MainPrice currentPrice = MainPriceDao.FindFirst(findPrice) as MainPrice;
                if (currentPrice == null)
                {
                    MainPriceDao.Add(mainPrice.Value);
                }
                else
                {
                    currentPrice.Price = mainPrice.Value.Price;
                    currentPrice.WholeSalePrice = mainPrice.Value.WholeSalePrice;
                    MainPriceDao.Update(currentPrice);
                }
            }
            

            return data;
        }
        
        /// <summary>
        /// Update StockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(StockIn data)
        {
            StockInDao.Update(data);
        }
        
        /// <summary>
        /// Delete StockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockIn data)
        {
            StockInDao.Delete(data);
        }
        
        /// <summary>
        /// Delete StockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockInDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<StockIn> FindAll(ObjectCriteria<StockIn> criteria)
        {
            return StockInDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<StockIn> criteria)
        {
            return StockInDao.FindPaging(criteria);
        }

        public IList<StockIn> Find(object criteria)
        {
            return (IList<StockIn>) StockInDao.Execute(delegate(ISession session)
                                   {
                                       var sql = from c in session.Linq<StockIn>()
                                                 join o in session.Linq<StockInDetail>() on c.StockInId equals o.StockInDetailPK.StockInId
                                                 select c;
                                       return null;
                                   }
                                   );
        }

        public IList<StockIn> FindByMultiCriteria(StockInCriteria criteria)
        {
            bool hasDetailQuery = false;
            StockInDetail detail = null;
            DetachedCriteria critMaster = DetachedCriteria.For<StockIn>();
            DetachedCriteria critDetail = DetachedCriteria.For<StockInDetail>();

            if (criteria != null)
            {

                if (!ObjectUtility.IsNullOrEmpty(criteria.ProductMasterNames))
                {
                    hasDetailQuery = true;
                    foreach (string masterName in criteria.ProductMasterNames)
                    {
                        critDetail.Add(SqlExpression.Like<StockInDetail>(sod => sod.ProductMaster.ProductName, masterName));
                    }
                }

                if (!ObjectUtility.IsNullOrEmpty(criteria.CategoryName))
                {
                    hasDetailQuery = true;
                    critDetail.Add<StockInDetail>(
                        sod => sod.ProductMaster.Category.CategoryName == criteria.CategoryName);
                }

                if (!ObjectUtility.IsNullOrEmpty(criteria.TypeNames))
                {
                    hasDetailQuery = true;
                    foreach (string typeName in criteria.TypeNames)
                    {
                        critDetail.Add(SqlExpression.Like<StockInDetail>(sod => sod.ProductMaster.ProductType.TypeName, typeName));
                    }
                }
                if (criteria.DatePick)
                {

                    critMaster.Add(SqlExpression.Between<StockIn>(so => so.StockInDate,
                                                                   DateUtility.ZeroTime(criteria.FromDate),
                                                                   DateUtility.MaxTime(criteria.ToDate)));
                }
            }
            
            return (IList<StockIn>)StockInDao.Execute(delegate(ISession session)
            {
                ICriteria executeCrit = critMaster.GetExecutableCriteria(session);
                if (hasDetailQuery)
                {
                    critDetail.SetProjection(Projections.Distinct(Projections.Property("StockInDetailPK.StockInId")));
                    executeCrit.Add(LambdaSubquery.Property<StockIn>(p => p.StockInId).In(critDetail));
                }

                executeCrit.SetMaxResults(20);
                //executeCrit.SetResultTransformer(Transformers.DistinctRootEntity);
                return executeCrit.List<StockIn>();
            }
                                 );
        }

        public StockIn Fetch(StockIn stockIn)
        {
            return StockInDao.Fetch(stockIn);
        }
    }


    public class StockInCriteria
    {
        public bool DatePick { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public string Description { get; set; }
        public IList<string> ProductMasterNames { get; set; }
        public string CategoryName { get; set; }
        public IList<string> TypeNames { get; set; }

    }
}