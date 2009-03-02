using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO
{
    public class ProductMasterEventArgs : BaseEventArgs
    {
        public Form ParentForm { get; set; }
        public string ProductMasterId { get; set; }
        public ProductMaster ProductMaster { get; set; }
        public DepartmentPrice DepartmentPrice { get; set; }
        public IList CountryList { get; set; }
        public IList ProductTypeList { get; set; }
        public IList ProductSizeList { get; set; }
        public IList ProductColorList { get; set; }
        public IList ManufacturerList { get; set; }
        public IList DistributorList { get; set; }
        public IList PackagerList { get; set; }
        public List<ProductMaster> CreatedProductMasterList { get; set; }
    }
}
