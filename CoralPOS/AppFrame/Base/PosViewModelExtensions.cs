using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Validation;

namespace AppFrame.Base
{
    public static class PosViewModelExtensions
    {
        public static POSErrorResult Validate<T>(this PosViewModel viewModel, T model) where T:class
        {
            IObjectValidator<T> validator = ValidatorProvider.For(model);
            return validator.Validate();
        }
    }
}
