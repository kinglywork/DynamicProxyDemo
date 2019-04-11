using System;

namespace DynamicProxyDemo
{
    /// <inheritdoc />
    /// <summary>
    /// Test proxy invocation handler which is used to check a methods security
    /// before invoking the method
    /// </summary>
    public class SecurityInterceptor : IInvocationHandler
    {
        private readonly object _obj;

        ///<summary>
        /// Class constructor
        ///</summary>
        ///<param name="obj">Instance of object to be proxied</param>
        public SecurityInterceptor(object obj)
        {
            this._obj = obj;
        }

        ///<summary>
        /// Factory method to create a new proxy instance.
        ///</summary>
        ///<param name="obj">Instance of object to be proxied</param>
        public static object Inject(object obj)
        {
            return ProxyFactory.GetInstance().Create(new SecurityInterceptor(obj), obj.GetType());
        }

        /// <inheritdoc />
        /// <summary>
        ///  IProxyInvocationHandler method that gets called from within the proxy
        ///  instance. 
        /// </summary>
        /// <param name="proxy">Instance of proxy</param>
        /// <param name="method">Method instance</param>
        /// <param name="parameters"></param> 
        public object Invoke(object proxy, System.Reflection.MethodInfo method, object[] parameters)
        {
            object retVal;
            const string userRole = "role";

            // if the user has permission to invoke the method, the method
            // is invoked, otherwise an exception is thrown indicating they
            // do not have permission
            if (SecurityManager.IsMethodInRole(userRole, method.Name))
            {
                // The actual method is invoked
                retVal = method.Invoke(_obj, parameters);
            }
            else
            {
                throw new Exception("Invalid permission to invoke " + method.Name);
            }

            return retVal;
        }
    }
}