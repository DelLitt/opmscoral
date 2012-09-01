using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoralPOS.Models;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Utils
{
    public class StockInHelper
    {
        public static IList<Product> CreateProduct(ProductMaster productMaster, IList colorList, IList sizeList)
        {
            IList<Product> products = new List<Product>();
            // product id is formed by productmasterid-colorid-sizeid and month of input
            string productIdPart1 = string.Format("{0:000000}", Int64.Parse(productMaster.ProductMasterId));
            string month = "";
            int i = DateTime.Now.Month%12;
            switch (i)
            {
                case 10:
                    month = "A";
                    break;
                case 11:
                    month = "B";
                    break;
                case 12:
                    month = "C";
                    break;
                default:
                    month = (i) + "";
                    break;
            }
            //string productIdPart4 = month;
            string year = (DateTime.Now.Year - 2012) + "";
            string productIdPart4 = year + month;

            foreach (ExProductColor color in colorList)
            {
                string productIdPart2 = string.Format("{0:00}", color.ColorId);
                foreach (ExProductSize size in sizeList)
                {
                    string productIdPart3 = string.Format("{0:00}", size.SizeId);
                    string productId = productIdPart1 + productIdPart2 + productIdPart3 + productIdPart4;
                    Product newProduct = new Product
                                             {
                                                 ProductId = productId,
                                                 Barcode = productId,
                                                 ProductMaster = productMaster,
                                                 CreateDate = DateTime.Now,
                                                 UpdateDate = DateTime.Now,
                                                 CreateId = "admin",
                                                 UpdateId = "admin",
                                                 ProductColor = color,
                                                 ProductSize = size
                                             };
                    products.Add(newProduct);
                }
            }
            return products;
        }
        public static StockIn Create(Department department,IDictionary<Product,long> productList, string createId,DateTime createDate,string description,int stockInType = 1,int confirmFlag = 1)
        {
            CoralPOS.Models.StockIn stockIn = new CoralPOS.Models.StockIn
            {
                CreateDate = createDate,
                ConfirmFlg = confirmFlag,
                CreateId = createId,
                UpdateId = createId,
                UpdateDate = createDate,
                Description = description,
                ExclusiveKey = 0,
                DelFlg = 0,
                StockInDate = createDate,
                StockInDetails = new List<StockInDetail>(),
                StockInType = 3,

            };

            foreach (var tempValid in productList)
            {
                CoralPOS.Models.StockInDetail detail = new StockInDetail
                {
                    StockIn = stockIn,
                    CreateDate = createDate,
                    UpdateDate = createDate,
                    CreateId = createId,
                    UpdateId = createId,
                    DelFlg = 0,
                    ExclusiveKey = 0,
                    Quantity = tempValid.Value,
                    Product = tempValid.Key,
                    ProductMaster = tempValid.Key.ProductMaster,
                    StockInType = stockInType,

                };
                stockIn.StockInDetails.Add(detail);
            }
            return stockIn;
        }
    }
}
