using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace AppFrame.WPF
{
    public class PosValidationRule : ValidationRule
    {
        public PosValidationRule() : base(System.Windows.Controls.ValidationStep.CommittedValue,true)
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return ValidationResult.ValidResult;
            return ValidationResult.ValidResult;
        }
    }
}
