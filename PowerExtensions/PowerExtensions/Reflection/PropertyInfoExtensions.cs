using System.Linq;
using System.Reflection;

namespace PowerExtensions.Reflection
{
    public static class PropertyInfoExtensions
    {
        public static bool IsPublic(this PropertyInfo info)
        {
            return info.DeclaringType.GetProperties().Any(pi => pi.Name == info.Name);
        }

        public static bool IsNonPublic(this PropertyInfo info)
        {
            return !info.GetMethod.IsPublic && !info.SetMethod.IsPublic;
        }

        public static bool IsInstance(this PropertyInfo info)
        {
            return !info.GetMethod.IsStatic;
        }

        public static bool IsStatic(this PropertyInfo info)
        {
            return info.GetMethod.IsStatic;
        }
    }
}
