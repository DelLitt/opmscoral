using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace AppFrame.WPF.ValidationAttributes
{
    public class NotNullOrEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string textValue = value as string;
            return !string.IsNullOrEmpty(textValue);    
        }
    }
}