using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caliburn.WPF.ApplicationFramework
{
    /// <summary>
    /// The result of validation a model.
    /// </summary>
    public interface IValidationResult
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        string Message { get; }
    }
}
