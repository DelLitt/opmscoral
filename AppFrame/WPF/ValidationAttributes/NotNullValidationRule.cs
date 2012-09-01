using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace AppFrame.WPF.ValidationAttributes
{
    public class NotNullAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value!=null;    
        }
    }
}