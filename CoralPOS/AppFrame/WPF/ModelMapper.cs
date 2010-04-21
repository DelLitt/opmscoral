using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Caliburn.Core;
using Caliburn.PresentationFramework;

namespace AppFrame.WPF
{
    public class ModelMapper<TViewModel,TModel> : PropertyChangedBase
    {
        private IDictionary<TViewModel, TModel> dictionary;
        private IDictionary<string, object> _propertiesMapper;
        public ModelMapper() : base()
        {
            dictionary = new Dictionary<TViewModel, TModel>();
            _propertiesMapper = new Dictionary<string, object>();
        }
        public void Connect(TViewModel viewModel,TModel model)
        {
            dictionary[viewModel] = model;
            AutoMap(viewModel, model);
            if(viewModel is PropertyChangedBase)
            {
                PropertyChangedBase changedBase= viewModel as PropertyChangedBase;
                changedBase.PropertyChanged += changedBase_PropertyChanged;
            }
        }

        public void NotifyViewModel<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
           NotifyViewModel(propertyExpression.GetMemberInfo().Name); 
        }
        public void NotifyViewModel(string property)
        {
            ModelChanged(property);
        }

        private void ModelChanged(string property)
        {
            
        }

        void changedBase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ViewModelChanged(e.PropertyName);
        }

        private void ViewModelChanged(string propertyName)
        {
            
        }

        private void AutoMap(TViewModel viewModel, TModel model)
        {
            Type type = viewModel.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                MapProprietaryProp(model, propertyInfo);
            }
        }

        
        private void MapProprietaryProp(TModel model, PropertyInfo mappingProp)
        {
            Type type = model.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if(propertyInfo.Name.Equals(mappingProp.Name))
                {
                    // mapping
                }
            }
        }

    }
}
