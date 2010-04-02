using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using Caliburn.PresentationFramework.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace AppFrame.WPF
{
    public class PosErrorValidationRule : ValidationRule
    {
        internal static readonly PosErrorValidationRule Instance = new PosErrorValidationRule();

        public PosErrorValidationRule()
            : base(ValidationStep.CommittedValue, true)
        {
        }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            IValidator validator = ServiceLocator.Current.GetInstance<IValidator>();
            BindingGroup group = value as BindingGroup;
            if (group != null)
            {
                IList items = group.Items;
                for (int i = items.Count - 1; i >= 0; i--)
                {
                    
                    IEnumerable<IValidationError> errors = validator.Validate(items[i]);
                    IEnumerator enumerator = errors.GetEnumerator();

                    if(enumerator.MoveNext())
                    {
                        IValidationError error = enumerator.Current as IValidationError;
                        return new ValidationResult(false,error.Message);
                    }
                }
            }
            else
            {
                BindingExpression expression = value as BindingExpression;
                if (expression == null)
                {
                    throw new InvalidOperationException("ValidationRule_UnexpectedValue");
                }

                object item = expression.DataItem;
                IEnumerable<IValidationError> errors = validator.Validate(item);
                IEnumerator enumerator = errors.GetEnumerator();

                if (enumerator.MoveNext())
                {
                    IValidationError error = enumerator.Current as IValidationError;
                    return new ValidationResult(false, error.Message);
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
