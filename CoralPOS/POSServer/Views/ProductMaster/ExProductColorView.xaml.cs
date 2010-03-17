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

namespace POSServer.Views.ProductMaster
{
    /// <summary>
    /// Interaction logic for ProductTypeView.xaml
    /// </summary>
    public partial class ExProductColorView : UserControl
    {
        public ExProductColorView()
        {
            InitializeComponent();
        }

        private void ProductColorList_RowEditEnding(object sender, Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {

        }
    }
}
