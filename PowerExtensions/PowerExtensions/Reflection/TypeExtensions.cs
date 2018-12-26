using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PowerExtensions.Reflection
{
    /// <summary>
    /// Extension for <see cref="Type"/>
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Determined if the type given <paramref name="type"/> is a .net value-type or a string or datetime
        /// </summary>
        /// <param name="type">Information of the given type</param>
        /// <returns><see langword="true"/> if the given type is simple</returns>
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

        /// <summary>
        /// Determined if the given <paramref name="type"/> is a reference-type (except string or datetime)
        /// </summary>
        /// <param name="type">Information of the given type</param>
        /// <returns><see langword="true"/> if the type is complex</returns>
        public static bool IsComplex(this Type type)
        {
            return !IsSimple(type);
        }

        /// <summary>
        /// Determined if the given <paramref name="type"/> is nullable
        /// </summary>
        /// <param name="type">Information of the type</param>
        /// <returns><see langword="true"/> if the type is nullable</returns>
        public static bool IsNullable(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return 
                type == typeof(string) ||
                typeInfo.IsClass ||
                typeInfo.IsInterface ||
                Nullable.GetUnderlyingType(type) != null;
        }

        /// <summary>
        /// Returns all properties of the <paramref name="type"/> despite the protection level
        /// </summary>
        /// <param name="type">Information of the type</param>
        /// <returns>Collection of all properties</returns>
        public static IEnumerable<PropertyInfo> GetPropertiesAll(this Type type)
        {
            return type.GetTypeInfo().DeclaredProperties;
        }

        /// <summary>
        /// Returns all fields of the <paramref name="type"/> without the default backing-fields despite the protection level
        /// </summary>
        /// <param name="type">Information of the type</param>
        /// <returns>Collection of all fields</returns>
        public static IEnumerable<FieldInfo> GetFieldsAll(this Type type)
        {
            return type
                .GetTypeInfo()
                .DeclaredFields
                .Where(f => !f.Name.EndsWith(">k__BackingField"));
        }
    }
}
