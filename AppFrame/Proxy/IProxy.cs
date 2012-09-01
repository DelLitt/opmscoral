using System;

namespace AppFrame.Proxy
{
    /// <summary>
    /// An interface which should be implemented by all proxies.
    /// </summary>
    public interface IProxy
    {
        /// <summary>
        /// Gets the type of object underlying the proxy.
        /// </summary>
        /// <value>The original type.</value>
        Type OriginalType { get; }
    }
}