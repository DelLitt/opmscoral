﻿using System;
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
        public Form ParentForm { get; set; }

        public ProductMaster SelectedProductMaster { get; set; }
        public DepartmentStockIn DepartmeneStockIn { get; set; }
        public Department Department { get; set; }
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
        public IList DepartmentRemainStockList { get; set; }

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
    }
}