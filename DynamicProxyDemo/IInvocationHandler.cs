using System;
using System.Reflection;

namespace DynamicProxyDemo
{
    /// <summary>
    /// Interface that a user defined proxy handler needs to implement.  This interface 
    /// defines one method that gets invoked by the generated proxy.  
    /// </summary>
    public interface IInvocationHandler
    {
        /// <param name="proxy">The instance of the proxy</param>
        /// <param name="method">The method info that can be used to invoke the actual method on the object implementation</param>
        /// <param name="parameters">Parameters to pass to the method</param>
        /// <returns>Object</returns>
        object Invoke(object proxy, MethodInfo method, object[] parameters);
    }
}