using System;
using System.Reflection;
using System.Collections;

namespace DynamicProxyDemo
{
    /// <summary>
    /// Factory class used to cache Types instances
    /// </summary>
    public class MetaDataFactory
    {
        private static readonly Hashtable typeMap = new Hashtable();

        /// <summary>
        /// Class constructor.  Private because this is a static class.
        /// </summary>
        private MetaDataFactory()
        {
        }

        ///<summary>
        /// Method to add a new Type to the cache, using the type's fully qualified
        /// name as the key
        ///</summary>
        ///<param name="interfaceType">Type to cache</param>
        public static void Add(Type interfaceType)
        {
            if (interfaceType == null)
            {
                return;
            }
            lock (typeMap.SyncRoot)
            {
                if (!typeMap.ContainsKey(interfaceType.FullName))
                {
                    typeMap.Add(interfaceType.FullName, interfaceType);
                }
            }
        }

        ///<summary>
        /// Method to return the method of a given type at a specified index.
        ///</summary>
        ///<param name="name">Fully qualified name of the method to return</param>
        ///<param name="i">Index to use to return MethodInfo</param>
        ///<returns>MethodInfo</returns>
        public static MethodInfo GetMethod(string name, int i)
        {
            Type type;
            lock (typeMap.SyncRoot)
            {
                type = (Type) typeMap[name];
            }

            var methods = type.GetMethods();
            return i < methods.Length ? methods[i] : null;
        }
    }
}