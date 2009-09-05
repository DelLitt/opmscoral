using System;
using System.Collections;
using AppFrame.Common;
using AppFrame.Utility;
using AppFrameClient.Common;
using NHibernate.Criterion;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;
using System.Collections.Generic;

namespace AppFrame.Logic
{
    public class StockInLogicImpl : IStockInLogic
    {
        public IStockInDAO StockInDAO { get; set; }
        public IStockInDetailDAO StockInDetailDAO { get; set; }
        public IStockDAO StockDAO { get; set; }
        public IProductDAO ProductDAO { get; set; }
        public IDepartmentPriceDAO DepartmentPriceDAO { get; set; }

        /// <summary>
        /// Find StockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of StockIn</param>
        /// <returns></returns>
        public StockIn FindById(object id)
        {
            return StockInDAO.FindById(id);
        }

        [Transaction(ReadOnly = false)]
        public void AddReStock(StockIn data)
        {
            string dateStr = data.StockInDate.ToString("yyMMdd");
            var criteria = new ObjectCriteria();
            criteria.AddGreaterCriteria("StockInId", dateStr + "00000");
            var maxId = StockInDAO.SelectSpecificType(criteria, Projections.Max("StockInId"));
            var stockInId = maxId == null ? dateStr + "00001" : string.Format("{0:00000000000}", (Int64.Parse(maxId.ToString()) + 1));

            data.CreateDate = DateTime.Now;
            data.UpdateDate = DateTime.Now;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            data.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            data.StockInType = (long) 1;
            data.StockInId = stockInId;
            StockInDAO.Add(data);
            
            foreach (StockInDetail stockInDetail in data.StockInDetails)
            {
                // add dept stock in
                var detailPK = new StockInDetailPK { ProductId = stockInDetail.Product.ProductId, StockInId = stockInId };
                stockInDetail.StockInDetailPK = detailPK;
                stockInDetail.CreateDate = DateTime.Now;
                stockInDetail.UpdateDate = DateTime.Now;
                stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                stockInDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                stockInDetail.ProductMaster = stockInDetail.Product.ProductMaster;
                //                    stockInDetail.CurrentStockQuantity = (sum == null) ? 0 : Int64.Parse(sum.ToString());
                StockInDetailDAO.Add(stockInDetail);
                ObjectCriteria stockCriteria = new ObjectCriteria();
                stockCriteria.AddEqCriteria("Product.ProductId", stockInDetail.Product.ProductId);
                IList stockList = StockDAO.FindAll(stockCriteria);
                
                // decrease error and increase good
                if(stockList != null)
                {
                    Stock stock = (Stock)stockList[0];
                    stock.ErrorQuantity -= stockInDetail.Quantity;
                    stock.GoodQuantity += stockInDetail.Quantity;
                    stock.Quantity = stock.ErrorQuantity + stock.GoodQuantity + stock.DamageQuantity +
                                     stock.UnconfirmQuantity + stock.LostQuantity;
                    StockDAO.Update(stock);
                }
            }
        }

        /// <summary>
        /// Add StockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public StockIn Add(StockIn data)
        {
            string dateStr = data.StockInDate.ToString("yyMMdd");
            var criteria = new ObjectCriteria();
            criteria.AddGreaterCriteria("StockInId", dateStr + "00000");
            var maxId = StockInDAO.SelectSpecificType(criteria, Projections.Max("StockInId"));
            var stockInId = maxId == null ? dateStr + "00001" : string.Format("{0:00000000000}", (Int64.Parse(maxId.ToString()) + 1));

            data.StockInId = stockInId;
            /*criteria = new ObjectCriteria();
            criteria.AddGreaterCriteria("ProductId", dateStr + "000000");

            maxId = ProductDAO.SelectSpecificType(criteria, Projections.Max("ProductId"));
            var productId = (maxId == null) 
                ? Int64.Parse(dateStr + "000001")
                : (Int64.Parse(maxId.ToString()) + 1);*/

            maxId = StockDAO.SelectSpecificType(null, Projections.Max("StockId"));
            var stockId = maxId == null ? 1 : Int64.Parse(maxId.ToString()) + 1;

            data.CreateDate = DateTime.Now;
            data.UpdateDate = DateTime.Now;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            data.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            StockInDAO.Add(data);
            IDictionary<string, string> maxPrdIdList = new Dictionary<string, string>();
            foreach (StockInDetail stockInDetail in data.StockInDetails)
            {
                // add product
                Product product = stockInDetail.Product;
                if (string.IsNullOrEmpty(product.ProductId))
                {
                    // find master ID
                    string masterId = product.ProductMaster.ProductMasterId;
                    masterId = masterId.Substring(6);
                    // search in product table to get latest number
                    string nextPrdId = GetProductIdFromList(maxPrdIdList,masterId);
                    if (nextPrdId == null)
                    {
                        string shortDate = StringUtility.ConvertDateToFourChar(DateTime.Now);
                        ObjectCriteria prdCrit = new ObjectCriteria();
                        prdCrit.AddLikeCriteria("ProductId", masterId + shortDate + "%");
                        var maxIPrdId = ProductDAO.SelectSpecificType(prdCrit, Projections.Max("ProductId"));
                        string productId = (maxIPrdId == null)
                                            ? masterId + shortDate + "01"
                                            : IncreaseMaxProductId(maxIPrdId.ToString());
                        
                        nextPrdId = productId;
                        maxPrdIdList[masterId] = nextPrdId;
                    }
                    product.ProductId = nextPrdId;
                    // increase product id and grant to the dictionary
                    nextPrdId = IncreaseMaxProductId(nextPrdId);
                    maxPrdIdList[masterId] = nextPrdId;
                    product.CreateDate = DateTime.Now;
                    product.UpdateDate = DateTime.Now;
                    product.Quantity = stockInDetail.Quantity;
                    product.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    product.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    ProductDAO.Add(product);

                    criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                    criteria.AddEqCriteria("ProductMaster.ProductMasterId", product.ProductMaster.ProductMasterId);
//                    var sum = StockDAO.SelectSpecificType(criteria, Projections.Sum("Quantity"));

                    // add dept stock in
                    var detailPK = new StockInDetailPK { ProductId = product.ProductId, StockInId = stockInId};
                    stockInDetail.StockInDetailPK = detailPK;
                    stockInDetail.CreateDate = DateTime.Now;
                    stockInDetail.UpdateDate = DateTime.Now;
                    stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockInDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockInDetail.ProductMaster = product.ProductMaster;
//                    stockInDetail.CurrentStockQuantity = (sum == null) ? 0 : Int64.Parse(sum.ToString());
                    StockInDetailDAO.Add(stockInDetail);

                    // if do not needs to confirm then update stock.
                    if (data.ConfirmFlg != 1)
                    {
                        // add stock
                        var stock = new Stock
                                        {
                                            StockId = stockId++,
                                            CreateDate = DateTime.Now,
                                            UpdateDate = DateTime.Now,
                                            Product = product,
                                            Quantity = stockInDetail.Quantity,
                                            GoodQuantity = stockInDetail.Quantity,
                                            ProductMaster = product.ProductMaster
                                        };
                        stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        StockDAO.Add(stock);
                    }
                    var pricePk = new DepartmentPricePK { DepartmentId = 0, ProductMasterId = product.ProductMaster.ProductMasterId };

                    var price = DepartmentPriceDAO.FindById(pricePk);
                    if (price == null)
                    {
                        price = new DepartmentPrice
                                    {
                                        DepartmentPricePK = pricePk, 
                                        Price = stockInDetail.SellPrice,
                                        UpdateDate = DateTime.Now, 
                                        CreateDate = DateTime.Now
                                    };
                        if(stockInDetail.DepartmentPrice!=null)
                        {
                            price.WholeSalePrice = stockInDetail.DepartmentPrice.WholeSalePrice;
                        }
                        price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        price.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        DepartmentPriceDAO.Add(price);
                    }
                    else
                    {
                        // don't need to update price
                        price.Price = stockInDetail.SellPrice;
                        price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        price.UpdateDate = DateTime.Now;
                        //DepartmentPriceDAO.Update(price);
                    }
                }
            }

            return data;
        }

        private string IncreaseMaxProductId(string s)
        {
            int nextId = Int32.Parse(s.Substring(10))+1;
            return s.Substring(0, 10)+ string.Format("{0:00}", nextId);
        }

        private string GetProductIdFromList(IDictionary<string, string> dictionary,string prdMasterId)
        {
            foreach (string key in dictionary.Keys)
            {
                if(key.Equals(prdMasterId))
                {
                    return dictionary[key];
                }
            }
            return null;   
        }

        /// <summary>
        /// Update StockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Update(StockIn data)
        {
            string dateStr = data.StockInDate.ToString("yyMMdd");

            var criteria = new ObjectCriteria();
            criteria.AddGreaterCriteria("ProductId", dateStr + "000000");

            //var maxId = ProductDAO.SelectSpecificType(criteria, Projections.Max("ProductId"));
            /*var productId = (maxId == null)
                ? Int64.Parse(dateStr + "000001")
                : (Int64.Parse(maxId.ToString()) + 1);*/

            var maxId = StockDAO.SelectSpecificType(null, Projections.Max("StockId"));
            var stockId = maxId == null ? 1 : Int64.Parse(maxId.ToString()) + 1;

            data.UpdateDate = DateTime.Now;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            int delFlg = 0;
            IDictionary<string, string> maxPrdIdList = new Dictionary<string, string>();
            foreach (StockInDetail stockInDetail in data.StockInDetails)
            {
                // add product
                Product product = stockInDetail.Product;
                if (string.IsNullOrEmpty(product.ProductId))
                {
                    //product.ProductId = string.Format("{0:000000000000}", productId++);
                    // find master ID
                    string masterId = product.ProductMaster.ProductMasterId;
                    masterId = masterId.Substring(6);
                    // search in product table to get latest number
                    string nextPrdId = GetProductIdFromList(maxPrdIdList, masterId);
                    if (nextPrdId == null)
                    {
                        string shortDate = StringUtility.ConvertDateToFourChar(DateTime.Now);
                        ObjectCriteria prdCrit = new ObjectCriteria();
                        prdCrit.AddLikeCriteria("ProductId", masterId + shortDate + "%");
                        var maxIPrdId = ProductDAO.SelectSpecificType(prdCrit, Projections.Max("ProductId"));
                        string productId = (maxIPrdId == null)
                                            ? masterId + shortDate + "01"
                                            : IncreaseMaxProductId(maxIPrdId.ToString());

                        nextPrdId = productId;
                        maxPrdIdList[masterId] = nextPrdId;
                    }
                    product.ProductId = nextPrdId;
                    // increase product id and grant to the dictionary
                    nextPrdId = IncreaseMaxProductId(nextPrdId);
                    maxPrdIdList[masterId] = nextPrdId;

                    product.CreateDate = DateTime.Now;
                    product.UpdateDate = DateTime.Now;
                    product.Quantity = stockInDetail.Quantity;
                    product.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    product.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    ProductDAO.Add(product);

                    // add dept stock in
                    var detailPK = new StockInDetailPK { ProductId = product.ProductId, StockInId = data.StockInId };
                    stockInDetail.StockInDetailPK = detailPK;
                    stockInDetail.CreateDate = DateTime.Now;
                    stockInDetail.UpdateDate = DateTime.Now;
                    stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockInDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockInDetail.ProductMaster = product.ProductMaster;
                    StockInDetailDAO.Add(stockInDetail);

                    if (!ClientSetting.ImportConfirmation)
                    {
                        // dept stock
                        var stock = new Stock
                                        {
                                            StockId = stockId++,
                                            CreateDate = DateTime.Now,
                                            UpdateDate = DateTime.Now,
                                            Product = product,
                                            ProductMaster = product.ProductMaster,
                                            Quantity = stockInDetail.Quantity,
                                            GoodQuantity = stockInDetail.Quantity
                                        };
                        stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        StockDAO.Add(stock);
                    }
                    var pricePk = new DepartmentPricePK { DepartmentId = 0, ProductMasterId = product.ProductMaster.ProductMasterId };

                    var price = DepartmentPriceDAO.FindById(pricePk);
                    if (price == null)
                    {
                        price = new DepartmentPrice { DepartmentPricePK = pricePk, Price = stockInDetail.SellPrice, UpdateDate = DateTime.Now, CreateDate = DateTime.Now };
                        price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        price.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        DepartmentPriceDAO.Add(price);
                    }
                }
                else
                {
                    var temProduct = ProductDAO.FindById(product.ProductId);
                    if (stockInDetail.DelFlg == 0)
                    {
                        temProduct.Quantity = product.Quantity;
                        temProduct.Price = product.Price;
                    }
                    else
                    {
                        temProduct.DelFlg = 1;
                        delFlg++;
                    }

                    temProduct.UpdateDate = DateTime.Now;
                    product.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

                    ProductDAO.Update(temProduct);

                    // update dept stock in
                    var detailPK = new StockInDetailPK { ProductId = product.ProductId, StockInId = data.StockInId };
                    stockInDetail.StockInDetailPK = detailPK;
                    stockInDetail.UpdateDate = DateTime.Now;
                    stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    StockInDetailDAO.Update(stockInDetail);

                    // if do not need to confirm then update stock
                    if (data.ConfirmFlg != 1)
                    {
                        // update stock
                        criteria = new ObjectCriteria();
                        criteria.AddEqCriteria("Product.ProductId", product.ProductId);
                        criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        IList stockList = StockDAO.FindAll(criteria);
                        if (stockList.Count > 0)
                        {
                            Stock stock = (Stock) stockList[0];
                            stock.UpdateDate = DateTime.Now;
                            if (stockInDetail.DelFlg == 0)
                            {

                                stock.GoodQuantity = stock.GoodQuantity -
                                                     (stockInDetail.OldQuantity - stockInDetail.Quantity);
                                stock.Quantity = stock.ErrorQuantity + stock.GoodQuantity + stock.DamageQuantity +
                                                 stock.UnconfirmQuantity + stock.LostQuantity;
                            }
                            else
                            {
                                stock.DelFlg = 1;
                            }
                            stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                            stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                            StockDAO.Update(stock);

                        }
                        else
                        {
                            // in case confirmation so stock in has been confirmed to update
                            if(ClientSetting.ImportConfirmation)
                            {
                                // dept stock
                                var stock = new Stock
                                {
                                    StockId = stockId++,
                                    CreateDate = DateTime.Now,
                                    UpdateDate = DateTime.Now,
                                    Product = product,
                                    ProductMaster = product.ProductMaster,
                                    Quantity = stockInDetail.Quantity,
                                    GoodQuantity = stockInDetail.Quantity
                                };
                                stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                                stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                                StockDAO.Add(stock); 
                            }
                        }
                    }

                    var pricePk = new DepartmentPricePK { DepartmentId = 0, ProductMasterId = product.ProductMaster.ProductMasterId };

                    var price = DepartmentPriceDAO.FindById(pricePk);
                    if (price == null)
                    {
                        price = new DepartmentPrice { DepartmentPricePK = pricePk, Price = stockInDetail.SellPrice, UpdateDate = DateTime.Now, CreateDate = DateTime.Now };
                        price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        price.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        DepartmentPriceDAO.Add(price);
                    }
                }
            }

            if (delFlg == data.StockInDetails.Count)
            {
                data.DelFlg = 1;
            }
            StockInDAO.Update(data);
        }
        
        /// <summary>
        /// Delete StockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(StockIn data)
        {
            StockInDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete StockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            StockInDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all StockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return StockInDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all StockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return StockInDAO.FindPaging(criteria);
        }

        public IList FindByProductMaster(DateTime fromDate,DateTime toDate)
        {
            return StockInDAO.FindByProductMaster(fromDate, toDate);
        }

        #region IStockInLogic Members


        public IList FindReStockIn(string id)
        {
            return StockInDetailDAO.FindReStock(id);
        }

        #endregion

        #region IStockInLogic Members


        public string FindMaxId()
        {
            string dateStr = DateTime.Now.ToString("yyMMdd");
            var criteria = new ObjectCriteria();
            criteria.AddGreaterCriteria("StockInId", dateStr + "00000");
            var maxId = StockInDAO.SelectSpecificType(criteria, Projections.Max("StockInId"));
            var stockInId = maxId == null ? dateStr + "00001" : string.Format("{0:00000000000}", (Int64.Parse(maxId.ToString()) + 1));
            return stockInId;
        }

        #endregion

        #region IStockInLogic Members


        public void AddFixedStockIn(StockIn stockIn)
        {
            StockInDAO.Add(stockIn);

            foreach (StockInDetail inDetail in stockIn.StockInDetails)
            {
                StockInDetailDAO.Add(inDetail);
            }
        }

        public void AddForStockOutToProducer(StockIn stockIn)
        {
            string dateStr = stockIn.StockInDate.ToString("yyMMdd");
            var criteria = new ObjectCriteria();
            var maxId = StockInDAO.SelectSpecificType(criteria, Projections.Max("StockInId"));
            var stockInId = maxId == null ? dateStr + "00001" : string.Format("{0:00000000000}", (Int64.Parse(maxId.ToString()) + 1));
            stockIn.StockInId = stockInId;
            StockInDAO.Add(stockIn);

            foreach (StockInDetail stockInDetail in stockIn.StockInDetails)
            {
                // add dept stock in
                var detailPK = new StockInDetailPK { ProductId = stockInDetail.Product.ProductId, StockInId = stockInId };
                stockInDetail.StockInDetailPK = detailPK;
                StockInDetailDAO.Add(stockInDetail);

                if (!stockIn.NotUpdateMainStock) // if need update main stock so update
                {
                    ObjectCriteria stockCriteria = new ObjectCriteria();
                    stockCriteria.AddEqCriteria("Product.ProductId", stockInDetail.Product.ProductId);
                    IList stockList = StockDAO.FindAll(stockCriteria);
                    // increase good
                    if (stockList != null)
                    {
                        Stock stock = (Stock) stockList[0];
                        stock.GoodQuantity += stockInDetail.Quantity;
                        stock.Quantity = stock.ErrorQuantity + stock.GoodQuantity + stock.DamageQuantity +
                                         stock.UnconfirmQuantity + stock.LostQuantity;
                        StockDAO.Update(stock);
                    }
                }
            }

        }

        [Transaction(ReadOnly = false)]
        public void UpdateDetail(StockIn data)
        {
            string dateStr = data.StockInDate.ToString("yyMMdd");

            var criteria = new ObjectCriteria();
            criteria.AddGreaterCriteria("ProductId", dateStr + "000000");

            //var maxId = ProductDAO.SelectSpecificType(criteria, Projections.Max("ProductId"));
            /*var productId = (maxId == null)
                ? Int64.Parse(dateStr + "000001")
                : (Int64.Parse(maxId.ToString()) + 1);*/

            var maxId = StockDAO.SelectSpecificType(null, Projections.Max("StockId"));
            var stockId = maxId == null ? 1 : Int64.Parse(maxId.ToString()) + 1;

            data.UpdateDate = DateTime.Now;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            int delFlg = 0;
            IDictionary<string, string> maxPrdIdList = new Dictionary<string, string>();
            foreach (StockInDetail stockInDetail in data.StockInDetails)
            {
                // add product
                Product product = stockInDetail.Product;
                if (string.IsNullOrEmpty(product.ProductId))
                {
                    //product.ProductId = string.Format("{0:000000000000}", productId++);
                    // find master ID
                    string masterId = product.ProductMaster.ProductMasterId;
                    masterId = masterId.Substring(6);
                    // search in product table to get latest number
                    string nextPrdId = GetProductIdFromList(maxPrdIdList, masterId);
                    if (nextPrdId == null)
                    {
                        string shortDate = StringUtility.ConvertDateToFourChar(DateTime.Now);
                        ObjectCriteria prdCrit = new ObjectCriteria();
                        prdCrit.AddLikeCriteria("ProductId", masterId + shortDate + "%");
                        var maxIPrdId = ProductDAO.SelectSpecificType(prdCrit, Projections.Max("ProductId"));
                        string productId = (maxIPrdId == null)
                                            ? masterId + shortDate + "01"
                                            : IncreaseMaxProductId(maxIPrdId.ToString());

                        nextPrdId = productId;
                        maxPrdIdList[masterId] = nextPrdId;
                    }
                    product.ProductId = nextPrdId;
                    // increase product id and grant to the dictionary
                    nextPrdId = IncreaseMaxProductId(nextPrdId);
                    maxPrdIdList[masterId] = nextPrdId;

                    product.CreateDate = DateTime.Now;
                    product.UpdateDate = DateTime.Now;
                    product.Quantity = stockInDetail.Quantity;
                    product.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    product.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    ProductDAO.Add(product);

                    // add dept stock in
                    var detailPK = new StockInDetailPK { ProductId = product.ProductId, StockInId = data.StockInId };
                    stockInDetail.StockInDetailPK = detailPK;
                    stockInDetail.CreateDate = DateTime.Now;
                    stockInDetail.UpdateDate = DateTime.Now;
                    stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockInDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockInDetail.ProductMaster = product.ProductMaster;
                    StockInDetailDAO.Add(stockInDetail);

                    if (!ClientSetting.ImportConfirmation)
                    {
                        // dept stock
                        var stock = new Stock
                        {
                            StockId = stockId++,
                            CreateDate = DateTime.Now,
                            UpdateDate = DateTime.Now,
                            Product = product,
                            ProductMaster = product.ProductMaster,
                            Quantity = stockInDetail.Quantity,
                            GoodQuantity = stockInDetail.Quantity
                        };
                        stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        StockDAO.Add(stock);
                    }
                    var pricePk = new DepartmentPricePK { DepartmentId = 0, ProductMasterId = product.ProductMaster.ProductMasterId };

                    var price = DepartmentPriceDAO.FindById(pricePk);
                    if (price == null)
                    {
                        price = new DepartmentPrice { DepartmentPricePK = pricePk, Price = stockInDetail.SellPrice, UpdateDate = DateTime.Now, CreateDate = DateTime.Now };
                        price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        price.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        DepartmentPriceDAO.Add(price);
                    }
                }
                else
                {
                    var temProduct = ProductDAO.FindById(product.ProductId);
                    if (stockInDetail.DelFlg == 0)
                    {
                        temProduct.Quantity = product.Quantity;
                        temProduct.Price = product.Price;
                    }
                    else
                    {
                        temProduct.DelFlg = 1;
                        delFlg++;
                    }

                    temProduct.UpdateDate = DateTime.Now;
                    product.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

                    ProductDAO.Update(temProduct);

                    // update dept stock in
                    var detailPK = new StockInDetailPK { ProductId = product.ProductId, StockInId = data.StockInId };
                    stockInDetail.StockInDetailPK = detailPK;
                    stockInDetail.UpdateDate = DateTime.Now;
                    stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    StockInDetailDAO.Update(stockInDetail);

                    // if do not need to confirm then update stock
                    if (data.ConfirmFlg != 1)
                    {
                        // update stock
                        criteria = new ObjectCriteria();
                        criteria.AddEqCriteria("Product.ProductId", product.ProductId);
                        criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        IList stockList = StockDAO.FindAll(criteria);
                        if (stockList.Count > 0)
                        {
                            Stock stock = (Stock)stockList[0];
                            stock.UpdateDate = DateTime.Now;
                            if (stockInDetail.DelFlg == 0)
                            {

                                stock.GoodQuantity = stock.GoodQuantity -
                                                     (stockInDetail.OldQuantity - stockInDetail.Quantity);
                                stock.Quantity = stock.ErrorQuantity + stock.GoodQuantity + stock.DamageQuantity +
                                                 stock.UnconfirmQuantity + stock.LostQuantity;
                            }
                            else
                            {
                                stock.DelFlg = 1;
                            }
                            stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                            stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                            StockDAO.Update(stock);

                        }
                        else
                        {
                            // in case confirmation so stock in has been confirmed to update
                            if (ClientSetting.ImportConfirmation)
                            {
                                // dept stock
                                var stock = new Stock
                                {
                                    StockId = stockId++,
                                    CreateDate = DateTime.Now,
                                    UpdateDate = DateTime.Now,
                                    Product = product,
                                    ProductMaster = product.ProductMaster,
                                    Quantity = stockInDetail.Quantity,
                                    GoodQuantity = stockInDetail.Quantity
                                };
                                stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                                stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                                StockDAO.Add(stock);
                            }
                        }
                    }

                    var pricePk = new DepartmentPricePK { DepartmentId = 0, ProductMasterId = product.ProductMaster.ProductMasterId };

                    var price = DepartmentPriceDAO.FindById(pricePk);
                    if (price == null)
                    {
                        price = new DepartmentPrice { DepartmentPricePK = pricePk, Price = stockInDetail.SellPrice, UpdateDate = DateTime.Now, CreateDate = DateTime.Now };
                        price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        price.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        DepartmentPriceDAO.Add(price);
                    }
                }
            }

            if (delFlg == data.StockInDetails.Count)
            {
                data.DelFlg = 1;
            }
            
        }

        [Transaction(ReadOnly = false)]
        public void UpdateMaster(StockIn data)
        {
            StockInDAO.Update(data); 
        }

        #endregion
    }
}