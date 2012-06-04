using System;
using System.Collections;
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

namespace POSServer.Views.Stock.StockIn
{
    /// <summary>
    /// Interaction logic for TemplatePage.xaml
    /// </summary>
    public partial class StockInView : UserControl
    {
        public StockInView()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ProductMasterList_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void StockInDetailList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void PutPrice_Click(object sender, RoutedEventArgs e)
        {
            IList<DataGridCellInfo> selectedCells = StockInDetailList.SelectedCells;
            foreach (DataGridCellInfo dataGridCellInfo in selectedCells)
            {
                
            }
        }
    }
}