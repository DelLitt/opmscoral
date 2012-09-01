using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AppFrame.WPF.ValidationAttributes
{
    public class PastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime val = (DateTime)value;
            return DateTime.Now.Subtract(val).Ticks > 0;
        }
    }
}
