using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using AppFrame.Model;
using AppFrame.DataLayer;
using NHibernate.Criterion;
using System;

namespace AppFrame.Logic
{
    public class BlockInDetailLogicImpl : IBlockInDetailLogic
    {
        private IBlockInDetailDAO _blockInDetailDAO;

        public IBlockInDetailDAO BlockInDetailDAO
        {
            get 
            { 
                return _blockInDetailDAO; 
            }
            set 
            { 
                _blockInDetailDAO = value; 
            }
        }

        public IProductDAO ProductDAO { get; set; }
        public IProductMasterDAO ProductMasterDAO { get; set; }
        public IStockInDetailDAO StockInDetailDAO { get; set; }
        public IStockInDAO StockInDAO { get; set; }
        
        /// <summary>
        /// Find BlockInDetail object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of BlockInDetail</param>
        /// <returns></returns>
        public BlockInDetail FindById(object id)
        {
            return BlockInDetailDAO.FindById(id);
        }
        
        /// <summary>
        /// Add BlockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public BlockInDetail Add(BlockInDetail data)
        {
            var pk = new BlockInDetailPK {BlockId = 1};
            var maxId = BlockInDetailDAO.SelectSpecificType(null, Projections.Max("BlockInDetailPK.BlockDetailId"));
            
            pk.BlockDetailId = maxId == null ? "1" : (Int64.Parse(maxId.ToString()) + 1).ToString();
            
            data.BlockInDetailPK = pk;

            var maxProduct = ProductDAO.SelectSpecificType(null, Projections.Max("ProductId"));
            Int64 maxProductId = 1;
            if (maxProduct != null)
            {
                maxProductId = (Int64)maxProduct + 1;
            }

            var maxStockInId = StockInDAO.SelectSpecificType(null, Projections.Max("StockInId"));
            if (maxStockInId == null)
            {
                maxStockInId = (long) 1;
            }
            else
            {
                maxStockInId = (long)maxStockInId + 1;
            }

            var stockIn = new StockIn {StockInDate = data.ImportDate};
            data.StockInId = (long)maxStockInId;

            BlockInDetailDAO.Add(data);
            StockInDAO.Add(stockIn);

            foreach (Product product in data.Products)
            {
                // TODO product.ProductId = maxProductId++;
                product.BlockInDetail = data;
                ProductDAO.Add(product);

                var stockInDetail = new StockInDetail
                                        {
                                            Product = product,
                                            ProductId = product.ProductId,
                                            StockIn = stockIn,
                                            Quantity = product.Quantity,
                                            Price = product.Price,
                                            StockInType = (Int64)StockInDetail.StockInStatus.IMPORTED,
                                            StockInDetailPK =
                                                new StockInDetailPK
                                                    {StockInId = stockIn.StockInId, ProductId = product.ProductId}
                                        };
                StockInDetailDAO.Add(stockInDetail);
            }

            return data;
        }
        
        /// <summary>
        /// Update BlockInDetail to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(BlockInDetail data)
        {
            // Update block
            BlockInDetailDAO.Update(data);

            // Update Stock In
            StockIn stockIn = null;
            if (data.StockInId != 0)
            {
                stockIn = StockInDAO.FindById(data.StockInId);
                if (stockIn != null)
                {
                    stockIn.StockInDate = data.ImportDate;
                    StockInDAO.Update(stockIn);
                }
            }

            // Get the max id of product
            var maxProduct = ProductDAO.SelectSpecificType(null, Projections.Max("ProductId"));
            Int64 maxProductId = 1;
            if (maxProduct != null) 
            {
                maxProductId = ((Int64)maxProduct) + 1;
            }

            foreach (Product product in data.Products) 
            {
                // Add new Product
                if (string.IsNullOrEmpty(product.ProductId))
                {
                    // TODO product.ProductId = maxProductId++;
                    ProductDAO.Add(product);
                    if (stockIn != null)
                    {
                        var stockInDetail = new StockInDetail
                        {
                            Product = product,
                            ProductId = product.ProductId,
                            StockIn = stockIn,
                            Quantity = product.Quantity,
                            Price = product.Price,
                            StockInDetailPK =
                                new StockInDetailPK { StockInId = stockIn.StockInId, ProductId = product.ProductId }
                        };
                        StockInDetailDAO.Add(stockInDetail);
                    }
                }
                // Update Product
                else {
                    ProductDAO.Update(product);
                    if (stockIn != null)
                    {
                        var stockInDetail = new StockInDetail
                        {
                            Product = product,
                            ProductId = product.ProductId,
                            StockIn = stockIn,
                            Quantity = product.Quantity,
                            Price = product.Price,
                            StockInDetailPK =
                                new StockInDetailPK { StockInId = stockIn.StockInId, ProductId = product.ProductId }
                        };
                        StockInDetailDAO.Update(stockInDetail);
                    }
                }
            }
        }
        
        /// <summary>
        /// Delete BlockInDetail from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(BlockInDetail data)
        {
            BlockInDetailDAO.Delete(data);
        }

        /// <summary>
        /// Delete a list of BlockInDetail from database.
        /// </summary>
        /// <param name="deleteList"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteList(IList<BlockInDetail> deleteList)
        {
            foreach (var blockInDetail in deleteList)
            {
                // Delete Block
                blockInDetail.DelFlg = 1;
                BlockInDetailDAO.Update(blockInDetail);

                // Delete Stock In
                StockIn stockIn = null;
                if (blockInDetail.StockInId != 0)
                {
                    stockIn = StockInDAO.FindById(blockInDetail.StockInId);
                    if (stockIn != null)
                    {
                        stockIn.DelFlg = 1;
                        StockInDAO.Update(stockIn);
                    }
                }

                foreach (Product product in blockInDetail.Products)
                {
                    product.DelFlg = 1;
                    ProductDAO.Update(product);
                    if (stockIn != null)
                    {
                        var stockInDetail = new StockInDetail
                                                {
                                                    Product = product,
                                                    StockIn = stockIn,
                                                    DelFlg = 1,
                                                    StockInDetailPK =
                                                        new StockInDetailPK
                                                            {
                                                                StockInId = stockIn.StockInId,
                                                                ProductId = product.ProductId
                                                            }
                                                };
                        StockInDetailDAO.Update(stockInDetail);
                    }
                }
            }
        }

        /// <summary>
        /// Delete BlockInDetail from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            BlockInDetailDAO.DeleteById(id);
        }
        
        /// <summary>
        /// Find all BlockInDetail from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList FindAll(ObjectCriteria criteria)
        {
            return BlockInDetailDAO.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all BlockInDetail from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria criteria)
        {
            return BlockInDetailDAO.FindPaging(criteria);
        }
    }
}