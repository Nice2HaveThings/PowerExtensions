using System.Runtime.Serialization;

namespace PowerExtensions.Serialization
{
    public static class SerializationExtensions
    {
        public static TValue GetValue<TValue>(this SerializationInfo info, string name)
        {
            return (TValue)info.GetValue(name, typeof(TValue));
        }
    }
}
