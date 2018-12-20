# PowerExtensions

PowerExtensions are a hobby project of a senior developer which helps you to write faster, cleaner and more understandable code with the use of helpful extension methods. Those methods are used in my daily business and i guess everyone of you had written or think of them before. They are full unit-testet, feel free to use them, add pull requests or make some issues.

### Table of implemented extensions
* Linq
	* IDictionary<K,V>.AddIfMissing(key, Func<K,V>)
	* IDictionary<K,V>.GetOrAdd(key, Func<K,V>)
	* IEnumerable<T>.Second()
	* IEnumerable<T>.Second(Predicate)
	* IEnumerable<T>.SecondOrDefault()
	* IEnumerable<T>.SecondOrDefault(Predicate)
	* IEnumerable<T>.Third()
	* IEnumerable<T>.Third(Predicate)
	* IEnumerable<T>.ThirdOrDefault()
	* IEnumerable<T>.ThirdOrDefault(Predicate)
* Reflection
	* Type.IsComplex()
	* Type.IsNullable()
	* Type.IsSimple()
* Serialization
	* SerializationInfo.GetValue<T>(name)
* Transformation
	* IEnumerable<IGrouping<K,V>>.ToDictionary()