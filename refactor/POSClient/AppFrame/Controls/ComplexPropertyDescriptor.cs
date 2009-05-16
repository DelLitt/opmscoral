using System;
using System.ComponentModel;

namespace AppFrame.Controls
{
    public class ComplexPropertyDescriptor : PropertyDescriptor
    {
        private string name;
        private MemberDescriptor memberDescriptor;
        private Attribute[] attributes;
        private PropertyDescriptor _subPD;
        private PropertyDescriptor _parentPD;

        public ComplexPropertyDescriptor(PropertyDescriptor parentPropDescriptor, PropertyDescriptor subPropDescriptor, string pdname)
            : base(pdname,null)

        {           

            _subPD = subPropDescriptor;
            _parentPD = parentPropDescriptor;

        }
        public ComplexPropertyDescriptor(string name,Attribute[] attributes) : base(name,attributes)
        {
           if(name.IndexOf(".")>0)
           {
               string _subPDName = name.Substring(name.LastIndexOf("."));
               string _parentPDName = name.Substring(0, name.LastIndexOf("."));

           }
        }
                
        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get { return _parentPD.ComponentType; }
        }
        
        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get { return _subPD.PropertyType; }
        }

        public override void ResetValue(object component)
        {
            // not implement
        }

        public override object GetValue(object component)
        {

            return _subPD.GetValue(_parentPD.GetValue(component));

        }
        

        public override void SetValue(object component, object value)
        {

            _subPD.SetValue(_parentPD.GetValue(component), value);

            OnValueChanged(component, EventArgs.Empty);

        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
    }
}
