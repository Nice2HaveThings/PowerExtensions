using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PowerExtensions.Reflection
{
    public static class TypeExtensions
    {
        public static bool IsSimple(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return IsSimple(typeInfo.GetGenericArguments()[0]);
            }
            return typeInfo.IsPrimitive
              || typeInfo.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal));
        }

        public static bool IsComplex(this Type type)
        {
            return !IsSimple(type);
        }

        public static bool IsNullable(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return 
                type == typeof(string) ||
                typeInfo.IsClass ||
                typeInfo.IsInterface ||
                Nullable.GetUnderlyingType(type) != null;
        }

        public static IEnumerable<PropertyInfo> GetPropertiesAll(this Type type)
        {
            return type.GetTypeInfo().DeclaredProperties;
        }

        public static IEnumerable<FieldInfo> GetFieldsAll(this Type type)
        {
            return type
                .GetTypeInfo()
                .DeclaredFields
                .Where(f => !f.Name.EndsWith(">k__BackingField"));
        }
    }
}
