using System;
using System.ComponentModel;

namespace AppFrame.Controls
{
    public class ComplexCustomDescriptionProvider<T> : TypeDescriptionProvider
    {   

            private ICustomTypeDescriptor td;
            public ComplexCustomDescriptionProvider()

                : this(TypeDescriptor.GetProvider(typeof(T)))
            {

            }

            public ComplexCustomDescriptionProvider(TypeDescriptionProvider parent)

                : base(parent)
            {

            }

            public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
            {

                if (td == null)
                {
                    td = base.GetTypeDescriptor(objectType, instance);
                    td = new ComplexCustomTypeDescriptor(td);
                }
                return td;
            }
            
    }
}
