﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;

namespace AppFrame.View.GoodsIO.DepartmentGoodsIO
{
    public interface IDepartmentStockInExtraView : IDepartmentStockInView
    {
        
        event EventHandler<DepartmentStockInEventArgs> FillProductToComboEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadGoodsByIdEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadProductColorEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadProductSizeEvent;
        event EventHandler<DepartmentStockInEventArgs> FillDepartmentEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameColorEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameColorSizeEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadPriceAndStockEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadDepartmentStockInForExportEvent;
        event EventHandler<DepartmentStockInEventArgs> UpdateDepartmentStockInForExportEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadMasterDataForExportEvent;
        event EventHandler<DepartmentStockInEventArgs> SyncExportedMasterDataEvent;
        event EventHandler<DepartmentStockInEventArgs> LoadStockInByProductMaster;
        event EventHandler<DepartmentStockInEventArgs> UpdateStockOutEvent;
        event EventHandler<DepartmentStockInEventArgs> FindRemainsQuantity;
        event EventHandler<DepartmentStockInEventArgs> FindBarcodeInMainStockEvent;
        event EventHandler<DepartmentStockInEventArgs> RefreshStockQuantityEvent;
    }
}
