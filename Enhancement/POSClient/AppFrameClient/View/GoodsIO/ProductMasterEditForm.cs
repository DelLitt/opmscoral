using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;

namespace AppFrameClient.View.GoodsIO
{
    public partial class ProductMasterEditForm : BaseForm,IProductMasterEditView
    {
        private IProductMasterController _productMasterController;
        private ProductMasterView ProductMasterView;
        public string ProductMasterId { get; set; }
        public ProductMasterEditForm()
        {
            InitializeComponent();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Implementation of IProductMasterEditView

        public IProductMasterController ProductMasterController
        {
            get { return _productMasterController; }
            set 
            { 
                _productMasterController = value;
                _productMasterController.ProductMasterEditView = this;
            }
        }

        public event EventHandler<ProductMasterEventArgs> LoadProductMasters;
        public event EventHandler<ProductMasterEventArgs> SaveProductMasters;

        #endregion

        private void ProductMasterEditForm_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.ProductMasterId))
            {
                ProductMasterEventArgs eventArgs = new ProductMasterEventArgs();
                eventArgs.ProductMasterId = ProductMasterId;
                EventUtility.fireEvent(LoadProductMasters,this,eventArgs);
                ProductMasterView = eventArgs.ProductMasterView;
                txtProductName.Text = ProductMasterView.ProductName;
                txtDescription.Text = ProductMasterView.Description;
                
            }
        }
    }
}
