using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Utility.Mapper
{   
    /// <summary>
    /// Base class for converter
    /// </summary>
    /// <typeparam name="TDestinationClass">Destination of class converted</typeparam>
    /// <typeparam name="TSourceClass">Source class</typeparam>
    public interface BaseMapper<TDestinationClass,TSourceClass>
    {
        TDestinationClass Convert(TSourceClass source);
    }
}
