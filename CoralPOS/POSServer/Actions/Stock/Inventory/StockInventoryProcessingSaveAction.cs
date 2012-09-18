using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Utils;

namespace POSServer.Actions.Stock.Inventory
{
    [PerRequest]
    public class StockInventoryProcessingSaveAction : DefaultPosAction
    {
        [Autowired]
        public IDepartmentLogic DepartmentLogic { get; set; }
        [Autowired]
        public IStockOutLogic StockOutLogic { get; set; }
        [Autowired]
        public IStockInLogic StockInLogic { get; set; }
        [Autowired]
        public IDepartmentStockTempValidLogic DepartmentStockTempValidLogic { get; set; }
        [Autowired]
        public IMainPriceLogic MainPriceLogic { get; set; }
        [Autowired]
        public IStockDefinitionStatusLogic StockDefinitionStatusLogic { get; set; }
        
        public void DoExecute()
        {
            DoExecuteAsync(ProcessInventoryChecking,null);
        }

        private object ProcessInventoryChecking()
        {
            DepartmentInventoryChecking checking = (DepartmentInventoryChecking)Flow.Session.Get(FlowConstants.TEMP_VALID_SELECTED_CHECKING);
            CreateStockOut(checking);
            CreateStockIn(checking);
            DepartmentStockTempValidLogic.SaveInventoryChecking(checking);
            return null;
        }

        private void CreateStockIn(DepartmentInventoryChecking checking)
        {
            IDictionary<Product, long> productList =
                (IDictionary<Product, long>) Flow.Session.Get(FlowConstants.TEMP_VALID_SELECTED_STOCK_IN_LIST);
            if (productList.Count == 0) return;
            int stockInType = 3; // 3: STOCK IN FOR COMPENSATE IN CHECKING
            Department mainStock = DepartmentLogic.FindById(0);
            CoralPOS.Models.StockIn stockIn = StockInHelper.Create(
                                    mainStock,
                                    productList,
                                    "processChecking",
                                    DateTime.Now,
                                    "Stock in for unexist items in stock",
                                    stockInType,
                                    0);
            // populate the price for stock in
            PopulatePrice(stockIn);
            // save stock in
            StockInLogic.Add(stockIn);
            // create stock out from stock in
            if (checking.Department.DepartmentId > 0)
            {
                StockDefinitionStatus definitionStatus = StockDefinitionStatusLogic.FindById(DefinitionStatus.DESTROY_LOST_AND_DAMAGE);
                CoralPOS.Models.StockOut stockOut = StockOutHelper.From(stockIn, checking.Department, definitionStatus, 0, "Stock out from " + stockIn.Description);
                StockOutLogic.Add(stockOut);
            }
        }

        private void PopulatePrice(CoralPOS.Models.StockIn stockIn)
        {
            foreach (var detail in stockIn.StockInDetails)
            {
                MainPricePK pk = new MainPricePK
                {
                    DepartmentId = 0,
                    ProductMasterId = detail.Product.ProductMaster.ProductMasterId
                };
                detail.MainPrice = MainPriceLogic.FindById(pk);
            }
        }

        private void CreateStockOut(DepartmentInventoryChecking checking)
        {
            IDictionary<Product, long> productExportList =
                (IDictionary<Product, long>)Flow.Session.Get(FlowConstants.TEMP_VALID_SELECTED_STOCK_OUT_LIST);
            if (productExportList.Count == 0) return;
            if (checking.Department.DepartmentId > 0) // department id > 0 
            {
                // write instructions for department do stock out automatically

            }
            else
            {
                StockDefinitionStatus definitionStatus = StockDefinitionStatusLogic.FindById(DefinitionStatus.DESTROY_LOST_AND_DAMAGE);
                string description = "Stock out from extra products in stock";
                CoralPOS.Models.StockOut stockOut = StockOutHelper.Create(
                                                            checking.Department,
                                                            productExportList,
                                                            "processChecking",
                                                            DateTime.Now,
                                                            definitionStatus,
                                                            description,
                                                            0);

                StockOutLogic.Add(stockOut);
            }
        }
    }
}
