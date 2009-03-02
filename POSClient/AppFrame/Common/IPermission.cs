using AppFrame.Common;

namespace AppFrame.Common
{
    public interface IPermission
    {
        /// <summary>
        /// Check whether user has right to access an object
        /// </summary>
        /// <param name="accessingObject">Object which user access</param>
        /// <param name="user">BaseUser are accessing object</param>
        /// <returns>true if user has right and vice versa</returns>
        bool HasPermission(object accessingObject, BaseUser user);
    }
}