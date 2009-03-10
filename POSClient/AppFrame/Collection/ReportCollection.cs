using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AppFrame.Controls;

namespace AppFrame.Collection
{
    public class ReportCollection<T> : BindingList<T>,ITypedList
    {
        /// <summary>
        /// 
        /// </summary>
        public ReportCollection()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public ReportCollection(IList<T> list)
            : base(list)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listAccessors"></param>
        /// <returns></returns>
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            bool designTime = false;
            PropertyDescriptorCollection propertyDescriptorCollection =
                TypeDescriptor.GetProperties(typeof(T));
            
                PropertyDescriptorCollection descriptorCollection = ComplexListPropertyHelper.GetList(propertyDescriptorCollection, typeof(T).FullName);

                PropertyDescriptor[] descriptors = new PropertyDescriptor[descriptorCollection.Count];

                return descriptorCollection;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listAccessors"></param>
        /// <returns></returns>
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return typeof(T).Name;
        }
    }
}
