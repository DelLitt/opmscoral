using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace POSClient.Views.Sale
{
    /// <summary>
    /// Interaction logic for TemplatePage.xaml
    /// </summary>
    public partial class PurchaseOrderView : UserControl
    {
        public PurchaseOrderView()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(e.Source is TextBox && !((TextBox)e.Source).Name.Equals("Note"))
                    e.Handled = !IsTextValid(e.Text);
        }

        private bool IsTextValid(string text)
        {
            bool isValid = false;
            if (!string.IsNullOrEmpty(text == null ? null : text.Trim()))
            {
                Int64 result = -1;
                if (Int64.TryParse(text, out result))
                {
                    if (result > 0)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

        private void Grid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Barcode.Focus();
        }
        
    }
}