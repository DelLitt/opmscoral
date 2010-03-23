using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoralPOS.Models;

namespace POSServer.Utils
{
    public class StockInHelper
    {
        public static IList<Product> CreateProduct(ProductMaster productMaster, IList colorList, IList sizeList)
        {
            IList<Product> products = new List<Product>();
            // product id is formed by productmasterid-colorid-sizeid and month of input
            string productIdPart1 = string.Format("{0:0000000}", Int64.Parse(productMaster.ProductMasterId));
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
            string productIdPart4 = month;
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
                                                 ProductMasterId = productMaster.ProductMasterId,
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
    }
}
