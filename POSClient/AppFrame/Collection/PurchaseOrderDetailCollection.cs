using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Controls;
using AppFrame.Model;

namespace AppFrame.Collection
{
    public class PurchaseOrderDetailCollection : BindingList<PurchaseOrderDetail>,ITypedList
    {
        private BindingSource bindingSource;
        public PurchaseOrderDetailCollection(BindingSource source) : base()
        {
            bindingSource = source;
        }

        public PurchaseOrderDetailCollection() : base()
        {
        }

        #region ITypedList Members

        public PurchaseOrderDetailCollection(IList<PurchaseOrderDetail> list) : base(list)
        {
        }

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            bool designTime = false;
            if (bindingSource == null)
            {
                designTime = true;
            }
            else
            {
                if (bindingSource.Site != null && bindingSource.Site.DesignMode)
                {
                    designTime = true;
                }
            }
            PropertyDescriptorCollection propertyDescriptorCollection =
                TypeDescriptor.GetProperties(typeof (PurchaseOrderDetail));
            if (designTime)
            {
                return propertyDescriptorCollection;
            } 
            else
            {
                PropertyDescriptorCollection descriptorCollection = ComplexListPropertyHelper.GetList(propertyDescriptorCollection, typeof(PurchaseOrderDetail).FullName);

                PropertyDescriptor[] descriptors = new PropertyDescriptor[descriptorCollection.Count];
                foreach (PropertyDescriptor descriptor in descriptors)
                {
                    
                }
                return descriptorCollection;
            }
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return typeof (PurchaseOrderDetail).Name;
        }

        #endregion

    }
}
