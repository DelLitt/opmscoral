using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace AppFrame.WPF
{
    public class WPFUtils
    {
        public static FormattedText CreateFormattedText(string text,int fontSize,Brush brush,Typeface typeface,int maxTextWidth,TextAlignment alignment)
        {
            FormattedText formattedText = new FormattedText(
                            text,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            typeface,
                            fontSize,
                            brush);
            formattedText.SetFontSize(fontSize * (96.0 / 72.0));
            formattedText.TextAlignment = alignment;
            formattedText.MaxTextWidth = maxTextWidth;
            return formattedText;
        }
    }
}
