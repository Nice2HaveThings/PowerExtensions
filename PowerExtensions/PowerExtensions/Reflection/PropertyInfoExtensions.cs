using System.Linq;
using System.Reflection;

namespace PowerExtensions.Reflection
{
    /// <summary>
    /// Extentions for <see cref="PropertyInfo"/>
    /// </summary>
    public static class PropertyInfoExtensions
    {
        /// <summary>
        /// Determined if the property is public
        /// </summary>
        /// <param name="info">Information of the property</param>
        /// <returns><see langword="true"/> if the property is public</returns>
        /// <remarks>The protection-level of the declaring class is not taken into account</remarks>
        public static bool IsPublic(this PropertyInfo info)
        {
            return info.DeclaringType.GetProperties().Any(pi => pi.Name == info.Name);
        }

        /// <summary>
        /// Determinde if the property isn't public
        /// </summary>
        /// <param name="info">Information of the property</param>
        /// <returns><see langword="true"/> if the property isn't public</returns>
        /// /// <remarks>The protection-level of the declaring class is not taken into account</remarks>
        public static bool IsNonPublic(this PropertyInfo info)
        {
            return !info.GetMethod.IsPublic && !info.SetMethod.IsPublic;
        }

        /// <summary>
        /// Determinde if the property is a instance member
        /// </summary>
        /// <param name="info">Information of the property</param>
        /// <returns><see langword="true"/> if the property is a instance member</returns>
        public static bool IsInstance(this PropertyInfo info)
        {
            return !info.GetMethod.IsStatic;
        }

        /// <summary>
        /// Determinde if the property is a static member
        /// </summary>
        /// <param name="info">Information of the property</param>
        /// <returns><see langword="true"/> if the property is a static member</returns>
        public static bool IsStatic(this PropertyInfo info)
        {
            return info.GetMethod.IsStatic;
        }
    }
}
