using System;

namespace DynamicProxyDemo
{
    /// <summary>
    /// Test class.
    /// </summary>
    public class SecurityManager
    {
        ///<summary>
        /// Test method which can be implemented to check if a given method can
        /// be accessed by a user given the following role.
        /// NOTE:  This does not have any implementation...it's only used as a placeholder
        ///</summary>
        public static bool IsMethodInRole(string userRole, string methodName)
        {
            // check if the specified user role can invoke the method
            return true;
        }
    }
}