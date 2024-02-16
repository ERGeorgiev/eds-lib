using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EdsLibrary.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        /// Attempts to cast an object into another object using reflection.
        /// </summary>
        public static T Cast<T>(this object parent, params string[] ignoredFields)
        {
            T child = (T)Activator.CreateInstance(typeof(T));
            foreach (PropertyInfo prop in parent.GetType().GetProperties().Where(p => ignoredFields.Contains(p.Name) == false))
            {
                try
                {
                    if (child.GetType().GetProperty(prop.Name) != null)
                    {
                        child.GetType().GetProperty(prop.Name).SetValue(child, prop.GetValue(parent, null), null);
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return child;
        }
    }
}
