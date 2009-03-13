using System;
using System.Collections;
using AppFrame.Common;
using AppFrame.Exceptions;
using NHibernate.Criterion;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;

namespace AppFrame.Logic
{
    public class DepartmentStockInLogicImpl : IDepartmentStockInLogic
    {
        public IDepartmentStockInDetailDAO DepartmentStockInDetailDAO { get; set; }
        public IDepartmentStockDAO DepartmentStockDAO { get; set; }
        public IProductDAO ProductDAO { get; set; }
        public IStockDAO StockDAO { get; set; }
        public IDepartmentStockInDAO DepartmentStockInDAO { get; set; }
        public IDepartmentPriceDAO DepartmentPriceDAO { get; set; }
        public IDepartmentDAO DepartmentDAO { get; set; }
        public IProductColorDAO ProductColorDAO { get; set; }
        public IProductTypeDAO ProductTypeDAO { get; set; }
        public IProductSizeDAO ProductSizeDAO { get; set; }
        public IProductMasterDAO ProductMasterDAO { get; set; }
        public ICountryDAO CountryDAO { get; set; }
        public IDistributorDAO DistributorDAO { get; set; }
        public IPackagerDAO PackagerDAO { get; set; }
        public IManufacturerDAO ManufacturerDAO { get; set; }

        /// <summary>
        /// Find DepartmentStockIn object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of DepartmentStockIn</param>
        /// <returns></returns>
        public DepartmentStockIn FindById(object id)
        {
            return DepartmentStockInDAO.FindById(id);
        }
        
        /// <summary>
        /// Add DepartmentStockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public DepartmentStockIn Add(DepartmentStockIn data)
        {
            string deptStr = string.Format("{0:000}", data.DepartmentId);
            string dateStr = data.StockInDate.ToString("yyMMdd");
            var criteria = new ObjectCriteria();
            criteria.AddGreaterCriteria("DepartmentStockInPK.StockInId", dateStr + deptStr + "00000");
            var maxId = DepartmentStockInDAO.SelectSpecificType(criteria, Projections.Max("DepartmentStockInPK.StockInId"));
            var stockInId = maxId == null ? dateStr + deptStr + "00001" : string.Format("{0:00000000000000}", (Int64.Parse(maxId.ToString()) + 1));

            var stockInPk = new DepartmentStockInPK {DepartmentId = data.DepartmentId, StockInId = stockInId + ""};

            data.DepartmentStockInPK = stockInPk;
            data.CreateDate = DateTime.Now;
            data.UpdateDate = DateTime.Now;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            data.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            DepartmentStockInDAO.Add(data);

            // we will get the stock to get the data
            IList productMasterIds = new ArrayList();
            foreach (DepartmentStockInDetail stockInDetail in data.DepartmentStockInDetails)
            {
                productMasterIds.Add(stockInDetail.Product.ProductMaster.ProductMasterId);
            }

            criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddGreaterCriteria("Quantity", (long)0);
            criteria.AddSearchInCriteria("ProductMaster.ProductMasterId", productMasterIds);
            criteria.AddOrder("ProductMaster.ProductMasterId", true);
            criteria.AddOrder("Product.ProductId", true);
            IList stockList = StockDAO.FindAll(criteria);

            IList updateStockList = new ArrayList();
            IList stockInDetailList = new ArrayList();
            foreach (DepartmentStockInDetail stockInDetail in data.DepartmentStockInDetails)
            {
                long quantity = stockInDetail.Quantity;
                foreach (Stock stock in stockList)
                {
                    long stockInQty = 0;
                    if (stock.ProductMaster.ProductMasterId.Equals(stockInDetail.Product.ProductMaster.ProductMasterId) && stock.Quantity > 0)
                    {
                        if (quantity >= stock.Quantity)
                        {
                            stockInQty = stock.Quantity;
                            quantity -= stock.Quantity;
                            stock.Quantity = 0;
                        }
                        else
                        {
                            stockInQty = quantity;
                            stock.Quantity -= quantity;
                            quantity = 0;
                        }
                        stock.UpdateDate = DateTime.Now;
                        stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        updateStockList.Add(stock);
                        var pk = new DepartmentStockInDetailPK
                                   {
                                       DepartmentId = data.DepartmentId,
                                       ProductId = stock.Product.ProductId,
                                       StockInId = stockInId
                                   };
                        var detail = new DepartmentStockInDetail
                        {
                            DepartmentStockInDetailPK = pk,
                            Quantity = stockInQty,
                            CreateDate = DateTime.Now,
                            UpdateDate = DateTime.Now,
                            UpdateId = ClientInfo.getInstance().LoggedUser.Name,
                            CreateId = ClientInfo.getInstance().LoggedUser.Name,
                            ProductMaster = stock.ProductMaster
                        };
                        var deptStock = new DepartmentStock
                                            {
                                                DepartmentStockPK = new DepartmentStockPK
                                                                        {
                                                                            DepartmentId = data.DepartmentId,
                                                                            ProductId = stock.Product.ProductId
                                                                        },
                                                CreateDate = DateTime.Now,
                                                UpdateDate = DateTime.Now,
                                                UpdateId = ClientInfo.getInstance().LoggedUser.Name,
                                                CreateId = ClientInfo.getInstance().LoggedUser.Name,
                                                ProductMaster = stock.ProductMaster
                                            };
                        stockInDetailList.Add(detail);
                        if (quantity == 0)
                        {
                            break;
                        }
                    }
                }
                if (quantity > 0)
                {
                    data.DepartmentStockInPK.StockInId = null;
                    throw new BusinessException("Số lượng xuất kho lớn hơn số lượng trong kho");
                }
            }

            foreach (DepartmentStockInDetail detail in stockInDetailList)
            {
                DepartmentStockInDetailDAO.Add(detail);
            }

            foreach (Stock stock in updateStockList)
            {
                StockDAO.Update(stock);
            }
            return data;
        }

                /// <summary>
        /// Add DepartmentStockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public void Sync(DepartmentStockIn data)
        {
            DepartmentStockIn DepartmentStockIn = DepartmentStockInDAO.FindById(data.DepartmentStockInPK);
            if (DepartmentStockIn == null)
            {
                DepartmentStockInDAO.Add(data);
            }
            else
            {
                ObjectCriteria criteria = new ObjectCriteria();

                // currently we do not accept update stock in
                //return;
                // amend for debug
                DepartmentStockInDAO.Update(data);
            }

            IList productMasterIds = new ArrayList();
            IList productIds = new ArrayList();
            IList priceList = new ArrayList();
            IList quantityList = new ArrayList();

            // put master data first
            foreach (DepartmentStockInDetail detail in data.DepartmentStockInDetails)
            {
                if (detail.Product.ProductMaster.ProductColor != null)
                {
                    ProductColor color = ProductColorDAO.FindById(detail.Product.ProductMaster.ProductColor.ColorId);
                    if (color == null)
                    {
                        ProductColorDAO.Add(detail.Product.ProductMaster.ProductColor);
                    }
                }
                if (detail.Product.ProductMaster.ProductSize != null)
                {
                    ProductSize Size = ProductSizeDAO.FindById(detail.Product.ProductMaster.ProductSize.SizeId);
                    if (Size == null)
                    {
                        ProductSizeDAO.Add(detail.Product.ProductMaster.ProductSize);
                    }
                }
                if (detail.Product.ProductMaster.ProductType != null)
                {
                    ProductType Type = ProductTypeDAO.FindById(detail.Product.ProductMaster.ProductType.TypeId);
                    if (Type == null)
                    {
                        ProductTypeDAO.Add(detail.Product.ProductMaster.ProductType);
                    }
                }
                if (detail.Product.ProductMaster.Country != null)
                {
                    Country Country = CountryDAO.FindById(detail.Product.ProductMaster.Country.CountryId);
                    if (Country == null)
                    {
                        CountryDAO.Add(detail.Product.ProductMaster.Country);
                    }
                }
                if (detail.Product.ProductMaster.Distributor != null)
                {
                    Distributor Distributor =
                        DistributorDAO.FindById(detail.Product.ProductMaster.Distributor.DistributorId);
                    if (Distributor == null)
                    {
                        DistributorDAO.Add(detail.Product.ProductMaster.Distributor);
                    }
                }
                if (detail.Product.ProductMaster.Packager != null)
                {
                    Packager Packager = PackagerDAO.FindById(detail.Product.ProductMaster.Packager.PackagerId);
                    if (Packager == null)
                    {
                        PackagerDAO.Add(detail.Product.ProductMaster.Packager);
                    }
                }
                if (detail.Product.ProductMaster.Manufacturer != null)
                {
                    Manufacturer Manufacturer =
                        ManufacturerDAO.FindById(detail.Product.ProductMaster.Manufacturer.ManufacturerId);
                    if (Manufacturer == null)
                    {
                        ManufacturerDAO.Add(detail.Product.ProductMaster.Manufacturer);
                    }
                }
                ProductMaster ProductMaster = ProductMasterDAO.FindById(detail.Product.ProductMaster.ProductMasterId);
                if (ProductMaster == null)
                {
                    ProductMasterDAO.Add(detail.Product.ProductMaster);
                }
                else
                {
                    ProductMaster.Country = detail.Product.ProductMaster.Country;
                    ProductMaster.Packager = detail.Product.ProductMaster.Packager;
                    ProductMaster.ProductColor = detail.Product.ProductMaster.ProductColor;
                    ProductMaster.ProductFullName = detail.Product.ProductMaster.ProductFullName;
                    ProductMaster.ProductName = detail.Product.ProductMaster.ProductName;
                    ProductMaster.ProductSize = detail.Product.ProductMaster.ProductSize;
                    ProductMaster.ProductType = detail.Product.ProductMaster.ProductType;
                    ProductMaster.UpdateDate = detail.Product.ProductMaster.UpdateDate;
                    ProductMaster.UpdateId = detail.Product.ProductMaster.UpdateId;
                    ProductMaster.CreateDate = detail.Product.ProductMaster.CreateDate;
                    ProductMaster.CreateId = detail.Product.ProductMaster.CreateId;
                    ProductMaster.Distributor = detail.Product.ProductMaster.Distributor;
                    ProductMaster.Manufacturer = detail.Product.ProductMaster.Manufacturer;
                    ProductMaster.ImagePath = detail.Product.ProductMaster.ImagePath;
                    ProductMaster.ExclusiveKey = detail.Product.ProductMaster.ExclusiveKey;

                    ProductMasterDAO.Update(ProductMaster);
                }
                if (!productMasterIds.Contains(detail.Product.ProductMaster.ProductMasterId))
                {
                    productMasterIds.Add(detail.Product.ProductMaster.ProductMasterId);
                    priceList.Add(detail.Price);
                }

                Product Product = ProductDAO.FindById(detail.Product.ProductId);
                if (Product == null)
                {
                    ProductDAO.Add(detail.Product);
                }
                else
                {
                    Product.UpdateDate = detail.Product.UpdateDate;
                    Product.UpdateId = detail.Product.UpdateId;
                    Product.CreateDate = detail.Product.CreateDate;
                    Product.CreateId = detail.Product.CreateId;
                    Product.ProductMaster = detail.Product.ProductMaster;
                    Product.Quantity = detail.Product.Quantity;
                    Product.Price = detail.Product.Price;
                    ProductDAO.Update(Product);
                }

                if (!productIds.Contains(detail.Product.ProductId))
                {
                    productIds.Add(detail.Product.ProductId);
                    quantityList.Add(detail.Quantity);
                }

                DepartmentStockInDetail DepartmentStockInDetail =
                    DepartmentStockInDetailDAO.FindById(detail.DepartmentStockInDetailPK);
                if (DepartmentStockInDetail == null)
                {
                    DepartmentStockInDetailDAO.Add(detail);
                }
                else
                {
                    DepartmentStockInDetail.UpdateDate = detail.UpdateDate;
                    DepartmentStockInDetail.UpdateId = detail.UpdateId;
                    DepartmentStockInDetail.CreateDate = detail.CreateDate;
                    DepartmentStockInDetail.CreateId = detail.CreateId;
                    DepartmentStockInDetail.Quantity = DepartmentStockInDetail.Quantity;
                    DepartmentStockInDetail.Price = DepartmentStockInDetail.Price;

                    DepartmentStockInDetailDAO.Update(DepartmentStockInDetail);
                }
            }

            // update price
            if (productMasterIds.Count > 0)
            {
                var criteria = new ObjectCriteria();
                criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddEqCriteria("DepartmentPricePK.DepartmentId", (long)0);
                criteria.AddSearchInCriteria("DepartmentPricePK.ProductMasterId", productMasterIds);
                IList deptPriceList = DepartmentPriceDAO.FindAll(criteria);
                int i = 0;
                foreach (string productMasterId in productMasterIds)
                {
                    DepartmentPrice price = null;
                    foreach (DepartmentPrice price1 in deptPriceList)
                    {
                        if (price1.DepartmentPricePK.ProductMasterId.Equals(productMasterId))
                        {
                            price = price1;
                            price.Price = (Int64)priceList[i];
                            break;
                        }
                    }
                    if (price == null)
                    {
                        price = new DepartmentPrice{DepartmentPricePK = new DepartmentPricePK{DepartmentId = 0, ProductMasterId = productMasterId}, Price = (Int64)priceList[i]};
                        DepartmentPriceDAO.Add(price);
                    }
                    else
                    {
                        DepartmentPriceDAO.Update(price);
                    }
                    i++;
                }
            }

            if (productIds.Count > 0)
            {
                var criteria = new ObjectCriteria();
                criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddEqCriteria("DepartmentStockPK.DepartmentId", data.DepartmentStockInPK.DepartmentId);
                criteria.AddSearchInCriteria("DepartmentStockPK.ProductId", productIds);
                IList stockList = DepartmentStockDAO.FindAll(criteria);
                int i = 0;
                foreach (string productId in productIds)
                {
                    DepartmentStock stock = null;
                    foreach (DepartmentStock price1 in stockList)
                    {
                        if (price1.DepartmentStockPK.ProductId.Equals(productId))
                        {
                            stock = price1;
                            stock.Quantity += (Int64)quantityList[i];
                            break;
                        }
                    }
                    if (stock == null)
                    {
                        stock = new DepartmentStock
                                    {
                                        DepartmentStockPK = new DepartmentStockPK { DepartmentId = data.DepartmentStockInPK.DepartmentId, ProductId = productId },
                                        Quantity = (Int64)quantityList[i]
                                    };
                        DepartmentStockDAO.Add(stock);
                    }
                    else
                    {
                        DepartmentStockDAO.Update(stock);
                    }
                    i++;
                }
            }
        }

        /// <summary>
        /// Update DepartmentStockIn to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(DepartmentStockIn data)
        {
            data.DepartmentId = CurrentDepartment.Get().DepartmentId;
            data.UpdateDate = DateTime.Now;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            
            
            int delFlg = 0;
            foreach (DepartmentStockInDetail stockInDetail in data.DepartmentStockInDetails)
            {
                // add product
                Product product = stockInDetail.Product;
                if (string.IsNullOrEmpty(product.ProductId))
                {
                    // TODO product.ProductId = productId++;
                    product.CreateDate = DateTime.Now;
                    product.UpdateDate = DateTime.Now;
                    product.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    product.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    ProductDAO.Add(product);

                    // add dept stock in
                    var detailPK = new DepartmentStockInDetailPK { DepartmentId = data.DepartmentId, ProductId = product.ProductId, StockInId = data.DepartmentStockInPK.StockInId};
                    stockInDetail.DepartmentStockInDetailPK = detailPK;
                    stockInDetail.CreateDate = DateTime.Now;
                    stockInDetail.UpdateDate = DateTime.Now;
                    stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stockInDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    DepartmentStockInDetailDAO.Add(stockInDetail);

                    // dept stock
                    var stockPk = new DepartmentStockPK { DepartmentId = data.DepartmentId, ProductId = product.ProductId };
                    var departmentStock = new DepartmentStock
                    {
                        DepartmentStockPK = stockPk,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Product = product,
                        Quantity = product.Quantity,
                        OnStorePrice = stockInDetail.OnStorePrice
                    };
                    departmentStock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    departmentStock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    DepartmentStockDAO.Add(departmentStock);

                    var pricePk = new DepartmentPricePK { DepartmentId = data.DepartmentId, ProductMasterId = product.ProductMaster.ProductMasterId };

                    var price = DepartmentPriceDAO.FindById(pricePk);
                    if (price == null)
                    {
                        price = new DepartmentPrice { DepartmentPricePK = pricePk, Price = stockInDetail.OnStorePrice, UpdateDate = DateTime.Now, CreateDate = DateTime.Now };
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
                    var detailPK = new DepartmentStockInDetailPK { DepartmentId = data.DepartmentId, ProductId = product.ProductId, StockInId = data.DepartmentStockInPK.StockInId};
                    stockInDetail.DepartmentStockInDetailPK = detailPK;
                    stockInDetail.UpdateDate = DateTime.Now;
                    stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    DepartmentStockInDetailDAO.Update(stockInDetail);

                    // update stock
                    var stockPk = new DepartmentStockPK { DepartmentId = data.DepartmentId, ProductId = product.ProductId};
                    var departmentStock = DepartmentStockDAO.FindById(stockPk);
                    departmentStock.UpdateDate = DateTime.Now;
                    if (stockInDetail.DelFlg == 0)
                    {
                        departmentStock.Quantity = departmentStock.Quantity -
                                                   (stockInDetail.OldQuantity - stockInDetail.Quantity);
                    }
                    else
                    {
                        departmentStock.DelFlg = 1;
                    }
                    departmentStock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    departmentStock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    DepartmentStockDAO.Update(departmentStock);

                    var pricePk = new DepartmentPricePK { DepartmentId = data.DepartmentId, ProductMasterId = product.ProductMaster.ProductMasterId };

                    var price = DepartmentPriceDAO.FindById(pricePk);
                    if (price == null)
                    {
                        price = new DepartmentPrice { DepartmentPricePK = pricePk, Price = stockInDetail.OnStorePrice, UpdateDate = DateTime.Now, CreateDate = DateTime.Now };
                        price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        price.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        DepartmentPriceDAO.Add(price);
                    }
                }
            }

            if (delFlg == data.DepartmentStockInDetails.Count)
            {
                data.DelFlg = 1;
            }
            DepartmentStockInDAO.Update(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockIn from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(DepartmentStockIn data)
        {
            DepartmentStockInDAO.Delete(data);
        }
        
        /// <summary>
        /// Delete DepartmentStockIn from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            DepartmentStockInDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all DepartmentStockIn from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return DepartmentStockInDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all DepartmentStockIn from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return DepartmentStockInDAO.FindPaging(criteria);
        }

        #region IDepartmentStockInLogic Members


        public IList FindByProductMaster(long id, DateTime date, DateTime toDate)
        {
            return DepartmentStockInDAO.FindByProductMaster(id, date, toDate);
        }

        #endregion

        #region IDepartmentStockInLogic Members


        public void AddReStock(DepartmentStockIn @in)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}