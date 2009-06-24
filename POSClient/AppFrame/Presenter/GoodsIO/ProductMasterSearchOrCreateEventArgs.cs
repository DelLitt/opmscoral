using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter.GoodsIO
{
    public class ProductMasterSearchOrCreateEventArgs : BaseEventArgs
    {
        public Form ParentForm { get; set; }
        public ProductMaster ProductMaster { get; set; }
        public IList ProductMasterList { get; set; }
        public IList ProductList { get; set; }
        public IList CountryList { get; set; }
        public IList ProductTypeList { get; set; }
        public IList ProductSizeList { get; set; }
        public IList ProductColorList { get; set; }
        public IList ManufacturerList { get; set; }
        public IList DistributorList { get; set; }
        public IList PackagerList { get; set; }

        public string ProductMasterId { get; set; }
        public string ProductMasterName { get; set; }
        public ProductType ProductType { get; set; }
        public ProductSize ProductSize { get; set; }
        public ProductColor ProductColor { get; set; }
        public Country Country { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Distributor Distributor { get; set; }
        public Packager Packager { get; set; }
        public string Barcode { get; set; }
    }
}
