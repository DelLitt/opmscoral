﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using AppFrame.Base;
using AppFrame.WPF;
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

        /// <summary>
        /// Return true if does not have view or does not using PosDataErrorProvider
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static bool HasError(this PosViewModel viewModel)
        {
            var view = viewModel.GetView(null) as DependencyObject;
            if(view == null) return false;
            DependencyObject vp = LogicalTreeHelper.FindLogicalNode(view, "PosDataErrorProvider");
            PosDataErrorProvider pvp = vp as PosDataErrorProvider;
            if(pvp == null) return false;
            return pvp.Validate();
        }

        public static bool HasError(this PosViewModel viewModel,string pdpName)
        {
            var view = viewModel.GetView(viewModel) as DependencyObject;
            if (view == null) return true;
            DependencyObject vp = LogicalTreeHelper.FindLogicalNode(view, pdpName);
            PosDataErrorProvider pvp = vp as PosDataErrorProvider;
            if (pvp == null) return true;
            return pvp.Validate();
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
