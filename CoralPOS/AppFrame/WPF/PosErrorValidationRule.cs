using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using AppFrame.DataLayer;
using Caliburn.PresentationFramework.Behaviors;
using Caliburn.PresentationFramework.ViewModels;

namespace AppFrame.WPF
{
    public class PosErrorValidationRule : ValidationRule
    {
        private static PosErrorValidationRule _instance;
        private PropertyInfo _sourceItemInfo;
        private PropertyInfo _sourcePropertyName;
        public PosErrorValidationRule()
            : base(ValidationStep.CommittedValue, true)
        {
        }
        
        public static PosErrorValidationRule Instance
        {
            get
            {
                if(_instance == null) _instance = new PosErrorValidationRule();
                return _instance;
            }
        
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DefaultValidator validator = GlobalValidator.Instance;
            BindingGroup group = value as BindingGroup;
            if (group != null)
            {
                IList items = group.Items;
                foreach (var item in items)
                {
                    if (item == null) continue;
                    if(!ShouldValidate(item)) continue;
                    
                    var errors = validator.Validate(item);
                    if(errors.Count() > 0 )
                    {
                        string errorMessage = string.Join(Environment.NewLine,errors.Select(x => x.Message).ToArray());
                        return new ValidationResult(false, errorMessage);
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

                _sourceItemInfo = typeof(BindingExpression).GetProperty("SourceItem", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                _sourcePropertyName = typeof(BindingExpression).GetProperty("SourcePropertyName", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (_sourceItemInfo == null || _sourcePropertyName == null)
                    throw new InvalidOperationException("Oops, we have a problem, it seems like the WPF team decided to change the name of the SourceItem/SourcePropertyName property of the BindingExpression class.");
                var item = _sourceItemInfo.GetValue(expression, null);
                if(item!=null && ShouldValidate(item))
                {
                    string propertyName = (string) _sourcePropertyName.GetValue(expression, null);
                    var errors = validator.Validate(item,propertyName);
                    if (errors.Count() > 0)
                    {
                        string errorMessage = string.Join(Environment.NewLine, errors.Select(x => x.Message).ToArray());
                        return new ValidationResult(false, errorMessage);
                    }
                }
            }
            return ValidationResult.ValidResult;
        }

        private bool ShouldValidate(object item)
        {
            return item.GetType().GetCustomAttributes(typeof (ValidateAttribute), true).Any();
        }
    }
}
