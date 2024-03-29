using System;
using System;
using System.Collections;
using System.Diagnostics;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Utility.Mapper;
using AppFrameClient.Common;
using AppFrameClient.Logic;
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
        public IEmployeeDAO EmployeeDAO { get; set; }
        public IEmployeeDetailDAO EmployeeDetailDAO { get; set; }

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
            string deptStr = "";
            if(ClientSetting.IsSubStock())
            {
                deptStr = string.Format("{0:00000}", data.DepartmentStockInPK.DepartmentId);
            }
            else
            {
                deptStr = string.Format("{0:000}", data.DepartmentStockInPK.DepartmentId);    
            }
            
            string dateStr = data.StockInDate.ToString("yyMMdd");
            var criteria = new ObjectCriteria();
            if(ClientSetting.IsSubStock())
            {
                criteria.AddGreaterCriteria("DepartmentStockInPK.StockInId", dateStr + deptStr + "000");    
            }
            else
            {
                criteria.AddGreaterCriteria("DepartmentStockInPK.StockInId", dateStr + deptStr + "00000");    
            }

            var maxId = DepartmentStockInDAO.SelectSpecificType(criteria, Projections.Max("DepartmentStockInPK.StockInId"));
            string stockInId = "";
            if(ClientSetting.IsSubStock())
            {
                stockInId = maxId == null ? dateStr + deptStr + "001" :   string.Format("{0:00000000000000}", (Int64.Parse(maxId.ToString()) + 1));
            }
            else
            {
                stockInId = maxId == null ? dateStr + deptStr + "00001" : string.Format("{0:00000000000000}", (Int64.Parse(maxId.ToString()) + 1));    
            }
            

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
            IList stockList = DepartmentStockDAO.FindAll(criteria);

            IList updateStockList = new ArrayList();
            IList stockInDetailList = new ArrayList();
            foreach (DepartmentStockInDetail stockInDetail in data.DepartmentStockInDetails)
            {
                long quantity = stockInDetail.Quantity;
                foreach (DepartmentStock stock in stockList)
                {
                    long stockInQty = 0;
                   if (stock.Product.ProductId.Equals(stockInDetail.ProductId) && stock.Quantity >= 0)
                    {
                        /*if (quantity >= stock.Quantity)
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
                        }*/
                        if (quantity >= stock.GoodQuantity)
                        {
                            stockInQty = stock.GoodQuantity;
                            quantity -= stock.GoodQuantity;
                            stock.GoodQuantity = 0;
                        }
                        else
                        {
                            stockInQty = quantity;
                            stock.GoodQuantity -= quantity;
                            quantity = 0;
                        }
                        stock.Quantity = stock.GoodQuantity + stock.ErrorQuantity + stock.DamageQuantity +
                                         stock.LostQuantity + stock.UnconfirmQuantity;
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
                        price = new DepartmentPrice
                                    {
                                        DepartmentPricePK = new DepartmentPricePK{DepartmentId = 0, ProductMasterId = productMasterId}, 
                                        Price = (Int64)priceList[i],
                                        CreateDate = DateTime.Now,
                                        CreateId = ClientInfo.getInstance().LoggedUser.Name,
                                        UpdateDate = DateTime.Now,
                                        UpdateId = ClientInfo.getInstance().LoggedUser.Name
                                    };
                        DepartmentPriceDAO.Add(price);
                    }
                    else
                    {
                        price.UpdateDate = DateTime.Now;
                        price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
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
                            //stock.Quantity += (Int64)quantityList[i];
                            stock.GoodQuantity += (Int64)quantityList[i];
                            stock.Quantity += (Int64) quantityList[i];
                            break;
                        }
                    }
                    if (stock == null)
                    {
                        stock = new DepartmentStock
                                    {
                                        DepartmentStockPK = new DepartmentStockPK { DepartmentId = data.DepartmentStockInPK.DepartmentId, ProductId = productId },
                                        Quantity = (Int64)quantityList[i],
                                        GoodQuantity = (Int64)quantityList[i],
                                        CreateDate = DateTime.Now,
                                        CreateId = ClientInfo.getInstance().LoggedUser.Name,
                                        UpdateDate = DateTime.Now,
                                        UpdateId = ClientInfo.getInstance().LoggedUser.Name
                                    };
                        DepartmentStockDAO.Add(stock);
                    }
                    else
                    {
                        stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        stock.UpdateDate = DateTime.Now;
                        DepartmentStockDAO.Update(stock);
                    }
                    i++;
                }
            }

            if (data.Department != null)
            {
                Department dept = DepartmentDAO.FindById(data.Department.DepartmentId);
                if (dept == null)
                {
                    DepartmentDAO.Add(data.Department);
                }
                else
                {
                    //dept.Active = data.Department.Active;
                    dept.Address = data.Department.Address;
                    dept.DepartmentName = data.Department.DepartmentName;
                    dept.ManagerId = data.Department.ManagerId;
                    dept.StartDate = data.Department.StartDate;
                    DepartmentDAO.Update(dept);
                }
                foreach (Employee employee in data.Department.Employees)
                {
                    Employee emp = EmployeeDAO.FindById(employee.EmployeePK);
                    if (emp == null)
                    {
                        EmployeeDAO.Add(employee);
                        if (employee.EmployeeInfo != null)
                        {
                            EmployeeDetailDAO.Add(employee.EmployeeInfo);
                        }
                    }
                    else
                    {
                        emp.DelFlg = employee.DelFlg;
                        EmployeeDAO.Update(emp);
                        if (employee.EmployeeInfo != null)
                        {
                            EmployeeDetailDAO.Update(employee.EmployeeInfo);
                        }
                    }
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
                        /*Quantity = product.Quantity,
                        GoodQuantity =product.Quantity,*/
                        Quantity = stockInDetail.Quantity,
                        GoodQuantity =stockInDetail.Quantity,
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
                        /*departmentStock.Quantity = departmentStock.Quantity -
                                                   (stockInDetail.OldQuantity - stockInDetail.Quantity);*/
                        departmentStock.GoodQuantity = departmentStock.GoodQuantity -
                                                   (stockInDetail.OldQuantity - stockInDetail.Quantity);
                        departmentStock.Quantity = departmentStock.GoodQuantity + departmentStock.ErrorQuantity +
                                                   departmentStock.LostQuantity + departmentStock.DamageQuantity +
                                                   departmentStock.UnconfirmQuantity;
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

        public void UpdateExportStatus(DepartmentStockIn data)
        {
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


        public void AddReStock(DepartmentStockIn data)
        {
            string deptStr = string.Format("{0:000}", data.DepartmentId);
            string dateStr = data.StockInDate.ToString("yyMMdd");
            var criteria = new ObjectCriteria();
            criteria.AddGreaterCriteria("DepartmentStockInPK.StockInId", dateStr + deptStr + "00000");
            var maxId = DepartmentStockInDAO.SelectSpecificType(criteria, Projections.Max("DepartmentStockInPK.StockInId"));
            var stockInId = maxId == null ? dateStr + deptStr + "00001" : string.Format("{0:00000000000000}", (Int64.Parse(maxId.ToString()) + 1));

            var stockInPk = new DepartmentStockInPK { DepartmentId = data.DepartmentId, StockInId = stockInId + "" };

            data.CreateDate = DateTime.Now;
            data.UpdateDate = DateTime.Now;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            data.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            data.StockInType = (long)1;
            data.DepartmentStockInPK = stockInPk;
            DepartmentStockInDAO.Add(data);

            foreach (DepartmentStockInDetail stockInDetail in data.DepartmentStockInDetails)
            {
                // add dept stock in
                var detailPK = new DepartmentStockInDetailPK 
                { ProductId = stockInDetail.Product.ProductId, 
                  StockInId = stockInId,
                  DepartmentId = data.DepartmentId};

                stockInDetail.DepartmentStockInDetailPK = detailPK;
                stockInDetail.CreateDate = DateTime.Now;
                stockInDetail.UpdateDate = DateTime.Now;
                stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                stockInDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                stockInDetail.ProductMaster = stockInDetail.Product.ProductMaster;

                //                    stockInDetail.CurrentStockQuantity = (sum == null) ? 0 : Int64.Parse(sum.ToString());
                DepartmentStockInDetailDAO.Add(stockInDetail);
                ObjectCriteria stockCriteria = new ObjectCriteria();
                stockCriteria.AddEqCriteria("DepartmentStockPK.ProductId", stockInDetail.Product.ProductId);
                stockCriteria.AddEqCriteria("DepartmentStockPK.DepartmentId", data.DepartmentId);
                IList stockList = DepartmentStockDAO.FindAll(stockCriteria);

                // decrease error and increase good
                if (stockList != null)
                {
                    DepartmentStock stock = (DepartmentStock)stockList[0];
                    stock.ErrorQuantity -= stockInDetail.Quantity;
                    stock.GoodQuantity += stockInDetail.Quantity;
                    stock.Quantity = stock.ErrorQuantity + stock.GoodQuantity + stock.DamageQuantity +
                                     stock.UnconfirmQuantity + stock.LostQuantity;
                    DepartmentStockDAO.Update(stock);
                }
            }
        }

        #endregion

        #region IDepartmentStockInLogic Members


        public IList FindReStockIn(string id)
        {
            return DepartmentStockInDetailDAO.FindReStock(id);
        }

        #endregion

        #region IDepartmentStockInLogic Members

        [Transaction(ReadOnly = false)]
        public void Sync(SyncFromMainToDepartment syncFromMainToDepartment)
        {
            IList prdMasterUpdateList = new ArrayList();
            IList needUpdateStocks = new ArrayList();
            IList needAddNewStocks = new ArrayList();
            // fix departmentStock first

            IList deptStockTemps = syncFromMainToDepartment.DepartmentStockTemps;
            if (deptStockTemps != null && deptStockTemps.Count > 0)
            {
                DepartmentStockOut deptStockOut = new DepartmentStockOut();
                object maxDSOId = DepartmentStockOutDAO.SelectSpecificType(null,
                                                                           Projections.Max(
                                                                               "DepartmentStockOutPK.StockOutId"));
                long maxDeptStockOutId = (maxDSOId != null ? (long) maxDSOId + 1 : 1);

                object maxDetId = DepartmentStockOutDetailDAO.SelectSpecificType(null,
                                                                                 Projections.Max("DepartmentStockOutDetailPK.StockOutDetailId"));
                long maxDeptStockOutDetId = (maxDetId != null ? (long) maxDetId + 1 : 1);
                deptStockOut.DepartmentStockOutPK = new DepartmentStockOutPK
                                                        {
                                                            DepartmentId = CurrentDepartment.Get().DepartmentId,
                                                            StockOutId = maxDeptStockOutId

                                                        };
                deptStockOut.DefectStatus = new StockDefectStatus {DefectStatusId = 5}; // xuat tra ve nha san xuat
                deptStockOut.ConfirmFlg = 1; // can xac nhan tu kho chinh
                
                deptStockOut.StockOutDate = DateTime.Now;
                deptStockOut.CreateDate = DateTime.Now;
                deptStockOut.UpdateDate = DateTime.Now;
                deptStockOut.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                deptStockOut.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                deptStockOut.DepartmentStockOutDetails = new ArrayList();
                foreach (DepartmentStockTemp deptStockTemp in deptStockTemps)
                {

                    // find the stock checking 
                    DepartmentStockTemp processedDeptStockTemp =
                    DepartmentStockTempDAO.FindById(deptStockTemp.DepartmentStockTempPK);

                    // if exist, then check whether was it processed.
                    if(processedDeptStockTemp!=null)
                    {
                        // if processed
                        if(processedDeptStockTemp.Fixed == 1)
                        {
                            continue; // process to next stock checking row
                        }
                    }
                    else // not exist, maybe error ..
                    {
                        continue; // process to next stock checking row
                    }


                    long realQty = deptStockTemp.GoodQuantity + deptStockTemp.ErrorQuantity +
                                   deptStockTemp.DamageQuantity +
                                   deptStockTemp.LostQuantity + deptStockTemp.UnconfirmQuantity;
                    if (realQty < deptStockTemp.Quantity)
                    {
                        long returnToStockQty = deptStockTemp.Quantity - realQty;
                        DepartmentStockOutDetail deptSODet = new DepartmentStockOutDetail();
                        deptSODet.DepartmentStockOutDetailPK = new DepartmentStockOutDetailPK();
                        deptSODet.DepartmentStockOutDetailPK.DepartmentId = CurrentDepartment.Get().DepartmentId;
                        deptSODet.DepartmentStockOutDetailPK.StockOutDetailId = maxDeptStockOutDetId++;
                        /*deptSODet.StockOutDetailId = maxDeptStockOutDetId++;*/
                        deptSODet.Product = deptStockTemp.Product;
                        deptSODet.ProductMaster = deptStockTemp.ProductMaster;
                        deptSODet.DepartmentStockOut = deptStockOut;
                        deptSODet.Description = "Số liệu dư được xuất về nhà sản xuất hủy";
                        deptSODet.CreateDate = DateTime.Now;
                        deptSODet.UpdateDate = DateTime.Now;
                        deptSODet.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        deptSODet.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        deptSODet.StockOutId = deptStockOut.DepartmentStockOutPK.StockOutId;
                        deptSODet.DepartmentId = deptStockOut.DepartmentStockOutPK.DepartmentId;

                        deptSODet.GoodQuantity = returnToStockQty;
                        deptSODet.Quantity = returnToStockQty;
                        deptSODet.DefectStatus = new StockDefectStatus {DefectStatusId = 5}; // xuat tra ve nha san xuat
                        deptStockOut.DepartmentStockOutDetails.Add(deptSODet);
                    }
                    DepartmentStockPK stockPk = new DepartmentStockPK
                                                    {
                                                        DepartmentId = deptStockTemp.DepartmentStockTempPK.DepartmentId,
                                                        ProductId = deptStockTemp.DepartmentStockTempPK.ProductId
                                                    };
                    DepartmentStock stock = DepartmentStockDAO.FindById(stockPk);
                    
                    if (stock != null)
                    {
                        prdMasterUpdateList.Add(stock.Product.ProductMaster);
                        long differGoodQty = stock.Quantity - deptStockTemp.Quantity;
                        stock.GoodQuantity = deptStockTemp.GoodQuantity + differGoodQty;
                        if(deptStockTemp.GoodQuantity > deptStockTemp.Quantity) // stock them vo
                        {
                            // lay so luong nguyen thuy de co the cong them khi stock in vao cua hang
                            stock.GoodQuantity = stock.Quantity;
                        }
                        stock.ErrorQuantity = deptStockTemp.ErrorQuantity;
                        stock.LostQuantity = deptStockTemp.LostQuantity;
                        stock.DamageQuantity = deptStockTemp.DamageQuantity;
                        stock.UnconfirmQuantity = deptStockTemp.UnconfirmQuantity;
                        stock.Quantity = stock.GoodQuantity + stock.ErrorQuantity + stock.LostQuantity +
                                         stock.DamageQuantity + stock.UnconfirmQuantity;
                        needUpdateStocks.Add(stock);
                    }

                    deptStockTemp.DelFlg = 1;
                    processedDeptStockTemp.Fixed = 1;
                    processedDeptStockTemp.DelFlg = 1;
                    DepartmentStockTempDAO.Update(processedDeptStockTemp);
                }
                if (deptStockOut.DepartmentStockOutDetails.Count > 0)
                {
                    DepartmentStockOutDAO.Add(deptStockOut);
                    foreach (DepartmentStockOutDetail detail in deptStockOut.DepartmentStockOutDetails)
                    {
                        DepartmentStockOutDetailDAO.Add(detail);
                    }
                }
            }

            IList stockOutList = syncFromMainToDepartment.StockOutList;
            long deptId = syncFromMainToDepartment.Department.DepartmentId;
            string deptStr = "000";
            if(deptId > 9999)
            {
                deptStr = deptId.ToString();
            }
            else
            {
               deptStr = string.Format("{0:000}", deptId);
            }
            
            string dateStr = DateTime.Now.ToString("yyMMdd");
            var criteria = new ObjectCriteria();
            if(deptId > 9999)
            {
                criteria.AddGreaterCriteria("DepartmentStockInPK.StockInId", dateStr + deptStr + "000");
            }
            else
            {
                criteria.AddGreaterCriteria("DepartmentStockInPK.StockInId", dateStr + deptStr + "00000");    
            }
            
            var maxId = DepartmentStockInDAO.SelectSpecificType(criteria, Projections.Max("DepartmentStockInPK.StockInId"));

            var stockInId ="";
            if(deptId > 9999)
            {
                stockInId = maxId == null ? dateStr + deptStr + "001" : string.Format("{0:00000000000000}", (Int64.Parse(maxId.ToString()) + 1));
            }
            else
            {
                stockInId = maxId == null ? dateStr + deptStr + "00001" : string.Format("{0:00000000000000}", (Int64.Parse(maxId.ToString()) + 1));
            }
                
            long nextDeptStockInId = Int64.Parse(stockInId);
            foreach (StockOut stockOut in stockOutList)
            {
                // convert stock out to department stock in
                DepartmentStockInMapper mapper = new DepartmentStockInMapper();
                DepartmentStockIn data = mapper.Convert(stockOut);
                data.Department = syncFromMainToDepartment.Department;
                // sync department stock in
                data.DepartmentStockInPK.StockInId = string.Format("{0:00000000000000}",nextDeptStockInId++);
                /*DepartmentStockIn DepartmentStockIn = DepartmentStockInDAO.FindById(data.DepartmentStockInPK);
                if (DepartmentStockIn == null)
                {
                    DepartmentStockInDAO.Add(data);
                }*/
                StockOut oldStockOut = StockOutDAO.FindById(stockOut.StockoutId);
                if (oldStockOut == null)
                {
                    StockOutDAO.Add(stockOut);
                    DepartmentStockInDAO.Add(data);
                }
                else
                {
                    //ObjectCriteria criteria = new ObjectCriteria();

                    // currently we do not accept update stock in
                    continue;
                    // amend for debug
                    //DepartmentStockInDAO.Update(data);
                }    

                // sync department stock in detail
                IList productMasterIds = new ArrayList();
                IList productIds = new ArrayList();
                IList priceList = new ArrayList();
                IList whosalePriceList = new ArrayList();
                IList quantityList = new ArrayList();

                
                // put master data first
                foreach (DepartmentStockInDetail detail in data.DepartmentStockInDetails)
                {
                    detail.DepartmentStockInDetailPK.StockInId = data.DepartmentStockInPK.StockInId;
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
                        ProductSize size = ProductSizeDAO.FindById(detail.Product.ProductMaster.ProductSize.SizeId);
                        if (size == null)
                        {
                            ProductSizeDAO.Add(detail.Product.ProductMaster.ProductSize);
                        }
                    }
                    ProductType Type = ProductTypeDAO.FindById(detail.Product.ProductMaster.ProductType.TypeId);
                    if (detail.Product.ProductMaster.ProductType != null)
                    {
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

                    //ProductMaster ProductMaster = ProductMasterDAO.FindById(detail.Product.ProductMaster.ProductMasterId);
                    ProductMaster ProductMaster = GetProductMaster(detail.Product.ProductMaster,prdMasterUpdateList);
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
                        whosalePriceList.Add(detail.OnStorePrice);
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
                    /*IList NotDupPMList = new ArrayList();
                    NotDupPMList = CreateNotDuplicateList(productMasterIds);*/
                    var objectCriteria = new ObjectCriteria();
                    objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                    objectCriteria.AddEqCriteria("DepartmentPricePK.DepartmentId", (long)0);
                    objectCriteria.AddSearchInCriteria("DepartmentPricePK.ProductMasterId", productMasterIds);
                    IList deptPriceList = DepartmentPriceDAO.FindAll(objectCriteria);
                    int i = 0;
                    IList newPriceList = new ArrayList();
                    foreach (string productMasterId in productMasterIds)
                    {
                        DepartmentPrice price = null;
                        bool found = false;
                        foreach (DepartmentPrice price1 in deptPriceList)
                        {
                            if (price1.DepartmentPricePK.ProductMasterId.Equals(productMasterId))
                            {
                                //price = price1;
                                found = true;
                                price1.Price = (Int64)priceList[i];
                                price1.WholeSalePrice = (Int64) whosalePriceList[i];
                                break;
                            }
                        }
                        if (!found)
                        {
                            foreach (DepartmentPrice price1 in newPriceList)
                            {
                                if (price1.DepartmentPricePK.ProductMasterId.Equals(productMasterId))
                                {
                                    //price = price1;
                                    found = true;
                                    price1.Price = (Int64) priceList[i];
                                    price1.WholeSalePrice = (Int64) whosalePriceList[i];
                                    break;
                                }
                            }
                        }
                        //if (price == null)
                        if (!found)
                        {
                            price = new DepartmentPrice
                            {
                                DepartmentPricePK = new DepartmentPricePK { DepartmentId = 0, ProductMasterId = productMasterId },
                                Price = (Int64)priceList[i],
                                WholeSalePrice = (Int64)whosalePriceList[i],
                                CreateDate = DateTime.Now,
                                CreateId = ClientInfo.getInstance().LoggedUser.Name,
                                UpdateDate = DateTime.Now,
                                UpdateId = ClientInfo.getInstance().LoggedUser.Name
                            };
                            newPriceList.Add(price);
                            //DepartmentPriceDAO.Add(price);
                        }
                        /*else
                        {
                            price.UpdateDate = DateTime.Now;
                            price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                            DepartmentPriceDAO.Update(price);
                        }*/
                        i++;
                    }
                    // patch for update stock
                        try
                        {
                            foreach (DepartmentPrice price in deptPriceList)
                            {
                                DepartmentPriceDAO.Update(price);    
                            }
                            foreach (DepartmentPrice price in newPriceList)
                            {
                                DepartmentPriceDAO.Add(price);
                            }   
                        }
                        catch (Exception)
                        {

                        }
                }

                // mix 2 lists
                // find lack productIds
                IList lackProductIds = new ArrayList();
                if(productIds.Count > 0)
                {
                    foreach (string productId in productIds)
                    {
                        bool hasFound = false;
                        foreach (DepartmentStock departmentStock in needUpdateStocks)
                        {
                            if(productId.Equals(departmentStock.DepartmentStockPK.ProductId))
                            {
                                hasFound = true;
                                break;
                            }
                        }
                        if(!hasFound)
                        {
                            lackProductIds.Add(productId);
                        }
                    }
                /*}

                if (productIds.Count > 0)
                {*/
                    if (lackProductIds.Count > 0)
                    {
                        var objectCrit1 = new ObjectCriteria();
                        objectCrit1.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        objectCrit1.AddEqCriteria("DepartmentStockPK.DepartmentId",
                                                  data.DepartmentStockInPK.DepartmentId);

                        
                        objectCrit1.AddSearchInCriteria("DepartmentStockPK.ProductId", lackProductIds);
                        IList stockList = DepartmentStockDAO.FindAll(objectCrit1);
                        if(stockList!= null && stockList.Count > 0)
                        {
                            foreach (DepartmentStock departmentStock in stockList)
                            {
                                needUpdateStocks.Add(departmentStock);
                            }
                        }
                    }
                    int i = 0;
                    foreach (string productId in productIds)
                    {
                        DepartmentStock stock = null;
                        foreach (DepartmentStock needUpdateStock in needUpdateStocks)
                        {
                            if (needUpdateStock.DepartmentStockPK.ProductId.Equals(productId))
                            {
                                stock = needUpdateStock;
                                //stock.Quantity += (Int64)quantityList[i];
                                needUpdateStock.GoodQuantity += (Int64)quantityList[i];
                                needUpdateStock.Quantity += (Int64)quantityList[i];
                                break;
                            }
                        }
                        if (stock == null)
                        {
                            // check in add new stock
                            foreach (DepartmentStock newStock in needAddNewStocks)
                            {
                                if(newStock.DepartmentStockPK.ProductId.Equals(productId))
                                {
                                    stock = newStock;
                                    //stock.Quantity += (Int64)quantityList[i];
                                    newStock.GoodQuantity += (Int64)quantityList[i];
                                    newStock.Quantity += (Int64)quantityList[i];
                                    break;
                                }
                            }
                            // if not found in addnewStock so we create new stock
                            if (stock == null)
                            {
                                stock = new DepartmentStock
                                            {
                                                DepartmentStockPK =
                                                    new DepartmentStockPK
                                                        {
                                                            DepartmentId = data.DepartmentStockInPK.DepartmentId,
                                                            ProductId = productId
                                                        },
                                                Quantity = (Int64) quantityList[i],
                                                GoodQuantity = (Int64) quantityList[i],
                                                CreateDate = DateTime.Now,
                                                CreateId = ClientInfo.getInstance().LoggedUser.Name,
                                                UpdateDate = DateTime.Now,
                                                UpdateId = ClientInfo.getInstance().LoggedUser.Name
                                            };
                                needAddNewStocks.Add(stock);
                            }
                            /*try
                            {
                                stock = new DepartmentStock
                                {
                                    DepartmentStockPK = new DepartmentStockPK { DepartmentId = data.DepartmentStockInPK.DepartmentId, ProductId = productId },
                                    Quantity = (Int64)quantityList[i],
                                    GoodQuantity = (Int64)quantityList[i],
                                    CreateDate = DateTime.Now,
                                    CreateId = ClientInfo.getInstance().LoggedUser.Name,
                                    UpdateDate = DateTime.Now,
                                    UpdateId = ClientInfo.getInstance().LoggedUser.Name
                                };
                                DepartmentStockDAO.Add(stock);    
                            }
                            catch (Exception)
                            {
                                
                            }*/
                            
                        }
                        /*else
                        {
                            stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                            stock.UpdateDate = DateTime.Now;
                            DepartmentStockDAO.Update(stock);
                        }*/
                        i++;
                    }
                }
                

            }

            // update stock
            foreach (DepartmentStock stock in needUpdateStocks)
            {
                    stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stock.UpdateDate = DateTime.Now;
                    DepartmentStockDAO.Update(stock);
            }
            // add new stock
            foreach (DepartmentStock addNewStock in needAddNewStocks)
            {
                DepartmentStockDAO.Add(addNewStock);
            }

            // update common data
            
            if (syncFromMainToDepartment.Department != null)
            {
                Department dept = DepartmentDAO.FindById(syncFromMainToDepartment.Department.DepartmentId);
                if (dept == null)
                {
                    DepartmentDAO.Add(syncFromMainToDepartment.Department);
                }
                else
                {
                    //dept.Active = data.Department.Active;
                    dept.Address = syncFromMainToDepartment.Department.Address;
                    dept.DepartmentName = syncFromMainToDepartment.Department.DepartmentName;
                    dept.ManagerId = syncFromMainToDepartment.Department.ManagerId;
                    dept.StartDate = syncFromMainToDepartment.Department.StartDate;
                    DepartmentDAO.Update(dept);
                }
                foreach (Employee employee in syncFromMainToDepartment.Department.Employees)
                {
                    Employee emp = EmployeeDAO.FindById(employee.EmployeePK);
                    if (emp == null)
                    {
                        EmployeeDAO.Add(employee);
                        if (employee.EmployeeInfo != null)
                        {
                            EmployeeDetailDAO.Add(employee.EmployeeInfo);
                        }
                    }
                    else
                    {
                        emp.DelFlg = employee.DelFlg;
                        EmployeeDAO.Update(emp);
                        if (employee.EmployeeInfo != null)
                        {
                            EmployeeDetailDAO.Update(employee.EmployeeInfo);
                        }
                    }
                }
            }

            if(syncFromMainToDepartment.UserInfoList!=null && syncFromMainToDepartment.UserInfoList.Count > 0)
            {
                IList needCreateRoleList = new ArrayList();
                IList needCheckRoleList = new ArrayList();
                IList roleList = RoleDAO.FindAll();

                foreach (LoginModel model in syncFromMainToDepartment.UserInfoList)
                {
                    foreach (RoleModel role in model.Roles)
                    {
                        needCheckRoleList.Add(role);
                    }
                }

                // check role
                foreach (RoleModel roleModel in needCheckRoleList)
                {
                    bool hasFound = false;
                    foreach (RoleModel existRole in roleList)
                    {
                        if (existRole.Id == roleModel.Id)
                        {
                            if (!existRole.Name.Equals(roleModel.Name)) existRole.Name = roleModel.Name;
                            hasFound = true;
                            break;
                        }
                    }

                    if (!hasFound)
                        {
                            bool addedToCreateList = false;
                            foreach (RoleModel needCreateRole in needCreateRoleList)
                            {
                                if(roleModel.Id == needCreateRole.Id)
                                {
                                    addedToCreateList = true;
                                    break;
                                }
                            }
                            if (!addedToCreateList) needCreateRoleList.Add(roleModel);
                        }
                    

                }
                foreach (RoleModel model in roleList)
                {
                    RoleDAO.Update(model);
                }
                foreach (RoleModel model in needCreateRoleList)
                {
                    RoleDAO.Add(model);
                }
                foreach (LoginModel model in syncFromMainToDepartment.UserInfoList)
                {
                    

                    LoginModel dbUserModel = LoginDAO.FindById(model.Username);
                    if (dbUserModel != null)
                    {
                        dbUserModel.Username = model.Username;
                        if (!dbUserModel.Password.Equals(model.Password))
                        {
                            if (DateTime.Compare(dbUserModel.UpdateDate, model.UpdateDate) < 0)
                            {
                                dbUserModel.Password = model.Password;
                            }
                        }
                        dbUserModel.Roles = model.Roles;
                        dbUserModel.EmployeeInfo = model.EmployeeInfo;
                        dbUserModel.Suspended = model.Suspended;
                        dbUserModel.Deleted = model.Deleted;

                        LoginDAO.Update(dbUserModel);
                    }
                    else
                    {
                        LoginDAO.Add(model);
                    }
                }
            }
        }

        private IList CreateNotDuplicateList(IList list)
        {
            IList resultList = new ArrayList();
            foreach (string s in list)
            {
                if(NotInList(resultList,s))
                {
                    resultList.Add(s);
                }
            }
            return resultList;
        }

        private bool NotInList(IList list, string s)
        {
            foreach (string c in list)
            {
                if(c.Equals(s))
                {
                    return false;
                }
            }
            return true;
        }

        [Transaction(ReadOnly = false)]
        public LogicResult SyncFromSubStock(DepartmentStockIn stockIn)
        {
            LogicResult result = new LogicResult();
            result.HasError = false;
            string deptStr = string.Format("{0:000}", stockIn.DepartmentStockInPK.DepartmentId);
            string dateStr = stockIn.StockInDate.ToString("yyMMdd");
            var crit = new ObjectCriteria();
            crit.AddGreaterCriteria("DepartmentStockInPK.StockInId", dateStr + deptStr + "00000");
            var maxId = DepartmentStockInDAO.SelectSpecificType(crit, Projections.Max("DepartmentStockInPK.StockInId"));
            var stockInId = maxId == null ? dateStr + deptStr + "00001" : string.Format("{0:00000000000000}", (Int64.Parse(maxId.ToString()) + 1));

            var stockInPk = new DepartmentStockInPK 
                                                    { DepartmentId = stockIn.DepartmentStockInPK.DepartmentId,
                                                      StockInId = stockInId + "" 
                                                    };
            stockIn.DepartmentStockInPK = stockInPk;
            

            IList productMasterIds = new ArrayList();
            IList productIds = new ArrayList();
            IList priceList = new ArrayList();
            IList quantityList = new ArrayList();

            if(stockIn.DepartmentStockInDetails== null || stockIn.DepartmentStockInDetails.Count == 0)
            {
                result.HasError = true;
                result.Messages = new ArrayList();
                result.Messages.Add("Stock-in do not have details ?!?!");
                return result;
            }
            try
            {
                DepartmentStockIn DepartmentStockIn = DepartmentStockInDAO.FindById(stockIn.DepartmentStockInPK);
                if (DepartmentStockIn == null)
                {
                    DepartmentStockInDAO.Add(stockIn);
                }
                else
                {
                    ObjectCriteria criteria = new ObjectCriteria();

                    // currently we do not accept update department-stock-in in
                    //return;
                    // amend for debug
                    return result;
                }
                // put master data first
                foreach (DepartmentStockInDetail detail in stockIn.DepartmentStockInDetails)
                {
                    detail.DepartmentStockInDetailPK.StockInId = stockInId;
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
                        /*ProductMaster.Country = detail.Product.ProductMaster.Country;
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

                        ProductMasterDAO.Update(ProductMaster);*/
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
                        /*Product.UpdateDate = detail.Product.UpdateDate;
                        Product.UpdateId = detail.Product.UpdateId;
                        Product.CreateDate = detail.Product.CreateDate;
                        Product.CreateId = detail.Product.CreateId;
                        Product.ProductMaster = detail.Product.ProductMaster;
                        Product.Quantity = detail.Product.Quantity;
                        Product.Price = detail.Product.Price;
                        ProductDAO.Update(Product);*/
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
                        /*DepartmentStockInDetail.UpdateDate = detail.UpdateDate;
                        DepartmentStockInDetail.UpdateId = detail.UpdateId;
                        DepartmentStockInDetail.CreateDate = detail.CreateDate;
                        DepartmentStockInDetail.CreateId = detail.CreateId;
                        DepartmentStockInDetail.Quantity = DepartmentStockInDetail.Quantity;
                        DepartmentStockInDetail.Price = DepartmentStockInDetail.Price;
                        DepartmentStockInDetailDAO.Update(DepartmentStockInDetail);*/
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
                            price = new DepartmentPrice
                            {
                                DepartmentPricePK = new DepartmentPricePK { DepartmentId = 0, ProductMasterId = productMasterId },
                                Price = (Int64)priceList[i],
                                CreateDate = DateTime.Now,
                                CreateId = ClientInfo.getInstance().LoggedUser.Name,
                                UpdateDate = DateTime.Now,
                                UpdateId = ClientInfo.getInstance().LoggedUser.Name
                            };
                            DepartmentPriceDAO.Add(price);
                        }
                        else
                        {
                            price.UpdateDate = DateTime.Now;
                            price.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                            DepartmentPriceDAO.Update(price);
                        }
                        i++;
                    }
                }

                if (productIds.Count > 0)
                {
                    var criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                    criteria.AddEqCriteria("DepartmentStockPK.DepartmentId", stockIn.DepartmentStockInPK.DepartmentId);
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
                                //stock.Quantity += (Int64)quantityList[i];
                                stock.GoodQuantity += (Int64)quantityList[i];
                                stock.Quantity += (Int64)quantityList[i];
                                break;
                            }
                        }
                        if (stock == null)
                        {
                            stock = new DepartmentStock
                            {
                                DepartmentStockPK = new DepartmentStockPK { DepartmentId = stockIn.DepartmentStockInPK.DepartmentId, ProductId = productId },
                                Quantity = (Int64)quantityList[i],
                                GoodQuantity = (Int64)quantityList[i],
                                CreateDate = DateTime.Now,
                                CreateId = ClientInfo.getInstance().LoggedUser.Name,
                                UpdateDate = DateTime.Now,
                                UpdateId = ClientInfo.getInstance().LoggedUser.Name
                            };
                            DepartmentStockDAO.Add(stock);
                        }
                        else
                        {
                            stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                            stock.UpdateDate = DateTime.Now;
                            DepartmentStockDAO.Update(stock);
                        }
                        i++;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Messages = new ArrayList();
                result.Messages.Add(ex.Message);
                return result;
            }
            
        }

        [Transaction(ReadOnly = false)]
        public void AddStockInBack(DepartmentStockIn data)
        {
            long deptId = data.DepartmentStockInPK.DepartmentId;
            string deptStr = "000";
            if (deptId > 9999)
            {
                deptStr = deptId.ToString();    
            }
            else
            {
                deptStr = string.Format("{0:000}", data.DepartmentStockInPK.DepartmentId);
            }
            string dateStr = data.StockInDate.ToString("yyMMdd");
            var criteria = new ObjectCriteria();
            string extraZero = "00000";
            if(deptId > 9999)
            {
                extraZero = "000";
            }
            criteria.AddGreaterCriteria("DepartmentStockInPK.StockInId", dateStr + deptStr + extraZero);
            var maxId = DepartmentStockInDAO.SelectSpecificType(criteria,
                                                                Projections.Max("DepartmentStockInPK.StockInId"));
            string startNum = "00001";
            if(deptId > 9999)
            {
                startNum = "001";
            }
            var stockInId = maxId == null
                                ? dateStr + deptStr + startNum
                                : string.Format("{0:00000000000000}", (Int64.Parse(maxId.ToString()) + 1));

            var stockInPk = new DepartmentStockInPK {DepartmentId = deptId, StockInId = stockInId + ""};

            data.DepartmentStockInPK = stockInPk;
            data.CreateDate = DateTime.Now;
            data.UpdateDate = DateTime.Now;
            data.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            data.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            DepartmentStockInDAO.Add(data);

            // we will get the stock to get the data
            IList productMasterIds = new ArrayList();
            IList productIds = new ArrayList();
            foreach (DepartmentStockInDetail stockInDetail in data.DepartmentStockInDetails)
            {
                productIds.Add(stockInDetail.Product.ProductId);
            }

            criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddSearchInCriteria("DepartmentStockPK.ProductId", productIds);
            criteria.AddOrder("Product.ProductId", true);
            IList stockList = DepartmentStockDAO.FindAll(criteria);

            IList updateStockList = new ArrayList();
            IList stockInDetailList = new ArrayList();
            foreach (DepartmentStockInDetail stockInDetail in data.DepartmentStockInDetails)
            {
                long quantity = stockInDetail.Quantity;
                DepartmentStockPK stockPk = new DepartmentStockPK
                                                {
                                                    DepartmentId = deptId,
                                                    ProductId = stockInDetail.Product.ProductId
                                                };
                DepartmentStock departmentStock = DepartmentStockDAO.FindById(stockPk);

                if (departmentStock.DepartmentStockPK.ProductId.Equals(stockInDetail.Product.ProductId))
                {
                        departmentStock.GoodQuantity += stockInDetail.Quantity;
                        departmentStock.Quantity += stockInDetail.Quantity;
                        departmentStock.UpdateDate = DateTime.Now;
                        departmentStock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        
                        DepartmentStockDAO.Update(departmentStock);

                        var pk = new DepartmentStockInDetailPK
                                     {
                                         DepartmentId = data.DepartmentStockInPK.DepartmentId,
                                         ProductId = departmentStock.Product.ProductId,
                                         StockInId = stockInId
                                     };
                        stockInDetail.DepartmentStockInDetailPK = pk;
                        DepartmentStockInDetailDAO.Add(stockInDetail);
                }
            }
        }

        [Transaction(ReadOnly = false)]
        public void SyncMasterData(SyncFromMainToDepartment syncFromMainToDepartment)
        {
            IList syncedColorList = new ArrayList();
            IList syncedSizeList = new ArrayList();
            IList syncedProductMasterList = new ArrayList();
            IList syncedProductList = new ArrayList();
            IList syncedProductTypeList = new ArrayList();
            IList syncedCountryList = new ArrayList();
            IList syncedDistributorList = new ArrayList();
            IList syncedManufacturerList = new ArrayList();
            IList syncedPackageList = new ArrayList();
            IList productMasterList = syncFromMainToDepartment.ProductMasterList;
            if(productMasterList!=null && productMasterList.Count > 0)
            {
                int i = 0;
                Stopwatch stopwatch = Stopwatch.StartNew();
                foreach (Product product in productMasterList)
                {
                    i++;
                    
                    if (product.ProductMaster.ProductColor != null)
                    {
                        if (NotInList(syncedColorList, product.ProductMaster.ProductColor.ColorName))
                        {
                            /*try
                            {*/
                            ProductColor color = ProductColorDAO.FindById(product.ProductMaster.ProductColor.ColorId);
                            if (color == null)
                            {
                                ProductColorDAO.Add(product.ProductMaster.ProductColor);
                            }
                            else
                            {
                                /*color.ColorName = product.ProductMaster.ProductColor.ColorName;
                                ProductColorDAO.Update(color);*/
                            }
                        }
                        syncedColorList.Add(product.ProductMaster.ProductColor.ColorName);
                        /*}
                        catch (Exception)
                        {
                            
                        }*/
                    }
                    if (product.ProductMaster.ProductSize != null)
                    {
                        if (NotInList(syncedSizeList, product.ProductMaster.ProductSize.SizeName))
                        {

                            /*try
                        {*/
                            ProductSize size = ProductSizeDAO.FindById(product.ProductMaster.ProductSize.SizeId);
                            if (size == null)
                            {
                                ProductSizeDAO.Add(product.ProductMaster.ProductSize);
                            }
                            else
                            {
                                /*size.SizeName = product.ProductMaster.ProductSize.SizeName;
                                ProductSizeDAO.Update(size);*/
                            }
                            syncedSizeList.Add(product.ProductMaster.ProductSize.SizeName);
                        }
                        /*catch
                        (Exception)
                        {

                        }
                    }*/
                }
                    
                        if (product.ProductMaster.ProductType != null)
                        {
                            if (NotInList(syncedSizeList, product.ProductMaster.ProductType.TypeName))
                            {

                                ProductType type = ProductTypeDAO.FindById(product.ProductMaster.ProductType.TypeId);
                                if (type == null)
                                {
                                    ProductTypeDAO.Add(product.ProductMaster.ProductType);
                                }
                                else
                                {
                                    /*type.TypeName = product.ProductMaster.ProductType.TypeName;
                                    ProductTypeDAO.Update(type);*/
                                }
                                syncedProductTypeList.Add(product.ProductMaster.ProductType.TypeName);
                            }
                        }
                        try
                        {
                        if (product.ProductMaster.Country != null)
                        {
                            Country Country = CountryDAO.FindById(product.ProductMaster.Country.CountryId);
                            if (Country == null)
                            {
                                CountryDAO.Add(product.ProductMaster.Country);
                            }

                        }
                        if (product.ProductMaster.Distributor != null)
                        {
                            Distributor Distributor =
                                DistributorDAO.FindById(product.ProductMaster.Distributor.DistributorId);
                            if (Distributor == null)
                            {
                                DistributorDAO.Add(product.ProductMaster.Distributor);
                            }

                        }
                        if (product.ProductMaster.Packager != null)
                        {

                            Packager Packager = PackagerDAO.FindById(product.ProductMaster.Packager.PackagerId);
                            if (Packager == null)
                            {
                                PackagerDAO.Add(product.ProductMaster.Packager);
                            }

                        }
                        if (product.ProductMaster.Manufacturer != null)
                        {

                            Manufacturer Manufacturer =
                                ManufacturerDAO.FindById(product.ProductMaster.Manufacturer.ManufacturerId);
                            if (Manufacturer == null)
                            {
                                ManufacturerDAO.Add(product.ProductMaster.Manufacturer);
                            }
                        }
                    }
                    catch(Exception)
                    {
                    }

                    /*try
                    {*/
                    if (NotInList(syncedProductMasterList, product.ProductMaster.ProductMasterId))
                    {
                        ProductMaster ProductMaster = ProductMasterDAO.FindById(product.ProductMaster.ProductMasterId);
                        //ProductMaster ProductMaster = GetProductMaster(product.ProductMaster, prdMasterUpdateList);
                        if (ProductMaster == null)
                        {
                            ProductMasterDAO.Add(product.ProductMaster);
                        }
                        else
                        {
                            if(   !ProductMaster.ProductName.Equals(product.ProductMaster.ProductName)
                               || (ProductMaster.ProductType!=null && !ProductMaster.ProductType.TypeName.Equals(product.ProductMaster.ProductType.TypeName))
                               || (!string.IsNullOrEmpty(ProductMaster.ImagePath) && !ProductMaster.ImagePath.Equals(product.ProductMaster.ImagePath))
                                )
                            {
                                ProductMaster.Country = product.ProductMaster.Country;
                                ProductMaster.Packager = product.ProductMaster.Packager;
                                ProductMaster.ProductColor = product.ProductMaster.ProductColor;
                                ProductMaster.ProductFullName = product.ProductMaster.ProductFullName;
                                ProductMaster.ProductName = product.ProductMaster.ProductName;
                                ProductMaster.ProductSize = product.ProductMaster.ProductSize;
                                ProductMaster.ProductType = product.ProductMaster.ProductType;
                                ProductMaster.UpdateDate = product.ProductMaster.UpdateDate;
                                ProductMaster.UpdateId = product.ProductMaster.UpdateId;
                                ProductMaster.CreateDate = product.ProductMaster.CreateDate;
                                ProductMaster.CreateId = product.ProductMaster.CreateId;
                                ProductMaster.Distributor = product.ProductMaster.Distributor;
                                ProductMaster.Manufacturer = product.ProductMaster.Manufacturer;
                                ProductMaster.ImagePath = product.ProductMaster.ImagePath;
                                ProductMaster.ExclusiveKey = product.ProductMaster.ExclusiveKey;
                                ProductMasterDAO.Update(ProductMaster);
                                
                            }
                            
                        }
                        syncedProductMasterList.Add(product.ProductMaster.ProductMasterId);
                    }
                    /*}
                    catch (Exception)
                    {
                    }*/

                    if (NotInList(syncedProductList, product.ProductId))
                    {
                        /*try
                        {*/
                        Product existProduct = ProductDAO.FindById(product.ProductId);
                        if (existProduct == null)
                        {
                            ProductDAO.Add(product);
                        }
                        else
                        {
                            /*existProduct.UpdateDate = product.UpdateDate;
                            existProduct.UpdateId = product.UpdateId;
                            existProduct.CreateDate = product.CreateDate;
                            existProduct.CreateId = product.CreateId;
                            existProduct.ProductMaster = product.ProductMaster;
                            existProduct.Quantity = product.Quantity;
                            existProduct.Price = product.Price;
                            ProductDAO.Update(existProduct);*/
                        }
                        syncedProductList.Add(product.ProductId);
                    }
                    /*}
                    catch (Exception)
                    {
                    }*/
                }
                stopwatch.Stop();
                Console.WriteLine("Number of seconds :" + (stopwatch.ElapsedMilliseconds/1000).ToString());
            }
            // update price
            IList syncDeptPriceList = new ArrayList();
            if(syncFromMainToDepartment.DepartmentPriceMasterList!= null)
            {
                foreach (DepartmentPrice departmentPrice in syncFromMainToDepartment.DepartmentPriceMasterList)
                {
                    if (NotInList(syncedProductMasterList, departmentPrice.DepartmentPricePK.ProductMasterId))
                    {
                        ProductMaster productMaster =
                            ProductMasterDAO.FindById(departmentPrice.DepartmentPricePK.ProductMasterId);
                        if(productMaster == null)
                        {
                            continue;
                        }
                    }

                    /*try
                    {*/
                    if (NotInList(syncDeptPriceList, departmentPrice.DepartmentPricePK.ProductMasterId))
                    {
                        DepartmentPrice existPrice = DepartmentPriceDAO.FindById(departmentPrice.DepartmentPricePK);
                        if (existPrice == null)
                        {
                            DepartmentPriceDAO.Add(departmentPrice);
                        }
                        else
                        {
                            if (existPrice.Price != departmentPrice.Price || existPrice.WholeSalePrice != departmentPrice.WholeSalePrice)
                            {
                                existPrice.Price = departmentPrice.Price;
                                existPrice.WholeSalePrice = departmentPrice.WholeSalePrice;
                                DepartmentPriceDAO.Update(existPrice);
                            }
                        }
                        syncDeptPriceList.Add(departmentPrice.DepartmentPricePK.ProductMasterId);
                    }
                    /*}
                    catch (Exception)
                    {
                    }*/
                }
            }
            // update common data
            if (syncFromMainToDepartment.DepartmentList != null)
            {
                foreach (Department department in syncFromMainToDepartment.DepartmentList)
                {
                    try
                    {
                        Department dept = DepartmentDAO.FindById(syncFromMainToDepartment.Department.DepartmentId);
                        if (dept == null)
                        {
                            DepartmentDAO.Add(department);
                        }
                        else
                        {
                            dept.Address = department.Address;
                            dept.DepartmentName = department.DepartmentName;
                            dept.ManagerId = department.ManagerId;
                            dept.StartDate = department.StartDate;
                            DepartmentDAO.Update(dept);
                        } 
                    }
                    catch (Exception)
                    {

                    }
                       
                }
            }
            if(syncFromMainToDepartment.EmployeeList!= null)
            {
               foreach (Employee employee in syncFromMainToDepartment.EmployeeList)
                {

                    try
                    {
                        Employee emp = EmployeeDAO.FindById(employee.EmployeePK);
                        if (emp == null)
                        {
                            EmployeeDAO.Add(employee);
                            if (employee.EmployeeInfo != null)
                            {
                                EmployeeDetailDAO.Add(employee.EmployeeInfo);
                            }
                        }
                        else
                        {
                            emp.DelFlg = employee.DelFlg;
                            EmployeeDAO.Update(emp);
                            if (employee.EmployeeInfo != null)
                            {
                                emp.EmployeeInfo.EmployeeName = employee.EmployeeInfo.EmployeeName;
                                emp.EmployeeInfo.Address = employee.EmployeeInfo.Address;
                                EmployeeDetailDAO.Update(employee.EmployeeInfo);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                } 
            }
            
        }

        // get product master if in list and get in database if new
        private ProductMaster GetProductMaster(ProductMaster productMaster, IList list)
        {
            ProductMaster foundMaster = null;
            foreach (ProductMaster master in list)
            {
                if(master.ProductMasterId.Equals(productMaster.ProductMasterId))
                {
                    foundMaster = master;
                    break;
                }
            }
            if(foundMaster== null)
            {
                foundMaster = ProductMasterDAO.FindById(productMaster.ProductMasterId);
                if(foundMaster!=null)
                {
                    list.Add(foundMaster);
                }
                else
                {
                    list.Add(productMaster);
                }
                return foundMaster;
            }
            else
            {
                return foundMaster;
            }
        }

        public IStockOutDAO StockOutDAO
        {
            get; set;
        }

        public IDepartmentStockOutDAO DepartmentStockOutDAO
        {
            get;
            set;
        }
        public IDepartmentStockOutDetailDAO DepartmentStockOutDetailDAO
        {
            get;
            set;
        }
        public IDepartmentStockTempDAO DepartmentStockTempDAO
        {
            get;
            set;
        }
        
        public ILoginDao LoginDAO { get; set; }
        public IRoleDao RoleDAO { get; set; }
        #endregion
    }
}