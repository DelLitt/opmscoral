using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFrameControls.Controls
{
    public class CoralUserControl : UserControl
    {
        public static RoutedEventHandler GotFocus;
        public static RoutedEventHandler LostFocus;
        public static KeyEventHandler KeyDown;
        public CoralUserControl()
        {
            AddHandler(TextBox.GotFocusEvent, GotFocus,true);
            AddHandler(TextBox.LostFocusEvent, LostFocus, true);
            AddHandler(Keyboard.KeyDownEvent, KeyDown, true);
        }

        private void KeyDownEventHandler(object sender, KeyEventArgs keyEventArgs)
        {
            if(keyEventArgs.Key == Key.F2)
            {
                // focus to text box has name is Barcode.
                // Magic string is used here :(
                TextBox box =(TextBox)this.FindName("Barcode");
                if (box != null) box.Focus();
            }
        }

        private void LostFocusEventHandler(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox)
            {
                TextBox box = (TextBox)e.OriginalSource;
                box.Effect = null;
                box.Background = System.Windows.Media.Brushes.White;
            }
        }

        private void GotFocusEventHandler(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox)
            {
                TextBox box = (TextBox)e.OriginalSource;
                box.Effect = new System.Windows.Media.Effects.DropShadowEffect();
                box.Background = System.Windows.Media.Brushes.LightGreen;
            }
        }
    }
}
