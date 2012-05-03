using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AppFrame.Validation
{
    public class ValidateAttribute : ValidationAttribute
    {
        public ValidateAttribute()
        {
        }

        public ValidateAttribute(string errorMessage) : base(errorMessage)
        {
        }

        public ValidateAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor)
        {
        }
    }
}
