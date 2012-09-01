using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caliburn.WPF.ApplicationFramework
{
    /// <summary>
    /// A type of <see cref="IModelNode"/> that represents a property.
    /// </summary>
    public interface IProperty //: IModelNode, ISupportInterrogation
    {
        /// <summary>
        /// Gets the definition.
        /// </summary>
        /// <value>The definition.</value>
        //IPropertyDefinition Definition { get; }

        /// <summary>
        /// Gets or sets the untyped value.
        /// </summary>
        /// <value>The untyped value.</value>
        object UntypedValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object GetView(string name);
    }

    /// <summary>
    /// A strongly typed version of <see cref="IProperty"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProperty<T> : IProperty
    {
        /// <summary>
        /// Gets the definition.
        /// </summary>
        /// <value>The definition.</value>
        //new IPropertyDefinition<T> Definition { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        T Value { get; set; }
    }
}
