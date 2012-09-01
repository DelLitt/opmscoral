using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoralPOS.Models;

namespace POSServer.Utils
{
    public class StockOutHelper
    {
        public static StockOut Create(Department department,IDictionary<Product,long> productList, string createId,DateTime createDate,StockDefinitionStatus definitionStatus,string description,int confirmFlag = 1)
        {
            CoralPOS.Models.StockOut stockOut = new CoralPOS.Models.StockOut
            {
                CreateDate = createDate,
                ConfirmFlg = confirmFlag,
                CreateId = createId,
                UpdateId = createId,
                UpdateDate = createDate,
                Description = description,
                Department = department,
                DefinitionStatus = definitionStatus,
                ExclusiveKey = 0,
                DelFlg = 0,
                StockOutDate = createDate,
                StockOutDetails = new List<StockOutDetail>(),

            };
            foreach (var stockInProduct in productList)
            {
                CoralPOS.Models.StockOutDetail detail = new StockOutDetail
                {
                    StockOut = stockOut,
                    CreateDate = createDate,
                    UpdateDate = createDate,
                    CreateId = createId,
                    UpdateId = createId,
                    Description = description,
                    DelFlg = 0,
                    ExclusiveKey = 0,
                    Quantity = stockInProduct.Value,
                    Product = stockInProduct.Key,
                    ProductMaster = stockInProduct.Key.ProductMaster,
                    GoodQuantity = stockInProduct.Value,
                    DefectStatusId = definitionStatus.DefectStatusId
                };
                stockOut.StockOutDetails.Add(detail);
            }
            return stockOut;
        }

        public static StockOut From(StockIn stockIn, Department department,StockDefinitionStatus definitionStatus, int confirmFlag = 0,string description ="")
        {
            IDictionary<Product,long> productList = new Dictionary<Product, long>();
            foreach (var detail in stockIn.StockInDetails)
            {
                productList.Add(detail.Product,detail.Quantity);
            }
            return Create(  department, 
                            productList, 
                            stockIn.CreateId, 
                            stockIn.CreateDate, 
                            definitionStatus,
                            description, 
                            0);
        }
    }
}
