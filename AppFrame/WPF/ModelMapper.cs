using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;
using Caliburn.Core;
using Caliburn.PresentationFramework;

namespace AppFrame.WPF
{
    public class ModelMapper<TViewModel,TModel> : PropertyChangedBase
    {
        private TViewModel viewModel;
        private TModel model;
        private IDictionary<KeyValuePair<string,string>, PropMapper> _propertiesMapper;
        public ModelMapper() : base()
        {
            _propertiesMapper = new Dictionary<KeyValuePair<string, string>, PropMapper>();
        }
        public void Connect(TViewModel viewModel,TModel model)
        {
            this.viewModel = viewModel;
            this.model = model;
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
            Type viewModelType = viewModel.GetType();
            PropertyInfo info = viewModelType.GetProperty(propertyName);
            object vmPropValue = info.GetValue(viewModel, null);
            KeyValuePair<string, string> map = _propertiesMapper.Keys.FirstOrDefault(x => x.Key.Equals(info.Name));
            PropMapper mapper = _propertiesMapper[map];
            PropertyInfo destInfo = model.GetType().GetProperties().FirstOrDefault(x => x.Name.Equals(map.Value));
            if(destInfo!=null)
            {
                destInfo.SetValue(model, mapper.ConvertFrom(), new object[] { 0 });    
            }
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
                    KeyValuePair<string, string> pair = new KeyValuePair<string, string>(mappingProp.Name,
                                                                                         propertyInfo.Name);
                    
                    PropMapper propMapper = new PropMapper();
                    _propertiesMapper[pair] = propMapper;
                    break;
                }
            }
        }

    }

    

    public class PropMapper
    {
        public object ConvertFrom()
        {
            return null;
        }
    }
}
