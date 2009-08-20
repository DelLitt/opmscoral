using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Utility;

namespace AppFrameClient.Presenter.GoodsIO.DepartmentStockData
{
    public class DepartmentStockInExtraController : DepartmentStockInController, IDepartmentStockInExtraController
    {
        
                #region IDepartmentStockInExtraController Members

                private IDepartmentStockInExtraView departmentStockInExtraView;
                public AppFrame.View.GoodsIO.DepartmentGoodsIO.IDepartmentStockInExtraView DepartmentStockInExtraView
                {
                    get
                    {
                        return departmentStockInExtraView;
                    }
                    set
                    {
                        departmentStockInExtraView = value;

                        departmentStockInExtraView.FillProductToComboEvent +=
                                    new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_FillProductToComboEvent);
                        departmentStockInExtraView.LoadGoodsByIdEvent +=
                                    new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_LoadGoodsByIdEvent);
                        departmentStockInExtraView.LoadGoodsByNameEvent +=
                                    new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_LoadGoodsByNameEvent);

                        departmentStockInExtraView.LoadProductColorEvent += new EventHandler<DepartmentStockInEventArgs>(departmentStockInExtraView_LoadProductColorEvent);
                        departmentStockInExtraView.LoadProductSizeEvent += new EventHandler<DepartmentStockInEventArgs>(departmentStockInExtraView_LoadProductSizeEvent);
                        departmentStockInExtraView.LoadGoodsByNameColorEvent +=
                            new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_LoadGoodsByNameAndColorEvent);
                        departmentStockInExtraView.LoadGoodsByNameColorSizeEvent +=
                    new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_LoadGoodsByNameColorSizeEvent);
                        departmentStockInExtraView.FillDepartmentEvent +=
                                    new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_FillDepartmentEvent);
                        departmentStockInExtraView.LoadPriceAndStockEvent +=
                                    new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_LoadPriceAndStockEvent);
                        departmentStockInExtraView.LoadDepartmentStockInForExportEvent +=
                                    new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_LoadDepartemntStockInForExportEvent);
                        departmentStockInExtraView.UpdateDepartmentStockInForExportEvent +=
                                    new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_UpdateDepartemntStockInForExportEvent);
                        departmentStockInExtraView.FindByStockInIdEvent += new EventHandler<DepartmentStockInEventArgs>(departmentStockInExtraView_FindByStockInIdEvent);
                        departmentStockInExtraView.LoadMasterDataForExportEvent += new EventHandler<DepartmentStockInEventArgs>(departmentStockInExtraView_LoadMasterDataForExportEvent);
                        departmentStockInExtraView.SyncExportedMasterDataEvent += new EventHandler<DepartmentStockInEventArgs>(departmentStockInExtraView_SyncExportedMasterDataEvent);
                        departmentStockInExtraView.LoadStockInByProductMaster += new EventHandler<DepartmentStockInEventArgs>(departmentStockInExtraView_LoadStockInByProductMaster);
                    }
                }

                void departmentStockInExtraView_LoadStockInByProductMaster(object sender, DepartmentStockInEventArgs e)
                {
                    ObjectCriteria prdMasterCrit = new ObjectCriteria();
                    IList prdNames = new ArrayList();
                    foreach (ProductMaster list in e.ProductMasterList)
                    {
                        prdNames.Add(list.ProductName);
                    }
                    prdMasterCrit.AddSearchInCriteria("ProductName", prdNames);
                    prdMasterCrit.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                    IList prdMasterList = ProductMasterLogic.FindAll(prdMasterCrit);

                    if (prdMasterList != null && prdMasterList.Count > 0)
                    {
                        IList prdMstIds = new ArrayList();
                        foreach (ProductMaster master in prdMasterList)
                        {
                            prdMstIds.Add(master.ProductMasterId);
                        }
                        IList stockOutList = new ArrayList();
                        ObjectCriteria stkCriteria = new ObjectCriteria();
                        stkCriteria.AddSearchInCriteria("ProductMaster.ProductMasterId", prdMstIds);
                        stkCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        //stkCriteria.AddGreaterCriteria("GoodQuantity", (long)0);
                        IList stockList = StockLogic.FindAll(stkCriteria);
                        foreach (Stock inDetail in stockList)
                        {
                            DepartmentStockInDetail deptDetail = new DepartmentStockInDetail();
                            deptDetail.CreateDate = DateTime.Now;
                            deptDetail.UpdateDate = DateTime.Now;
                            deptDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                            deptDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                            deptDetail.DepartmentStockInDetailPK = new DepartmentStockInDetailPK();
                            deptDetail.Product = inDetail.Product;
                            deptDetail.ProductMaster = inDetail.Product.ProductMaster;
                            deptDetail.Quantity = inDetail.Quantity;
                            stockOutList.Add(deptDetail);
                        }
                        GetRemainStockNumber(stockOutList);
                        MinusConfirmStockOut(stockOutList);
                        e.SelectedStockOutDetails = stockOutList;
                    }
                }

        private void MinusConfirmStockOut(IList stockOutList)
        {
            foreach (DepartmentStockInDetail outDetail in stockOutList)
            {
                long confirmingQty = StockOutDetailLogic.FindConfirmingQuantity(outDetail.Product);
                outDetail.StockQuantity -= confirmingQty;
            } 
        }

        void departmentStockInExtraView_SyncExportedMasterDataEvent(object sender, DepartmentStockInEventArgs e)
                {
                    try
                    {
                        var syncFromMainToDepartment = e.SyncFromMainToDepartment;
                        DepartmentStockInLogic.SyncMasterData(syncFromMainToDepartment);
                        ClientUtility.Log(logger, syncFromMainToDepartment.ToString(), "Đồng bộ từ cửa hàng về kho");
                        e.EventResult = "Success";
                    }
                    catch (Exception exception)
                    {
                        e.EventResult = null;
                    }
                }

                void departmentStockInExtraView_LoadMasterDataForExportEvent(object sender, DepartmentStockInEventArgs e)
                {
                    e.SyncFromMainToDepartment = new SyncFromMainToDepartment();
                    if (e.SyncProductMasters)
                    {
                        ObjectCriteria prdCrit = new ObjectCriteria();
                        prdCrit.AddGreaterOrEqualsCriteria("UpdateDate", e.LastSyncTime);
                        IList masterProductList1 = ProductLogic.FindAll(prdCrit);

                        SubObjectCriteria subCrit = new SubObjectCriteria("ProductMaster");
                        subCrit.AddGreaterOrEqualsCriteria("UpdateDate", e.LastSyncTime);
                        prdCrit = new ObjectCriteria();
                        prdCrit.AddSubCriteria("ProductMaster", subCrit);
                        IList masterProductList2 = ProductLogic.FindAll(prdCrit);
                        IList masterProductList = new ArrayList();

                        if (masterProductList1 != null)
                        {
                            foreach (Product product in masterProductList1)
                            {
                                masterProductList.Add(product);
                            }
                        }
                        if (masterProductList2 != null)
                        {
                            foreach (Product product in masterProductList2)
                            {
                                if (!ExistInList(masterProductList, product))
                                {
                                    masterProductList.Add(product);
                                }
                            }
                        }
                        e.SyncFromMainToDepartment.ProductMasterList = masterProductList;
                        e.HasMasterDataToSync = true;
                    }
                    if (e.SyncPrice)
                    {
                        ObjectCriteria deptPriceCrit = new ObjectCriteria();
                        deptPriceCrit.AddGreaterOrEqualsCriteria("UpdateDate", e.LastSyncTime);

                        IList masterDeptPriceList = DepartmentPriceLogic.FindAll(deptPriceCrit);
                        e.SyncFromMainToDepartment.DepartmentPriceMasterList = masterDeptPriceList;
                        e.HasMasterDataToSync = true;
                    }
                    if (e.SyncDepartments)
                    {
                        e.SyncFromMainToDepartment.DepartmentList = DepartmentLogic.FindAll(null);
                        e.SyncFromMainToDepartment.EmployeeList = EmployeeLogic.FindAll(null);
                        e.HasMasterDataToSync = true;
                    }
                }

        private bool ExistInList(IList list, Product product)
        {
            foreach (Product product1 in list)
            {
                if(product1.ProductId.Equals(product.ProductId))
                {
                    return true;
                }
            }
            return false;
        }

        public  void departmentStockInExtraView_FindByStockInIdEvent(object sender, DepartmentStockInEventArgs e)
        {
            if (e.SelectedStockInIds.Count > 0)
            {
                ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddSearchInCriteria("StockInDetailPK.StockInId", e.SelectedStockInIds);
                IList list = StockInDetailLogic.FindAll(objectCriteria);
                IList stockOutList = new ArrayList();
                foreach (StockInDetail inDetail in list)
                {
                    DepartmentStockInDetail deptDetail = new DepartmentStockInDetail();
                    deptDetail.CreateDate = DateTime.Now;
                    deptDetail.UpdateDate = DateTime.Now;
                    deptDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    deptDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    deptDetail.DepartmentStockInDetailPK = new DepartmentStockInDetailPK();
                    deptDetail.Product = inDetail.Product;
                    deptDetail.ProductMaster = inDetail.Product.ProductMaster;
                    deptDetail.Quantity = inDetail.Quantity;
                    stockOutList.Add(deptDetail);
                }
                GetRemainStockNumber(stockOutList);
                MinusConfirmStockOut(stockOutList);
                e.SelectedStockOutDetails = stockOutList;
            }
            EventUtility.fireEvent(CompletedFindByStockInEvent,this,e);
        }

        public void _departmentStockInView_UpdateDepartemntStockInForExportEvent(object sender, DepartmentStockInEventArgs e)
        {
            e.DepartmentStockIn.ExportStatus = CommonConstants.DEL_FLG_YES;
            e.DepartmentStockIn.UpdateDate = DateTime.Now;
            e.DepartmentStockIn.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            DepartmentStockInLogic.UpdateExportStatus(e.DepartmentStockIn);
        }

        public void _departmentStockInView_LoadDepartemntStockInForExportEvent(object sender, DepartmentStockInEventArgs e)
        {
            DateTime lastSyncTime = e.LastSyncTime;
            e.SyncFromMainToDepartment = new SyncFromMainToDepartment();
            var stockTempCri = new ObjectCriteria();
            stockTempCri.AddEqCriteria("Fixed", CommonConstants.DEL_FLG_YES);
            stockTempCri.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);

            IList processedStockTemps = DepartmentStockTempLogic.FindAll(stockTempCri);
            e.SyncFromMainToDepartment.DepartmentStockTemps = processedStockTemps;
            
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddEqCriteria("DepartmentId", e.Department.DepartmentId);
            criteria.AddGreaterOrEqualsCriteria("CreateDate", lastSyncTime);
            
            e.SyncFromMainToDepartment.StockOutList = StockOutLogic.FindAll(criteria);
            e.SyncFromMainToDepartment.Department = e.Department;
            criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            //criteria.AddEqCriteria("EmployeePK.DepartmentId", e.Department.DepartmentId);
            e.SyncFromMainToDepartment.Department.Employees = EmployeeLogic.FindAll(criteria);
            //foreach (DepartmentStockIn departmentStockIn in e.DepartmentStockInList)
            if (e.SyncFromMainToDepartment.StockOutList == null || e.SyncFromMainToDepartment.StockOutList.Count == 0)
            {
                return; // don't need to get detail
            }
            foreach (StockOut departmentStockIn in e.SyncFromMainToDepartment.StockOutList)
            {

                foreach (StockOutDetail detail in departmentStockIn.StockOutDetails)
                {
                    DepartmentPrice price =
                        DepartmentPriceLogic.FindById(new DepartmentPricePK
                                                          {
                                                              DepartmentId = 0,
                                                              ProductMasterId =
                                                                  detail.Product.ProductMaster.ProductMasterId
                                                          });
                    if (price != null)
                    {
                        detail.Price = price.Price;
                        
                    }
                }
            }
            
        }

        void _departmentStockInView_LoadPriceAndStockEvent(object sender, DepartmentStockInEventArgs e)
        {
            GetRemainStockNumber(e.DepartmentStockInDetailList);
        }

        void _departmentStockInView_FillDepartmentEvent(object sender, DepartmentStockInEventArgs e)
                {
                    var criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                    e.DepartmentList = DepartmentLogic.FindAll(criteria);
                }

                void departmentStockInExtraView_LoadProductSizeEvent(object sender, DepartmentStockInEventArgs e)
                {
                    if (e.SelectedDepartmentStockInDetail != null && e.SelectedDepartmentStockInDetail.Product != null && !string.IsNullOrEmpty(e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductName))
                    {
                        var subCriteria = new SubObjectCriteria("ProductMasters");
                        subCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        subCriteria.AddEqCriteria("ProductType", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductType);
                        subCriteria.AddEqCriteria("ProductName", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductName);
                        subCriteria.AddEqCriteria("ProductColor", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductColor);
                        subCriteria.AddEqCriteria("Country", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Country);
                        subCriteria.AddEqCriteria("Manufacturer", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Manufacturer);
                        subCriteria.AddEqCriteria("Distributor", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Distributor);
                        subCriteria.AddEqCriteria("Packager", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Packager);
                        var criteria = new ObjectCriteria();
                        criteria.AddSubCriteria("ProductMasters", subCriteria);
                        IList productSizes = ProductSizeLogic.FindAll(criteria);
                        e.ProductSizeList = productSizes;
                    }
                }

                void departmentStockInExtraView_LoadProductColorEvent(object sender, DepartmentStockInEventArgs e)
                {
                    if (e.SelectedDepartmentStockInDetail != null && e.SelectedDepartmentStockInDetail.Product != null
                        && !string.IsNullOrEmpty(e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductName))
                    {
                        var subCriteria = new SubObjectCriteria("ProductMasters");
                        subCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                        subCriteria.AddEqCriteria("ProductType", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductType);
                        subCriteria.AddEqCriteria("ProductName", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductName);
                        subCriteria.AddEqCriteria("ProductSize", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductSize);
                        subCriteria.AddEqCriteria("Country", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Country);
                        subCriteria.AddEqCriteria("Manufacturer", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Manufacturer);
                        subCriteria.AddEqCriteria("Distributor", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Distributor);
                        subCriteria.AddEqCriteria("Packager", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Packager);
                        var criteria = new ObjectCriteria();
                        criteria.AddSubCriteria("ProductMasters",subCriteria);
                        IList productColors = ProductColorLogic.FindAll(criteria);
                        e.ProductColorList = productColors;
                    }
                }

                void _departmentStockInView_LoadGoodsByNameEvent(object sender, DepartmentStockInEventArgs e)
                    {
                    DepartmentStockInDetail detail = e.SelectedDepartmentStockInDetail;
                    ObjectCriteria objectCriteria = new ObjectCriteria();
                    objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                    objectCriteria.AddEqCriteria("ProductName", detail.Product.ProductMaster.ProductName);            
                    IList list  = ProductMasterLogic.FindAll(objectCriteria);
                    e.FoundProductMasterList = list;
                    if (list == null || list.Count == 0)
                    {
                        return;
                    }
                    ProductMaster prodMaster = list[0] as ProductMaster;
                    detail.Product.ProductMaster = prodMaster;
                    e.SelectedDepartmentStockInDetail = detail;
                    IList detailList = new ArrayList();
                    detailList.Add(detail);
                    GetRemainStockNumber(detailList);
                    }

                void _departmentStockInView_LoadGoodsByNameAndColorEvent(object sender, DepartmentStockInEventArgs e)
                {
                    DepartmentStockInDetail detail = e.SelectedDepartmentStockInDetail;
                    ObjectCriteria objectCriteria = new ObjectCriteria();
                    objectCriteria.AddEqCriteria("ProductName", detail.Product.ProductMaster.ProductName);
                    objectCriteria.AddEqCriteria("ProductType", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductType);
                    objectCriteria.AddEqCriteria("Country", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Country);
                    objectCriteria.AddEqCriteria("Manufacturer", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Manufacturer);
                    objectCriteria.AddEqCriteria("Distributor", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Distributor);
                    objectCriteria.AddEqCriteria("Packager", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Packager);
                    objectCriteria.AddEqCriteria("ProductColor", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductColor);
                    IList list = ProductMasterLogic.FindAll(objectCriteria);
                    if (list == null || list.Count == 0)
                    {
                        return;
                    }
                    ProductMaster prodMaster = list[0] as ProductMaster;
                    detail.Product.ProductMaster = prodMaster;
                    e.SelectedDepartmentStockInDetail = detail;
                    departmentStockInExtraView_LoadProductSizeEvent(sender, e);
                    IList detailList = new ArrayList();
                    detailList.Add(detail);
                    GetRemainStockNumber(detailList);
                }

                void _departmentStockInView_LoadGoodsByNameColorSizeEvent(object sender, DepartmentStockInEventArgs e)
                {
                    DepartmentStockInDetail detail = e.SelectedDepartmentStockInDetail;
                    ObjectCriteria objectCriteria = new ObjectCriteria();
                    objectCriteria.AddEqCriteria("ProductName", detail.Product.ProductMaster.ProductName);
                    objectCriteria.AddEqCriteria("ProductType", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductType);
                    objectCriteria.AddEqCriteria("Country", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Country);
                    objectCriteria.AddEqCriteria("Manufacturer", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Manufacturer);
                    objectCriteria.AddEqCriteria("Distributor", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Distributor);
                    objectCriteria.AddEqCriteria("Packager", e.SelectedDepartmentStockInDetail.Product.ProductMaster.Packager);
                    objectCriteria.AddEqCriteria("ProductColor", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductColor);
                    objectCriteria.AddEqCriteria("ProductSize", e.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductSize);
                    IList list = ProductMasterLogic.FindAll(objectCriteria);
                    if (list == null || list.Count == 0)
                    {
                        return;
                    }
                    ProductMaster prodMaster = list[0] as ProductMaster;
                    detail.Product.ProductMaster = prodMaster;
                    e.SelectedDepartmentStockInDetail = detail;
                    IList detailList = new ArrayList();
                    detailList.Add(detail);
                    GetRemainStockNumber(detailList);
                }


                void _departmentStockInView_LoadGoodsByIdEvent(object sender, DepartmentStockInEventArgs e)
                {
                    DepartmentStockInDetail detail = e.SelectedDepartmentStockInDetail;
                    ProductMaster prodMaster = ProductMasterLogic.FindById(detail.Product.ProductMaster.ProductMasterId);
                    if (prodMaster == null)
                    {
                        return;
                    }
                    detail.Product.ProductMaster = prodMaster;

                    e.SelectedDepartmentStockInDetail = detail;
                    IList detailList = new ArrayList();
                    detailList.Add(detail);
                    GetRemainStockNumber(detailList);
                }

                void _departmentStockInView_FillProductToComboEvent(object sender, DepartmentStockInEventArgs e)
                {
                    ComboBox comboBox = (ComboBox) sender;
                    string originalText = comboBox.Text;
                    if (e.IsFillToComboBox)
                    {
                        ProductMaster searchPM = e.SelectedDepartmentStockInDetail.Product.ProductMaster;
                        var subCrit = new SubObjectCriteria("ProductMaster");
                        subCrit.AddLikeCriteria("ProductName", "%" + searchPM.ProductName + "%");
                        subCrit.AddOrder("ProductName", true);

                        var criteria = new ObjectCriteria(true);
                        /*criteria.AddEqCriteria("pm.DelFlg", CommonConstants.DEL_FLG_NO);
                        criteria.AddEqCriteria("stock.DelFlg", CommonConstants.DEL_FLG_NO);
                        criteria.AddLikeCriteria("pm.ProductName", "%" + searchPM.ProductName + "%");*/
                        criteria.AddSubCriteria("ProductMaster", subCrit);
                        criteria.MaxResult = 200;
                        /*IList list = StockLogic.FindByQueryForStockIn(criteria);*/
                        IList list = StockLogic.FindAll(criteria);
//                        if (e.ComboBoxDisplayMember.Equals("ProductMasterId"))
//                        {
//                            result = ProductMasterLogic.FindProductMasterById(searchPM.ProductMasterId, 50,true);
//                        }
//                        else
//                        {
//                            result = ProductMasterLogic.FindProductMasterByName(searchPM.ProductName, 50,true);
//                        }

                        if(list ==null || list.Count == 0)
                        {
                            return;
                        }
                        IList result = new ArrayList();
                        foreach (Stock stock in list)
                        {
                            result.Add(stock.ProductMaster);
                        }
                        IList retlist = RemoveDuplicateName(result);

                        result = new ArrayList();
                        int count = 0;
                        foreach (var p in retlist)
                        {
                            result.Add(p);
                            count++;
                        }

                        BindingList<ProductMaster> productMasters = new BindingList<ProductMaster>();
                        if (result != null)
                        {
                            foreach (ProductMaster master in result)
                            {
                                productMasters.Add(master);
                            }
                        }
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = productMasters;
                        comboBox.DataSource = bindingSource;
                        comboBox.DisplayMember = "TypeAndName";
                        comboBox.ValueMember = e.ComboBoxDisplayMember;
                        comboBox.DropDownWidth = 300;
                        comboBox.DropDownHeight = 200;
                        // keep the original text
                        comboBox.Text = originalText;
                        //comboBox.SelectedIndex = -1;
                        //comboBox.SelectionStart = comboBox.Text.Length;
                        //comboBox.DroppedDown = true;
                        comboBox.MaxDropDownItems = 10;
                    }
                }
        
        private void GetRemainStockNumber(IList departmentStockIns)
        {
            IList productMasterIds = new ArrayList();
            foreach (DepartmentStockInDetail detail in departmentStockIns)
            {
                if (detail.Product != null && detail.Product.ProductMaster != null && detail.Product.ProductMaster.ProductMasterId != null)
                productMasterIds.Add(detail.Product.ProductMaster.ProductMasterId);
            }
            if (productMasterIds.Count == 0)
            {
                return;
            }
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddSearchInCriteria("ProductMaster.ProductMasterId", productMasterIds);
            IList stockList = StockLogic.FindAll(criteria);
            criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddEqCriteria("DepartmentPricePK.DepartmentId", (long)0);
            criteria.AddSearchInCriteria("DepartmentPricePK.ProductMasterId", productMasterIds);
            IList priceList = DepartmentPriceLogic.FindAll(criteria);
            foreach (DepartmentStockInDetail detail in departmentStockIns)
            {
                detail.StockQuantity = 0;
                if (detail.Product != null
                    && detail.Product.ProductMaster != null 
                    && detail.Product.ProductMaster.ProductMasterId != null)
                {
                    foreach (Stock stock in stockList)
                    {
                        if (stock.Product.ProductId.Equals(detail.Product.ProductId))
                        {
                            detail.StockQuantity += stock.Quantity;
                        }
                    }
                    foreach (DepartmentPrice price in priceList)
                    {
                        if (price.DepartmentPricePK.ProductMasterId.Equals(detail.Product.ProductMaster.ProductMasterId))
                        {
                            detail.Price = price.Price;
                        }
                    }
                }
            }
        }
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void departmentStockInView_SaveDepartmentStockInEvent(object sender, DepartmentStockInEventArgs e)
        {
            var stockIn = e.DepartmentStockIn;
            if (stockIn.StockInId == 0)
            {
                // if we are doing stock out to department
                if(e.ExportGoodsToDepartment)
                {
                    // execute stock out saving
                    StockOutLogic.Add(stockIn);
                    if (!e.IsForSync)
                    {
                        ClientUtility.Log(logger, stockIn.ToString(), "Xuất hàng ra cửa hàng");
                    }
                    else
                    {
                        ClientUtility.Log(logger, "Đồng bộ về cửa hàng.\r\n" + stockIn.ToString(), "Xuất hàng ra cửa hàng");
                    }

                }
                else
                {
                    DepartmentStockInLogic.Add(stockIn);
                    if (!e.IsForSync)
                    {
                        ClientUtility.Log(logger, stockIn.ToString(), "Nhập kho cửa hàng");
                    }
                    else
                    {
                        ClientUtility.Log(logger, "Đồng bộ về cửa hàng.\r\n" + stockIn.ToString(), "Đồng bộ về cửa hàng");
                    }
                }
                
            }
            else
            {
                DepartmentStockInLogic.Update(stockIn);
                if (!e.IsForSync)
                {
                    ClientUtility.Log(logger, stockIn.ToString(), "Nhập kho cửa hàng");
                }
                else
                {
                    ClientUtility.Log(logger, "Đồng bộ về cửa hàng.\r\n" + stockIn.ToString(), "Đồng bộ về cửa hàng");
                }
            }
            if (stockIn.DepartmentStockInPK != null && e.IsForSync)
            {
                e.DepartmentStockIn = DepartmentStockInLogic.FindById(stockIn.DepartmentStockInPK);
                IList productMasterIds = new ArrayList();
                foreach (DepartmentStockInDetail detail in e.DepartmentStockIn.DepartmentStockInDetails)
                {
                    if (!productMasterIds.Contains(detail.Product.ProductMaster.ProductMasterId))
                    {
                        productMasterIds.Add(detail.Product.ProductMaster.ProductMasterId);
                    }
                }
                var criteria = new ObjectCriteria();
                criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddEqCriteria("DepartmentPricePK.DepartmentId", (long)0);
                criteria.AddSearchInCriteria("DepartmentPricePK.ProductMasterId", productMasterIds);
                IList priceList = DepartmentPriceLogic.FindAll(criteria);
                foreach (DepartmentStockInDetail detail in e.DepartmentStockIn.DepartmentStockInDetails)
                {
                    foreach (DepartmentPrice price in priceList)
                    {
                        if (price.DepartmentPricePK.ProductMasterId.Equals(detail.Product.ProductMaster.ProductMasterId))
                        {
                            detail.Price = price.Price;
                        }
                    }
                }

                // Department information
                e.DepartmentStockIn.Department = DepartmentLogic.FindById(stockIn.DepartmentStockInPK.DepartmentId);
                criteria = new ObjectCriteria();
                criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddEqCriteria("EmployeePK.DepartmentId", stockIn.DepartmentStockInPK.DepartmentId);
                e.DepartmentStockIn.Department.Employees = EmployeeLogic.FindAll(criteria);
            }
            e.EventResult = "Success";
        }

        private IList RemoveDuplicateName(IList prdlist)
        {
            IList list = new ArrayList();
            foreach (ProductMaster productMaster in prdlist)
            {
                if (NotInList(productMaster, list))
                {
                    list.Add(productMaster);
                }
            }
            return list;
        }

        private bool NotInList(ProductMaster master, IList list)
        {
            foreach (ProductMaster productMaster in list)
            {
                if (productMaster.ProductName.Equals(master.ProductName))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

                #region IDepartmentStockInExtraController Members
                public IStockInDetailLogic StockInDetailLogic
                {
                    get;
                    set;
                }

                public IStockOutDetailLogic StockOutDetailLogic
                {
                    get;
                    set;
                }
                public IDepartmentLogic DepartmentLogic
                {
                    get;
                    set;
                }

                public AppFrame.Logic.IProductColorLogic ProductColorLogic
                {
                    get;set;
            
                }

                public AppFrame.Logic.IProductSizeLogic ProductSizeLogic
                {
                    get;set;
                }

        public IProductLogic ProductLogic
        {
            get; set;
        }

        public event EventHandler<DepartmentStockInEventArgs> CompletedFindByStockInEvent;

        public AppFrame.Logic.IStockLogic StockLogic
                {
                    get;
                    set;
                }
                public AppFrame.Logic.IEmployeeDetailLogic EmployeeDetailLogic
                {
                    get;
                    set;
                }

                public IDepartmentStockTempLogic DepartmentStockTempLogic
                {
                    get; set;
                }
                #endregion
            }
    }

