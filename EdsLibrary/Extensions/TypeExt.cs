using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace EdsLibrary.Extensions
{
    public static partial class TypeExt
    {
        public static bool IsSystemType(this Type type)
        {
            return (type.Assembly.GetName().Name == "mscorlib");
        }
    }
}
