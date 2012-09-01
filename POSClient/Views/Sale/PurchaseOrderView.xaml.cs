using System;
using System.Windows.Controls;
using System.Windows.Input;
using AppFrameControls.Controls;

namespace POSClient.Views.Sale
{
    /// <summary>
    /// Interaction logic for TemplatePage.xaml
    /// </summary>
    public partial class PurchaseOrderView : CoralUserControl
    {
        public PurchaseOrderView()
        {
            InitializeComponent();
        }

        private void GridPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(e.Source is TextBox 
                && !((TextBox)e.Source).Name.Equals("Note")
                && !((TextBox)e.Source).Name.Equals("Barcode"))
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
                    if (result >= 0)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

        private void GridLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Barcode.Focus();
        }

        private void PaymentTextInput(object sender, TextCompositionEventArgs e)
        {
            int payment = Int32.Parse(Payment.Text);
            int change = payment - Int32.Parse(TotalQuantity.Text);
            Changes.Text = change.ToString();
        }       
    }
}