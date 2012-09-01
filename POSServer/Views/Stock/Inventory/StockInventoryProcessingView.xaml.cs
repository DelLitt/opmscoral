using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoralPOS.DTO;
using CoralPOS.Models;

namespace POSServer.Views.Stock.Inventory
{
    /// <summary>
    /// Interaction logic for TemplatePage.xaml
    /// </summary>
    public partial class StockInventoryProcessingView : UserControl
    {
        public StockInventoryProcessingView()
        {
            InitializeComponent();

            
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterText();
            CalculateSum();
        }

        private void CalculateSum()
        {
            long totalQuantity = 0;
            long totalGoodQuantity = 0;
            foreach (var item in StockInventoryList.Items)
            {
                DepartmentStockTempValidDTO master = (DepartmentStockTempValidDTO)item;
                master.CountQuantities();
                totalQuantity += master.TotalQuantity;
                totalGoodQuantity += master.TotalGoodQuantity;
            }
            LogicalSum.Text = totalQuantity.ToString();
            RealSum.Text = totalGoodQuantity.ToString();
        }

        public void FilterText()
        {
            ProductMasterList.Items.Filter = delegate(object obj)
            {
                if (ProductTypeList.SelectedItem == null) return true;
                ProductType type = (ProductType)ProductTypeList.SelectedItem;
                if (type.TypeId == 0) return true;
                CoralPOS.Models.ProductMaster master = (CoralPOS.Models.ProductMaster)obj;
                return master.ProductType.TypeId == type.TypeId;
            };
            var itemSource = StockInventoryList.ItemsSource;
            StockInventoryList.Items.Filter = delegate(object obj)
            {
                if (ProductTypeList.SelectedItem == null) return true;
                ProductType type = (ProductType)ProductTypeList.SelectedItem;
                if (type.TypeId == 0) return true;
                DepartmentStockTempValidDTO master = (DepartmentStockTempValidDTO)obj;
                return master.ProductMaster.ProductType.TypeId == type.TypeId;
            };
        }
    }
}