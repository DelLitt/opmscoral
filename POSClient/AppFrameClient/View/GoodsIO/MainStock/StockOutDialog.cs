using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrameClient.View.GoodsIO.MainStock
{
    public partial class StockOutDialog : BaseForm, IStockOutDialogView
    {
        public StockOutDialog()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StockOutDialog_Load(object sender, EventArgs e)
        {
            StockOutDialogEventArgs eventArgs = new StockOutDialogEventArgs();
            EventUtility.fireEvent(InitDialogEvent,this,eventArgs);

            PopulateComboBoxes(eventArgs);
        }

        private void PopulateComboBoxes(StockOutDialogEventArgs args)
        {
            productMasterBindingSource.DataSource = args.ProductMastersList;
            productMasterBindingSource.ResetBindings(false);
            productColorBindingSource.DataSource = args.ProductColorList;
            productColorBindingSource.ResetBindings(false);
            productSizeBindingSource.DataSource = args.ProductSizeList;
            productSizeBindingSource.ResetBindings(false);
            departmentBindingSource.DataSource = args.DepartmentsList;
            departmentBindingSource.ResetBindings(false);
        }

        private IStockOutDialogController stockOutDialogController; 
        public IStockOutDialogController StockOutDialogController 
        { get
        {
            return stockOutDialogController;
        } 
            set
            {
                stockOutDialogController = value;
                stockOutDialogController.StockOutDialogView = this;
            }
        }
        public event EventHandler<StockOutDialogEventArgs> InitDialogEvent;
        public event EventHandler<StockOutDialogEventArgs> FindProductMasterNameEvent;
        public event EventHandler<StockOutDialogEventArgs> FindProductMastersEvent;
        public event EventHandler<StockOutDialogEventArgs> FindProductColorNameEvent;
        public event EventHandler<StockOutDialogEventArgs> FindProductSizeNameEvent;
        public event EventHandler<StockOutDialogEventArgs> DivideProductMastersEvent;
    }
}