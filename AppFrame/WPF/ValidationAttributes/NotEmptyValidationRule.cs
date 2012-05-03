using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace AppFrame.WPF.ValidationAttributes
{
    public class NotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string textValue = value.ToString();
            return !"".Equals(textValue);
        }
    }
}