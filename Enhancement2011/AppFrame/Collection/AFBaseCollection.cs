using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AppFrame.Controls;

namespace AppFrame.Collection
{
    [Serializable()]
    public class AFBaseCollection<T> : BindingList<T>,ITypedList
    {
        private BindingSource bindingSource;
        /// <summary>
        ///  gfgfd
        /// </summary>
        /// <param name="source"></param>
        public AFBaseCollection(BindingSource source) : base()
        {
            bindingSource = source;
            bindingSource.DataSource = this;
        }

        /// <summary>
        /// 
        /// </summary>
        public AFBaseCollection()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public AFBaseCollection(IList<T> list)
            : base(list)
        {
        }

        public BindingSource ParentBindingSource
        {
            get { return bindingSource; }
            set { bindingSource = value; }
        }
        #region implement sortable
        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            // Get the property info for the specified property.
            //PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
            //PropertyInfo propInfo = prop.
            T item;

            if (key != null)
            {
                // Loop through the items to see if the key
                // value matches the property value.
                for (int i = 0; i < Count; ++i)
                {
                    item = (T)Items[i];
                    if (prop.GetValue(item).Equals(key))
                        return i;
                }
            }
            return -1;
        }
        public int Find(string property, object key)
        {
            // Check the properties for a property with the specified name.
            PropertyDescriptorCollection parentProperties =
                TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptorCollection properties = ComplexListPropertyHelper.GetList(parentProperties, typeof(T).FullName);
            PropertyDescriptor prop = properties.Find(property, true);

            // If there is not a match, return -1 otherwise pass search to
            // FindCore method.
            if (prop == null)
                return -1;
            else
                return FindCore(prop, key);
        }
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        
        bool isSortedValue;
        protected override bool IsSortedCore
        {
            get { return isSortedValue; }
        }

        ListSortDirection sortDirectionValue;
        PropertyDescriptor sortPropertyValue;
        private ArrayList sortedList;
        ArrayList unsortedItems;
        protected override void ApplySortCore(PropertyDescriptor prop,
            ListSortDirection direction)
        {
            sortedList = new ArrayList();

            // Check to see if the property type we are sorting by implements
            // the IComparable interface.
            Type interfaceType = prop.PropertyType.GetInterface("IComparable");

            if (interfaceType != null)
            {
                // If so, set the SortPropertyValue and SortDirectionValue.
                sortPropertyValue = prop;
                sortDirectionValue = direction;

                unsortedItems = new ArrayList(this.Count);

                // Loop through each item, adding it the the sortedItems ArrayList.
                foreach (Object item in this.Items)
                {
                    sortedList.Add(prop.GetValue(item));
                    unsortedItems.Add(item);
                }
                // Call Sort on the ArrayList.
                sortedList.Sort();
                T temp;

                // Check the sort direction and then copy the sorted items
                // back into the list.
                if (direction == ListSortDirection.Descending)
                    sortedList.Reverse();

                for (int i = 0; i < this.Count; i++)
                {
                    int position = Find(prop.Name, sortedList[i]);
                    if(position == -1)
                    {
                        continue;
                    }
                    if (position != i)
                    {
                        temp = this[i];
                        this[i] = this[position];
                        this[position] = temp;
                    }
                }

                isSortedValue = true;

                // Raise the ListChanged event so bound controls refresh their
                // values.
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
            else
                // If the property type does not implement IComparable, let the user
                // know.
                throw new NotSupportedException("Cannot sort by " + prop.Name +
                    ". This" + prop.PropertyType.ToString() +
                    " does not implement IComparable");
        }
        protected override void RemoveSortCore()
        {
            int position;
            object temp;
            // Ensure the list has been sorted.
            if (unsortedItems != null)
            {
                // Loop through the unsorted items and reorder the
                // list per the unsorted list.
                for (int i = 0; i < unsortedItems.Count; )
                {
                    position = this.Find("LastName",
                        unsortedItems[i].GetType().
                        GetProperty("LastName").GetValue(unsortedItems[i], null));
                    if (position > 0 && position != i)
                    {
                        temp = this[i];
                        this[i] = this[position];
                        this[position] = (T)temp;
                        i++;
                    }
                    else if (position == i)
                        i++;
                    else
                        // If an item in the unsorted list no longer exists,
                        // delete it.
                        unsortedItems.RemoveAt(i);
                }
                isSortedValue = false;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        public void RemoveSort()
        {
            RemoveSortCore();
        }
        

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortPropertyValue; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirectionValue; }
        }
        public override void EndNew(int itemIndex)
        {
            // Check to see if the item is added to the end of the list,
            // and if so, re-sort the list.
            if (sortPropertyValue != null && itemIndex == this.Count - 1)
                ApplySortCore(this.sortPropertyValue, this.sortDirectionValue);

            base.EndNew(itemIndex);
        }
        #endregion
        #region ITypedList Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listAccessors"></param>
        /// <returns></returns>
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
                TypeDescriptor.GetProperties(typeof(T));
            if (designTime)
            {
                return propertyDescriptorCollection;
            }
            else
            {
                PropertyDescriptorCollection descriptorCollection = ComplexListPropertyHelper.GetList(propertyDescriptorCollection, typeof(T).FullName);

                PropertyDescriptor[] descriptors = new PropertyDescriptor[descriptorCollection.Count];
                
                return descriptorCollection;
            }
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

        #endregion
    }
}
