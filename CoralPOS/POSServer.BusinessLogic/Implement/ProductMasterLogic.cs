			 


using System;
using System.Collections;
using System.Collections.Generic;
using AppFrame.Base;
using NHibernate.Criterion;
using POSServer.BusinessLogic.Common;
using Spring.Transaction.Interceptor;
using  CoralPOS.Models;
using  POSServer.DataLayer.Implement;
using AppFrame.DataLayer;

namespace POSServer.BusinessLogic.Implement
{
    public class ProductMasterLogic : IProductMasterLogic
    {
        private IProductMasterDao _innerDao;
        public IProductMasterDao ProductMasterDao
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

        public IProductTypeDao ProductTypeDao { get; set; }
        public ICategoryDao CategoryDao { get; set; }
        public IExProductColorDao ProductColorDao { get; set; }
        public IExProductSizeDao ProductSizeDao { get; set; }
        public IProductDao ProductDao { get; set; }
        /// <summary>
        /// Find ProductMaster object by id. Return null if nothing is found
        /// </summary>
        /// <param name="id">Id of ProductMaster</param>
        /// <returns></returns>
        public ProductMaster FindById(object id)
        {
            return ProductMasterDao.FindById(id);
        }
        
        /// <summary>
        /// Add ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public ProductMaster Add(ProductMaster data)
        {
            ProductMasterDao.Add(data);
            return data;
        }
        
        /// <summary>
        /// Update ProductMaster to database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Update(ProductMaster data)
        {
            ProductMasterDao.Update(data);
        }
        
        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void Delete(ProductMaster data)
        {
            ProductMasterDao.Delete(data);
        }
        
        /// <summary>
        /// Delete ProductMaster from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly=false)]
        public void DeleteById(object id)
        {
            ProductMasterDao.DeleteById(id);
        }
        
        /// <summary>
        /// Find all ProductMaster from database. No pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<ProductMaster> FindAll(ObjectCriteria<ProductMaster> criteria)
        {
            return ProductMasterDao.FindAll(criteria);
        }
        
        /// <summary>
        /// Find all ProductMaster from database. Has pagination.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public QueryResult FindPaging(ObjectCriteria<ProductMaster> criteria)
        {
            return ProductMasterDao.FindPaging(criteria);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public void PreloadDefinition(IFlowSession session)
        {
            IList<Category> categories = CategoryDao.FindAll(new ObjectCriteria<Category>());
            session.Put(FlowConstants.CATEGORY_LIST,categories);
            IList<ProductType> productTypes = ProductTypeDao.FindAll(new ObjectCriteria<ProductType>());
            session.Put(FlowConstants.PRODUCT_TYPE_LIST,productTypes);
            IList<ExProductColor> productColors = ProductColorDao.FindAll(new ObjectCriteria<ExProductColor>());
            session.Put(FlowConstants.PRODUCT_COLOR_LIST, productColors);
            IList<ExProductSize> productSizes = ProductSizeDao.FindAll(new ObjectCriteria<ExProductSize>());
            session.Put(FlowConstants.PRODUCT_SIZE_LIST, productSizes);

        }

        [Transaction()]
        public bool Save(ProductMaster master, IList colors, IList sizes)
        {
            var maxIdResult = ProductMasterDao.SelectSpecificType(null, Projections.Max("ProductMasterId"));
            long maxProductMasterId = maxIdResult != null ? Int64.Parse(maxIdResult.ToString()) + 1 : 1;

            string productMasterId = string.Format("{0:0000000000000}", maxProductMasterId);
            master.ProductMasterId = productMasterId;

            ProductMasterDao.Add(master);
            // product id is formed by productmasterid-colorid-sizeid and month of input
            string productIdPart1 = string.Format("{0:0000000}", maxProductMasterId);
            string month = "";
            int i = DateTime.Now.Month % 12;
            switch (i)
            {
                case 10: month = "A";
                    break;
                case 11: month = "B";
                    break;
                case 12: month = "C";
                    break;
                default: month = (i) + "";
                    break;
            }
            string productIdPart4 = month;
            foreach (ExProductColor color in colors)
            {
                string productIdPart2 = string.Format("{0:00}", color.ColorId);
                foreach (ExProductSize size in sizes)
                {
                    string productIdPart3 = string.Format("{0:00}", size.SizeId);

                    string productId = productIdPart1 + productIdPart2 + productIdPart3 + productIdPart4;
                    Product existProduct = ProductDao.FindById(productId);
                    if(existProduct == null)
                    {
                        Product newProduct = new Product
                                                 {
                                                     ProductId = productId,
                                                     Barcode = productId,
                                                     ProductMaster = master,
                                                     ProductMasterId = productMasterId,
                                                     CreateDate = DateTime.Now,
                                                     UpdateDate = DateTime.Now,
                                                     CreateId = "admin",
                                                     UpdateId = "admin",
                                                     ProductColor = color,
                                                     ProductSize = size
                                                 };

                        ProductDao.Add(newProduct);
                    }
                }
            }
            return true;
        }

        public IList LoadAllProductMasterWIthType()
        {
            return ProductMasterDao.FindProductMasterWithTypes();
        }
    }
}