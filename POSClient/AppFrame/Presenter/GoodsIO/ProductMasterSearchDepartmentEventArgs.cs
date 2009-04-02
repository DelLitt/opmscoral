using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using Product=AppFrame.Model.Product;

namespace AppFrame.Presenter.GoodsIO
{
    public class ProductMasterSearchDepartmentEventArgs : ProductMasterSearchOrCreateEventArgs
    {
        public bool AvailableInStock { get; set;}
        public ProductMaster SelectedProductMaster { get; set; }
        public Product ReturnProduct { get; set; }
        public IList ProductsInDepartment { get; set; }
    }
}
