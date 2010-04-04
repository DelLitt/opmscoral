
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.ViewModels;

namespace AppFrame.Extensions
{
    public static class PosViewModelExtensions
    {
        public static bool HasError(this PosViewModel viewModel,object target)
        {
            DefaultValidator validator = new DefaultValidator();
            var error = validator.Validate(target).FirstOrDefault();
            return error != null ? true : false;     
        }

        public static bool HasError(this PosViewModel viewModel)
        {
            DefaultValidator validator = new DefaultValidator();
            var error = validator.Validate(viewModel).FirstOrDefault();
            return error != null ? true : false;     
        }

        public static IEnumerable<IValidationError> GetErrors(this PosViewModel viewModel,object target)
        {
            DefaultValidator validator = new DefaultValidator();
            return validator.Validate(target);
        }

        public static IEnumerable<IValidationError> GetErrors(this PosViewModel viewModel)
        {
            DefaultValidator validator = new DefaultValidator();
            return validator.Validate(viewModel);
        }
    }
}
