using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using ArrayList=System.Collections.ArrayList;

namespace AppFrame.Controls
{
    public class ComplexListPropertyHelper
    {
        private const int MAX_VISIBLE_PROPERTIES = 128;
        string[] DotNetType = new string[]
                                  { "String","Int32","Int64","Float","Double","Boolean","DateTime" };

        

        public static PropertyDescriptorCollection GetList(PropertyDescriptorCollection propertyDescriptorCollection,Type baseType)
        {
            return GetList(propertyDescriptorCollection, baseType.Name);
        }

        public static PropertyDescriptorCollection GetList(PropertyDescriptorCollection pDescriptorCollection,string baseType)
        {
            PropertyDescriptor[] propertyDescriptors = new PropertyDescriptor[pDescriptorCollection.Count];
            pDescriptorCollection.CopyTo(propertyDescriptors,0);
            return GetList(propertyDescriptors, baseType);
            
        }

        public static PropertyDescriptorCollection GetList(PropertyDescriptor[] propertyDescriptors, string baseType)
        {
            if(propertyDescriptors == null)
            {
                return new PropertyDescriptorCollection(propertyDescriptors);
            }
            IList list = new ArrayList();
            IList typeList = new ArrayList();
            list = CopyToList(list, propertyDescriptors);
            typeList.Add(baseType);
            foreach (PropertyDescriptor parentPD in propertyDescriptors)
            {
                // add parent type as first type
                if (!IsPrimitiveOrCollectionType(parentPD.PropertyType) && TypeNotInList(parentPD, typeList))
                {
                    typeList.Add(parentPD.PropertyType.FullName);
                }
                GetList(parentPD, ref list, ref typeList);
            }
            PropertyDescriptor[] descriptors = new PropertyDescriptor[list.Count];
            list.CopyTo(descriptors, 0);
            PropertyDescriptorCollection newDescriptorCollection = new PropertyDescriptorCollection(descriptors);
            return newDescriptorCollection;
        }

        private static bool IsPrimitiveOrCollectionType(Type type)
        {
            bool retVal = type.IsPrimitive
                          || type.Name.Equals("DateTime")
                          || type.Name.Equals("String")
                          || type.Name.Equals("IList")
                          || type is IEnumerable
                          || type is IList
                          || type.IsSubclassOf(typeof(IEnumerable))
                          || type.IsSubclassOf(typeof(IList))
                          || type.IsArray
                          || type.IsGenericType
                          || type.IsEnum;
            return retVal;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentPD"></param>
        /// <param name="list"></param>
        /// <param name="typeList"></param>
        private static void GetList(PropertyDescriptor parentPD, ref IList list,ref IList typeList)
        {
            
            if (parentPD.PropertyType.Name.Equals("Product"))
            {
                
            }
            if(list.Count> MAX_VISIBLE_PROPERTIES)
            {
                return;
            }
            // check if descriptor contains any bidirectional property
            /*foreach (PropertyInfo propertyInfo in parentPD.PropertyType.GetProperties())
            {
                if (!TypeNotInList(propertyInfo.PropertyType, typeList))
                {
                    // return, if continue we will get loop forever
                    return;
                }
            }*/

            PropertyDescriptorCollection childPDs = ((PropertyDescriptor) parentPD).GetChildProperties();
            PropertyInfo[] properties = parentPD.PropertyType.GetProperties();
            // if childPDs count < 0 then return
            if (childPDs.Count <= 0)
            {
                return;
            }
            // if parentPD is immultable type then return
            Type parentType = parentPD.PropertyType;
            if (IsPrimitiveOrCollectionType(parentType) 
                ||  parentType.IsArray
                || parentType is  IEnumerable )
            {
                return;
            }
            
            // check child type
            foreach (PropertyDescriptor childPD in childPDs)
            {
                
                ComplexPropertyDescriptor subPropertyDescriptor = new ComplexPropertyDescriptor(parentPD, childPD, parentPD.Name + "." + childPD.Name);
                
                // if is primitive types
                if (IsPrimitiveOrCollectionType(childPD.PropertyType))
                {
                    if (subPropertyDescriptor.PropertyType.Name.Equals("PurchaseOrderDetailPK.DepartmentId"))
                    {
                        
                    }
                    
                    list.Add(subPropertyDescriptor);
                }
                else // custom type
                {
                    if (TypeNotInList(childPD, typeList))
                    {
                        if (subPropertyDescriptor.PropertyType.Name.Equals("PurchaseOrderDetailPK.DepartmentId"))
                        {
                            //Console.WriteLine("Here");
                        }

                        //Console.WriteLine("Sub:" + subPropertyDescriptor.Name);
                        list.Add(subPropertyDescriptor);
                        typeList.Add(childPD.PropertyType.FullName);
                        
                        /*PropertyDescriptorCollection subChildPDs = ((PropertyDescriptor)childPD).GetChildProperties();
                        if (subChildPDs.Count > 0)
                        {*/
                            GetList(subPropertyDescriptor, ref list, ref typeList);
                        /*}*/
                    }
                }
            }
        }

        private static bool TypeNotInList(PropertyDescriptor descriptor, IList list)
        {
            foreach (string typeName in list)
            {
                if(typeName.Equals(descriptor.PropertyType.FullName))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool TypeNotInList(Type type, IList list)
        {
            foreach (string typeName in list)
            {
                if (typeName.Equals(type.FullName))
                {
                    return false;
                }
            }
            return true;
        }


        private static bool PropertyDescriptorNotInList(PropertyDescriptor descriptor, IList list)
        {

            foreach (PropertyDescriptor propDesc in list)
            {
                if (descriptor.DisplayName.Equals(propDesc.DisplayName))
                {
                    return false;
                }
            }
            return true;
        }

        private static IList CopyToList(IList list, PropertyDescriptorCollection cols)
        {
            foreach (PropertyDescriptor col in cols)
            {
                list.Add(col);
            }
            return list;
        }
        private static IList CopyToList(IList list, PropertyDescriptor[] cols)
        {
            foreach (PropertyDescriptor col in cols)
            {
                list.Add(col);
            }
            return list;
        }
    }
}
