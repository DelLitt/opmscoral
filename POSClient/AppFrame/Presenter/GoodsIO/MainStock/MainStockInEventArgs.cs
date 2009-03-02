using System;
using System.Collections.Generic;
using System.Text;
using AppFrame.Common;
using System.Collections;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO.MainStock
{
    public class MainStockInEventArgs : BaseEventArgs
    {
        public Form ParentForm { get; set; }

        public ProductMaster SelectedProductMaster { get; set; }
        public StockIn StockIn { get; set; }
        public Department Department { get; set; }

        public IList FoundProductMasterList { get; set; }

        public IList ProductMasterList { get; set; }
        public IList CountryList { get; set; }
        public IList ProductTypeList { get; set; }
        public IList ProductSizeList { get; set; }
        public IList ProductColorList { get; set; }
        public IList ManufacturerList { get; set; }
        public IList DistributorList { get; set; }
        public IList PackagerList { get; set; }
        public IList StockList { get; set; }

        public IList DepartmentStockList { get; set; }
        public IList DepartmentRemainStockList { get; set; }
        public DepartmentPrice DepartmentPrice { get; set; }

        public string ProductMasterId { get; set; }
        public string ProductMasterIdForPrice { get; set; }
        public string ProductMasterName { get; set; }
        public ProductType ProductType { get; set; }
        public ProductSize ProductSize { get; set; }
        public ProductColor ProductColor { get; set; }
        public Country Country { get; set; }
        public StockInDetail SelectedStockInDetail {get;set;}
        public int SelectedIndex { get; set; }
        public bool IsFillToComboBox { get; set; }
        public string ComboBoxDisplayMember { get; set; }
    }
}