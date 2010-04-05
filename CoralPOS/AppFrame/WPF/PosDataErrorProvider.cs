using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AppFrame.WPF
{
    public class PosDataErrorProvider : Decorator
    {
        List<FrameworkElement> bindingObjects = new List<FrameworkElement>();
        private delegate void FoundBindingCallbackDelegate(FrameworkElement element, Binding binding);
        public PosDataErrorProvider()
        {
            this.Loaded += new System.Windows.RoutedEventHandler(PosDataErrorProvider_Loaded);
        }
        void PosDataErrorProvider_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            TurnOnValidateOnDataError();
        }
        
        #region properties
        public ControlTemplate ErrorTemplate { get; set; }
        #endregion
        public bool Validate()
        {
            bool val = true;
            foreach (FrameworkElement bindingObject in bindingObjects)
            {
                val = System.Windows.Controls.Validation.GetHasError(bindingObject);
                if(val == false) return val;
            }
            return val;
        }
        private void TurnOnValidateOnDataError()
        {
            FindBindingsRecursively(
                      this.Parent,
                      delegate(FrameworkElement element, Binding binding)
                      {
                          bindingObjects.Add(element);
                          // Turn on validate on error for this binding
                          binding.ValidatesOnDataErrors = true;
                          binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                          if(ErrorTemplate!=null)
                          {
                              System.Windows.Controls.Validation.SetErrorTemplate(element, ErrorTemplate);
                          }
                      });  
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
                                callbackDelegate((FrameworkElement)element, bb);
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
}
