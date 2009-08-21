using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using System.Collections;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO.DepartmentGoodsIO
{
    public class DepartmentStockInEventArgs : BaseEventArgs
    {
        public StockOut UpdateStockOut { get; set; }
        public IList SelectedStockInIds { get; set;}
        public bool HasMasterDataToSync { get; set;}
        public bool SyncDepartments { get; set;}
        public bool SyncPrice {get;set;}
        public bool SyncProductMasters { get; set;}
        public string SelectedStockInId { get; set;}
        public IList SelectedStockOutDetails { get; set; }
        public DepartmentStock DepartmentStock { get; set;}

        public IList DepartmentsList
        {
            get;
            set;
        }
        public DateTime LastSyncTime { get; set;}
        public SyncFromMainToDepartment SyncFromMainToDepartment { get; set; }
        public IList StockOutList { get; set;}
        public DepartmentStockInDetail DepartmentStockInDetail { get; set;}
        public Form ParentForm { get; set; }
        public bool ExportGoodsToDepartment { get; set;}
        public ProductMaster SelectedProductMaster { get; set; }
        public DepartmentStockIn DepartmentStockIn { get; set; }
        public Department Department { get; set; }
        public string ProductId { get; set; }    
        public bool IsForSync { get; set; }

        public IList CountryList { get; set; }
        public IList ProductTypeList { get; set; }
        public IList ProductSizeList { get; set; }
        public IList ProductColorList { get; set; }
        public IList ManufacturerList { get; set; }
        public IList DistributorList { get; set; }
        public IList PackagerList { get; set; }
        public IList StockList { get; set; }
        public IList DepartmentStockList { get; set; }
        public IList DepartmentList { get; set; }
        public IList DepartmentStockInDetailList { get; set; }
        public IList FoundProductMasterList { get; set; }

        public string ProductMasterId { get; set; }
        public string ProductMasterName { get; set; }
        public ProductType ProductType { get; set; }
        public ProductSize ProductSize { get; set; }
        public ProductColor ProductColor { get; set; }
        public Country Country { get; set; }
        public DepartmentStockInDetail SelectedDepartmentStockInDetail {get;set;}
        public int SelectedIndex { get; set; }
        public bool IsFillToComboBox { get; set; }
        public string ComboBoxDisplayMember { get; set; }
        public IList DepartmentStockInList { get; set; }

        public IList ProductMasterList { get; set; }
        public IList DepartmentPriceMasterList { get; set; }
    }
}