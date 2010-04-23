using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using AppFrame.DataLayer;
using Caliburn.PresentationFramework.ViewModels;

namespace AppFrame.WPF
{
    public class PosDataErrorProvider : Decorator
    {
        List<BindingElementInfo> bindingObjects = new List<BindingElementInfo>();
        
        private static FieldInfo _isSealedFieldInfo;
        private delegate void FoundBindingCallbackDelegate(FrameworkElement element, Binding binding,DependencyProperty dp);
        public PosDataErrorProvider()
        {
            this.Name = "PosDataErrorProvider";
            _isSealedFieldInfo =
                typeof(BindingBase).GetField("_isSealed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (_isSealedFieldInfo == null)
                throw new InvalidOperationException("Oops, we have a problem, it seems like the WPF team decided to change the name of the _isSealed field of the BindingBase class.");
            this.Loaded += new System.Windows.RoutedEventHandler(PosDataErrorProviderLoaded);
        }
        void PosDataErrorProviderLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ValidateContext = false;
            GetBindingElementInformation();
            if(EnabledValidation) TurnOnValidateOnDataError();
        }

        private void GetBindingElementInformation()
        {
            FindBindingsRecursively(
                     this.Parent,
                     delegate(FrameworkElement element, Binding binding, DependencyProperty dp)
                     {
                         bindingObjects.Add(new BindingElementInfo(element, binding, dp));
                     });
        }

        private bool enabledValidation = true;
        public bool EnabledValidation
        {
            get { return enabledValidation; }
            set { enabledValidation = value; 
                if(enabledValidation)
                {
                    TurnOnValidateOnDataError();
                }
                else
                {
                    TurnOffValidateOnDataError();
                }
            }
        }

        public bool ValidateContext { get; set; }
        private void TurnOffValidateOnDataError()
        {
            foreach (BindingElementInfo bbInfo in bindingObjects)
            {
                Binding binding = bbInfo.Binding;
                FrameworkElement element = bbInfo.DependencyObject;
                DependencyProperty dp = bbInfo.DependencyProperty;
                // Turn on validate on error for this binding
                // well, WPF check if Binding is sealed , if true, then throw exception if we change
                // so I borrow trick from Marlon Grech.
                bool isSealed = (bool)_isSealedFieldInfo.GetValue(binding);
                if (isSealed) _isSealedFieldInfo.SetValue(binding, false);

                binding.ValidatesOnDataErrors = false;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                binding.NotifyOnValidationError = false;
                System.Windows.Controls.Validation.RemoveErrorHandler(element, ErrorHandler);
                element.SetBinding(dp, binding);
                if (isSealed) _isSealedFieldInfo.SetValue(binding, true);
                if (ErrorTemplate != null)
                {
                    System.Windows.Controls.Validation.SetErrorTemplate(element, ErrorTemplate);
                }
            }
        }

        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.Register("IsValid", typeof(Boolean), typeof(PosDataErrorProvider));
        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }
        #region properties
        public ControlTemplate ErrorTemplate { get; set; }
        #endregion
        // return true if Ok and false if has error
        public bool Validate()
        {
            bool validated = true;
            if (ValidateContext)
            {
                if (this.DataContext is IDataErrorInfo)
                {
                    ValidateDataContext(this.DataContext);
                }
            }
            else
            {
                validated = ValidateBinding();
                
            }
            
            return validated;
        }

        private bool ValidateBinding()
        {
            bool validate = true;
            foreach (BindingElementInfo bindingObject in bindingObjects)
            {
                bool hasError = false;
                //hasError = System.Windows.Controls.Validation.GetHasError(bindingObject);
                var errors = System.Windows.Controls.Validation.GetErrors(bindingObject.DependencyObject);
                hasError = errors.Count > 0;
                if (hasError)
                {
                    validate = false;
                    foreach (ValidationError validationError in errors)
                    {
                        System.Windows.Controls.Validation.MarkInvalid((BindingExpressionBase)validationError.BindingInError, validationError);
                    }
                }

            }
            return validate;
        }

        private void ValidateDataContext(object dataContext)
        {
            List<IValidationError> errors = new List<IValidationError>();
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddFirst(dataContext.GetType().FullName);
            ValidateRecursively(dataContext, errors,linkedList);
            /*foreach (IValidationError validationError in errors)
            {*/
                //string propName = validationError.PropertyName;

            var result = from bdi in bindingObjects
                         from validationError in errors
                         where bdi.Binding.Path.Path.EndsWith(validationError.PropertyName)
                         select CreateValidationError(bdi, validationError);
                                 
            
            /*}*/
        }

        private object CreateValidationError(BindingElementInfo bdi, IValidationError validationError)
        {
            ValidationError error = new ValidationError(bdi.Binding.ValidationRules[0], bdi.Binding,validationError.Message, null);
            System.Windows.Controls.Validation.MarkInvalid(BindingOperations.GetBindingExpression(bdi.DependencyObject,bdi.DependencyProperty),error);
            return error;
        }

        private void ValidateRecursively(object instance, List<IValidationError> validationErrors, LinkedList<string> linkedList)
        {
            Type type = instance.GetType();
            PropertyInfo[] propInfos =type.GetProperties();
            validationErrors.AddRange(GlobalValidator.Instance.Validate(instance).ToList());
            
            foreach (PropertyInfo propertyInfo in propInfos)
            {
                
                var obj = propertyInfo.GetValue(instance, null);
                if (obj == null) continue;
                if (obj.GetType().IsPrimitive || obj.GetType().IsEnum) continue;
                Type typeObj = obj.GetType();
                if (obj.GetType().FullName.EndsWith("Proxy")) typeObj = obj.GetType().BaseType;
                if(linkedList.Contains(typeObj.FullName))
                {
                    int propPos = PosInList(linkedList, typeObj.FullName);
                    int entityPos = PosInList(linkedList, instance.GetType().FullName);
                    if (propPos < entityPos) continue;
                }
                else
                {
                    linkedList.AddLast(typeObj.FullName);
                }
                ValidateRecursively(obj, validationErrors, linkedList);

            }
            
        }

        private int PosInList(LinkedList<string> linkedList, string entityFullName)
        {
            IEnumerator enumerator = linkedList.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
            {
                if (entityFullName.Equals(enumerator.Current.ToString())) return i;
                i++;
            }
            return int.MaxValue;
        }

        private void TurnOnValidateOnDataError()
        {
            foreach (BindingElementInfo bbInfo in bindingObjects)
            {
                Binding binding = bbInfo.Binding;
                FrameworkElement element = bbInfo.DependencyObject;
                DependencyProperty dp = bbInfo.DependencyProperty;
                // Turn on validate on error for this binding
                // well, WPF check if Binding is sealed , if true, then throw exception if we change
                // so I borrow trick from Marlon Grech.
                bool isSealed = (bool)_isSealedFieldInfo.GetValue(binding);
                if (isSealed) _isSealedFieldInfo.SetValue(binding, false);

                binding.ValidatesOnDataErrors = true;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                binding.NotifyOnValidationError = true;
                System.Windows.Controls.Validation.AddErrorHandler(element, ErrorHandler);
                element.SetBinding(dp, binding);
                if (isSealed) _isSealedFieldInfo.SetValue(binding, true);
                if (ErrorTemplate != null)
                {
                    System.Windows.Controls.Validation.SetErrorTemplate(element, ErrorTemplate);
                }
            }
            /*FindBindingsRecursively(
                      this.Parent,
                      delegate(FrameworkElement element, Binding binding,DependencyProperty dp)
                      {
                          bindingObjects.Add(new BindingElementInfo(element,binding,dp));
                          // Turn on validate on error for this binding
                          // well, WPF check if Binding is sealed , if true, then throw exception if we change
                          // so I borrow trick from Marlon Grech.
                          bool isSealed = (bool)_isSealedFieldInfo.GetValue(binding);
                          if(isSealed) _isSealedFieldInfo.SetValue(binding,false);
                          
                          binding.ValidatesOnDataErrors = true;
                          binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                          binding.NotifyOnValidationError = true;
                          System.Windows.Controls.Validation.AddErrorHandler(element,ErrorHandler);
                          element.SetBinding(dp, binding);
                          if (isSealed) _isSealedFieldInfo.SetValue(binding, true);
                          if(ErrorTemplate!=null)
                          {
                              System.Windows.Controls.Validation.SetErrorTemplate(element, ErrorTemplate);
                          }
                      }); */ 
        }

        private void ErrorHandler(object sender, ValidationErrorEventArgs e)
        {
            if(e.Action == ValidationErrorEventAction.Added)
            {
                IsValid = false;
            }
            else
            {
                IsValid = true;
            }
        }

        private void FindBindingsRecursively(DependencyObject element, FoundBindingCallbackDelegate callbackDelegate)
        {

            // See if we should display the errors on this element
            MemberInfo[] members = element.GetType().GetMembers(BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField | BindingFlags.GetProperty);

            foreach (MemberInfo member in members)
            {
                DependencyProperty dp = null;

                // Check to see if the field or property we were given is a dependency property
                if (member.MemberType == MemberTypes.Field)
                {
                    FieldInfo field = (FieldInfo)member;
                    if (typeof(DependencyProperty).IsAssignableFrom(field.FieldType))
                    {
                        dp = (DependencyProperty)field.GetValue(element);
                    }
                }
                else if (member.MemberType == MemberTypes.Property)
                {
                    PropertyInfo prop = (PropertyInfo)member;
                    if (typeof(DependencyProperty).IsAssignableFrom(prop.PropertyType))
                    {
                        dp = (DependencyProperty)prop.GetValue(element, null);
                    }
                }

                if (dp != null)
                {
                    // Awesome, we have a dependency property. does it have a binding? If yes, is it bound to the property we're interested in?
                    Binding bb = BindingOperations.GetBinding(element, dp);
                    if (bb != null)
                    {
                        // This element has a DependencyProperty that we know of that is bound to the property we're interested in. 
                        // Now we just tell the callback and the caller will handle it.
                        if (element is FrameworkElement)
                        {
                            if (((FrameworkElement)element).DataContext == this.DataContext)
                            {
                                callbackDelegate((FrameworkElement)element, bb,dp);
                            }
                        }
                    }
                }
            }

            // Now, recurse through any child elements
            if (element is FrameworkElement || element is FrameworkContentElement)
            {
                foreach (object childElement in LogicalTreeHelper.GetChildren(element))
                {
                    if (childElement is DependencyObject)
                    {
                        FindBindingsRecursively((DependencyObject)childElement, callbackDelegate);
                    }
                }
            }
        }
    
    }
    
    class BindingElementInfo
    {
        private FrameworkElement dependencyObject;
        private Binding binding;
        private DependencyProperty dependencyProperty;

        public BindingElementInfo(FrameworkElement dependencyObject, Binding binding, DependencyProperty dependencyProperty)
        {
            this.dependencyObject = dependencyObject;
            this.binding = binding;
            this.dependencyProperty = dependencyProperty;
        }

        public FrameworkElement DependencyObject
        {
            get { return dependencyObject; }
            set { dependencyObject = value; }
        }

        public Binding Binding
        {
            get { return binding; }
            set { binding = value; }
        }

        public DependencyProperty DependencyProperty
        {
            get { return dependencyProperty; }
            set { dependencyProperty = value; }
        }
    }
    
}
