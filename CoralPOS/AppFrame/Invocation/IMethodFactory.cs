using System.Reflection;

namespace AppFrame.Invocation
{
    /// <summary>
    /// A service capable of creating instances of <see cref="IMethod"/>.
    /// </summary>
    public interface IMethodFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="IMethod"/> using the <see cref="MethodInfo"/>.
        /// </summary>
        /// <param name="methodInfo">The method info.</param>
        /// <returns>The method.</returns>
        IMethod CreateFrom(MethodInfo methodInfo);
    }
}