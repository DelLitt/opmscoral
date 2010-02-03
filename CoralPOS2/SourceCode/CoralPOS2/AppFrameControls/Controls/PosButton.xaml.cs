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

namespace AppFrameControls.Controls
{
    /// <summary>
    /// Interaction logic for PosButton.xaml
    /// </summary>
    public partial class PosButton : Button
    {
        public PosButton()
        {
            InitializeComponent();
        }

        public string Text { get; set; }

        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text",typeof(string), typeof(PosButton),
        new FrameworkPropertyMetadata("Button 1",
        new PropertyChangedCallback(OnTextChanged)));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // When the color changes, set the icon color
            PosButton control = (PosButton)d;
            TextBlock tb = (TextBlock)control.Content;
            tb.Text = control.Text;
        }
    }
}
