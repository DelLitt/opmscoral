using System;
using System.Collections;
using AppFrame.Common;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

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
            criteria = new ObjectCriteria();
            criteria.AddGreaterCriteria("ProductId", dateStr + "000000");

            maxId = ProductDAO.SelectSpecificType(criteria, Projections.Max("ProductId"));
            var productId = (maxId == null) 
                ? Int64.Parse(dateStr + "000001")
                : (Int64.Parse(maxId.ToString()) + 1);

            maxId = StockDAO.SelectSpecificType(null, Projections.Max("StockId"));
            var stockId = maxId == null ? 1 : Int64.Parse(maxId.ToString()) + 1;

            data.CreateDate = DateTime.Now;
            data.UpdateDate = DateTime.Now;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            data.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            StockInDAO.Add(data);

            foreach (StockInDetail stockInDetail in data.StockInDetails)
            {
                // add product
                Product product = stockInDetail.Product;
                if (string.IsNullOrEmpty(product.ProductId))
                {
                    product.ProductId = string.Format("{0:000000000000}", productId++);
                    product.CreateDate = DateTime.Now;
                    product.UpdateDate = DateTime.Now;
                    product.Quantity = stockInDetail.Quantity;
                    product.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    product.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    ProductDAO.Add(product);

                    // add dept stock in
                    var detailPK = new StockInDetailPK { ProductId = product.ProductId, StockInId = stockInId};
                    stockInDetail.StockInDetailPK = detailPK;
                    stockInDetail.CreateDate = DateTime.Now;
                    stockInDetail.UpdateDate = DateTime.Now;
                    stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockInDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockInDetail.ProductMaster = product.ProductMaster;
                    StockInDetailDAO.Add(stockInDetail);

                    // dept stock
                    var stock = new Stock
                    {
                        StockId = stockId++,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Product = product,
                        Quantity = stockInDetail.Quantity,
                        ProductMaster = product.ProductMaster
                    };
                    stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    StockDAO.Add(stock);

                    var pricePk = new DepartmentPricePK { DepartmentId = 0, ProductMasterId = product.ProductMaster.ProductMasterId };

                    var price = DepartmentPriceDAO.FindById(pricePk);
                    if (price == null)
                    {
                        price = new DepartmentPrice { DepartmentPricePK = pricePk, Price = stockInDetail.SellPrice, UpdateDate = DateTime.Now, CreateDate = DateTime.Now };
                        price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        price.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        DepartmentPriceDAO.Add(price);
                    }
                    else
                    {
                        price.Price = stockInDetail.SellPrice;
                        price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        price.UpdateDate = DateTime.Now;
                        DepartmentPriceDAO.Update(price);
                    }
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
            string dateStr = data.StockInDate.ToString("yyMMdd");

            var criteria = new ObjectCriteria();
            criteria.AddGreaterCriteria("ProductId", dateStr + "000000");

            var maxId = ProductDAO.SelectSpecificType(criteria, Projections.Max("ProductId"));
            var productId = (maxId == null)
                ? Int64.Parse(dateStr + "000001")
                : (Int64.Parse(maxId.ToString()) + 1);

            maxId = StockDAO.SelectSpecificType(null, Projections.Max("StockId"));
            var stockId = maxId == null ? 1 : Int64.Parse(maxId.ToString()) + 1;


            data.UpdateDate = DateTime.Now;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;


            int delFlg = 0;
            foreach (StockInDetail stockInDetail in data.StockInDetails)
            {
                // add product
                Product product = stockInDetail.Product;
                if (string.IsNullOrEmpty(product.ProductId))
                {
                    product.ProductId = string.Format("{0:000000000000}", productId++);
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
                    StockInDetailDAO.Add(stockInDetail);

                    // dept stock
                    var departmentStock = new Stock
                    {
                        StockId = stockId++,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Product = product,
                        ProductMaster = product.ProductMaster,
                        Quantity = stockInDetail.Quantity
                    };
                    departmentStock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    departmentStock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    StockDAO.Add(departmentStock);

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

                    // update stock
                    criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("Product.ProductId", product.ProductId);
                    criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                    IList departmentStockList = StockDAO.FindAll(criteria);
                    if (departmentStockList.Count > 0)
                    {
                        Stock stock = (Stock) departmentStockList[0];
                        stock.UpdateDate = DateTime.Now;
                        if (stockInDetail.DelFlg == 0)
                        {
                            stock.Quantity = stock.Quantity -
                                                       (stockInDetail.OldQuantity - stockInDetail.Quantity);
                        }
                        else
                        {
                            stock.DelFlg = 1;
                        }
                        stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        StockDAO.Update(stock);

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
    }
}